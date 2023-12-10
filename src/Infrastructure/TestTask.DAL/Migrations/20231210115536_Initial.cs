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
                name: "BooksHireRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BooksHiredDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksHireRecords", x => x.Id);
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
                        name: "FK_BookHireItems_BooksHireRecords_BookHireCardId",
                        column: x => x.BookHireCardId,
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
                    { new Guid("07d015c0-f9ab-4b7f-8d79-5814e7d1c9c9"), "Charles Dickens" },
                    { new Guid("0cbf1bd2-4903-48f3-8af6-9c93f98a275f"), "Stephen King" },
                    { new Guid("0d2d8ecb-d12c-473c-b9c0-744c8bc84e68"), "Toni Morrison" },
                    { new Guid("112709e5-ab8c-49ba-8d00-7a05b4af57b2"), "H.G. Wells" },
                    { new Guid("1320e816-fc5c-48ca-b387-4c7466dde70a"), "Leo Tolstoy" },
                    { new Guid("14d8d575-50b3-4b42-9683-230504f81929"), "Harper Lee" },
                    { new Guid("204bb490-cfaa-4abe-bca5-b68f0811e192"), "William Shakespeare" },
                    { new Guid("20ec9081-64fc-42dc-a1ab-c104e0310038"), "F. Scott Fitzgerald" },
                    { new Guid("26ad2339-0398-4d2b-81f8-6fb7d390122b"), "Arthur Conan Doyle" },
                    { new Guid("33e67217-571b-4c40-b999-756bf5fef416"), "Roald Dahl" },
                    { new Guid("3e4fba9a-820f-44fd-93ac-7285f00ce3d6"), "Jane Goodall" },
                    { new Guid("43696775-19a7-4434-a966-6832cbdd4e4a"), "Homer" },
                    { new Guid("48d7aed9-71ce-48e8-8ff0-3d949890f170"), "Jane Austen" },
                    { new Guid("4e461607-e0dc-48d0-a793-87fb48476b11"), "J.K. Rowling" },
                    { new Guid("5577ffd5-7267-4879-b9d7-1c5b142573be"), "Virginia Woolf" },
                    { new Guid("5aa0c86e-b087-4463-b496-f49169f4d850"), "Gabriel García Márquez" },
                    { new Guid("61443c4d-da0e-4558-bb23-3f580fb305aa"), "Aldous Huxley" },
                    { new Guid("70635962-871c-4df3-8e21-b39b40841756"), "Mark Twain" },
                    { new Guid("78a23c68-16f5-48c1-9699-f0286af9520d"), "Hermann Hesse" },
                    { new Guid("8731e872-c681-4959-97d5-70cd647dc408"), "George Orwell" },
                    { new Guid("974f4769-8505-4fec-ab3c-9c385880dd35"), "Charlotte Brontë" },
                    { new Guid("9abfc4c3-e6de-4a86-87ec-0f366929a753"), "Ernest Hemingway" },
                    { new Guid("9cf6fa9f-36b9-4757-a63b-d4f56900f16a"), "J.R.R. Tolkien" },
                    { new Guid("a145f3dd-3438-45f5-8799-dc589a29b2df"), "Ayn Rand" },
                    { new Guid("a3e9299a-4f69-4544-82fd-57b97dcf4ff2"), "Michael Crichton" },
                    { new Guid("b2f23da5-e895-47a9-bac0-43f5e7c34c49"), "Agatha Christie" },
                    { new Guid("c6cdaed0-66d2-41a8-bec7-268b9e8c0341"), "Isaac Asimov" },
                    { new Guid("d8f7a8af-7615-41ea-86c8-5cc4acb2ec5e"), "Emily Brontë" },
                    { new Guid("e5781a17-42b9-4750-9649-6539f4518ea1"), "Margaret Atwood" },
                    { new Guid("f109dab5-3862-4ff4-b118-af80d78a5e4c"), "Kurt Vonnegut" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("1e97d279-6fcd-4cb0-890d-f849d55aa028"), "Science Fiction" },
                    { new Guid("280a590a-d271-4aea-a611-3a5110d7c307"), "Self-Help" },
                    { new Guid("31793010-aa4a-4ad0-937a-f22732b879d2"), "Drama" },
                    { new Guid("367cbf43-4b36-4ea4-80c3-2d44610a97df"), "Cookbook" },
                    { new Guid("4f68e0ca-9454-49ba-a717-37ddd37baffd"), "Adventure" },
                    { new Guid("540ed2c7-42cc-4993-939a-79b2431d2f36"), "Horror" },
                    { new Guid("5c8561b3-be12-4d49-86c5-20e9035332b2"), "Poetry" },
                    { new Guid("84168c71-5b07-45bd-a173-1c970be63d19"), "Non-Fiction" },
                    { new Guid("886eb3c5-1d40-4918-9b8a-8c30622aa845"), "Historical Fiction" },
                    { new Guid("8afd0124-87cf-4fdb-9290-c86f662b5f97"), "Fantasy" },
                    { new Guid("a31e573c-ac02-47c3-8df2-a1c412a2a2f9"), "Biography" },
                    { new Guid("a424dfa4-4847-4fb7-a8de-bb1216b67bd5"), "Business" },
                    { new Guid("bc6cb191-62b6-4a73-ae3a-2724a5b8290d"), "Romance" },
                    { new Guid("cf8a8236-bcdc-469c-b6b2-92586e7a1c95"), "Thriller" },
                    { new Guid("d0490315-87bf-4cf4-a5af-8c17bdeef0ca"), "Travel" },
                    { new Guid("dfd96a9e-019f-4447-b72a-e7368dab4848"), "Comedy" },
                    { new Guid("ed282ee5-5a04-4994-bfb4-f6d5c08172ea"), "Mystery" },
                    { new Guid("fec2d4ef-bb6e-474b-b4d5-27ed337a56fb"), "Science" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "ISBN", "Title" },
                values: new object[,]
                {
                    { new Guid("04bde369-9783-4f4f-bccb-127954847205"), new Guid("974f4769-8505-4fec-ab3c-9c385880dd35"), null, "978-0-14-200174-5", "The Secret Life of Bees" },
                    { new Guid("04ccdace-3199-4cc6-b451-b2dfb1d7166d"), new Guid("78a23c68-16f5-48c1-9699-f0286af9520d"), "Homer's ancient Greek epic, recounting the adventures of Odysseus as he journeys home from the Trojan War.", "978-0-14-303995-2", "The Odyssey" },
                    { new Guid("05a9ae8c-7ea1-4d6b-9f51-a95c5034e5f7"), new Guid("07d015c0-f9ab-4b7f-8d79-5814e7d1c9c9"), "Leo Tolstoy's epic portrayal of Russian society during the Napoleonic Wars, blending history, philosophy, and human drama.", "978-0-14-303500-8", "War and Peace" },
                    { new Guid("0d7c2367-a2f9-4cfd-b3eb-405ee8c80021"), new Guid("61443c4d-da0e-4558-bb23-3f580fb305aa"), "J.D. Salinger's iconic coming-of-age novel, capturing the angst and rebellion of a teenage boy in post-World War II America.", "978-0-31-676948-0", "The Catcher in the Rye" },
                    { new Guid("16b1eb99-4491-477d-802c-1ba0bc14d876"), new Guid("c6cdaed0-66d2-41a8-bec7-268b9e8c0341"), "Donna Tartt's Pulitzer Prize-winning novel about a young boy's life after a terrorist attack in a New York art museum.", "978-0-31-605543-7", "The Goldfinch" },
                    { new Guid("1de7f845-1fc2-4a6b-be48-dd7c30eb9ca6"), new Guid("8731e872-c681-4959-97d5-70cd647dc408"), "John Green's heart-wrenching novel about two teenagers with cancer who fall in love.", "978-0-14-242417-9", "The Fault in Our Stars" },
                    { new Guid("1e23212e-ad49-4002-a583-f7c57190c3e6"), new Guid("07d015c0-f9ab-4b7f-8d79-5814e7d1c9c9"), "Charles Duhigg's exploration of the science behind habits and how they can be transformed.", "978-0-81-298160-5", "The Power of Habit" },
                    { new Guid("25ce3359-b528-4253-9780-3c7498374184"), new Guid("70635962-871c-4df3-8e21-b39b40841756"), null, "978-0-19-921613-3", "Alice's Adventures in Wonderland" },
                    { new Guid("2bd39a08-3aa5-4e04-948d-a8430aa16956"), new Guid("a3e9299a-4f69-4544-82fd-57b97dcf4ff2"), "Jeannette Walls's memoir detailing her unconventional and often troubled childhood.", "978-0-74-324754-5", "The Glass Castle" },
                    { new Guid("30e4ea88-c798-4c3d-b8cc-0ea72ca32307"), new Guid("14d8d575-50b3-4b42-9683-230504f81929"), "Suzanne Collins's dystopian saga of Katniss Everdeen's fight for survival in the annual Hunger Games.", "978-0-43-902352-8", "The Hunger Games" },
                    { new Guid("32483bf5-7acb-46db-9e20-c2c06ee16e25"), new Guid("20ec9081-64fc-42dc-a1ab-c104e0310038"), "A timeless tale of love, manners, and societal expectations in Regency-era England by Jane Austen.", "978-0-14-143951-8", "Pride and Prejudice" },
                    { new Guid("35cf7e97-d9f8-4234-9cfe-3b366e0bb8ec"), new Guid("14d8d575-50b3-4b42-9683-230504f81929"), "Harper Lee's powerful exploration of racial injustice and moral growth in the American South.", "978-0-06-112348-4", "To Kill a Mockingbird" },
                    { new Guid("361fc05f-f508-404e-a408-377d7b82f396"), new Guid("07d015c0-f9ab-4b7f-8d79-5814e7d1c9c9"), "M. Scott Peck's exploration of personal growth, love, and spiritual development.", "978-0-74-324315-8", "The Road Less Traveled" },
                    { new Guid("39319952-1ce2-4760-86d3-b60913c4ce7e"), new Guid("9cf6fa9f-36b9-4757-a63b-d4f56900f16a"), "J.R.R. Tolkien's epic fantasy trilogy, featuring the quest to destroy the One Ring and save Middle-earth from the dark forces of Sauron.", "978-0-54-400341-5", "The Lord of the Rings" },
                    { new Guid("449af876-9bb1-473f-abcd-72430f317d7a"), new Guid("112709e5-ab8c-49ba-8d00-7a05b4af57b2"), "Erin Morgenstern's magical tale of a mysterious competition between two illusionists in a magical circus.", "978-0-38-553970-6", "The Night Circus" },
                    { new Guid("4b627856-6a2f-46b5-bc00-e4832261aba5"), new Guid("e5781a17-42b9-4750-9649-6539f4518ea1"), "Mary Shelley's gothic tale of scientific hubris and the consequences of creating life.", "978-0-48-628211-4", "Frankenstein" },
                    { new Guid("4fbd62c4-67ea-409c-8220-bd6deb08a022"), new Guid("9cf6fa9f-36b9-4757-a63b-d4f56900f16a"), null, "978-0-06-085052-4", "Brave New World" },
                    { new Guid("52651f51-aa2b-4576-b85d-7d55412ffb14"), new Guid("e5781a17-42b9-4750-9649-6539f4518ea1"), "Fyodor Dostoevsky's exploration of morality, faith, and family dynamics through the complex relationships of the Karamazov brothers.", "978-0-14-044924-2", "The Brothers Karamazov" },
                    { new Guid("5a46172a-0bfe-42b8-b33e-845cd8e6f31b"), new Guid("9cf6fa9f-36b9-4757-a63b-d4f56900f16a"), null, "978-1-25-030169-7", "The Silent Patient" },
                    { new Guid("5a6be7ef-5910-4645-9fe7-b879f87f8376"), new Guid("61443c4d-da0e-4558-bb23-3f580fb305aa"), "Paulo Coelho's philosophical novel about Santiago, a shepherd boy, on a journey to discover his personal legend.", "978-0-06-112241-5", "The Alchemist" },
                    { new Guid("5ae1513a-72da-479d-aad8-345b3b0ec449"), new Guid("33e67217-571b-4c40-b999-756bf5fef416"), "Ken Kesey's classic novel set in a mental hospital, challenging authority and celebrating individuality.", "978-0-45-116396-7", "One Flew Over the Cuckoo's Nest" },
                    { new Guid("5d9e498c-7242-446e-a08e-fb2a0d28d6c8"), new Guid("8731e872-c681-4959-97d5-70cd647dc408"), "Douglas Adams's hilarious space adventure, following the misadventures of Arthur Dent and his extraterrestrial friend Ford Prefect.", "978-0-34-539180-3", "The Hitchhiker's Guide to the Galaxy" },
                    { new Guid("5ddc5e73-b22e-476a-8941-ede5c97bceda"), new Guid("b2f23da5-e895-47a9-bac0-43f5e7c34c49"), "Rebecca Skloot's biography exploring the life and legacy of Henrietta Lacks, whose cells were used for medical research without her knowledge.", "978-1-40-005217-2", "The Immortal Life of Henrietta Lacks" },
                    { new Guid("5e2310d6-4a6e-4050-90ef-f553af25b06a"), new Guid("b2f23da5-e895-47a9-bac0-43f5e7c34c49"), "F. Scott Fitzgerald's classic portrayal of the American Dream, excess, and disillusionment in the Roaring Twenties.", "978-0-74-327356-5", "The Great Gatsby" },
                    { new Guid("5e6d852c-4644-4925-b036-b4d2aa2d0b6c"), new Guid("20ec9081-64fc-42dc-a1ab-c104e0310038"), null, "978-0-14-044022-5", "The Three Musketeers" },
                    { new Guid("76a166a8-702b-41c3-930a-2ec6886c2282"), new Guid("112709e5-ab8c-49ba-8d00-7a05b4af57b2"), null, "978-0-14-143955-6", "Wuthering Heights" },
                    { new Guid("794cc4e5-e040-44d4-973b-fb0c9524243e"), new Guid("a3e9299a-4f69-4544-82fd-57b97dcf4ff2"), "Joseph Heller's satirical novel depicting the absurdities and paradoxes of war.", "978-0-68-484121-9", "The Catch-22" },
                    { new Guid("86c9054f-4706-40ae-8934-a74c2ae2cf82"), new Guid("61443c4d-da0e-4558-bb23-3f580fb305aa"), null, "978-0-45-141943-9", "Les Misérables" },
                    { new Guid("8719aedf-8573-4b23-9415-17a52520c15d"), new Guid("a145f3dd-3438-45f5-8799-dc589a29b2df"), "Geoffrey Chaucer's collection of stories told by a diverse group of pilgrims on their journey to Canterbury.", "978-0-14-042234-4", "The Canterbury Tales" },
                    { new Guid("8d5b05af-d8e1-4971-a041-e3a26d9d1ef8"), new Guid("4e461607-e0dc-48d0-a793-87fb48476b11"), null, "978-0-14-143957-0", "The Picture of Dorian Gray" },
                    { new Guid("8de54f39-bd87-44a6-b8ce-143dcb84cb58"), new Guid("974f4769-8505-4fec-ab3c-9c385880dd35"), "Yuval Noah Harari's exploration of the history and impact of Homo sapiens on the world.", "978-0-99-711060-8", "Sapiens: A Brief History of Humankind" },
                    { new Guid("9112e3f2-90fb-4058-9bd4-0e3c97260d0b"), new Guid("33e67217-571b-4c40-b999-756bf5fef416"), "Andy Weir's gripping science fiction novel about an astronaut stranded on Mars and his fight for survival.", "978-0-55-341802-6", "The Martian" },
                    { new Guid("9236b0bb-8b02-4622-ab0f-dc0edcd438ea"), new Guid("9cf6fa9f-36b9-4757-a63b-d4f56900f16a"), "Herman Melville's epic journey aboard the whaling ship Pequod, driven by Captain Ahab's obsessive quest for the white whale.", "978-0-14-310635-7", "Moby-Dick" },
                    { new Guid("9d6e1376-c16a-46a3-bb3e-be0c5c73e8f1"), new Guid("a3e9299a-4f69-4544-82fd-57b97dcf4ff2"), null, "978-0-37-584220-7", "The Book Thief" },
                    { new Guid("9e4d7b86-96fe-4ac3-8c5e-eadf575b6f0f"), new Guid("112709e5-ab8c-49ba-8d00-7a05b4af57b2"), "George Orwell's dystopian masterpiece, depicting a nightmarish future under totalitarian rule.", "978-0-45-152493-5", "1984" },
                    { new Guid("9e98364e-8405-4cb4-abe0-bd609d63990e"), new Guid("78a23c68-16f5-48c1-9699-f0286af9520d"), "Margaret Atwood's dystopian novel set in the Republic of Gilead, where women's rights are severely restricted.", "978-0-38-549081-8", "The Handmaid's Tale" },
                    { new Guid("a57a1ae7-bd27-40f6-ad10-67939a8b1e11"), new Guid("4e461607-e0dc-48d0-a793-87fb48476b11"), "John Steinbeck's novel depicting the struggles of a displaced Oklahoma family during the Great Depression.", "978-0-14-303943-3", "The Grapes of Wrath" },
                    { new Guid("a7b7e1a8-10d0-409f-aa2a-515e6c5d6a11"), new Guid("e5781a17-42b9-4750-9649-6539f4518ea1"), "Kathryn Stockett's novel about African American maids working in white households in Jackson, Mississippi, during the early 1960s.", "978-0-42-523220-0", "The Help" },
                    { new Guid("aba9cab5-87d9-498e-b33d-55dede2868a1"), new Guid("33e67217-571b-4c40-b999-756bf5fef416"), null, "978-0-06-112028-4", "One Hundred Years of Solitude" },
                    { new Guid("ac789dc9-d197-42e7-95cf-6b304e114d97"), new Guid("33e67217-571b-4c40-b999-756bf5fef416"), "Stephen King's chilling tale of supernatural horror, isolation, and the descent into madness at the haunted Overlook Hotel.", "978-0-38-511683-7", "The Shining" },
                    { new Guid("b32ec0d2-6e3b-427f-9cc8-597e40f4cda1"), new Guid("5577ffd5-7267-4879-b9d7-1c5b142573be"), null, "978-0-15-602835-6", "The Color Purple" },
                    { new Guid("b71299e3-1fd8-4c20-82b7-8534d7192fee"), new Guid("0cbf1bd2-4903-48f3-8af6-9c93f98a275f"), "C.S. Lewis's beloved fantasy series, taking readers to the enchanting land of Narnia and its magical inhabitants.", "978-0-06-112008-4", "The Chronicles of Narnia" },
                    { new Guid("c4145f93-1f53-441e-9da7-b09cb491e471"), new Guid("a3e9299a-4f69-4544-82fd-57b97dcf4ff2"), null, "978-0-54-792822-7", "The Hobbit" },
                    { new Guid("c797f182-dfec-4e29-b786-7ff01f52b16a"), new Guid("0cbf1bd2-4903-48f3-8af6-9c93f98a275f"), "Haruki Murakami's surreal and mesmerizing novel exploring the mysteries of human consciousness.", "978-0-67-977543-0", "The Wind-Up Bird Chronicle" },
                    { new Guid("c85fda10-242a-4bdd-a198-ffa279267c7c"), new Guid("a145f3dd-3438-45f5-8799-dc589a29b2df"), "Stieg Larsson's gripping mystery featuring investigative journalist Mikael Blomkvist and the enigmatic hacker Lisbeth Salander.", "978-0-30-726975-1", "The Girl with the Dragon Tattoo" },
                    { new Guid("d5d90bb0-778e-404a-a20b-5a00a50b554f"), new Guid("33e67217-571b-4c40-b999-756bf5fef416"), "Dan Brown's gripping mystery involving symbology, art, and secret societies.", "978-0-30-747427-8", "The Da Vinci Code" },
                    { new Guid("d6cbaec8-d022-40ff-94f9-88bb56092ab7"), new Guid("33e67217-571b-4c40-b999-756bf5fef416"), "J.K. Rowling's enchanting introduction to the wizarding world, filled with magic, friendship, and adventure.", "978-0-59-035342-7", "Harry Potter and the Sorcerer's Stone" },
                    { new Guid("e188d537-aa54-4957-b1d2-8d5246958b80"), new Guid("5aa0c86e-b087-4463-b496-f49169f4d850"), "Khaled Hosseini's powerful novel about friendship, betrayal, and redemption in Afghanistan.", "978-1-59-463193-1", "The Kite Runner" },
                    { new Guid("e546ad0f-2795-4d1f-833a-da6fd55d50fa"), new Guid("48d7aed9-71ce-48e8-8ff0-3d949890f170"), "Paula Hawkins's psychological thriller about a woman who becomes entangled in a missing person investigation.", "978-1-59-463402-4", "The Girl on the Train" },
                    { new Guid("e887fcc3-0106-4e31-b02b-8245e242bd5b"), new Guid("a145f3dd-3438-45f5-8799-dc589a29b2df"), "Alexandre Dumas's classic adventure novel of betrayal, revenge, and redemption.", "978-0-14-044926-6", "The Count of Monte Cristo" },
                    { new Guid("e8ad3bf9-02cb-434b-b506-8498e2aa5f40"), new Guid("b2f23da5-e895-47a9-bac0-43f5e7c34c49"), "Cormac McCarthy's post-apocalyptic tale of a father and son's harrowing journey through a desolate landscape.", "978-0-30-738789-9", "The Road" },
                    { new Guid("f21d7ce6-d689-4db2-9ab2-280ede4a35fd"), new Guid("33e67217-571b-4c40-b999-756bf5fef416"), "Fyodor Dostoevsky's psychological thriller, exploring the moral and psychological turmoil of a young man in St. Petersburg.", "978-0-14-310763-7", "Crime and Punishment" },
                    { new Guid("f84e5fa9-217d-474c-9f17-d530ab7d578a"), new Guid("78a23c68-16f5-48c1-9699-f0286af9520d"), "Amy Tan's novel exploring the relationships between Chinese-American immigrant mothers and their American-born daughters.", "978-0-80-417839-9", "The Joy Luck Club" },
                    { new Guid("f96235ab-5701-4f3c-9ec6-ecb30dd0f149"), new Guid("0cbf1bd2-4903-48f3-8af6-9c93f98a275f"), "Frank Herbert's science fiction epic set in a distant future where noble houses vie for control of the desert planet Arrakis and its valuable spice melange.", "978-0-44-117271-9", "Dune" },
                    { new Guid("fa33b40b-28d2-4835-bf96-8b3ec7cace90"), new Guid("5577ffd5-7267-4879-b9d7-1c5b142573be"), "Tara Westover's memoir recounting her journey from a rural Idaho childhood to gaining an education against all odds.", "978-0-52-558019-4", "Educated" },
                    { new Guid("ff6b8997-0c57-4494-9856-0660944c9e1c"), new Guid("5577ffd5-7267-4879-b9d7-1c5b142573be"), null, "978-0-52-551488-0", "The Immortalists" }
                });

            migrationBuilder.InsertData(
                table: "BooksGenres",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { new Guid("0d7c2367-a2f9-4cfd-b3eb-405ee8c80021"), new Guid("1e97d279-6fcd-4cb0-890d-f849d55aa028") },
                    { new Guid("1de7f845-1fc2-4a6b-be48-dd7c30eb9ca6"), new Guid("1e97d279-6fcd-4cb0-890d-f849d55aa028") },
                    { new Guid("5a46172a-0bfe-42b8-b33e-845cd8e6f31b"), new Guid("1e97d279-6fcd-4cb0-890d-f849d55aa028") },
                    { new Guid("e546ad0f-2795-4d1f-833a-da6fd55d50fa"), new Guid("1e97d279-6fcd-4cb0-890d-f849d55aa028") },
                    { new Guid("e887fcc3-0106-4e31-b02b-8245e242bd5b"), new Guid("1e97d279-6fcd-4cb0-890d-f849d55aa028") },
                    { new Guid("e8ad3bf9-02cb-434b-b506-8498e2aa5f40"), new Guid("1e97d279-6fcd-4cb0-890d-f849d55aa028") },
                    { new Guid("5a6be7ef-5910-4645-9fe7-b879f87f8376"), new Guid("280a590a-d271-4aea-a611-3a5110d7c307") },
                    { new Guid("794cc4e5-e040-44d4-973b-fb0c9524243e"), new Guid("280a590a-d271-4aea-a611-3a5110d7c307") },
                    { new Guid("04ccdace-3199-4cc6-b451-b2dfb1d7166d"), new Guid("31793010-aa4a-4ad0-937a-f22732b879d2") },
                    { new Guid("1de7f845-1fc2-4a6b-be48-dd7c30eb9ca6"), new Guid("31793010-aa4a-4ad0-937a-f22732b879d2") },
                    { new Guid("35cf7e97-d9f8-4234-9cfe-3b366e0bb8ec"), new Guid("31793010-aa4a-4ad0-937a-f22732b879d2") },
                    { new Guid("39319952-1ce2-4760-86d3-b60913c4ce7e"), new Guid("31793010-aa4a-4ad0-937a-f22732b879d2") },
                    { new Guid("5e2310d6-4a6e-4050-90ef-f553af25b06a"), new Guid("31793010-aa4a-4ad0-937a-f22732b879d2") },
                    { new Guid("b71299e3-1fd8-4c20-82b7-8534d7192fee"), new Guid("31793010-aa4a-4ad0-937a-f22732b879d2") },
                    { new Guid("c4145f93-1f53-441e-9da7-b09cb491e471"), new Guid("31793010-aa4a-4ad0-937a-f22732b879d2") },
                    { new Guid("f84e5fa9-217d-474c-9f17-d530ab7d578a"), new Guid("31793010-aa4a-4ad0-937a-f22732b879d2") },
                    { new Guid("04bde369-9783-4f4f-bccb-127954847205"), new Guid("367cbf43-4b36-4ea4-80c3-2d44610a97df") },
                    { new Guid("32483bf5-7acb-46db-9e20-c2c06ee16e25"), new Guid("367cbf43-4b36-4ea4-80c3-2d44610a97df") },
                    { new Guid("76a166a8-702b-41c3-930a-2ec6886c2282"), new Guid("367cbf43-4b36-4ea4-80c3-2d44610a97df") },
                    { new Guid("9d6e1376-c16a-46a3-bb3e-be0c5c73e8f1"), new Guid("367cbf43-4b36-4ea4-80c3-2d44610a97df") },
                    { new Guid("d5d90bb0-778e-404a-a20b-5a00a50b554f"), new Guid("367cbf43-4b36-4ea4-80c3-2d44610a97df") },
                    { new Guid("1e23212e-ad49-4002-a583-f7c57190c3e6"), new Guid("4f68e0ca-9454-49ba-a717-37ddd37baffd") },
                    { new Guid("5a6be7ef-5910-4645-9fe7-b879f87f8376"), new Guid("4f68e0ca-9454-49ba-a717-37ddd37baffd") },
                    { new Guid("9e4d7b86-96fe-4ac3-8c5e-eadf575b6f0f"), new Guid("4f68e0ca-9454-49ba-a717-37ddd37baffd") },
                    { new Guid("c797f182-dfec-4e29-b786-7ff01f52b16a"), new Guid("4f68e0ca-9454-49ba-a717-37ddd37baffd") },
                    { new Guid("d5d90bb0-778e-404a-a20b-5a00a50b554f"), new Guid("4f68e0ca-9454-49ba-a717-37ddd37baffd") },
                    { new Guid("32483bf5-7acb-46db-9e20-c2c06ee16e25"), new Guid("540ed2c7-42cc-4993-939a-79b2431d2f36") },
                    { new Guid("8de54f39-bd87-44a6-b8ce-143dcb84cb58"), new Guid("540ed2c7-42cc-4993-939a-79b2431d2f36") },
                    { new Guid("9d6e1376-c16a-46a3-bb3e-be0c5c73e8f1"), new Guid("540ed2c7-42cc-4993-939a-79b2431d2f36") },
                    { new Guid("ac789dc9-d197-42e7-95cf-6b304e114d97"), new Guid("540ed2c7-42cc-4993-939a-79b2431d2f36") },
                    { new Guid("b32ec0d2-6e3b-427f-9cc8-597e40f4cda1"), new Guid("540ed2c7-42cc-4993-939a-79b2431d2f36") },
                    { new Guid("16b1eb99-4491-477d-802c-1ba0bc14d876"), new Guid("5c8561b3-be12-4d49-86c5-20e9035332b2") },
                    { new Guid("32483bf5-7acb-46db-9e20-c2c06ee16e25"), new Guid("5c8561b3-be12-4d49-86c5-20e9035332b2") },
                    { new Guid("5d9e498c-7242-446e-a08e-fb2a0d28d6c8"), new Guid("5c8561b3-be12-4d49-86c5-20e9035332b2") },
                    { new Guid("b71299e3-1fd8-4c20-82b7-8534d7192fee"), new Guid("5c8561b3-be12-4d49-86c5-20e9035332b2") },
                    { new Guid("04bde369-9783-4f4f-bccb-127954847205"), new Guid("84168c71-5b07-45bd-a173-1c970be63d19") },
                    { new Guid("35cf7e97-d9f8-4234-9cfe-3b366e0bb8ec"), new Guid("84168c71-5b07-45bd-a173-1c970be63d19") },
                    { new Guid("c4145f93-1f53-441e-9da7-b09cb491e471"), new Guid("84168c71-5b07-45bd-a173-1c970be63d19") },
                    { new Guid("e546ad0f-2795-4d1f-833a-da6fd55d50fa"), new Guid("84168c71-5b07-45bd-a173-1c970be63d19") },
                    { new Guid("e8ad3bf9-02cb-434b-b506-8498e2aa5f40"), new Guid("84168c71-5b07-45bd-a173-1c970be63d19") },
                    { new Guid("1e23212e-ad49-4002-a583-f7c57190c3e6"), new Guid("886eb3c5-1d40-4918-9b8a-8c30622aa845") },
                    { new Guid("449af876-9bb1-473f-abcd-72430f317d7a"), new Guid("886eb3c5-1d40-4918-9b8a-8c30622aa845") },
                    { new Guid("5d9e498c-7242-446e-a08e-fb2a0d28d6c8"), new Guid("886eb3c5-1d40-4918-9b8a-8c30622aa845") },
                    { new Guid("794cc4e5-e040-44d4-973b-fb0c9524243e"), new Guid("886eb3c5-1d40-4918-9b8a-8c30622aa845") },
                    { new Guid("d6cbaec8-d022-40ff-94f9-88bb56092ab7"), new Guid("886eb3c5-1d40-4918-9b8a-8c30622aa845") },
                    { new Guid("fa33b40b-28d2-4835-bf96-8b3ec7cace90"), new Guid("886eb3c5-1d40-4918-9b8a-8c30622aa845") },
                    { new Guid("16b1eb99-4491-477d-802c-1ba0bc14d876"), new Guid("8afd0124-87cf-4fdb-9290-c86f662b5f97") },
                    { new Guid("30e4ea88-c798-4c3d-b8cc-0ea72ca32307"), new Guid("8afd0124-87cf-4fdb-9290-c86f662b5f97") },
                    { new Guid("4b627856-6a2f-46b5-bc00-e4832261aba5"), new Guid("8afd0124-87cf-4fdb-9290-c86f662b5f97") },
                    { new Guid("4fbd62c4-67ea-409c-8220-bd6deb08a022"), new Guid("8afd0124-87cf-4fdb-9290-c86f662b5f97") },
                    { new Guid("86c9054f-4706-40ae-8934-a74c2ae2cf82"), new Guid("8afd0124-87cf-4fdb-9290-c86f662b5f97") },
                    { new Guid("8719aedf-8573-4b23-9415-17a52520c15d"), new Guid("8afd0124-87cf-4fdb-9290-c86f662b5f97") },
                    { new Guid("8de54f39-bd87-44a6-b8ce-143dcb84cb58"), new Guid("8afd0124-87cf-4fdb-9290-c86f662b5f97") },
                    { new Guid("ac789dc9-d197-42e7-95cf-6b304e114d97"), new Guid("8afd0124-87cf-4fdb-9290-c86f662b5f97") },
                    { new Guid("e8ad3bf9-02cb-434b-b506-8498e2aa5f40"), new Guid("8afd0124-87cf-4fdb-9290-c86f662b5f97") },
                    { new Guid("30e4ea88-c798-4c3d-b8cc-0ea72ca32307"), new Guid("a31e573c-ac02-47c3-8df2-a1c412a2a2f9") },
                    { new Guid("5e2310d6-4a6e-4050-90ef-f553af25b06a"), new Guid("a31e573c-ac02-47c3-8df2-a1c412a2a2f9") },
                    { new Guid("f84e5fa9-217d-474c-9f17-d530ab7d578a"), new Guid("a31e573c-ac02-47c3-8df2-a1c412a2a2f9") },
                    { new Guid("04ccdace-3199-4cc6-b451-b2dfb1d7166d"), new Guid("a424dfa4-4847-4fb7-a8de-bb1216b67bd5") },
                    { new Guid("0d7c2367-a2f9-4cfd-b3eb-405ee8c80021"), new Guid("a424dfa4-4847-4fb7-a8de-bb1216b67bd5") },
                    { new Guid("25ce3359-b528-4253-9780-3c7498374184"), new Guid("a424dfa4-4847-4fb7-a8de-bb1216b67bd5") },
                    { new Guid("5ae1513a-72da-479d-aad8-345b3b0ec449"), new Guid("a424dfa4-4847-4fb7-a8de-bb1216b67bd5") },
                    { new Guid("76a166a8-702b-41c3-930a-2ec6886c2282"), new Guid("a424dfa4-4847-4fb7-a8de-bb1216b67bd5") },
                    { new Guid("8de54f39-bd87-44a6-b8ce-143dcb84cb58"), new Guid("a424dfa4-4847-4fb7-a8de-bb1216b67bd5") },
                    { new Guid("aba9cab5-87d9-498e-b33d-55dede2868a1"), new Guid("a424dfa4-4847-4fb7-a8de-bb1216b67bd5") },
                    { new Guid("9d6e1376-c16a-46a3-bb3e-be0c5c73e8f1"), new Guid("bc6cb191-62b6-4a73-ae3a-2724a5b8290d") },
                    { new Guid("9e98364e-8405-4cb4-abe0-bd609d63990e"), new Guid("bc6cb191-62b6-4a73-ae3a-2724a5b8290d") },
                    { new Guid("e546ad0f-2795-4d1f-833a-da6fd55d50fa"), new Guid("bc6cb191-62b6-4a73-ae3a-2724a5b8290d") },
                    { new Guid("2bd39a08-3aa5-4e04-948d-a8430aa16956"), new Guid("cf8a8236-bcdc-469c-b6b2-92586e7a1c95") },
                    { new Guid("86c9054f-4706-40ae-8934-a74c2ae2cf82"), new Guid("cf8a8236-bcdc-469c-b6b2-92586e7a1c95") },
                    { new Guid("30e4ea88-c798-4c3d-b8cc-0ea72ca32307"), new Guid("dfd96a9e-019f-4447-b72a-e7368dab4848") },
                    { new Guid("4fbd62c4-67ea-409c-8220-bd6deb08a022"), new Guid("dfd96a9e-019f-4447-b72a-e7368dab4848") },
                    { new Guid("5ae1513a-72da-479d-aad8-345b3b0ec449"), new Guid("dfd96a9e-019f-4447-b72a-e7368dab4848") },
                    { new Guid("5d9e498c-7242-446e-a08e-fb2a0d28d6c8"), new Guid("dfd96a9e-019f-4447-b72a-e7368dab4848") },
                    { new Guid("9e4d7b86-96fe-4ac3-8c5e-eadf575b6f0f"), new Guid("dfd96a9e-019f-4447-b72a-e7368dab4848") },
                    { new Guid("c797f182-dfec-4e29-b786-7ff01f52b16a"), new Guid("ed282ee5-5a04-4994-bfb4-f6d5c08172ea") },
                    { new Guid("fa33b40b-28d2-4835-bf96-8b3ec7cace90"), new Guid("ed282ee5-5a04-4994-bfb4-f6d5c08172ea") },
                    { new Guid("361fc05f-f508-404e-a408-377d7b82f396"), new Guid("fec2d4ef-bb6e-474b-b4d5-27ed337a56fb") },
                    { new Guid("449af876-9bb1-473f-abcd-72430f317d7a"), new Guid("fec2d4ef-bb6e-474b-b4d5-27ed337a56fb") },
                    { new Guid("76a166a8-702b-41c3-930a-2ec6886c2282"), new Guid("fec2d4ef-bb6e-474b-b4d5-27ed337a56fb") },
                    { new Guid("b71299e3-1fd8-4c20-82b7-8534d7192fee"), new Guid("fec2d4ef-bb6e-474b-b4d5-27ed337a56fb") }
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
                name: "BooksHireRecords");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
