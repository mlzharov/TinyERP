using System.Collections.Generic;

namespace App.Service.Setting
{
    public class CreateContentTypeRequest
    {
        public CreateContentTypeRequest(string name, string key, string description)
        {
            this.Name = name;
            this.Key = key;
            this.Description = description;
        }

        public string Name { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public IList<App.Entity.Common.Parameter> Parameters { get; set; }
        public CreateContentTypeRequest()
        {
            this.Parameters = new List<App.Entity.Common.Parameter>();
        }
    }
}
