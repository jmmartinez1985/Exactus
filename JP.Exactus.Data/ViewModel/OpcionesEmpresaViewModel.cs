using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP.Exactus.Data.ViewModel
{
    public class OpcionesEmpresaViewModel
    {
        public int IDOpcionEmpresa { get; set; }
        public int IDEmpresa { get; set; }
        public int IDOpcion { get; set; }
        public bool Activo { get; set; }

        public  EmpresasViewModel Empresa { get; set; }
        public  OpcionesViewModel Opciones { get; set; }
    }
}
