using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JP.Exactus.Data.ViewModel;
using JP.Exactus.Interfaces;

namespace JP.Exactus.Web.Controllers
{
    public class OpcionesEmpresaController : Controller
    {
        // GET: OpcionesEmpresa
        public ActionResult Index()
        {
            using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
            {
                var obje = core.OpcionesEmpresa.ListarOpcionesEmpresa();
                return View(obje);
            }
        }

        // GET: OpcionesEmpresa/Details/5
        public ActionResult Details(int id)
        {
            using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
            {
                var obje = core.OpcionesEmpresa.ObtenerOpcionesEmpresa(id);
                return View(obje);
            }
        }

        // GET: OpcionesEmpresa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OpcionesEmpresa/Create
        [HttpPost]
        public ActionResult Create(OpcionesEmpresaViewModel model)
        {
            try
            {
                using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
                {
                    core.OpcionesEmpresa.GuardarOpcionesEmpresa(model);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: OpcionesEmpresa/Edit/5
        public ActionResult Edit(int id)
        {
            using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
            {
                var obje = core.OpcionesEmpresa.ObtenerOpcionEmpresaPorId(id);
                return View(obje);
            }
        }

        // POST: OpcionesEmpresa/Edit/5
        [HttpPost]
        public ActionResult Edit(OpcionesEmpresaViewModel model)
        {
            try
            {
                using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
                {
                    core.OpcionesEmpresa.GuardarOpcionesEmpresa(model);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: OpcionesEmpresa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OpcionesEmpresa/Delete/5
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
