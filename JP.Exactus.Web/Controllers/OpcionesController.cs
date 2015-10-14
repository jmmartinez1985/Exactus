using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JP.Exactus.Data.ViewModel;
using JP.Exactus.Interfaces;

namespace JP.Exactus.Web.Controllers
{
    public class OpcionesController : Controller
    {
        // GET: Opciones
        public ActionResult Index()
        {
            using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
            {
                var obje = core.Opciones.ListarOpciones();
                return View(obje);
            }
        }

        // GET: Opciones/Details/5
        public ActionResult Details(int id)
        {
            using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
            {
                var obje = core.Opciones.obtenerOpcionPorId(id);
                return View(obje);
            }
        }

        // GET: Opciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Opciones/Create
        [HttpPost]
        public ActionResult Create(OpcionesViewModel model)
        {
            model.Activo = true;
            try
            {
                using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
                {
                    core.Opciones.GuardarOpciones(model);
                    return RedirectToAction("Index");
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Opciones/Edit/5
        public ActionResult Edit(int id)
        {
            using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
            {
                var obje = core.Opciones.obtenerOpcionPorId(id);
                return View(obje);
            }
        }

        // POST: Opciones/Edit/5
        [HttpPost]
        public ActionResult Edit(OpcionesViewModel model)
        {
            try
            {
                using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
                {
                    core.Opciones.GuardarOpciones(model);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Opciones/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Opciones/Delete/5
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
