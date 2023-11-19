using DDD.Domain.Repositoreis;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.SQLite
{
    internal sealed class TransactionSQL : ITransaction, IDisposable
    {
        private DbConnection _connection;
        private DbTransaction _transaction;
        public TransactionSQL(DbConnection connection)
        {
            _connection = connection;
            _connection.Open();
        }

        public void BeginTransaction()
        {
            _transaction = _connection?.BeginTransaction();
        }

        public void Commit()
        {
            _transaction?.Commit();
        }

        public void RollBack()
        {
            _transaction?.Rollback();
        }
        public void Dispose()
        {
            _connection?.Dispose();
            _transaction?.Dispose();
        }

        public DbTransaction GetDbTransaction() => _transaction;
    }
}
