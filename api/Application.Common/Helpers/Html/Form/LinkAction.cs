namespace Application.Common.Helpers.Html.Form
{
    public class LinkAction
    {
        public LinkAction(string text, string url, string iconUrl)
        {
            this.Text = text;
            this.Url = url;
            this.IconUrl = iconUrl;
        }
        public string Url { get; set; }
        public string IconUrl { get; set; }
        public string Text { get; set; }
    }
}
