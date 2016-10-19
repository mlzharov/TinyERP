using App.Common.Data;

namespace App.Entity.Common
{
    public class Language: BaseEntity
    {
        public Language(string name, string code, string isoCode): base()
        {
            this.Name = name;
            this.Code = code;
            this.IsoCode = isoCode;
        }

        public string Name { get; set; }
        public string Code  { get; set; }
        public string IsoCode { get; set; }
        public string Description { get; set; }
    }
}
