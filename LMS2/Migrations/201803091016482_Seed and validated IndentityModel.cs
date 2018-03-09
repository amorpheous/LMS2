namespace LMS2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedandvalidatedIndentityModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "NickName", c => c.String(maxLength: 20));
            AlterColumn("dbo.AspNetUsers", "AdditionalInfo", c => c.String(maxLength: 200));
            AlterColumn("dbo.AspNetUsers", "SpecialInfo", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "SpecialInfo", c => c.String());
            AlterColumn("dbo.AspNetUsers", "AdditionalInfo", c => c.String());
            AlterColumn("dbo.AspNetUsers", "NickName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String());
        }
    }
}
