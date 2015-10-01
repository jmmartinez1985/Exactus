using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP.Exactus.Data.ViewModel
{
    public class EmpresasViewModel
    {
        public int IDEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Ruc { get; set; }
        public string UrlApi { get; set; }
        public string Logo { get; set; }
        public string Email { get; set; }
        public string PersonaContacto { get; set; }
        public bool Activo { get; set; }

    }
}
