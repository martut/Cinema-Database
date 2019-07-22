namespace KinoOpolwood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bilets",
                c => new
                    {
                        BiletId = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MiejsceId = c.Int(nullable: false),
                        SeansId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BiletId)
                .ForeignKey("dbo.Miejsces", t => t.MiejsceId, cascadeDelete: true)
                .ForeignKey("dbo.Seans", t => t.SeansId, cascadeDelete: true)
                .Index(t => t.MiejsceId)
                .Index(t => t.SeansId);
            
            CreateTable(
                "dbo.Miejsces",
                c => new
                    {
                        MiejsceId = c.Int(nullable: false, identity: true),
                        SalaId = c.Int(nullable: false),
                        SeatNumber = c.Int(nullable: false),
                        RowNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MiejsceId)
                .ForeignKey("dbo.Salas", t => t.SalaId, cascadeDelete: true)
                .Index(t => t.SalaId);
            
            CreateTable(
                "dbo.Salas",
                c => new
                    {
                        SalaId = c.Int(nullable: false, identity: true),
                        RoomNumber = c.Int(nullable: false),
                        NumberOfSeats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalaId);
            
            CreateTable(
                "dbo.Seans",
                c => new
                    {
                        SeansId = c.Int(nullable: false, identity: true),
                        FilmId = c.Int(nullable: false),
                        SalaId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SeansId)
                .ForeignKey("dbo.Films", t => t.FilmId, cascadeDelete: true)
                .ForeignKey("dbo.Salas", t => t.SalaId)
                .Index(t => t.FilmId)
                .Index(t => t.SalaId);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        FilmId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        LenghtTime = c.DateTime(nullable: false),
                        Director = c.String(),
                    })
                .PrimaryKey(t => t.FilmId);
            
            CreateTable(
                "dbo.Klients",
                c => new
                    {
                        KlientId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Adress = c.String(),
                    })
                .PrimaryKey(t => t.KlientId);
            
            CreateTable(
                "dbo.Rezerwacjas",
                c => new
                    {
                        RezerwacjaId = c.Int(nullable: false, identity: true),
                        MiejsceId = c.Int(nullable: false),
                        KlientId = c.Int(nullable: false),
                        SeansId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RezerwacjaId)
                .ForeignKey("dbo.Klients", t => t.KlientId, cascadeDelete: true)
                .ForeignKey("dbo.Miejsces", t => t.MiejsceId, cascadeDelete: true)
                .ForeignKey("dbo.Seans", t => t.SeansId, cascadeDelete: true)
                .Index(t => t.MiejsceId)
                .Index(t => t.KlientId)
                .Index(t => t.SeansId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rezerwacjas", "SeansId", "dbo.Seans");
            DropForeignKey("dbo.Rezerwacjas", "MiejsceId", "dbo.Miejsces");
            DropForeignKey("dbo.Rezerwacjas", "KlientId", "dbo.Klients");
            DropForeignKey("dbo.Bilets", "SeansId", "dbo.Seans");
            DropForeignKey("dbo.Seans", "SalaId", "dbo.Salas");
            DropForeignKey("dbo.Seans", "FilmId", "dbo.Films");
            DropForeignKey("dbo.Bilets", "MiejsceId", "dbo.Miejsces");
            DropForeignKey("dbo.Miejsces", "SalaId", "dbo.Salas");
            DropIndex("dbo.Rezerwacjas", new[] { "SeansId" });
            DropIndex("dbo.Rezerwacjas", new[] { "KlientId" });
            DropIndex("dbo.Rezerwacjas", new[] { "MiejsceId" });
            DropIndex("dbo.Seans", new[] { "SalaId" });
            DropIndex("dbo.Seans", new[] { "FilmId" });
            DropIndex("dbo.Miejsces", new[] { "SalaId" });
            DropIndex("dbo.Bilets", new[] { "SeansId" });
            DropIndex("dbo.Bilets", new[] { "MiejsceId" });
            DropTable("dbo.Rezerwacjas");
            DropTable("dbo.Klients");
            DropTable("dbo.Films");
            DropTable("dbo.Seans");
            DropTable("dbo.Salas");
            DropTable("dbo.Miejsces");
            DropTable("dbo.Bilets");
        }
    }
}
