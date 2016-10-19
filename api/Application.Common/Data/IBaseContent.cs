using System;

namespace App.Common.Data
{
    public interface IBaseContent: IBaseEntity<Guid>
    {
        string Name { get; set; }
        string Key { get; set; }
        string Description { get; set; }
    }
}
