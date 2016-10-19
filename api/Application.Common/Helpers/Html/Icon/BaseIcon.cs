namespace Application.Common.Helpers.Html.Icon
{
    public class BaseIcon
    {
        public BaseIcon(IconType type)
        {
            this.Type = type;
        }

        public BaseIcon(string text, string url, string cssClass, IconType type)
        {
            this.Text = text;
            this.Url = url;
            this.Type = type;
            this.Class = cssClass;
        }

        public BaseIcon(string text, string url, string cssClass, IconType type, string id, string onClick)
        {
            this.Text = text;
            this.Url = url;
            this.Type = type;
            this.Class = cssClass;
            this.Id = id;
            this.OnClick = onClick;
        }

        public string OnClick { get; set; }
        public string Id { get; set; }
        public string Class { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public IconType Type { get; set; }
    }
}
