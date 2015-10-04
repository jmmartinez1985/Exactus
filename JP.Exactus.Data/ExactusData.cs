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
            reader = ((RefCountingDataReader)db.ExecuteReader(System.Data.CommandType.Text, $"SELECT A.BODEGA,B.NOMBRE FROM {this.schema}.USUARIO_BODEGA A, BREMEN.BODEGA B WHERE A.BODEGA = B.BODEGA AND A.USUARIO= '{this.user}' ORDER BY A.BODEGA ASC")).InnerReader as SqlDataReader;
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
        public void ObtenerClientePorNombre(string schema, string Nombre)
        {
            dynamic result = db.ExecuteDataSet(System.Data.CommandType.Text, $"SELECT A.CLIENTE,A.NOMBRE,A.CONTRIBUYENTE, A.ALIAS, A.SALDO, A.LIMITE_CREDITO, B.DESCRIPCION CATEGORIA_CLIENTE, A.NIVEL_PRECIO,A.CONDICION_PAGO, (SELECT MAX(VERSION) VERSION FROM {schema}.VERSION_NIVEL WHERE NIVEL_PRECIO = A.NIVEL_PRECIO) VERSION_PRECIO, A.EXENTO_IMPUESTOS FROM {schema}.CLIENTE A, {schema}.CATEGORIA_CLIENTE B WHERE  NOMBRE LIKE '% {Nombre} %' AND A.CATEGORIA_CLIENTE = B.CATEGORIA_CLIENTE AND ACTIVO = 'S' ORDER BY A.NOMBRE");
        }

        /*Busca todos los cliente que tengan el Ruc o Cédula parecido a la variable RucCedula*/
        public void ObtenerClientePorRuc(string schema, string RucCedula)
        {
            dynamic result = db.ExecuteDataSet(System.Data.CommandType.Text, $"SELECT A.CLIENTE,A.NOMBRE,A.CONTRIBUYENTE, A.ALIAS, A.SALDO, A.LIMITE_CREDITO, B.DESCRIPCION CATEGORIA_CLIENTE, A.NIVEL_PRECIO,A.CONDICION_PAGO,(SELECT MAX(VERSION) VERSION FROM {schema}.VERSION_NIVEL WHERE NIVEL_PRECIO = A.NIVEL_PRECIO) VERSION_PRECIO, A.EXENTO_IMPUESTOS FROM {schema}.CLIENTE A, {schema}.CATEGORIA_CLIENTE B WHERE  NOMBRE LIKE '% {RucCedula} %' AND A.CATEGORIA_CLIENTE = B.CATEGORIA_CLIENTE AND ACTIVO = 'S' ORDER BY A.NOMBRE");
        }


        /*Busca todos articulos por diferentes formas articulo, descripcion, clasificiacion1,clasificiacion2,clasificiacion3,clasificiacion4,clasificiacion5,clasificiacion6*/
        /*importante BODEGA NO SE MANDA NULL NI VACIO, EN LA BUSQUEDA ES ARTICULO = NULL O DESCRIPCION = NULL PERO UNO DE LOS DOS DEBE TENER VALOR */
        /*importante nivel_precio se saca el cliente */
        /*importante clasificaciones en la clase clasificacion, la agrupacion es por ejemplo 1 y en la busqueda es clasificacion_1 */
        public void ObtenerArticulo(string schema, string bodega, string articulo, string descripcion, string nivel_precio, string version_precio, string clasificacion1, string clasificacion2, string clasificacion3, string clasificacion4, string clasificacion5, string clasificacion6)
        {
            string sqlcomando = "";
            sqlcomando = $" SELECT AR.ARTICULO , AR.DESCRIPCION ,AR.CODIGO_BARRAS_INVT CODIGO_BARRA,CONVERT(CHAR,CONVERT(INT,(EB.CANT_DISPONIBLE))) Disponible, (SELECT PRECIO FROM {schema}.ARTICULO_PRECIO WHERE VERSION = {version_precio} AND NIVEL_PRECIO = {nivel_precio}  AND ARTICULO = AR.ARTICULO) PRECIO, AR.IMPUESTO ";
            sqlcomando = sqlcomando + $" FROM {schema}.ARTICULO AR, {schema}.EXISTENCIA_BODEGA EB ";
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

            dynamic result = db.ExecuteDataSet(System.Data.CommandType.Text, sqlcomando);

        }

        /*CLASIFICACION ES EL VALOR Y DESCRIPCION QUE ES, EN LA BUSQUEDA DE ARTICULO SE INTERPRETA CLASIFACION_(AGRUPACION)*/
        public void ObtenerClasificacion(string schema, string agrupacion)
        {
            dynamic result = db.ExecuteDataSet(System.Data.CommandType.Text, $"SELECT CLASIFICACION, DESCRIPCION FROM {schema}.CLASIFICACION WHERE AGRUPACION = {agrupacion}");
        }
        /*Consecutivo es el Esquema Maestro para Facturas, Pedidos, Devoluciones, Etc */
        public void BuscarConsecutivo(string schema, string usuario)
        {
            dynamic result = db.ExecuteDataSet(System.Data.CommandType.Text, $"SELECT  B.CODIGO_CONSECUTIVO, B.DESCRIPCION FROM {schema}.CONSECUFA_USUARIO A, {schema}.CONSECUTIVO_FA B WHERE A.CODIGO_CONSECUTIVO = B.CODIGO_CONSECUTIVO AND USUARIO = {usuario} ORDER BY B.CODIGO_CONSECUTIVO");
        }





        public string getConnectionString(string user, string password) {

            var builder = new SqlConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings["ExactusConnection"].ConnectionString);
            builder.UserID = user;
            builder.Password = password;
            return builder.ToString();
        }


    }
}
