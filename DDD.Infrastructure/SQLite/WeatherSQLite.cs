using DDD.Domain.Entities;
using DDD.Domain.Repositoreis;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Windows.Forms;

namespace DDD.Infrastructure.SQLite
{
    public class WeatherSQLite : IWeatherRepository
    {

        public WeatherEntity GetLatest(int areaId)
        {
            string sql = @"select 
                                DataDate,
                                Condition,
                                Temperature
                                from Weather
                                where AreaId = @AreaId 
                                order by DateTime desc
                                LIMIT 1";
            return SQLiteHepler.Query(sql,
                new List<SQLiteParameter>
                {
                    new SQLiteParameter("@AreaId", areaId)
                }.ToArray(), render =>
            {
                return new WeatherEntity(areaId, Convert.ToDateTime(render["DataDate"]), Convert.ToInt32(render["Condition"]), Convert.ToSingle(render["Temperature"]));
            }, null) ;
        }

        public IReadOnlyCollection<WeatherEntity> GetData()
        {
            try
            {
                string sql = @"select 
                                A.AreaId,
                                ifnull(B.AreaName, '') as AreaName,
                                A.DataDate,
                                A.Condition,
                                A.Temperature
                                from Weather A left outer join Areas B on A.AreaId = B.AreaId";
                return SQLiteHepler.Query(sql, render =>
                {
                    return new WeatherEntity(Convert.ToInt32(render["AreaId"]), Convert.ToString(render["AreaName"]), Convert.ToDateTime(render["DataDate"]),
                            Convert.ToInt32(render["Condition"]), Convert.ToSingle(render["Temperature"]));
                });
            }
            catch
            {
                MessageBox.Show("aaaaaa");
                return null;
            }
        }

        public void Save(WeatherEntity weatherEntity)
        {
            string insert = @"insert into Weather 
                             (AreaId,DataDate, Condition, Temperature) values 
                             (@AreaId, @DataDate, @Condition, @Temperature)";

            string update = @"update Weather
                             set Condition = @Condition,
                             Temperature = @Temperature
                             where AreaId = @AreaId
                             and DataDate = DateTime";
            var args = new List<SQLiteParameter>
            {
                new SQLiteParameter("@AreaId", weatherEntity.AreaId.Value),
                new SQLiteParameter("@DataDate", weatherEntity.DateTime),
                new SQLiteParameter("@Condition", weatherEntity.Condition.Value),
                new SQLiteParameter("@Temperature", weatherEntity.Temperature.Value),

            };

            SQLiteHepler.Execute(insert, args.ToArray());


        }

        public void Save(ITransaction dbTransaction, WeatherEntity weatherEntity)
        {
            string insert = @"insert into Weather 
                             (AreaId,DataDate, Condition, Temperature) values 
                             (@AreaId, @DataDate, @Condition, @Temperature)";

            string update = @"update Weather
                             set Condition = @Condition,
                             Temperature = @Temperature
                             where AreaId = @AreaId
                             and DataDate = DateTime";
            var args = new List<SQLiteParameter>
            {
                new SQLiteParameter("@AreaId", weatherEntity.AreaId.Value),
                new SQLiteParameter("@DataDate", weatherEntity.DateTime),
                new SQLiteParameter("@Condition", weatherEntity.Condition.Value),
                new SQLiteParameter("@Temperature", weatherEntity.Temperature.Value),

            };

            if (dbTransaction == null)
            {
                SQLiteHepler.Execute(insert, args.ToArray());
            }
            else
            {
                SQLiteHepler.Execute(insert, args.ToArray(), dbTransaction.GetDbTransaction());
            }
        }
    }
}
