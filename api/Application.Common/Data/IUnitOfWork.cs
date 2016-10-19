
using System;

namespace App.Common.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IDbContext Context { get;}
        void Commit();
    }
}
