using System;
namespace App.Common.Validation
{
    public class ElementNotFound : Exception
    {
        public string[] Params { get; set; }
        public ElementNotFound(params string[] args)
        {
            this.Params = args;
        }
    }
}
