namespace BarangayMonitoringSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fullnames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clearances", "Residentlastname", c => c.String());
            AddColumn("dbo.Clearances", "Residentmiddlename", c => c.String());
            AddColumn("dbo.Clearances", "Residentfirstname", c => c.String());
            AddColumn("dbo.ResidentRegisters", "Blotterreports_Blotternumber", c => c.Int());
            CreateIndex("dbo.ResidentRegisters", "Blotterreports_Blotternumber");
            AddForeignKey("dbo.ResidentRegisters", "Blotterreports_Blotternumber", "dbo.Blotterreports", "Blotternumber");
            DropColumn("dbo.Clearances", "Residentname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clearances", "Residentname", c => c.String());
            DropForeignKey("dbo.ResidentRegisters", "Blotterreports_Blotternumber", "dbo.Blotterreports");
            DropIndex("dbo.ResidentRegisters", new[] { "Blotterreports_Blotternumber" });
            DropColumn("dbo.ResidentRegisters", "Blotterreports_Blotternumber");
            DropColumn("dbo.Clearances", "Residentfirstname");
            DropColumn("dbo.Clearances", "Residentmiddlename");
            DropColumn("dbo.Clearances", "Residentlastname");
        }
    }
}
