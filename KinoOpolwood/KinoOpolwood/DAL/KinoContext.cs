namespace KinoOpolwood.DAL
{
    using KinoOpolwood.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class KinoContext : DbContext
    {
        // Your context has been configured to use a 'KinoContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'KinoOpolwood.DAL.KinoContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'KinoContext' 
        // connection string in the application configuration file.
        public KinoContext()
            : base("name=KinoContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Klient> Klients { get; set; }
        public virtual DbSet<Bilet> Bilets { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Miejsce> Miejsces { get; set; }
        public virtual DbSet<Rezerwacja> Rezerwacjas { get; set; }
        public virtual DbSet<Sala> Salas { get; set; }
        public virtual DbSet<Seans> Seanss { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Seans>().HasRequired(a => a.Sala).WithMany().WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}