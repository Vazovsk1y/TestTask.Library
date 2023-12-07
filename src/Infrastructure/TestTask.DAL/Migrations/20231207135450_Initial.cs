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
                name: "BooksHiresInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookHiredDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksHiresInfos", x => x.Id);
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
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "BookHireItems",
                columns: table => new
                {
                    BookHireCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookHireExpiryDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsBookReturned = table.Column<bool>(type: "bit", nullable: false),
                    BookReturnDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookHireItems", x => new { x.BookId, x.BookHireCardId });
                    table.ForeignKey(
                        name: "FK_BookHireItems_BooksHiresInfos_BookHireCardId",
                        column: x => x.BookHireCardId,
                        principalTable: "BooksHiresInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookHireItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FullName" },
                values: new object[,]
                {
                    { new Guid("01ed4143-30d8-4f84-9b61-cf32cc8cd3f7"), "Charlotte Brontë" },
                    { new Guid("10615a81-8d9b-4099-9822-4081efd7a4ad"), "Charles Dickens" },
                    { new Guid("1335fa2c-6bee-4c35-8735-d17c36ae1a36"), "George Orwell" },
                    { new Guid("143b8492-16d6-486b-9f89-c5b08dd62117"), "Michael Crichton" },
                    { new Guid("19505c06-e688-41db-8d00-1561dd1ea93c"), "J.K. Rowling" },
                    { new Guid("20042ed7-a09a-4b91-adac-cb298b87b007"), "H.G. Wells" },
                    { new Guid("3207664e-10e9-4f4c-bebc-000cb20a8ac2"), "Mark Twain" },
                    { new Guid("3e7dcc67-ca24-4711-a948-4f9e714e6925"), "Margaret Atwood" },
                    { new Guid("42a87a56-af52-47e5-8c07-86d76adfcf82"), "Emily Brontë" },
                    { new Guid("45123b57-2088-4bdf-b180-cfe1ce4c0963"), "Virginia Woolf" },
                    { new Guid("47e1c0cc-aca2-42a5-8ef2-f3aa7007b9ea"), "Leo Tolstoy" },
                    { new Guid("504246ec-9bcf-4c26-a705-8cf4abff4f4b"), "Stephen King" },
                    { new Guid("58a4d4b6-d03b-4b2c-ac7b-e639bdce2068"), "Roald Dahl" },
                    { new Guid("69fd8ca4-a2b0-4cf6-a71a-308a50226a6f"), "Aldous Huxley" },
                    { new Guid("6de5652f-7d06-44e8-bffd-541d99f45dbc"), "Ayn Rand" },
                    { new Guid("7c2bd8f5-b60a-43af-a892-6ee2370f9d1e"), "William Shakespeare" },
                    { new Guid("87c47796-9894-455c-89c4-d548e9796f52"), "J.R.R. Tolkien" },
                    { new Guid("9392e91e-5115-4a66-86cb-a0a70d6df27c"), "Hermann Hesse" },
                    { new Guid("93c9b236-d56d-40bc-84ca-317bb83293aa"), "F. Scott Fitzgerald" },
                    { new Guid("a5aac66c-1ed9-4886-8ef4-c6be46575b4b"), "Homer" },
                    { new Guid("b19d3bed-bb80-4747-a915-cb3fce01e8a5"), "Arthur Conan Doyle" },
                    { new Guid("b49ab307-235b-4659-b4bd-e93280ac84e4"), "Harper Lee" },
                    { new Guid("b5f1b0b3-0943-4d0a-a3c4-22d25836da0f"), "Ernest Hemingway" },
                    { new Guid("bb1fa7e6-828f-4557-a86e-475a133072c7"), "Toni Morrison" },
                    { new Guid("d35ffd89-61e4-4887-a791-900edfd36d69"), "Jane Austen" },
                    { new Guid("de6de5e2-0f17-4c0c-a8a3-bc2b267f211a"), "Jane Goodall" },
                    { new Guid("e46d2a3b-9e03-4985-9208-49aab09348b4"), "Gabriel García Márquez" },
                    { new Guid("eb484b53-5635-46c4-baaa-ed805b0dbead"), "Isaac Asimov" },
                    { new Guid("f4f0c1ad-c4d7-4ad3-9831-d17654c98836"), "Kurt Vonnegut" },
                    { new Guid("f62dee0b-c18a-442e-be3f-64de2e4aeb32"), "Agatha Christie" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("0cf8b380-2197-475e-b2a3-58933b2b28da"), "Self-Help" },
                    { new Guid("16f86a14-951e-4d5d-a8a2-1b851bfedbf0"), "Non-Fiction" },
                    { new Guid("1f7e00a3-33bc-40e3-86cb-0cc3d5960bd9"), "Horror" },
                    { new Guid("2407f9f6-9366-44cc-a778-a6542fbf117d"), "Cookbook" },
                    { new Guid("3552e9af-420f-4ac5-b2a7-1c2df67ea04d"), "Thriller" },
                    { new Guid("3af32f58-6e4f-4cda-8ab5-e2a3c2930109"), "Fantasy" },
                    { new Guid("3e9f2549-c5f1-49bc-a5c7-642104b6321e"), "Science Fiction" },
                    { new Guid("4d56568a-f1f7-46a0-b2aa-a5cf89f033f3"), "Comedy" },
                    { new Guid("5f9b5fb9-506d-4c07-80ef-e5b7fcc3b6f2"), "Drama" },
                    { new Guid("600d8d8a-a57a-4fa9-83ec-40fa7ebe45ba"), "Biography" },
                    { new Guid("6fdde76f-4321-4d4a-a7ed-83ed682a6d62"), "Mystery" },
                    { new Guid("a4adf827-2747-40d7-801b-07115f9f0082"), "Romance" },
                    { new Guid("b621b43e-4639-44c1-9a30-9aaa12b2ac80"), "Historical Fiction" },
                    { new Guid("bc6621c3-2a57-4271-8820-93d94501eeba"), "Poetry" },
                    { new Guid("c9669d77-fef5-4096-af97-5cf06e75feb3"), "Travel" },
                    { new Guid("ce160fd7-cb8c-4185-99e2-f398e52678cc"), "Adventure" },
                    { new Guid("cfc35fd7-ff41-44bb-9779-dc0f98ad8eb2"), "Business" },
                    { new Guid("e0be5314-1296-4988-b09f-11fca7c85060"), "Science" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "ISBN", "Title" },
                values: new object[,]
                {
                    { new Guid("1475e87b-c7e8-4372-8de5-2bd6b17bb4d2"), new Guid("143b8492-16d6-486b-9f89-c5b08dd62117"), null, "978-0-14-143955-6", "Wuthering Heights" },
                    { new Guid("219b255f-8434-426c-a236-b16b224f557a"), new Guid("3e7dcc67-ca24-4711-a948-4f9e714e6925"), null, "978-0-54-792822-7", "The Hobbit" },
                    { new Guid("23030c7e-bb55-4ce2-aefa-bba3cf25bf97"), new Guid("87c47796-9894-455c-89c4-d548e9796f52"), "Donna Tartt's Pulitzer Prize-winning novel about a young boy's life after a terrorist attack in a New York art museum.", "978-0-31-605543-7", "The Goldfinch" },
                    { new Guid("268c1d81-e4b4-4f5f-8993-2d80473050a3"), new Guid("3e7dcc67-ca24-4711-a948-4f9e714e6925"), null, "978-0-52-551488-0", "The Immortalists" },
                    { new Guid("39c21217-e288-4b21-90da-68dbec7b7e8f"), new Guid("7c2bd8f5-b60a-43af-a892-6ee2370f9d1e"), "Amy Tan's novel exploring the relationships between Chinese-American immigrant mothers and their American-born daughters.", "978-0-80-417839-9", "The Joy Luck Club" },
                    { new Guid("41dd2dd8-7c58-4ab8-9ea1-b35c57366080"), new Guid("b19d3bed-bb80-4747-a915-cb3fce01e8a5"), null, "978-0-14-044022-5", "The Three Musketeers" },
                    { new Guid("479298bc-c19e-4bd4-9246-3e7800f2e5d5"), new Guid("6de5652f-7d06-44e8-bffd-541d99f45dbc"), "Fyodor Dostoevsky's psychological thriller, exploring the moral and psychological turmoil of a young man in St. Petersburg.", "978-0-14-310763-7", "Crime and Punishment" },
                    { new Guid("4be039c0-322c-49ea-909d-f5967ad47cf2"), new Guid("19505c06-e688-41db-8d00-1561dd1ea93c"), "Paulo Coelho's philosophical novel about Santiago, a shepherd boy, on a journey to discover his personal legend.", "978-0-06-112241-5", "The Alchemist" },
                    { new Guid("529ee040-5ed8-42ed-be65-e05c4be21528"), new Guid("6de5652f-7d06-44e8-bffd-541d99f45dbc"), null, "978-0-37-584220-7", "The Book Thief" },
                    { new Guid("539f03dd-b40a-402b-bc78-02f909b97538"), new Guid("42a87a56-af52-47e5-8c07-86d76adfcf82"), "Joseph Heller's satirical novel depicting the absurdities and paradoxes of war.", "978-0-68-484121-9", "The Catch-22" },
                    { new Guid("566c9af3-6bbb-45a4-81f0-5d8572a8e577"), new Guid("42a87a56-af52-47e5-8c07-86d76adfcf82"), "J.D. Salinger's iconic coming-of-age novel, capturing the angst and rebellion of a teenage boy in post-World War II America.", "978-0-31-676948-0", "The Catcher in the Rye" },
                    { new Guid("5bca57fb-4f16-4619-a0f4-261a2c7c691c"), new Guid("47e1c0cc-aca2-42a5-8ef2-f3aa7007b9ea"), "John Steinbeck's novel depicting the struggles of a displaced Oklahoma family during the Great Depression.", "978-0-14-303943-3", "The Grapes of Wrath" },
                    { new Guid("5e3eda09-3e3a-442f-afaf-c068082934df"), new Guid("eb484b53-5635-46c4-baaa-ed805b0dbead"), "Herman Melville's epic journey aboard the whaling ship Pequod, driven by Captain Ahab's obsessive quest for the white whale.", "978-0-14-310635-7", "Moby-Dick" },
                    { new Guid("5f6c0fa6-e5ad-4066-8f69-82f74491259d"), new Guid("47e1c0cc-aca2-42a5-8ef2-f3aa7007b9ea"), "C.S. Lewis's beloved fantasy series, taking readers to the enchanting land of Narnia and its magical inhabitants.", "978-0-06-112008-4", "The Chronicles of Narnia" },
                    { new Guid("628fc3a2-c351-4b6e-9a1d-d80d63711976"), new Guid("eb484b53-5635-46c4-baaa-ed805b0dbead"), "Rebecca Skloot's biography exploring the life and legacy of Henrietta Lacks, whose cells were used for medical research without her knowledge.", "978-1-40-005217-2", "The Immortal Life of Henrietta Lacks" },
                    { new Guid("669fb617-f96d-47cf-b3bd-359569fb4aa7"), new Guid("504246ec-9bcf-4c26-a705-8cf4abff4f4b"), "Suzanne Collins's dystopian saga of Katniss Everdeen's fight for survival in the annual Hunger Games.", "978-0-43-902352-8", "The Hunger Games" },
                    { new Guid("687ab10d-302d-424a-88d7-cc3fb53bdc2b"), new Guid("f4f0c1ad-c4d7-4ad3-9831-d17654c98836"), "Alexandre Dumas's classic adventure novel of betrayal, revenge, and redemption.", "978-0-14-044926-6", "The Count of Monte Cristo" },
                    { new Guid("6b0cc103-b8e6-401c-a3ec-769eace927eb"), new Guid("b19d3bed-bb80-4747-a915-cb3fce01e8a5"), null, "978-0-45-141943-9", "Les Misérables" },
                    { new Guid("6c51c4c2-ad34-4cd0-8d50-beac7e524025"), new Guid("de6de5e2-0f17-4c0c-a8a3-bc2b267f211a"), null, "978-0-19-921613-3", "Alice's Adventures in Wonderland" },
                    { new Guid("6cb782b0-5ca8-403a-b6b3-1c1f5440ec2e"), new Guid("b19d3bed-bb80-4747-a915-cb3fce01e8a5"), "Yuval Noah Harari's exploration of the history and impact of Homo sapiens on the world.", "978-0-99-711060-8", "Sapiens: A Brief History of Humankind" },
                    { new Guid("725187d4-fa2a-4bee-9cb8-1ed031088cb7"), new Guid("3e7dcc67-ca24-4711-a948-4f9e714e6925"), null, "978-1-25-030169-7", "The Silent Patient" },
                    { new Guid("7baa369b-b5d5-419b-b1df-78f31306e129"), new Guid("10615a81-8d9b-4099-9822-4081efd7a4ad"), "Leo Tolstoy's epic portrayal of Russian society during the Napoleonic Wars, blending history, philosophy, and human drama.", "978-0-14-303500-8", "War and Peace" },
                    { new Guid("84914b05-f2c9-4346-a656-8bd4a5bc3e40"), new Guid("504246ec-9bcf-4c26-a705-8cf4abff4f4b"), "J.R.R. Tolkien's epic fantasy trilogy, featuring the quest to destroy the One Ring and save Middle-earth from the dark forces of Sauron.", "978-0-54-400341-5", "The Lord of the Rings" },
                    { new Guid("86aa7b8b-07d0-4f57-b5e5-f01f676dbe69"), new Guid("7c2bd8f5-b60a-43af-a892-6ee2370f9d1e"), "Erin Morgenstern's magical tale of a mysterious competition between two illusionists in a magical circus.", "978-0-38-553970-6", "The Night Circus" },
                    { new Guid("86b2636c-0f1c-44f8-ade9-e9437f5bd1da"), new Guid("f62dee0b-c18a-442e-be3f-64de2e4aeb32"), "M. Scott Peck's exploration of personal growth, love, and spiritual development.", "978-0-74-324315-8", "The Road Less Traveled" },
                    { new Guid("89bb92e6-7847-4bfe-8d30-026a3a0519bb"), new Guid("b19d3bed-bb80-4747-a915-cb3fce01e8a5"), "Frank Herbert's science fiction epic set in a distant future where noble houses vie for control of the desert planet Arrakis and its valuable spice melange.", "978-0-44-117271-9", "Dune" },
                    { new Guid("8cb48997-f476-4cfc-9ef2-ef89af50fd3c"), new Guid("de6de5e2-0f17-4c0c-a8a3-bc2b267f211a"), "Paula Hawkins's psychological thriller about a woman who becomes entangled in a missing person investigation.", "978-1-59-463402-4", "The Girl on the Train" },
                    { new Guid("91a21725-f427-48a8-929c-c3e91dbba110"), new Guid("9392e91e-5115-4a66-86cb-a0a70d6df27c"), "Andy Weir's gripping science fiction novel about an astronaut stranded on Mars and his fight for survival.", "978-0-55-341802-6", "The Martian" },
                    { new Guid("943df911-4772-4185-9857-1ca1aa395206"), new Guid("19505c06-e688-41db-8d00-1561dd1ea93c"), null, "978-0-14-143957-0", "The Picture of Dorian Gray" },
                    { new Guid("9cece5b1-d2c5-4f34-a19f-54ee61b76b47"), new Guid("de6de5e2-0f17-4c0c-a8a3-bc2b267f211a"), "Haruki Murakami's surreal and mesmerizing novel exploring the mysteries of human consciousness.", "978-0-67-977543-0", "The Wind-Up Bird Chronicle" },
                    { new Guid("a4ed7151-9852-4c9c-92db-a705664345ea"), new Guid("1335fa2c-6bee-4c35-8735-d17c36ae1a36"), null, "978-0-06-112028-4", "One Hundred Years of Solitude" },
                    { new Guid("a823a0cc-6a32-474a-b4b2-37c94549327f"), new Guid("42a87a56-af52-47e5-8c07-86d76adfcf82"), "George Orwell's dystopian masterpiece, depicting a nightmarish future under totalitarian rule.", "978-0-45-152493-5", "1984" },
                    { new Guid("aa47c42b-d820-42aa-bd2f-f1244e75e31c"), new Guid("b5f1b0b3-0943-4d0a-a3c4-22d25836da0f"), null, "978-0-15-602835-6", "The Color Purple" },
                    { new Guid("abe7d045-c701-4d61-81b1-b7d1d2f28c39"), new Guid("42a87a56-af52-47e5-8c07-86d76adfcf82"), "F. Scott Fitzgerald's classic portrayal of the American Dream, excess, and disillusionment in the Roaring Twenties.", "978-0-74-327356-5", "The Great Gatsby" },
                    { new Guid("b72491e2-d80d-49eb-b79a-28a7c34fa92d"), new Guid("de6de5e2-0f17-4c0c-a8a3-bc2b267f211a"), "Tara Westover's memoir recounting her journey from a rural Idaho childhood to gaining an education against all odds.", "978-0-52-558019-4", "Educated" },
                    { new Guid("b8b260e2-448e-4d31-9cdf-1f36013f70de"), new Guid("d35ffd89-61e4-4887-a791-900edfd36d69"), "Harper Lee's powerful exploration of racial injustice and moral growth in the American South.", "978-0-06-112348-4", "To Kill a Mockingbird" },
                    { new Guid("bc79faf2-e3e5-4056-8f61-4b9d6b69aadd"), new Guid("9392e91e-5115-4a66-86cb-a0a70d6df27c"), "Homer's ancient Greek epic, recounting the adventures of Odysseus as he journeys home from the Trojan War.", "978-0-14-303995-2", "The Odyssey" },
                    { new Guid("bc9c8649-c943-4ecb-87e8-11b6d8d9d112"), new Guid("eb484b53-5635-46c4-baaa-ed805b0dbead"), "Geoffrey Chaucer's collection of stories told by a diverse group of pilgrims on their journey to Canterbury.", "978-0-14-042234-4", "The Canterbury Tales" },
                    { new Guid("c2e43fe6-58ab-4aa7-bacd-49b175d565ad"), new Guid("6de5652f-7d06-44e8-bffd-541d99f45dbc"), null, "978-0-06-085052-4", "Brave New World" },
                    { new Guid("c466c891-c61d-4cb8-baca-a61ae803b5f2"), new Guid("6de5652f-7d06-44e8-bffd-541d99f45dbc"), "Douglas Adams's hilarious space adventure, following the misadventures of Arthur Dent and his extraterrestrial friend Ford Prefect.", "978-0-34-539180-3", "The Hitchhiker's Guide to the Galaxy" },
                    { new Guid("c76dd43e-0e97-4692-84cb-8d4f2b8451df"), new Guid("e46d2a3b-9e03-4985-9208-49aab09348b4"), "Jeannette Walls's memoir detailing her unconventional and often troubled childhood.", "978-0-74-324754-5", "The Glass Castle" },
                    { new Guid("cb38da87-20f3-4540-83d0-032e6a87d35d"), new Guid("69fd8ca4-a2b0-4cf6-a71a-308a50226a6f"), "Mary Shelley's gothic tale of scientific hubris and the consequences of creating life.", "978-0-48-628211-4", "Frankenstein" },
                    { new Guid("cd57b50b-3734-43d7-9229-4f656d8d6aa6"), new Guid("1335fa2c-6bee-4c35-8735-d17c36ae1a36"), "J.K. Rowling's enchanting introduction to the wizarding world, filled with magic, friendship, and adventure.", "978-0-59-035342-7", "Harry Potter and the Sorcerer's Stone" },
                    { new Guid("d2030d67-e15c-4ccc-b5ea-e769be2dbe17"), new Guid("143b8492-16d6-486b-9f89-c5b08dd62117"), "Fyodor Dostoevsky's exploration of morality, faith, and family dynamics through the complex relationships of the Karamazov brothers.", "978-0-14-044924-2", "The Brothers Karamazov" },
                    { new Guid("d55f22a5-3078-4960-bdd7-3bccff1d14cc"), new Guid("a5aac66c-1ed9-4886-8ef4-c6be46575b4b"), "Khaled Hosseini's powerful novel about friendship, betrayal, and redemption in Afghanistan.", "978-1-59-463193-1", "The Kite Runner" },
                    { new Guid("e170cc7a-e522-41ce-bc8a-21a3fabce3f6"), new Guid("de6de5e2-0f17-4c0c-a8a3-bc2b267f211a"), "Stephen King's chilling tale of supernatural horror, isolation, and the descent into madness at the haunted Overlook Hotel.", "978-0-38-511683-7", "The Shining" },
                    { new Guid("ea98eb91-35a7-4638-8d81-9df9bcf55e47"), new Guid("d35ffd89-61e4-4887-a791-900edfd36d69"), null, "978-0-14-200174-5", "The Secret Life of Bees" },
                    { new Guid("eb8227df-e352-4659-851a-f36106186a9a"), new Guid("10615a81-8d9b-4099-9822-4081efd7a4ad"), "John Green's heart-wrenching novel about two teenagers with cancer who fall in love.", "978-0-14-242417-9", "The Fault in Our Stars" },
                    { new Guid("ef708df4-7cc7-4b5f-8b78-6c5104f8e100"), new Guid("143b8492-16d6-486b-9f89-c5b08dd62117"), "Dan Brown's gripping mystery involving symbology, art, and secret societies.", "978-0-30-747427-8", "The Da Vinci Code" },
                    { new Guid("f160540c-8401-4be1-ba0d-a9f75734d158"), new Guid("d35ffd89-61e4-4887-a791-900edfd36d69"), "A timeless tale of love, manners, and societal expectations in Regency-era England by Jane Austen.", "978-0-14-143951-8", "Pride and Prejudice" },
                    { new Guid("f417d3f1-9e2e-4035-b878-71a1f5a82c0c"), new Guid("6de5652f-7d06-44e8-bffd-541d99f45dbc"), "Ken Kesey's classic novel set in a mental hospital, challenging authority and celebrating individuality.", "978-0-45-116396-7", "One Flew Over the Cuckoo's Nest" },
                    { new Guid("f5a7f53c-0fa7-4d10-94c4-beba2e0cbbdd"), new Guid("d35ffd89-61e4-4887-a791-900edfd36d69"), "Stieg Larsson's gripping mystery featuring investigative journalist Mikael Blomkvist and the enigmatic hacker Lisbeth Salander.", "978-0-30-726975-1", "The Girl with the Dragon Tattoo" },
                    { new Guid("f6d21620-e4db-4380-a28c-e1619eb88fd6"), new Guid("58a4d4b6-d03b-4b2c-ac7b-e639bdce2068"), "Cormac McCarthy's post-apocalyptic tale of a father and son's harrowing journey through a desolate landscape.", "978-0-30-738789-9", "The Road" },
                    { new Guid("fa121db7-0442-451e-a664-3945d213ba28"), new Guid("f4f0c1ad-c4d7-4ad3-9831-d17654c98836"), "Margaret Atwood's dystopian novel set in the Republic of Gilead, where women's rights are severely restricted.", "978-0-38-549081-8", "The Handmaid's Tale" },
                    { new Guid("fbaad571-7547-4f12-8541-ff4c011d6482"), new Guid("87c47796-9894-455c-89c4-d548e9796f52"), "Kathryn Stockett's novel about African American maids working in white households in Jackson, Mississippi, during the early 1960s.", "978-0-42-523220-0", "The Help" },
                    { new Guid("fdaff6b9-0881-449f-b921-d9853cd2d725"), new Guid("19505c06-e688-41db-8d00-1561dd1ea93c"), "Charles Duhigg's exploration of the science behind habits and how they can be transformed.", "978-0-81-298160-5", "The Power of Habit" }
                });

            migrationBuilder.InsertData(
                table: "BooksGenres",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { new Guid("529ee040-5ed8-42ed-be65-e05c4be21528"), new Guid("0cf8b380-2197-475e-b2a3-58933b2b28da") },
                    { new Guid("687ab10d-302d-424a-88d7-cc3fb53bdc2b"), new Guid("0cf8b380-2197-475e-b2a3-58933b2b28da") },
                    { new Guid("7baa369b-b5d5-419b-b1df-78f31306e129"), new Guid("0cf8b380-2197-475e-b2a3-58933b2b28da") },
                    { new Guid("bc79faf2-e3e5-4056-8f61-4b9d6b69aadd"), new Guid("0cf8b380-2197-475e-b2a3-58933b2b28da") },
                    { new Guid("c466c891-c61d-4cb8-baca-a61ae803b5f2"), new Guid("0cf8b380-2197-475e-b2a3-58933b2b28da") },
                    { new Guid("cd57b50b-3734-43d7-9229-4f656d8d6aa6"), new Guid("0cf8b380-2197-475e-b2a3-58933b2b28da") },
                    { new Guid("f417d3f1-9e2e-4035-b878-71a1f5a82c0c"), new Guid("0cf8b380-2197-475e-b2a3-58933b2b28da") },
                    { new Guid("1475e87b-c7e8-4372-8de5-2bd6b17bb4d2"), new Guid("16f86a14-951e-4d5d-a8a2-1b851bfedbf0") },
                    { new Guid("725187d4-fa2a-4bee-9cb8-1ed031088cb7"), new Guid("16f86a14-951e-4d5d-a8a2-1b851bfedbf0") },
                    { new Guid("eb8227df-e352-4659-851a-f36106186a9a"), new Guid("16f86a14-951e-4d5d-a8a2-1b851bfedbf0") },
                    { new Guid("39c21217-e288-4b21-90da-68dbec7b7e8f"), new Guid("1f7e00a3-33bc-40e3-86cb-0cc3d5960bd9") },
                    { new Guid("479298bc-c19e-4bd4-9246-3e7800f2e5d5"), new Guid("1f7e00a3-33bc-40e3-86cb-0cc3d5960bd9") },
                    { new Guid("5e3eda09-3e3a-442f-afaf-c068082934df"), new Guid("1f7e00a3-33bc-40e3-86cb-0cc3d5960bd9") },
                    { new Guid("5f6c0fa6-e5ad-4066-8f69-82f74491259d"), new Guid("1f7e00a3-33bc-40e3-86cb-0cc3d5960bd9") },
                    { new Guid("669fb617-f96d-47cf-b3bd-359569fb4aa7"), new Guid("1f7e00a3-33bc-40e3-86cb-0cc3d5960bd9") },
                    { new Guid("abe7d045-c701-4d61-81b1-b7d1d2f28c39"), new Guid("1f7e00a3-33bc-40e3-86cb-0cc3d5960bd9") },
                    { new Guid("e170cc7a-e522-41ce-bc8a-21a3fabce3f6"), new Guid("1f7e00a3-33bc-40e3-86cb-0cc3d5960bd9") },
                    { new Guid("fbaad571-7547-4f12-8541-ff4c011d6482"), new Guid("1f7e00a3-33bc-40e3-86cb-0cc3d5960bd9") },
                    { new Guid("86b2636c-0f1c-44f8-ade9-e9437f5bd1da"), new Guid("2407f9f6-9366-44cc-a778-a6542fbf117d") },
                    { new Guid("ef708df4-7cc7-4b5f-8b78-6c5104f8e100"), new Guid("2407f9f6-9366-44cc-a778-a6542fbf117d") },
                    { new Guid("f417d3f1-9e2e-4035-b878-71a1f5a82c0c"), new Guid("2407f9f6-9366-44cc-a778-a6542fbf117d") },
                    { new Guid("39c21217-e288-4b21-90da-68dbec7b7e8f"), new Guid("3552e9af-420f-4ac5-b2a7-1c2df67ea04d") },
                    { new Guid("91a21725-f427-48a8-929c-c3e91dbba110"), new Guid("3552e9af-420f-4ac5-b2a7-1c2df67ea04d") },
                    { new Guid("a4ed7151-9852-4c9c-92db-a705664345ea"), new Guid("3552e9af-420f-4ac5-b2a7-1c2df67ea04d") },
                    { new Guid("aa47c42b-d820-42aa-bd2f-f1244e75e31c"), new Guid("3552e9af-420f-4ac5-b2a7-1c2df67ea04d") },
                    { new Guid("c466c891-c61d-4cb8-baca-a61ae803b5f2"), new Guid("3552e9af-420f-4ac5-b2a7-1c2df67ea04d") },
                    { new Guid("d55f22a5-3078-4960-bdd7-3bccff1d14cc"), new Guid("3552e9af-420f-4ac5-b2a7-1c2df67ea04d") },
                    { new Guid("f160540c-8401-4be1-ba0d-a9f75734d158"), new Guid("3552e9af-420f-4ac5-b2a7-1c2df67ea04d") },
                    { new Guid("f5a7f53c-0fa7-4d10-94c4-beba2e0cbbdd"), new Guid("3552e9af-420f-4ac5-b2a7-1c2df67ea04d") },
                    { new Guid("5f6c0fa6-e5ad-4066-8f69-82f74491259d"), new Guid("3af32f58-6e4f-4cda-8ab5-e2a3c2930109") },
                    { new Guid("687ab10d-302d-424a-88d7-cc3fb53bdc2b"), new Guid("3af32f58-6e4f-4cda-8ab5-e2a3c2930109") },
                    { new Guid("8cb48997-f476-4cfc-9ef2-ef89af50fd3c"), new Guid("3af32f58-6e4f-4cda-8ab5-e2a3c2930109") },
                    { new Guid("c76dd43e-0e97-4692-84cb-8d4f2b8451df"), new Guid("3af32f58-6e4f-4cda-8ab5-e2a3c2930109") },
                    { new Guid("cd57b50b-3734-43d7-9229-4f656d8d6aa6"), new Guid("3af32f58-6e4f-4cda-8ab5-e2a3c2930109") },
                    { new Guid("e170cc7a-e522-41ce-bc8a-21a3fabce3f6"), new Guid("3af32f58-6e4f-4cda-8ab5-e2a3c2930109") },
                    { new Guid("fa121db7-0442-451e-a664-3945d213ba28"), new Guid("3af32f58-6e4f-4cda-8ab5-e2a3c2930109") },
                    { new Guid("23030c7e-bb55-4ce2-aefa-bba3cf25bf97"), new Guid("3e9f2549-c5f1-49bc-a5c7-642104b6321e") },
                    { new Guid("41dd2dd8-7c58-4ab8-9ea1-b35c57366080"), new Guid("3e9f2549-c5f1-49bc-a5c7-642104b6321e") },
                    { new Guid("7baa369b-b5d5-419b-b1df-78f31306e129"), new Guid("3e9f2549-c5f1-49bc-a5c7-642104b6321e") },
                    { new Guid("9cece5b1-d2c5-4f34-a19f-54ee61b76b47"), new Guid("3e9f2549-c5f1-49bc-a5c7-642104b6321e") },
                    { new Guid("fbaad571-7547-4f12-8541-ff4c011d6482"), new Guid("3e9f2549-c5f1-49bc-a5c7-642104b6321e") },
                    { new Guid("539f03dd-b40a-402b-bc78-02f909b97538"), new Guid("4d56568a-f1f7-46a0-b2aa-a5cf89f033f3") },
                    { new Guid("a823a0cc-6a32-474a-b4b2-37c94549327f"), new Guid("4d56568a-f1f7-46a0-b2aa-a5cf89f033f3") },
                    { new Guid("c2e43fe6-58ab-4aa7-bacd-49b175d565ad"), new Guid("4d56568a-f1f7-46a0-b2aa-a5cf89f033f3") },
                    { new Guid("d2030d67-e15c-4ccc-b5ea-e769be2dbe17"), new Guid("4d56568a-f1f7-46a0-b2aa-a5cf89f033f3") },
                    { new Guid("fa121db7-0442-451e-a664-3945d213ba28"), new Guid("4d56568a-f1f7-46a0-b2aa-a5cf89f033f3") },
                    { new Guid("539f03dd-b40a-402b-bc78-02f909b97538"), new Guid("5f9b5fb9-506d-4c07-80ef-e5b7fcc3b6f2") },
                    { new Guid("5e3eda09-3e3a-442f-afaf-c068082934df"), new Guid("5f9b5fb9-506d-4c07-80ef-e5b7fcc3b6f2") },
                    { new Guid("cb38da87-20f3-4540-83d0-032e6a87d35d"), new Guid("5f9b5fb9-506d-4c07-80ef-e5b7fcc3b6f2") },
                    { new Guid("e170cc7a-e522-41ce-bc8a-21a3fabce3f6"), new Guid("5f9b5fb9-506d-4c07-80ef-e5b7fcc3b6f2") },
                    { new Guid("ea98eb91-35a7-4638-8d81-9df9bcf55e47"), new Guid("5f9b5fb9-506d-4c07-80ef-e5b7fcc3b6f2") },
                    { new Guid("eb8227df-e352-4659-851a-f36106186a9a"), new Guid("5f9b5fb9-506d-4c07-80ef-e5b7fcc3b6f2") },
                    { new Guid("f5a7f53c-0fa7-4d10-94c4-beba2e0cbbdd"), new Guid("5f9b5fb9-506d-4c07-80ef-e5b7fcc3b6f2") },
                    { new Guid("fdaff6b9-0881-449f-b921-d9853cd2d725"), new Guid("5f9b5fb9-506d-4c07-80ef-e5b7fcc3b6f2") },
                    { new Guid("b8b260e2-448e-4d31-9cdf-1f36013f70de"), new Guid("600d8d8a-a57a-4fa9-83ec-40fa7ebe45ba") },
                    { new Guid("d55f22a5-3078-4960-bdd7-3bccff1d14cc"), new Guid("600d8d8a-a57a-4fa9-83ec-40fa7ebe45ba") },
                    { new Guid("6cb782b0-5ca8-403a-b6b3-1c1f5440ec2e"), new Guid("6fdde76f-4321-4d4a-a7ed-83ed682a6d62") },
                    { new Guid("84914b05-f2c9-4346-a656-8bd4a5bc3e40"), new Guid("6fdde76f-4321-4d4a-a7ed-83ed682a6d62") },
                    { new Guid("86aa7b8b-07d0-4f57-b5e5-f01f676dbe69"), new Guid("6fdde76f-4321-4d4a-a7ed-83ed682a6d62") },
                    { new Guid("aa47c42b-d820-42aa-bd2f-f1244e75e31c"), new Guid("6fdde76f-4321-4d4a-a7ed-83ed682a6d62") },
                    { new Guid("ef708df4-7cc7-4b5f-8b78-6c5104f8e100"), new Guid("6fdde76f-4321-4d4a-a7ed-83ed682a6d62") },
                    { new Guid("539f03dd-b40a-402b-bc78-02f909b97538"), new Guid("a4adf827-2747-40d7-801b-07115f9f0082") },
                    { new Guid("943df911-4772-4185-9857-1ca1aa395206"), new Guid("a4adf827-2747-40d7-801b-07115f9f0082") },
                    { new Guid("9cece5b1-d2c5-4f34-a19f-54ee61b76b47"), new Guid("a4adf827-2747-40d7-801b-07115f9f0082") },
                    { new Guid("a4ed7151-9852-4c9c-92db-a705664345ea"), new Guid("a4adf827-2747-40d7-801b-07115f9f0082") },
                    { new Guid("4be039c0-322c-49ea-909d-f5967ad47cf2"), new Guid("b621b43e-4639-44c1-9a30-9aaa12b2ac80") },
                    { new Guid("566c9af3-6bbb-45a4-81f0-5d8572a8e577"), new Guid("b621b43e-4639-44c1-9a30-9aaa12b2ac80") },
                    { new Guid("89bb92e6-7847-4bfe-8d30-026a3a0519bb"), new Guid("b621b43e-4639-44c1-9a30-9aaa12b2ac80") },
                    { new Guid("fdaff6b9-0881-449f-b921-d9853cd2d725"), new Guid("b621b43e-4639-44c1-9a30-9aaa12b2ac80") },
                    { new Guid("c2e43fe6-58ab-4aa7-bacd-49b175d565ad"), new Guid("bc6621c3-2a57-4271-8820-93d94501eeba") },
                    { new Guid("479298bc-c19e-4bd4-9246-3e7800f2e5d5"), new Guid("ce160fd7-cb8c-4185-99e2-f398e52678cc") },
                    { new Guid("6cb782b0-5ca8-403a-b6b3-1c1f5440ec2e"), new Guid("ce160fd7-cb8c-4185-99e2-f398e52678cc") },
                    { new Guid("725187d4-fa2a-4bee-9cb8-1ed031088cb7"), new Guid("ce160fd7-cb8c-4185-99e2-f398e52678cc") },
                    { new Guid("c2e43fe6-58ab-4aa7-bacd-49b175d565ad"), new Guid("ce160fd7-cb8c-4185-99e2-f398e52678cc") },
                    { new Guid("c466c891-c61d-4cb8-baca-a61ae803b5f2"), new Guid("ce160fd7-cb8c-4185-99e2-f398e52678cc") },
                    { new Guid("c76dd43e-0e97-4692-84cb-8d4f2b8451df"), new Guid("ce160fd7-cb8c-4185-99e2-f398e52678cc") },
                    { new Guid("d2030d67-e15c-4ccc-b5ea-e769be2dbe17"), new Guid("ce160fd7-cb8c-4185-99e2-f398e52678cc") },
                    { new Guid("f5a7f53c-0fa7-4d10-94c4-beba2e0cbbdd"), new Guid("ce160fd7-cb8c-4185-99e2-f398e52678cc") },
                    { new Guid("479298bc-c19e-4bd4-9246-3e7800f2e5d5"), new Guid("cfc35fd7-ff41-44bb-9779-dc0f98ad8eb2") },
                    { new Guid("628fc3a2-c351-4b6e-9a1d-d80d63711976"), new Guid("cfc35fd7-ff41-44bb-9779-dc0f98ad8eb2") },
                    { new Guid("725187d4-fa2a-4bee-9cb8-1ed031088cb7"), new Guid("cfc35fd7-ff41-44bb-9779-dc0f98ad8eb2") },
                    { new Guid("9cece5b1-d2c5-4f34-a19f-54ee61b76b47"), new Guid("cfc35fd7-ff41-44bb-9779-dc0f98ad8eb2") },
                    { new Guid("c466c891-c61d-4cb8-baca-a61ae803b5f2"), new Guid("cfc35fd7-ff41-44bb-9779-dc0f98ad8eb2") },
                    { new Guid("cb38da87-20f3-4540-83d0-032e6a87d35d"), new Guid("cfc35fd7-ff41-44bb-9779-dc0f98ad8eb2") },
                    { new Guid("a4ed7151-9852-4c9c-92db-a705664345ea"), new Guid("e0be5314-1296-4988-b09f-11fca7c85060") },
                    { new Guid("e170cc7a-e522-41ce-bc8a-21a3fabce3f6"), new Guid("e0be5314-1296-4988-b09f-11fca7c85060") },
                    { new Guid("f5a7f53c-0fa7-4d10-94c4-beba2e0cbbdd"), new Guid("e0be5314-1296-4988-b09f-11fca7c85060") },
                    { new Guid("fa121db7-0442-451e-a664-3945d213ba28"), new Guid("e0be5314-1296-4988-b09f-11fca7c85060") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_FullName",
                table: "Authors",
                column: "FullName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookHireItems_BookHireCardId",
                table: "BookHireItems",
                column: "BookHireCardId");

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
                name: "IX_Genres_Title",
                table: "Genres",
                column: "Title",
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
                name: "BooksHiresInfos");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
