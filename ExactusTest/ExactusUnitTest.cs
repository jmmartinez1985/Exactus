using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JP.Exactus.Data;

namespace ExactusTest
{
    [TestClass]
    public class ExactusUnitTest
    {

        [TestMethod]
        public void RetornaBodega()
        {
            ExactusData exactus = new ExactusData("jperez", "*", "bremen");
            var result = exactus.RetornarBodega();
            Assert.IsNotNull(result);
        }
    }
}
