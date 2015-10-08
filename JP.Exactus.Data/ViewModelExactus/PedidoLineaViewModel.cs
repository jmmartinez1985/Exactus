using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP.Exactus.Data.ViewModelExactus
{
    public class PedidoLineaViewModel
    {
        public String PEDIDO { get; set; }
        public Int32 PEDIDO_LINEA { get; set; }
        public String BODEGA { get; set; }
        public String LOTE { get; set; }
        public String LOCALIZACION { get; set; }
        public String ARTICULO { get; set; }
        public String ESTADO { get; set; }
        public DateTime FECHA_ENTREGA { get; set; }
        public Int32 LINEA_USUARIO { get; set; }
        public Decimal PRECIO_UNITARIO { get; set; }
        public Decimal CANTIDAD_PEDIDA { get; set; }
        public Decimal CANTIDAD_A_FACTURA { get; set; }
        public Decimal CANTIDAD_FACTURADA { get; set; }
        public Decimal CANTIDAD_RESERVADA { get; set; }
        public Decimal CANTIDAD_BONIFICAD { get; set; }
        public Decimal CANTIDAD_CANCELADA { get; set; }
        public String TIPO_DESCUENTO { get; set; }
        public Decimal MONTO_DESCUENTO { get; set; }
        public Decimal PORC_DESCUENTO { get; set; }
        public String DESCRIPCION { get; set; }
        public String COMENTARIO { get; set; }
        public Int32 PEDIDO_LINEA_BONIF { get; set; }
        public String UNIDAD_DISTRIBUCIO { get; set; }
        public DateTime FECHA_PROMETIDA { get; set; }
        public Int32 LINEA_ORDEN_COMPRA { get; set; }
        public DateTime RecordDate { get; set; } 
        public String CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
