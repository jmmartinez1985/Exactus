using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP.Exactus.Data.ViewModelExactus
{
    public class PedidoParametrosViewModel
    {
        public String CLIENTE { get; set; }
        public String BODEGA { get; set; }
        public String ORDEN_COMPRA { get; set; }
        public String OBSERVACIONES { get; set; }
        public String USUARIO_LOGIN { get; set; }
        public String TARJETA_CREDITO { get; set; }
        public String NOMBRE_CUENTA { get; set; }
        public String PEDIDO { get; set; }
        public Int32 CONDICION_PAGO { get; set; }
        public String CODIGO_CONSECUTIVO { get; set; }

        public List<PedidoLineaParametrosViewModel> PEDIDODETALLE { get; set; }

    }
}
