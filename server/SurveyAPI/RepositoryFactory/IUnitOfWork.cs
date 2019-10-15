
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RepositoryFactory
{
    public interface IUnitOfWork
    {
        void Commit();
        void RollBack();
        IDbConnection Connection { get; }
    }
}
