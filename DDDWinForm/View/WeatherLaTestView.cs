using DDD.Domain.Entities;
using DDDWinForm.View;
using DDDWinForm.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDDWinForm
{
    public partial class WeatherLaTestView : Form
    {
        private WeatherSaveView _weatherSaveView;
        private WeatherLatesViewModel _weatherLatesViewModel;
        private WeatherListView _weatherListView; 

        public WeatherLaTestView()
        {
            InitializeComponent();
            _weatherSaveView = new WeatherSaveView();
            _weatherLatesViewModel = new WeatherLatesViewModel();
            _weatherListView = new WeatherListView();

            AreaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            AreaComboBox.DataBindings.Add("SelectedValue", _weatherLatesViewModel, nameof(_weatherLatesViewModel.SelectedAreaId));
            AreaComboBox.DataBindings.Add("DataSource", _weatherLatesViewModel, nameof(_weatherLatesViewModel.Areas));

            AreaComboBox.ValueMember = nameof(AreaEntity.AreaId);
            AreaComboBox.DisplayMember = nameof(AreaEntity.AreaName);

            DateTime.DataBindings.Add("Text", _weatherLatesViewModel, nameof(_weatherLatesViewModel.DataDate));
            Condition.DataBindings.Add("Text", _weatherLatesViewModel, nameof(_weatherLatesViewModel.Condition));
            Temperature.DataBindings.Add("Text", _weatherLatesViewModel, nameof(_weatherLatesViewModel.Temperature));
        }

        private void LatestButton_Click(object sender, EventArgs e)
        {
            _weatherLatesViewModel.Search();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (_weatherSaveView == null)
            {
                return;
            }
            _weatherSaveView.ShowDialog();
        }

        private void WeatherList_Click(object sender, EventArgs e)
        {
            if (_weatherListView == null)
            {
                return;
            }
            _weatherListView.SetWeatherList();
            _weatherListView.ShowDialog();
        }
    }
}
