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
    public class EmpresaBusinessObject : BusinessCoreObject, IEmpresasBusinessObject
    {

        public EmpresasViewModel obtenerEmpresaPorId(int empresaId)
        {
            var empresaList = base.Context.Empresa.FirstOrDefault(c => c.IDEmpresa == empresaId);
            return Mapper.Map<Empresa,EmpresasViewModel > (empresaList);
        }

        public void GuardarEmpresa(EmpresasViewModel model)
        {

            var registroExiste = base.Context.Empresa.Find(model.IDEmpresa);
            if (registroExiste == null)
            {
                var empresa = base.Context.Empresa.Create();
                Mapper.Map<EmpresasViewModel, Empresa>(model, empresa);
                base.Context.Empresa.Add(empresa);
            }
            else
            {
                Mapper.Map<EmpresasViewModel, Empresa>(model, registroExiste);
                base.Context.Entry(registroExiste).State = System.Data.Entity.EntityState.Modified;

            }
            base.Context.SaveChanges();

        }

        public IEnumerable<EmpresasViewModel> ListarEmpresas()
        {
            var empresasList = base.Context.Empresa.ToList();
            return Mapper.Map<List<Empresa>, List<EmpresasViewModel>>(empresasList);
        }
        
    }
}
