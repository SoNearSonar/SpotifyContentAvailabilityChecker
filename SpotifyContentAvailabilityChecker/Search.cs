namespace SpotifyContentAvailabilityChecker
{
    public class Search
    {
        public bool Favorite;

        public string Title;

        public List<string> Authors;

        public string Type;

        public string Link;

        public Search(bool Favorite, string Title, List<string> Authors, string Type, string Link) 
        {
            this.Favorite = Favorite;
            this.Title = Title;
            this.Authors = Authors;
            this.Type = Type;
            this.Link = Link;
        }

        public string GetFavoriteIcon(bool Favorite)
        {
            return Favorite ? "\u2605" : "";
        }
    }
}
