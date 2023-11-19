using DDD.Domain.Entities;
using DDD.Domain.Repositoreis;
using DDD.Infrastructure.SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDDWinForm.ViewModel
{
    public class WeatherLatesViewModel : ViewModelBase
    {
        private IWeatherRepository _weatherRepository;
        private IAreasRepository _areasRepository;

        public WeatherLatesViewModel() : this(new WeatherSQLite(), new AreasSQLite())
        {

        }

        public WeatherLatesViewModel(IWeatherRepository weatherRepository, IAreasRepository areasRepository)
        {
            _weatherRepository = weatherRepository;
            _areasRepository = areasRepository;
            //var weatherEntities = _weatherRepository.GetData();
            //WeatherEntities = new BindingList<WeatherEntity>();
            //foreach (var row in weatherEntities)
            //{
            //    var weatherEntity = new WeatherEntity(row.AreaId, row.DateTime, row.Condition.Value, row.Temperature.Value);
            //    WeatherEntities.Add(weatherEntity);
            //}
            foreach (var area in _areasRepository.GetData())
            {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }
        }

        private object _selectedAreaId;
        public object SelectedAreaId 
        { 
            get => _selectedAreaId;
            set => SetProperty(ref _selectedAreaId, value);
        }

        private DateTime _date;
        public DateTime DataDate 
        { 
            get => _date;
            set => SetProperty(ref _date, value);
        }

        private string _condition;
        public string Condition 
        { 
            get => _condition;
            set => SetProperty(ref _condition, value);
        }

        private string _temperature;
        public string Temperature 
        { 
            get => _temperature;
            set => SetProperty(ref _temperature, value);
        }

        public BindingList<WeatherEntity> WeatherEntities { get; set; }

        public BindingList<AreaEntity> Areas { get; set; } = new BindingList<AreaEntity>();

        public void Search()
        {
            var weatherEntity = _weatherRepository.GetLatest(Convert.ToInt32(SelectedAreaId.ToString()));
            
            if (weatherEntity == null)
            {
                DataDate = DataDate.Date;
                Condition = string.Empty;
                Temperature = string.Empty;
            }
            else
            {
                SelectedAreaId = weatherEntity.AreaId;
                DataDate = weatherEntity.DateTime;
                Condition = weatherEntity.Condition.DisplayValue;
                Temperature = weatherEntity.Temperature.DisplayValueWithUnit;
            }
        }
    }
}
