using SpotifyAPI.Web;
using System.Text;

namespace SpotifyContentAvailabilityChecker.Helpers
{
    public static class SpotifyContentHelper
    {
        private static StringBuilder _builder = new StringBuilder();

        public static string GetContentType(int contentSelection)
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

        public static string GetIDOfContent(string link)
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
                    MessageBoxDisplayHelper.ShowError("The information you have provided cannot be converted into an ID\n\nOn Spotify content, click \"Copy (Song, Album, Podcast) Link\"", "ID error");
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
                    MessageBoxDisplayHelper.ShowError("The information you have provided cannot be converted into an ID\n\n" + "On Spotify content, click \"Copy (Song, Album, Podcast) Link\"", "ID error");
                    return "";
                }
            }
        }

        public static string FillAuthorsOfContent(List<SimpleArtist> artists)
        {
            foreach (SimpleArtist artist in artists)
            {
                _builder.Append($"{artist.Name}, ");
            }
            string authors = _builder.ToString().Substring(0, _builder.Length - 2);
            _builder.Clear();
            return authors;
        }

        public static string FillAuthorsOfContent(List<string> artists)
        {
            foreach (string artist in artists)
            {
                _builder.Append($"{artist}, ");
            }
            string authors = _builder.ToString().Substring(0, _builder.Length - 2);
            _builder.Clear();
            return authors;
        }
    }
}
