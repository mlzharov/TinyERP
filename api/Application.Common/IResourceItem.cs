using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.Remoting.Channels;

namespace App.Common
{
    public interface IResourceItem
    {
        string Key { get; set; }
        string Message { get; set; }
        IList<string> Params { get; set; }
    }
}
