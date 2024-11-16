namespace FusionTech.src.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<StoreEmployee> StoreEmployees { get; set; }
        public DbSet<SystemAdmin> SystemAdmins { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderedGames> OrderedGames { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Supply> Supply { get; set; }
        public DbSet<PersonIdCounter> PersonIdCounters { get; set; }
        public DbSet<GameConsole> Console { get; set; }
        public DbSet<GameStudio> Studio { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<VideoGameVersion> VideoGameVersion { get; set; }
        public DbSet<VideoGameInfo> VideoGameInfo { get; set; }

        public DatabaseContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasIndex(p => p.PersonEmail).IsUnique();

            modelBuilder.Entity<Person>().HasIndex(p => p.PersonPhoneNumber).IsUnique();

            modelBuilder.Entity<Inventory>().HasKey(i => new { i.StoreId, i.VideoGameVersionId });

            modelBuilder.Entity<Person>().UseTptMappingStrategy();
            modelBuilder.HasPostgresEnum<PersonType>();

            // Seed Super Admin
            // this is an extremly sensitive information, it should be removed in a real world scenario.
            PasswordUtils.HashPassword("SuperAdmin", out string hashedPassword, out byte[] salt);

            var SystemAdmin1 = new SystemAdmin
            {
                PersonId = 1,
                PersonEmail = "Zayed1@mail.com",
                PersonName = "Zayd Al-Nasser",
                PersonPassword = hashedPassword,
                PersonPhoneNumber = "+966503010080",
                salt = salt,
                ManageGames = true,
                ManageCustomers = true,
                ManageEmployees = true,
                ManageStores = true,
                ManageSystemAdmins = true,
                ProfilePicturePath = "",
            };
            PasswordUtils.HashPassword(
                "SuperAdmin",
                out string hashedPassword10,
                out byte[] salt10
            );

            var SystemAdmin2 = new SystemAdmin
            {
                PersonId = 2,
                PersonEmail = "Tariq2@mail.com",
                PersonName = "Tariq Hassan",
                PersonPassword = hashedPassword10,
                PersonPhoneNumber = "+966503011180",
                salt = salt10,
                ManageGames = true,
                ManageCustomers = true,
                ManageEmployees = false,
                ManageStores = false,
                ManageSystemAdmins = false,
                ProfilePicturePath = "",
            };
            PasswordUtils.HashPassword(
                "SuperAdmin",
                out string hashedPassword11,
                out byte[] salt11
            );

            var SystemAdmin3 = new SystemAdmin
            {
                PersonId = 3,
                PersonEmail = "Sara3@mail.com",
                PersonName = "Sara Al-Hassan",
                PersonPassword = hashedPassword11,
                PersonPhoneNumber = "+966503017840",
                salt = salt11,
                ManageGames = false,
                ManageCustomers = false,
                ManageEmployees = true,
                ManageStores = true,
                ManageSystemAdmins = false,
                ProfilePicturePath = "",
            };

            // Seed Category data
            var Category1 = new Category
            {
                CategoryId = Guid.Parse("2e32f726-203b-4fa3-a960-3a2c1a275864"),
                CategoryName = "Action",
            };
            var Category2 = new Category
            {
                CategoryId = Guid.Parse("4867a76e-ccc5-4470-a25a-dd1e91cbc87d"),
                CategoryName = "Adventure",
            };
            var Category3 = new Category
            {
                CategoryId = Guid.Parse("0b387646-e3f1-4892-857c-b260a7113ca4"),
                CategoryName = "Racing",
            };
            var Category4 = new Category
            {
                CategoryId = Guid.Parse("fe93817b-e277-476d-a27f-7450a0fe72b2"),
                CategoryName = "simulation",
            };

            // Seed GameConsole data
            var Console1 = new GameConsole
            {
                GameConsoleId = Guid.Parse("0268a1b4-571e-4962-90be-471f315c0497"),
                ConsoleName = "GamerBox",
            };
            var Console2 = new GameConsole
            {
                GameConsoleId = Guid.Parse("36be9397-03a5-4dff-a2f2-1f7061faff98"),
                ConsoleName = "FusionPlay",
            };
            var Console3 = new GameConsole
            {
                GameConsoleId = Guid.Parse("41c5f56f-7ebe-4f73-8298-04b3171e56a0"),
                ConsoleName = "RetroCube",
            };
            var Console4 = new GameConsole
            {
                GameConsoleId = Guid.Parse("2d952229-3668-48f3-88f5-4ddd9779524c"),
                ConsoleName = "PC",
            };
            var Console5 = new GameConsole
            {
                GameConsoleId = Guid.Parse("d31bda97-60bc-4cee-b564-daad86ad2ca6"),
                ConsoleName = "Playstation",
            };

            // Seed GameStudio data
            var studioGuidHelper = "646e4c3c-bfc2-41dc-9f49-14b7905516b8";
            var Studio1 = new GameStudio
            {
                GameStudioId = Guid.Parse(studioGuidHelper),
                StudioName = "Deck Nine Games",
                StudioPicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Studios/{studioGuidHelper}/{studioGuidHelper}.png",
            };

            studioGuidHelper = "8720de28-1bf5-49ad-b272-ddfee747f22c";
            var Studio2 = new GameStudio
            {
                GameStudioId = Guid.Parse(studioGuidHelper),
                StudioName = "Telltale Games",
                StudioPicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Studios/{studioGuidHelper}/{studioGuidHelper}.jpg",
            };

            studioGuidHelper = "0b4ad2e6-b78c-47a8-bf70-fb667cb7a138";
            var Studio3 = new GameStudio
            {
                GameStudioId = Guid.Parse(studioGuidHelper),
                StudioName = "Feral Interactive",
                StudioPicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Studios/{studioGuidHelper}/{studioGuidHelper}.png",
            };

            studioGuidHelper = "bbd8f143-d7e1-41ef-9702-9bfb27567b80";
            var Studio4 = new GameStudio
            {
                GameStudioId = Guid.Parse(studioGuidHelper),
                StudioName = "Codemaster",
                StudioPicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Studios/{studioGuidHelper}/{studioGuidHelper}.png",
            };

            studioGuidHelper = "86b47e62-089e-4f3e-b9c4-f29ea6720fd0";
            var Studio5 = new GameStudio
            {
                GameStudioId = Guid.Parse(studioGuidHelper),
                StudioName = "Crystal Dynamics",
                StudioPicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Studios/{studioGuidHelper}/{studioGuidHelper}.png",
            };

            studioGuidHelper = "bfe21050-cd59-4feb-ab5e-459031e4b3f3";
            var Studio6 = new GameStudio
            {
                GameStudioId = Guid.Parse(studioGuidHelper),
                StudioName = "Avalanche Studios",
                StudioPicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Studios/{studioGuidHelper}/{studioGuidHelper}.png",
            };

            studioGuidHelper = "5502bbf3-535e-4042-85b8-052b35594542";
            var Studio7 = new GameStudio
            {
                GameStudioId = Guid.Parse(studioGuidHelper),
                StudioName = "IO Interactive",
                StudioPicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Studios/{studioGuidHelper}/{studioGuidHelper}.jpg",
            };

            studioGuidHelper = "cf04439e-6b5d-406f-b2e1-a5616a3aee8a";
            var Studio8 = new GameStudio
            {
                GameStudioId = Guid.Parse(studioGuidHelper),
                StudioName = "Skybound Entertainment",
                StudioPicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Studios/{studioGuidHelper}/{studioGuidHelper}.png",
            };

            studioGuidHelper = "727cffb5-6ba3-4a56-a1eb-fe1962c8f044";
            var Studio9 = new GameStudio
            {
                GameStudioId = Guid.Parse(studioGuidHelper),
                StudioName = "Liquid Entertainment",
                StudioPicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Studios/{studioGuidHelper}/{studioGuidHelper}.jpg",
            };

            studioGuidHelper = "9fc928ce-aa2a-4e7b-816d-b3468ea552ed";
            var Studio10 = new GameStudio
            {
                GameStudioId = Guid.Parse(studioGuidHelper),
                StudioName = "Blue Omega Entertainment",
                StudioPicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Studios/{studioGuidHelper}/{studioGuidHelper}.jpg",
            };

            var publisherGuidHelper = "12ba59b8-6c30-4864-9d48-0f95bd278b40";
            var Publisher1 = new Publisher
            {
                PublisherId = Guid.Parse(publisherGuidHelper), //action
                PublisherName = "Square Enix",
                PublisherEmail = "creators@us.square-enix.com",
                PublisherPicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Publishers/{publisherGuidHelper}/{publisherGuidHelper}.jpg",
            };
            publisherGuidHelper = "f5ea9a66-8a49-4f1f-ae5d-09ce38a7c80d";
            var Publisher2 = new Publisher
            {
                PublisherId = Guid.Parse(publisherGuidHelper),
                PublisherName = "Telltale Games",
                PublisherEmail = " support@telltalegames.com", // adventure and action
                PublisherPicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Publishers/{publisherGuidHelper}/{publisherGuidHelper}.jpg",
            };
            publisherGuidHelper = "df5d8791-98b3-445d-8120-07b33695da10";
            var Publisher3 = new Publisher
            {
                PublisherId = Guid.Parse(publisherGuidHelper),
                PublisherName = "Codemasters",
                PublisherEmail = " help@codemasters.com", //race
                PublisherPicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Publishers/{publisherGuidHelper}/{publisherGuidHelper}.png",
            };

            var videoGamesInfoGuidHelper = "7248c5a6-49e0-4f88-be50-8d87a54c938f";
            var VideoGameInfo1 = new VideoGameInfo
            {
                VideoGameInfoId = Guid.Parse(videoGamesInfoGuidHelper),
                GameName = "Life is Strange: Double Exposure",
                Description =
                    "Max Caulfield, photographer-in-residence at the prestigious Caledon University, discovers her closest new friend, Safi, dead in the snow. Murdered. To save her, Max tries to Rewind time - a power she’s not used in years... instead, Max opens the way to a parallel timeline where Safi is still alive, and still in danger! Max realizes the killer will soon strike again - in both versions of reality. With her new power to Shift between two timelines - can Max solve and prevent the same murder?",
                YearOfRelease = "Oct 29, 2024",
                TotalRating = 3,
                PublisherId = Publisher1.PublisherId,
                GamePicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Games/{videoGamesInfoGuidHelper}/{videoGamesInfoGuidHelper}.jpg",
            };

            videoGamesInfoGuidHelper = "ee4836d4-d131-47fe-b741-3c104f14df71";
            var VideoGameInfo2 = new VideoGameInfo
            {
                VideoGameInfoId = Guid.Parse(videoGamesInfoGuidHelper),
                GameName = "The Wolf Among Us",
                Description =
                    "The Wolf Among Us is a five-part episodic game relying heavily on dialogues and choices of the player. The game is considered a prequel to Bill Willingham's 'Fables' comic book and features usual TellTale stylistics: cartoon-like graphics, comparing your choices to the decisions of the other players and QTEs. 'The Wolf' is the first part of the series with a promised expansion to the second season coming out in 2019.You play as Bigby Wolf; he is a Sheriff of a Fabletown: as a typical Sheriff, you need to fulfill the requests of the Fabletown's residents and uncover mysteries lying behind the crimes there. The gameplay consists of choosing the dialogue options, reacting to QTE button-mash and watching cutscenes.",
                YearOfRelease = "Oct 10, 2013",
                TotalRating = 5,
                PublisherId = Publisher2.PublisherId,
                GamePicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Games/{videoGamesInfoGuidHelper}/{videoGamesInfoGuidHelper}.jpg",
            };

            videoGamesInfoGuidHelper = "d6cd4ffd-62d1-41e6-b6b4-5a05babb8d45";
            var VideoGameInfo3 = new VideoGameInfo
            {
                VideoGameInfoId = Guid.Parse(videoGamesInfoGuidHelper),
                GameName = "Rise of the Tomb Raider",
                Description =
                    "Rise of the Tomb Raider is the eleventh entry in the franchise, being a sequel to its predecessor, Tomb Raider, a reboot of the franchise. This story follows Lara Croft, one year after battling her supernatural experiences in Yamatai. This time she is trying to find the legendary city of Kitezh in Siberia, Russia. The legend behind the city begins in the 12th century and still comes nowadays, that this ancient city grants with a promise of immortality. While Lara tries to solve the mystery of Siberia, she encounters an organisation called Trinity. They want to retrieve this gift to themselves. Following the notes of her father, Lara tries to discover the secrets of the ancient city and stop Trinity in doing so.Exploring the Soviet motive,even more,the game has the DLC's - Baba Yaga, the Temple of the Witch, which follows Lara in the Soviet mine and confronting the legendary witch of Russian folk-tales, Cold Darkness Awakened, the story about a secret biological weapon and Blood Ties and Lara's Nightmare - a fight for ownership of the Croft estate.",
                YearOfRelease = "Nov 10, 2015",
                TotalRating = 5,
                PublisherId = Publisher1.PublisherId,
                GamePicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Games/{videoGamesInfoGuidHelper}/{videoGamesInfoGuidHelper}.jpg",
            };

            videoGamesInfoGuidHelper = "c5618a1b-eef8-43ec-aa1b-25415fb5bc2f";
            var VideoGameInfo4 = new VideoGameInfo
            {
                VideoGameInfoId = Guid.Parse(videoGamesInfoGuidHelper),
                GameName = "GRID (2008)",
                Description =
                    "GRID is a racing game that lets the player dive into the motorsport, assume the real racer’s role and even control their own racing team. Races and racing championships are held in three main locations – the United States, Europe, and Japan. All racing circuits in the game are the mixture of imaginary and the existing ones. The gameplay is divided into 6 racing classes: GT championships, drifting, touge (climbing the narrow mountain pass like Pikes Peak), open wheel racing, demolition derby, and 24 Hours of Le Mans (additional at the end of the season). Each car of 43 available in the game is tied to one of the event types. Several professional teams compete within these championships. Therefore, to start the career player have to choose one of the disciplines and a professional team to join. While progressing GRID gives an opportunity to create your own racing team, hire sponsors and other drivers, and participate in different events. The gameplay also has a remarkable feature called “flashback” that allows rewinding time to prevent driver’s mistakes.",
                YearOfRelease = "Jun 3, 2008",
                TotalRating = 5,
                PublisherId = Publisher3.PublisherId,
                GamePicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Games/{videoGamesInfoGuidHelper}/{videoGamesInfoGuidHelper}.png",
            };

            videoGamesInfoGuidHelper = "02b0bb70-4fc8-4c72-86a7-731f4332b9a5";
            var VideoGameInfo5 = new VideoGameInfo
            {
                VideoGameInfoId = Guid.Parse(videoGamesInfoGuidHelper),
                GameName = "Operation Flashpoint: Red River",
                Description =
                    "Operation Flashpoint: Red River is a tactical first-person shooter, set in the modern world. The game is a sequel to Operation Flashpoint: Dragon Rising, and overall a third game in the series.The game’s protagonists are a squad of four US Marine Corps soldiers,each with their unique skills and fighting capabilities.The main campaign focuses on a fictional conflict in the Middle East,featuring both single - player mode and cooperative multiplayer.The battles in Operation Flashpoint are unique in a way that the players will feel the battleground,facing a real threat of getting their platoon killed,therefore making them plan their every step and use the surroundings to ensure victory.While,the game lacks competitive multiplayer,due to its focus on realism and refined experience of a fast - paced military simulator,the cooperative experience will allow players to fully immerse themselves in what would seem like a real test of nerves,teamwork,and tactics.",
                YearOfRelease = "Apr 19, 2011",
                TotalRating = 5,
                PublisherId = Publisher3.PublisherId,
                GamePicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Games/{videoGamesInfoGuidHelper}/{videoGamesInfoGuidHelper}.jpg",
            };

            videoGamesInfoGuidHelper = "96ae6e7a-5c53-4ded-bf98-6a791f1ebdd3";
            var VideoGameInfo6 = new VideoGameInfo
            {
                VideoGameInfoId = Guid.Parse(videoGamesInfoGuidHelper),
                GameName = "Just Cause 2",
                Description =
                    "Just Cause II follows a story of Rico Rodriguez, who arrives yet on another fictional island. Previously being on the Caribbean, now he is coming to Panau - an island in Southeast Asia. This time, Rico has to overthrow the dictatorial regime with its leader, Pandak 'Baby' Panay and confront his former mentor, Tom Sheldon. When Rico arrives at the island, he discovers three criminal gangs: The Roaches, The Reapers and the Ular Boys. In order to prevail, Rico has to fight all of the three fractions as well.One of the key features of the game is speed.This game is filled with adrenaline and ways of doing things very fastly.A wide variety of vehicles such as planes,boats,cars and other.A grappling hook is also available for the player as he can make his character fly around like Spider - Man or tie enemies to each other.There is a big choice of weaponry as well - you can have a pistol, two pistols, auto - rifles or even a grenade launcher! Having an open world map provides a player with experience do whatever they please - flying around, making missions or just discovering new things on the island.",
                YearOfRelease = "Mar 23, 2010",
                TotalRating = 5,
                PublisherId = Publisher1.PublisherId,
                GamePicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Games/{videoGamesInfoGuidHelper}/{videoGamesInfoGuidHelper}.jpg",
            };

            videoGamesInfoGuidHelper = "dce59101-3621-461e-bf10-61807163a946";
            var VideoGameInfo7 = new VideoGameInfo
            {
                VideoGameInfoId = Guid.Parse(videoGamesInfoGuidHelper),
                GameName = "Hitman: Absolution",
                Description =
                    "The direct sequel to the Hitman: Blood money, Absolution tells the story of Agent 47, the true intentions of his Agency and how top Agent became a renegade on the run. Unlike previous games in the series, players will get more linear and cinematic experience. The game revolves around objective-based missions, providing various methods of completion. Players can avoid direct confrontation by disguising themselves in other people’s uniforms and use environmental interactions to distract or kill unsuspecting targets. And in case of raising the alarm, players can try to rush the mission with the direct attack, using dozens of available weapons.Players can use special vision mechanic,called Instinct.It allows seeing through the solid surfaces in order to observe NPC’s,items that can be interacted with and predict the movement of patrolling guards.Absolution provides players with additional challenges and collectibles in order to invite players to explore the maps.",
                YearOfRelease = "Nov 19, 2012",
                TotalRating = 5,
                PublisherId = Publisher1.PublisherId,
                GamePicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Games/{videoGamesInfoGuidHelper}/{videoGamesInfoGuidHelper}.jpg",
            };

            videoGamesInfoGuidHelper = "007e6acf-7ff4-45d6-aa22-dfbf4c4d3b23";
            var VideoGameInfo8 = new VideoGameInfo
            {
                VideoGameInfoId = Guid.Parse(videoGamesInfoGuidHelper),
                GameName = "The Walking Dead: Michonne",
                Description =
                    "The Walking Dead: Michonne - A Telltale Miniseries stars the iconic, blade-wielding character from Robert Kirkman's best-selling comic books. Haunted by her past, and coping with unimaginable loss and regret, the story explores Michonne's absence between issues #126 and #139 of the comic book. In this three part miniseries, players will discover what took Michonne away from Rick, Ezekiel, and the rest of her trusted group… and what brought her back.",
                YearOfRelease = "Feb 22, 2016",
                TotalRating = 5,
                PublisherId = Publisher2.PublisherId,
                GamePicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Games/{videoGamesInfoGuidHelper}/{videoGamesInfoGuidHelper}.jpg",
            };
            
            videoGamesInfoGuidHelper = "0ce33067-7091-4c51-a1c4-3a93751c748c";
            var VideoGameInfo9 = new VideoGameInfo
            {
                VideoGameInfoId = Guid.Parse(videoGamesInfoGuidHelper),
                GameName = "Poker Night 2",
                Description =
                    "Playing poker is good in itself and as an occasion for live communication, a disclosure of communicative talents, a great way to spend time with friends. Especially if these friends know how to play and have fun playing.This poker simulator allows you to spend time in a beautiful company.The game lets you play with Sam(Sam & Max franchise),assisted by Max,Brock Samson(The Venture Bros.),Ash Williams(The Evil Dead) and Claptrap(Borderlands).The dealer of the game is GLaDOS(Portal series). Some other popular characters take part as additional characters or cameos.All players start the game with the same amount of in-game money,the goal is to win the money of other players.The game can be played in Texas hold 'em style or in Omaha hold' em.",
                YearOfRelease = "Apr 24, 2013",
                TotalRating = 5,
                PublisherId = Publisher2.PublisherId,
                GamePicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Games/{videoGamesInfoGuidHelper}/{videoGamesInfoGuidHelper}.jpg",
            };

            videoGamesInfoGuidHelper = "e439131b-d595-48e3-8873-be55a1357748";
            var VideoGameInfo10 = new VideoGameInfo
            {
                VideoGameInfoId = Guid.Parse(videoGamesInfoGuidHelper),
                GameName = "Back to the Future: The Game",
                Description =
                    "Marty McFly and Doc Brown return in a completely new Back to the Future adventure. Six months after the events of the third film, the DeLorean Time Machine mysteriously returns to Hill Valley - driverless! Marty must go back in time and get aid from a resistant teenage Emmett Brown, or else the space time continuum will forever be unraveled!",
                YearOfRelease = "Dec 21, 2010",
                TotalRating = 5,
                PublisherId = Publisher2.PublisherId,
                GamePicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Games/{videoGamesInfoGuidHelper}/{videoGamesInfoGuidHelper}.jpg",
            };

            videoGamesInfoGuidHelper = "426a499a-41c1-4763-a615-fca426836e3f";
            var VideoGameInfo11 = new VideoGameInfo
            {
                VideoGameInfoId = Guid.Parse(videoGamesInfoGuidHelper),
                GameName = "Jurassic Park: The Game",
                Description =
                    "Security systems have failed and the creatures of the park roam free. Now, a rogue corporation will stop at nothing to acquire the dinosaur embryos stolen and lost by Dennis Nedry. Experience a brand new adventure set during the events of the first Jurassic Park movie and see new areas and dinosaurs in this landmark adventure 65 million years in the making!",
                YearOfRelease = "Nov 15, 2011",
                TotalRating = 5,
                PublisherId = Publisher2.PublisherId,
                GamePicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Games/{videoGamesInfoGuidHelper}/{videoGamesInfoGuidHelper}.jpg",
            };

            videoGamesInfoGuidHelper = "e5a9c78f-863e-428d-81a5-3b2d4ce62494";
            var VideoGameInfo12 = new VideoGameInfo
            {
                VideoGameInfoId = Guid.Parse(videoGamesInfoGuidHelper),
                GameName = "F1 2015",
                Description =
                    "F1 2015 is a racing simulator based on the 2015 Formula One season, but with teams from the 2014 season (including the Hockenheimring track, which is missed from the 2015 season calendar). Seventh in the series. It presents the crews and pilots who participated directly in this season. Unlike its predecessors, the game received a new engine, improved physics and graphics.A 'Pro Season' mode was featured.This mode was different from the usual championship in a complete lack of interface and management assistance, as well as the highest level of complexity.The career mode, which was in the previous parts of the series, did not appear in the game.",
                YearOfRelease = "Jul 9, 2015",
                TotalRating = 5,
                PublisherId = Publisher3.PublisherId,
                GamePicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Games/{videoGamesInfoGuidHelper}/{videoGamesInfoGuidHelper}.jpg",
            };

            videoGamesInfoGuidHelper = "4cdb49aa-17a7-4029-a50a-e01f5aa5fd3c";
            var VideoGameInfo13 = new VideoGameInfo
            {
                VideoGameInfoId = Guid.Parse(videoGamesInfoGuidHelper),
                GameName = "Overlord: Raising Hell",
                Description =
                    "How evil can you get? Discover how corruptible you are in Overlord, the twisted fantasy action adventure where you can be evil(or really evil).In the game's seriously warped fantasy world, players will become the Overlord and get first-hand experience of how absolute power corrupts absolutely. You could be a regular run-of-the-mill Overlord. However, with incredible power at your disposal and a team of evil-minded impish critters, the Minions, on hand to do your bidding, how will you resist the temptation to be wonderfully despotic?!Go deeper into the Overlord's twisted world as the single-player expansion content opens a series of hellish new levels, each a supernatural abyss for the game's five kingdoms: Mellow Hills, Evernight, Heaven's Peak, the Golden Halls and the Ruborian Desert. Access to each abyss is via a portal, which opens once a kingdom has been successfully conquered and the previous ruler banished to a personal hell within. However it's not just the fallen heroes that have been dragged into the abyss: the Overlord's newly loyal peasants have also been taken down into hell too.",
                YearOfRelease = "Feb 15, 2008",
                TotalRating = 5,
                PublisherId = Publisher3.PublisherId,

                GamePicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Games/{videoGamesInfoGuidHelper}/{videoGamesInfoGuidHelper}.jpg",
            };

            videoGamesInfoGuidHelper = "9215201e-133d-43e1-b9b8-7b73ac3327c5";

            var VideoGameInfo14 = new VideoGameInfo
            {
                VideoGameInfoId = Guid.Parse(videoGamesInfoGuidHelper),
                GameName = "Law & Order: Legacies",
                Description =
                    "Law & Order: Legacies is an adventure game developed by Telltale Games. It was originally released in 2012. It was published by Telltale Games. The game is rated as 'Recommended' on RAWG. Law & Order: Legacies is available on PC. Dave Felton and Jason Lars Berquist produced the game. It was scored by Jared Emerson-Johnson and Mike Post.",
                YearOfRelease = "Jan 30, 2012",
                TotalRating = 5,
                PublisherId = Publisher2.PublisherId,
                GamePicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Games/{videoGamesInfoGuidHelper}/{videoGamesInfoGuidHelper}.jpg",
            };

            videoGamesInfoGuidHelper = "338b764e-b0f1-4969-89c8-164ca308e226";
            var VideoGameInfo15 = new VideoGameInfo
            {
                VideoGameInfoId = Guid.Parse(videoGamesInfoGuidHelper),
                GameName = "The Walking Dead: Michonne - Episode 2: Give No Shelter",
                Description =
                    "The Walking Dead: Michonne - Episode 2: Give No Shelter is an adventure game developed by Skybound. It came out on 29-03-2016. It was published by Telltale Games. Most rawgers rated the game as 'Recommended'. The Walking Dead: Michonne - Episode 2: Give No Shelter is available on PC and PlayStation 3.",
                YearOfRelease = "Mar 29, 2016",
                TotalRating = 5,
                PublisherId = Publisher2.PublisherId,
                GamePicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Games/{videoGamesInfoGuidHelper}/{videoGamesInfoGuidHelper}.jpg",
            };

            videoGamesInfoGuidHelper = "7fe582b8-0308-48d8-8173-800102aebcfb";
            var VideoGameInfo16 = new VideoGameInfo
            {
                VideoGameInfoId = Guid.Parse(videoGamesInfoGuidHelper),
                GameName = "Hitman",
                Description =
                    "Hitman is a six episodes game with different contracts. The action takes place as a prequel to Hitman: Agent 47 (only prologue) and episodes take place six years after Hitman: Absolution. All contracts are being ordered by a 'shadow client' and seem to be unrelated. But as you fulfil those contracts, you start to realise that all of the targets somehow are a part of a secret organisation called the Providence.",
                YearOfRelease = "Mar 11, 2016",
                TotalRating = 5,
                PublisherId = Publisher1.PublisherId,
                GamePicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Games/{videoGamesInfoGuidHelper}/{videoGamesInfoGuidHelper}.jpg",
            };

            videoGamesInfoGuidHelper = "72daabe6-62ec-4657-8e27-3ef881adcdd0";

            var VideoGameInfo17 = new VideoGameInfo
            {
                VideoGameInfoId = Guid.Parse(videoGamesInfoGuidHelper),
                GameName = "Just Cause 3",
                Description =
                    "Just Cause 3 is an open-world action adventure with the large locus on freedom of exploring. It is the thirds title in the Just Cause series produced by Avalanche Studios, preceded by the first two numerical parts and having the 4th part not yet released as its successor.Rico Rodriguez is the protagonist of the game, who is continually being forced to deal with bandits and dictators somewhere in the Mediterranean.The events of the third game in the series take place 6 years after the second installment.",
                YearOfRelease = "Nov 30, 2015",
                TotalRating = 5,
                PublisherId = Publisher1.PublisherId,
                GamePicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Games/{videoGamesInfoGuidHelper}/{videoGamesInfoGuidHelper}.jpg",
            };

            videoGamesInfoGuidHelper = "e09688b3-257e-413f-9ef4-0f4a9916a2c7";
            var VideoGameInfo18 = new VideoGameInfo
            {
                VideoGameInfoId = Guid.Parse(videoGamesInfoGuidHelper),
                GameName = "Rise of the Argonauts",
                Description =
                    "The role model: Released in 2008, the game, is similar to another well - known representative of the genre of action - role - playing games God of War series.Developers became studio Liquid Entertainment, and the publisher company Codemasters.The game appeared on the PC and on the most popular consoles of its generation: Playstation 3 and Xbox 360. The story and the setting: The plot of the game tells about Jason, and the action takes place in Ancient Greece. Like God of War, the game uses ancient Greek mythology to build a game universe. The modified myth of Jason and the Argonauts, who went on a journey for the Golden Fleece was used as inspiration.According to the scriptwriters of the game, Jason is a Greek king, whose wife was killed in front of him.The only way for a grieving husband to return the beloved is the Golden Fleece, which can resurrect the dead.Other well-known heroes of myths appear in the game: Hercules, Achilles, Medea, Medusa, Patroclus, and others. Together they travel through a variety of real and imaginary locations: Iolcu, Delphi, Mycenae, Tartar, and Kifr.",
                YearOfRelease = "Dec 12, 2008",
                TotalRating = 5,
                PublisherId = Publisher3.PublisherId,
                GamePicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Games/{videoGamesInfoGuidHelper}/{videoGamesInfoGuidHelper}.jpg",
            };

            videoGamesInfoGuidHelper = "339b171d-1256-4569-a330-506e46bb06c6";
            var VideoGameInfo19 = new VideoGameInfo
            {
                VideoGameInfoId = Guid.Parse(videoGamesInfoGuidHelper),
                GameName = "Damnation",
                Description =
                    "Evolving the shooter genre with its unique and exhilarating combination of fluid action and combat, Damnation features huge, open environments, frenetic combat, daredevil acrobatics and high-octane vehicle-based stunts. Presenting players with an intense test of reflexes, quick thinking and rapid-fire conflict, Damnation will feature vast, breathtaking landscapes, each covering miles of distance and thousands of vertical feet. Billed as a shooter gone vertical and visually inspired by iconic elements of American history, these massive streaming landscapes will form the battlegrounds for a post-industrial conflict between humanity and an unstoppable arms dealer hell - bent on total world domination.",
                YearOfRelease = "May 22, 2009",
                TotalRating = 5,
                PublisherId = Publisher3.PublisherId,
                GamePicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Games/{videoGamesInfoGuidHelper}/{videoGamesInfoGuidHelper}.jpg",
            };

            videoGamesInfoGuidHelper = "a0ed6f38-b3e3-4090-86f1-40c09cdaaecd";
            var VideoGameInfo20 = new VideoGameInfo
            {
                VideoGameInfoId = Guid.Parse(videoGamesInfoGuidHelper),
                GameName = "ToCA Race Driver",
                Description =
                    "Pro Race Driver features 42 licensed touring and racecars, including the Holden Commodore, Ford Falcon, Mercedes CLK, Alfa Romeo GTV, and Viper GTS. Thirty-eight international circuits are re-created under license, including Bathurst, Hockenheimring, and Silverstone. The 13 global championships include DTM from Germany, V8 Supercars from Australia, and the British Touring Car Championship. The state-of-the-art car physics engine was tested for realism by professional race drivers. A customizable car setup provides a uniquely true-to-life driving and performance experience. Real, visible damage is created using the crash test industry's FEM system, and it affects the handling and drivability of vehicles.",
                YearOfRelease = "Apr 1, 2003",
                TotalRating = 5,
                PublisherId = Publisher3.PublisherId,
                GamePicturePath =
                    $"https://fusiontech-0dxp.onrender.com/images/Games/{videoGamesInfoGuidHelper}/{videoGamesInfoGuidHelper}.jpg",
            };
            //pc 4, playstation 5

            var VideoGameVersion1 = new VideoGameVersion
            {
                VideoGameVersionId = Guid.Parse("d04514c0-df00-4608-ac8e-14c81dc4f77b"),
                Price = 80,
                VideoGameInfoId = VideoGameInfo1.VideoGameInfoId,
                GameConsoleId = Console5.GameConsoleId,
            };
            var VideoGameVersion2 = new VideoGameVersion
            {
                VideoGameVersionId = Guid.Parse("34bb9d50-8f6f-4dc1-9c8e-4bd3d6bbb725"),
                Price = 85,
                VideoGameInfoId = VideoGameInfo2.VideoGameInfoId,
                GameConsoleId = Console4.GameConsoleId,
            };
            var VideoGameVersion3 = new VideoGameVersion
            {
                VideoGameVersionId = Guid.Parse("8fa26dfb-b2e3-4f5c-bc6a-d01001fac01f"),
                Price = 90,
                VideoGameInfoId = VideoGameInfo3.VideoGameInfoId,
                GameConsoleId = Console5.GameConsoleId,
            };
            var VideoGameVersion4 = new VideoGameVersion
            {
                VideoGameVersionId = Guid.Parse("015dd706-c2dd-4740-81c7-b5dc47806f85"),
                Price = 75,
                VideoGameInfoId = VideoGameInfo4.VideoGameInfoId,
                GameConsoleId = Console4.GameConsoleId,
            };
            var VideoGameVersion5 = new VideoGameVersion
            {
                VideoGameVersionId = Guid.Parse("f5aad30c-2849-45fe-bba2-ee0dee2ccc4f"),
                Price = 85,
                VideoGameInfoId = VideoGameInfo5.VideoGameInfoId,
                GameConsoleId = Console4.GameConsoleId,
            };
            var VideoGameVersion6 = new VideoGameVersion
            {
                VideoGameVersionId = Guid.Parse("e666929b-6816-46c2-8d36-f8fd722952bb"),
                Price = 95,
                VideoGameInfoId = VideoGameInfo6.VideoGameInfoId,
                GameConsoleId = Console5.GameConsoleId,
            };
            var VideoGameVersion7 = new VideoGameVersion
            {
                VideoGameVersionId = Guid.Parse("a6060751-2511-43ed-ba82-a19fe5c58a05"),
                Price = 84,
                VideoGameInfoId = VideoGameInfo7.VideoGameInfoId,
                GameConsoleId = Console4.GameConsoleId,
            };
            var VideoGameVersion8 = new VideoGameVersion
            {
                VideoGameVersionId = Guid.Parse("05fb1770-4363-445e-8bd9-37d2d47086b3"),
                Price = 70,
                VideoGameInfoId = VideoGameInfo8.VideoGameInfoId,
                GameConsoleId = Console5.GameConsoleId,
            };
            var VideoGameVersion9 = new VideoGameVersion
            {
                VideoGameVersionId = Guid.Parse("951fe8f0-27ec-4fc6-bb0f-37101cd907ff"),
                Price = 65,
                VideoGameInfoId = VideoGameInfo9.VideoGameInfoId,
                GameConsoleId = Console4.GameConsoleId,
            };
            var VideoGameVersion10 = new VideoGameVersion
            {
                VideoGameVersionId = Guid.Parse("00347265-4220-4f99-8bd6-27342e15ef45"),
                Price = 100,
                VideoGameInfoId = VideoGameInfo10.VideoGameInfoId,
                GameConsoleId = Console5.GameConsoleId,
            };
            var VideoGameVersion11 = new VideoGameVersion
            {
                VideoGameVersionId = Guid.Parse("b31898f5-ad46-4530-a7c5-26c70caeb5b1"),
                Price = 73,
                VideoGameInfoId = VideoGameInfo11.VideoGameInfoId,
                GameConsoleId = Console4.GameConsoleId,
            };
            var VideoGameVersion12 = new VideoGameVersion
            {
                VideoGameVersionId = Guid.Parse("21b39eb5-a567-4ec8-a0b9-c7e50f311dc0"),
                Price = 109,
                VideoGameInfoId = VideoGameInfo12.VideoGameInfoId,
                GameConsoleId = Console5.GameConsoleId,
            };
            var VideoGameVersion13 = new VideoGameVersion
            {
                VideoGameVersionId = Guid.Parse("bc86a13f-c64f-4827-a0b7-9cdf16e8f1c7"),
                Price = 110,
                VideoGameInfoId = VideoGameInfo13.VideoGameInfoId,
                GameConsoleId = Console4.GameConsoleId,
            };
            var VideoGameVersion14 = new VideoGameVersion
            {
                VideoGameVersionId = Guid.Parse("76708e1d-6810-47f1-a31e-d5e787623dbb"),
                Price = 120,
                VideoGameInfoId = VideoGameInfo14.VideoGameInfoId,
                GameConsoleId = Console4.GameConsoleId,
            };
            var VideoGameVersion15 = new VideoGameVersion
            {
                VideoGameVersionId = Guid.Parse("1161e5b3-5ad1-475b-aa84-4afdff09b982"),
                Price = 125,
                VideoGameInfoId = VideoGameInfo15.VideoGameInfoId,
                GameConsoleId = Console5.GameConsoleId,
            };
            var VideoGameVersion16 = new VideoGameVersion
            {
                VideoGameVersionId = Guid.Parse("22ce0bc9-4b20-42d8-b883-5d9156024c7a"),
                Price = 100,
                VideoGameInfoId = VideoGameInfo16.VideoGameInfoId,
                GameConsoleId = Console4.GameConsoleId,
            };
            var VideoGameVersion17 = new VideoGameVersion
            {
                VideoGameVersionId = Guid.Parse("ca89b58b-f2d8-4bbe-8fb0-c5c6bf8cce91"),
                Price = 125,
                VideoGameInfoId = VideoGameInfo17.VideoGameInfoId,
                GameConsoleId = Console5.GameConsoleId,
            };
            var VideoGameVersion18 = new VideoGameVersion
            {
                VideoGameVersionId = Guid.Parse("53c84e6c-de22-45b5-9fa8-ca2958b362b4"),
                Price = 203,
                VideoGameInfoId = VideoGameInfo18.VideoGameInfoId,
                GameConsoleId = Console4.GameConsoleId,
            };
            var VideoGameVersion19 = new VideoGameVersion
            {
                VideoGameVersionId = Guid.Parse("e4f3ff4c-ca6c-4784-afe2-cb4b0d267ae4"),
                Price = 105,
                VideoGameInfoId = VideoGameInfo19.VideoGameInfoId,
                GameConsoleId = Console5.GameConsoleId,
            };
            var VideoGameVersion20 = new VideoGameVersion
            {
                VideoGameVersionId = Guid.Parse("22d7f20b-e812-4faf-9645-73c34e826b65"),
                Price = 65,
                VideoGameInfoId = VideoGameInfo20.VideoGameInfoId,
                GameConsoleId = Console4.GameConsoleId,
            };

            var Store1 = new Store
            {
                StoreId = Guid.Parse("b15664cd-da73-46bf-a47f-7be46fdd346a"),
                WorkHours = 35,
                Location = "Riyadh",
            };
            var Store2 = new Store
            {
                StoreId = Guid.Parse("06ed9de3-fd34-4b16-9c8c-150bb751c156"),
                WorkHours = 40,
                Location = "Jeddah",
            };

            var Inventory1 = new Inventory
            {
                // InventoryId = Guid.Parse("fd76ef5f-4ff4-4c64-9766-693e38b9e517"),
                VideoGameVersionId = VideoGameVersion1.VideoGameVersionId,
                StoreId = Store1.StoreId,
                GameQuantity = 250,
            };
            var Inventory2 = new Inventory
            {
                // InventoryId = Guid.Parse("1c8072f0-54d8-4a45-a5ef-b6e593bbf52f"),
                VideoGameVersionId = VideoGameVersion2.VideoGameVersionId,
                StoreId = Store1.StoreId,
                GameQuantity = 150,
            };
            var Inventory3 = new Inventory
            {
                // InventoryId = Guid.Parse("7d3f8f53-4c21-4e9f-a1b7-4a25e9f479a5"),
                VideoGameVersionId = VideoGameVersion3.VideoGameVersionId,
                StoreId = Store1.StoreId,
                GameQuantity = 50,
            };
            var Inventory4 = new Inventory
            {
                // InventoryId = Guid.Parse("42e1e9c0-ea4b-49af-9a92-e6c32b708a75"),
                VideoGameVersionId = VideoGameVersion4.VideoGameVersionId,
                StoreId = Store1.StoreId,
                GameQuantity = 350,
            };
            var Inventory5 = new Inventory
            {
                // InventoryId = Guid.Parse("c3c22e9c-1f78-4e26-9c80-31f4e7a2380e"),
                VideoGameVersionId = VideoGameVersion5.VideoGameVersionId,
                StoreId = Store1.StoreId,
                GameQuantity = 300,
            };
            var Inventory6 = new Inventory
            {
                // InventoryId = Guid.Parse("95a8c007-e80d-489e-85a2-5c6e9d947c57"),
                VideoGameVersionId = VideoGameVersion6.VideoGameVersionId,
                StoreId = Store1.StoreId,
                GameQuantity = 200,
            };
            var Inventory7 = new Inventory
            {
                // InventoryId = Guid.Parse("18a27249-9b5d-4d88-9679-63969b57b037"),
                VideoGameVersionId = VideoGameVersion7.VideoGameVersionId,
                StoreId = Store1.StoreId,
                GameQuantity = 90,
            };
            var Inventory8 = new Inventory
            {
                // InventoryId = Guid.Parse("d7b415f2-bbbf-45ea-926c-0b2c40b9fcba"),
                VideoGameVersionId = VideoGameVersion8.VideoGameVersionId,
                StoreId = Store1.StoreId,
                GameQuantity = 210,
            };
            var Inventory9 = new Inventory
            {
                // InventoryId = Guid.Parse("5b3f8d90-5a3f-4855-9bc0-dc44768e8d8b"),
                VideoGameVersionId = VideoGameVersion9.VideoGameVersionId,
                StoreId = Store1.StoreId,
                GameQuantity = 30,
            };
            var Inventory10 = new Inventory
            {
                // InventoryId = Guid.Parse("2e8bcd53-b1ff-4b1d-a68c-4d8e95ef68b6"),
                VideoGameVersionId = VideoGameVersion10.VideoGameVersionId,
                StoreId = Store1.StoreId,
                GameQuantity = 400,
            };
            var Inventory11 = new Inventory
            {
                // InventoryId = Guid.Parse("107fe30c-6d74-4bab-8a1f-26ee0e3cce43"),
                VideoGameVersionId = VideoGameVersion11.VideoGameVersionId,
                StoreId = Store1.StoreId,
                GameQuantity = 400,
            };
            var Inventory12 = new Inventory
            {
                // InventoryId = Guid.Parse("7b15e5ab-e9f0-4e49-bc7b-6d3785f6521c"),
                VideoGameVersionId = VideoGameVersion12.VideoGameVersionId,
                StoreId = Store1.StoreId,
                GameQuantity = 350,
            };

            var Inventory13 = new Inventory
            {
                // InventoryId = Guid.Parse("34d82c84-2bb8-4b42-bc62-9ff4bcb7cb88"),
                VideoGameVersionId = VideoGameVersion13.VideoGameVersionId,
                StoreId = Store1.StoreId,
                GameQuantity = 250,
            };

            var Inventory14 = new Inventory
            {
                // InventoryId = Guid.Parse("8f204b73-46b8-49c0-9b26-81c3d6d631f3"),
                VideoGameVersionId = VideoGameVersion14.VideoGameVersionId,
                StoreId = Store1.StoreId,
                GameQuantity = 600,
            };

            var Inventory15 = new Inventory
            {
                // InventoryId = Guid.Parse("0e2a798e-c4f2-4d2c-a12b-6f5e0f155c7b"),
                VideoGameVersionId = VideoGameVersion15.VideoGameVersionId,
                StoreId = Store1.StoreId,
                GameQuantity = 200,
            };

            var Inventory16 = new Inventory
            {
                // InventoryId = Guid.Parse("3b9e4c4e-4b3f-4e7b-9756-d07c1bafe7da"),
                VideoGameVersionId = VideoGameVersion16.VideoGameVersionId,
                StoreId = Store1.StoreId,
                GameQuantity = 450,
            };

            var Inventory17 = new Inventory
            {
                // InventoryId = Guid.Parse("f3b1f621-5d81-42f0-b877-78b0a635e32d"),
                VideoGameVersionId = VideoGameVersion17.VideoGameVersionId,
                StoreId = Store1.StoreId,
                GameQuantity = 300,
            };

            var Inventory18 = new Inventory
            {
                // InventoryId = Guid.Parse("99c8c29f-7cc0-44ec-bb11-479b27b0b46c"),
                VideoGameVersionId = VideoGameVersion18.VideoGameVersionId,
                StoreId = Store1.StoreId,
                GameQuantity = 700,
            };

            var Inventory19 = new Inventory
            {
                // InventoryId = Guid.Parse("5e07b60f-0984-4a83-803c-bda1b735e1c0"),
                VideoGameVersionId = VideoGameVersion19.VideoGameVersionId,
                StoreId = Store1.StoreId,
                GameQuantity = 400,
            };

            var Inventory20 = new Inventory
            {
                // InventoryId = Guid.Parse("7f9d9a79-2e29-4c7c-b3f4-87c85fbd7461"),
                VideoGameVersionId = VideoGameVersion20.VideoGameVersionId,
                StoreId = Store1.StoreId,
                GameQuantity = 500,
            };

            // Seed Payment data
            var Payment1 = new Payment
            {
                PaymentId = Guid.Parse("4c02ee7d-5a8b-4dba-9df0-5d84aba66837"),
                PaymentMethod = "Cash on delivery",
            };
            var Payment2 = new Payment
            {
                PaymentId = Guid.Parse("93d71ec8-adfe-4b40-93ba-bc4a389e6393"),
                PaymentMethod = "Visa",
            };
            var Payment3 = new Payment
            {
                PaymentId = Guid.Parse("649bd2f6-fd7b-4af9-aaad-c30aae9d0f53"),
                PaymentMethod = "Mada",
            };
            var Payment4 = new Payment
            {
                PaymentId = Guid.Parse("77965d61-af9f-41a5-a9df-fbe8e9386a2a"),
                PaymentMethod = "Apple Pay",
            };

            // Seed PersonIdCounter data
            var PersonIdCounter1 = new PersonIdCounter
            {
                PersonIdCounterId = PersonType.SystemAdmin,
                CurrentId = 3,
            };
            var PersonIdCounter2 = new PersonIdCounter
            {
                PersonIdCounterId = PersonType.StoreEmployee,
                CurrentId = 3,
            };
            var PersonIdCounter3 = new PersonIdCounter
            {
                PersonIdCounterId = PersonType.Customer,
                CurrentId = 4,
            };

            // Seed Supplier data
            var Supplier1 = new Supplier
            {
                SupplierId = Guid.Parse("47c88b33-d1cb-4b2d-94b5-b6867c6d6639"),
                SupplierName = "Tech Supplies Co",
                SupplierContactInfo = "contact@techsupplies.com, +966-800-555-0199",
                SupplierBankInfo = "Account No: 123456789",
            };
            var Supplier2 = new Supplier
            {
                SupplierId = Guid.Parse("8f851df0-b73d-49af-acb4-3f812b483430"),
                SupplierName = "Gaming Goods Ltd",
                SupplierContactInfo = "support@gaminggoods.com, +966-800-555-0198",
                SupplierBankInfo = "Account No: 987654321",
            };

            var Supply1 = new Supply
            {
                SupplyId = Guid.Parse("0bb3c011-9ba9-47e7-9ce0-3268f85e1ffc"),
                SupplierId = Supplier1.SupplierId,
                VideoGameVersionId = VideoGameVersion1.VideoGameVersionId,
                SupplyQuantity = 100,
                SupplierDate = DateTime.UtcNow,
                // InventoryId = Inventory1.InventoryId,
            };
            var Supply2 = new Supply
            {
                SupplyId = Guid.Parse("3d8f49b2-ef8b-4b3e-8f5d-1f68d8f4f4b1"),
                SupplierId = Supplier1.SupplierId,
                VideoGameVersionId = VideoGameVersion2.VideoGameVersionId,
                SupplyQuantity = 100,
                SupplierDate = DateTime.UtcNow,
                // InventoryId = Inventory1.InventoryId,
            };
            var Supply3 = new Supply
            {
                SupplyId = Guid.Parse("1b234567-89ab-cdef-0123-456789abcdef"),
                SupplierId = Supplier1.SupplierId,
                VideoGameVersionId = VideoGameVersion3.VideoGameVersionId,
                SupplyQuantity = 100,
                SupplierDate = DateTime.UtcNow,
                // InventoryId = Inventory3.InventoryId,
            };
            var Supply4 = new Supply
            {
                SupplyId = Guid.Parse("4d8d76aa-48e5-4c2b-95f1-5a77c73c0f11"),
                SupplierId = Supplier1.SupplierId,
                VideoGameVersionId = VideoGameVersion4.VideoGameVersionId,
                SupplyQuantity = 100,
                SupplierDate = DateTime.UtcNow,
                // InventoryId = Inventory4.InventoryId,
            };
            var Supply5 = new Supply
            {
                SupplyId = Guid.Parse("7f1f7c59-f92e-4c3b-a3f4-9c2a4cd474cb"),
                SupplierId = Supplier1.SupplierId,
                VideoGameVersionId = VideoGameVersion5.VideoGameVersionId,
                SupplyQuantity = 100,
                SupplierDate = DateTime.UtcNow,
                // InventoryId = Inventory5.InventoryId,
            };
            var Supply6 = new Supply
            {
                SupplyId = Guid.Parse("0a9c8263-7f5e-4e25-bb85-7a4c0a1e3a5c"),
                SupplierId = Supplier1.SupplierId,
                VideoGameVersionId = VideoGameVersion6.VideoGameVersionId,
                SupplyQuantity = 100,
                SupplierDate = DateTime.UtcNow,
                // InventoryId = Inventory6.InventoryId,
            };
            var Supply7 = new Supply
            {
                SupplyId = Guid.Parse("e43ff624-3f3c-4e8e-b5eb-11c0c3a244fa"),
                SupplierId = Supplier1.SupplierId,
                VideoGameVersionId = VideoGameVersion7.VideoGameVersionId,
                SupplyQuantity = 100,
                SupplierDate = DateTime.UtcNow,
                // InventoryId = Inventory7.InventoryId,
            };
            var Supply8 = new Supply
            {
                SupplyId = Guid.Parse("5a6e8d59-0c3d-4e54-a105-50f44dcb9e4b"),
                SupplierId = Supplier1.SupplierId,
                VideoGameVersionId = VideoGameVersion8.VideoGameVersionId,
                SupplyQuantity = 100,
                SupplierDate = DateTime.UtcNow,
                // InventoryId = Inventory8.InventoryId,
            };
            var Supply9 = new Supply
            {
                SupplyId = Guid.Parse("2b7c5a63-8e93-4d88-bc90-85c42d1574ae"),
                SupplierId = Supplier1.SupplierId,
                VideoGameVersionId = VideoGameVersion9.VideoGameVersionId,
                SupplyQuantity = 100,
                SupplierDate = DateTime.UtcNow,
                // InventoryId = Inventory9.InventoryId,
            };
            var Supply10 = new Supply
            {
                SupplyId = Guid.Parse("9e7b22d3-c5a5-429e-82dc-e5c573745e1d"),
                SupplierId = Supplier1.SupplierId,
                VideoGameVersionId = VideoGameVersion10.VideoGameVersionId,
                SupplyQuantity = 100,
                SupplierDate = DateTime.UtcNow,
                // InventoryId = Inventory10.InventoryId,
            };
            var Supply11 = new Supply
            {
                SupplyId = Guid.Parse("59259348-41da-4bbc-b85c-48ee82f474ce"),
                SupplierId = Supplier2.SupplierId,
                VideoGameVersionId = VideoGameVersion11.VideoGameVersionId,
                SupplyQuantity = 50,
                SupplierDate = DateTime.UtcNow.AddDays(-1),
                // InventoryId = Inventory11.InventoryId,
            };
            var Supply12 = new Supply
            {
                SupplyId = Guid.Parse("8d5c8e30-dede-4ef0-9158-f7692c41acb2"),
                SupplierId = Supplier2.SupplierId,
                VideoGameVersionId = VideoGameVersion12.VideoGameVersionId,
                SupplyQuantity = 50,
                SupplierDate = DateTime.UtcNow.AddDays(-1),
                // InventoryId = Inventory12.InventoryId,
            };
            var Supply13 = new Supply
            {
                SupplyId = Guid.Parse("34f2c84e-6c77-4c4a-b5f3-eef62d87b4be"),
                SupplierId = Supplier2.SupplierId,
                VideoGameVersionId = VideoGameVersion13.VideoGameVersionId,
                SupplyQuantity = 50,
                SupplierDate = DateTime.UtcNow.AddDays(-1),
                // InventoryId = Inventory13.InventoryId,
            };
            var Supply14 = new Supply
            {
                SupplyId = Guid.Parse("c7f1f4f5-74e3-4b4f-9c5a-3e2059d8b72d"),
                SupplierId = Supplier2.SupplierId,
                VideoGameVersionId = VideoGameVersion14.VideoGameVersionId,
                SupplyQuantity = 50,
                SupplierDate = DateTime.UtcNow.AddDays(-1),
                // InventoryId = Inventory14.InventoryId,
            };
            var Supply15 = new Supply
            {
                SupplyId = Guid.Parse("9b7f3e43-50bc-41d5-8f43-b8e0e1f47732"),
                SupplierId = Supplier2.SupplierId,
                VideoGameVersionId = VideoGameVersion15.VideoGameVersionId,
                SupplyQuantity = 50,
                SupplierDate = DateTime.UtcNow.AddDays(-1),
                // InventoryId = Inventory15.InventoryId,
            };
            var Supply16 = new Supply
            {
                SupplyId = Guid.Parse("72b24a8d-4e5b-43e5-aeae-ecf9dc1b52d9"),
                SupplierId = Supplier2.SupplierId,
                VideoGameVersionId = VideoGameVersion16.VideoGameVersionId,
                SupplyQuantity = 50,
                SupplierDate = DateTime.UtcNow.AddDays(-1),
                // InventoryId = Inventory16.InventoryId,
            };
            var Supply17 = new Supply
            {
                SupplyId = Guid.Parse("f3b00c12-3b5e-4c8e-9bb0-7a5c7408cd07"),
                SupplierId = Supplier2.SupplierId,
                VideoGameVersionId = VideoGameVersion17.VideoGameVersionId,
                SupplyQuantity = 50,
                SupplierDate = DateTime.UtcNow.AddDays(-1),
                // InventoryId = Inventory17.InventoryId,
            };
            var Supply18 = new Supply
            {
                SupplyId = Guid.Parse("18a64e64-3707-451c-b54d-51dbb9933aa0"),
                SupplierId = Supplier2.SupplierId,
                VideoGameVersionId = VideoGameVersion18.VideoGameVersionId,
                SupplyQuantity = 50,
                SupplierDate = DateTime.UtcNow.AddDays(-1),
                // InventoryId = Inventory18.InventoryId,
            };
            var Supply19 = new Supply
            {
                SupplyId = Guid.Parse("5e4f2822-bb47-45b4-83c0-6c1de2b5f900"),
                SupplierId = Supplier2.SupplierId,
                VideoGameVersionId = VideoGameVersion19.VideoGameVersionId,
                SupplyQuantity = 50,
                SupplierDate = DateTime.UtcNow.AddDays(-1),
                // InventoryId = Inventory19.InventoryId,
            };
            var Supply20 = new Supply
            {
                SupplyId = Guid.Parse("8b5c0f77-e3f1-4972-9102-6c1dfbb5a601"),
                SupplierId = Supplier2.SupplierId,
                VideoGameVersionId = VideoGameVersion20.VideoGameVersionId,
                SupplyQuantity = 50,
                SupplierDate = DateTime.UtcNow.AddDays(-1),
                // InventoryId = Inventory20.InventoryId,
            };

            //StoreEmployee data

            PasswordUtils.HashPassword(
                "StoreEmployee",
                out string hashedPassword1,
                out byte[] salt1
            );

            var storeEmployee1 = new StoreEmployee
            {
                PersonId = 1001,
                PersonEmail = "employeeAhmed1@hotmail.com",
                PersonName = "Ahmed Al-Farsi",
                PersonPassword = hashedPassword1,
                PersonPhoneNumber = "+966500000005",
                salt = salt1,
                Role = "StoreEmployee",
                Salary = 4827f,
                YearsOfService = 5,
                StoreId = Store1.StoreId,
                ProfilePicturePath = "",
            };

            PasswordUtils.HashPassword(
                "StoreEmployee",
                out string hashedPassword2,
                out byte[] salt2
            );

            var storeEmployee2 = new StoreEmployee
            {
                PersonId = 1002,
                PersonEmail = "employeeOmer2@gmail.com",
                PersonName = "Omar El-Mansour",
                PersonPassword = hashedPassword2,
                PersonPhoneNumber = "+966504071005",
                salt = salt2,
                Role = "StoreEmployee",
                Salary = 12000f,
                YearsOfService = 8,
                StoreId = Store2.StoreId,
                ProfilePicturePath = "",
            };
            PasswordUtils.HashPassword(
                "StoreEmployee",
                out string hashedPassword3,
                out byte[] salt3
            );

            var storeEmployee3 = new StoreEmployee
            {
                PersonId = 1003,
                PersonEmail = "employeeFatima3@gmail.com",
                PersonName = "Fatima El-Amin",
                PersonPassword = hashedPassword3,
                PersonPhoneNumber = "+966504071006",
                salt = salt3,
                Role = "StoreEmployee",
                Salary = 10000f,
                YearsOfService = 6,
                StoreId = Store1.StoreId,
                ProfilePicturePath = "",
            };

            //customer data
            PasswordUtils.HashPassword("Customer", out string hashedPassword8, out byte[] salt8);
            var customer1 = new Customer
            {
                PersonId = 100001,
                PersonEmail = "Miraaa1@gmail.com",
                PersonName = "Mira Al-Sharif",
                PersonPassword = hashedPassword8,
                PersonPhoneNumber = "+966504071075",
                salt = salt8,
                Age = 35,
                ProfilePicturePath = "",
            };
            PasswordUtils.HashPassword("Customer", out string hashedPassword7, out byte[] salt7);
            var customer2 = new Customer
            {
                PersonId = 100002,
                PersonEmail = "NoorFarouq2@gmail.com",
                PersonName = "Noor Al-Farouq",
                PersonPassword = hashedPassword7,
                PersonPhoneNumber = "+966504060980",
                salt = salt7,
                Age = 30,
                ProfilePicturePath = "",
            };
            PasswordUtils.HashPassword("Customer", out string hashedPassword6, out byte[] salt6);
            var customer3 = new Customer
            {
                PersonId = 100003,
                PersonEmail = "Khalidd3@gmail.com",
                PersonName = "Khalid Al-Jabari",
                PersonPassword = hashedPassword6,
                PersonPhoneNumber = "+966503371005",
                salt = salt6,
                Age = 23,
                ProfilePicturePath = "",
            };
            PasswordUtils.HashPassword("Customer", out string hashedPassword4, out byte[] salt4);
            var customer4 = new Customer
            {
                PersonId = 100004,
                PersonEmail = "YasinOm4@gmail.com",
                PersonName = "Yasin Al-Omari",
                PersonPassword = hashedPassword4,
                PersonPhoneNumber = "+966504471195",
                salt = salt4,
                Age = 25,
                ProfilePicturePath = "",
            };

            //order data
            var order1 = new Order
            {
                OrderId = Guid.Parse("f47ac10b-58cc-4372-a567-0e02b2c3d479"),
                OrderDate = DateTime.UtcNow,
                TotalPrice = 600f,
                EmployeeId = storeEmployee1.PersonId,
                PaymentId = Payment1.PaymentId,
                StoreId = Store1.StoreId,
                CustomerId = customer4.PersonId,
            };
            var order2 = new Order
            {
                OrderId = Guid.Parse("c9ebf2c7-5a7f-4b5d-bb7f-2f2c4d8e4a88"),
                OrderDate = DateTime.UtcNow,
                TotalPrice = 500f,
                EmployeeId = storeEmployee2.PersonId,
                PaymentId = Payment2.PaymentId,
                StoreId = Store2.StoreId,
                CustomerId = customer2.PersonId,
            };
            var order3 = new Order
            {
                OrderId = Guid.Parse("c4f5e3e1-2c4c-4f4e-a4d1-5e5e6139d703"),
                OrderDate = DateTime.UtcNow,
                TotalPrice = 890f,
                EmployeeId = storeEmployee3.PersonId,
                PaymentId = Payment3.PaymentId,
                StoreId = Store2.StoreId,
                CustomerId = customer2.PersonId,
            };
            var order4 = new Order
            {
                OrderId = Guid.Parse("d3c4b5e8-1f3a-4c8c-897e-2d8cf3e7c4f6"),
                OrderDate = DateTime.UtcNow,
                TotalPrice = 100f,
                EmployeeId = storeEmployee2.PersonId,
                PaymentId = Payment4.PaymentId,
                StoreId = Store1.StoreId,
                CustomerId = customer1.PersonId,
            };

            var orderedGame1 = new OrderedGames
            {
                Id = Guid.Parse("b2a3e9f8-3a7c-4b02-b0f9-8a3d4c5f6e7b"),
                OrderId = order1.OrderId,
                VideoGameVersionId = VideoGameVersion1.VideoGameVersionId,
                Quantity = 2,
            };
            var orderedGame2 = new OrderedGames
            {
                Id = Guid.Parse("1c6e2e0a-9c4e-4b07-bb8f-5d9d8e7f5a3c"),
                OrderId = order2.OrderId,
                VideoGameVersionId = VideoGameVersion1.VideoGameVersionId,
                Quantity = 1,
            };
            var orderedGame3 = new OrderedGames
            {
                Id = Guid.Parse("7f8d9b7e-4c3b-4f6a-9a5b-1a2c3d4e5f6a"),
                OrderId = order3.OrderId,
                VideoGameVersionId = VideoGameVersion2.VideoGameVersionId,
                Quantity = 1,
            };
            var orderedGame4 = new OrderedGames
            {
                Id = Guid.Parse("3f9e2a1a-5c2d-4f3e-8b0f-4d5e6c7b8a9c"),
                OrderId = order4.OrderId,
                VideoGameVersionId = VideoGameVersion3.VideoGameVersionId,
                Quantity = 2,
            };

            var Rate1 = new RatedBy
            {
                RatedById = Guid.Parse("e2f0c1a7-8c2c-4f51-9f4e-4a7f3b1c7e4b"),
                Rating = 5f,
                Comment = "very nice service ! thank you",
                PersonId = customer1.PersonId,
                VideoGameInfoId = VideoGameVersion2.VideoGameInfoId,
            };
            var Rate2 = new RatedBy
            {
                RatedById = Guid.Parse("b9e7f8a1-5e9a-4e79-a0b7-6e5c6d2b5f9c"),
                Rating = 4.5f,
                Comment = "very nice game I like itt :)",
                PersonId = customer2.PersonId,
                VideoGameInfoId = VideoGameVersion2.VideoGameInfoId,
            };
            var Rate3 = new RatedBy
            {
                RatedById = Guid.Parse("16ed8a7d-4f1b-4ec7-b4ed-79c6b8ac7e0a"),
                Rating = 4f,
                Comment = "good game ! ",
                PersonId = customer3.PersonId,
                VideoGameInfoId = VideoGameVersion3.VideoGameInfoId,
            };

            // modelBuilder
            modelBuilder.Entity<SystemAdmin>().HasData(SystemAdmin1, SystemAdmin2, SystemAdmin3);
            modelBuilder
                .Entity<StoreEmployee>()
                .HasData(storeEmployee1, storeEmployee2, storeEmployee3);
            modelBuilder.Entity<Customer>().HasData(customer1, customer2, customer3, customer4);
            modelBuilder.Entity<Order>().HasData(order1, order2, order3, order4);
            modelBuilder
                .Entity<OrderedGames>()
                .HasData(orderedGame1, orderedGame2, orderedGame3, orderedGame4);
            modelBuilder.Entity<RatedBy>().HasData(Rate1, Rate2, Rate3);

            modelBuilder.Entity<Category>().HasData(Category1, Category2, Category3, Category4);

            modelBuilder
                .Entity<GameConsole>()
                .HasData(Console1, Console2, Console3, Console4, Console5);

            modelBuilder
                .Entity<GameStudio>()
                .HasData(
                    Studio1,
                    Studio2,
                    Studio3,
                    Studio4,
                    Studio5,
                    Studio6,
                    Studio7,
                    Studio8,
                    Studio9,
                    Studio10
                );

            modelBuilder.Entity<Publisher>().HasData(Publisher1, Publisher2, Publisher3);

            modelBuilder
                .Entity<VideoGameInfo>()
                .HasData(
                    VideoGameInfo1,
                    VideoGameInfo2,
                    VideoGameInfo3,
                    VideoGameInfo4,
                    VideoGameInfo5,
                    VideoGameInfo6,
                    VideoGameInfo7,
                    VideoGameInfo8,
                    VideoGameInfo9,
                    VideoGameInfo10,
                    VideoGameInfo11,
                    VideoGameInfo12,
                    VideoGameInfo13,
                    VideoGameInfo14,
                    VideoGameInfo15,
                    VideoGameInfo16,
                    VideoGameInfo17,
                    VideoGameInfo18,
                    VideoGameInfo19,
                    VideoGameInfo20
                );

            modelBuilder
                .Entity<VideoGameVersion>()
                .HasData(
                    VideoGameVersion1,
                    VideoGameVersion2,
                    VideoGameVersion3,
                    VideoGameVersion4,
                    VideoGameVersion5,
                    VideoGameVersion6,
                    VideoGameVersion7,
                    VideoGameVersion8,
                    VideoGameVersion9,
                    VideoGameVersion10,
                    VideoGameVersion11,
                    VideoGameVersion12,
                    VideoGameVersion13,
                    VideoGameVersion14,
                    VideoGameVersion15,
                    VideoGameVersion16,
                    VideoGameVersion17,
                    VideoGameVersion18,
                    VideoGameVersion19,
                    VideoGameVersion20
                );

            modelBuilder.Entity<Store>().HasData(Store1, Store2);

            modelBuilder
                .Entity<Inventory>()
                .HasData(
                    Inventory1,
                    Inventory2,
                    Inventory3,
                    Inventory4,
                    Inventory5,
                    Inventory6,
                    Inventory7,
                    Inventory8,
                    Inventory9,
                    Inventory10,
                    Inventory11,
                    Inventory12,
                    Inventory13,
                    Inventory14,
                    Inventory15,
                    Inventory16,
                    Inventory17,
                    Inventory18,
                    Inventory19,
                    Inventory20
                );

            modelBuilder.Entity<Payment>().HasData(Payment1, Payment2, Payment3, Payment4);

            modelBuilder
                .Entity<PersonIdCounter>()
                .HasData(PersonIdCounter1, PersonIdCounter2, PersonIdCounter3);

            modelBuilder.Entity<Supplier>().HasData(Supplier1, Supplier2);

            modelBuilder
                .Entity<Supply>()
                .HasData(
                    Supply1,
                    Supply2,
                    Supply3,
                    Supply4,
                    Supply5,
                    Supply6,
                    Supply7,
                    Supply8,
                    Supply9,
                    Supply10,
                    Supply11,
                    Supply12,
                    Supply13,
                    Supply14,
                    Supply15,
                    Supply16,
                    Supply17,
                    Supply18,
                    Supply19,
                    Supply20
                );

            modelBuilder
                .Entity<Category>()
                .HasMany(c => c.VideoGameInfos)
                .WithMany(v => v.Categories)
                .UsingEntity(j =>
                    j.HasData(
                        new
                        {
                            CategoriesCategoryId = Category2.CategoryId,
                            VideoGameInfosVideoGameInfoId = VideoGameInfo1.VideoGameInfoId,
                        },
                        new
                        {
                            CategoriesCategoryId = Category2.CategoryId,
                            VideoGameInfosVideoGameInfoId = VideoGameInfo2.VideoGameInfoId,
                        },
                        new
                        {
                            CategoriesCategoryId = Category1.CategoryId,
                            VideoGameInfosVideoGameInfoId = VideoGameInfo3.VideoGameInfoId,
                        },
                        new
                        {
                            CategoriesCategoryId = Category3.CategoryId,
                            VideoGameInfosVideoGameInfoId = VideoGameInfo4.VideoGameInfoId,
                        },
                        new
                        {
                            CategoriesCategoryId = Category1.CategoryId,
                            VideoGameInfosVideoGameInfoId = VideoGameInfo5.VideoGameInfoId,
                        },
                        new
                        {
                            CategoriesCategoryId = Category1.CategoryId,
                            VideoGameInfosVideoGameInfoId = VideoGameInfo6.VideoGameInfoId,
                        },
                        new
                        {
                            CategoriesCategoryId = Category1.CategoryId,
                            VideoGameInfosVideoGameInfoId = VideoGameInfo7.VideoGameInfoId,
                        },
                        new
                        {
                            CategoriesCategoryId = Category2.CategoryId,
                            VideoGameInfosVideoGameInfoId = VideoGameInfo8.VideoGameInfoId,
                        },
                        new
                        {
                            CategoriesCategoryId = Category4.CategoryId,
                            VideoGameInfosVideoGameInfoId = VideoGameInfo9.VideoGameInfoId,
                        },
                        new
                        {
                            CategoriesCategoryId = Category2.CategoryId,
                            VideoGameInfosVideoGameInfoId = VideoGameInfo10.VideoGameInfoId,
                        },
                        new
                        {
                            CategoriesCategoryId = Category1.CategoryId,
                            VideoGameInfosVideoGameInfoId = VideoGameInfo11.VideoGameInfoId,
                        },
                        new
                        {
                            CategoriesCategoryId = Category3.CategoryId,
                            VideoGameInfosVideoGameInfoId = VideoGameInfo12.VideoGameInfoId,
                        },
                        new
                        {
                            CategoriesCategoryId = Category1.CategoryId,
                            VideoGameInfosVideoGameInfoId = VideoGameInfo13.VideoGameInfoId,
                        },
                        new
                        {
                            CategoriesCategoryId = Category2.CategoryId,
                            VideoGameInfosVideoGameInfoId = VideoGameInfo14.VideoGameInfoId,
                        },
                        new
                        {
                            CategoriesCategoryId = Category2.CategoryId,
                            VideoGameInfosVideoGameInfoId = VideoGameInfo15.VideoGameInfoId,
                        },
                        new
                        {
                            CategoriesCategoryId = Category2.CategoryId,
                            VideoGameInfosVideoGameInfoId = VideoGameInfo16.VideoGameInfoId,
                        },
                        new
                        {
                            CategoriesCategoryId = Category1.CategoryId,
                            VideoGameInfosVideoGameInfoId = VideoGameInfo17.VideoGameInfoId,
                        },
                        new
                        {
                            CategoriesCategoryId = Category2.CategoryId,
                            VideoGameInfosVideoGameInfoId = VideoGameInfo17.VideoGameInfoId,
                        },
                        new
                        {
                            CategoriesCategoryId = Category1.CategoryId,
                            VideoGameInfosVideoGameInfoId = VideoGameInfo18.VideoGameInfoId,
                        },
                        new
                        {
                            CategoriesCategoryId = Category1.CategoryId,
                            VideoGameInfosVideoGameInfoId = VideoGameInfo19.VideoGameInfoId,
                        },
                        new
                        {
                            CategoriesCategoryId = Category3.CategoryId,
                            VideoGameInfosVideoGameInfoId = VideoGameInfo20.VideoGameInfoId,
                        }
                    )
                );
            modelBuilder
                .Entity<GameStudio>()
                .HasMany(G => G.VideoGames)
                .WithMany(v => v.GameStudios)
                .UsingEntity(j =>
                    j.HasData(
                        new
                        {
                            GameStudiosGameStudioId = Studio1.GameStudioId,
                            VideoGamesVideoGameInfoId = VideoGameInfo1.VideoGameInfoId,
                        },
                        new
                        {
                            GameStudiosGameStudioId = Studio2.GameStudioId,
                            VideoGamesVideoGameInfoId = VideoGameInfo2.VideoGameInfoId,
                        },
                        new
                        {
                            GameStudiosGameStudioId = Studio3.GameStudioId,
                            VideoGamesVideoGameInfoId = VideoGameInfo3.VideoGameInfoId,
                        },
                        new
                        {
                            GameStudiosGameStudioId = Studio5.GameStudioId,
                            VideoGamesVideoGameInfoId = VideoGameInfo3.VideoGameInfoId,
                        },
                        new
                        {
                            GameStudiosGameStudioId = Studio4.GameStudioId,
                            VideoGamesVideoGameInfoId = VideoGameInfo4.VideoGameInfoId,
                        },
                        new
                        {
                            GameStudiosGameStudioId = Studio4.GameStudioId,
                            VideoGamesVideoGameInfoId = VideoGameInfo5.VideoGameInfoId,
                        },
                        new
                        {
                            GameStudiosGameStudioId = Studio6.GameStudioId,
                            VideoGamesVideoGameInfoId = VideoGameInfo6.VideoGameInfoId,
                        },
                        new
                        {
                            GameStudiosGameStudioId = Studio7.GameStudioId,
                            VideoGamesVideoGameInfoId = VideoGameInfo7.VideoGameInfoId,
                        },
                        new
                        {
                            GameStudiosGameStudioId = Studio2.GameStudioId,
                            VideoGamesVideoGameInfoId = VideoGameInfo8.VideoGameInfoId,
                        },
                        new
                        {
                            GameStudiosGameStudioId = Studio2.GameStudioId,
                            VideoGamesVideoGameInfoId = VideoGameInfo9.VideoGameInfoId,
                        },
                        new
                        {
                            GameStudiosGameStudioId = Studio2.GameStudioId,
                            VideoGamesVideoGameInfoId = VideoGameInfo10.VideoGameInfoId,
                        },
                        new
                        {
                            GameStudiosGameStudioId = Studio2.GameStudioId,
                            VideoGamesVideoGameInfoId = VideoGameInfo11.VideoGameInfoId,
                        },
                        new
                        {
                            GameStudiosGameStudioId = Studio4.GameStudioId,
                            VideoGamesVideoGameInfoId = VideoGameInfo12.VideoGameInfoId,
                        },
                        new
                        {
                            GameStudiosGameStudioId = Studio4.GameStudioId,
                            VideoGamesVideoGameInfoId = VideoGameInfo13.VideoGameInfoId,
                        },
                        new
                        {
                            GameStudiosGameStudioId = Studio2.GameStudioId,
                            VideoGamesVideoGameInfoId = VideoGameInfo14.VideoGameInfoId,
                        },
                        new
                        {
                            GameStudiosGameStudioId = Studio8.GameStudioId,
                            VideoGamesVideoGameInfoId = VideoGameInfo15.VideoGameInfoId,
                        },
                        new
                        {
                            GameStudiosGameStudioId = Studio7.GameStudioId,
                            VideoGamesVideoGameInfoId = VideoGameInfo16.VideoGameInfoId,
                        },
                        new
                        {
                            GameStudiosGameStudioId = Studio6.GameStudioId,
                            VideoGamesVideoGameInfoId = VideoGameInfo17.VideoGameInfoId,
                        },
                        new
                        {
                            GameStudiosGameStudioId = Studio9.GameStudioId,
                            VideoGamesVideoGameInfoId = VideoGameInfo18.VideoGameInfoId,
                        },
                        new
                        {
                            GameStudiosGameStudioId = Studio10.GameStudioId,
                            VideoGamesVideoGameInfoId = VideoGameInfo19.VideoGameInfoId,
                        },
                        new
                        {
                            GameStudiosGameStudioId = Studio4.GameStudioId,
                            VideoGamesVideoGameInfoId = VideoGameInfo20.VideoGameInfoId,
                        }
                    )
                );
        }
    }
}
