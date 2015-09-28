using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP.Exactus.Data.ViewModel
{
    public class EmpresasViewModel
    {
        public int Emp_Id { get; set; }
        public string Emp_Nombre { get; set; }
        public Nullable<System.DateTime> Emp_Ingreso { get; set; }
    }
}
