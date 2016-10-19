namespace Application.Common.Helpers.Html
{
    public class CommandPanelItem
    {
        public CommandPanelItem(string text, string url, string iconUrl)
        {
            this.Url = url;
            this.IconUrl = iconUrl;
            this.Text = text;
        }
        public string Url { get; set; }
        public string IconUrl { get; set; }
        public string Text { get; set; }
    }
}
