using DDD.Domain.Entities;
using DDD.Domain.Repositoreis;
using DDD.Infrastructure.SQLite;
using DDDWinForm.DataGridViewRow;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDWinForm.ViewModel
{
    public class WeatherListViewModel : ViewModelBase
    {
        private IWeatherRepository _weatherRepository;
        public WeatherListViewModel(): this(new WeatherSQLite())
        {

        }

        public WeatherListViewModel(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public BindingList<WeatherDataGridViewRow> WeatherList { get; set; } = new BindingList<WeatherDataGridViewRow>();

        public void ShowWeatherList()
        {
            WeatherList.Clear();
            foreach (var weather in _weatherRepository.GetData())
            {
                WeatherList.Add(new WeatherDataGridViewRow(weather));
            }
        }
    }
}
