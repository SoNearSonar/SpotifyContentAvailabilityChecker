using Newtonsoft.Json;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyContentAvailabilityChecker.Helpers;
using SpotifyContentAvailabilityChecker.Objects;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace SpotifyContentAvailabilityChecker
{
    public partial class SCAC : Form
    {
        // Spotify client/object properties
        private EmbedIOAuthServer? _loginServer;
        private SpotifyClient? _client;
        private LoginRequest? _request;
        private string? _accessToken;

        // Made for holding searches and contries. Used for searching
        private ListView.ListViewItemCollection _itemCollection;

        // Made for the detection of Spotify content when searching country availability
        private int _contentSelection;

        // Made for reading and saving the saved search history
        private List<Search> _searches = new List<Search>();

        // Made for opening the history location
        private Process _process;

        public SCAC()
        {
            InitializeComponent();
        }

        private void SCAC_Load(object sender, EventArgs e)
        {
            _searches = new List<Search>();
            _contentSelection = 3;
            TXT_ContentTypeDisplay.Text = "Unknown (Not Supported)";
            CBX_SearchBy.SelectedIndex = 0;
            CBX_HistorySearchBy.SelectedIndex = 0;

            // Creating the saved history directory and the process to open it
            if (!Directory.Exists(ProcessStarterHelper.DirPath))
            {
                Directory.CreateDirectory(ProcessStarterHelper.DirPath);
            }
            _process = ProcessStarterHelper.CreateProcess(ProcessStarterHelper.DirPath, "explorer.exe");

            // Reading the saved history file (.json)
            if (File.Exists(ProcessStarterHelper.FilePath))
            {
                try
                {
                    // Try to read the .json file's content as a list of searches
                    _searches = JsonConvert.DeserializeObject<List<Search>>(File.ReadAllText(ProcessStarterHelper.FilePath));

                    // If the searches exist and there's more than zero (0) add them to the search history display
                    if (_searches != null && _searches.Count > 0)
                    {
                        foreach (Search search in _searches)
                        {
                            InsertSearchItem(search);
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
            if (!File.Exists(ProcessStarterHelper.FilePath))
            {
                try
                {
                    File.Create(ProcessStarterHelper.FilePath);
                }
                catch (Exception ex)
                {
                    MessageBoxDisplayHelper.ShowError($"An error occurred while creating the history save file:\nError: {ex.Message}", "Program error");
                }
            }

            // Add all the current listed searches in the history area to a list for processing if it is not filtered by favorites
            try
            {
                // Write all the searches from the list to a .json file
                string serializedData = JsonConvert.SerializeObject(_searches, Formatting.Indented);
                File.WriteAllText(ProcessStarterHelper.FilePath, serializedData);
            }
            catch (Exception ex)
            {
                MessageBoxDisplayHelper.ShowError($"An error occurred while saving your search history:\nError: {ex.Message}", "Program error");
            }
        }

        private void BTN_StartSearch_Click(object sender, EventArgs e)
        {
            if (_client == null || string.IsNullOrWhiteSpace(TXT_AccessToken.Text))
            {
                MessageBoxDisplayHelper.ShowError("Please get an access token before searching", "No access token entered");
                return;
            }
            else if (string.IsNullOrWhiteSpace(TXT_ContentLinkURI.Text))
            {
                MessageBoxDisplayHelper.ShowError("Please enter in a valid URL or URI\nValid content: Songs, Albums, and Podcasts", "Invalid URL or URI provided");
                return;
            }

            // 0 = Song, 1 = Album, 2 = Podcast (Detected from input)
            string id = SpotifyContentHelper.GetIDOfContent(TXT_ContentLinkURI.Text);
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
                    MessageBoxDisplayHelper.ShowError("Please enter in a valid URL or URI\nValid content: Songs, Albums, and Podcasts", "Invalid URL or URI provided");
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
                                if (CountriesListHelper.Countries[item.SubItems[1].Text].Contains(TXT_SearchInput.Text, StringComparison.InvariantCultureIgnoreCase))
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
                MessageBoxDisplayHelper.ShowError("You cannot select zero (0) or multiple items to use in a search", "Search selection error");
                return;
            }

            TXT_ContentLinkURI.Text = LVW_SearchHistory.SelectedItems[0].SubItems[5].Text;
            BTN_StartSearch_Click(sender, e);
            TCRTL_Main.SelectedIndex = 0;
        }

        private void BTN_ClearSearches_Click(object sender, EventArgs e)
        {
            if (CHK_FavoriteSearchOnly.Checked || !string.IsNullOrWhiteSpace(TXT_HistorySearch.Text)) 
            {
                MessageBoxDisplayHelper.ShowError("Please remove all filters before clearing your searches", "Search clear error");
                return;
            }

            DialogResult result = MessageBoxDisplayHelper.ShowQuestion("Are you sure you want to delete your search history?", "Confirm clearing searches");
            if (result == DialogResult.Yes)
            {
                LVW_SearchHistory.Items.Clear();
                _searches.Clear();
            }
        }

        private void BTN_ClearSpecificSearch_Click(object sender, EventArgs e)
        {
            if (LVW_SearchHistory.SelectedItems.Count == 0)
            {
                MessageBoxDisplayHelper.ShowError("Select an item on the list to delete first", "Search delete error");
                return;
            }

            foreach (ListViewItem search in LVW_SearchHistory.SelectedItems)
            {
                LVW_SearchHistory.Items.Remove(search);
                Search? specSearch = _searches.Find(item => item.Id.Equals(search.SubItems[0].Text));
                _searches.Remove(specSearch);
            }
        }

        private void CBX_HistorySearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            TXT_HistorySearch_TextChanged(sender, e);
        }

        private void TXT_HistorySearch_TextChanged(object sender, EventArgs e)
        {
            if (_searches != null)
            {
                FillHistoryApplicationObject(_searches);
            }
        }

        private void CHK_FavoriteSearchOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (CHK_FavoriteSearchOnly.Checked)
            {
                LVW_SearchHistory.Items.Clear();
                foreach (Search search in _searches)
                {
                    if (search.Favorite)
                    {
                        InsertSearchItem(search);
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
            MessageBoxDisplayHelper.ShowError($"There was an error trying to get an access token:\nError: {error}", "Authorization error");
        }

        private void SetFavorite()
        {
            foreach (ListViewItem item in LVW_SearchHistory.SelectedItems)
            {
                item.SubItems[1].Text = string.IsNullOrWhiteSpace(item.SubItems[1].Text) ? "\u2605" : "";
                Search? search = _searches.Find(search => search.Id.Equals(item.SubItems[0].Text));
                if (string.IsNullOrWhiteSpace(item.SubItems[1].Text))
                {
                    _searches[_searches.IndexOf(search)].Favorite = false;
                    if (CHK_FavoriteSearchOnly.Checked)
                    {
                        LVW_SearchHistory.Items.Remove(item);
                    }
                }
                else
                {
                    _searches[_searches.IndexOf(search)].Favorite = true;
                }
                
            }
        }

        private void FillHistoryApplicationObject(List<Search> searches)
        {
            LVW_SearchHistory.Items.Clear();
            if (!string.IsNullOrWhiteSpace(TXT_HistorySearch.Text))
            {
                switch (CBX_HistorySearchBy.SelectedIndex)
                {
                    case 0:
                        foreach (Search search in searches)
                        {
                            if (search.Title.Contains(TXT_HistorySearch.Text, StringComparison.InvariantCultureIgnoreCase))
                            {
                                InsertSearchItem(search);
                            }
                        }
                        break;
                    case 1:
                        foreach (Search search in searches)
                        {
                            if (search.Authors.Contains(TXT_HistorySearch.Text, StringComparison.InvariantCultureIgnoreCase))
                            {
                                InsertSearchItem(search);
                            }
                        }
                        break;
                }
            }
            else
            {
                if (!CHK_FavoriteSearchOnly.Checked)
                {
                    foreach (Search search in searches)
                    {
                        InsertSearchItem(search);
                    }
                }
                else
                {
                    foreach (Search search in searches)
                    {
                        if (search.Favorite)
                        {
                            InsertSearchItem(search);
                        }
                    }
                }
            }
        }

        private async void FillSongInformation(string id)
        {
            FullTrack _track;
            try
            {
                _track = await _client.Tracks.Get(id);
            }
            catch (Exception ex)
            {
                MessageBoxDisplayHelper.ShowError($"There was an error trying to get the song.\n\nError: {ex.Message}", "Retrieve song error");
                return;
            }

            if (_track != null)
            {
                string authors = SpotifyContentHelper.FillAuthorsOfContent(_track.Artists);
                FillContentInformation(_track.Name, authors, "N/A", "N/A");
                FillListViewForAvailability(_track.AvailableMarkets);
                FillSearchHistory(_track.Name, authors, SpotifyContentHelper.GetContentType(_contentSelection), _track.ExternalUrls["spotify"]);
            }
        }

        private async void FillAlbumInformation(string id)
        {
            FullAlbum _album;
            try
            {
                _album = await _client.Albums.Get(id);
            }
            catch (Exception ex)
            {
                MessageBoxDisplayHelper.ShowError($"There was an error trying to get the album.\n\nError: {ex.Message}", "Retrieve album error");
                return;
            }

            
            if (_album != null) 
            {
                string authors = SpotifyContentHelper.FillAuthorsOfContent(_album.Artists);
                FillContentInformation
                (
                    _album.Name, 
                    authors,
                    _album.Copyrights.Count > 1 ? _album.Copyrights[0].Text : "N/A",
                    _album.Copyrights.Count == 1 ? _album.Copyrights[0].Text : _album.Copyrights[1].Text
                );
                FillListViewForAvailability(_album.AvailableMarkets);
                FillSearchHistory(_album.Name, authors, SpotifyContentHelper.GetContentType(_contentSelection), _album.ExternalUrls["spotify"]);
            }
        }

        private async void FillPodcastInformation(string id)
        {
            FullShow _podcast;
            try
            {
                _podcast = await _client.Shows.Get(id);
            }
            catch (Exception ex)
            {
                MessageBoxDisplayHelper.ShowError($"There was an error trying to get the podcast.\n\nError: {ex.Message}", "Retrieve podcast error");
                return;
            }

            if (_podcast != null)
            {
                FillContentInformation(_podcast.Name, _podcast.Publisher, "N/A", "N/A");
                FillListViewForAvailability(_podcast.AvailableMarkets);
                FillSearchHistory(_podcast.Name, _podcast.Publisher, SpotifyContentHelper.GetContentType(_contentSelection), _podcast.ExternalUrls["spotify"]);
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

        private void FillListViewForAvailability(List<string> availableMarkets)
        {
            foreach (string market in availableMarkets)
            {
                ListViewItem item = new ListViewItem(new string[] { market, CountriesListHelper.Countries[market] });
                LVW_CountryResults.Items.Add(item);
            }
        }

        private void FillSearchHistory(string title, string author, string contentType, string link)
        {
            ListViewItem item = new ListViewItem(new string[] { Guid.NewGuid().ToString() , "", title, author, contentType, link });
            LVW_SearchHistory.Items.Add(item);
            _searches.Add(new Search(Guid.NewGuid().ToString(), false, title, author, contentType, link));
        }

        private void InsertSearchItem(Search search)
        {
            ListViewItem item = new ListViewItem(new string[] { search.Id, search.GetFavoriteIcon(), search.Title, search.Authors, search.Type, search.Link });
            LVW_SearchHistory.Items.Add(item);
        }
    }
}