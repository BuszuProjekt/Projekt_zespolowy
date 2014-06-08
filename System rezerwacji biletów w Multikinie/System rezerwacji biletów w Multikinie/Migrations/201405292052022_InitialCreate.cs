namespace System_rezerwacji_biletów_w_Multikinie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tytul = c.String(),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Seans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdFilmu = c.Int(nullable: false),
                        TytułFilmu = c.String(),
                        IdSali = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Salas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IlośćMiejsc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Miejsces",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IdSali = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Miejsces");
            DropTable("dbo.Salas");
            DropTable("dbo.Seans");
            DropTable("dbo.Films");
        }
    }
}
