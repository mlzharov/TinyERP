namespace App.Common.UITest.UI
{
    public interface IUIAction: IExecutable
    {
        string Element { get;}
        TestResultType Status { get; set; }
        UIActionType Type { get;}
        App.Common.UITest.Runner.IWebDriver WebDriver { get; }
        void ResolveParams(System.Collections.Generic.IList<Suite.TestDataKeyNamePair> actionParams);

        Suite.TestCaseAction TestCaseAction { get; set; }
        App.Common.Validation.ValidationException Error { get; set; }
    }
}
