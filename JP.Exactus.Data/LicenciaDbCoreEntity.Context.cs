﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LicenciaCoreDBEntities : DbContext
    {
        public LicenciaCoreDBEntities()
            : base("name=LicenciaCoreDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Auditoria> Auditoria { get; set; }
        public virtual DbSet<Dispositivo> Dispositivo { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Opciones> Opciones { get; set; }
        public virtual DbSet<OpcionesEmpresa> OpcionesEmpresa { get; set; }
    }
}
