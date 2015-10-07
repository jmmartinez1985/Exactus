using JP.Exactus.Data.Helpers;
using JP.Exactus.Data.ViewModelExactus;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP.Exactus.Data
{
    public class ExactusData
    {
        private string user;
        private string password;
        private string schema;
        private Database db;
        private DatabaseProviderFactory factory;

        public ExactusData()
        {
            //Crea proveedor para la conexion

            
            factory = new DatabaseProviderFactory();
            //Crea el objeto conexion con Enterprise Library
            db = factory.Create("ExactusConnection");

        }

        public ExactusData(string User, string Pass, String Schema)
        {
            this.user = User;
            this.password = Pass;
            this.schema = Schema;
            //Crea proveedor para la conexion
            factory = new DatabaseProviderFactory();
            //Crea el objeto conexion con Enterprise Library
            db = new GenericDatabase(getConnectionString(User,Pass),DbProviderFactories.GetFactory("System.Data.SqlClient"));
            
        }

        public bool ValidaUsuario() {

            DbConnection connection = db.CreateConnection();
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                return false;

            }
            connection.Close();
            return true;

        }

        public List<BodegaViewModel> ObtenerBodega() /*Muestra todas las Bodegas que tiene permiso el usuario para seleccionar en el sistema de pedidos*/
        {
           

            SqlDataReader reader;
            //Se obtiene el reader de Enterprise Library y se convierte a SqlDataReader para poder pasarlo al dynamicReader
            reader = ((RefCountingDataReader)db.ExecuteReader(System.Data.CommandType.Text, $"SELECT A.BODEGA,B.NOMBRE FROM {this.schema}.USUARIO_BODEGA A, {this.schema}.BODEGA B WHERE A.BODEGA = B.BODEGA AND A.USUARIO= '{this.user}' ORDER BY A.BODEGA ASC")).InnerReader as SqlDataReader;
            //Se transforma al dynamic reader para acceder por nombre y evitar los casting entre tipo y los GET...
            dynamic dynreader = (DynamicDataReader)reader;
            var bodegaList = new List<BodegaViewModel>();
            //Se le el reader
            while (dynreader.Read())
            {
                //Se crea objeto bodega para pasarlo a la Lista
                BodegaViewModel model = new BodegaViewModel()
                {
                    Bodega = dynreader.BODEGA,
                    Nombre = dynreader.NOMBRE
                    
                };
                bodegaList.Add(model);
            }
            dynreader.Close();
            reader.Close();
            return bodegaList;
        }

        /*Busca todos los cliente que tengan el nombre parecido a la variable Nombre*/
        public List<ClienteViewModel> ObtenerClientePorNombre(string Nombre)
        {

            SqlDataReader reader;
            //Se obtiene el reader de Enterprise Library y se convierte a SqlDataReader para poder pasarlo al dynamicReader
            reader = ((RefCountingDataReader)db.ExecuteReader(System.Data.CommandType.Text, $"SELECT A.CLIENTE,A.NOMBRE,A.CONTRIBUYENTE, A.ALIAS, A.SALDO, A.LIMITE_CREDITO, B.DESCRIPCION CATEGORIA_CLIENTE, A.NIVEL_PRECIO,A.CONDICION_PAGO, (SELECT MAX(VERSION) VERSION FROM {this.schema}.VERSION_NIVEL WHERE NIVEL_PRECIO = A.NIVEL_PRECIO) VERSION_PRECIO, A.EXENTO_IMPUESTOS FROM {this.schema}.CLIENTE A, {this.schema}.CATEGORIA_CLIENTE B WHERE  NOMBRE LIKE '% {Nombre} %' AND A.CATEGORIA_CLIENTE = B.CATEGORIA_CLIENTE AND ACTIVO = 'S' ORDER BY A.NOMBRE")).InnerReader as SqlDataReader;
            //Se transforma al dynamic reader para acceder por nombre y evitar los casting entre tipo y los GET...
            dynamic dynreader = (DynamicDataReader)reader;
            var clienteList = new List<ClienteViewModel>();
            //Se le el reader
            while (dynreader.Read())
            {
                //Se crea objeto bodega para pasarlo a la Lista
                ClienteViewModel model = new ClienteViewModel()
                {
                    CLIENTE = dynreader.CLIENTE,
                    NOMBRE = dynreader.NOMBRE,
                    CONTRIBUYENTE = dynreader.CONTRIBUYENTE,
                    ALIAS = dynreader.ALIAS,
                    SALDO = dynreader.SALDO,
                    LIMITE_CREDITO = dynreader.LIMITE_CREDITO,
                    CATEGORIA_CLIENTE = dynreader.CATEGORIA_CLIENTE,
                    NIVEL_PRECIO = dynreader.NIVEL_PRECIO,
                    CONDICION_PAGO = dynreader.CONDICION_PAGO,
                    VERSION_PRECIO = dynreader.VERSION_PRECIO,
                    EXENTO_IMPUESTOS = dynreader.EXENTO_IMPUESTOS
                };
                clienteList.Add(model);
            }
            dynreader.Close();
            reader.Close();
            return clienteList;
        }

        /*Busca todos los cliente que tengan el Ruc o Cédula parecido a la variable RucCedula*/
        public List<ClienteViewModel> ObtenerClientePorRuc(string RucCedula)
        {

            SqlDataReader reader;
            //Se obtiene el reader de Enterprise Library y se convierte a SqlDataReader para poder pasarlo al dynamicReader
            reader = ((RefCountingDataReader)db.ExecuteReader(System.Data.CommandType.Text, $"SELECT A.CLIENTE,A.NOMBRE,A.CONTRIBUYENTE, A.ALIAS, A.SALDO, A.LIMITE_CREDITO, B.DESCRIPCION CATEGORIA_CLIENTE, A.NIVEL_PRECIO,A.CONDICION_PAGO,(SELECT MAX(VERSION) VERSION FROM {this.schema}.VERSION_NIVEL WHERE NIVEL_PRECIO = A.NIVEL_PRECIO) VERSION_PRECIO, A.EXENTO_IMPUESTOS FROM {this.schema}.CLIENTE A, {this.schema}.CATEGORIA_CLIENTE B WHERE  NOMBRE LIKE '% {RucCedula} %' AND A.CATEGORIA_CLIENTE = B.CATEGORIA_CLIENTE AND ACTIVO = 'S' ORDER BY A.NOMBRE")).InnerReader as SqlDataReader;
            //Se transforma al dynamic reader para acceder por nombre y evitar los casting entre tipo y los GET...
            dynamic dynreader = (DynamicDataReader)reader;
            var clienteList = new List<ClienteViewModel>();
            //Se le el reader
            while (dynreader.Read())
            {
                //Se crea objeto bodega para pasarlo a la Lista
                ClienteViewModel model = new ClienteViewModel()
                {
                    CLIENTE = dynreader.CLIENTE,
                    NOMBRE = dynreader.NOMBRE,
                    CONTRIBUYENTE = dynreader.CONTRIBUYENTE,
                    ALIAS = dynreader.ALIAS,
                    SALDO = dynreader.SALDO,
                    LIMITE_CREDITO = dynreader.LIMITE_CREDITO,
                    CATEGORIA_CLIENTE = dynreader.CATEGORIA_CLIENTE,
                    NIVEL_PRECIO = dynreader.NIVEL_PRECIO,
                    CONDICION_PAGO = dynreader.CONDICION_PAGO,
                    VERSION_PRECIO = dynreader.VERSION_PRECIO,
                    EXENTO_IMPUESTOS = dynreader.EXENTO_IMPUESTOS
                };
                clienteList.Add(model);
            }
            dynreader.Close();
            reader.Close();
            return clienteList;
        }


        /*Busca todos articulos por diferentes formas articulo, descripcion, clasificiacion1,clasificiacion2,clasificiacion3,clasificiacion4,clasificiacion5,clasificiacion6*/
        /*importante BODEGA NO SE MANDA NULL NI VACIO, EN LA BUSQUEDA ES ARTICULO = NULL O DESCRIPCION = NULL PERO UNO DE LOS DOS DEBE TENER VALOR */
        /*importante nivel_precio se saca el cliente */
        /*importante clasificaciones en la clase clasificacion, la agrupacion es por ejemplo 1 y en la busqueda es clasificacion_1 */
        public List<ArticuloViewModel> ObtenerArticulo(string bodega, string articulo, string descripcion, string nivel_precio, string version_precio, string clasificacion1, string clasificacion2, string clasificacion3, string clasificacion4, string clasificacion5, string clasificacion6)
        {
            string sqlcomando = "";
            sqlcomando = $" SELECT AR.ARTICULO , AR.DESCRIPCION ,AR.CODIGO_BARRAS_INVT CODIGO_BARRA,EB.CANT_DISPONIBLE Disponible, coalesce((SELECT PRECIO FROM {this.schema}.ARTICULO_PRECIO WHERE VERSION = '{version_precio}' AND NIVEL_PRECIO = '{nivel_precio}'  AND ARTICULO = AR.ARTICULO),0.00) PRECIO, AR.IMPUESTO ";
            sqlcomando = sqlcomando + $" FROM {this.schema}.ARTICULO AR, {this.schema}.EXISTENCIA_BODEGA EB ";
            sqlcomando = sqlcomando + " WHERE AR.ARTICULO = EB.ARTICULO AND AR.ACTIVO = 'S' ";
            sqlcomando = sqlcomando + $" AND BODEGA = '{bodega}'";
            if (articulo == null)
            {
                sqlcomando = sqlcomando + $" AND AR.DESCRIPCION LIKE '%{descripcion}%'";
            }
            else
            {
                sqlcomando = sqlcomando + $" AND AR.ARTICULO LIKE '%{articulo}%'";
            }

            if (clasificacion1 != null) 
            {
                sqlcomando = sqlcomando + $" AND AR.CLASIFICACION_1 = '{clasificacion1}' ";
            }
            if (clasificacion2 != null)
            {
                sqlcomando = sqlcomando + $" AND AR.CLASIFICACION_2 = '{clasificacion2}' ";
            }
            if (clasificacion3 != null)
            {
                sqlcomando = sqlcomando + $" AND AR.CLASIFICACION_3 = '{clasificacion3}' ";
            }
            if (clasificacion4 != null)
            {
                sqlcomando = sqlcomando + $" AND AR.CLASIFICACION_4 = '{clasificacion4}' ";
            }
            if (clasificacion5 != null)
            {
                sqlcomando = sqlcomando + $" AND AR.CLASIFICACION_5 = '{clasificacion5}' ";
            }
            if (clasificacion6 != null)
            {
                sqlcomando = sqlcomando + $" AND AR.CLASIFICACION_6 = '{clasificacion6}' ";
            }
            sqlcomando = sqlcomando + " ORDER BY AR.ARTICULO desc ";

            SqlDataReader reader;
            //Se obtiene el reader de Enterprise Library y se convierte a SqlDataReader para poder pasarlo al dynamicReader
            reader = ((RefCountingDataReader)db.ExecuteReader(System.Data.CommandType.Text, sqlcomando)).InnerReader as SqlDataReader;
            //Se transforma al dynamic reader para acceder por nombre y evitar los casting entre tipo y los GET...
            dynamic dynreader = (DynamicDataReader)reader;
            var ArticuloList = new List<ArticuloViewModel>();
            //Se le el reader
            while (dynreader.Read())
            {
                //Se crea objeto bodega para pasarlo a la Lista
                ArticuloViewModel model = new ArticuloViewModel()
                {

                    ARTICULO = dynreader.ARTICULO,
                    DESCRIPCION = dynreader.DESCRIPCION,
                    CODIGO_BARRA = dynreader.CODIGO_BARRA,
                    DISPONIBLE = dynreader.Disponible,
                    PRECIO = dynreader.PRECIO,
                    IMPUESTO = dynreader.IMPUESTO

                };
                ArticuloList.Add(model);
            }
            dynreader.Close();
            reader.Close();
            return ArticuloList;

        }

        /*CLASIFICACION ES EL VALOR Y DESCRIPCION QUE ES, EN LA BUSQUEDA DE ARTICULO SE INTERPRETA CLASIFACION_(AGRUPACION)*/
        public List<ClasificacionViewModel> ObtenerClasificacion(string agrupacion)
        {

            SqlDataReader reader;
            //Se obtiene el reader de Enterprise Library y se convierte a SqlDataReader para poder pasarlo al dynamicReader
            reader = ((RefCountingDataReader)db.ExecuteReader(System.Data.CommandType.Text, $"SELECT CLASIFICACION, DESCRIPCION FROM {this.schema}.CLASIFICACION WHERE AGRUPACION = {agrupacion}")).InnerReader as SqlDataReader;
            //Se transforma al dynamic reader para acceder por nombre y evitar los casting entre tipo y los GET...
            dynamic dynreader = (DynamicDataReader)reader;
            var ClasificacionList = new List<ClasificacionViewModel>();
            //Se le el reader
            while (dynreader.Read())
            {
                //Se crea objeto bodega para pasarlo a la Lista
                ClasificacionViewModel model = new ClasificacionViewModel()
                {
                    CLASIFICACION = dynreader.CLASIFICACION,
                    DESCRIPCION = dynreader.DESCRIPCION
                };
                ClasificacionList.Add(model);
            }
            dynreader.Close();
            reader.Close();
            return ClasificacionList;
        }
        /*Consecutivo es el Esquema Maestro para Facturas, Pedidos, Devoluciones, Etc */
        public List<ConsecutivosViewModel> BuscarConsecutivo( string usuario)
        {


            SqlDataReader reader;
            //Se obtiene el reader de Enterprise Library y se convierte a SqlDataReader para poder pasarlo al dynamicReader
            reader = ((RefCountingDataReader)db.ExecuteReader(System.Data.CommandType.Text, $"SELECT  B.CODIGO_CONSECUTIVO, B.DESCRIPCION FROM {schema}.CONSECUFA_USUARIO A, {schema}.CONSECUTIVO_FA B WHERE A.CODIGO_CONSECUTIVO = B.CODIGO_CONSECUTIVO AND USUARIO = '{usuario}' ORDER BY B.CODIGO_CONSECUTIVO")).InnerReader as SqlDataReader;
            //Se transforma al dynamic reader para acceder por nombre y evitar los casting entre tipo y los GET...
            dynamic dynreader = (DynamicDataReader)reader;
            var ConsecutivoList = new List<ConsecutivosViewModel>();
            //Se le el reader
            while (dynreader.Read())
            {
                //Se crea objeto bodega para pasarlo a la Lista
                ConsecutivosViewModel model = new ConsecutivosViewModel()
                {
                    CODIGO_CONSECUTIVO = dynreader.CODIGO_CONSECUTIVO,
                    DESCRIPCION = dynreader.DESCRIPCION
                };
                ConsecutivoList.Add(model);
            }
            dynreader.Close();
            reader.Close();
            return ConsecutivoList;

        }


        public string GrabarPedido(PedidoParametrosViewModel PedidoParametros, List<PedidoLineaParametrosViewModel> PedidoLineaParametros)
        {
            string sqlcomando = "";
            string Nropedido = ""; 
            sqlcomando = sqlcomando + $" DECLARE @CLIENTE VARCHAR(100); DECLARE @BODEGA  VARCHAR(100); DECLARE @ORDEN_COMPRA VARCHAR(100); DECLARE @OBSERVACIONES VARCHAR(300); ";
            sqlcomando = sqlcomando + $" DECLARE @USUARIO_LOGIN VARCHAR(100); DECLARE @TARJETA_CREDITO VARCHAR(100); DECLARE @NOMBRE_CUENTA VARCHAR(100); ";
            sqlcomando = sqlcomando + $" DECLARE @CONDICION_PAGO INTEGER; DECLARE @PEDIDO VARCHAR(100); ";
            sqlcomando = sqlcomando + $" SET @BODEGA = '{PedidoParametros.BODEGA}';";
            sqlcomando = sqlcomando + $" SET @ORDEN_COMPRA = '{PedidoParametros.ORDEN_COMPRA}';  ";
            sqlcomando = sqlcomando + $" SET @OBSERVACIONES = '{PedidoParametros.OBSERVACIONES}';  ";
            sqlcomando = sqlcomando + $" SET @USUARIO_LOGIN = '{PedidoParametros.USUARIO_LOGIN}';  ";
            sqlcomando = sqlcomando + $" SET @TARJETA_CREDITO = '{PedidoParametros.TARJETA_CREDITO}'; ";
            sqlcomando = sqlcomando + $" SET @NOMBRE_CUENTA = '{PedidoParametros.NOMBRE_CUENTA}'; ";
            sqlcomando = sqlcomando + $" SET @CONDICION_PAGO = '{PedidoParametros.CONDICION_PAGO}';  ";
            sqlcomando = sqlcomando + $" SET @CLIENTE = '{PedidoParametros.CLIENTE}';  ";
            sqlcomando = sqlcomando + $" DECLARE @NUM_CONS VARCHAR(10) = '{PedidoParametros.CODIGO_CONSECUTIVO}'; DECLARE @CONSECUTIVO VARCHAR(50); ";
            /*sqlcomando = sqlcomando + $" SET @PEDIDO = '{PedidoParametros.PEDIDO}' ";*/
            /*sqlcomando = sqlcomando + $" SET @PEDIDO = '{Nropedido}'; ";*/
            sqlcomando = sqlcomando + $" SELECT @CONSECUTIVO = CONVERT(INT,COALESCE(CONVERT(VARCHAR(50),CONVERT(INTEGER,SUBSTRING(MAX(PEDIDO),5,LEN(MAX(PEDIDO))))),'00000000')) + 1 FROM {this.schema}.PEDIDO WHERE PEDIDO LIKE '%'+@NUM_CONS+'%' ";
            sqlcomando = sqlcomando + $" SELECT @PEDIDO = @NUM_CONS +'-'+@CONSECUTIVO ";

            sqlcomando = sqlcomando + $" DECLARE @FACTURADOR VARCHAR(100); DECLARE @VERSION_PRECIO VARCHAR(100); DECLARE @COBRADOR VARCHAR(100); DECLARE @RUTA VARCHAR(100); ";
            sqlcomando = sqlcomando + $" DECLARE @ZONA VARCHAR(100); DECLARE @PAIS VARCHAR(100); DECLARE @ALIAS_CLIENTE VARCHAR(100); DECLARE @VENDEDOR VARCHAR(100); ";
            sqlcomando = sqlcomando + $" DECLARE @SI_NO INTEGER; DECLARE @NIVEL_PRECIOS VARCHAR(100); ";
            sqlcomando = sqlcomando + $" SELECT @SI_NO = COUNT(*) FROM  {this.schema}.PEDIDO WHERE PEDIDO = @PEDIDO ";
            sqlcomando = sqlcomando + $" IF @SI_NO <= 0  ";
            sqlcomando = sqlcomando + $" SELECT @ALIAS_CLIENTE = ALIAS,@NIVEL_PRECIOS= NIVEL_PRECIO, @COBRADOR = COBRADOR , @RUTA = RUTA, @ZONA = ZONA, @VENDEDOR = VENDEDOR, @PAIS = PAIS  ";
            sqlcomando = sqlcomando + $" FROM {this.schema}.CLIENTE WHERE CLIENTE = @CLIENTE ";
            sqlcomando = sqlcomando + $" IF @VENDEDOR IS NULL SET @VENDEDOR = 'ND' ";
            sqlcomando = sqlcomando + $" SELECT @FACTURADOR = COD_FACTURADOR FROM USUARIO_FACTURADOR_WEB WHERE USUARIO = @USUARIO_LOGIN ";
            sqlcomando = sqlcomando + $" IF @FACTURADOR = NULL OR @FACTURADOR = '' SET @FACTURADOR = @VENDEDOR ";
            sqlcomando = sqlcomando + $" SELECT @VERSION_PRECIO = MAX(VERSION) FROM {this.schema}.VERSION_NIVEL WHERE NIVEL_PRECIO = @NIVEL_PRECIOS ";
            sqlcomando = sqlcomando + $" INSERT INTO {this.schema}.PEDIDO (PEDIDO,ESTADO,FECHA_PEDIDO,FECHA_PROMETIDA,FECHA_PROX_EMBARQU,FECHA_ULT_EMBARQUE, FECHA_ULT_CANCELAC, ORDEN_COMPRA,FECHA_ORDEN,TARJETA_CREDITO, EMBARCAR_A, DIREC_EMBARQUE,RUBRO1  ,RUBRO2 ,RUBRO3,RUBRO4,RUBRO5,OBSERVACIONES ,COMENTARIO_CXC,TOTAL_MERCADERIA,MONTO_ANTICIPO,MONTO_FLETE,MONTO_SEGURO,MONTO_DOCUMENTACIO,TIPO_DESCUENTO1,TIPO_DESCUENTO2,MONTO_DESCUENTO1,MONTO_DESCUENTO2,PORC_DESCUENTO1,PORC_DESCUENTO2,TOTAL_IMPUESTO1,TOTAL_IMPUESTO2,TOTAL_A_FACTURAR,PORC_COMI_VENDEDOR,PORC_COMI_COBRADOR,TOTAL_CANCELADO,TOTAL_UNIDADES,IMPRESO, FECHA_HORA,DESCUENTO_VOLUMEN,TIPO_PEDIDO,MONEDA_PEDIDO,VERSION_NP     ,AUTORIZADO,DOC_A_GENERAR,CLASE_PEDIDO,MONEDA,NIVEL_PRECIO,COBRADOR ,RUTA ,USUARIO       ,CONDICION_PAGO ,BODEGA ,ZONA, VENDEDOR ,CLIENTE,CLIENTE_DIRECCION,CLIENTE_CORPORAC,CLIENTE_ORIGEN,PAIS ,SUBTIPO_DOC_CXC,TIPO_DOC_CXC,BACKORDER,CONTRATO,PORC_INTCTE,DESCUENTO_CASCADA,NoteExistsFlag,RecordDate,CreatedBy ,CreateDate,DIRECCION_FACTURA,TIPO_CAMBIO,FIJAR_TIPO_CAMBIO,ORIGEN_PEDIDO, NOMBRE_CLIENTE) ";
            sqlcomando = sqlcomando + $" VALUES                    (@PEDIDO,'N',   CONVERT(varchar(10),GETDATE(),120),   CONVERT(varchar(10),GETDATE(),120),      CONVERT(varchar(10),GETDATE(),120),         '1980-01-01 00:00:00.000','1980-01-01 00:00:00.000',@ORDEN_COMPRA,CONVERT(varchar(10),GETDATE(),120), @TARJETA_CREDITO, (CASE WHEN @NOMBRE_CUENTA IS NULL OR @NOMBRE_CUENTA = '' THEN @ALIAS_CLIENTE ELSE @NOMBRE_CUENTA END) ,'ND'          ,@NOMBRE_CUENTA,@FACTURADOR,NULL  ,NULL  ,NULL  ,@OBSERVACIONES,NULL          ,0               ,0             ,0          ,0           ,0                 ,'P'            ,'P'            ,0               ,0               , 0             ,0              ,0              , 0             ,0               , 0                , 0                 ,0             ,0             ,'N'    , CONVERT(varchar(10),GETDATE(),120) ,0                , 'N'       ,'L'          ,@VERSION_PRECIO,'N'       ,'F'          ,'N'         ,'L'   , @NIVEL_PRECIOS  ,@COBRADOR,@RUTA,@USUARIO_LOGIN,@CONDICION_PAGO,@BODEGA,@ZONA,@VENDEDOR,@CLIENTE,@CLIENTE        ,@CLIENTE        ,@CLIENTE      ,@PAIS,0              ,'FAC'       ,'N'      ,NULL    ,0          ,'N'              ,0             ,CONVERT(varchar(10),GETDATE(),120)  ,@USUARIO_LOGIN,CONVERT(varchar(10),GETDATE(),120) ,'ND'             ,NULL       ,'N'              ,'F'   , (CASE WHEN @NOMBRE_CUENTA IS NULL OR @NOMBRE_CUENTA = '' THEN @ALIAS_CLIENTE ELSE @NOMBRE_CUENTA END)    ) ";
            sqlcomando = sqlcomando + $" DECLARE @ARTICULO VARCHAR(100); DECLARE @CREADOR_POR VARCHAR(100); DECLARE @PRECIO_UNITARIO DECIMAL(14,2); DECLARE @CANTIDAD DECIMAL(14,2); DECLARE @DESCUENTO DECIMAL(14,2); ";
            sqlcomando = sqlcomando + $" DECLARE @LINEA_USUARIO   INTEGER; DECLARE @PEDIDO_LINEA    INTEGER; DECLARE @EXENTO_IMPUESTO VARCHAR(10); DECLARE @ITBM DECIMAL(14,2); ";
            foreach (var item in PedidoLineaParametros)
            {
                sqlcomando = sqlcomando + $" set @ARTICULO ='{item.ARTICULO}'; ";
                sqlcomando = sqlcomando + $" set @CREADOR_POR ='{item.CREADOR_POR}'; ";
                sqlcomando = sqlcomando + $" set @PRECIO_UNITARIO = {item.PRECIO_UNITARIO}; ";
                sqlcomando = sqlcomando + $" set @CANTIDAD = {item.CANTIDAD}; ";
                sqlcomando = sqlcomando + $" set @DESCUENTO = {item.DESCUENTO}; ";
                sqlcomando = sqlcomando + $" Select @ITBM = CONVERT(DECIMAL(14,2),IMPUESTO1)/100 + CONVERT(DECIMAL(14,2),IMPUESTO2)/100 From {this.schema}.IMPUESTO WHERE IMPUESTO = (SELECT IMPUESTO FROM {this.schema}.ARTICULO WHERE ARTICULO = @ARTICULO) ; ";
                sqlcomando = sqlcomando + $" SELECT @EXENTO_IMPUESTO = EXENTO_IMPUESTOS FROM {this.schema}.CLIENTE WHERE CLIENTE = (SELECT CLIENTE FROM {this.schema}.PEDIDO WHERE PEDIDO = @PEDIDO) ";
                sqlcomando = sqlcomando + $" IF  (SELECT MAX(PEDIDO_LINEA)+1 FROM {this.schema}.PEDIDO_LINEA WHERE PEDIDO = @PEDIDO) IS NULL  ";
                sqlcomando = sqlcomando + $" SET @PEDIDO_LINEA = 1 ";
                sqlcomando = sqlcomando + $" ELSE ";
                sqlcomando = sqlcomando + $" SELECT @PEDIDO_LINEA =  MAX(PEDIDO_LINEA)+1 FROM {this.schema}.PEDIDO_LINEA WHERE PEDIDO = @PEDIDO ";
                sqlcomando = sqlcomando + $" IF (SELECT COUNT(*) FROM {this.schema}.PEDIDO_LINEA WHERE PEDIDO = @PEDIDO) <= 0  ";
                sqlcomando = sqlcomando + $" SET @LINEA_USUARIO = 0 ";
                sqlcomando = sqlcomando + $" ELSE ";
                sqlcomando = sqlcomando + $" SELECT @LINEA_USUARIO = COUNT(*)-1 FROM {this.schema}.PEDIDO_LINEA WHERE PEDIDO = @PEDIDO  ";
                sqlcomando = sqlcomando + $" INSERT INTO {this.schema}.PEDIDO_LINEA(PEDIDO,  PEDIDO_LINEA,  BODEGA, LOTE,LOCALIZACION,ARTICULO ,ESTADO,FECHA_ENTREGA,LINEA_USUARIO, PRECIO_UNITARIO, CANTIDAD_PEDIDA,CANTIDAD_A_FACTURA,CANTIDAD_FACTURADA,CANTIDAD_RESERVADA,CANTIDAD_BONIFICAD,CANTIDAD_CANCELADA,TIPO_DESCUENTO,MONTO_DESCUENTO,PORC_DESCUENTO,DESCRIPCION,COMENTARIO,PEDIDO_LINEA_BONIF,UNIDAD_DISTRIBUCIO,FECHA_PROMETIDA,LINEA_ORDEN_COMPRA,RecordDate,CreatedBy,CreateDate) ";
                sqlcomando = sqlcomando + $" VALUES                         (@PEDIDO, @PEDIDO_LINEA, @BODEGA,NULL,NULL        ,@ARTICULO,'N'   ,CONVERT(varchar(10),GETDATE(),120),@LINEA_USUARIO,@PRECIO_UNITARIO,@CANTIDAD      ,@CANTIDAD                 ,@CANTIDAD         ,0                 ,0                 ,0                 ,'P'           ,@DESCUENTO              ,0             ,NULL       ,NULL      ,NULL              ,NULL              ,CONVERT(varchar(10),GETDATE(),120)      ,NULL              , CONVERT(varchar(10),GETDATE(),120), @CREADOR_POR,getdate())       ";
                sqlcomando = sqlcomando + $" UPDATE {this.schema}.EXISTENCIA_BODEGA SET CANT_PEDIDA = CANT_PEDIDA + @CANTIDAD  WHERE BODEGA = @BODEGA AND ARTICULO = @ARTICULO ";
                sqlcomando = sqlcomando + $" IF @EXENTO_IMPUESTO = 'S' OR @ITBM = 0 ";
                sqlcomando = sqlcomando + $" UPDATE {this.schema}.PEDIDO	SET TOTAL_MERCADERIA = TOTAL_MERCADERIA + ROUND(@PRECIO_UNITARIO*@CANTIDAD,4), TOTAL_IMPUESTO1 = TOTAL_IMPUESTO1, TOTAL_A_FACTURAR = TOTAL_A_FACTURAR + ROUND((@PRECIO_UNITARIO*@CANTIDAD)-(@DESCUENTO),3),TOTAL_UNIDADES = TOTAL_UNIDADES + @CANTIDAD, MONTO_DESCUENTO1 = MONTO_DESCUENTO1 + @DESCUENTO WHERE PEDIDO = @PEDIDO ";
                sqlcomando = sqlcomando + $" ELSE ";
                sqlcomando = sqlcomando + $" UPDATE {this.schema}.PEDIDO SET TOTAL_MERCADERIA = TOTAL_MERCADERIA + ROUND(@PRECIO_UNITARIO*@CANTIDAD,4), TOTAL_IMPUESTO1 = TOTAL_IMPUESTO1 + ROUND(((@PRECIO_UNITARIO*@CANTIDAD)- @DESCUENTO) * (@ITBM),4), TOTAL_A_FACTURAR = TOTAL_A_FACTURAR + ROUND(((@PRECIO_UNITARIO*@CANTIDAD)- @DESCUENTO),4)+ROUND(((@PRECIO_UNITARIO*@CANTIDAD)-@DESCUENTO) * @ITBM,4)/*-ROUND(@DESCUENTO,2)*/,TOTAL_UNIDADES = TOTAL_UNIDADES + @CANTIDAD,MONTO_DESCUENTO1 = MONTO_DESCUENTO1 + @DESCUENTO WHERE PEDIDO = @PEDIDO ";
            }
            
            sqlcomando = sqlcomando + " select @PEDIDO  PEDIDO";
            SqlDataReader reader;
            //Se obtiene el reader de Enterprise Library y se convierte a SqlDataReader para poder pasarlo al dynamicReader
            reader = ((RefCountingDataReader)db.ExecuteReader(System.Data.CommandType.Text, sqlcomando)).InnerReader as SqlDataReader;
            //Se transforma al dynamic reader para acceder por nombre y evitar los casting entre tipo y los GET...
            dynamic dynreader = (DynamicDataReader)reader;
            //Se le el reader
            while (dynreader.Read())
            {
                Nropedido = dynreader.PEDIDO;
            }
            dynreader.Close();
            reader.Close();
            return Nropedido;
        }


        public void EliminarLinea(List<PedidoLineaParametrosViewModel> PedidoLineaParametros)
        {
            string sqlcomando = "";
            sqlcomando = sqlcomando + " DECLARE @NUM_PEDIDO VARCHAR(100); DECLARE @ARTICULO VARCHAR(100); DECLARE @LINEA INTEGER; DECLARE @SUB_TOTAL DECIMAL(14,4); DECLARE @ITBM DECIMAL(14,3); DECLARE @TOTAL DECIMAL(14,3); DECLARE @UNIDADES DECIMAL(14,3); DECLARE @MONTO_DESCUENTO DECIMAL(14,3); DECLARE @EXENTO_IMPUESTO VARCHAR(10); DECLARE @ITBMS DECIMAL(14,2);    ";
            
            foreach (var item in PedidoLineaParametros)
            {
                sqlcomando = sqlcomando + $" set @ARTICULO ='{item.ARTICULO}'; ";
                sqlcomando = sqlcomando + $" set @NUM_PEDIDO ='{item.PEDIDO}'; ";
                sqlcomando = sqlcomando + $" set @LINEA = {item.Linea}; ";
                sqlcomando = sqlcomando + $" Select @ITBMS = CONVERT(DECIMAL(14,2),IMPUESTO1)/100 + CONVERT(DECIMAL(14,2),IMPUESTO2)/100 From {this.schema}.IMPUESTO WHERE IMPUESTO = (SELECT IMPUESTO FROM {this.schema}.ARTICULO WHERE ARTICULO = @ARTICULO) ;  SELECT @EXENTO_IMPUESTO = EXENTO_IMPUESTOS FROM {this.schema}.CLIENTE WHERE CLIENTE = (SELECT CLIENTE FROM {this.schema}.PEDIDO WHERE PEDIDO = @NUM_PEDIDO)  IF @EXENTO_IMPUESTO = 'S' OR @ITBMS = 0 SELECT @SUB_TOTAL = CONVERT(DECIMAL(10,4),(PRECIO_UNITARIO*CANTIDAD_PEDIDA)), @UNIDADES = CONVERT(DECIMAL(10,4),CANTIDAD_PEDIDA), @ITBM = 0 ,   @TOTAL = ROUND(((PRECIO_UNITARIO*CANTIDAD_PEDIDA)-MONTO_DESCUENTO),4), @MONTO_DESCUENTO = CONVERT(DECIMAL(10,4),ROUND(MONTO_DESCUENTO,4))  FROM {this.schema}.PEDIDO_LINEA PL, {this.schema}.ARTICULO AR WHERE PL.ARTICULO = AR.ARTICULO AND PEDIDO = @NUM_PEDIDO AND  PL.ARTICULO = @ARTICULO AND  PL.PEDIDO_LINEA = @LINEA  ELSE SELECT @SUB_TOTAL = CONVERT(DECIMAL(10,4),(PRECIO_UNITARIO*CANTIDAD_PEDIDA)), @UNIDADES = CONVERT(DECIMAL(10,4),CANTIDAD_PEDIDA),   @ITBM = CONVERT(DECIMAL(10,4),ROUND((((PRECIO_UNITARIO*CANTIDAD_PEDIDA)-MONTO_DESCUENTO)*@ITBMS),4)) , @TOTAL = CONVERT(DECIMAL(10,4),ROUND(((PRECIO_UNITARIO*CANTIDAD_PEDIDA)-MONTO_DESCUENTO) + (((PRECIO_UNITARIO*CANTIDAD_PEDIDA)-MONTO_DESCUENTO)*@ITBMS),4)), @MONTO_DESCUENTO = CONVERT(DECIMAL(10,4),ROUND(MONTO_DESCUENTO,4))  FROM {this.schema}.PEDIDO_LINEA PL, {this.schema}.ARTICULO AR WHERE PL.ARTICULO = AR.ARTICULO AND PEDIDO = @NUM_PEDIDO  AND  PL.ARTICULO = @ARTICULO AND  PL.PEDIDO_LINEA = @LINEA  UPDATE {this.schema}.PEDIDO SET TOTAL_MERCADERIA = TOTAL_MERCADERIA - ROUND(@SUB_TOTAL,4), TOTAL_IMPUESTO1 = TOTAL_IMPUESTO1 - ROUND(@ITBM,4) , TOTAL_A_FACTURAR = TOTAL_A_FACTURAR - ROUND(@TOTAL,4), TOTAL_UNIDADES = TOTAL_UNIDADES - @UNIDADES, MONTO_DESCUENTO1 = MONTO_DESCUENTO1 - @MONTO_DESCUENTO WHERE PEDIDO = @NUM_PEDIDO  DELETE FROM {this.schema}.PEDIDO_LINEA WHERE ARTICULO = @ARTICULO AND PEDIDO = @NUM_PEDIDO AND PEDIDO_LINEA = @LINEA  UPDATE {this.schema}.EXISTENCIA_BODEGA SET CANT_PEDIDA = CANT_PEDIDA - @UNIDADES WHERE BODEGA = (SELECT DISTINCT BODEGA FROM {this.schema}.PEDIDO WHERE PEDIDO = @NUM_PEDIDO) AND ARTICULO = @ARTICULO  "; 
            }
            db.ExecuteNonQuery(System.Data.CommandType.Text, sqlcomando);
        }















        public string getConnectionString(string user, string password) {

            var builder = new SqlConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings["ExactusConnection"].ConnectionString);
            builder.UserID = user;
            builder.Password = password;
            return builder.ToString();
        }


    }
}
