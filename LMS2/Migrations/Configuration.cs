namespace LMS2.Migrations
{
    using LMS2.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LMS2.Models.ApplicationDbContext>
{

    public Configuration()
    {
        AutomaticMigrationsEnabled = true;
        AutomaticMigrationDataLossAllowed = true;
    }

    protected override void Seed(ApplicationDbContext context)
    {
        var courses = new[] {
                new Course {  CourseName = ".NET Höst 2015", Description = ".NET", StartDate = DateTime.Parse("2015-10-01"), EndDate = DateTime.Parse("2015-11-30") },
                                new Course {  CourseName = ".NET Vår 2016", Description = ".NET", StartDate = DateTime.Parse("2016-04-01"),  EndDate = DateTime.Parse("2016-11-25") },
                new Course {  CourseName = ".NET Höst 2016", Description = ".NET", StartDate = DateTime.Parse("2016-10-01"),  EndDate = DateTime.Parse("2016-12-31") },
                new Course {  CourseName = ".NET Vår 2017", Description = ".NET", StartDate = DateTime.Parse("2017-04-01"),  EndDate = DateTime.Parse("2017-10-31") },
                new Course {  CourseName = ".NET Höst 2017", Description = ".NET", StartDate = DateTime.Parse("2017-10-01"),  EndDate = DateTime.Parse("2018-12-01")},
                new Course {  CourseName = ".NET Vår 2018", Description = ".NET", StartDate = DateTime.Parse("2018-04-01"),  EndDate = DateTime.Parse("2018-12-01")},
                new Course {  CourseName = "Java Höst 2017", Description = "Java", StartDate = DateTime.Parse("2017-10-01"),  EndDate = DateTime.Parse("2017-12-31") },
                new Course {  CourseName = "Java Vår 2018", Description = "Java", StartDate = DateTime.Parse("2018-04-01"),  EndDate = DateTime.Parse("2018-11-30") },
                new Course {  CourseName = "Communism", Description = "An improvement on the crumbling capitalist society", StartDate = DateTime.Parse("2017-12-04"),  EndDate = DateTime.Parse("2018-05-31")},
                new Course {  CourseName = "SheepFarming", Description = "Those wooly things", StartDate = DateTime.Parse("2018-01-28"),  EndDate = DateTime.Parse("2018-02-28")},
                new Course {  CourseName = "BerryProduction", Description = "Basically, you pick them", StartDate = DateTime.Parse("2018-01-29"),  EndDate = DateTime.Parse("2018-03-31") },

            };
        context.Courses.AddOrUpdate(
            c => new { c.CourseName, c.Description, c.StartDate, c.EndDate },
            courses
        );

        context.SaveChanges();


        var modules = new[] {
                new Module { ModuleName = "Communism1", Description = "Planned economy", StartDate = new DateTime(2017, 12, 4, 0, 0, 0), EndDate = new DateTime(2017, 12, 31, 0, 0, 0),
                    ModuleInfo = "Studies of Eastern European planned economies in the 1950s and 1960s by both American and Eastern European economists showing greater fluctuations in output than market economies during the same period",
                    CourseId = courses[8].Id},
                new Module { ModuleName = "Communism2", Description = "Modern bourgeois society", StartDate = new DateTime(2018, 1, 1, 0, 0, 0), EndDate = new DateTime(2018, 2, 28, 0, 0, 0),
                    ModuleInfo = "Modern bourgeois society with its relations of production, of exchange, and of property, a society that has conjured up such gigantic means of production and of exchange, is like the sorcerer, who is no longer able to control the powers of the nether world whom he has called up by his spells.",
                    CourseId = courses[8].Id},
                new Module { ModuleName = "Communism3", Description = "The proletariat", StartDate = new DateTime(2018, 3, 1, 0, 0, 0), EndDate = new DateTime(2018, 5, 31, 0, 0, 0),
                    ModuleInfo = "Let the ruling classes tremble at a Communistic revolution. The proletarians have nothing to lose but their chains. They have a world to win.",
                    CourseId = courses[8].Id},
                new Module { ModuleName = "SheepFarming1", Description = "Market possibilities and Strategies", StartDate = new DateTime(2018, 1, 28, 0, 0, 0), EndDate = new DateTime(2018, 2, 4, 0, 0, 0),
                    ModuleInfo = "Navigating in Moodle (our online classroom), course expectations, student introductions, sheep management systems and how they relate to marketing, your farm resources and the rest of your life.  Lambing at different times of year as well as how many times a year will be addressed.",
                    CourseId = courses[9].Id},
                new Module { ModuleName = "SheepFarming2", Description = "Matching Nutrition for Age & Stage", StartDate = new DateTime(2018, 2, 5, 0, 0, 0), EndDate = new DateTime(2018, 2, 7, 0, 0, 0),
                    ModuleInfo = "Considerations for determining feeding styles, feeders and grouping of animals, forage analysis, the value of good forages, and the management of forage handling to minimize waste while maintaining quality.  A little pasture introduction will be included as well.",
                    CourseId = courses[9].Id},
                new Module { ModuleName = "SheepFarming3", Description = "Pasture, Parasites and Predators", StartDate = new DateTime(2018, 2, 8, 0, 0, 0), EndDate = new DateTime(2018, 2, 10, 0, 0, 0),
                    ModuleInfo = "3P’s of sheep production – management tools to improve pasture quality, reduce parasite issues, and minimize predator losses.  Grazing can be an integral part of sheep farming.  Learn about rotational grazing, fencing types, guardian animals, evasive grazing to control parasites, pasture improvement, how to measure the dry matter in your pasture and where to get a grazing plan.",
                    CourseId = courses[9].Id},
                new Module { ModuleName = "SheepFarming4", Description = "Health Management", StartDate = new DateTime(2018, 2, 11, 0, 0, 0), EndDate = new DateTime(2018, 2, 14, 0, 0, 0),
                    ModuleInfo = "An ounce of prevention is worth a pound of cure.  Development of a flock health program, including planning to prevent health problems, vaccinations, foot care, biosecurity, and purchasing animals, developing a vet relationship, medicine storage, quality assurance programs.",
                    CourseId = courses[9].Id},
                new Module { ModuleName = "SheepFarming5", Description = "Financial Considerations of Sheep Farming and a quick look at Housing and Handling Systems", StartDate = new DateTime(2018, 2, 15, 0, 0, 0), EndDate = new DateTime(2018, 2, 22, 0, 0, 0),
                    ModuleInfo = "Creating a business, budgeting and financial planning for sheep farms, and decision making. Also a quick look at proper handling, basics of sheep behavior, space requirements, site selection, feeder and water placement, and housing options.",
                    CourseId = courses[9].Id},
                new Module { ModuleName = "SheepFarming6", Description = "Record Keeping, identification methods, and selection methods to meet your goals", StartDate = new DateTime(2018, 2, 23, 0, 0, 0), EndDate = new DateTime(2018, 2, 28, 0, 0, 0),
                    ModuleInfo = "Planning and record keeping, computer programs, resources to get you started and/or further develop plans for improving your sheep enterprise.",
                    CourseId = courses[9].Id},
                new Module { ModuleName = "BerryProduction1", Description = "Strawberries", StartDate = new DateTime(2018, 1, 29, 0, 0, 0), EndDate = new DateTime(2018, 2, 19, 0, 0, 0),
                    ModuleInfo = "cultural systems of strawberries; recommended varieties; pest management.",
                    CourseId = courses[10].Id},
                new Module { ModuleName = "BerryProduction2", Description = "Raspberries and Blackberries", StartDate = new DateTime(2018, 2, 20, 0, 0, 0), EndDate = new DateTime(2018, 3, 4, 0, 0, 0),
                    ModuleInfo = "cultural systems of bramble crops; recommended varieties; pest management.",
                    CourseId = courses[10].Id},
                new Module { ModuleName = "BerryProduction3", Description = "Post-harvest and marketing", StartDate = new DateTime(2018, 3, 5, 0, 0, 0), EndDate = new DateTime(2018, 3, 31, 0, 0, 0),
                    ModuleInfo = "Learn to evaluate the market potential of a site. Learn how to identify suitable irrigation sources.",
                    CourseId = courses[10].Id}
            };

        context.Modules.AddOrUpdate(
            m => new { m.ModuleName, m.Description, m.StartDate, m.EndDate, m.ModuleInfo },
            modules
        );

        context.SaveChanges();

        var activityTypes = new[] {
                new ActivityType { ActivityTypeName = "E-learning"},
                new ActivityType { ActivityTypeName = "Lecture"},
                new ActivityType { ActivityTypeName = "Exercise"},
                new ActivityType { ActivityTypeName = "Work-shop"},
                new ActivityType { ActivityTypeName = "Project"},
                new ActivityType { ActivityTypeName = "Other"},
            };

        context.ActivityTypes.AddOrUpdate(
            t => new { t.ActivityTypeName },
            activityTypes
        );

        context.SaveChanges();


        var activities = new[] {
                new Activity {
ActivityName = "Communism1:1",
Description = "Lecture: top-down administrative model",
StartDate = new DateTime(2017, 12, 4, 8, 0, 0),
EndDate = new DateTime(2017, 12, 4, 12, 0, 0),
ActivityInfo = "Leon Trotsky believed that those at the top of the chain of command, regardless of their intellectual capacity, operated without the input and participation of the millions of people who participate in the economy and understand/respond to local conditions and changes in the economy, and therefore would be unable to effectively coordinate all economic activity.",
                    ModuleId = modules[0].Id,
                    ActivityTypeId = activityTypes[1].Id},

new Activity {
ActivityName = "Communism1:2",
Description = "Work-shop: Advantages of economic planning",
StartDate = new DateTime(2017, 12, 14, 9, 0, 0),
EndDate = new DateTime(2017, 12, 17, 15, 0, 0),
ActivityInfo = "Consumer demand can be restrained in favor of greater capital investment for economic development in a desired pattern.",
                    ModuleId = modules[0].Id,
                    ActivityTypeId = activityTypes[3].Id},

new Activity {
ActivityName = "Communism1:3",
Description = "Implementation: Real life trial",
StartDate = new DateTime(2017, 12, 21, 10, 0, 0),
EndDate = new DateTime(2017, 12, 29, 16, 0, 0),
ActivityInfo = "Choose a country and...",
                    ModuleId = modules[0].Id,
                    ActivityTypeId = activityTypes[4].Id},





new Activity {
ActivityName = "Communism2:1",
Description = "Lecture: MBS introduction",
StartDate = new DateTime(2018, 1, 3, 8, 0, 0),
EndDate = new DateTime(2018, 1, 3, 11, 0, 0),
ActivityInfo = "General information about MBS",
                    ModuleId = modules[1].Id,
                    ActivityTypeId = activityTypes[1].Id},

new Activity {
ActivityName = "Communism2:2",
Description = "Project: The database of information",
StartDate = new DateTime(2018, 1, 12, 8, 0, 0),
EndDate = new DateTime(2018, 1, 17, 11, 0, 0),
ActivityInfo = "Create a database containing information about MBS",
                    ModuleId = modules[1].Id,
                    ActivityTypeId = activityTypes[4].Id},

new Activity {
ActivityName = "Communism2:3",
Description = "Lecture: Dismantling",
StartDate = new DateTime(2018, 2, 4, 8, 0, 0),
EndDate = new DateTime(2018, 2, 4, 16, 0, 0),
ActivityInfo = "The act of causing a system to stop functioning by gradually reducing its power or purpose",
                    ModuleId = modules[1].Id,
                    ActivityTypeId = activityTypes[1].Id},



new Activity {
ActivityName = "Communism3:1",
Description = "Lecture: ",
StartDate = new DateTime(2018, 3, 2, 8, 0, 0),
EndDate = new DateTime(2018, 3, 2, 13, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[2].Id,
                    ActivityTypeId = activityTypes[1].Id},

new Activity {
ActivityName = "Communism3:2",
Description = "Lecture: ",
StartDate = new DateTime(2018, 4, 2, 8, 0, 0),
EndDate = new DateTime(2018, 4, 2, 13, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[2].Id,
                    ActivityTypeId = activityTypes[1].Id},

new Activity {
ActivityName = "Communism3:3",
Description = "Lecture: ",
StartDate = new DateTime(2018, 5, 14, 8, 0, 0),
EndDate = new DateTime(2018, 5, 14, 16, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[2].Id,
                    ActivityTypeId = activityTypes[1].Id},






new Activity {
ActivityName = "SheepFarming1:1",
Description = "Lecture: ",
StartDate = new DateTime(2018, 1, 28, 8, 0, 0),
EndDate = new DateTime(2018, 1, 28, 13, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[3].Id,
                    ActivityTypeId = activityTypes[1].Id},

new Activity {
ActivityName = "SheepFarming1:2",
Description = "Lecture: ",
StartDate = new DateTime(2018, 1, 29, 8, 0, 0),
EndDate = new DateTime(2018, 1, 29, 14, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[3].Id,
                    ActivityTypeId = activityTypes[1].Id},

new Activity {
ActivityName = "SheepFarming1:3",
Description = "Lecture: ",
StartDate = new DateTime(2018, 2, 3, 8, 0, 0),
EndDate = new DateTime(2018, 2, 3, 14, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[3].Id,
                    ActivityTypeId = activityTypes[1].Id},




new Activity {
ActivityName = "SheepFarming2:1",
Description = "Lecture: ",
StartDate = new DateTime(2018, 2, 5, 8, 0, 0),
EndDate = new DateTime(2018, 2, 5, 16, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[4].Id,
                    ActivityTypeId = activityTypes[1].Id},

new Activity {
ActivityName = "SheepFarming2:2",
Description = "Lecture: ",
StartDate = new DateTime(2018, 2, 6, 8, 0, 0),
EndDate = new DateTime(2018, 2, 6, 14, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[4].Id,
                    ActivityTypeId = activityTypes[1].Id},

new Activity {
ActivityName = "SheepFarming2:3",
Description = "Lecture: ",
StartDate = new DateTime(2018, 2, 7, 8, 0, 0),
EndDate = new DateTime(2018, 2, 7, 9, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[4].Id,
                    ActivityTypeId = activityTypes[1].Id},





new Activity {
ActivityName = "SheepFarming3:1",
Description = "Lecture: ",
StartDate = new DateTime(2018, 2, 9, 8, 0, 0),
EndDate = new DateTime(2018, 2, 9, 13, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[5].Id,
                    ActivityTypeId = activityTypes[1].Id},


new Activity {
ActivityName = "SheepFarming4:1",
Description = "Lecture: ",
StartDate = new DateTime(2018, 2, 11, 8, 0, 0),
EndDate = new DateTime(2018, 2, 11, 11, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[6].Id,
                    ActivityTypeId = activityTypes[1].Id},

new Activity {
ActivityName = "SheepFarming4:2",
Description = "Lecture: ",
StartDate = new DateTime(2018, 2, 12, 8, 0, 0),
EndDate = new DateTime(2018, 2, 12, 14, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[6].Id,
                    ActivityTypeId = activityTypes[1].Id},

new Activity {
ActivityName = "SheepFarming4:3",
Description = "Lecture: ",
StartDate = new DateTime(2018, 2, 14, 8, 0, 0),
EndDate = new DateTime(2018, 2, 14, 17, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[6].Id,
                    ActivityTypeId = activityTypes[1].Id},

new Activity {
ActivityName = "SheepFarming5:1",
Description = "Lecture: ",
StartDate = new DateTime(2018, 2, 15, 8, 0, 0),
EndDate = new DateTime(2018, 2, 15, 17, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[7].Id,
                    ActivityTypeId = activityTypes[1].Id},

new Activity {
ActivityName = "SheepFarming5:2",
Description = "Lecture: ",
StartDate = new DateTime(2018, 2, 18, 8, 0, 0),
EndDate = new DateTime(2018, 2, 18, 15, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[7].Id,
                    ActivityTypeId = activityTypes[1].Id},

new Activity {
ActivityName = "SheepFarming5:3",
Description = "Lecture: ",
StartDate = new DateTime(2018, 2, 21, 8, 0, 0),
EndDate = new DateTime(2018, 2, 21, 16, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[7].Id,
                    ActivityTypeId = activityTypes[1].Id},

new Activity {
ActivityName = "SheepFarming6:1",
Description = "Lecture: ",
StartDate = new DateTime(2018, 2, 23, 8, 0, 0),
EndDate = new DateTime(2018, 2, 23, 15, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[8].Id,
                    ActivityTypeId = activityTypes[1].Id},

new Activity {
ActivityName = "SheepFarming6:2",
Description = "Lecture: ",
StartDate = new DateTime(2018, 2, 25, 8, 0, 0),
EndDate = new DateTime(2018, 2, 25, 16, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[8].Id,
                    ActivityTypeId = activityTypes[1].Id},

new Activity {
ActivityName = "SheepFarming6:3",
Description = "Lecture: ",
StartDate = new DateTime(2018, 2, 27, 8, 0, 0),
EndDate = new DateTime(2018, 2, 27, 16, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[8].Id,
                    ActivityTypeId = activityTypes[1].Id},

new Activity {
ActivityName = "BerryProduction1:1",
Description = "Lecture: ",
StartDate = new DateTime(2018, 1, 29, 8, 0, 0),
EndDate = new DateTime(2018, 1, 29, 10, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[9].Id,
                    ActivityTypeId = activityTypes[1].Id},

new Activity {
ActivityName = "BerryProduction1:2",
Description = "Lecture: ",
StartDate = new DateTime(2018, 1, 30, 8, 0, 0),
EndDate = new DateTime(2018, 1, 30, 13, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[9].Id,
                    ActivityTypeId = activityTypes[1].Id},

new Activity {
ActivityName = "BerryProduction1:3",
Description = "Lecture: ",
StartDate = new DateTime(2018, 2, 4, 8, 0, 0),
EndDate = new DateTime(2018, 2, 4, 14, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[9].Id,
                    ActivityTypeId = activityTypes[1].Id},

new Activity {
ActivityName = "BerryProduction2:1",
Description = "Lecture: ",
StartDate = new DateTime(2018, 2, 20, 8, 0, 0),
EndDate = new DateTime(2018, 2, 20, 14, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[10].Id,
                    ActivityTypeId = activityTypes[1].Id},

new Activity {
ActivityName = "BerryProduction2:2",
Description = "Lecture: ",
StartDate = new DateTime(2018, 2, 25, 8, 0, 0),
EndDate = new DateTime(2018, 2, 25, 14, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[10].Id,
                    ActivityTypeId = activityTypes[1].Id},

new Activity {
ActivityName = "BerryProduction2:3",
Description = "Lecture: ",
StartDate = new DateTime(2018, 2, 28, 8, 0, 0),
EndDate = new DateTime(2018, 2, 28, 17, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[10].Id,
                    ActivityTypeId = activityTypes[1].Id},


new Activity {
ActivityName = "BerryProduction3:1",
Description = "Lecture: ",
StartDate = new DateTime(2018, 3, 11, 8, 0, 0),
EndDate = new DateTime(2018, 3, 11, 16, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[11].Id,
                    ActivityTypeId = activityTypes[1].Id},

new Activity {
ActivityName = "BerryProduction3:2",
Description = "Lecture: ",
StartDate = new DateTime(2018, 3, 17, 8, 0, 0),
EndDate = new DateTime(2018, 3, 17, 16, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[11].Id,
                    ActivityTypeId = activityTypes[1].Id},

new Activity {
ActivityName = "BerryProduction3:3",
Description = "Lecture: ",
StartDate = new DateTime(2018, 3, 21, 8, 0, 0),
EndDate = new DateTime(2018, 3, 21, 16, 0, 0),
ActivityInfo = " ",
                    ModuleId = modules[11].Id,
                    ActivityTypeId = activityTypes[1].Id},

            };

        context.Activities.AddOrUpdate(
            a => new { a.ActivityName, a.Description, a.StartDate, a.EndDate, a.ActivityInfo },
            activities
        );


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
                new ApplicationUser {  FirstName = "Georgios", LastName = "Rastapopulous" , Email = "badguy@tintin.com", NickName = "Archvillain", UserName = "badguy@tintin.com", AdditionalInfo = "In the IT world, my goal is to become a Project Manager. I also like big cigars from Cuba.", IsActive = true, CourseId = courses.SingleOrDefault(c => c.CourseName == "SheepFarming").Id},
                new ApplicationUser {  FirstName = "Francois", LastName = "Haddock" , Email = "kapten@tintin.com", NickName = "Kapten", UserName = "kapten@tintin.com", AdditionalInfo = "Stranded seabear with a fondness for whisky - on or off sea. Especially on sea." , IsActive = true, CourseId = courses.SingleOrDefault(c => c.CourseName == "SheepFarming").Id},
                new ApplicationUser {  FirstName = "Karl", LastName = "Kalkyl", Email = "kalkyl@tintin.com", NickName = "Professorn", UserName = "kalkyl@tintin.com", AdditionalInfo = "A bit whimsical, but brialliant at times. I want to develop within .NET, and related frameworks.", IsActive = true, CourseId = courses.SingleOrDefault(c => c.CourseName == "Communism").Id},
                new ApplicationUser {  FirstName = "Johannes", LastName = "Gabrielsson", Email = "johannes@gmail.com", NickName = "The Worm", UserName = "johannes@gmail.com", AdditionalInfo = "Have mostly done javadevelopment and build published apps for the Android platform, that makes fun of Steve Jobs. The man never knew programming or understood people.",IsActive = true, CourseId = courses.SingleOrDefault(c => c.CourseName == "Communism").Id},
                new ApplicationUser {  FirstName = "Rikard", LastName = "Nyström", Email = "LittleBunny@uu.se", NickName = "Dog with rabies", UserName = "LittleBunny@uu.se", AdditionalInfo = "New at programming. Have working with computer mining, and statistics before. Dont talk ill about my mommy.",IsActive = true, CourseId = courses.SingleOrDefault(c => c.CourseName == "Communism").Id},
                new ApplicationUser {  FirstName = "William", LastName = "Smith", Email = "VilleViking@live.se", NickName = "Tjommen", UserName = "VilleViking@live.se", IsActive = true, AdditionalInfo = "Hardcore coder. On my way way on becoming a fullstackdeveloper. At any given moment, any day, you will find at least 15 2L Coca Cola in my fridge.", CourseId = courses.SingleOrDefault(c => c.CourseName == "BerryProduction").Id},
                new ApplicationUser {  FirstName = "Anna", LastName = "Holmström", Email = "Anna_Virrpanna@gmail.com", NickName = "Please help me", UserName = "Anna_Virrpanna@gmail.com", IsActive = true, AdditionalInfo = "I want learn how build beautiful websites that is also easy to navigate within. Something that appels to the senses as well as the mind, and stimulates a craving for more.", CourseId = courses.SingleOrDefault(c => c.CourseName == "BerryProduction").Id},
                new ApplicationUser {  FirstName = "Fredrik", LastName = "Nyqvist", Email = "lapinkultaMums@gmail.com", NickName = "Mamas Boy", UserName = "lapinkultaMums@gmail.com", IsActive = true, AdditionalInfo = "Interested in frontend. Have done some PHP, and javascript. Working knowledge in SQL. My big dream offline is to finish a marathon.", CourseId = courses.SingleOrDefault(c => c.CourseName == "BerryProduction").Id},
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
                new ApplicationUser {  FirstName = "Adrian", LastName = "Lozano" , Email = "zano@lexicon.se", NickName = "The Adrianator", UserName = "zano@lexicon.se", IsActive = true, AdditionalInfo = "I have done the most within programming, and have now also founded my own start-ups in - guess what? - programming. I contribute with selected lectures to the course within .NET."},
                 new ApplicationUser {  FirstName = "Dmitris", LastName = "Björlingh", Email = "dimitris@lexicon.se", NickName = "The Beard", UserName = "dimitris@lexicon.se", IsActive = true, AdditionalInfo = "Head teacher for .NET. I teach lessons. Sometimes I teach people lessons."}
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