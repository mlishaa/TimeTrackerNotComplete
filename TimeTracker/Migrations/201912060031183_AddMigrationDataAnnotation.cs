namespace TimeTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigrationDataAnnotation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "DOB", c => c.DateTime());
            AddColumn("dbo.Employees", "Salary", c => c.Double(nullable: false));
            AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Employees", "lastName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "lastName", c => c.String());
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
            DropColumn("dbo.Employees", "Salary");
            DropColumn("dbo.Employees", "DOB");
        }
    }
}
