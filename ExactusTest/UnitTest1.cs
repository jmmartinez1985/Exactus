using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JP.Exactus.Data;

namespace ExactusTest
{
    [TestClass]
    public class UnitTest1
    {




        [TestMethod]
        public void TestMethod1()
        {
            ExactusData exactus = new ExactusData("jperez", "*", "bremen");
            var result = exactus.RetornarBodega();
        }
    }
}
