using Microsoft.EntityFrameworkCore;
using MVCProject.Models;

namespace MVCProject.DataContext
{
    public class ProductReviewContext : DbContext
    {
        private const string CONNECTION_STRING = "Server=(localdb)\\mssqllocaldb;Database=MVCProject;Trusted_Connection=True;MultipleActiveResultSets=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }
        public DbSet<ProductModel> Products { get; set; }

        public DbSet<ReviewModel> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>().HasData(
                new ProductModel()
                {
                    Id = 1,
                    Name = "Elden Ring",
                    Image = "https://th.bing.com/th/id/OIP.HERMAyUVzo3DzgckW79BCAHaDz?w=340&h=179&c=7&r=0&o=5&dpr=1.3&pid=1.7",
                    Description = "The world of Elden Ring is called the Lands Between – a large realm ruled by demigods and blessed by the power of the Elden Ring and the Erdtree. A meme that you might have seen doing the rounds joked that Elden Ring is in fact set in the US state of Ohio, but, unsurprisingly, this is false. The lands of the Lands Between are simply one giant, mystical continent surrounded by water. We’ve found the Elden Ring map fragments, so take a look to get the lay of the land.",
                    
                },
                new ProductModel()
                {
                    Id = 2,
                    Name = "Red Dead Redemption 2",
                    Image = "https://th.bing.com/th/id/OIP.MUqc73udKVBorlv2f2VK7gHaEK?w=280&h=180&c=7&r=0&o=5&dpr=1.3&pid=1.7",
                    Description = "America, 1899.\r\nArthur Morgan and the Van der Linde gang are outlaws on the run. With federal agents and the best bounty hunters in the nation massing on their heels, the gang must rob, steal and fight their way across the rugged heartland of America in order to survive",
                },
                new ProductModel()
                {
                    Id = 3,
                    Name = "The Legend of Zelda",
                    Image = "https://th.bing.com/th/id/OIP.y1CgDIrbI1bS1MfB5Ls5nQHaEo?w=284&h=180&c=7&r=0&o=5&dpr=1.3&pid=1.7",
                    Description = "In the enchanting world of Hyrule, a courageous young hero named Link sets out on an epic quest to rescue Princess Zelda from the clutches of the evil sorcerer Ganon. With the power of the Triforce guiding him, Link must navigate treacherous dungeons, solve intricate puzzles, and face formidable foes to restore peace to the land. This timeless tale of bravery, friendship, and adventure has captivated players for generations, making \"The Legend of Zelda\" a beloved and iconic video game series.",
                },
                new ProductModel()
                {
                    Id = 4,
                    Name = "Flappy Bird",
                    Image = "https://th.bing.com/th/id/OIP.VUwmSfhAI_28Hb6fjU2dZAHaEo?w=265&h=180&c=7&r=0&o=5&dpr=1.3&pid=1.7",
                    Description = "\r\nIn \"Flappy Bird,\" embark on a simple yet addictively challenging journey through the skies. Play as a tiny, determined bird, and with just a tap, guide it through narrow gaps between green pipes. Dodge obstacles, test your reflexes, and try to achieve the highest score possible. With its minimalist design and easy-to-learn gameplay, \"Flappy Bird\" offers endless hours of fun and frustration as players strive for mastery in this mobile gaming sensation.",
                }); 
            modelBuilder.Entity<ReviewModel>().HasData(
                new ReviewModel()
                {
                    Id = 1,
                    Name = "Rackean Roberts",
                    Content = "Elden Ring is an overhyped and convoluted mess that fails to deliver on its promises, leaving players with a tedious and disappointing experience.",
                    ProductId= 1,
                    Rating = 2

                },
                new ReviewModel()
                {
                    Id= 2,
                    Name= "Vance Winters",
                    Content = "Elden Ring is an awe-inspiring masterpiece that seamlessly blends the hauntingly beautiful world, captivating lore, and challenging gameplay, creating an unforgettable experience for any adventurous soul",
                    ProductId = 1,
                    Rating = 5
                },
                new ReviewModel()
                {
                    Id = 3,
                    Name = "Joseph Camacho",
                    Content = "Flappy Bird is an addictive and exhilarating mobile game that keeps me endlessly entertained with its simple yet challenging gameplay!",
                    ProductId = 4,
                    Rating = 5
                },
                new ReviewModel()
                {
                    Id = 4,
                    Name = "Christina Exclusa",
                    Content = "Red Dead Redemption 2 is an absolute masterpiece, seamlessly blending a breathtaking open-world, deeply immersive storytelling, and an unparalleled level of attention to detail that keeps me coming back for more adventures in the Old West.",
                    ProductId = 2,
                    Rating = 5
                },
                new ReviewModel()
                {
                    Id = 5,
                    Name = "Jatin Patel",
                    Content = "The Legend of Zelda series is an unparalleled gaming experience that weaves together breathtaking adventures, clever puzzles, and a timeless charm, leaving me utterly spellbound and forever in awe of its magical world.",
                    ProductId = 3,
                    Rating = 5
                });
               
        }




    }
}
