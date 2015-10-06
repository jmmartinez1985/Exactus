using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP.Exactus.Data.ViewModelExactus
{
    public class ArticuloViewModel
    {
        public String ARTICULO { get; set; }
        public String DESCRIPCION { get; set; }
        public String CODIGO_BARRA { get; set; }
        public Decimal DISPONIBLE { get; set; }
        public Decimal PRECIO { get; set; }
        public String IMPUESTO { get; set; } /*Este impuesto es solamente para cada articulo*/
    }
}
