using DDD.Domain.Entities;
using DDD.Domain.Exceptions;
using DDD.Domain.Repositoreis;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.SQLite
{
    public sealed class AreasSQLite : IAreasRepository
    {
        public IReadOnlyList<AreaEntity> GetData()
        {
            string sql = @"select 
                                AreaId,
                                AreaName
                                from Areas";
            return SQLiteHepler.Query<AreaEntity>(sql, render =>
            {
                return new AreaEntity(Convert.ToInt32(render["AreaId"]),
                         Convert.ToString(render["AreaName"]));
            }
            );
        }
    }
}
