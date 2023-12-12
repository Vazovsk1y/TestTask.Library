using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestTask.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksHireRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BooksHireDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksHireRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BooksHireRecords_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BooksGenres",
                columns: table => new
                {
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksGenres", x => new { x.GenreId, x.BookId });
                    table.ForeignKey(
                        name: "FK_BooksGenres_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookHireItems",
                columns: table => new
                {
                    BookHireRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookHireExpiryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsBookReturned = table.Column<bool>(type: "bit", nullable: false),
                    BookReturnDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookHireItems", x => new { x.BookId, x.BookHireRecordId });
                    table.ForeignKey(
                        name: "FK_BookHireItems_BooksHireRecords_BookHireRecordId",
                        column: x => x.BookHireRecordId,
                        principalTable: "BooksHireRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookHireItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FullName" },
                values: new object[,]
                {
                    { new Guid("013ff23d-27a1-4634-9624-0d11d1ebb2a1"), "Charlotte Brontë" },
                    { new Guid("02cb4e9c-a7a1-4ed7-80a9-3fdac734b696"), "Harper Lee" },
                    { new Guid("0bd6d794-7e42-49f7-affb-74547559dd0a"), "Gabriel García Márquez" },
                    { new Guid("1366b5a9-44a6-4040-a19f-6379e2f78c95"), "Emily Brontë" },
                    { new Guid("19ea4415-8c05-4f5d-b620-7314488a7f5c"), "Ernest Hemingway" },
                    { new Guid("1c20dba8-57d9-4303-9f43-7ca7fc54a36c"), "J.R.R. Tolkien" },
                    { new Guid("21e3e2c2-43a5-47e4-b2b9-5fe410206334"), "Jane Austen" },
                    { new Guid("2e9994ac-a6a2-46b8-a0f0-3e2592024e03"), "Leo Tolstoy" },
                    { new Guid("2eac031e-e3e1-4304-ad99-4ba71be2825d"), "F. Scott Fitzgerald" },
                    { new Guid("38a91b62-2c76-4653-8e69-1902b47f8d63"), "Homer" },
                    { new Guid("3ac56c0f-10bd-44bb-8c98-5cb09e643373"), "Mark Twain" },
                    { new Guid("4756fe07-5e77-4339-8ca4-4b1b8f79ce2e"), "Jane Goodall" },
                    { new Guid("536410de-1f08-4143-ab84-5294d91a25b0"), "Aldous Huxley" },
                    { new Guid("5e142f82-a3a0-4f42-af99-45a4868d37f8"), "J.K. Rowling" },
                    { new Guid("632851e6-e20e-49b2-ba30-32a97896de68"), "Stephen King" },
                    { new Guid("63f0f1b5-a165-4cfb-9d7d-d8def47c8ea9"), "Agatha Christie" },
                    { new Guid("6b0f8d31-854e-4b97-904e-f0f7be6052dd"), "Isaac Asimov" },
                    { new Guid("6e4c1f4b-b264-4be4-a8e8-d196e48029b6"), "Toni Morrison" },
                    { new Guid("7d5fb1fb-8bcf-452c-a5b6-1fb4875a8f77"), "Virginia Woolf" },
                    { new Guid("87f808e8-60da-47de-be72-237cc18ec45e"), "Roald Dahl" },
                    { new Guid("8a106e71-a0c2-48a1-ba70-dfb11fc72349"), "George Orwell" },
                    { new Guid("8aba693b-c27f-4bfa-9b52-278e5419af07"), "Arthur Conan Doyle" },
                    { new Guid("950c6d64-e7ae-4e91-9313-ce5b2e61ffbe"), "William Shakespeare" },
                    { new Guid("99bf4221-b0b3-4a63-b19a-b796f079806e"), "H.G. Wells" },
                    { new Guid("b05a20dc-40bf-4296-a8da-478401ecbf1d"), "Charles Dickens" },
                    { new Guid("c1925a84-763b-4ddd-9aab-166d3bf3c42a"), "Margaret Atwood" },
                    { new Guid("ded05215-fd00-49d4-bd98-554563579b97"), "Hermann Hesse" },
                    { new Guid("e63ee2aa-6575-4f26-80f7-350aed315210"), "Ayn Rand" },
                    { new Guid("ec1492f1-d882-431a-98fa-560e73238dde"), "Michael Crichton" },
                    { new Guid("f29deecc-a512-4d7a-b059-5055bf5761e5"), "Kurt Vonnegut" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("2135f117-37df-4322-b14d-f2190d786ac6"), "Thriller" },
                    { new Guid("24724531-bda6-43f3-a802-2676619ff6b7"), "Biography" },
                    { new Guid("3349ef1b-1177-4fa6-9019-ef23fc8fb0cd"), "Mystery" },
                    { new Guid("3c083119-1883-47c9-a3e3-cb61fafca34c"), "Travel" },
                    { new Guid("4893f3f3-938d-4099-b486-0f299e2a9aac"), "Science Fiction" },
                    { new Guid("4fad30e1-31c7-4e18-ae0d-75544b9c7ca8"), "Science" },
                    { new Guid("5051faf8-d337-4004-b098-02c673aa042f"), "Non-Fiction" },
                    { new Guid("80200493-4085-42a8-ba3e-a800ec74e7d1"), "Historical Fiction" },
                    { new Guid("889ef4b7-c724-4109-a9a3-840c9b959eee"), "Comedy" },
                    { new Guid("8a12a7ad-f1f4-4125-aa26-5f1549611c3d"), "Poetry" },
                    { new Guid("97536df1-528a-46e8-b4c2-7bc47633b958"), "Romance" },
                    { new Guid("a76ea292-ca22-4f91-8daa-ffe1367a2738"), "Adventure" },
                    { new Guid("aa33dfa4-1941-4054-a066-eb3272d7a902"), "Fantasy" },
                    { new Guid("d2d6664b-4324-44a9-aa9d-370154b77941"), "Cookbook" },
                    { new Guid("dd2fc0b3-2678-4eda-a5d1-c1c556ec6d65"), "Drama" },
                    { new Guid("f1198184-fa0f-49a6-a17a-af7e253794dd"), "Horror" },
                    { new Guid("f7d4da0e-b5de-4083-b59d-02a8bb1ba77f"), "Business" },
                    { new Guid("fa661dc3-4237-428c-b17e-7871915a0f14"), "Self-Help" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "BookStatus", "Description", "ISBN", "Title" },
                values: new object[,]
                {
                    { new Guid("017c445f-d735-4368-b973-78d39b32127c"), new Guid("632851e6-e20e-49b2-ba30-32a97896de68"), "Free", "Tara Westover's memoir recounting her journey from a rural Idaho childhood to gaining an education against all odds.", "978-0-52-558019-4", "Educated" },
                    { new Guid("05d91ea6-dd31-4efc-bbcb-061a3d01c264"), new Guid("950c6d64-e7ae-4e91-9313-ce5b2e61ffbe"), "Free", "Andy Weir's gripping science fiction novel about an astronaut stranded on Mars and his fight for survival.", "978-0-55-341802-6", "The Martian" },
                    { new Guid("062bfd5f-cf24-4bc5-8052-558e969958f5"), new Guid("f29deecc-a512-4d7a-b059-5055bf5761e5"), "Free", "M. Scott Peck's exploration of personal growth, love, and spiritual development.", "978-0-74-324315-8", "The Road Less Traveled" },
                    { new Guid("07e02018-ab0c-4b82-a22a-519cc74ee557"), new Guid("536410de-1f08-4143-ab84-5294d91a25b0"), "Free", null, "978-0-14-044022-5", "The Three Musketeers" },
                    { new Guid("08bf9363-b1b7-4197-8743-1488f540b19c"), new Guid("1366b5a9-44a6-4040-a19f-6379e2f78c95"), "Free", "J.D. Salinger's iconic coming-of-age novel, capturing the angst and rebellion of a teenage boy in post-World War II America.", "978-0-31-676948-0", "The Catcher in the Rye" },
                    { new Guid("18916309-6ca0-4b92-a975-e35d77bc54b4"), new Guid("0bd6d794-7e42-49f7-affb-74547559dd0a"), "Free", "Geoffrey Chaucer's collection of stories told by a diverse group of pilgrims on their journey to Canterbury.", "978-0-14-042234-4", "The Canterbury Tales" },
                    { new Guid("1ead4f06-f006-4d90-84fd-78e48f4b9456"), new Guid("19ea4415-8c05-4f5d-b620-7314488a7f5c"), "Free", "Erin Morgenstern's magical tale of a mysterious competition between two illusionists in a magical circus.", "978-0-38-553970-6", "The Night Circus" },
                    { new Guid("27083580-0c5d-468a-87fc-06dc1b2a564c"), new Guid("87f808e8-60da-47de-be72-237cc18ec45e"), "Free", "A timeless tale of love, manners, and societal expectations in Regency-era England by Jane Austen.", "978-0-14-143951-8", "Pride and Prejudice" },
                    { new Guid("275fa2d9-1f26-4771-a7fb-98c2baf1bc05"), new Guid("5e142f82-a3a0-4f42-af99-45a4868d37f8"), "Free", "John Steinbeck's novel depicting the struggles of a displaced Oklahoma family during the Great Depression.", "978-0-14-303943-3", "The Grapes of Wrath" },
                    { new Guid("2c8c3d22-431f-4f05-950b-845c9449dd14"), new Guid("4756fe07-5e77-4339-8ca4-4b1b8f79ce2e"), "Free", null, "978-0-19-921613-3", "Alice's Adventures in Wonderland" },
                    { new Guid("2e76ec4e-8499-4bc7-9253-081f348247ee"), new Guid("536410de-1f08-4143-ab84-5294d91a25b0"), "Free", "Herman Melville's epic journey aboard the whaling ship Pequod, driven by Captain Ahab's obsessive quest for the white whale.", "978-0-14-310635-7", "Moby-Dick" },
                    { new Guid("38e5b465-e732-464a-b3d7-011c0ed23e58"), new Guid("6b0f8d31-854e-4b97-904e-f0f7be6052dd"), "Free", null, "978-0-06-085052-4", "Brave New World" },
                    { new Guid("391d222d-f0f4-45fc-8265-d4124447cd3f"), new Guid("950c6d64-e7ae-4e91-9313-ce5b2e61ffbe"), "Free", "C.S. Lewis's beloved fantasy series, taking readers to the enchanting land of Narnia and its magical inhabitants.", "978-0-06-112008-4", "The Chronicles of Narnia" },
                    { new Guid("3c0fac8f-35d1-4f3d-9f59-dac9937606cd"), new Guid("19ea4415-8c05-4f5d-b620-7314488a7f5c"), "Free", "Rebecca Skloot's biography exploring the life and legacy of Henrietta Lacks, whose cells were used for medical research without her knowledge.", "978-1-40-005217-2", "The Immortal Life of Henrietta Lacks" },
                    { new Guid("3c8c1150-778c-4bfa-acfc-4c00e439d1c1"), new Guid("1366b5a9-44a6-4040-a19f-6379e2f78c95"), "Free", "Fyodor Dostoevsky's exploration of morality, faith, and family dynamics through the complex relationships of the Karamazov brothers.", "978-0-14-044924-2", "The Brothers Karamazov" },
                    { new Guid("41a8fa88-f5db-4a5c-8296-207247caf79d"), new Guid("0bd6d794-7e42-49f7-affb-74547559dd0a"), "Free", "Stephen King's chilling tale of supernatural horror, isolation, and the descent into madness at the haunted Overlook Hotel.", "978-0-38-511683-7", "The Shining" },
                    { new Guid("41e6da8f-402a-455a-abfb-5877d96a2522"), new Guid("2eac031e-e3e1-4304-ad99-4ba71be2825d"), "Free", "George Orwell's dystopian masterpiece, depicting a nightmarish future under totalitarian rule.", "978-0-45-152493-5", "1984" },
                    { new Guid("462eb35a-c804-425e-a06c-69669536745d"), new Guid("8a106e71-a0c2-48a1-ba70-dfb11fc72349"), "Free", null, "978-0-54-792822-7", "The Hobbit" },
                    { new Guid("4663ddd6-82c8-40d2-9de2-df75fdf0ac00"), new Guid("ded05215-fd00-49d4-bd98-554563579b97"), "Free", "Suzanne Collins's dystopian saga of Katniss Everdeen's fight for survival in the annual Hunger Games.", "978-0-43-902352-8", "The Hunger Games" },
                    { new Guid("466c3ada-8097-4b73-9893-a8b76929225b"), new Guid("21e3e2c2-43a5-47e4-b2b9-5fe410206334"), "Free", "Donna Tartt's Pulitzer Prize-winning novel about a young boy's life after a terrorist attack in a New York art museum.", "978-0-31-605543-7", "The Goldfinch" },
                    { new Guid("56e6c74b-9470-4c01-8404-5a6437483502"), new Guid("63f0f1b5-a165-4cfb-9d7d-d8def47c8ea9"), "Free", null, "978-0-45-141943-9", "Les Misérables" },
                    { new Guid("57279703-0a5f-4226-94c6-97996175f094"), new Guid("013ff23d-27a1-4634-9624-0d11d1ebb2a1"), "Free", "Dan Brown's gripping mystery involving symbology, art, and secret societies.", "978-0-30-747427-8", "The Da Vinci Code" },
                    { new Guid("5c22ae00-0d97-407d-8daa-f75f826bc982"), new Guid("63f0f1b5-a165-4cfb-9d7d-d8def47c8ea9"), "Free", null, "978-0-14-143955-6", "Wuthering Heights" },
                    { new Guid("6504919e-b3a3-43b9-b6e6-eda085b1e097"), new Guid("63f0f1b5-a165-4cfb-9d7d-d8def47c8ea9"), "Free", "F. Scott Fitzgerald's classic portrayal of the American Dream, excess, and disillusionment in the Roaring Twenties.", "978-0-74-327356-5", "The Great Gatsby" },
                    { new Guid("6b3124c9-c800-4d20-b3ab-1942037a1483"), new Guid("b05a20dc-40bf-4296-a8da-478401ecbf1d"), "Free", null, "978-0-14-200174-5", "The Secret Life of Bees" },
                    { new Guid("79abced3-c21e-476b-975a-eca8c5663921"), new Guid("8aba693b-c27f-4bfa-9b52-278e5419af07"), "Free", "Alexandre Dumas's classic adventure novel of betrayal, revenge, and redemption.", "978-0-14-044926-6", "The Count of Monte Cristo" },
                    { new Guid("7ae62875-452e-41d1-bb27-90cfa9ee84fc"), new Guid("ec1492f1-d882-431a-98fa-560e73238dde"), "Free", "Homer's ancient Greek epic, recounting the adventures of Odysseus as he journeys home from the Trojan War.", "978-0-14-303995-2", "The Odyssey" },
                    { new Guid("7beed323-2cc7-403b-9fd3-a8faf70e60c6"), new Guid("7d5fb1fb-8bcf-452c-a5b6-1fb4875a8f77"), "Free", "Paula Hawkins's psychological thriller about a woman who becomes entangled in a missing person investigation.", "978-1-59-463402-4", "The Girl on the Train" },
                    { new Guid("7dcbb665-e6bf-4fd4-aa76-a55de5bc65cb"), new Guid("19ea4415-8c05-4f5d-b620-7314488a7f5c"), "Free", "Douglas Adams's hilarious space adventure, following the misadventures of Arthur Dent and his extraterrestrial friend Ford Prefect.", "978-0-34-539180-3", "The Hitchhiker's Guide to the Galaxy" },
                    { new Guid("7fd9f626-901d-4ccf-9efe-a0763c35e222"), new Guid("1c20dba8-57d9-4303-9f43-7ca7fc54a36c"), "Free", "Fyodor Dostoevsky's psychological thriller, exploring the moral and psychological turmoil of a young man in St. Petersburg.", "978-0-14-310763-7", "Crime and Punishment" },
                    { new Guid("822d1a49-e1d3-48cc-841b-0bf737f2ef5e"), new Guid("99bf4221-b0b3-4a63-b19a-b796f079806e"), "Free", "J.R.R. Tolkien's epic fantasy trilogy, featuring the quest to destroy the One Ring and save Middle-earth from the dark forces of Sauron.", "978-0-54-400341-5", "The Lord of the Rings" },
                    { new Guid("867c760a-b6c7-43cf-b06a-87ca5d0434a4"), new Guid("0bd6d794-7e42-49f7-affb-74547559dd0a"), "Free", "Harper Lee's powerful exploration of racial injustice and moral growth in the American South.", "978-0-06-112348-4", "To Kill a Mockingbird" },
                    { new Guid("8779917f-54ac-445e-b9ed-1d57068948fb"), new Guid("3ac56c0f-10bd-44bb-8c98-5cb09e643373"), "Free", null, "978-0-15-602835-6", "The Color Purple" },
                    { new Guid("8889961b-7244-4282-a390-e5bebaa5ab80"), new Guid("7d5fb1fb-8bcf-452c-a5b6-1fb4875a8f77"), "Free", "Khaled Hosseini's powerful novel about friendship, betrayal, and redemption in Afghanistan.", "978-1-59-463193-1", "The Kite Runner" },
                    { new Guid("8d273897-d66c-46d0-8e5a-3ec2023dbbfe"), new Guid("8a106e71-a0c2-48a1-ba70-dfb11fc72349"), "Free", "Ken Kesey's classic novel set in a mental hospital, challenging authority and celebrating individuality.", "978-0-45-116396-7", "One Flew Over the Cuckoo's Nest" },
                    { new Guid("91bed765-a5cc-4e39-a50e-fb291ff72c76"), new Guid("63f0f1b5-a165-4cfb-9d7d-d8def47c8ea9"), "Free", "Mary Shelley's gothic tale of scientific hubris and the consequences of creating life.", "978-0-48-628211-4", "Frankenstein" },
                    { new Guid("9e7ddd8a-935a-4196-a66c-2e871bc447e9"), new Guid("19ea4415-8c05-4f5d-b620-7314488a7f5c"), "Free", "Amy Tan's novel exploring the relationships between Chinese-American immigrant mothers and their American-born daughters.", "978-0-80-417839-9", "The Joy Luck Club" },
                    { new Guid("a11c6773-728a-49a7-9371-0727432ab2f7"), new Guid("21e3e2c2-43a5-47e4-b2b9-5fe410206334"), "Free", "Stieg Larsson's gripping mystery featuring investigative journalist Mikael Blomkvist and the enigmatic hacker Lisbeth Salander.", "978-0-30-726975-1", "The Girl with the Dragon Tattoo" },
                    { new Guid("a2f92267-3630-419c-8590-74ae3b67a219"), new Guid("7d5fb1fb-8bcf-452c-a5b6-1fb4875a8f77"), "Free", "John Green's heart-wrenching novel about two teenagers with cancer who fall in love.", "978-0-14-242417-9", "The Fault in Our Stars" },
                    { new Guid("a67fb20d-ba84-4267-903c-cefd3ce1e993"), new Guid("1366b5a9-44a6-4040-a19f-6379e2f78c95"), "Free", "Charles Duhigg's exploration of the science behind habits and how they can be transformed.", "978-0-81-298160-5", "The Power of Habit" },
                    { new Guid("ab591033-c6e1-4592-aa4a-f8a543946499"), new Guid("1366b5a9-44a6-4040-a19f-6379e2f78c95"), "Free", null, "978-0-37-584220-7", "The Book Thief" },
                    { new Guid("ac6a5d99-fda4-48e6-b359-5032f5a03a05"), new Guid("38a91b62-2c76-4653-8e69-1902b47f8d63"), "Free", "Cormac McCarthy's post-apocalyptic tale of a father and son's harrowing journey through a desolate landscape.", "978-0-30-738789-9", "The Road" },
                    { new Guid("ad88624b-2a7e-4ec3-881f-6fd4e09370bc"), new Guid("b05a20dc-40bf-4296-a8da-478401ecbf1d"), "Free", "Paulo Coelho's philosophical novel about Santiago, a shepherd boy, on a journey to discover his personal legend.", "978-0-06-112241-5", "The Alchemist" },
                    { new Guid("b8ed7427-7904-41a7-bc1d-2901d5bbe9c7"), new Guid("99bf4221-b0b3-4a63-b19a-b796f079806e"), "Free", null, "978-0-06-112028-4", "One Hundred Years of Solitude" },
                    { new Guid("d3fc7d76-b0b6-4e96-938c-4a6009fc45f3"), new Guid("e63ee2aa-6575-4f26-80f7-350aed315210"), "Free", "Yuval Noah Harari's exploration of the history and impact of Homo sapiens on the world.", "978-0-99-711060-8", "Sapiens: A Brief History of Humankind" },
                    { new Guid("d7c63adc-f68f-4734-98eb-22e132434383"), new Guid("1c20dba8-57d9-4303-9f43-7ca7fc54a36c"), "Free", null, "978-1-25-030169-7", "The Silent Patient" },
                    { new Guid("d93ab1a9-974a-4c5a-924d-9e1362b077c4"), new Guid("ded05215-fd00-49d4-bd98-554563579b97"), "Free", "Haruki Murakami's surreal and mesmerizing novel exploring the mysteries of human consciousness.", "978-0-67-977543-0", "The Wind-Up Bird Chronicle" },
                    { new Guid("da160c75-4209-486d-99c4-4380910bc08e"), new Guid("c1925a84-763b-4ddd-9aab-166d3bf3c42a"), "Free", "Jeannette Walls's memoir detailing her unconventional and often troubled childhood.", "978-0-74-324754-5", "The Glass Castle" },
                    { new Guid("dd2a83ee-17ba-475a-b080-61c9c93d4bc7"), new Guid("5e142f82-a3a0-4f42-af99-45a4868d37f8"), "Free", "Margaret Atwood's dystopian novel set in the Republic of Gilead, where women's rights are severely restricted.", "978-0-38-549081-8", "The Handmaid's Tale" },
                    { new Guid("e212b6d1-2914-4f99-9cd5-f67d525a4ba4"), new Guid("21e3e2c2-43a5-47e4-b2b9-5fe410206334"), "Free", "Leo Tolstoy's epic portrayal of Russian society during the Napoleonic Wars, blending history, philosophy, and human drama.", "978-0-14-303500-8", "War and Peace" },
                    { new Guid("e6c56f5d-1577-4345-8130-e4efda08c260"), new Guid("1366b5a9-44a6-4040-a19f-6379e2f78c95"), "Free", "J.K. Rowling's enchanting introduction to the wizarding world, filled with magic, friendship, and adventure.", "978-0-59-035342-7", "Harry Potter and the Sorcerer's Stone" },
                    { new Guid("e751fb95-1776-4183-8c01-654e2cc1ecb6"), new Guid("1c20dba8-57d9-4303-9f43-7ca7fc54a36c"), "Free", "Joseph Heller's satirical novel depicting the absurdities and paradoxes of war.", "978-0-68-484121-9", "The Catch-22" },
                    { new Guid("ea0c0481-4353-4cb5-a52c-ad7051813808"), new Guid("6b0f8d31-854e-4b97-904e-f0f7be6052dd"), "Free", null, "978-0-14-143957-0", "The Picture of Dorian Gray" },
                    { new Guid("f2bc612d-b0dd-48d9-9552-2a581d6deaaf"), new Guid("99bf4221-b0b3-4a63-b19a-b796f079806e"), "Free", null, "978-0-52-551488-0", "The Immortalists" },
                    { new Guid("f7014cae-df1b-4a0e-957d-e082054527e8"), new Guid("7d5fb1fb-8bcf-452c-a5b6-1fb4875a8f77"), "Free", "Kathryn Stockett's novel about African American maids working in white households in Jackson, Mississippi, during the early 1960s.", "978-0-42-523220-0", "The Help" },
                    { new Guid("ff7716d9-5223-493e-8ad3-a5b8a00759d0"), new Guid("02cb4e9c-a7a1-4ed7-80a9-3fdac734b696"), "Free", "Frank Herbert's science fiction epic set in a distant future where noble houses vie for control of the desert planet Arrakis and its valuable spice melange.", "978-0-44-117271-9", "Dune" }
                });

            migrationBuilder.InsertData(
                table: "BooksGenres",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { new Guid("27083580-0c5d-468a-87fc-06dc1b2a564c"), new Guid("2135f117-37df-4322-b14d-f2190d786ac6") },
                    { new Guid("2e76ec4e-8499-4bc7-9253-081f348247ee"), new Guid("2135f117-37df-4322-b14d-f2190d786ac6") },
                    { new Guid("56e6c74b-9470-4c01-8404-5a6437483502"), new Guid("2135f117-37df-4322-b14d-f2190d786ac6") },
                    { new Guid("6504919e-b3a3-43b9-b6e6-eda085b1e097"), new Guid("2135f117-37df-4322-b14d-f2190d786ac6") },
                    { new Guid("7beed323-2cc7-403b-9fd3-a8faf70e60c6"), new Guid("2135f117-37df-4322-b14d-f2190d786ac6") },
                    { new Guid("8779917f-54ac-445e-b9ed-1d57068948fb"), new Guid("2135f117-37df-4322-b14d-f2190d786ac6") },
                    { new Guid("ac6a5d99-fda4-48e6-b359-5032f5a03a05"), new Guid("2135f117-37df-4322-b14d-f2190d786ac6") },
                    { new Guid("b8ed7427-7904-41a7-bc1d-2901d5bbe9c7"), new Guid("2135f117-37df-4322-b14d-f2190d786ac6") },
                    { new Guid("062bfd5f-cf24-4bc5-8052-558e969958f5"), new Guid("24724531-bda6-43f3-a802-2676619ff6b7") },
                    { new Guid("1ead4f06-f006-4d90-84fd-78e48f4b9456"), new Guid("24724531-bda6-43f3-a802-2676619ff6b7") },
                    { new Guid("27083580-0c5d-468a-87fc-06dc1b2a564c"), new Guid("24724531-bda6-43f3-a802-2676619ff6b7") },
                    { new Guid("3c0fac8f-35d1-4f3d-9f59-dac9937606cd"), new Guid("24724531-bda6-43f3-a802-2676619ff6b7") },
                    { new Guid("41a8fa88-f5db-4a5c-8296-207247caf79d"), new Guid("24724531-bda6-43f3-a802-2676619ff6b7") },
                    { new Guid("4663ddd6-82c8-40d2-9de2-df75fdf0ac00"), new Guid("24724531-bda6-43f3-a802-2676619ff6b7") },
                    { new Guid("7fd9f626-901d-4ccf-9efe-a0763c35e222"), new Guid("24724531-bda6-43f3-a802-2676619ff6b7") },
                    { new Guid("867c760a-b6c7-43cf-b06a-87ca5d0434a4"), new Guid("24724531-bda6-43f3-a802-2676619ff6b7") },
                    { new Guid("a67fb20d-ba84-4267-903c-cefd3ce1e993"), new Guid("24724531-bda6-43f3-a802-2676619ff6b7") },
                    { new Guid("ad88624b-2a7e-4ec3-881f-6fd4e09370bc"), new Guid("24724531-bda6-43f3-a802-2676619ff6b7") },
                    { new Guid("da160c75-4209-486d-99c4-4380910bc08e"), new Guid("24724531-bda6-43f3-a802-2676619ff6b7") },
                    { new Guid("062bfd5f-cf24-4bc5-8052-558e969958f5"), new Guid("3349ef1b-1177-4fa6-9019-ef23fc8fb0cd") },
                    { new Guid("38e5b465-e732-464a-b3d7-011c0ed23e58"), new Guid("3349ef1b-1177-4fa6-9019-ef23fc8fb0cd") },
                    { new Guid("7ae62875-452e-41d1-bb27-90cfa9ee84fc"), new Guid("3349ef1b-1177-4fa6-9019-ef23fc8fb0cd") },
                    { new Guid("a67fb20d-ba84-4267-903c-cefd3ce1e993"), new Guid("3349ef1b-1177-4fa6-9019-ef23fc8fb0cd") },
                    { new Guid("d3fc7d76-b0b6-4e96-938c-4a6009fc45f3"), new Guid("3349ef1b-1177-4fa6-9019-ef23fc8fb0cd") },
                    { new Guid("e6c56f5d-1577-4345-8130-e4efda08c260"), new Guid("3349ef1b-1177-4fa6-9019-ef23fc8fb0cd") },
                    { new Guid("ea0c0481-4353-4cb5-a52c-ad7051813808"), new Guid("3349ef1b-1177-4fa6-9019-ef23fc8fb0cd") },
                    { new Guid("017c445f-d735-4368-b973-78d39b32127c"), new Guid("4893f3f3-938d-4099-b486-0f299e2a9aac") },
                    { new Guid("1ead4f06-f006-4d90-84fd-78e48f4b9456"), new Guid("4893f3f3-938d-4099-b486-0f299e2a9aac") },
                    { new Guid("38e5b465-e732-464a-b3d7-011c0ed23e58"), new Guid("4893f3f3-938d-4099-b486-0f299e2a9aac") },
                    { new Guid("391d222d-f0f4-45fc-8265-d4124447cd3f"), new Guid("4893f3f3-938d-4099-b486-0f299e2a9aac") },
                    { new Guid("57279703-0a5f-4226-94c6-97996175f094"), new Guid("4893f3f3-938d-4099-b486-0f299e2a9aac") },
                    { new Guid("e212b6d1-2914-4f99-9cd5-f67d525a4ba4"), new Guid("4893f3f3-938d-4099-b486-0f299e2a9aac") },
                    { new Guid("822d1a49-e1d3-48cc-841b-0bf737f2ef5e"), new Guid("4fad30e1-31c7-4e18-ae0d-75544b9c7ca8") },
                    { new Guid("08bf9363-b1b7-4197-8743-1488f540b19c"), new Guid("5051faf8-d337-4004-b098-02c673aa042f") },
                    { new Guid("18916309-6ca0-4b92-a975-e35d77bc54b4"), new Guid("5051faf8-d337-4004-b098-02c673aa042f") },
                    { new Guid("41e6da8f-402a-455a-abfb-5877d96a2522"), new Guid("5051faf8-d337-4004-b098-02c673aa042f") },
                    { new Guid("8d273897-d66c-46d0-8e5a-3ec2023dbbfe"), new Guid("5051faf8-d337-4004-b098-02c673aa042f") },
                    { new Guid("ab591033-c6e1-4592-aa4a-f8a543946499"), new Guid("5051faf8-d337-4004-b098-02c673aa042f") },
                    { new Guid("d3fc7d76-b0b6-4e96-938c-4a6009fc45f3"), new Guid("5051faf8-d337-4004-b098-02c673aa042f") },
                    { new Guid("dd2a83ee-17ba-475a-b080-61c9c93d4bc7"), new Guid("5051faf8-d337-4004-b098-02c673aa042f") },
                    { new Guid("f2bc612d-b0dd-48d9-9552-2a581d6deaaf"), new Guid("5051faf8-d337-4004-b098-02c673aa042f") },
                    { new Guid("07e02018-ab0c-4b82-a22a-519cc74ee557"), new Guid("80200493-4085-42a8-ba3e-a800ec74e7d1") },
                    { new Guid("3c8c1150-778c-4bfa-acfc-4c00e439d1c1"), new Guid("80200493-4085-42a8-ba3e-a800ec74e7d1") },
                    { new Guid("41a8fa88-f5db-4a5c-8296-207247caf79d"), new Guid("80200493-4085-42a8-ba3e-a800ec74e7d1") },
                    { new Guid("462eb35a-c804-425e-a06c-69669536745d"), new Guid("80200493-4085-42a8-ba3e-a800ec74e7d1") },
                    { new Guid("6b3124c9-c800-4d20-b3ab-1942037a1483"), new Guid("80200493-4085-42a8-ba3e-a800ec74e7d1") },
                    { new Guid("822d1a49-e1d3-48cc-841b-0bf737f2ef5e"), new Guid("80200493-4085-42a8-ba3e-a800ec74e7d1") },
                    { new Guid("8889961b-7244-4282-a390-e5bebaa5ab80"), new Guid("80200493-4085-42a8-ba3e-a800ec74e7d1") },
                    { new Guid("a2f92267-3630-419c-8590-74ae3b67a219"), new Guid("80200493-4085-42a8-ba3e-a800ec74e7d1") },
                    { new Guid("da160c75-4209-486d-99c4-4380910bc08e"), new Guid("80200493-4085-42a8-ba3e-a800ec74e7d1") },
                    { new Guid("e6c56f5d-1577-4345-8130-e4efda08c260"), new Guid("80200493-4085-42a8-ba3e-a800ec74e7d1") },
                    { new Guid("ea0c0481-4353-4cb5-a52c-ad7051813808"), new Guid("80200493-4085-42a8-ba3e-a800ec74e7d1") },
                    { new Guid("ff7716d9-5223-493e-8ad3-a5b8a00759d0"), new Guid("80200493-4085-42a8-ba3e-a800ec74e7d1") },
                    { new Guid("41e6da8f-402a-455a-abfb-5877d96a2522"), new Guid("889ef4b7-c724-4109-a9a3-840c9b959eee") },
                    { new Guid("4663ddd6-82c8-40d2-9de2-df75fdf0ac00"), new Guid("889ef4b7-c724-4109-a9a3-840c9b959eee") },
                    { new Guid("6504919e-b3a3-43b9-b6e6-eda085b1e097"), new Guid("889ef4b7-c724-4109-a9a3-840c9b959eee") },
                    { new Guid("a67fb20d-ba84-4267-903c-cefd3ce1e993"), new Guid("889ef4b7-c724-4109-a9a3-840c9b959eee") },
                    { new Guid("dd2a83ee-17ba-475a-b080-61c9c93d4bc7"), new Guid("889ef4b7-c724-4109-a9a3-840c9b959eee") },
                    { new Guid("f7014cae-df1b-4a0e-957d-e082054527e8"), new Guid("889ef4b7-c724-4109-a9a3-840c9b959eee") },
                    { new Guid("2c8c3d22-431f-4f05-950b-845c9449dd14"), new Guid("8a12a7ad-f1f4-4125-aa26-5f1549611c3d") },
                    { new Guid("6b3124c9-c800-4d20-b3ab-1942037a1483"), new Guid("8a12a7ad-f1f4-4125-aa26-5f1549611c3d") },
                    { new Guid("7beed323-2cc7-403b-9fd3-a8faf70e60c6"), new Guid("8a12a7ad-f1f4-4125-aa26-5f1549611c3d") },
                    { new Guid("9e7ddd8a-935a-4196-a66c-2e871bc447e9"), new Guid("8a12a7ad-f1f4-4125-aa26-5f1549611c3d") },
                    { new Guid("b8ed7427-7904-41a7-bc1d-2901d5bbe9c7"), new Guid("8a12a7ad-f1f4-4125-aa26-5f1549611c3d") },
                    { new Guid("d3fc7d76-b0b6-4e96-938c-4a6009fc45f3"), new Guid("8a12a7ad-f1f4-4125-aa26-5f1549611c3d") },
                    { new Guid("05d91ea6-dd31-4efc-bbcb-061a3d01c264"), new Guid("97536df1-528a-46e8-b4c2-7bc47633b958") },
                    { new Guid("062bfd5f-cf24-4bc5-8052-558e969958f5"), new Guid("97536df1-528a-46e8-b4c2-7bc47633b958") },
                    { new Guid("466c3ada-8097-4b73-9893-a8b76929225b"), new Guid("97536df1-528a-46e8-b4c2-7bc47633b958") },
                    { new Guid("91bed765-a5cc-4e39-a50e-fb291ff72c76"), new Guid("97536df1-528a-46e8-b4c2-7bc47633b958") },
                    { new Guid("ac6a5d99-fda4-48e6-b359-5032f5a03a05"), new Guid("97536df1-528a-46e8-b4c2-7bc47633b958") },
                    { new Guid("b8ed7427-7904-41a7-bc1d-2901d5bbe9c7"), new Guid("97536df1-528a-46e8-b4c2-7bc47633b958") },
                    { new Guid("d7c63adc-f68f-4734-98eb-22e132434383"), new Guid("97536df1-528a-46e8-b4c2-7bc47633b958") },
                    { new Guid("d93ab1a9-974a-4c5a-924d-9e1362b077c4"), new Guid("97536df1-528a-46e8-b4c2-7bc47633b958") },
                    { new Guid("062bfd5f-cf24-4bc5-8052-558e969958f5"), new Guid("a76ea292-ca22-4f91-8daa-ffe1367a2738") },
                    { new Guid("41e6da8f-402a-455a-abfb-5877d96a2522"), new Guid("a76ea292-ca22-4f91-8daa-ffe1367a2738") },
                    { new Guid("6504919e-b3a3-43b9-b6e6-eda085b1e097"), new Guid("a76ea292-ca22-4f91-8daa-ffe1367a2738") },
                    { new Guid("7ae62875-452e-41d1-bb27-90cfa9ee84fc"), new Guid("a76ea292-ca22-4f91-8daa-ffe1367a2738") },
                    { new Guid("7dcbb665-e6bf-4fd4-aa76-a55de5bc65cb"), new Guid("a76ea292-ca22-4f91-8daa-ffe1367a2738") },
                    { new Guid("8779917f-54ac-445e-b9ed-1d57068948fb"), new Guid("a76ea292-ca22-4f91-8daa-ffe1367a2738") },
                    { new Guid("8d273897-d66c-46d0-8e5a-3ec2023dbbfe"), new Guid("a76ea292-ca22-4f91-8daa-ffe1367a2738") },
                    { new Guid("ad88624b-2a7e-4ec3-881f-6fd4e09370bc"), new Guid("a76ea292-ca22-4f91-8daa-ffe1367a2738") },
                    { new Guid("d93ab1a9-974a-4c5a-924d-9e1362b077c4"), new Guid("a76ea292-ca22-4f91-8daa-ffe1367a2738") },
                    { new Guid("ea0c0481-4353-4cb5-a52c-ad7051813808"), new Guid("a76ea292-ca22-4f91-8daa-ffe1367a2738") },
                    { new Guid("56e6c74b-9470-4c01-8404-5a6437483502"), new Guid("aa33dfa4-1941-4054-a066-eb3272d7a902") },
                    { new Guid("5c22ae00-0d97-407d-8daa-f75f826bc982"), new Guid("aa33dfa4-1941-4054-a066-eb3272d7a902") },
                    { new Guid("a2f92267-3630-419c-8590-74ae3b67a219"), new Guid("aa33dfa4-1941-4054-a066-eb3272d7a902") },
                    { new Guid("f7014cae-df1b-4a0e-957d-e082054527e8"), new Guid("aa33dfa4-1941-4054-a066-eb3272d7a902") },
                    { new Guid("ff7716d9-5223-493e-8ad3-a5b8a00759d0"), new Guid("aa33dfa4-1941-4054-a066-eb3272d7a902") },
                    { new Guid("017c445f-d735-4368-b973-78d39b32127c"), new Guid("d2d6664b-4324-44a9-aa9d-370154b77941") },
                    { new Guid("18916309-6ca0-4b92-a975-e35d77bc54b4"), new Guid("d2d6664b-4324-44a9-aa9d-370154b77941") },
                    { new Guid("79abced3-c21e-476b-975a-eca8c5663921"), new Guid("d2d6664b-4324-44a9-aa9d-370154b77941") },
                    { new Guid("91bed765-a5cc-4e39-a50e-fb291ff72c76"), new Guid("d2d6664b-4324-44a9-aa9d-370154b77941") },
                    { new Guid("275fa2d9-1f26-4771-a7fb-98c2baf1bc05"), new Guid("dd2fc0b3-2678-4eda-a5d1-c1c556ec6d65") },
                    { new Guid("4663ddd6-82c8-40d2-9de2-df75fdf0ac00"), new Guid("dd2fc0b3-2678-4eda-a5d1-c1c556ec6d65") },
                    { new Guid("57279703-0a5f-4226-94c6-97996175f094"), new Guid("dd2fc0b3-2678-4eda-a5d1-c1c556ec6d65") },
                    { new Guid("867c760a-b6c7-43cf-b06a-87ca5d0434a4"), new Guid("dd2fc0b3-2678-4eda-a5d1-c1c556ec6d65") },
                    { new Guid("8889961b-7244-4282-a390-e5bebaa5ab80"), new Guid("dd2fc0b3-2678-4eda-a5d1-c1c556ec6d65") },
                    { new Guid("2e76ec4e-8499-4bc7-9253-081f348247ee"), new Guid("f1198184-fa0f-49a6-a17a-af7e253794dd") },
                    { new Guid("466c3ada-8097-4b73-9893-a8b76929225b"), new Guid("f1198184-fa0f-49a6-a17a-af7e253794dd") },
                    { new Guid("9e7ddd8a-935a-4196-a66c-2e871bc447e9"), new Guid("f1198184-fa0f-49a6-a17a-af7e253794dd") },
                    { new Guid("a11c6773-728a-49a7-9371-0727432ab2f7"), new Guid("f1198184-fa0f-49a6-a17a-af7e253794dd") },
                    { new Guid("08bf9363-b1b7-4197-8743-1488f540b19c"), new Guid("f7d4da0e-b5de-4083-b59d-02a8bb1ba77f") },
                    { new Guid("27083580-0c5d-468a-87fc-06dc1b2a564c"), new Guid("f7d4da0e-b5de-4083-b59d-02a8bb1ba77f") },
                    { new Guid("38e5b465-e732-464a-b3d7-011c0ed23e58"), new Guid("f7d4da0e-b5de-4083-b59d-02a8bb1ba77f") },
                    { new Guid("391d222d-f0f4-45fc-8265-d4124447cd3f"), new Guid("f7d4da0e-b5de-4083-b59d-02a8bb1ba77f") },
                    { new Guid("3c0fac8f-35d1-4f3d-9f59-dac9937606cd"), new Guid("f7d4da0e-b5de-4083-b59d-02a8bb1ba77f") },
                    { new Guid("41a8fa88-f5db-4a5c-8296-207247caf79d"), new Guid("f7d4da0e-b5de-4083-b59d-02a8bb1ba77f") },
                    { new Guid("5c22ae00-0d97-407d-8daa-f75f826bc982"), new Guid("f7d4da0e-b5de-4083-b59d-02a8bb1ba77f") },
                    { new Guid("a11c6773-728a-49a7-9371-0727432ab2f7"), new Guid("f7d4da0e-b5de-4083-b59d-02a8bb1ba77f") },
                    { new Guid("ab591033-c6e1-4592-aa4a-f8a543946499"), new Guid("f7d4da0e-b5de-4083-b59d-02a8bb1ba77f") },
                    { new Guid("ff7716d9-5223-493e-8ad3-a5b8a00759d0"), new Guid("f7d4da0e-b5de-4083-b59d-02a8bb1ba77f") },
                    { new Guid("822d1a49-e1d3-48cc-841b-0bf737f2ef5e"), new Guid("fa661dc3-4237-428c-b17e-7871915a0f14") },
                    { new Guid("e751fb95-1776-4183-8c01-654e2cc1ecb6"), new Guid("fa661dc3-4237-428c-b17e-7871915a0f14") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_FullName",
                table: "Authors",
                column: "FullName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookHireItems_BookHireRecordId",
                table: "BookHireItems",
                column: "BookHireRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ISBN",
                table: "Books",
                column: "ISBN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BooksGenres_BookId",
                table: "BooksGenres",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksHireRecords_UserId",
                table: "BooksHireRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Title",
                table: "Genres",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookHireItems");

            migrationBuilder.DropTable(
                name: "BooksGenres");

            migrationBuilder.DropTable(
                name: "BooksHireRecords");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
