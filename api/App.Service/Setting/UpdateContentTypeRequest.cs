using System;
using System.Collections.Generic;

namespace App.Service.Setting
{
    public class UpdateContentTypeRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public IList<App.Entity.Common.Parameter> Parameters { get; set; }
        public UpdateContentTypeRequest()
        {
            this.Parameters = new List<App.Entity.Common.Parameter>();
        }
    }
}
