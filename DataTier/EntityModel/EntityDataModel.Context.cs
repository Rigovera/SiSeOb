﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace DataTier.EntityModel
{
    using MySql.Data.EntityFramework;

    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    //"docker run --name mariaDB -e MYSQL_ROOT_PASSWORD=root -p 3306:3306  -d docker.io/library/mariadb:10.9"
    [DbConfigurationType(typeof(MySqlEFConfiguration))] //linea super importante luego de actualizar EF 6 y connector. Tambien hay que modificar correctamente el config
    public partial class siseobEntities : DbContext
    {
        public siseobEntities()
            : base("name=siseobEntities")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }


        public virtual DbSet<assignedemployee> assignedemployees { get; set; }

        public virtual DbSet<assignedtool> assignedtools { get; set; }

        public virtual DbSet<certificate> certificates { get; set; }

        public virtual DbSet<certificatearticleitem> certificatearticleitems { get; set; }

        public virtual DbSet<certificatedetail> certificatedetails { get; set; }

        public virtual DbSet<certificatetype> certificatetypes { get; set; }

        public virtual DbSet<client> clients { get; set; }

        public virtual DbSet<employee> employees { get; set; }

        public virtual DbSet<employeetype> employeetypes { get; set; }

        public virtual DbSet<location> locations { get; set; }

        public virtual DbSet<measurementunit> measurementunits { get; set; }

        public virtual DbSet<moneymovement> moneymovements { get; set; }

        public virtual DbSet<moneymovementtype> moneymovementtypes { get; set; }

        public virtual DbSet<receipt> receipts { get; set; }

        public virtual DbSet<receiptdetail> receiptdetails { get; set; }

        public virtual DbSet<tool> tools { get; set; }

        public virtual DbSet<tooltype> tooltypes { get; set; }

        public virtual DbSet<work> works { get; set; }

        public virtual DbSet<worktype> worktypes { get; set; }

        public virtual DbSet<articleprice> articleprices { get; set; }

        public virtual DbSet<pricelist> pricelists { get; set; }

        public virtual DbSet<certificatearticle> certificatearticles { get; set; }

    }

}

