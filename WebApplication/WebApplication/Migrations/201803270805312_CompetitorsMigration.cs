namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompetitorsMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
            "dbo.Competitors",
            c => new
            {
                Id = c.Int(nullable: false, identity: true),
                Name = c.String(nullable: false),
                Surname = c.String(nullable: false),
                Year = c.DateTime(nullable: false),
                Gender = c.String(nullable: false),
                City = c.String(nullable: false),
                Country = c.String(nullable: false),
                CoachId = c.String(nullable: false)
            })
            .ForeignKey("dbo.AspNetUsers", t => t.CoachId)
            .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Competitors");
        }
    }
}
