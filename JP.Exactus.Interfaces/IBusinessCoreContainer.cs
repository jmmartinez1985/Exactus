using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP.Exactus.Interfaces
{
    public interface IBusinessCoreContainer : IDisposable
    {
        IEmpresasBusinessObject Empresas { get; }
        IDispositivoBusinessObject Dispositivos { get; }

        IOpcionesEmpresaBusinessObject OpcionesEmpresa { get; }
    }
}
