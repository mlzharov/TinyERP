using System.Collections.Generic;
namespace App.Common.Paging
{
    public class PagingData<DataType> : IPagingData<DataType>
    {
        public IList<DataType> Items { get; private set; }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalItems { get; private set; }
        public int TotalPages { get; private set; }
        public PagingData(IList<DataType> items, int pageIndex, int pageSize, int totalItems)
        {
            this.Items = items;
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalItems = totalItems;
            this.TotalPages = totalItems / pageSize + (totalItems % pageSize != 0 ? 1 : 0);
        }
    }
}
