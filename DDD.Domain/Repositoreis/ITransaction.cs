using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repositoreis
{
    public interface ITransaction : IDisposable
    {
        void BeginTransaction();
        void Commit();

        void RollBack();

        DbTransaction GetDbTransaction();
    }
}
