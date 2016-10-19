using App.Common.Mapping;
using App.Common.Paging;
using System.Collections.Generic;
namespace App.Common.Data
{
    public interface IBaseRepository<TEntity>
    {
        TEntity GetById(string id, string includes = "");
        TResult GetById<TResult>(string id) where TResult : IMappedFrom<TEntity>;
        void Add(TEntity item);
        void Delete(string id);
        void Update(TEntity item);
        IList<TResult> GetItems<TResult>(string include = "") where TResult : IMappedFrom<TEntity>;


        IPagingData<TResult> GetAll<TResult, SearchRequestType>(IPagingRequest<SearchRequestType> request) where TResult : IMappedFrom<TEntity>;
        IPagingData<TEntity> GetAll<SearchRequestType>(IPagingRequest<SearchRequestType> request);

    }
}
