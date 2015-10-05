using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JP.Exactus.Data.ViewModel;

namespace JP.Exactus.Interfaces
{
    public interface IEmpresasBusinessObject
    {
        IEnumerable<EmpresasViewModel> ListarEmpresas();
        
        void GuardarEmpresa(EmpresasViewModel model);

        EmpresasViewModel obtenerEmpresaPorId(int empresaId);
    }
}
