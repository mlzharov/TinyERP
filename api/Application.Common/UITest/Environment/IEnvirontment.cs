using System.Collections.Generic;
namespace App.Common.UITest.Environment
{
    public interface IEnvironment : IExecutable
    {
        string Name { get; set; }
        string Description { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        string BaseUrl { get; set; }
        TestReport Report { get; set; }
        List<App.Common.UITest.Suite.TestSuiteRef> Suites { get; set; }
        BrowserRef Browser { get; set; }
        string OutputFolder { get;}
    }
}
