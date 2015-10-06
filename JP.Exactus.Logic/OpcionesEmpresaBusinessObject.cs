using JP.Exactus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JP.Exactus.Data.ViewModel;
using JP.Exactus.Data;
using AutoMapper;

namespace JP.Exactus.Logic
{
    public class OpcionesEmpresaBusinessObject : BusinessCoreObject, IOpcionesEmpresaBusinessObject
    {
        

        public IEnumerable<OpcionesEmpresaViewModel> ObtenerOpcionesEmpresa(int idEmpresa)
        {
            var opciones = base.Context.OpcionesEmpresa.Where(c => c.IDEmpresa == idEmpresa).ToList();
            return Mapper.Map<List<OpcionesEmpresa>, List<OpcionesEmpresaViewModel>>(opciones);
        }

        public void GuardarOpcionesEmpresa(OpcionesEmpresaViewModel model)
        {

            var registroExiste = base.Context.OpcionesEmpresa.Find(model.IDOpcionEmpresa);
            if (registroExiste == null)
            {
                var OpcionesEmp = base.Context.OpcionesEmpresa.Create();
                Mapper.Map<OpcionesEmpresaViewModel, OpcionesEmpresa>(model, OpcionesEmp);
                base.Context.OpcionesEmpresa.Add(OpcionesEmp);
            }
            else
            {
                Mapper.Map<OpcionesEmpresaViewModel, OpcionesEmpresa>(model, registroExiste);
                base.Context.Entry(registroExiste).State = System.Data.Entity.EntityState.Modified;

            }
            base.Context.SaveChanges();

        }

        public IEnumerable<OpcionesEmpresaViewModel> ListarOpcionesEmpresa()
        {
            var OpcionesEmpresaList = base.Context.OpcionesEmpresa.Include("Empresa").Include("Opciones").ToList();
            return Mapper.Map<List<OpcionesEmpresa>, List<OpcionesEmpresaViewModel>>(OpcionesEmpresaList);
        }

        public OpcionesEmpresaViewModel ObtenerOpcionEmpresaPorId(int OpcionId)
        {
            var opcion = base.Context.OpcionesEmpresa.FirstOrDefault(c => c.IDOpcion == OpcionId);
            return Mapper.Map<OpcionesEmpresa, OpcionesEmpresaViewModel>(opcion);
        }
    }
}
