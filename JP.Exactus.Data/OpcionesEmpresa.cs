//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JP.Exactus.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class OpcionesEmpresa
    {
        public int IDOpcionEmpresa { get; set; }
        public int IDEmpresa { get; set; }
        public int IDOpcion { get; set; }
        public bool Activo { get; set; }
    
        public virtual Empresa Empresa { get; set; }
        public virtual Opciones Opciones { get; set; }
    }
}
