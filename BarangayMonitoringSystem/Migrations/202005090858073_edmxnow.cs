namespace BarangayMonitoringSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edmxnow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blotterreports1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Blotternumber = c.Int(nullable: false),
                        ResidentFirstName = c.String(),
                        ResidentMiddleName = c.String(),
                        ResidentLastName = c.String(),
                        Incidentlocation = c.String(),
                        Incidenttype = c.String(),
                        Status = c.String(),
                        Remarks = c.String(),
                        Datereported = c.DateTime(nullable: false),
                        DateIncident = c.DateTime(nullable: false),
                        Clearance_ClearanceId = c.Int(),
                        ResidentRegister_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clearances1", t => t.Clearance_ClearanceId)
                .ForeignKey("dbo.ResidentRegisters", t => t.ResidentRegister_ID)
                .Index(t => t.Clearance_ClearanceId)
                .Index(t => t.ResidentRegister_ID);
            
            CreateTable(
                "dbo.Clearances1",
                c => new
                    {
                        ClearanceId = c.Int(nullable: false, identity: true),
                        ResidentId = c.Int(nullable: false),
                        Residentname = c.String(),
                        Cedula = c.String(),
                        BarangayId = c.String(),
                        RegisteredVoter = c.String(),
                        BGClearance = c.String(),
                        ResidentRegister_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ClearanceId)
                .ForeignKey("dbo.ResidentRegisters", t => t.ResidentRegister_ID)
                .Index(t => t.ResidentRegister_ID);
            
            AlterColumn("dbo.Logindbs", "UserName", c => c.String());
            AlterColumn("dbo.Logindbs", "Password", c => c.String());
            AlterColumn("dbo.ResidentRegisters", "ResidentFirstName", c => c.String());
            AlterColumn("dbo.ResidentRegisters", "ResidentMiddleName", c => c.String());
            AlterColumn("dbo.ResidentRegisters", "ResidentLastName", c => c.String());
            AlterColumn("dbo.ResidentRegisters", "Gender", c => c.String());
            AlterColumn("dbo.ResidentRegisters", "Address", c => c.String());
            AlterColumn("dbo.ResidentRegisters", "Religion", c => c.String());
            AlterColumn("dbo.ResidentRegisters", "Status", c => c.String());
            AlterColumn("dbo.ResidentRegisters", "Occupation", c => c.String());
            AlterColumn("dbo.ResidentRegisters", "Nationality", c => c.String());
            AlterColumn("dbo.ResidentRegisters", "PlaceofBirth", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blotterreports1", "ResidentRegister_ID", "dbo.ResidentRegisters");
            DropForeignKey("dbo.Clearances1", "ResidentRegister_ID", "dbo.ResidentRegisters");
            DropForeignKey("dbo.Blotterreports1", "Clearance_ClearanceId", "dbo.Clearances1");
            DropIndex("dbo.Clearances1", new[] { "ResidentRegister_ID" });
            DropIndex("dbo.Blotterreports1", new[] { "ResidentRegister_ID" });
            DropIndex("dbo.Blotterreports1", new[] { "Clearance_ClearanceId" });
            AlterColumn("dbo.ResidentRegisters", "PlaceofBirth", c => c.String(nullable: false));
            AlterColumn("dbo.ResidentRegisters", "Nationality", c => c.String(nullable: false));
            AlterColumn("dbo.ResidentRegisters", "Occupation", c => c.String(nullable: false));
            AlterColumn("dbo.ResidentRegisters", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.ResidentRegisters", "Religion", c => c.String(nullable: false));
            AlterColumn("dbo.ResidentRegisters", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.ResidentRegisters", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.ResidentRegisters", "ResidentLastName", c => c.String(nullable: false));
            AlterColumn("dbo.ResidentRegisters", "ResidentMiddleName", c => c.String(nullable: false));
            AlterColumn("dbo.ResidentRegisters", "ResidentFirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Logindbs", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Logindbs", "UserName", c => c.String(nullable: false));
            DropTable("dbo.Clearances1");
            DropTable("dbo.Blotterreports1");
        }
    }
}
