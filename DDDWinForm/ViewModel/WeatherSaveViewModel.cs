using DDD.Domain.Entities;
using DDD.Domain.Exceptions;
using DDD.Domain.Helpers;
using DDD.Domain.Repositoreis;
using DDD.Domain.ValueObject;
using DDD.Infrastructure.SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDWinForm.ViewModel
{
    public class WeatherSaveViewModel : ViewModelBase
    {
        private IWeatherRepository _weatherRepository;
        private IAreasRepository _areasRepository;
        public WeatherSaveViewModel() : this(new WeatherSQLite(), new AreasSQLite())
        {

        }

        public WeatherSaveViewModel(IWeatherRepository weatherRepository, IAreasRepository areasRepository)
        {
            _weatherRepository = weatherRepository;
            _areasRepository = areasRepository;
            DataDateValue = GetDateTime();
            SelectedCondition = Condition.Suny.Value;
            TemperatureText = string.Empty;

            foreach (var area in _areasRepository.GetData())
            {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }
        }

        public object SelectedAreaId { get; set; }
        public DateTime DataDateValue { get; set; }
        public object SelectedCondition { get; set; }
        public string TemperatureText { get; set; }

        public void Save()
        {
            Guard.IsNull(SelectedAreaId, "エリア選択してください。");
            Guard.IsFloat(TemperatureText, "温度の入力に誤りがあります。", out string outValue);
            var entity = new WeatherEntity(
                Convert.ToInt32(SelectedAreaId),
                DataDateValue,
                Convert.ToInt32(SelectedCondition),
                Convert.ToSingle(outValue)
                ) ;
            _weatherRepository.Save(entity);
        }

        public BindingList<AreaEntity> Areas { get; set; } = new BindingList<AreaEntity>();
        public BindingList<Condition> Conditions { get; set; } = new BindingList<Condition>(Condition.ToList());
        public string TemperatureUnitName { get; set; } = Temperature.UnitName;

        public virtual DateTime GetDateTime() => DateTime.Now;
    }
}
