using JP.Exactus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JP.Exactus.Data;

namespace JP.Exactus.Logic
{
    public class ExactusBusinessObject : IExactusBusinessObject
    {

        private string Schema
        {
            get { return System.Configuration.ConfigurationManager.AppSettings["schema"].ToString(); }
        }
       
        public bool obtenerUsuario(string usuario, string contraseña)
        {

            var exactus = new ExactusData(usuario, contraseña, Schema);
            /*exactus.GuardarPedido(Schema);*/
            return exactus.ValidaUsuario();
        }
    }
}
