namespace EmployeeAttendanceSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginDate = c.DateTime(nullable: false),
                        LogODate = c.DateTime(nullable: false),
                        NoHours = c.String(),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        JobPosition = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Position = c.String(),
                        Logged = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Attendances", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.Tasks", new[] { "Employee_Id" });
            DropIndex("dbo.Attendances", new[] { "Employee_Id" });
            DropTable("dbo.Tasks");
            DropTable("dbo.Employees");
            DropTable("dbo.Attendances");
        }
    }
}
