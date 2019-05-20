namespace CollegeDBEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RUN1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Number = c.Int(nullable: false),
                        DepartmentTypesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DepartmentTypes", t => t.DepartmentTypesID, cascadeDelete: true)
                .Index(t => t.DepartmentTypesID);
            
            CreateTable(
                "dbo.DepartmentTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ScoreTypesID = c.Int(nullable: false),
                        StudentClassesID = c.Int(nullable: false),
                        Description = c.String(),
                        DateAssigned = c.DateTime(nullable: false),
                        DateDue = c.DateTime(nullable: false),
                        DateSubmitted = c.DateTime(nullable: false),
                        PointsEarned = c.Int(nullable: false),
                        PointsPossible = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ScoreTypes", t => t.ScoreTypesID, cascadeDelete: true)
                .ForeignKey("dbo.StudentClasses", t => t.StudentClassesID, cascadeDelete: true)
                .Index(t => t.ScoreTypesID)
                .Index(t => t.StudentClassesID);
            
            CreateTable(
                "dbo.ScoreTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StudentClasses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClassesID = c.Int(nullable: false),
                        StudentsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Classes", t => t.ClassesID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentsID, cascadeDelete: true)
                .Index(t => t.ClassesID)
                .Index(t => t.StudentsID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        LName = c.String(),
                        SNN = c.Int(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                        Phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scores", "StudentClassesID", "dbo.StudentClasses");
            DropForeignKey("dbo.StudentClasses", "StudentsID", "dbo.Students");
            DropForeignKey("dbo.StudentClasses", "ClassesID", "dbo.Classes");
            DropForeignKey("dbo.Scores", "ScoreTypesID", "dbo.ScoreTypes");
            DropForeignKey("dbo.Classes", "DepartmentTypesID", "dbo.DepartmentTypes");
            DropIndex("dbo.StudentClasses", new[] { "StudentsID" });
            DropIndex("dbo.StudentClasses", new[] { "ClassesID" });
            DropIndex("dbo.Scores", new[] { "StudentClassesID" });
            DropIndex("dbo.Scores", new[] { "ScoreTypesID" });
            DropIndex("dbo.Classes", new[] { "DepartmentTypesID" });
            DropTable("dbo.Students");
            DropTable("dbo.StudentClasses");
            DropTable("dbo.ScoreTypes");
            DropTable("dbo.Scores");
            DropTable("dbo.DepartmentTypes");
            DropTable("dbo.Classes");
        }
    }
}
