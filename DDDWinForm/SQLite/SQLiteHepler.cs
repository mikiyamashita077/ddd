
using DDD.Domain.Entities;
using DDD.Domain.Repositoreis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDWinForm.Hepler
{
    public class SQLiteHepler : IWeatherRepository
    {
        private readonly string ConnetionString = @"Data Source=C:\temp\2023_11_03_DDD\DDD.db";
        
        public IReadOnlyCollection<WeatherEntity> GetLatest(int areaId)
        {
            string sql = @"select 
                                DateTime,
                                Condition,
                                Temperature
                                from Weather
                                where AreaId = @AreaId 
                                order by DateTime desc
                                LIMIT 1";
            List<WeatherEntity> list = new List<WeatherEntity>();
            // DB接続する
            using (var connetion = new SQLiteConnection(ConnetionString))
            {
                using (var command = new SQLiteCommand(sql, connetion))
                {
                    connetion.Open();
                    command.Parameters.AddWithValue("@AreaId", areaId);
                    using (var render = command.ExecuteReader())
                    {
                        while (render.Read())
                        {
                            list.Add(new WeatherEntity(Convert.ToInt32(render["AreaId"]),Convert.ToDateTime(render["DateTime"]), 
                                Convert.ToInt32(render["Conditon"]), Convert.ToSingle(render["Temperature"])));
                        }
                    }
                }
            }
            return list;
        }
    }
}
