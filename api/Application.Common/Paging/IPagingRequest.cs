namespace App.Common.Paging
{
    public interface IPagingRequest<RequestDataType>
    {
        RequestDataType Data { get;  }
        int PageIndex { get;  }
        int PageSize { get;  }
    }
}
