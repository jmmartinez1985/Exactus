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

        public void GuardarPedido(string schema) {
            //DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory());
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.Create("ExactusConnection");
            dynamic result =db.ExecuteDataSet(System.Data.CommandType.Text, $"select top 10 * from  {schema}.pedido");
        }
    }
}
