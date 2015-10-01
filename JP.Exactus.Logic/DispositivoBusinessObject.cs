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
    public class DispositivoBusinessObject : BusinessCoreObject, IDispositivoBusinessObject
    {
        public IEnumerable<DispositivoViewModel> ListarDispositivos()
        {
            var dispositivosList = base.Context.Dispositivo.ToList();
            return Mapper.Map<List<Dispositivo>, List<DispositivoViewModel>>(dispositivosList);
        }
    }
}
