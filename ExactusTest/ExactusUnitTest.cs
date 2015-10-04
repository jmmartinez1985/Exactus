using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JP.Exactus.Data;
using JP.Exactus.Interfaces;
using JP.Exactus.Logic;

namespace ExactusTest
{
    [TestClass]
    public class ExactusUnitTest
    {

        [TestMethod]
        public void ObtenerBodega()
        {
            ExactusData exactus = new ExactusData("jperez", "japerez", "bremen");
            var result = exactus.ObtenerBodega();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ObtenerUsuario() {

            IExactusBusinessObject exac = new  ExactusBusinessObject();
            exac.obtenerUsuario("jperezz", "japerez");

        }
    }
}
