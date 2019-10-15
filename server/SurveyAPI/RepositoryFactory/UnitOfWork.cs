
using Npgsql;
using System;
using System.Configuration;
using System.Data;

namespace RepositoryFactory
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        IDbTransaction _transaction { get; set; }
        IDbConnection _connection { get; set; }
        static UnitOfWork _unitOfWork { get; set; }
        UnitOfWork()
        {
                string Connection = ConfigurationManager.ConnectionStrings["SurveyDB"].ConnectionString;
                _connection = new NpgsqlConnection(Connection);
                _connection.Open();
                _transaction = _connection.BeginTransaction();

        }

        public IDbConnection Connection { get { return _connection; } }
        public IDbTransaction Transaction { get { return _transaction; } }
        public static UnitOfWork GenerateUnitOfWork()
        {
            return _unitOfWork = new UnitOfWork();
        }
        public void Commit()
        {
            _transaction.Commit();
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }

        public void RollBack()
        {
            _transaction.Rollback();
        }
    }
}

