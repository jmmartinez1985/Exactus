﻿using JP.Exactus.Data.Helpers;
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
            sqlcomando = $" SELECT AR.ARTICULO , AR.DESCRIPCION ,AR.CODIGO_BARRAS_INVT CODIGO_BARRA,CONVERT(CHAR,CONVERT(INT,(EB.CANT_DISPONIBLE))) Disponible, (SELECT PRECIO FROM {this.schema}.ARTICULO_PRECIO WHERE VERSION = {version_precio} AND NIVEL_PRECIO = {nivel_precio}  AND ARTICULO = AR.ARTICULO) PRECIO, AR.IMPUESTO ";
            sqlcomando = sqlcomando + $" FROM {this.schema}.ARTICULO AR, {this.schema}.EXISTENCIA_BODEGA EB ";
            sqlcomando = sqlcomando + " WHERE AR.ARTICULO = EB.ARTICULO AND AR.ACTIVO = 'S' ";
            sqlcomando = sqlcomando + $" AND BODEGA = {bodega}";
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
                sqlcomando = sqlcomando + $" AND AR.CLASIFICACION_1 = {clasificacion1} ";
            }
            if (clasificacion2 != null)
            {
                sqlcomando = sqlcomando + $" AND AR.CLASIFICACION_2 = {clasificacion2} ";
            }
            if (clasificacion3 != null)
            {
                sqlcomando = sqlcomando + $" AND AR.CLASIFICACION_3 = {clasificacion3} ";
            }
            if (clasificacion4 != null)
            {
                sqlcomando = sqlcomando + $" AND AR.CLASIFICACION_4 = {clasificacion4} ";
            }
            if (clasificacion5 != null)
            {
                sqlcomando = sqlcomando + $" AND AR.CLASIFICACION_5 = {clasificacion5} ";
            }
            if (clasificacion6 != null)
            {
                sqlcomando = sqlcomando + $" AND AR.CLASIFICACION_6 = {clasificacion6} ";
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
                    DISPONIBLE = dynreader.DISPONIBLE,
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
            reader = ((RefCountingDataReader)db.ExecuteReader(System.Data.CommandType.Text, $"SELECT  B.CODIGO_CONSECUTIVO, B.DESCRIPCION FROM {schema}.CONSECUFA_USUARIO A, {schema}.CONSECUTIVO_FA B WHERE A.CODIGO_CONSECUTIVO = B.CODIGO_CONSECUTIVO AND USUARIO = {usuario} ORDER BY B.CODIGO_CONSECUTIVO")).InnerReader as SqlDataReader;
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


        public string GrabarPedido(PedidoParametrosViewModel PedidoParametros, PedidoLineaParametrosViewModel PedidoLineas)
        {
            string sqlcomando = "";
            string Nropedido = ""; /*Pon aqui un numero de pedido cualquiera que sea varchar para probar*/
            
            sqlcomando = sqlcomando + $" DECLARE @CLIENTE VARCHAR(100); DECLARE @BODEGA  VARCHAR(100); DECLARE @ORDEN_COMPRA VARCHAR(100); DECLARE @OBSERVACIONES VARCHAR(300); ";
            sqlcomando = sqlcomando + $" DECLARE @USUARIO_LOGIN VARCHAR(100); DECLARE @TARJETA_CREDITO VARCHAR(100); DECLARE @NOMBRE_CUENTA VARCHAR(100); ";
            sqlcomando = sqlcomando + $" DECLARE @CONDICION_PAGO INTEGER; DECLARE @PEDIDO VARCHAR(100); ";
            sqlcomando = sqlcomando + $" DECLARE @CLIENTE VARCHAR(100); ";
            sqlcomando = sqlcomando + $" SET @BODEGA = '{PedidoParametros.BODEGA}'";
            sqlcomando = sqlcomando + $" SET @ORDEN_COMPRA = '{PedidoParametros.ORDEN_COMPRA}'  ";
            sqlcomando = sqlcomando + $" SET @OBSERVACIONES = '{PedidoParametros.OBSERVACIONES}'  ";
            sqlcomando = sqlcomando + $" SET @USUARIO_LOGIN = '{PedidoParametros.USUARIO_LOGIN}'  ";
            sqlcomando = sqlcomando + $" SET @TARJETA_CREDITO = '{PedidoParametros.TARJETA_CREDITO}' ";
            sqlcomando = sqlcomando + $" SET @NOMBRE_CUENTA = '{PedidoParametros.NOMBRE_CUENTA}' ";
            sqlcomando = sqlcomando + $" SET @CONDICION_PAGO = '{PedidoParametros.CONDICION_PAGO}'  ";
            /*sqlcomando = sqlcomando + $" SET @PEDIDO = '{PedidoParametros.PEDIDO}' ";*/
            sqlcomando = sqlcomando + $" SET @PEDIDO = '{Nropedido}' ";
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
            sqlcomando = sqlcomando + " select @PEDIDO ";

            SqlDataReader reader;
            //Se obtiene el reader de Enterprise Library y se convierte a SqlDataReader para poder pasarlo al dynamicReader
            reader = ((RefCountingDataReader)db.ExecuteReader(System.Data.CommandType.Text, sqlcomando)).InnerReader as SqlDataReader;
            //Se transforma al dynamic reader para acceder por nombre y evitar los casting entre tipo y los GET...
            dynamic dynreader = (DynamicDataReader)reader;
            //Se le el reader
            while (dynreader.Read())
            {
                Nropedido = dynreader.nropedido;
            }
            dynreader.Close();
            reader.Close();
            return Nropedido;
        }






        public string getConnectionString(string user, string password) {

            var builder = new SqlConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings["ExactusConnection"].ConnectionString);
            builder.UserID = user;
            builder.Password = password;
            return builder.ToString();
        }


    }
}
