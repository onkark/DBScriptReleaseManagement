﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBScriptReleaseManagement.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
    		//disabling Type 'System.Data.Entity.DynamicProxies' with data contract name
    		base.Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ItemList> ItemLists { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ReleaseScript> ReleaseScripts { get; set; }
        public virtual DbSet<ProjectReleaseSchedule> ProjectReleaseSchedules { get; set; }
    }
}
