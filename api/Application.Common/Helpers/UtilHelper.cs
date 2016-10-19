namespace App.Common.Helpers
{
    public class UtilHelper
    {
        public static string ToKey(string str) {
            if (string.IsNullOrWhiteSpace(str)) { return string.Empty; }
            return str.Replace(" ","_");
        }
    }
}
