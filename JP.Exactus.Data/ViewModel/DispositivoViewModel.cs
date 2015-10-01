using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP.Exactus.Data.ViewModel
{
    public class DispositivoViewModel
    {
        public int IDDispositivo { get; set; }
        public int IDEmpresa { get; set; }
        public string NombreDispositivo { get; set; }
        public string MACDispositivo { get; set; }
        public System.DateTime FechaExpira { get; set; }
        public bool Activo { get; set; }
        public int UsuarioModifica { get; set; }
        public System.DateTime FechaModifica { get; set; }

        public IEnumerable<AuditoriaViewModel> Auditoria { get; set; }
        public  EmpresasViewModel Empresa { get; set; }
    }
}
