namespace SpotifyContentAvailabilityChecker.Objects
{
    public class Search
    {
        public string Id;

        public bool Favorite;

        public string Title;

        public string Authors;

        public string Type;

        public string Link;

        public Search(string Id, bool Favorite, string Title, string Authors, string Type, string Link)
        {
            this.Id = Id;
            this.Favorite = Favorite;
            this.Title = Title;
            this.Authors = Authors;
            this.Type = Type;
            this.Link = Link;
        }

        public string GetFavoriteIcon()
        {
            return Favorite ? "\u2605" : "";
        }
    }
}
