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
        IExactusBusinessObject exac = new ExactusBusinessObject();

        [TestMethod]
        public void ObtenerBodega()
        {
            ExactusData exactus = new ExactusData("jperez", "japerez", "bremen");
            var result = exactus.ObtenerBodega();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ObtenerUsuario() {

            
            exac.ValidaUsuario("jperezz", "japerez");

        }

        [TestMethod]
        public void GrabarPedido()
        {
            
            
            exac.GrabarPedido("jperez", "japerez", "bremen");
        }

        [TestMethod]
        public void ObtenerClientePorNombre()
        {
            
            exac.ObtenerClientePorNombre("jperez", "japerez", "ABARROTERIA ROSEMY");

        }

        [TestMethod]
        public void ObtenerClientePorRuc()
        {
            exac.ObtenerClientePorRuc("jperez", "japerez", "6-710-842");
        }

        [TestMethod]
        public void ObtenerArticulo()
        {
            exac.ObtenerArticulo("jperez", "japerez", "B-51", "165", null, "ND-LOCAL", "14", null, null, null, null, null, null);
        }

        public void BuscarConsecutivo()
        {

        }







    }
}
