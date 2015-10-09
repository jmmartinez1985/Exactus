using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP.Exactus.Data.ViewModelExactus
{
    public class ClienteViewModel
    {
       public String  CLIENTE { get; set; }
        public String NOMBRE { get; set; }
        public String CONTRIBUYENTE { get; set; }
        public String ALIAS { get; set; }
        public Decimal SALDO { get; set; }
        public Decimal LIMITE_CREDITO { get; set; }
        public String CATEGORIA_CLIENTE { get; set; }
        public String NIVEL_PRECIO { get; set; }
        public String CONDICION_PAGO { get; set; }
        public Int32 VERSION_PRECIO { get; set; }
        public String EXENTO_IMPUESTOS { get; set; } /*Si es Exento Valor es S de lo contrario N*/
    }
}
