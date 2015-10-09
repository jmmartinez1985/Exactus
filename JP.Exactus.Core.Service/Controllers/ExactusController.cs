using JP.Exactus.Data.ViewModelExactus;
using JP.Exactus.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JP.Exactus.Core.Service.Controllers
{
    public class ExactusController : ApiController
    {
        [HttpGet]
        [Route("api/Exactus/ValidaUsuario")]
        public dynamic ValidaUsuario(string usuario, string password)
        {
            using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
            {
                var success = core.Exactus.ValidaUsuario(usuario, password);
                return new { resultado = "OK", existe = success };
            }

        }



        [HttpGet]
        [Route("api/Exactus/BuscarUltimosPedidos")]
        public dynamic BuscarUltimosPedidos(string usuario, string password)
        {
            using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
            {
                var PedidosTop = core.Exactus.BuscarUltimosPedidos(usuario, password);
                return new { resultado = "OK", pedidosLineas = PedidosTop };
            }
        }






        [HttpGet]
        [Route("api/Exactus/ObtenerBodega")]
        public dynamic ObtenerBodega(string usuario, string password)
        {
            using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
            {
                var bodegasList = core.Exactus.ObtenerBodega(usuario, password);
                return new { resultado = "OK", bodegas = bodegasList };
            }
        }

        [HttpGet]
        [Route("api/Exactus/ObtenerClientePorNombre")]
        public dynamic ObtenerClientePorNombre(string usuario, string password, string Nombre)
        {
            using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
            {
                var clienteList = core.Exactus.ObtenerClientePorNombre(usuario, password, Nombre);
                return new { resultado = "OK", clientes = clienteList };
            }
        }

        [HttpGet]
        [Route("api/Exactus/ObtenerClientePorRuc")]
        public dynamic ObtenerClientePorRuc(string usuario, string password, string RucCedula)
        {
            using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
            {
                var clienteList = core.Exactus.ObtenerClientePorRuc(usuario, password, RucCedula);
                return new { resultado = "OK", clientes = clienteList };
            }
        }

        [HttpGet]
        [Route("api/Exactus/ObtenerArticulo")]
        public dynamic ObtenerArticulo(string usuario, string password, string bodega, string articulo, string descripcion, string nivel_precio, string version_precio, string clasificacion1, string clasificacion2, string clasificacion3, string clasificacion4, string clasificacion5, string clasificacion6)
        {
            using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
            {
                var articulosList = core.Exactus.ObtenerArticulo(usuario, password, bodega, articulo, descripcion, nivel_precio, version_precio, clasificacion1, clasificacion2, clasificacion3, clasificacion4, clasificacion5, clasificacion6);
                return new { resultado = "OK", articulos = articulosList };
            }
        }

        [HttpGet]
        [Route("api/Exactus/ObtenerClasificacion")]
        public dynamic ObtenerClasificacion(string usuario, string password, string agrupacion)
        {
            using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
            {
                var agrupList = core.Exactus.ObtenerClasificacion(usuario, password, agrupacion);
                return new { resultado = "OK", agrupacion = agrupList };
            }
        } 

        [HttpPost]
        [HttpGet]
        [Route("api/Exactus/GuardarPedido")]
        public dynamic GuardarPedido(System.Net.Http.Formatting.FormDataCollection jsondata)
        {

            var usuario = jsondata["usuario"];
            var password = jsondata["password"];
            string pedido = "";
            PedidoParametrosViewModel data = (PedidoParametrosViewModel)Newtonsoft.Json.JsonConvert.DeserializeObject(jsondata["jsondata"].ToString(), typeof(PedidoParametrosViewModel), new JsonSerializerSettings());
            using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
            {
                pedido = core.Exactus.GrabarPedido(usuario, password, new PedidoParametrosViewModel
                {
                    USUARIO_LOGIN = data.USUARIO_LOGIN,
                    TARJETA_CREDITO = data.TARJETA_CREDITO,
                    PEDIDO = data.PEDIDO,
                    BODEGA = data.BODEGA,
                    CLIENTE = data.CLIENTE,
                    CODIGO_CONSECUTIVO = data.CODIGO_CONSECUTIVO,
                    CONDICION_PAGO = data.CONDICION_PAGO,
                    NOMBRE_CUENTA = data.NOMBRE_CUENTA,
                    OBSERVACIONES = data.OBSERVACIONES,
                    ORDEN_COMPRA = data.ORDEN_COMPRA
                }, data.PEDIDODETALLE);

            }
            return new { resultado = "ok", pedido = pedido };
        }

    }

}
