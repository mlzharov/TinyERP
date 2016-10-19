using App.Common.Data;

namespace App.Entity.Setting
{
    public class ContentType : BaseContent
    {
        public ContentType():base(){}
        public ContentType(string name, string key, string description) : base(name, key, description)
        {
        }
    }
}
