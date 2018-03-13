namespace LMS2.Migrations
{
    using LMS2.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var courses = new[] {
                new Course {  CourseName = ".NET Höst 2015", Description = ".NET", StartDate = DateTime.Parse("2015-10-01"), DurationDays = 60 },
                new Course {  CourseName = ".NET Vår 2016", Description = ".NET", StartDate = DateTime.Parse("2016-04-01"), DurationDays = 60 },
                new Course {  CourseName = ".NET Höst 2016", Description = ".NET", StartDate = DateTime.Parse("2016-10-01"), DurationDays = 60 },
                new Course {  CourseName = ".NET Vår 2017", Description = ".NET", StartDate = DateTime.Parse("2017-04-01"), DurationDays = 60 },
                new Course {  CourseName = ".NET Höst 2017", Description = ".NET", StartDate = DateTime.Parse("2017-10-01"), DurationDays = 60 },
                new Course {  CourseName = ".NET Vår 2018", Description = ".NET", StartDate = DateTime.Parse("2018-04-01"), DurationDays = 60 },
                new Course {  CourseName = "Java Höst 2017", Description = "Java", StartDate = DateTime.Parse("2017-10-01"), DurationDays = 60 },
                new Course {  CourseName = "Java Vår 2018", Description = "Java", StartDate = DateTime.Parse("2018-04-01"), DurationDays = 60 },
                new Course {  CourseName = "Communism", Description = "An improvement on the crumbling capitalist society", StartDate = DateTime.Parse("2017-12-04"), DurationDays = 70 },
                new Course {  CourseName = "SheepFarming", Description = "Those wooly things", StartDate = DateTime.Parse("2018-01-28"), DurationDays = 91 },
                new Course {  CourseName = "BerryProduction", Description = "Basically, you pick them", StartDate = DateTime.Parse("2018-01-29"), DurationDays = 35 },
            };
            context.Courses.AddOrUpdate(
                c => new { c.CourseName, c.Description, c.StartDate, c.DurationDays },
                courses
            );

            context.SaveChanges();

//            var modules = new[] {
//                new Module { ModuleName = "Communism1", Description = "Planned economy", StartDate = new DateTime(2017, 12, 04, 0, 0, 0), DurationDays = 28,
//                    ModuleInfo = "Studies of Eastern European planned economies in the 1950s and 1960s by both American and Eastern European economists showing greater fluctuations in output than market economies during the same period",},
//                new Module { ModuleName = "Communism2", Description = "Modern bourgeois society", StartDate = new DateTime(2018, 01, 01, 0, 0, 0), DurationDays = 28,
//                    ModuleInfo = "Modern bourgeois society with its relations of production, of exchange, and of property, a society that has conjured up such gigantic means of production and of exchange, is like the sorcerer, who is no longer able to control the powers of the nether world whom he has called up by his spells."},
//                new Module { ModuleName = "Communism3", Description = "The proletariat", StartDate = new DateTime(2018, 01, 28, 0, 0, 0), DurationDays = 14,
//                    ModuleInfo = "Let the ruling classes tremble at a Communistic revolution. The proletarians have nothing to lose but their chains. They have a world to win."},
//                new Module { ModuleName = "SheepFarming1", Description = "Market possibilities and Strategies", StartDate = new DateTime(2018, 01, 28, 0, 0, 0), DurationDays = 14,
//                    ModuleInfo = "Navigating in Moodle (our online classroom), course expectations, student introductions, sheep management systems and how they relate to marketing, your farm resources and the rest of your life.  Lambing at different times of year as well as how many times a year will be addressed."},
//                new Module { ModuleName = "SheepFarming2", Description = "Matching Nutrition for Age & Stage", StartDate = new DateTime(2018, 01, 01, 0, 0, 0), DurationDays = 28,
//                    ModuleInfo = "Considerations for determining feeding styles, feeders and grouping of animals, forage analysis, the value of good forages, and the management of forage handling to minimize waste while maintaining quality.  A little pasture introduction will be included as well."},
//                new Module { ModuleName = "SheepFarming3", Description = "Pasture, Parasites and Predators", StartDate = new DateTime(2018, 01, 28, 0, 0, 0), DurationDays = 14,
//                    ModuleInfo = "3P’s of sheep production – management tools to improve pasture quality, reduce parasite issues, and minimize predator losses.  Grazing can be an integral part of sheep farming.  Learn about rotational grazing, fencing types, guardian animals, evasive grazing to control parasites, pasture improvement, how to measure the dry matter in your pasture and where to get a grazing plan."},
//                new Module { ModuleName = "SheepFarming4", Description = "Health Management", StartDate = new DateTime(2018, 01, 29, 0, 0, 0), DurationDays = 7,
//                    ModuleInfo = "An ounce of prevention is worth a pound of cure.  Development of a flock health program, including planning to prevent health problems, vaccinations, foot care, biosecurity, and purchasing animals, developing a vet relationship, medicine storage, quality assurance programs."},
//                new Module { ModuleName = "SheepFarming5", Description = "Financial Considerations of Sheep Farming and a quick look at Housing and Handling Systems", StartDate = new DateTime(2018, 02, 05, 0, 0, 0), DurationDays = 14,
//                    ModuleInfo = "Creating a business, budgeting and financial planning for sheep farms, and decision making. Also a quick look at proper handling, basics of sheep behavior, space requirements, site selection, feeder and water placement, and housing options."},
//                new Module { ModuleName = "SheepFarming6", Description = "Record Keeping, identification methods, and selection methods to meet your goals", StartDate = new DateTime(2018, 02, 19, 0, 0, 0), DurationDays = 14,
//                    ModuleInfo = "Planning and record keeping, computer programs, resources to get you started and/or further develop plans for improving your sheep enterprise."},
//                new Module { ModuleName = "BerryProduction1", Description = "Strawberries", StartDate = new DateTime(2018, 01, 29, 0, 0, 0), DurationDays = 7,
//                    ModuleInfo = "cultural systems of strawberries; recommended varieties; pest management."},
//                new Module { ModuleName = "BerryProduction2", Description = "Raspberries and Blackberries", StartDate = new DateTime(2018, 02, 05, 0, 0, 0), DurationDays = 14,
//                    ModuleInfo = "cultural systems of bramble crops; recommended varieties; pest management."},
//                new Module { ModuleName = "BerryProduction3", Description = "Post-harvest and marketing", StartDate = new DateTime(2018, 02, 19, 0, 0, 0), DurationDays = 14,
//                    ModuleInfo = "Learn to evaluate the market potential of a site. Learn how to identify suitable irrigation sources."}
//            };

//            context.Modules.AddOrUpdate(
//                m => new { m.ModuleName, m.Description, m.StartDate, m.DurationDays, m.ModuleInfo },
//                modules
//            );

//            context.SaveChanges();

//            var activities = new[] {
//                new Activity {
//ActivityName = "Communism1:1",
//Description = "Lecture: top-down administrative model",
//StartDate = new DateTime(2017, 12, 04, 8, 0, 0),
//DurationDays = 1,
//ActivityInfo = "Leon Trotsky believed that those at the top of the chain of command, regardless of their intellectual capacity, operated without the input and participation of the millions of people who participate in the economy and understand/respond to local conditions and changes in the economy, and therefore would be unable to effectively coordinate all economic activity."},

//new Activity {
//ActivityName = "Communism1:2",
//Description = "Work-shop: Advantages of economic planning",
//StartDate = new DateTime(2017, 12, 04, 13, 0, 0),
//DurationDays = 1.66,
//ActivityInfo = "Consumer demand can be restrained in favor of greater capital investment for economic development in a desired pattern."},

//new Activity {
//ActivityName = "Communism1:3",
//Description = "Implementation: Real life trial",
//StartDate = new DateTime(2017, 12, 04, 8, 0, 0),
//DurationDays = 27-15/24,
//ActivityInfo = "Choose a country and..."},





//new Activity {
//ActivityName = "Communism2:1",
//Description = "Lecture: MBS introduction",
//StartDate = new DateTime(2018, 01, 01, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = "General information about MBS"},

//new Activity {
//ActivityName = "Communism2:2",
//Description = "Project: The database of information",
//StartDate = new DateTime(2018, 01, 02, 8, 0, 0),
//DurationDays = (1/6),
//ActivityInfo = "Create a database containing information about MBS"},

//new Activity {
//ActivityName = "Communism2:3",
//Description = "Lecture: Dismantling",
//StartDate = new DateTime(2018, 01, 08, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = "The act of causing a system to stop functioning by gradually reducing its power or purpose"},



//new Activity {
//ActivityName = "Communism3:1",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 01, 29, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},

//new Activity {
//ActivityName = "Communism3:2",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 01, 30, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},

//new Activity {
//ActivityName = "Communism3:3",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 01, 31, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},






//new Activity {
//ActivityName = "SheepFarming1:1",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 01, 28, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},

//new Activity {
//ActivityName = "SheepFarming1:2",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 01, 29, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},

//new Activity {
//ActivityName = "SheepFarming1:3",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 01, 30, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},




//new Activity {
//ActivityName = "SheepFarming2:1",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 01, 01, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},

//new Activity {
//ActivityName = "SheepFarming2:2",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 01, 02, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},

//new Activity {
//ActivityName = "SheepFarming2:3",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 01, 03, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},





//new Activity {
//ActivityName = "SheepFarming3:1",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 01, 28, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},


//new Activity {
//ActivityName = "SheepFarming4:1",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 01, 29, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},

//new Activity {
//ActivityName = "SheepFarming4:2",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 01, 30, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},

//new Activity {
//ActivityName = "SheepFarming4:3",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 01, 31, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},

//new Activity {
//ActivityName = "SheepFarming5:1",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 02, 05, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},

//new Activity {
//ActivityName = "SheepFarming5:2",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 02, 06, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},

//new Activity {
//ActivityName = "SheepFarming5:3",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 02, 07, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},

//new Activity {
//ActivityName = "SheepFarming6:1",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 02, 19, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},

//new Activity {
//ActivityName = "SheepFarming6:2",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 02, 20, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},

//new Activity {
//ActivityName = "SheepFarming6:3",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 02, 21, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},

//new Activity {
//ActivityName = "SheepFarming6:1",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 02, 19, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},

//new Activity {
//ActivityName = "SheepFarming6:2",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 02, 20, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},

//new Activity {
//ActivityName = "SheepFarming6:3",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 02, 21, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},

//new Activity {
//ActivityName = "BerryProduction2:1",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 02, 05, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},

//new Activity {
//ActivityName = "BerryProduction2:2",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 02, 06, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},

//new Activity {
//ActivityName = "BerryProduction2:3",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 02, 06, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},


//new Activity {
//ActivityName = "BerryProduction3:1",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 02, 19, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},

//new Activity {
//ActivityName = "BerryProduction3:2",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 02, 20, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},

//new Activity {
//ActivityName = "BerryProduction3:3",
//Description = "Lecture: ",
//StartDate = new DateTime(2018, 02, 21, 8, 0, 0),
//DurationDays = (2/6+1/24),
//ActivityInfo = " "},

//            };

//            context.Activities.AddOrUpdate(
//                a => new { a.ActivityName, a.Description, a.StartDate, a.DurationDays, a.ActivityInfo },
//                activities
//            );


            //Systemet skall hantera två, och endast två, roller - teacher och student
            //Först skapas en Rolestore för att förvara de två rollerna
            var roleStore = new RoleStore<IdentityRole>(context);

            //Sedan skapas en rolemanager för att kunna tilldela Teacher respektive Student behörigheter
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var roleNames = new[] { Roles.Teacher, Roles.Student };
            foreach (var roleName in roleNames)
            {
                if (context.Roles.Any(r => r.Name == roleName)) continue;

                // Create role
                var role = new IdentityRole { Name = roleName };
                var result = roleManager.Create(role);
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join("\n", result.Errors));
                }
            }

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var originalUsers = new[] {
                new ApplicationUser {  FirstName = "Georgios", LastName = "Rastapopulous" , Email = "badguy@tintin.com", NickName = "Archvillain", UserName = "badguy@tintin.com", IsActive = true},
                new ApplicationUser {  FirstName = "Francois", LastName = "Haddock" , Email = "kapten@tintin.com", NickName = "Kapten", UserName = "kapten@tintin.com", IsActive = true},
                new ApplicationUser {  FirstName = "Karl", LastName = "Kalkyl", Email = "kalkyl@tintin.com", NickName = "Professorn", UserName = "kalkyl@tintin.com", IsActive = true},
                new ApplicationUser {  FirstName = "Johannes", LastName = "Gabrielsson", Email = "johannes@gmail.com", NickName = "The Worm", UserName = "johannes@gmail.com", IsActive = true},
                new ApplicationUser {  FirstName = "Rikard", LastName = "Nyström", Email = "LittleBunny@uu.se", NickName = "Dog with rabies", UserName = "LittleBunny@uu.se", IsActive = true},
                new ApplicationUser {  FirstName = "William", LastName = "Smith", Email = "VilleViking@live.se", NickName = "Tjommen", UserName = "VilleViking@live.se", IsActive = true},
                new ApplicationUser {  FirstName = "Anna", LastName = "Holmström", Email = "Anna_Virrpanna@gmail.com", NickName = "Please help me", UserName = "Anna_Virrpanna@gmail.com", IsActive = true},
                new ApplicationUser {  FirstName = "Fredrik", LastName = "Nyqvist", Email = "lapinkultaMums@gmail.com", NickName = "Mamas Boy", UserName = "lapinkultaMums@gmail.com", IsActive = true},
            };



            for (int i = 0; i < originalUsers.Length; i++)
            {
                var userName = originalUsers[i].UserName;
                if (context.Users.Any(u => u.UserName == userName)) continue;
                // Create user där alla har samma lösenord          
                var result = userManager.Create(originalUsers[i], "student");
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join("\n", result.Errors));
                }
                userManager.AddToRole(originalUsers[i].Id, Roles.Student);
            }


            var originalTeachers = new[] {
                new ApplicationUser {  FirstName = "Adrian", LastName = "Lozano" , Email = "zano@lexicon.se", NickName = "Wannabe", UserName = "zano@lexicon.se", IsActive = true},
                 new ApplicationUser {  FirstName = "Dmitris", LastName = "Björlingh", Email = "dimitris@lexicon.se", NickName = "The Beard", UserName = "dimitris@lexicon.se", IsActive = true}
                            };


            for (int i = 0; i < originalTeachers.Length; i++)
            {
                var userName = originalTeachers[i].UserName;
                if (context.Users.Any(u => u.UserName == userName)) continue;
                // Create user där alla har samma lösenord          
                var result = userManager.Create(originalTeachers[i], "teacher");
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join("\n", result.Errors));
                }
                userManager.AddToRole(originalTeachers[i].Id, Roles.Teacher);
            }




        }
    }
}

