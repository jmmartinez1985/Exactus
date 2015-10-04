using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JP.Exactus.Data.ViewModel;
using JP.Exactus.Interfaces;

namespace JP.Exactus.Web.Controllers
{
    public class EmpresasController : Controller
    {
        // GET: Empresas
        public ActionResult Index()
        {
            using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
            {
                var obje = core.Empresas.ListarEmpresas();
                return View(obje);
            }
        }

        // GET: Empresas/Details/5
        public ActionResult Details(int id)
        {
            using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
            {
                var obje = core.Empresas.obtenerEmpresaPorId(id);
                return View(obje);
            }
        }

        // GET: Empresas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresas/Create
        [HttpPost]
        public ActionResult Create(EmpresasViewModel model)
        {
            try
            {
                using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
                {
                    core.Empresas.GuardarEmpresa(model);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Empresas/Edit/5
        public ActionResult Edit(int id)
        {
            using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
            {
                var obje = core.Empresas.obtenerEmpresaPorId(id);
                return View(obje);
            }
        }

        // POST: Empresas/Edit/5
        [HttpPost]
        public ActionResult Edit(EmpresasViewModel model)
        {
            try
            {
                using (IBusinessCoreContainer core = IoCContainer.Get<IBusinessCoreContainer>())
                {
                    core.Empresas.GuardarEmpresa(model);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex )
            {
                return View();
            }
        }

        // GET: Empresas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Empresas/Delete/5
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
