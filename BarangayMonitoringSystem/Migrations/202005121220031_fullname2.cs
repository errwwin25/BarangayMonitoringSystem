namespace BarangayMonitoringSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fullname2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Blotterreports", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blotterreports", "FullName", c => c.String());
        }
    }
}
