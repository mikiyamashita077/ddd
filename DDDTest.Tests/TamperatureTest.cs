using DDD.Domain.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DDDTest.Tests
{
    [TestClass]
    public class TamperatureTest
    {
        [TestMethod]
        public void 小数点以下２桁で丸めて表示()
        {
            var temp = new Temperature(12.3f);
            Assert.AreEqual(12.3f, temp.Value);
            Assert.AreEqual("12.30℃", temp.DisplayValueWithUnit);
        }

        [TestMethod]
        public void インスタンスが同じかどうか()
        {
            var temp1 = new Temperature(12.3f);
            var temp2 = new Temperature(12.3f);
            Assert.AreEqual(false, temp1.Equals(temp2));
        }

        [TestMethod]
        public void 値が同じかどうか()
        {
            var t1 = 12.3f;
            var t2 = 12.3f;
            Assert.AreEqual(true, t1.Equals(t2));
        }
    }
}
