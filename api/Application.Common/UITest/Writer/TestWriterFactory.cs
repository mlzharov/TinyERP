using App.Common.UITest.Environment;

namespace App.Common.UITest.Writer
{
    public class TestWriterFactory
    {
        public static ITestWriter Create(IEnvironment environment) {
            switch (environment.Report.Type) {
                
                case TestReportType.Excel:
                    return new ExcelTestWriter(environment);
                case TestReportType.Console:
                default:
                    return new ConsoleTestWriter(environment);
            }
        }
    }
}
