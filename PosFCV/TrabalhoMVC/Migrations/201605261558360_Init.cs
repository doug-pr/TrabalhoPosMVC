namespace TrabalhoMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidades",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        CodigoEstado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Estadoes", t => t.CodigoEstado)
                .Index(t => t.CodigoEstado);
            
            CreateTable(
                "dbo.Estadoes",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cidades", "CodigoEstado", "dbo.Estadoes");
            DropIndex("dbo.Cidades", new[] { "CodigoEstado" });
            DropTable("dbo.Estadoes");
            DropTable("dbo.Cidades");
        }
    }
}
