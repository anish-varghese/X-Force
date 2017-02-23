namespace Experion.Marina.Data.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attributes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AuditEntries",
                c => new
                    {
                        AuditEntryID = c.Int(nullable: false, identity: true),
                        EntitySetName = c.String(maxLength: 255),
                        EntityTypeName = c.String(maxLength: 255),
                        State = c.Int(nullable: false),
                        StateName = c.String(maxLength: 255),
                        CreatedBy = c.String(maxLength: 255),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AuditEntryID);
            
            CreateTable(
                "dbo.AuditEntryProperties",
                c => new
                    {
                        AuditEntryPropertyID = c.Int(nullable: false, identity: true),
                        AuditEntryID = c.Int(nullable: false),
                        RelationName = c.String(maxLength: 255),
                        PropertyName = c.String(maxLength: 255),
                        OldValue = c.String(),
                        NewValue = c.String(),
                    })
                .PrimaryKey(t => t.AuditEntryPropertyID)
                .ForeignKey("dbo.AuditEntries", t => t.AuditEntryID, cascadeDelete: true)
                .Index(t => t.AuditEntryID);
            
            CreateTable(
                "dbo.Bands",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Number = c.Long(nullable: false),
                        Name = c.String(),
                        DesignationId = c.String(),
                        DateOfJoin = c.DateTime(nullable: false),
                        BandId = c.String(),
                        Bands_Id = c.Long(),
                        Designations_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bands", t => t.Bands_Id)
                .ForeignKey("dbo.Designations", t => t.Designations_Id)
                .Index(t => t.Bands_Id)
                .Index(t => t.Designations_Id);
            
            CreateTable(
                "dbo.FilterOperators",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Operator = c.String(),
                        Attributes_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attributes", t => t.Attributes_Id)
                .Index(t => t.Attributes_Id);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilterOperators", "Attributes_Id", "dbo.Attributes");
            DropForeignKey("dbo.Employees", "Designations_Id", "dbo.Designations");
            DropForeignKey("dbo.Employees", "Bands_Id", "dbo.Bands");
            DropForeignKey("dbo.AuditEntryProperties", "AuditEntryID", "dbo.AuditEntries");
            DropIndex("dbo.FilterOperators", new[] { "Attributes_Id" });
            DropIndex("dbo.Employees", new[] { "Designations_Id" });
            DropIndex("dbo.Employees", new[] { "Bands_Id" });
            DropIndex("dbo.AuditEntryProperties", new[] { "AuditEntryID" });
            DropTable("dbo.UserLogins");
            DropTable("dbo.FilterOperators");
            DropTable("dbo.Employees");
            DropTable("dbo.Designations");
            DropTable("dbo.Bands");
            DropTable("dbo.AuditEntryProperties");
            DropTable("dbo.AuditEntries");
            DropTable("dbo.Attributes");
        }
    }
}
