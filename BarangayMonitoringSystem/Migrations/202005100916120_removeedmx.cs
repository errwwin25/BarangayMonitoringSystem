namespace BarangayMonitoringSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeedmx : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blotterreports1", "Clearance_ClearanceId", "dbo.Clearances1");
            DropForeignKey("dbo.Clearances1", "ResidentRegister_ID", "dbo.ResidentRegisters");
            DropForeignKey("dbo.Blotterreports1", "ResidentRegister_ID", "dbo.ResidentRegisters");
            DropIndex("dbo.Blotterreports1", new[] { "Clearance_ClearanceId" });
            DropIndex("dbo.Blotterreports1", new[] { "ResidentRegister_ID" });
            DropIndex("dbo.Clearances1", new[] { "ResidentRegister_ID" });
            AlterColumn("dbo.Logindbs", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Logindbs", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.ResidentRegisters", "ResidentFirstName", c => c.String(nullable: false));
            AlterColumn("dbo.ResidentRegisters", "ResidentMiddleName", c => c.String(nullable: false));
            AlterColumn("dbo.ResidentRegisters", "ResidentLastName", c => c.String(nullable: false));
            AlterColumn("dbo.ResidentRegisters", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.ResidentRegisters", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.ResidentRegisters", "Religion", c => c.String(nullable: false));
            AlterColumn("dbo.ResidentRegisters", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.ResidentRegisters", "Occupation", c => c.String(nullable: false));
            AlterColumn("dbo.ResidentRegisters", "Nationality", c => c.String(nullable: false));
            AlterColumn("dbo.ResidentRegisters", "Birthdate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ResidentRegisters", "PlaceofBirth", c => c.String(nullable: false));
            DropTable("dbo.Blotterreports1");
            DropTable("dbo.Clearances1");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.ClearanceId);
            
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
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.ResidentRegisters", "PlaceofBirth", c => c.String());
            AlterColumn("dbo.ResidentRegisters", "Birthdate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.ResidentRegisters", "Nationality", c => c.String());
            AlterColumn("dbo.ResidentRegisters", "Occupation", c => c.String());
            AlterColumn("dbo.ResidentRegisters", "Status", c => c.String());
            AlterColumn("dbo.ResidentRegisters", "Religion", c => c.String());
            AlterColumn("dbo.ResidentRegisters", "Gender", c => c.String());
            AlterColumn("dbo.ResidentRegisters", "Address", c => c.String());
            AlterColumn("dbo.ResidentRegisters", "ResidentLastName", c => c.String());
            AlterColumn("dbo.ResidentRegisters", "ResidentMiddleName", c => c.String());
            AlterColumn("dbo.ResidentRegisters", "ResidentFirstName", c => c.String());
            AlterColumn("dbo.Logindbs", "Password", c => c.String());
            AlterColumn("dbo.Logindbs", "UserName", c => c.String());
            CreateIndex("dbo.Clearances1", "ResidentRegister_ID");
            CreateIndex("dbo.Blotterreports1", "ResidentRegister_ID");
            CreateIndex("dbo.Blotterreports1", "Clearance_ClearanceId");
            AddForeignKey("dbo.Blotterreports1", "ResidentRegister_ID", "dbo.ResidentRegisters", "ID");
            AddForeignKey("dbo.Clearances1", "ResidentRegister_ID", "dbo.ResidentRegisters", "ID");
            AddForeignKey("dbo.Blotterreports1", "Clearance_ClearanceId", "dbo.Clearances1", "ClearanceId");
        }
    }
}
