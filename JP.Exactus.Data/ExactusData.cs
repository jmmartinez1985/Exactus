using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
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

        public ExactusData() { }

        public ExactusData(string User, string Pass, String Schema) {
            this.user = User;
            this.password = Pass;
            this.schema = Schema;
        }

        public void RetornarBodega(string schema, string usuario)
        {
            //DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory());
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create("ExactusConnection");
            dynamic result =db.ExecuteDataSet(System.Data.CommandType.Text, $"SELECT A.BODEGA,B.NOMBRE FROM {schema}.USUARIO_BODEGA A, BREMEN.BODEGA B WHERE A.BODEGA = B.BODEGA AND A.USUARIO= {usuario} ORDER BY A.BODEGA ASC");
        }


        public void RetornarClientePorNombre(string schema ,string Nombre)
        {
            //DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory());
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create("ExactusConnection");
            dynamic result =db.ExecuteDataSet(System.Data.CommandType.Text, $"SELECT A.CLIENTE,A.NOMBRE,A.CONTRIBUYENTE, A.ALIAS, A.SALDO, A.LIMITE_CREDITO, B.DESCRIPCION CATEGORIA_CLIENTE, A.NIVEL_PRECIO,A.CONDICION_PAGO, (SELECT MAX(VERSION) VERSION FROM {schema}.VERSION_NIVEL WHERE NIVEL_PRECIO = A.NIVEL_PRECIO) VERSION_PRECIO FROM {schema}.CLIENTE A, {schema}.CATEGORIA_CLIENTE B WHERE  NOMBRE LIKE '% {Nombre} %' AND A.CATEGORIA_CLIENTE = B.CATEGORIA_CLIENTE AND ACTIVO = 'S' ORDER BY A.NOMBRE");
        }

        public void RetornarClientePorRuc(string schema,string RucCedula)
        {
            //DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory());
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create("ExactusConnection");
            dynamic result = db.ExecuteDataSet(System.Data.CommandType.Text, $"SELECT A.CLIENTE,A.NOMBRE,A.CONTRIBUYENTE, A.ALIAS, A.SALDO, A.LIMITE_CREDITO, B.DESCRIPCION CATEGORIA_CLIENTE, A.NIVEL_PRECIO,A.CONDICION_PAGO,(SELECT MAX(VERSION) VERSION FROM {schema}.VERSION_NIVEL WHERE NIVEL_PRECIO = A.NIVEL_PRECIO) VERSION_PRECIO FROM {schema}.CLIENTE A, {schema}.CATEGORIA_CLIENTE B WHERE  NOMBRE LIKE '% {RucCedula} %' AND A.CATEGORIA_CLIENTE = B.CATEGORIA_CLIENTE AND ACTIVO = 'S' ORDER BY A.NOMBRE");
        }

        

        public void BuscarArticulo(string schema, string bodega, string articulo, string descripcion, string nivel_precio,string version_precio, string clasificacion1, string clasificacion2, string clasificacion3, string clasificacion4, string clasificacion5, string clasificacion6)
        {
            //DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory());
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create("ExactusConnection");
            string sqlcomando="";
            sqlcomando = $" SELECT AR.ARTICULO , AR.DESCRIPCION ,AR.CODIGO_BARRAS_INVT CODIGO_BARRA,CONVERT(CHAR,CONVERT(INT,(EB.CANT_DISPONIBLE))) Disponible, (SELECT PRECIO FROM {schema}.ARTICULO_PRECIO WHERE VERSION = {version_precio} AND NIVEL_PRECIO = {nivel_precio}  AND ARTICULO = AR.ARTICULO) PRECIO ";
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




    }
}
