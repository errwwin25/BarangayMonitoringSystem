namespace BarangayMonitoringSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkeyattempt3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blotterreports", "Id", "dbo.ResidentRegisters");
            DropIndex("dbo.Blotterreports", new[] { "Id" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Blotterreports", "Id");
            AddForeignKey("dbo.Blotterreports", "Id", "dbo.ResidentRegisters", "ID", cascadeDelete: true);
        }
    }
}
