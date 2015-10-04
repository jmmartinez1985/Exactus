using JP.Exactus.Data.ViewModelExactus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP.Exactus.Interfaces
{
    public interface IExactusBusinessObject
    {
        bool ValidaUsuario(string usuario, string contraseña);
        List<BodegaViewModel> ObtenerBodega(string usuario, string contraseña);
    }
}
