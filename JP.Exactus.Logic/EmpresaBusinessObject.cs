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

        public EmpresasViewModel obtenerDetalleEmpresa(int empresaId)
        {
            var empresa = base.Context.Empresa.FirstOrDefault(c => c.IDEmpresa == empresaId);
            return Mapper.Map<Empresa,EmpresasViewModel > (empresa);
        }
    }
}
