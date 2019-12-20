namespace examenNa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modeloInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        IdCliente = c.Guid(nullable: false),
                        Nombre = c.String(nullable: false),
                        ApePaterno = c.String(),
                        ApeNaterno = c.String(),
                        UsuarioCreacion = c.String(),
                        UsuarioModificacion = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechsModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdCliente);
            
            CreateTable(
                "dbo.Plan",
                c => new
                    {
                        IdPlanes = c.Int(nullable: false, identity: true),
                        IdCobertura = c.Int(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        IdCliente = c.Guid(nullable: false),
                        UsuarioCreacion = c.String(),
                        UsuarioModificacion = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechsModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdPlanes)
                .ForeignKey("dbo.Cliente", t => t.IdCliente, cascadeDelete: true)
                .Index(t => t.IdCliente);
            
            CreateTable(
                "dbo.Cobertura",
                c => new
                    {
                        IdCobertura = c.Int(nullable: false, identity: true),
                        NombreCobertura = c.String(),
                        Descripcion = c.String(),
                        IdPlan = c.Int(nullable: false),
                        UsuarioCreacion = c.String(),
                        UsuarioModificacion = c.String(),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechsModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdCobertura)
                .ForeignKey("dbo.Plan", t => t.IdPlan, cascadeDelete: true)
                .Index(t => t.IdPlan);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cobertura", "IdPlan", "dbo.Plan");
            DropForeignKey("dbo.Plan", "IdCliente", "dbo.Cliente");
            DropIndex("dbo.Cobertura", new[] { "IdPlan" });
            DropIndex("dbo.Plan", new[] { "IdCliente" });
            DropTable("dbo.Cobertura");
            DropTable("dbo.Plan");
            DropTable("dbo.Cliente");
        }
    }
}
