using JP.Exactus.Data.ViewModel;
using JP.Exactus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JP.Exactus.Web.Controllers
{
    public class DispositivosController : Controller
    {
        // GET: Dispositivos
        public ActionResult Index()
        {
            using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
            {
                var obje = core.Dispositivos.ListarDispositivos();
                return View(obje);
            }
        }

        // GET: Dispositivos/Details/5
        public ActionResult Details(int id)
        {

            ///ViewBag.Empresas = 

            return View();
        }

        // GET: Dispositivos/Create
        public ActionResult Create()
        {
            using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
            {
                var dispositivo = core.Dispositivos.ObtenerDispositivoPorId(1);
                return View(dispositivo);
            }
        }

        // POST: Dispositivos/Create
        [HttpPost]
        public ActionResult Create(DispositivoViewModel model)
        {
            try
            {
                // TODO: Add insert logic here

                using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
                {
                    core.Dispositivos.GuardarDispositivo(model);

                    return RedirectToAction("Index");
                }

                
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Dispositivos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dispositivos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dispositivos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dispositivos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
