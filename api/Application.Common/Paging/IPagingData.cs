using System.Collections.Generic;
namespace App.Common.Paging
{
    public interface IPagingData<DataType>
    {
        IList<DataType> Items { get;  }
        int PageIndex { get;  }
        int PageSize { get;  }
        int TotalItems { get;  }
        int TotalPages { get;  }

    }
}
