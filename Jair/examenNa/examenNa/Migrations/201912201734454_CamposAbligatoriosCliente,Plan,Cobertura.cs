namespace examenNa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CamposAbligatoriosClientePlanCobertura : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Plan", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Cobertura", "NombreCobertura", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cobertura", "NombreCobertura", c => c.String());
            AlterColumn("dbo.Plan", "Nombre", c => c.String());
        }
    }
}
