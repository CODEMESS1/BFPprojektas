namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class year : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Year", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Year");
        }
    }
}
