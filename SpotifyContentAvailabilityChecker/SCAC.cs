using Newtonsoft.Json;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using System.Diagnostics;
using System.Text;

namespace SpotifyContentAvailabilityChecker
{
    public partial class SCAC : Form
    {
        // Spotify client/object properties
        private EmbedIOAuthServer? _loginServer;
        private SpotifyClient? _client;
        private LoginRequest? _request;
        private FullTrack? _track;
        private FullAlbum? _album;
        private FullShow? _podcast;
        private string? _accessToken;

        // Countries dictionary object
        private CountriesList _countries = new CountriesList();

        // Made for holding searches and contries. Used for searching
        private ListView.ListViewItemCollection _itemCollection;
        private ListView.ListViewItemCollection _searchCollection = new ListView.ListViewItemCollection(new ListView());
        private ListView.ListViewItemCollection _favoriteSearchCollection = new ListView.ListViewItemCollection(new ListView());

        // Made for the detection of Spotify content when searching country availability
        private int _contentSelection;

        // Made for reading and saving the saved search history
        private static string _dirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SCAC");
        private static string _filePath = Path.Combine(_dirPath, "SearchHistory.json");
        private List<Search> _searches = new List<Search>();

        // Used for formatting authors and publishers
        private StringBuilder _builder = new StringBuilder();

        // Made for opening the history location
        private Process _process;

        public SCAC()
        {
            InitializeComponent();
        }

        private void SCAC_Load(object sender, EventArgs e)
        {
            _contentSelection = 3;
            TXT_ContentTypeDisplay.Text = "Unknown (Not Supported)";
            CBX_SearchBy.SelectedIndex = 0;
            CBX_HistorySearchBy.SelectedIndex = 0;

            // Creating the saved history directory and the process to open it
            if (!Directory.Exists(_dirPath))
            {
                Directory.CreateDirectory(_dirPath);
            }
            _process = new Process();
            _process.StartInfo = new ProcessStartInfo
            {
                Arguments = _dirPath,
                FileName = "explorer.exe"
            };

            // Reading the saved history file (.json)
            if (File.Exists(_filePath))
            {
                try
                {
                    List<Search> searches = JsonConvert.DeserializeObject<List<Search>>(File.ReadAllText(_filePath));
                    if (searches != null && searches.Count > 0)
                    {
                        foreach (Search search in searches)
                        {
                            ListViewItem item = new ListViewItem(new string[] { search.GetFavoriteIcon(search.Favorite), search.Title, FillAuthorsOfContent(search.Authors), search.Type, search.Link, search.Id });
                            LVW_SearchHistory.Items.Add(item);
                            _searchCollection.Add((ListViewItem)item.Clone());
                            if (search.Favorite)
                            {
                                _favoriteSearchCollection.Add((ListViewItem)item.Clone());
                            }
                        }
                    }
                }
                catch
                {

                }
            }
        }

        private async void BTN_GetAccessToken_Click(object sender, EventArgs e)
        {
            // Start a new server that is locally hosted to get a access token
            _loginServer = new EmbedIOAuthServer
            (
                new Uri("http://localhost:5000/callback"),
                5000
            );
            await _loginServer.Start();

            // Event handlers for when it is either successful or a failure
            _loginServer.ImplictGrantReceived += OnAccountUseApproved;
            _loginServer.ErrorReceived += OnAccountUseError;

            // A request using my Spotify application to get a access token
            _request = new LoginRequest
            (
                _loginServer.BaseUri,
                "4f8281c491f244d0a4b2058dbb4587a6",
                LoginRequest.ResponseType.Token
            );
            BrowserUtil.Open(_request.ToUri());
        }

