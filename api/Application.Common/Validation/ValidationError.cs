using System.Collections.Generic;

namespace App.Common.Validation
{
    public class ValidationError : IResourceItem
    {
        public ValidationError(string key, string message, IList<string> args=null)
        {
            this.Key = key;
            this.Message = message;
            this.Params = args ?? new List<string>();

        }

        public ValidationError(string key,  IList<string> args = null)
        {
            this.Key = key;
            this.Params = args ?? new List<string>();
        }

        public string Key { get; set; }
        public string Message { get; set; }
        public IList<string> Params { get; set; }
    }
}
