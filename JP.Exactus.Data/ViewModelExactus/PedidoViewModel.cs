using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP.Exactus.Data.ViewModelExactus
{
   public class PedidoViewModel
    {
        public String PEDIDO { get; set; }
        public String ESTADO { get; set; }
        public DateTime FECHA_PEDIDO { get; set; }
        public DateTime FECHA_PROMETIDA { get; set; }
        public DateTime FECHA_PROX_EMBARQU { get; set; }
        public DateTime FECHA_ULT_EMBARQUE { get; set; }
        public DateTime FECHA_ULT_CANCELAC { get; set; }
        public String ORDEN_COMPRA { get; set; }
        public DateTime FECHA_ORDEN { get; set; }
        public String TARJETA_CREDITO { get; set; }
        public String EMBARCAR_A { get; set; }
        public String DIREC_EMBARQUE { get; set; }
        public String RUBRO1 { get; set; }
        public String RUBRO2 { get; set; }
        public String RUBRO3 { get; set; }
        public String RUBRO4 { get; set; }
        public String RUBRO5 { get; set; }
        public String OBSERVACIONES { get; set; }
        public String COMENTARIO_CXC { get; set; }
        public Decimal TOTAL_MERCADERIA { get; set; }
        public Decimal MONTO_ANTICIPO { get; set; }
        public Decimal MONTO_FLETE { get; set; }
        public Decimal MONTO_SEGURO { get; set; }
        public Decimal MONTO_DOCUMENTACIO { get; set; }
        public String TIPO_DESCUENTO1 { get; set; }
        public String TIPO_DESCUENTO2 { get; set; }
        public Decimal MONTO_DESCUENTO1 { get; set; }
        public Decimal MONTO_DESCUENTO2 { get; set; }
        public Decimal PORC_DESCUENTO1 { get; set; }
        public Decimal PORC_DESCUENTO2 { get; set; }
        public Decimal TOTAL_IMPUESTO1 { get; set; }
        public Decimal TOTAL_IMPUESTO2 { get; set; }
        public Decimal TOTAL_A_FACTURAR { get; set; }
        public Decimal PORC_COMI_VENDEDOR { get; set; }
        public Decimal PORC_COMI_COBRADOR { get; set; }
        public Decimal TOTAL_CANCELADO { get; set; }
        public Decimal TOTAL_UNIDADES { get; set; }
        public String IMPRESO { get; set; }
        public DateTime FECHA_HORA { get; set; }
        public Decimal DESCUENTO_VOLUMEN { get; set; }
        public String TIPO_PEDIDO { get; set; }
        public String MONEDA_PEDIDO { get; set; }
        public String VERSION_NP { get; set; }
        public String AUTORIZADO { get; set; }
        public String DOC_A_GENERAR { get; set; }
        public String CLASE_PEDIDO { get; set; }
        public String MONEDA { get; set; }
        public String NIVEL_PRECIO { get; set; }
        public String COBRADOR { get; set; }
        public String RUTA { get; set; }
        public String USUARIO { get; set; }
        public Int32  CONDICION_PAGO { get; set; }
        public String BODEGA { get; set; }
        public String ZONA { get; set; }
        public String VENDEDOR { get; set; }
        public String CLIENTE { get; set; }
        public String CLIENTE_DIRECCION { get; set; }
        public String CLIENTE_CORPORAC { get; set; }
        public String CLIENTE_ORIGEN { get; set; }
        public String PAIS { get; set; }
        public Int32 SUBTIPO_DOC_CXC { get; set; }
        public String TIPO_DOC_CXC { get; set; }
        public String BACKORDER { get; set; }
        public String CONTRATO { get; set; }
        public Decimal PORC_INTCTE { get; set; }
        public String DESCUENTO_CASCADA { get; set; }
        public Int32 NoteExistsFlag { get; set; }
        public DateTime RecordDate { get; set; }
        public String CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public String DIRECCION_FACTURA { get; set; }
        public Decimal TIPO_CAMBIO { get; set; }
        public String FIJAR_TIPO_CAMBIO { get; set; }
        public String ORIGEN_PEDIDO { get; set; }
        public String NOMBRE_CLIENTE { get; set; }
     
    }
}