        private void SCAC_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Try creating the saved history file if it does not exist
            if (!File.Exists(_filePath))
            {
                try
                {
                    File.Create(_filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show
                    (
                        "An error occurred while creating the history save file:" +
                        $"\nError: {ex.Message}",
                        "Program error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }

            // Add all the current listed searches in the history area to a list for processing if it is not filtered by favorites
            if (!CHK_FavoriteSearchOnly.Checked)
            {
                if (LVW_SearchHistory.Items.Count > 0)
                {
                    foreach (ListViewItem item in LVW_SearchHistory.Items)
                    {
                        List<string> authors = new List<string>();
                        foreach (string author in item.SubItems[2].Text.Split(','))
                        {
                            authors.Add(author.Trim());
                        }
                        _searches.Add
                        (
                            new Search
                            (
                                item.SubItems[0].Text.Equals("\u2605"),
                                item.SubItems[1].Text, 
                                authors,
                                item.SubItems[3].Text,
                                item.SubItems[4].Text,
                                item.SubItems[5].Text
                            )
                        );
                    }
                }

                // Write all the searches from the list to a .json file
                if (_searches.Count > 0)
                {
                    string serializedData = JsonConvert.SerializeObject(_searches, Formatting.Indented);
                    try
                    {
                        File.WriteAllText(_filePath, serializedData);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show
                        (
                            "An error occurred while saving your search history:" +
                            $"\nError: {ex.Message}",
                            "Program error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }

        private void BTN_StartSearch_Click(object sender, EventArgs e)
        {
            if (_client == null || string.IsNullOrWhiteSpace(TXT_AccessToken.Text))
            {
                MessageBox.Show
                (
                    "Please get an access token before searching",
                    "No access token",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            else if (string.IsNullOrWhiteSpace(TXT_ContentLinkURI.Text))
            {
                MessageBox.Show
                (
                    "Please enter in a valid URL or URI" +
                    "\nValid content: Songs, Albums, and Podcasts",
                    "Invalid URL or URI provided",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // 0 = Song, 1 = Album, 2 = Podcast (Detected from input)
            string id = GetIDOfContent(TXT_ContentLinkURI.Text);
            switch (_contentSelection)
            {
                case 0:
                    FillSongInformation(id);
                    break;
                case 1:
                    FillAlbumInformation(id);
                    break;
                case 2:
                    FillPodcastInformation(id);
                    break;
                default:
                    MessageBox.Show
                    (
                        "Please enter in a valid URL or URI" +
                        "\nValid content: Songs, Albums, and Podcasts",
                        "Invalid URL or URI provided",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    break;
            }
        }

        private void BTN_ClearSearch_Click(object sender, EventArgs e)
        {
            TXT_ContentLinkURI.Text = "";
        }

        private void TXT_ContentLinkURI_TextChanged(object sender, EventArgs e)
        {
            if (TXT_ContentLinkURI.Text.Contains("track", StringComparison.InvariantCultureIgnoreCase))
            {
                TXT_ContentTypeDisplay.Text = "Song";
                _contentSelection = 0;
            }
            else if (TXT_ContentLinkURI.Text.Contains("album", StringComparison.InvariantCultureIgnoreCase))
            {
                TXT_ContentTypeDisplay.Text = "Album";
                _contentSelection = 1;
            }
            else if (TXT_ContentLinkURI.Text.Contains("show", StringComparison.InvariantCultureIgnoreCase))
            {
                TXT_ContentTypeDisplay.Text = "Podcast";
                _contentSelection = 2;
            }
            else
            {
                TXT_ContentTypeDisplay.Text = "Unknown (Not Supported)";
                _contentSelection = 3;
            }
        }

        private void TXT_SearchInput_TextChanged(object sender, EventArgs e)
        {
            if (_itemCollection != null)
            {
                MessageBox.Show(_itemCollection.Count.ToString());
                LVW_CountryResults.Items.Clear();
                if (!string.IsNullOrWhiteSpace(TXT_SearchInput.Text))
                {
                    switch (CBX_SearchBy.SelectedIndex)
                    {
                        case 0:
                            foreach (ListViewItem item in _itemCollection)
                            {
                                if (item.SubItems[0].Text.Contains(TXT_SearchInput.Text, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    LVW_CountryResults.Items.Add((ListViewItem)item.Clone());
                                }
                            }
                            break;
                        case 1:
                            foreach (ListViewItem item in _itemCollection)
                            {
                                if (_countries.Countries[item.SubItems[1].Text].Contains(TXT_SearchInput.Text, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    LVW_CountryResults.Items.Add((ListViewItem)item.Clone());
                                }
                            }
                            break;
                    }
                }
                else
                {
                    foreach (ListViewItem item in _itemCollection)
                    {
                        LVW_CountryResults.Items.Add((ListViewItem)item.Clone());
                    }
                }
            }
        }

        private void BTN_UseSelectedSearch_Click(object sender, EventArgs e)
        {
            if (LVW_SearchHistory.SelectedItems.Count != 1)
            {
                MessageBox.Show
                (
                    "You cannot select zero (0) or multiple items to use in a search",
                    "Search selection error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            TXT_ContentLinkURI.Text = LVW_SearchHistory.SelectedItems[0].SubItems[4].Text;
            BTN_StartSearch_Click(sender, e);
        }

        private void BTN_ClearSearches_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show
            (
                "Are you sure you want to delete your search history?",
                "Confirm clearing searches",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                LVW_SearchHistory.Items.Clear();
                _searchCollection.Clear();
            }
        }

        private void BTN_ClearSpecificSearch_Click(object sender, EventArgs e)
        {
            if (LVW_SearchHistory.SelectedItems.Count == 0)
            {
                DialogResult result = MessageBox.Show
                (
                    "Select an item on the list to delete first",
                    "Search delete error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            bool foundElement = false;
            if (_searchCollection != null)
            {
                foreach (ListViewItem item in _searchCollection)
                {
                    foreach (ListViewItem search in LVW_SearchHistory.SelectedItems)
                    {
                        if (LVW_SearchHistory.Items[search.Index].SubItems[1].Text.Equals(item.SubItems[1].Text) &&
                            LVW_SearchHistory.Items[search.Index].SubItems[2].Text.Equals(item.SubItems[2].Text) &&
                            LVW_SearchHistory.Items[search.Index].SubItems[3].Text.Equals(item.SubItems[3].Text) &&
                            LVW_SearchHistory.Items[search.Index].SubItems[4].Text.Equals(item.SubItems[4].Text))
                        {
                            _searchCollection.RemoveAt(item.Index);
                            foundElement = true;
                        }
                    }
                }
            }

            if (foundElement)
            {
                FillHistoryApplicationObject(_searchCollection);
            }
        }

        private void CBX_HistorySearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            TXT_HistorySearch_TextChanged(sender, e);
        }

        private void TXT_HistorySearch_TextChanged(object sender, EventArgs e)
        {
            if (!CHK_FavoriteSearchOnly.Checked)
            {
                if (_searchCollection != null)
                {
                    FillHistoryApplicationObject(_searchCollection);
                }
            }
            else
            {
                if (_favoriteSearchCollection != null)
                {
                    FillHistoryApplicationObject(_favoriteSearchCollection);
                }
            }
        }

        private void CHK_FavoriteSearchOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (CHK_FavoriteSearchOnly.Checked)
            {
                if (_favoriteSearchCollection != null)
                {
                    LVW_SearchHistory.Items.Clear();
                    foreach (ListViewItem item in _favoriteSearchCollection)
                    {
                        LVW_SearchHistory.Items.Add((ListViewItem)item.Clone());
                    }
                }
            }
            else
            {
                TXT_HistorySearch_TextChanged(sender, e);
            }
        }

        private void LVW_SearchHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CHK_SetFavoriting.Checked)
                SetFavorite();
        }

        private async Task OnAccountUseApproved(object sender, ImplictGrantResponse response) 
        {
            await _loginServer.Stop();
            _accessToken = response.AccessToken;
            _client = new SpotifyClient(_accessToken);
            TXT_AccessToken.Invoke
            (
                () => TXT_AccessToken.Text = _accessToken
            );
        }

        private async Task OnAccountUseError(object sender, string error, string errorState)
        {
            await _loginServer.Stop();
            MessageBox.Show
            (
                "There was an error trying to get an access token:" +
                $"\nError: {error}" +
                $"\nError state: {errorState}",
                "Authorization error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        private void SetFavorite()
        {
            foreach (ListViewItem item in LVW_SearchHistory.SelectedItems)
            {
                item.SubItems[0].Text = string.IsNullOrWhiteSpace(item.SubItems[0].Text) ? "\u2605" : "";
                _searchCollection[item.Index].SubItems[0].Text = item.SubItems[0].Text;
                if (string.IsNullOrWhiteSpace(item.SubItems[0].Text) && CHK_FavoriteSearchOnly.Checked)
                {
                    LVW_SearchHistory.Items.RemoveAt(item.Index);
                    _favoriteSearchCollection.Remove(item);
                }
                /*foreach (ListViewItem searchItem in _searchCollection)
                {
                    if (searchItem.SubItems[1].Text.Equals(item.SubItems[1].Text) && searchItem.SubItems[2].Text.Equals(item.SubItems[2].Text))
                    {
                        _searchCollection[searchItem.Index].SubItems[0].Text = 
                    }
                }*/
            }
        }

        private void FillHistoryApplicationObject(ListView.ListViewItemCollection _collection)
        {
            LVW_SearchHistory.Items.Clear();
            if (!string.IsNullOrWhiteSpace(TXT_HistorySearch.Text))
            {
                switch (CBX_HistorySearchBy.SelectedIndex)
                {
                    case 0:
                        foreach (ListViewItem item in _collection)
                        {
                            if (item.SubItems[1].Text.Contains(TXT_HistorySearch.Text, StringComparison.InvariantCultureIgnoreCase))
                            {
                                LVW_SearchHistory.Items.Add((ListViewItem)item.Clone());
                            }
                        }
                        break;
                    case 1:
                        foreach (ListViewItem item in _collection)
                        {
                            if (item.SubItems[2].Text.Contains(TXT_HistorySearch.Text, StringComparison.InvariantCultureIgnoreCase))
                            {
                                LVW_SearchHistory.Items.Add((ListViewItem)item.Clone());
                            }
                        }
                        break;
                }
            }
            else
            {
                foreach (ListViewItem item in _searchCollection)
                {
                    LVW_SearchHistory.Items.Add((ListViewItem)item.Clone());
                }
            }
        }

        private async void FillSongInformation(string id)
        {
            try
            {
                _track = await _client.Tracks.Get(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show
                (
                    "There was an error trying to get the song." +
                    $"\n\nError: {ex.Message}",
                    "Retrieve song error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            if (_track != null)
            {
                string authors = FillAuthorsOfContent(_track.Artists);
                FillContentInformation(_track.Name, authors, "N/A", "N/A");
                FillListViewForAvailability(_track.AvailableMarkets);
                FillSearchHistory(_track.Name, authors, GetContentType(_contentSelection), _track.ExternalUrls["spotify"]);
            }
        }

        private async void FillAlbumInformation(string id)
        {
            try
            {
                _album = await _client.Albums.Get(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show
                (
                    "There was an error trying to get the album." +
                    $"\n\nError: {ex.Message}",
                    "Retrieve album error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            
            if (_album != null) 
            {
                string authors = FillAuthorsOfContent(_album.Artists);
                FillContentInformation
                (
                    _album.Name, 
                    authors,
                    _album.Copyrights.Count > 1 ? _album.Copyrights[0].Text : "N/A",
                    _album.Copyrights.Count == 1 ? _album.Copyrights[0].Text : _album.Copyrights[1].Text
                );
                FillListViewForAvailability(_album.AvailableMarkets);
                FillSearchHistory(_album.Name, authors, GetContentType(_contentSelection), _album.ExternalUrls["spotify"]);
            }
        }

        private async void FillPodcastInformation(string id)
        {
            try
            {
                _podcast = await _client.Shows.Get(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show
                (
                    "There was an error trying to get the podcast." +
                    $"\n\nError: {ex.Message}",
                    "Retrieve podcast error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            if (_podcast != null)
            {
                FillContentInformation(_podcast.Name, _podcast.Publisher, "N/A", "N/A");
                FillListViewForAvailability(_podcast.AvailableMarkets);
                FillSearchHistory(_podcast.Name, _podcast.Publisher, GetContentType(_contentSelection), _podcast.ExternalUrls["spotify"]);
            }
        }

        private static string GetIDOfContent(string link)
        {
            // If the content is a link (i.e.: https://open.spotify.com/track/35tlXmLyuczxvxdLiQfpNu?si=5c57d6e768584bab)
            if (link.IndexOf("http") != -1)
            {
                try
                {
                    int beginIndex = link.LastIndexOf("/") + 1;
                    if (link.IndexOf("?si=") != -1)
                    {
                        int endIndex = link.IndexOf("?si=") - 1;
                        return link.Substring(beginIndex, endIndex - beginIndex + 1);
                    }
                    else
                    {
                        return link.Substring(beginIndex);
                    }

                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show
                    (
                        "The information you have provided cannot be converted into an ID\n\n" +
                        "On Spotify content, click \"Copy (Song, Album, Podcast) Link\"",
                        "ID error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return "";
                }
            }
            // If the content is a URI (i.e.: spotify:track:35tlXmLyuczxvxdLiQfpNu)
            else
            {
                try
                {
                    int beginIndex = link.LastIndexOf(":") + 1;
                    return link.Substring(beginIndex);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show(
                        "The information you have provided cannot be converted into an ID\n\n" +
                        "On Spotify content, click \"Copy (Song, Album, Podcast) Link\"", 
                        "ID error", 
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return "";
                }
            }
        }

        private void FillItemCollectionObject()
        {
            if (_itemCollection != null)
            {
                _itemCollection.Clear();
            }
            else
            {
                _itemCollection = new ListView.ListViewItemCollection(new ListView());
            }
            foreach (ListViewItem item in LVW_CountryResults.Items)
            {
                _itemCollection.Add((ListViewItem)item.Clone());
            }
        }

        private void FillContentInformation(string title, string authors, string copyright, string soundCopyright)
        {
            LVW_CountryResults.Items.Clear();
            TXT_Title.Invoke(() => TXT_Title.Text = title);
            TXT_Copyright.Invoke(() => TXT_Copyright.Text = copyright);
            TXT_SoundCopyright.Invoke(() => TXT_SoundCopyright.Text = soundCopyright);
            TXT_Authors.Invoke(() => TXT_Authors.Text = authors);
            FillItemCollectionObject();
        }

        private string FillAuthorsOfContent(List<SimpleArtist> artists)
        {
            foreach (SimpleArtist artist in artists)
            {
                _builder.Append($"{artist.Name}, ");
            }
            string authors = _builder.ToString().Substring(0, _builder.Length - 2);
            _builder.Clear();
            return authors;
        }

        private string FillAuthorsOfContent(List<string> artists)
        {
            foreach (string artist in artists)
            {
                _builder.Append($"{artist}, ");
            }
            string authors = _builder.ToString().Substring(0, _builder.Length - 2);
            _builder.Clear();
            return authors;
        }

        private void FillListViewForAvailability(List<string> availableMarkets)
        {
            foreach (string market in availableMarkets)
            {
                ListViewItem item = new ListViewItem(new string[] { market, _countries.Countries[market] });
                LVW_CountryResults.Items.Add(item);
            }
        }

        private void FillSearchHistory(string title, string author, string contentType, string link)
        {
            ListViewItem item = new ListViewItem(new string[] { "", title, author, contentType, link, Guid.NewGuid().ToString() });
            LVW_SearchHistory.Items.Add(item);
            _searchCollection.Add((ListViewItem)item.Clone());
        }

        private static string GetContentType(int contentSelection)
        {
            switch (contentSelection)
            {
                case 0:
                    return "Song";
                case 1:
                    return "Album";
                case 2:
                    return "Podcast";
                default:
                    return "Unknown (Not Supported)";
            }
        }
    }
}