namespace TimeTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        lastName = c.String(),
                        Department = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TimeCards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SubmissionDate = c.DateTime(nullable: false),
                        MondayHours = c.Int(nullable: false),
                        TuesdayHours = c.Int(nullable: false),
                        WedesdayHours = c.Int(nullable: false),
                        ThursdayHours = c.Int(nullable: false),
                        FridayHours = c.Int(nullable: false),
                        SaturdayHours = c.Int(nullable: false),
                        SundayHours = c.Int(nullable: false),
                        Employee_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.Employee_ID)
                .Index(t => t.Employee_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeCards", "Employee_ID", "dbo.Employees");
            DropIndex("dbo.TimeCards", new[] { "Employee_ID" });
            DropTable("dbo.TimeCards");
            DropTable("dbo.Employees");
        }
    }
}
