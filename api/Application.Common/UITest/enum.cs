using System.Xml.Serialization;

namespace App.Common.UITest
{
    public enum EnvironmentType { 
        Firefox,
        Chrome
    }
    public enum TestReportType {
        [XmlEnum("Console")]
        Console,
        [XmlEnum("Excel")]
        Excel
    }
    public enum TestResultType { 
        None,
        Fail,
        Success
    }
    public enum UIActionType {
        Assert,
        Click,
        Input,
        Navigate
    }
    public enum BrowserType { 
        Firefox,
        Chrome,
        Safari,
        IE,
        Edge
    }
    public enum UIActionSeertType { 
        Exist,
        Text,
        Count,
        CssClass,
        Browser
    }
}
