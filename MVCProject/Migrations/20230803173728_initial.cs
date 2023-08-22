using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCProject.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StarRating = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "The world of Elden Ring is called the Lands Between – a large realm ruled by demigods and blessed by the power of the Elden Ring and the Erdtree. A meme that you might have seen doing the rounds joked that Elden Ring is in fact set in the US state of Ohio, but, unsurprisingly, this is false. The lands of the Lands Between are simply one giant, mystical continent surrounded by water. We’ve found the Elden Ring map fragments, so take a look to get the lay of the land.", "https://th.bing.com/th/id/OIP.HERMAyUVzo3DzgckW79BCAHaDz?w=340&h=179&c=7&r=0&o=5&dpr=1.3&pid=1.7", "Elden Ring" },
                    { 2, "America, 1899.\r\nArthur Morgan and the Van der Linde gang are outlaws on the run. With federal agents and the best bounty hunters in the nation massing on their heels, the gang must rob, steal and fight their way across the rugged heartland of America in order to survive", "https://th.bing.com/th/id/OIP.MUqc73udKVBorlv2f2VK7gHaEK?w=280&h=180&c=7&r=0&o=5&dpr=1.3&pid=1.7", "Red Dead Redemption 2" },
                    { 3, "In the enchanting world of Hyrule, a courageous young hero named Link sets out on an epic quest to rescue Princess Zelda from the clutches of the evil sorcerer Ganon. With the power of the Triforce guiding him, Link must navigate treacherous dungeons, solve intricate puzzles, and face formidable foes to restore peace to the land. This timeless tale of bravery, friendship, and adventure has captivated players for generations, making \"The Legend of Zelda\" a beloved and iconic video game series.", "https://th.bing.com/th/id/OIP.y1CgDIrbI1bS1MfB5Ls5nQHaEo?w=284&h=180&c=7&r=0&o=5&dpr=1.3&pid=1.7", "The Legend of Zelda" },
                    { 4, "\r\nIn \"Flappy Bird,\" embark on a simple yet addictively challenging journey through the skies. Play as a tiny, determined bird, and with just a tap, guide it through narrow gaps between green pipes. Dodge obstacles, test your reflexes, and try to achieve the highest score possible. With its minimalist design and easy-to-learn gameplay, \"Flappy Bird\" offers endless hours of fun and frustration as players strive for mastery in this mobile gaming sensation.", "https://th.bing.com/th/id/OIP.VUwmSfhAI_28Hb6fjU2dZAHaEo?w=265&h=180&c=7&r=0&o=5&dpr=1.3&pid=1.7", "Flappy Bird" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Content", "Name", "ProductId", "Rating", "StarRating" },
                values: new object[,]
                {
                    { 1, "Elden Ring is an overhyped and convoluted mess that fails to deliver on its promises, leaving players with a tedious and disappointing experience.", "Rackean Roberts", 1, 2, null },
                    { 2, "Elden Ring is an awe-inspiring masterpiece that seamlessly blends the hauntingly beautiful world, captivating lore, and challenging gameplay, creating an unforgettable experience for any adventurous soul", "Vance Winters", 1, 5, null },
                    { 3, "Flappy Bird is an addictive and exhilarating mobile game that keeps me endlessly entertained with its simple yet challenging gameplay!", "Joseph Camacho", 4, 5, null },
                    { 4, "Red Dead Redemption 2 is an absolute masterpiece, seamlessly blending a breathtaking open-world, deeply immersive storytelling, and an unparalleled level of attention to detail that keeps me coming back for more adventures in the Old West.", "Christina Exclusa", 2, 5, null },
                    { 5, "The Legend of Zelda series is an unparalleled gaming experience that weaves together breathtaking adventures, clever puzzles, and a timeless charm, leaving me utterly spellbound and forever in awe of its magical world.", "Jatin Patel", 3, 5, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
