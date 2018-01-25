using System;

namespace Repositories.ConnectionBase
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}