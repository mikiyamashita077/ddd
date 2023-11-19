using DDDWinForm.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDDWinForm.View
{
    public partial class WeatherListView : Form
    {
        private WeatherListViewModel _weatherListViewModel;

        public WeatherListView()
        {
            InitializeComponent();
            _weatherListViewModel = new WeatherListViewModel();
            SetWeatherList();
            if (_weatherListViewModel.WeatherList != null)
            {
                WeatherListDataGridView.DataSource = _weatherListViewModel.WeatherList;
            }
        }

        public void SetWeatherList()
        {
            _weatherListViewModel.ShowWeatherList();
        }
    }
}
