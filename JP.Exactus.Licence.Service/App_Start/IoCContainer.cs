

using JP.Exactus.Data;
using JP.Exactus.Interfaces;
using JP.Exactus.Logic;
using Ninject;
using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JP.Exactus.Licence.Service
{
    public class IoCContainer
    {
        private static StandardKernel _kernel;

        public static StandardKernel Kernel
        {
            get
            {
                return _kernel;
            }
        }

        public static T Get<T>()
        {
            return _kernel.Get<T>();
        }

        public static void Bind()
        {
            _kernel = new StandardKernel();
            _kernel.Bind<IBusinessCoreContainer>().To<BusinessCore>().WithConstructorArgument("dbContext", GetConstructorArgFromSession);
            _kernel.Bind<IEmpresasBusinessObject>().To<EmpresaBusinessObject>();
            _kernel.Bind<IDispositivoBusinessObject>().To<DispositivoBusinessObject>();
            _kernel.Bind<IOpcionesEmpresaBusinessObject>().To<OpcionesEmpresaBusinessObject>();

        }

        private static object GetConstructorArgFromSession(IContext context)
        {
            return new LicenciaCoreDBEntities();
        }
    }
}