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
    }
}
