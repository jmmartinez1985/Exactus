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
        public dynamic obtenerUsuario(string usuario, string password)
        {
            using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
            {
                core.Exactus.obtenerUsuario(usuario, password);
            }
            return new { resultado = "OK" };
        }

    }
}
