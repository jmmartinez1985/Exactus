using JP.Exactus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JP.Exactus.Data.ViewModel;

namespace JP.Exactus.Logic
{
    public class EmpresaBusinessObject : BusinessCoreObject, IEmpresasBusinessObject
    {
        public void Dispose()
        {
            throw new NotImplementedException();

        }

        public EmpresasViewModel obtenerDetalleEmpresa(int empresaId)
        {

            this.Context.EMP_Empresas.Create();
            this.Context.EMP_Empresas.Add(new Data.EMP_Empresas { Emp_Ingreso = System.DateTime.Now, Emp_Nombre = "Isrra" });
            this.Context.SaveChanges();
            return null;
        }
    }
}
