namespace Experion.Marina.Data.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConvertStringToLong : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Bands_Id", "dbo.Bands");
            DropForeignKey("dbo.Employees", "Designations_Id", "dbo.Designations");
            DropIndex("dbo.Employees", new[] { "Bands_Id" });
            DropIndex("dbo.Employees", new[] { "Designations_Id" });
            DropColumn("dbo.Employees", "BandId");
            DropColumn("dbo.Employees", "DesignationId");
            RenameColumn(table: "dbo.Employees", name: "Bands_Id", newName: "BandId");
            RenameColumn(table: "dbo.Employees", name: "Designations_Id", newName: "DesignationId");
            AlterColumn("dbo.Employees", "DesignationId", c => c.Long(nullable: false));
            AlterColumn("dbo.Employees", "BandId", c => c.Long(nullable: false));
            AlterColumn("dbo.Employees", "BandId", c => c.Long(nullable: false));
            AlterColumn("dbo.Employees", "DesignationId", c => c.Long(nullable: false));
            CreateIndex("dbo.Employees", "DesignationId");
            CreateIndex("dbo.Employees", "BandId");
            AddForeignKey("dbo.Employees", "BandId", "dbo.Bands", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "DesignationId", "dbo.Designations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Employees", "BandId", "dbo.Bands");
            DropIndex("dbo.Employees", new[] { "BandId" });
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            AlterColumn("dbo.Employees", "DesignationId", c => c.Long());
            AlterColumn("dbo.Employees", "BandId", c => c.Long());
            AlterColumn("dbo.Employees", "BandId", c => c.String());
            AlterColumn("dbo.Employees", "DesignationId", c => c.String());
            RenameColumn(table: "dbo.Employees", name: "DesignationId", newName: "Designations_Id");
            RenameColumn(table: "dbo.Employees", name: "BandId", newName: "Bands_Id");
            AddColumn("dbo.Employees", "DesignationId", c => c.String());
            AddColumn("dbo.Employees", "BandId", c => c.String());
            CreateIndex("dbo.Employees", "Designations_Id");
            CreateIndex("dbo.Employees", "Bands_Id");
            AddForeignKey("dbo.Employees", "Designations_Id", "dbo.Designations", "Id");
            AddForeignKey("dbo.Employees", "Bands_Id", "dbo.Bands", "Id");
        }
    }
}
