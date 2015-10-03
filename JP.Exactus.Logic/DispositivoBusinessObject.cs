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
        public async void GuardarDispositivo(DispositivoViewModel model)
        {

            var registroExiste = base.Context.Dispositivo.Find(model.IDDispositivo);
            if (registroExiste == null)
            {
                var dispositivo = base.Context.Dispositivo.Create();
                Mapper.Map<DispositivoViewModel, Dispositivo>(model, dispositivo);
                base.Context.Dispositivo.Add(dispositivo);
            }
            else
            {
                Mapper.Map<DispositivoViewModel, Dispositivo>(model, registroExiste);
                base.Context.Entry(registroExiste).State = System.Data.Entity.EntityState.Modified;

            }
            await base.Context.SaveChangesAsync();

        }

        public IEnumerable<DispositivoViewModel> ListarDispositivos()
        {
            var dispositivosList = base.Context.Dispositivo.ToList();
            return Mapper.Map<List<Dispositivo>, List<DispositivoViewModel>>(dispositivosList);
        }

        public DispositivoViewModel ObtenerDispositivoPorId(int id)
        {
            var dispositivo = base.Context.Dispositivo.FirstOrDefault(c => c.IDDispositivo == id);
            return Mapper.Map<Dispositivo, DispositivoViewModel>(dispositivo);
        }

        public DispositivoViewModel ObtenerDispositivoPorMAC(string mac)
        {
            var dispositivo = base.Context.Dispositivo.FirstOrDefault(c => c.MACDispositivo == mac);
            if (dispositivo == null)
            {
                throw new Exception("El dispositivo no esta registrado o no esta vinculado a una empresa.");
            }
            return Mapper.Map<Dispositivo, DispositivoViewModel>(dispositivo);
        }
    }
}
