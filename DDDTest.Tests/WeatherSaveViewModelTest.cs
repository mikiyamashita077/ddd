using DDD.Domain.Entities;
using DDD.Domain.Exceptions;
using DDD.Domain.Repositoreis;
using DDDWinForm.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace DDDTest.Tests
{
    [TestClass]
    public class WeatherSaveViewModelTest
    {
        [TestMethod]
        public void 天気登録シナリオ()
        {
            var weatherMock = new Mock<IWeatherRepository>();
            var areasMock = new Mock<IAreasRepository>();
            List<AreaEntity> areas = new List<AreaEntity>();
            areas.Add(new AreaEntity(1, "東京"));
            areas.Add(new AreaEntity(2, "神戸"));

            areasMock.Setup(x => x.GetData()).Returns(areas);

            var viewModelMock = new Mock<WeatherSaveViewModel>(weatherMock.Object, areasMock.Object);
            viewModelMock.Setup(x => x.GetDateTime()).Returns(Convert.ToDateTime("2018/01/01 12:34:56"));
            var viewModel = viewModelMock.Object;
            // 初期値テスト
            viewModel.SelectedAreaId.IsNull(null);
            viewModel.DataDateValue.Is(Convert.ToDateTime("2018/01/01 12:34:56"));
            viewModel.SelectedCondition.Is(1);
            viewModel.TemperatureText.Is(string.Empty);
            viewModel.TemperatureUnitName.Is("℃");

            viewModel.Areas.Count.Is(2);
            viewModel.Conditions.Count.Is(4);

            var ex = AssertEx.Throws<InputException>(() => viewModel.Save());
            ex.Message.Is("エリア選択してください。");
            viewModel.SelectedAreaId = 2;
            //ex.Message.Is("温度の入力に誤りがあります。");
            viewModel.TemperatureText = "12.345";

            weatherMock.Setup(x => x.Save(It.IsAny<WeatherEntity>())).Callback<WeatherEntity>(saveValue =>
            {
                saveValue.AreaId.Value.Is(2);
                saveValue.DateTime.Is(Convert.ToDateTime("2018/01/01 12:34:56"));
                saveValue.Condition.Value.Is(1);
                saveValue.Temperature.Value.Is(12.345f);

            });

            viewModel.Save();
            weatherMock.VerifyAll();
        }
    }
}
