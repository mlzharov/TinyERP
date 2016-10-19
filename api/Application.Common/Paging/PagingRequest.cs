namespace App.Common.Paging
{
    public class PagingRequest<RequestDataType> : IPagingRequest<RequestDataType>
    {
        public RequestDataType Data { get; private set; }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public PagingRequest(RequestDataType data,int pageIndex, int pageSize)
        {
            this.Data = data;
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
        }
    }
}
