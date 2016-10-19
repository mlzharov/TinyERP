namespace App.Common.UITest
{
    public interface IBrowser
    {
        BrowserType Type { get; set; }
        string Name { get; set; }
        string Version { get; set; }
        string Description { get; set; }
    }
}
