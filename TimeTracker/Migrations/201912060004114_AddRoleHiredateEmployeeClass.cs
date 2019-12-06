namespace TimeTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoleHiredateEmployeeClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Role", c => c.String());
            AddColumn("dbo.Employees", "HireTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "HireTime");
            DropColumn("dbo.Employees", "Role");
        }
    }
}
