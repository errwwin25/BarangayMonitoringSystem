namespace BarangayMonitoringSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class experimentdropdown1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blotterreports", "ResidentFirstName", c => c.String());
            AlterColumn("dbo.Blotterreports", "ResidentMiddleName", c => c.String());
            AlterColumn("dbo.Blotterreports", "ResidentLastName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blotterreports", "ResidentLastName", c => c.String(nullable: false));
            AlterColumn("dbo.Blotterreports", "ResidentMiddleName", c => c.String(nullable: false));
            AlterColumn("dbo.Blotterreports", "ResidentFirstName", c => c.String(nullable: false));
        }
    }
}
