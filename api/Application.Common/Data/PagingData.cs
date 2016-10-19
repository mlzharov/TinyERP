using System.Collections.Generic;

namespace App.Common.Data
{
   public class PagingData<TEntity>
    {
       public PagingData()
       {
           this.TotalPages = 0;
           this.Items = new List<TEntity>();
       }
        public int TotalPages { get; set; }
        public IList<TEntity> Items { get; set; }
    }
}
