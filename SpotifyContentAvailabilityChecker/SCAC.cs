using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;

namespace SpotifyContentAvailabilityChecker
{
    public partial class SCAC : Form
    {
        private EmbedIOAuthServer? _loginServer;
        private SpotifyClient? _client;
        private LoginRequest? _request;
        private FullTrack? _track;
        private FullAlbum? _album;
        private FullShow? _podcast;
        private CountriesList _countries = new CountriesList();
        private ListView.ListViewItemCollection _itemCollection;
        private int _contentSelection;
        private string? _accessToken;

        public SCAC()
        {
            InitializeComponent();
        }

        private void SCAC_Load(object sender, EventArgs e)
        {
            _contentSelection = 0;
            CBX_SearchBy.SelectedIndex = 0;
        }

        private async void BTN_GetAccessToken_Click(object sender, EventArgs e)
        {
            _loginServer = new EmbedIOAuthServer
            (
                new Uri("http://localhost:5000/callback"),
                5000
            );
            await _loginServer.Start();

            _loginServer.ImplictGrantReceived += OnAccountUseApproved;
            _loginServer.ErrorReceived += OnAccountUseError;

            _request = new LoginRequest
            (
                _loginServer.BaseUri,
                "4f8281c491f244d0a4b2058dbb4587a6",
                LoginRequest.ResponseType.Token
            );
            BrowserUtil.Open(_request.ToUri());
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
                                if (item.Text.Contains(TXT_SearchInput.Text, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    LVW_CountryResults.Items.Add((ListViewItem)item.Clone());
                                }
                            }
                            break;
                        case 1:
                            foreach (ListViewItem item in _itemCollection)
                            {
                                if (_countries.Countries[item.Text].Contains(TXT_SearchInput.Text, StringComparison.InvariantCultureIgnoreCase))
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

            LVW_CountryResults.Items.Clear();
            TXT_Title.Invoke(() => TXT_Title.Text = _track.Name);
            TXT_Copyright.Invoke(() => TXT_Copyright.Text = "N/A");
            TXT_SoundCopyright.Invoke(() => TXT_SoundCopyright.Text = "N/A");
            foreach (SimpleArtist artist in _track.Artists)
            {
                TXT_Authors.Invoke(() => TXT_Authors.Text = $"{artist.Name}, ");
            }
            TXT_Authors.Invoke(() => TXT_Authors.Text = TXT_Authors.Text.Substring(0, TXT_Authors.Text.Length - 2));

            foreach (string market in _track.AvailableMarkets)
            {
                ListViewItem item = new ListViewItem(new string[] { market, _countries.Countries[market] });
                LVW_CountryResults.Items.Add(item);
            }
            FillItemCollectionObject();
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

            LVW_CountryResults.Items.Clear();
            TXT_Title.Invoke(() => TXT_Title.Text = _album.Name);
            TXT_Copyright.Invoke(() => TXT_Copyright.Text = _album.Copyrights[0].Text);
            TXT_SoundCopyright.Invoke(() => TXT_SoundCopyright.Text = _album.Copyrights[1].Text);
            foreach (SimpleArtist artist in _album.Artists)
            {
                TXT_Authors.Invoke(() => TXT_Authors.Text = $"{artist.Name}, ");
            }
            TXT_Authors.Invoke(() => TXT_Authors.Text = TXT_Authors.Text.Substring(0, TXT_Authors.Text.Length - 2));

            foreach (string market in _album.AvailableMarkets)
            {
                ListViewItem item = new ListViewItem(new string[] { market, _countries.Countries[market] });
                LVW_CountryResults.Items.Add(item);
            }
            FillItemCollectionObject();
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

            LVW_CountryResults.Items.Clear();
            TXT_Title.Invoke(() => TXT_Title.Text = _podcast.Name);
            TXT_Copyright.Invoke(() => TXT_Copyright.Text ="N/A");
            TXT_SoundCopyright.Invoke(() => TXT_SoundCopyright.Text = "N/A");
            TXT_Authors.Invoke(() => TXT_Authors.Text = _podcast.Publisher);

            foreach (string market in _podcast.AvailableMarkets)
            {
                ListViewItem item = new ListViewItem(new string[] { market, _countries.Countries[market] });
                LVW_CountryResults.Items.Add(item);
            }
            FillItemCollectionObject();
        }

        private static string GetIDOfContent(string link)
        {
            // If the content is a link (i.e.: https://open.spotify.com/track/35tlXmLyuczxvxdLiQfpNu?si=5c57d6e768584bab)
            if (link.IndexOf("http") != -1)
            {
                try
                {
                    int beginIndex = link.LastIndexOf("/") + 1;
                    int endIndex = link.IndexOf("?si=") - 1;
                    return link.Substring(beginIndex, endIndex - beginIndex + 1);
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show(
                        "The information you have provided cannot be converted into an ID\n\n" +
                        "On Spotify content, click \"Copy (Song, Album, Podcast) Link\"", "ID error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        "On Spotify content, click \"Copy (Song, Album, Podcast) Link\"", "ID error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}