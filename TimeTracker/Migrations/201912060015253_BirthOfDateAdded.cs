namespace TimeTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BirthOfDateAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "DateOfBirth");
        }
    }
}
