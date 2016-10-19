using System;
using System.Collections.Generic;
using App.Common.UITest.Environment;
using App.Common.UITest.Suite;

namespace App.Common.Helpers
{
    public class TestCaseHelper
    {
        public static void AddEnvirontmentParams(IList<TestDataKeyNamePair> keyPairs, IEnvironment environment)
        {
            keyPairs.Add(new TestDataKeyNamePair("baseUrl", environment.BaseUrl));
            keyPairs.Add(new TestDataKeyNamePair("height", environment.Height));
            keyPairs.Add(new TestDataKeyNamePair("outputFolder", environment.OutputFolder));
            keyPairs.Add(new TestDataKeyNamePair("width", environment.Width));
        }
        private static string GetParamKey(string name)
        {
            return "{{" + name + "}}";
        }
    }
}
