using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JP.Exactus.Interfaces;
using JP.Exactus.Data.ViewModel;
using JP.Exactus.Data;
using AutoMapper;

namespace JP.Exactus.Logic
{
    public class OpcionesBusinessObject : BusinessCoreObject, IOpcionesBusinessObject
    {

        public OpcionesViewModel obtenerOpcionPorId(int OpcionId)
        {
            var OpcionesList = base.Context.Opciones.FirstOrDefault(c => c.IDOpcion == OpcionId);
            return Mapper.Map<Opciones, OpcionesViewModel>(OpcionesList);
        }

        public void GuardarOpciones(OpcionesViewModel model)
        {

            var registroExiste = base.Context.Opciones.Find(model.IDOpcion);
            if (registroExiste == null)
            {
                var Opciones = base.Context.Opciones.Create();
                Mapper.Map<OpcionesViewModel, Opciones>(model, Opciones);
                base.Context.Opciones.Add(Opciones);
            }
            else
            {
                Mapper.Map<OpcionesViewModel, Opciones>(model, registroExiste);
                base.Context.Entry(registroExiste).State = System.Data.Entity.EntityState.Modified;

            }
            base.Context.SaveChanges();

        }

        public IEnumerable<OpcionesViewModel> ListarOpciones()
        {
            var OpcionesList = base.Context.Opciones.ToList();
            return Mapper.Map<List<Opciones>, List<OpcionesViewModel>>(OpcionesList);
        }

    }
}
