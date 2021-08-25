namespace BarangayMonitoringSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class experimentdropdown : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ResidentRegisters", "Residents_ID", c => c.Int());
            CreateIndex("dbo.ResidentRegisters", "Residents_ID");
            AddForeignKey("dbo.ResidentRegisters", "Residents_ID", "dbo.ResidentRegisters", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResidentRegisters", "Residents_ID", "dbo.ResidentRegisters");
            DropIndex("dbo.ResidentRegisters", new[] { "Residents_ID" });
            DropColumn("dbo.ResidentRegisters", "Residents_ID");
        }
    }
}
