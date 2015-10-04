using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JP.Exactus.Data.ViewModel;

namespace JP.Exactus.Interfaces
{
    public interface IOpcionesBusinessObject
    {
        IEnumerable<OpcionesViewModel> ListarOpciones();

        void GuardarOpciones(OpcionesViewModel model);

        OpcionesViewModel obtenerOpcionPorId(int opcionId);

    }
}
