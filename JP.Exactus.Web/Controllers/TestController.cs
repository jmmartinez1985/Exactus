using JP.Exactus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JP.Exactus.Web.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {

            using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
            {
                var obje = core.Empresas.obtenerDetalleEmpresa(1);
                return View(obje);
            }

            

            
            

        }
    }
}