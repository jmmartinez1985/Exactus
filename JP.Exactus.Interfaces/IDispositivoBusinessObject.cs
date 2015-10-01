using JP.Exactus.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP.Exactus.Interfaces
{
    public interface IDispositivoBusinessObject
    {
        IEnumerable<DispositivoViewModel> ListarDispositivos();

        DispositivoViewModel ObtenerDispositivoPorId(int id);

        void GuardarDispositivo(DispositivoViewModel model);

        DispositivoViewModel ObtenerDispositivoPorMAC(string mac);
    }
}
