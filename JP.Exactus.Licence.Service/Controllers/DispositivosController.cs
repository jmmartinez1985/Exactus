using JP.Exactus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JP.Exactus.Licence.Service.Controllers
{
    public class DispositivosController : ApiController
    {
        [HttpGet]
        public dynamic ObtenerDispositivo(string mac) {

            using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
            {
                var dispositivo = core.Dispositivos.ObtenerDispositivoPorMAC(mac);
                var empresa = core.Empresas.obtenerEmpresaPorId(dispositivo.IDEmpresa);
                var opciones = core.OpcionesEmpresa.ObtenerOpcionesEmpresa(dispositivo.IDEmpresa).
                    Select(c => new { id = c.IDOpcion ,opcion = c.Opciones.DescripcionOpcion });
                return new
                {
                    dispositivo = dispositivo,
                    empresa = empresa,
                    opciones = opciones,
                    

                };
            }

        }

    }
}
