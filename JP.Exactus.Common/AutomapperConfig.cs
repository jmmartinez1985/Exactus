
using AutoMapper;
using JP.Exactus.Data;
using JP.Exactus.Data.ViewModel;
using System.Collections.Generic;

namespace JP.Exactus.Common
{
    /// <summary>
    /// Clase encargada de configurar los mapeos entre entidades del modelo utilizando Automapper.
    /// </summary>
    public class AutomapperConfig
    {
        private static bool _isConfigured;

        /// <summary>
        /// Configura los mapeos. Debiera ser llamado una vez solamente por application domain.
        /// </summary>
        public static void Configure()
        {
            if (!_isConfigured)
            {
                // Mapeos de Catalogos.
                Mapper.CreateMap<Empresa, EmpresasViewModel>();
              

                _isConfigured = true;
            }
        }
    }
}
