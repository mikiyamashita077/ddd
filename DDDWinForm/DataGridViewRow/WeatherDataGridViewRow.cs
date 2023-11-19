using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDWinForm.DataGridViewRow
{
    public class WeatherDataGridViewRow
    {
        private WeatherEntity _weatherEntity;
        public WeatherDataGridViewRow(WeatherEntity weatherEntity)
        {
            _weatherEntity = weatherEntity;
        }

        public string AreaId => _weatherEntity.AreaId.DisplayValue;

        public string AreaName => _weatherEntity.AreaName;

        public string DateTime => _weatherEntity.DateTime.ToString();

        public string Condition => _weatherEntity.Condition.DisplayValue.ToString();

        public string Tempareture => _weatherEntity.Temperature.DisplayValueWithUnit;
    }
}
