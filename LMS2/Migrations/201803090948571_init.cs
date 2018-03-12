namespace LMS2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Activities", name: "ActivityType__Id", newName: "ActivityType_Id");
            RenameIndex(table: "dbo.Activities", name: "IX_ActivityType__Id", newName: "IX_ActivityType_Id");
            AddColumn("dbo.Activities", "ActivityName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Activities", "Description", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.Activities", "ActivityType");
            DropColumn("dbo.Activities", "EndDate");
            DropColumn("dbo.Modules", "EndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Modules", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Activities", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Activities", "ActivityType", c => c.String(nullable: false));
            AlterColumn("dbo.Activities", "Description", c => c.String(maxLength: 200));
            DropColumn("dbo.Activities", "ActivityName");
            RenameIndex(table: "dbo.Activities", name: "IX_ActivityType_Id", newName: "IX_ActivityType__Id");
            RenameColumn(table: "dbo.Activities", name: "ActivityType_Id", newName: "ActivityType__Id");
        }
    }
}
