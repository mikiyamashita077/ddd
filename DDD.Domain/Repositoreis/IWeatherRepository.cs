using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repositoreis
{
    public interface IWeatherRepository
    {
        IReadOnlyCollection<WeatherEntity> GetData();

        WeatherEntity GetLatest(int areaId);

        void Save(WeatherEntity weatherEntity);

        void Save(ITransaction dbTransaction, WeatherEntity weatherEntity);

    }
}
