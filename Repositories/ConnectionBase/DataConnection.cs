﻿using System;
using System.Data;

namespace Repositories.ConnectionBase
{
    public class DataConnection : IDisposable
    {
        private IDbConnection _connection;
        protected IDbConnection Connection
        {
            get
            {
                if (_connection.State != ConnectionState.Open && _connection.State != ConnectionState.Connecting)
                    _connection.Open();

                return _connection;
            }
        }
        public DataConnection(IDbConnection connection)
        {
            _connection = connection;
        }
        public void Dispose()
        {
            if (_connection != null && _connection.State != ConnectionState.Closed)
                _connection.Close();
        }
    }
}
