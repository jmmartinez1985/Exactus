using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP.Exactus.Data.ViewModelExactus
{
    public class PedidoLineaParametrosViewModel
    {
public String PEDIDO { get; set; }
public String ARTICULO { get; set; }
public String CREADOR_POR { get; set; }
public Decimal PRECIO_UNITARIO { get; set; }
public Decimal CANTIDAD { get; set; }
public Decimal DESCUENTO { get; set; }
public Int32 Linea { get; set; }
    }
}
