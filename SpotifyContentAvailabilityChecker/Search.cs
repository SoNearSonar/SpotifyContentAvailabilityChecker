namespace SpotifyContentAvailabilityChecker
{
    public class Search
    {
        public bool Favorite { get; set; }
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
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
