
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

                //Dispositivos
                Mapper.CreateMap<Dispositivo, DispositivoViewModel>()
                    .ForMember(t => t.Empresa, opts => opts.Ignore())
                    .ForMember(t => t.Auditoria, opts => opts.Ignore());

                Mapper.CreateMap<DispositivoViewModel, Dispositivo>()
                    .ForMember(t => t.Empresa, opts => opts.Ignore())
                    .ForMember(t => t.Auditoria, opts => opts.Ignore());


                //Empresas
                Mapper.CreateMap<Empresa, EmpresasViewModel>();
                    


                //Opciones
                Mapper.CreateMap<Opciones, OpcionesViewModel>();

                //OpcionesEmpresas
                Mapper.CreateMap<OpcionesEmpresa, OpcionesEmpresaViewModel>();

                Mapper.CreateMap<OpcionesEmpresaViewModel, OpcionesEmpresa >()
                    .ForMember(t => t.Empresa, opts => opts.Ignore())
                    .ForMember(t => t.Opciones, opts => opts.Ignore());

                //Auditoria
                Mapper.CreateMap<Auditoria, AuditoriaViewModel>();
                

                



                _isConfigured = true;
            }
        }
    }
}
