namespace BarangayMonitoringSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edmxnow2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ResidentRegisters", "Birthdate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ResidentRegisters", "Birthdate", c => c.DateTime(nullable: false));
        }
    }
}
