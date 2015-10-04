using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP.Exactus.Interfaces
{
    public interface IExactusBusinessObject
    {
        dynamic obtenerUsuario(string usuario, string contraseña);
    }
}
