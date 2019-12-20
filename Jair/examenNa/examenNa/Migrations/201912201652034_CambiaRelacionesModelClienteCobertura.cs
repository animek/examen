namespace examenNa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambiaRelacionesModelClienteCobertura : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Plan", "IdCliente", "dbo.Cliente");
            DropForeignKey("dbo.Cobertura", "IdPlan", "dbo.Plan");
            DropIndex("dbo.Plan", new[] { "IdCliente" });
            DropIndex("dbo.Cobertura", new[] { "IdPlan" });
            AddColumn("dbo.Cliente", "IdPlan", c => c.Int(nullable: false));
            CreateIndex("dbo.Cliente", "IdPlan");
            CreateIndex("dbo.Plan", "IdCobertura");
            AddForeignKey("dbo.Plan", "IdCobertura", "dbo.Cobertura", "IdCobertura", cascadeDelete: true);
            AddForeignKey("dbo.Cliente", "IdPlan", "dbo.Plan", "IdPlanes", cascadeDelete: true);
            DropColumn("dbo.Plan", "IdCliente");
            DropColumn("dbo.Cobertura", "IdPlan");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cobertura", "IdPlan", c => c.Int(nullable: false));
            AddColumn("dbo.Plan", "IdCliente", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Cliente", "IdPlan", "dbo.Plan");
            DropForeignKey("dbo.Plan", "IdCobertura", "dbo.Cobertura");
            DropIndex("dbo.Plan", new[] { "IdCobertura" });
            DropIndex("dbo.Cliente", new[] { "IdPlan" });
            DropColumn("dbo.Cliente", "IdPlan");
            CreateIndex("dbo.Cobertura", "IdPlan");
            CreateIndex("dbo.Plan", "IdCliente");
            AddForeignKey("dbo.Cobertura", "IdPlan", "dbo.Plan", "IdPlanes", cascadeDelete: true);
            AddForeignKey("dbo.Plan", "IdCliente", "dbo.Cliente", "IdCliente", cascadeDelete: true);
        }
    }
}
