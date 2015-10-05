using JP.Exactus.Interfaces;
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
        [Route("api/Exactus/ObtenerBodega")]
        public dynamic ObtenerBodega(string usuario, string password)
        {
            using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
            {
               var bodegasList =core.Exactus.ObtenerBodega(usuario,password);
               return new { resultado = "OK", bodegas = bodegasList };
            }
        }


    }
}
