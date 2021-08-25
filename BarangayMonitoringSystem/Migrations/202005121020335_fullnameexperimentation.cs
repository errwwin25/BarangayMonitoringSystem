namespace BarangayMonitoringSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fullnameexperimentation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blotterreports", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blotterreports", "FullName");
        }
    }
}
