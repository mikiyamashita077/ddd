using DDD.Domain.Entities;
using DDD.Domain.ValueObject;
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

namespace DDDWinForm
{
    public partial class WeatherSaveView : Form
    {
        private WeatherSaveViewModel weatherSaveViewModel = new WeatherSaveViewModel();
        public WeatherSaveView()
        {
            InitializeComponent();
            AreaIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            AreaIdComboBox.DataBindings.Add("SelectedValue", weatherSaveViewModel, nameof(weatherSaveViewModel.SelectedAreaId));
            AreaIdComboBox.DataBindings.Add("DataSource", weatherSaveViewModel, nameof(weatherSaveViewModel.Areas));

            AreaIdComboBox.ValueMember = nameof(AreaEntity.AreaId);
            AreaIdComboBox.DisplayMember = nameof(AreaEntity.AreaName);

            DateTimeTextBox.DataBindings.Add("Value", weatherSaveViewModel, nameof(weatherSaveViewModel.DataDateValue));
            ConditionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ConditionComboBox.DataBindings.Add("SelectedValue", weatherSaveViewModel, nameof(weatherSaveViewModel.SelectedCondition));
            ConditionComboBox.DataBindings.Add("DataSource", weatherSaveViewModel, nameof(weatherSaveViewModel.Conditions));

            ConditionComboBox.ValueMember = nameof(Condition.Value);
            ConditionComboBox.DisplayMember = nameof(Condition.DisplayValue);
            TemperatureTextBox.DataBindings.Add("Text", weatherSaveViewModel, nameof(weatherSaveViewModel.TemperatureText));
            UnitLabel.DataBindings.Add("Text", weatherSaveViewModel, nameof(weatherSaveViewModel.TemperatureUnitName));
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                weatherSaveViewModel.Save();
            }
            catch
            {
                MessageBox.Show("");
            }
        }
    }
}
