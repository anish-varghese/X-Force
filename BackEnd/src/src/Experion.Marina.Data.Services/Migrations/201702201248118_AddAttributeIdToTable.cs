namespace Experion.Marina.Data.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttributeIdToTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FilterOperators", "Attributes_Id", "dbo.Attributes");
            DropIndex("dbo.FilterOperators", new[] { "Attributes_Id" });
            RenameColumn(table: "dbo.FilterOperators", name: "Attributes_Id", newName: "AttributesId");
            AlterColumn("dbo.FilterOperators", "AttributesId", c => c.Long(nullable: false));
            CreateIndex("dbo.FilterOperators", "AttributesId");
            AddForeignKey("dbo.FilterOperators", "AttributesId", "dbo.Attributes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilterOperators", "AttributesId", "dbo.Attributes");
            DropIndex("dbo.FilterOperators", new[] { "AttributesId" });
            AlterColumn("dbo.FilterOperators", "AttributesId", c => c.Long());
            RenameColumn(table: "dbo.FilterOperators", name: "AttributesId", newName: "Attributes_Id");
            CreateIndex("dbo.FilterOperators", "Attributes_Id");
            AddForeignKey("dbo.FilterOperators", "Attributes_Id", "dbo.Attributes", "Id");
        }
    }
}
