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

            PedidoParametrosViewModel Pedido = new PedidoParametrosViewModel();
            {
                Pedido.BODEGA = "B-51";
                Pedido.CLIENTE = "0000001";
                Pedido.CONDICION_PAGO = 0;
                Pedido.NOMBRE_CUENTA = "PRUEBA";
                Pedido.OBSERVACIONES = "...";
                Pedido.ORDEN_COMPRA = "...";
                Pedido.TARJETA_CREDITO = "...";
                Pedido.PEDIDO = "...";
                Pedido.USUARIO_LOGIN = "sa"; /*USUARIO DE LA BASE DE DATOS DE CONEXION*/
                Pedido.CODIGO_CONSECUTIVO = "PBA"; /*ESTE ES EL CONSECUTIVO DEL SISTEMA, SE DEBE SELECCIONAR DE ESTE METODO BuscarConsecutivo(USUARIO)*/
            };



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


            exac.GrabarPedido("jperez", "japerez", Pedido, ListaPedidoLineas);
        }

        [TestMethod]
        public void ObtenerClientePorNombre()
        {
            
            exac.ObtenerClientePorNombre("jperez", "japerez", "ABARROTERIA");

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
            exac.BuscarConsecutivo("jperez", "japerez");
        }

        [TestMethod]
        public void EliminarLinea()
        {
            List<PedidoLineaParametrosViewModel> lista = new List<PedidoLineaParametrosViewModel>();
            lista.Add(new PedidoLineaParametrosViewModel() { PEDIDO = "PBA-10000007", ARTICULO = "165/60R14 FALKE", Linea = 3 });
            exac.EliminarLinea("jperez", "japerez",  lista);
           
        }

        [TestMethod]
        public void InsertarLineaNueva()
        {
            List<PedidoLineaParametrosViewModel> lista = new List<PedidoLineaParametrosViewModel>();
            lista.Add(new PedidoLineaParametrosViewModel() { ARTICULO = "165/60R14 FALKE", CREADOR_POR = "jperez", PRECIO_UNITARIO = Convert.ToDecimal(107.52), CANTIDAD = 4, DESCUENTO = Convert.ToDecimal(0.00), PEDIDO = "PBA-10000007" });
            exac.InsertarLineaNueva("jperez", "japerez", lista);
        }

        [TestMethod]
        public void EliminarPedidoCompleto()
        {
            PedidoParametrosViewModel pedido = new PedidoParametrosViewModel();
            pedido.PEDIDO = "PBA-10000007";
            exac.EliminarPedidoCompleto("jperez", "japerez",  pedido);
        }

        [TestMethod]
        public void BuscarClasificacion()
        {
            exac.ObtenerClasificacion("jperez", "japerez", "1");
        }





    }
}
