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

        public ExactusData() { }

        public ExactusData(string User, string Pass) {
            this.user = User;
            this.password = Pass;
        }

        public static void GuardarPedido() {
            Database db = DatabaseFactory.CreateDatabase("ExactusConnection");

        }
    }
}
