namespace LMS2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Module_Id", "dbo.Modules");
            DropIndex("dbo.Modules", new[] { "Course_Id1" });
            DropIndex("dbo.Courses", new[] { "Module_Id" });
            DropColumn("dbo.Modules", "Course_Id");
            RenameColumn(table: "dbo.Modules", name: "Course_Id1", newName: "Course_Id");
            DropColumn("dbo.Courses", "Module_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Module_Id", c => c.Int());
            RenameColumn(table: "dbo.Modules", name: "Course_Id", newName: "Course_Id1");
            AddColumn("dbo.Modules", "Course_Id", c => c.Int());
            CreateIndex("dbo.Courses", "Module_Id");
            CreateIndex("dbo.Modules", "Course_Id1");
            AddForeignKey("dbo.Courses", "Module_Id", "dbo.Modules", "Id");
        }
    }
}
