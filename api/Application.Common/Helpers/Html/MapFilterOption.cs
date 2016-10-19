namespace Application.Common.Helpers.Html
{
    public class MapFilterOption
    {
        public MapFilterOption(string text, string iconUrl, string id, string cssClass)
        {
            this.Text = text;
            this.IconUrl = iconUrl;
            this.Id = id;
            this.Class = cssClass;
        }

        public string Text { get; set; }
        public string IconUrl { get; set; }
        public string Id { get; set; }
        public string Class { get; set; }
    }
}