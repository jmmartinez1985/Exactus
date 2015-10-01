using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP.Exactus.Data.ViewModel
{
    public class AuditoriaViewModel
    {
        public int IDAuditoria { get; set; }
        public int IDDispositivo { get; set; }
        public string DescripcionAccion { get; set; }
        public System.DateTime Fecha { get; set; }

        public virtual Dispositivo Dispositivo { get; set; }
    }
}
