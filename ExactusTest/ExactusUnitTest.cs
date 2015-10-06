using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JP.Exactus.Data;
using JP.Exactus.Interfaces;
using JP.Exactus.Logic;
using JP.Exactus.Data.ViewModelExactus;
using System.Collections.Generic;

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

            List<PedidoParametrosViewModel> ListaPedido = new List<PedidoParametrosViewModel>();
            PedidoParametrosViewModel model = new PedidoParametrosViewModel();
            {
                model.BODEGA = "B-51";
                model.CLIENTE = "0000001";
                model.CONDICION_PAGO = 0;
                model.NOMBRE_CUENTA = "PRUEBA";
                model.OBSERVACIONES = "...";
                model.ORDEN_COMPRA = "...";
                model.TARJETA_CREDITO = "...";
                model.PEDIDO = "...";
                model.USUARIO_LOGIN = "sa"; /*USUARIO DE LA BASE DE DATOS DE CONEXION*/
                model.CODIGO_CONSECUTIVO = "PBA"; /*ESTE ES EL CONSECUTIVO DEL SISTEMA, SE DEBE SELECCIONAR DE ESTE METODO BuscarConsecutivo(USUARIO)*/
            }
            ListaPedido.Add(model);


            List<PedidoLineaParametrosViewModel> ListaPedidoLineas = new List<PedidoLineaParametrosViewModel>();
            int n = 1;
            while (n < 6)
            {

                PedidoLineaParametrosViewModel model1 = new PedidoLineaParametrosViewModel();
                {

                    model1.ARTICULO = "165/60R14 FALKE";
                    model1.CREADOR_POR = "jperez";
                    model1.PRECIO_UNITARIO = n * 10;
                    model1.CANTIDAD = n;
                    model1.DESCUENTO = 0;
                    model1.Linea = n;
                }

                ListaPedidoLineas.Add(model1);

                n++;
            }


            exac.GrabarPedido("jperez", "japerez", "bremen", ListaPedido, ListaPedidoLineas);
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

        [TestMethod]
        public void BuscarConsecutivo()
        {
            exac.BuscarConsecutivo("jperez", "japerez", "bremen");
        }







    }
}
