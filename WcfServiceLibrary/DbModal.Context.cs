﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfServiceLibrary
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SalesDBEntities : DbContext
    {
        public SalesDBEntities()
            : base("name=SalesDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
    }
}
