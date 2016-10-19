namespace App.Common.Data
{
    public class BaseContent: BaseEntity, IBaseContent
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public ItemStatus Status { get; set; }
        public BaseContent(): base(){}
        public BaseContent(BaseContent item) : base(item) {
            this.Name = item.Name;
            this.Key = item.Key;
            this.Description = item.Description;
        }

        public BaseContent(string name, string key, string description)
        {
            Name = name;
            Key = key;
            this.Description = description;
        }
    }
}
