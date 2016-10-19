namespace App.Common.UITest.Runner
{
    public interface IWebDriver : System.IDisposable
    {
        ITestRunner TestRunner { get; }
        void Click(UI.UIClickAction action);

        void Input(UI.UIInputAction action);

        void Assert(UI.UIAssertAction action);

        void Navigate(UI.UINavigateAction action);
        void Sleep(int second);
    }
}
