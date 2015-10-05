
using AutoMapper;
using JP.Exactus.Data;
using JP.Exactus.Interfaces;
using System;
using System.Collections.Generic;


namespace JP.Exactus.Logic
{
    /// <summary>
    /// Esta clase representa el contenedor de inversión de control, expone las clases de servicios en la aplicación.
    /// </summary>
    public class BusinessCore : IBusinessCoreContainer, IDisposable
    {
        private LicenciaCoreDBEntities _dbContext;
        private Dictionary<Type, object> _instanceHolder;

        /// <summary>
        /// Constructor que recibe el dbContext. Este dbContext es inyectado por Ninject (ver IoCContainer.cs).
        /// </summary>
        /// <param name="dbContext"></param>
        public BusinessCore(LicenciaCoreDBEntities dbContext)
        {
            _dbContext = dbContext;
            _instanceHolder = new Dictionary<Type, object>();
        }

        public BusinessCore()
        {
            _instanceHolder = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Obtiene una de las clases del servicio y le asigna el context para que lo utiliza.
        /// Para no instanciar todas las clases de servicios, se instancia cuando se accede la propiedad.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private T Get<T>()
        {
            Type type = typeof(T);
            if (_instanceHolder.ContainsKey(type))
            {
                return (T)_instanceHolder[type];
            }

            T t = Activator.CreateInstance<T>();
            if (_dbContext != null)
            {
            (t as BusinessCoreObject).Context = _dbContext;
            }
            _instanceHolder.Add(type, t);

            return t;
        }

        public void Dispose()
        {
            _instanceHolder.Clear();
            if (_dbContext != null)
            _dbContext.Dispose();
        }

        public IEmpresasBusinessObject Empresas
        {
            get { return Get<EmpresaBusinessObject>(); }
        }

        public IDispositivoBusinessObject Dispositivos
        {
            get { return Get<DispositivoBusinessObject>(); }
        }

        public IOpcionesEmpresaBusinessObject OpcionesEmpresa
        {
            get { return Get<OpcionesEmpresaBusinessObject>(); }
        }

        public IExactusBusinessObject Exactus
        {
            get { return Get<ExactusBusinessObject>(); }
        }

        public IOpcionesBusinessObject Opciones
        {
            get { return Get<OpcionesBusinessObject>(); }
        }
    }
}
