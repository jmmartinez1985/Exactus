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

        public static void GuardarPedido() {
            Database db = DatabaseFactory.CreateDatabase("MoneyBackConnectionString");

        }
    }
}
