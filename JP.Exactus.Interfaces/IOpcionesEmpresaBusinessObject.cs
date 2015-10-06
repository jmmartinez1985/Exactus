using JP.Exactus.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP.Exactus.Interfaces
{
    public interface IOpcionesEmpresaBusinessObject
    {

        OpcionesEmpresaViewModel ObtenerOpcionEmpresaPorId(int OpcionId);
        
        IEnumerable<OpcionesEmpresaViewModel> ObtenerOpcionesEmpresa(int idEmpresa);

        IEnumerable<OpcionesEmpresaViewModel> ListarOpcionesEmpresa();

        void GuardarOpcionesEmpresa(OpcionesEmpresaViewModel model);
        

    }
}
