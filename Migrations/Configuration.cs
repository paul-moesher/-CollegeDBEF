namespace CollegeDBEF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CollegeDBEF.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<CollegeDBEF.DAL.schoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CollegeDBEF.DAL.schoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //       protected override void Seed(MusicStoreDB context)
            //{
            //    context.Artists.Add(new Artist { Name = "Al Di Meola" });
            //    context.Genres.Add(new Genre { Name = "Jazz" });

            //    Genre genreRec = context.Genres.Find(1);

            //    context.Albums.Add(new Album
            //    {
            //        Artist = new Artist { Name = "Rush" },
            //        Genre = genreRec,  //new Genre { Name = "Rock" },
            //        Price = 9.99m,
            //        Title = "Caravan"
            //    });
            //    base.Seed(context);
            //}

            var departmentTypes = new List<DepartmentTypes>
            {
                new DepartmentTypes {Type = "Math" },
                new DepartmentTypes{Type = "English"},
                new DepartmentTypes{Type = "Stem" }

              //  new DepartmentType{Type = "Gym" }
            };

            departmentTypes.ForEach(s => context.DepartmentTypes.Add(s));
            context.SaveChanges();



            var scoreTypes = new List<ScoreTypes>
            {
                new ScoreTypes { Type = "Homework" },
                new ScoreTypes { Type = "Exam" },
                new ScoreTypes { Type = "Quiz" }

              //  new ScoreTypes { Type = "Test" }
            };

            scoreTypes.ForEach(s => context.ScoreTypes.Add(s));
            context.SaveChanges();


            var students = new List<Students>
            {
                //new Students{FName="Buster", LName="Nelk", SNN=111111111, Address="1 South ST", City="Norwalk", State="Ohio", Zip=44889, Phone=1112223333},
                //new Students{FName="Zion", LName="Thompson", SNN=222222222, Address="2 North ST", City="Lorain", State="Ohio", Zip=99007, Phone=111444444},
                //new Students{FName="Tom", LName="Wilson", SNN=333333333, Address="3 West ST", City="Norwalk", State="Ohio", Zip=66998, Phone=1118889999},

               new Students{FName="Bill", LName="Thomas", SNN=444444444, Address="4 North ST", City="Norwalk", State="Ohio", Zip=66998, Phone=1112229999}

            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var Classes = new List<Classes>
            {
                //new Classes{Title="MathIntro", Number=101, DepartmentTypesID =2},
                //new Classes{Title="ScienceIntro", Number=101, DepartmentTypesID =3},
                //new Classes{Title="GovermentIntro", Number=101, DepartmentTypesID =1}

               new Classes{Title="K-5 Computer", Number=101, DepartmentTypesID=3, instructor="Mr. Moesher"}
            };

            Classes.ForEach(s => context.Classes.Add(s));
            context.SaveChanges();


            var studentClasses = new List<StudentClasses>
            {
               //new StudentClasses {StudentsID = 1, ClassesID = 1 },
               //new StudentClasses {StudentsID = 1, ClassesID = 2 },
               //new StudentClasses {StudentsID = 2, ClassesID = 2 }

               new StudentClasses {StudentsID = 2, ClassesID = 3 }
            };

            studentClasses.ForEach(s => context.StudentClasses.Add(s));
            context.SaveChanges();

            var scores = new List<Scores>
            {
                //new Scores{ScoreTypesID=1, StudentClassesID = 2, Description="hw1", DateAssigned=DateTime.Parse("2019-05-01"), DateDue=DateTime.Parse("2019-05-02"), DateSubmitted=DateTime.Parse("2019-05-02"), PointsEarned=5, PointsPossible=5},
                //new Scores{ScoreTypesID=2, StudentClassesID = 1, Description="lab1", DateAssigned=DateTime.Parse("2019-05-01"), DateDue=DateTime.Parse("2019-05-01"), DateSubmitted=DateTime.Parse("2019-05-01"), PointsEarned=50, PointsPossible=55},
                //new Scores{ScoreTypesID=3, StudentClassesID = 3, Description="midterm", DateAssigned=DateTime.Parse("2019-05-05"), DateDue=DateTime.Parse("2019-05-05"), DateSubmitted=DateTime.Parse("2019-05-05"), PointsEarned=59, PointsPossible=90}

             new Scores{ScoreTypesID = 1, StudentClassesID = 1, Description = "Intro to algebra", DateAssigned = DateTime.Now,DateDue = DateTime.Now, DateSubmitted = DateTime.Now, PointsEarned = 8, PointsPossible = 10 },


            };

            scores.ForEach(s => context.Scores.Add(s));
            context.SaveChanges();


        }
    }
}
