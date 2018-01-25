using Repositories.Repositories.implements;
using Repositories.Repositories.interfaces;
using System;
using System.Data;

namespace Repositories.ConnectionBase
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _disposed;
        private IPlayersRepository _playerRepository;

        public UnitOfWork(IDbConnection connection)
        {
            _connection = connection;
            _transaction = _connection.BeginTransaction();
        }

        public IPlayersRepository PlayersRepository => _playerRepository ??
            (_playerRepository = new PlayersRepository(_connection));

        

        private void ResetRepositories()
        {
            _playerRepository = null;
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                ResetRepositories();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }

                if (_connection != null)
                {
                    _connection.Dispose();
                    _connection = null;
                }

                _disposed = true;
            }
        }
    }
}
