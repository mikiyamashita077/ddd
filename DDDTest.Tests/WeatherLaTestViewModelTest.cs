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
    public class WeatherLaTestViewModelTest
    {
        [TestMethod]
        public void シナリオ()
        {
            var mock = new Mock<IWeatherRepository>();
            var areasMoc = new Mock<IAreasRepository>();
            var areas = new List<AreaEntity>();
            areas.Add(new AreaEntity(1, "東京"));
            areas.Add(new AreaEntity(2, "神戸"));

            areasMoc.Setup(x => x.GetData()).Returns(areas);
            var viewModel = new WeatherLatesViewModel(mock.Object, areasMoc.Object);
            mock.Setup(x => x.GetLatest(1)).Returns(new WeatherEntity
                (
                    1,
                    Convert.ToDateTime("2018/01/01 00:00:00"),
                    2,
                    12.3f));

            viewModel.SelectedAreaId = 1;
            viewModel.Search();
            Assert.IsNull(viewModel.SelectedAreaId);
            Assert.AreEqual("2018/01/01 0:00:00", viewModel.DataDate.ToString());
            Assert.AreEqual("曇り", viewModel.Condition);
            Assert.AreEqual("12.30℃", viewModel.Temperature);

            Assert.AreEqual(2, viewModel.Areas.Count);


            mock.Setup(x => x.GetLatest(2)).Returns(new WeatherEntity
            (
                2,
                Convert.ToDateTime("2018/01/01 12:00:00"),
                3,
                24.3f));

            viewModel.SelectedAreaId = 2;
            viewModel.Search();
            // Chaining Assertion
            viewModel.SelectedAreaId.Is(2);
            Assert.AreEqual(2, viewModel.SelectedAreaId);
            Assert.AreEqual("2018/01/01 12:00:00", viewModel.DataDate.ToString());
            Assert.AreEqual("雨", viewModel.Condition);
            Assert.AreEqual("24.30℃", viewModel.Temperature);
            //Assert.ThrowsException<InputException>();
            //AssertEx.Throws<InputException>(() => );
        }
    }
}
