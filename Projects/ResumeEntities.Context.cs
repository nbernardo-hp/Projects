//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projects
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PortfolioEntities : DbContext
    {
        public PortfolioEntities()
            : base("name=PortfolioEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<COMPANY> COMPANies { get; set; }
        public virtual DbSet<JOB> JOBs { get; set; }
        public virtual DbSet<JOB_DATES> JOB_DATES { get; set; }
        public virtual DbSet<JOB_DESC> JOB_DESC { get; set; }
        public virtual DbSet<MAJOR> MAJORs { get; set; }
        public virtual DbSet<SCHOOL> SCHOOLs { get; set; }
        public virtual DbSet<PROJECT_LINKS> PROJECT_LINKS { get; set; }
        public virtual DbSet<PROJECT> PROJECTS { get; set; }
    }
}
