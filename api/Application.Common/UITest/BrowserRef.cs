namespace App.Common.UITest
{
    public class BrowserRef : IBrowser
    {
        public BrowserType Type { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
    }
}
