using DDD.Domain.ValueObject;
using System;

namespace DDD.Domain.Entities
{
    public sealed class WeatherEntity
    {
        /// <summary>
        /// 完全コンストラクタパターン
        /// </summary>
        /// <param name="areaId"></param>
        /// <param name="dateTime"></param>
        /// <param name="condition"></param>
        /// <param name="temperature"></param>
        public WeatherEntity(int areaId, DateTime dateTime,int condition, float temperature) : this (areaId, string.Empty,dateTime, condition, temperature)
        {
        }

        public WeatherEntity(int areaId, string areaName, DateTime dateTime, int condition, float temperature)
        {
            AreaId = new AreaId(areaId);
            AreaName = areaName;
            DateTime = dateTime;
            Condition = new Condition(condition);
            Temperature = new Temperature(temperature);
        }


        public AreaId AreaId { get; }

        public string AreaName { get; }

        public DateTime DateTime { get; }

        public Condition Condition { get; }

        public Temperature Temperature { get; }


        public bool IsOK()
        {
            return !(DateTime < DateTime.Now.AddMonths(-1) && Convert.ToSingle(Temperature.DisplayValue) < 10);
        }
    }
}
