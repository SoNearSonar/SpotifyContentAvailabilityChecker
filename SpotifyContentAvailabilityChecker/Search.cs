namespace SpotifyContentAvailabilityChecker
{
    public class Search
    {
        public bool Favorite;

        public string Title;

        public List<string> Authors;

        public string Type;

        public string Link;

        public string Id;

        public Search(bool Favorite, string Title, List<string> Authors, string Type, string Link, string Id) 
        {
            this.Favorite = Favorite;
            this.Title = Title;
            this.Authors = Authors;
            this.Type = Type;
            this.Link = Link;
            this.Id = Id;
        }

        public string GetFavoriteIcon(bool Favorite)
        {
            return Favorite ? "\u2605" : "";
        }
    }
}
