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
                    { new Guid("04cb0a64-f22a-47cf-b5fb-00c438e90d87"), "Aldous Huxley" },
                    { new Guid("32fa9aef-54a3-493f-9228-3dd20ebe95b4"), "Roald Dahl" },
                    { new Guid("352e3bd0-bdf8-49e1-9c29-a1a4f8ef3024"), "Arthur Conan Doyle" },
                    { new Guid("370e4491-5633-4e78-9831-3c47ae4374b7"), "Gabriel García Márquez" },
                    { new Guid("37cce38c-e786-411a-9374-89d99efea101"), "Toni Morrison" },
                    { new Guid("393a54fe-daa0-4bdb-8065-a182806681e6"), "Leo Tolstoy" },
                    { new Guid("43a30ad7-1577-40da-bd2d-9aa5f7339546"), "Virginia Woolf" },
                    { new Guid("646c0730-218b-481e-94ad-7f4fc830cb70"), "F. Scott Fitzgerald" },
                    { new Guid("77b018b1-7811-48cf-b96c-32dcb226ad09"), "William Shakespeare" },
                    { new Guid("804f84f1-1d81-4945-902d-ba4b03a11949"), "Jane Austen" },
                    { new Guid("844d2a69-2576-4f0b-acdd-d7b08fab436e"), "Ernest Hemingway" },
                    { new Guid("886e2b2b-466a-4453-90e8-cb33a617e249"), "Michael Crichton" },
                    { new Guid("8cbb6105-89c5-4dca-8548-19376b5d3bf5"), "Mark Twain" },
                    { new Guid("8e1a4532-371d-4250-a8bb-3c1ac4dbae24"), "Charles Dickens" },
                    { new Guid("a3aac870-20c5-4f1a-86dd-20be61665b84"), "Stephen King" },
                    { new Guid("a6665d29-e292-468f-8fe2-1aa996d9ecac"), "Margaret Atwood" },
                    { new Guid("a76eea22-9478-4b49-868f-12d2311c3492"), "Hermann Hesse" },
                    { new Guid("a84ef626-1ee3-41af-a57b-ac06cf18f862"), "Agatha Christie" },
                    { new Guid("b8ba024c-210b-4f77-898c-361c38c8ba9b"), "Emily Brontë" },
                    { new Guid("b9578ec3-d975-4966-9085-31819998bc84"), "Homer" },
                    { new Guid("c8a51eae-cc38-4c77-9bb6-4ec3ea8d620c"), "Jane Goodall" },
                    { new Guid("cbe43f46-9e76-48d6-a252-eeed33376e6c"), "Ayn Rand" },
                    { new Guid("cef324de-ddfc-4d2a-81c6-55161436285c"), "H.G. Wells" },
                    { new Guid("d3986608-7fa6-4c26-93e5-c522a3fd9cfa"), "Charlotte Brontë" },
                    { new Guid("d6c5a638-4312-417f-be34-671f55d8e4c6"), "J.R.R. Tolkien" },
                    { new Guid("e64de713-3bd6-433b-9966-77c55485f9a1"), "J.K. Rowling" },
                    { new Guid("f2ee12a7-b804-4e1a-be4d-7a273e0d7e1c"), "George Orwell" },
                    { new Guid("f359606b-3297-4d1a-8360-a784d415c0e3"), "Harper Lee" },
                    { new Guid("f96ab7a7-89e0-4324-a3bf-967f498caef3"), "Kurt Vonnegut" },
                    { new Guid("fdce1659-c865-4693-bce3-c87cd59c56f5"), "Isaac Asimov" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("08f3d6aa-1874-41c2-925c-58457cfabaac"), "Poetry" },
                    { new Guid("09c11eca-5c58-465d-92fc-6891e2c6cf49"), "Biography" },
                    { new Guid("0e3ce01e-df95-451f-a59d-8774501c6bef"), "Adventure" },
                    { new Guid("234e659d-7919-4a3a-8e6c-8a6b58c7dae4"), "Non-Fiction" },
                    { new Guid("291470b7-2128-447f-ab64-8f82770c74a2"), "Thriller" },
                    { new Guid("2c26cd80-e2e9-480a-8ce2-089e4545e01b"), "Historical Fiction" },
                    { new Guid("35140fdb-06f1-4edb-be27-b02a1a44d91f"), "Horror" },
                    { new Guid("3a42bd69-50f4-49cc-9184-55d97bc930d4"), "Self-Help" },
                    { new Guid("64bc61c1-7a4c-4844-bc02-17ab6b5ae64d"), "Mystery" },
                    { new Guid("76b8ab13-b3cd-49a6-84b5-3706e811bdb0"), "Business" },
                    { new Guid("89fa23ba-749b-460b-9882-f3cbbd76a1cd"), "Fantasy" },
                    { new Guid("8cb9facc-e26e-4ce2-8765-f7a3a291f955"), "Cookbook" },
                    { new Guid("a8bbdf7f-685e-4915-b2e9-19b95b8b5ccb"), "Science Fiction" },
                    { new Guid("b39859ba-ff41-4f82-be87-bacdeb8e2c0a"), "Science" },
                    { new Guid("c4bd476f-ac4f-44e6-9ad4-0eabd7b1ff36"), "Travel" },
                    { new Guid("d47c0cf6-5484-4b59-8426-9d8f2e34812d"), "Comedy" },
                    { new Guid("d6fbd6be-632f-4f0d-b2f2-1776e1f068e1"), "Romance" },
                    { new Guid("f8e30203-770d-458f-856b-427734a58afc"), "Drama" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "ISBN", "Title" },
                values: new object[,]
                {
                    { new Guid("02e8f4c3-f031-451e-9d57-bc9cd8f4dcf9"), new Guid("fdce1659-c865-4693-bce3-c87cd59c56f5"), null, "978-0-06-085052-4", "Brave New World" },
                    { new Guid("036bdc1d-fe5a-468e-9b62-f86c40863bd1"), new Guid("d3986608-7fa6-4c26-93e5-c522a3fd9cfa"), "C.S. Lewis's beloved fantasy series, taking readers to the enchanting land of Narnia and its magical inhabitants.", "978-0-06-112008-4", "The Chronicles of Narnia" },
                    { new Guid("037e8836-8448-4a65-a439-99804aef6b13"), new Guid("fdce1659-c865-4693-bce3-c87cd59c56f5"), "J.R.R. Tolkien's epic fantasy trilogy, featuring the quest to destroy the One Ring and save Middle-earth from the dark forces of Sauron.", "978-0-54-400341-5", "The Lord of the Rings" },
                    { new Guid("037fec9e-827f-45b7-89bf-e9bbff837d38"), new Guid("844d2a69-2576-4f0b-acdd-d7b08fab436e"), "Alexandre Dumas's classic adventure novel of betrayal, revenge, and redemption.", "978-0-14-044926-6", "The Count of Monte Cristo" },
                    { new Guid("0c745d6c-9d08-4176-a06b-2ccefe95b587"), new Guid("352e3bd0-bdf8-49e1-9c29-a1a4f8ef3024"), "Geoffrey Chaucer's collection of stories told by a diverse group of pilgrims on their journey to Canterbury.", "978-0-14-042234-4", "The Canterbury Tales" },
                    { new Guid("0e9ed85f-a740-4650-b1c8-fc18d7969768"), new Guid("32fa9aef-54a3-493f-9228-3dd20ebe95b4"), "Kathryn Stockett's novel about African American maids working in white households in Jackson, Mississippi, during the early 1960s.", "978-0-42-523220-0", "The Help" },
                    { new Guid("0ec261fb-35e3-402b-b4d0-c30ecb4a34eb"), new Guid("a3aac870-20c5-4f1a-86dd-20be61665b84"), "Jeannette Walls's memoir detailing her unconventional and often troubled childhood.", "978-0-74-324754-5", "The Glass Castle" },
                    { new Guid("0f19acc6-80a1-4929-80eb-8559a851a275"), new Guid("646c0730-218b-481e-94ad-7f4fc830cb70"), "Leo Tolstoy's epic portrayal of Russian society during the Napoleonic Wars, blending history, philosophy, and human drama.", "978-0-14-303500-8", "War and Peace" },
                    { new Guid("10606543-0d01-4ac0-b6b5-691bcafe3c30"), new Guid("804f84f1-1d81-4945-902d-ba4b03a11949"), "Tara Westover's memoir recounting her journey from a rural Idaho childhood to gaining an education against all odds.", "978-0-52-558019-4", "Educated" },
                    { new Guid("12f83231-03b4-4ebb-bb24-340c84263253"), new Guid("04cb0a64-f22a-47cf-b5fb-00c438e90d87"), "John Steinbeck's novel depicting the struggles of a displaced Oklahoma family during the Great Depression.", "978-0-14-303943-3", "The Grapes of Wrath" },
                    { new Guid("1848d0e1-f073-47d1-afbc-36543210d616"), new Guid("d3986608-7fa6-4c26-93e5-c522a3fd9cfa"), "Mary Shelley's gothic tale of scientific hubris and the consequences of creating life.", "978-0-48-628211-4", "Frankenstein" },
                    { new Guid("24a8866e-827a-4324-9b9c-62cdf0219945"), new Guid("a84ef626-1ee3-41af-a57b-ac06cf18f862"), "Erin Morgenstern's magical tale of a mysterious competition between two illusionists in a magical circus.", "978-0-38-553970-6", "The Night Circus" },
                    { new Guid("2cf3063b-e92e-4d4c-a8a9-281423e349fd"), new Guid("f2ee12a7-b804-4e1a-be4d-7a273e0d7e1c"), null, "978-0-15-602835-6", "The Color Purple" },
                    { new Guid("33bbb4b8-b362-4e69-aaba-a2d588ae02b3"), new Guid("f359606b-3297-4d1a-8360-a784d415c0e3"), null, "978-0-37-584220-7", "The Book Thief" },
                    { new Guid("369d6a60-c748-4526-aa5b-961b3d7a80fe"), new Guid("a6665d29-e292-468f-8fe2-1aa996d9ecac"), "Amy Tan's novel exploring the relationships between Chinese-American immigrant mothers and their American-born daughters.", "978-0-80-417839-9", "The Joy Luck Club" },
                    { new Guid("3aa1c312-1e6c-4179-9d52-ce6e1299cb86"), new Guid("a3aac870-20c5-4f1a-86dd-20be61665b84"), null, "978-0-14-143957-0", "The Picture of Dorian Gray" },
                    { new Guid("3c2b33e0-d08c-4306-aa43-75459237deb3"), new Guid("b8ba024c-210b-4f77-898c-361c38c8ba9b"), "John Green's heart-wrenching novel about two teenagers with cancer who fall in love.", "978-0-14-242417-9", "The Fault in Our Stars" },
                    { new Guid("476bf9e1-2ef7-4f4e-aedb-096d75007cc5"), new Guid("8e1a4532-371d-4250-a8bb-3c1ac4dbae24"), "Joseph Heller's satirical novel depicting the absurdities and paradoxes of war.", "978-0-68-484121-9", "The Catch-22" },
                    { new Guid("4951bfc0-816a-4541-adaa-d13a75c365f0"), new Guid("844d2a69-2576-4f0b-acdd-d7b08fab436e"), "Paulo Coelho's philosophical novel about Santiago, a shepherd boy, on a journey to discover his personal legend.", "978-0-06-112241-5", "The Alchemist" },
                    { new Guid("4955bb49-bf12-463a-8cb4-e0d0b396d332"), new Guid("646c0730-218b-481e-94ad-7f4fc830cb70"), "Rebecca Skloot's biography exploring the life and legacy of Henrietta Lacks, whose cells were used for medical research without her knowledge.", "978-1-40-005217-2", "The Immortal Life of Henrietta Lacks" },
                    { new Guid("4b3a7c87-897e-4e8b-9b55-b268d0d65602"), new Guid("8cbb6105-89c5-4dca-8548-19376b5d3bf5"), "Douglas Adams's hilarious space adventure, following the misadventures of Arthur Dent and his extraterrestrial friend Ford Prefect.", "978-0-34-539180-3", "The Hitchhiker's Guide to the Galaxy" },
                    { new Guid("530ab3f8-6c5b-4659-828a-803f5f482274"), new Guid("8cbb6105-89c5-4dca-8548-19376b5d3bf5"), "Suzanne Collins's dystopian saga of Katniss Everdeen's fight for survival in the annual Hunger Games.", "978-0-43-902352-8", "The Hunger Games" },
                    { new Guid("5ba511c5-bcf6-4adb-ba15-83dc32354b8c"), new Guid("646c0730-218b-481e-94ad-7f4fc830cb70"), null, "978-1-25-030169-7", "The Silent Patient" },
                    { new Guid("5c82cfc3-79a8-4079-ba51-4049bad1dd10"), new Guid("886e2b2b-466a-4453-90e8-cb33a617e249"), "Fyodor Dostoevsky's psychological thriller, exploring the moral and psychological turmoil of a young man in St. Petersburg.", "978-0-14-310763-7", "Crime and Punishment" },
                    { new Guid("6506e3bf-7adf-487a-85cd-9ddf2571b86d"), new Guid("d3986608-7fa6-4c26-93e5-c522a3fd9cfa"), "Stieg Larsson's gripping mystery featuring investigative journalist Mikael Blomkvist and the enigmatic hacker Lisbeth Salander.", "978-0-30-726975-1", "The Girl with the Dragon Tattoo" },
                    { new Guid("6a57c572-dc3e-497d-b414-7944663ab7df"), new Guid("77b018b1-7811-48cf-b96c-32dcb226ad09"), "Margaret Atwood's dystopian novel set in the Republic of Gilead, where women's rights are severely restricted.", "978-0-38-549081-8", "The Handmaid's Tale" },
                    { new Guid("6b71c2a5-c8fa-4446-b76f-f244880bd117"), new Guid("c8a51eae-cc38-4c77-9bb6-4ec3ea8d620c"), "A timeless tale of love, manners, and societal expectations in Regency-era England by Jane Austen.", "978-0-14-143951-8", "Pride and Prejudice" },
                    { new Guid("6dbd3ee6-d9ce-42df-986a-8b0007f28f96"), new Guid("fdce1659-c865-4693-bce3-c87cd59c56f5"), "Andy Weir's gripping science fiction novel about an astronaut stranded on Mars and his fight for survival.", "978-0-55-341802-6", "The Martian" },
                    { new Guid("78dd080d-ac62-433f-a7e0-e502f4488568"), new Guid("352e3bd0-bdf8-49e1-9c29-a1a4f8ef3024"), "George Orwell's dystopian masterpiece, depicting a nightmarish future under totalitarian rule.", "978-0-45-152493-5", "1984" },
                    { new Guid("7f788719-b041-446a-a264-7f861248655a"), new Guid("a76eea22-9478-4b49-868f-12d2311c3492"), "Yuval Noah Harari's exploration of the history and impact of Homo sapiens on the world.", "978-0-99-711060-8", "Sapiens: A Brief History of Humankind" },
                    { new Guid("8725a3db-2f1a-409e-ad30-6cba94531ae2"), new Guid("a76eea22-9478-4b49-868f-12d2311c3492"), "Dan Brown's gripping mystery involving symbology, art, and secret societies.", "978-0-30-747427-8", "The Da Vinci Code" },
                    { new Guid("8a9384a4-2c40-47f7-a2c1-5b69fd054c1d"), new Guid("370e4491-5633-4e78-9831-3c47ae4374b7"), "Fyodor Dostoevsky's exploration of morality, faith, and family dynamics through the complex relationships of the Karamazov brothers.", "978-0-14-044924-2", "The Brothers Karamazov" },
                    { new Guid("8cb4d66a-7f6a-4423-a26d-c1dca8bc92bb"), new Guid("370e4491-5633-4e78-9831-3c47ae4374b7"), null, "978-0-06-112028-4", "One Hundred Years of Solitude" },
                    { new Guid("97d2692c-db28-478f-a5f9-1e55798b9bbf"), new Guid("cef324de-ddfc-4d2a-81c6-55161436285c"), "Haruki Murakami's surreal and mesmerizing novel exploring the mysteries of human consciousness.", "978-0-67-977543-0", "The Wind-Up Bird Chronicle" },
                    { new Guid("9a147065-60a7-453b-b3ae-80bc4b4156d9"), new Guid("886e2b2b-466a-4453-90e8-cb33a617e249"), null, "978-0-14-200174-5", "The Secret Life of Bees" },
                    { new Guid("9e2d481b-874f-4587-a842-072098955bcb"), new Guid("c8a51eae-cc38-4c77-9bb6-4ec3ea8d620c"), "Charles Duhigg's exploration of the science behind habits and how they can be transformed.", "978-0-81-298160-5", "The Power of Habit" },
                    { new Guid("a23bd7d5-50a6-4e54-be1b-ae8e598f309a"), new Guid("cef324de-ddfc-4d2a-81c6-55161436285c"), "J.K. Rowling's enchanting introduction to the wizarding world, filled with magic, friendship, and adventure.", "978-0-59-035342-7", "Harry Potter and the Sorcerer's Stone" },
                    { new Guid("a3f16034-f110-4a27-b419-a3aa8afee6a4"), new Guid("a84ef626-1ee3-41af-a57b-ac06cf18f862"), null, "978-0-54-792822-7", "The Hobbit" },
                    { new Guid("ae94d435-31b7-44c7-ba5e-53b18f1e6afe"), new Guid("f96ab7a7-89e0-4324-a3bf-967f498caef3"), "Homer's ancient Greek epic, recounting the adventures of Odysseus as he journeys home from the Trojan War.", "978-0-14-303995-2", "The Odyssey" },
                    { new Guid("aeda1fc4-5e5e-4fae-b377-466a32f0b93f"), new Guid("c8a51eae-cc38-4c77-9bb6-4ec3ea8d620c"), "F. Scott Fitzgerald's classic portrayal of the American Dream, excess, and disillusionment in the Roaring Twenties.", "978-0-74-327356-5", "The Great Gatsby" },
                    { new Guid("bbf49d78-4fc9-4b0d-8e8e-7ca5e72a03c8"), new Guid("886e2b2b-466a-4453-90e8-cb33a617e249"), null, "978-0-52-551488-0", "The Immortalists" },
                    { new Guid("cfb4956c-43fb-4b1b-a430-28a65746b1cd"), new Guid("32fa9aef-54a3-493f-9228-3dd20ebe95b4"), "Donna Tartt's Pulitzer Prize-winning novel about a young boy's life after a terrorist attack in a New York art museum.", "978-0-31-605543-7", "The Goldfinch" },
                    { new Guid("d203b227-620e-4a71-bde5-8ef6219c6e2d"), new Guid("cef324de-ddfc-4d2a-81c6-55161436285c"), "Stephen King's chilling tale of supernatural horror, isolation, and the descent into madness at the haunted Overlook Hotel.", "978-0-38-511683-7", "The Shining" },
                    { new Guid("d6facd73-57cd-4382-a31e-3995353ff91e"), new Guid("646c0730-218b-481e-94ad-7f4fc830cb70"), "Khaled Hosseini's powerful novel about friendship, betrayal, and redemption in Afghanistan.", "978-1-59-463193-1", "The Kite Runner" },
                    { new Guid("d7e77f30-934e-4d7b-93e5-0ea110092719"), new Guid("a84ef626-1ee3-41af-a57b-ac06cf18f862"), null, "978-0-14-143955-6", "Wuthering Heights" },
                    { new Guid("d898a657-04bd-4d2e-a9c9-330ce533e413"), new Guid("fdce1659-c865-4693-bce3-c87cd59c56f5"), null, "978-0-14-044022-5", "The Three Musketeers" },
                    { new Guid("da307696-1a69-446d-a218-8fce5197ce47"), new Guid("886e2b2b-466a-4453-90e8-cb33a617e249"), "Frank Herbert's science fiction epic set in a distant future where noble houses vie for control of the desert planet Arrakis and its valuable spice melange.", "978-0-44-117271-9", "Dune" },
                    { new Guid("dd6562b3-93d7-45bf-894f-7d00c7897237"), new Guid("a76eea22-9478-4b49-868f-12d2311c3492"), "Cormac McCarthy's post-apocalyptic tale of a father and son's harrowing journey through a desolate landscape.", "978-0-30-738789-9", "The Road" },
                    { new Guid("dd848273-7c2f-423e-9c5f-0982db7eaa9c"), new Guid("e64de713-3bd6-433b-9966-77c55485f9a1"), null, "978-0-19-921613-3", "Alice's Adventures in Wonderland" },
                    { new Guid("df63308a-4335-4f69-a74c-051993261fcb"), new Guid("646c0730-218b-481e-94ad-7f4fc830cb70"), "Ken Kesey's classic novel set in a mental hospital, challenging authority and celebrating individuality.", "978-0-45-116396-7", "One Flew Over the Cuckoo's Nest" },
                    { new Guid("e295f6b0-ed22-4e19-9524-b1844ebf891e"), new Guid("a3aac870-20c5-4f1a-86dd-20be61665b84"), "J.D. Salinger's iconic coming-of-age novel, capturing the angst and rebellion of a teenage boy in post-World War II America.", "978-0-31-676948-0", "The Catcher in the Rye" },
                    { new Guid("e3959340-6a6e-45f5-a75d-3741be5f9951"), new Guid("cef324de-ddfc-4d2a-81c6-55161436285c"), "M. Scott Peck's exploration of personal growth, love, and spiritual development.", "978-0-74-324315-8", "The Road Less Traveled" },
                    { new Guid("e4543b2c-6472-46b6-836c-68839f50a9d9"), new Guid("8e1a4532-371d-4250-a8bb-3c1ac4dbae24"), "Paula Hawkins's psychological thriller about a woman who becomes entangled in a missing person investigation.", "978-1-59-463402-4", "The Girl on the Train" },
                    { new Guid("e729b54e-4f90-47d7-9c58-8b95ea089a4a"), new Guid("b8ba024c-210b-4f77-898c-361c38c8ba9b"), null, "978-0-45-141943-9", "Les Misérables" },
                    { new Guid("fa5bcbc6-a1f2-45ba-abcd-6958aac8fbb2"), new Guid("b9578ec3-d975-4966-9085-31819998bc84"), "Harper Lee's powerful exploration of racial injustice and moral growth in the American South.", "978-0-06-112348-4", "To Kill a Mockingbird" },
                    { new Guid("fe633b05-cebe-4370-bd19-09100c0b7344"), new Guid("844d2a69-2576-4f0b-acdd-d7b08fab436e"), "Herman Melville's epic journey aboard the whaling ship Pequod, driven by Captain Ahab's obsessive quest for the white whale.", "978-0-14-310635-7", "Moby-Dick" }
                });

            migrationBuilder.InsertData(
                table: "BooksGenres",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { new Guid("369d6a60-c748-4526-aa5b-961b3d7a80fe"), new Guid("08f3d6aa-1874-41c2-925c-58457cfabaac") },
                    { new Guid("3aa1c312-1e6c-4179-9d52-ce6e1299cb86"), new Guid("08f3d6aa-1874-41c2-925c-58457cfabaac") },
                    { new Guid("4951bfc0-816a-4541-adaa-d13a75c365f0"), new Guid("08f3d6aa-1874-41c2-925c-58457cfabaac") },
                    { new Guid("5ba511c5-bcf6-4adb-ba15-83dc32354b8c"), new Guid("08f3d6aa-1874-41c2-925c-58457cfabaac") },
                    { new Guid("5c82cfc3-79a8-4079-ba51-4049bad1dd10"), new Guid("08f3d6aa-1874-41c2-925c-58457cfabaac") },
                    { new Guid("7f788719-b041-446a-a264-7f861248655a"), new Guid("08f3d6aa-1874-41c2-925c-58457cfabaac") },
                    { new Guid("d203b227-620e-4a71-bde5-8ef6219c6e2d"), new Guid("08f3d6aa-1874-41c2-925c-58457cfabaac") },
                    { new Guid("d6facd73-57cd-4382-a31e-3995353ff91e"), new Guid("08f3d6aa-1874-41c2-925c-58457cfabaac") },
                    { new Guid("d898a657-04bd-4d2e-a9c9-330ce533e413"), new Guid("08f3d6aa-1874-41c2-925c-58457cfabaac") },
                    { new Guid("e3959340-6a6e-45f5-a75d-3741be5f9951"), new Guid("08f3d6aa-1874-41c2-925c-58457cfabaac") },
                    { new Guid("0ec261fb-35e3-402b-b4d0-c30ecb4a34eb"), new Guid("09c11eca-5c58-465d-92fc-6891e2c6cf49") },
                    { new Guid("24a8866e-827a-4324-9b9c-62cdf0219945"), new Guid("09c11eca-5c58-465d-92fc-6891e2c6cf49") },
                    { new Guid("7f788719-b041-446a-a264-7f861248655a"), new Guid("09c11eca-5c58-465d-92fc-6891e2c6cf49") },
                    { new Guid("aeda1fc4-5e5e-4fae-b377-466a32f0b93f"), new Guid("09c11eca-5c58-465d-92fc-6891e2c6cf49") },
                    { new Guid("d7e77f30-934e-4d7b-93e5-0ea110092719"), new Guid("09c11eca-5c58-465d-92fc-6891e2c6cf49") },
                    { new Guid("dd848273-7c2f-423e-9c5f-0982db7eaa9c"), new Guid("09c11eca-5c58-465d-92fc-6891e2c6cf49") },
                    { new Guid("fa5bcbc6-a1f2-45ba-abcd-6958aac8fbb2"), new Guid("09c11eca-5c58-465d-92fc-6891e2c6cf49") },
                    { new Guid("037e8836-8448-4a65-a439-99804aef6b13"), new Guid("0e3ce01e-df95-451f-a59d-8774501c6bef") },
                    { new Guid("8a9384a4-2c40-47f7-a2c1-5b69fd054c1d"), new Guid("0e3ce01e-df95-451f-a59d-8774501c6bef") },
                    { new Guid("dd6562b3-93d7-45bf-894f-7d00c7897237"), new Guid("0e3ce01e-df95-451f-a59d-8774501c6bef") },
                    { new Guid("e3959340-6a6e-45f5-a75d-3741be5f9951"), new Guid("0e3ce01e-df95-451f-a59d-8774501c6bef") },
                    { new Guid("0c745d6c-9d08-4176-a06b-2ccefe95b587"), new Guid("234e659d-7919-4a3a-8e6c-8a6b58c7dae4") },
                    { new Guid("0f19acc6-80a1-4929-80eb-8559a851a275"), new Guid("234e659d-7919-4a3a-8e6c-8a6b58c7dae4") },
                    { new Guid("12f83231-03b4-4ebb-bb24-340c84263253"), new Guid("234e659d-7919-4a3a-8e6c-8a6b58c7dae4") },
                    { new Guid("6b71c2a5-c8fa-4446-b76f-f244880bd117"), new Guid("234e659d-7919-4a3a-8e6c-8a6b58c7dae4") },
                    { new Guid("a23bd7d5-50a6-4e54-be1b-ae8e598f309a"), new Guid("234e659d-7919-4a3a-8e6c-8a6b58c7dae4") },
                    { new Guid("dd848273-7c2f-423e-9c5f-0982db7eaa9c"), new Guid("234e659d-7919-4a3a-8e6c-8a6b58c7dae4") },
                    { new Guid("df63308a-4335-4f69-a74c-051993261fcb"), new Guid("234e659d-7919-4a3a-8e6c-8a6b58c7dae4") },
                    { new Guid("e729b54e-4f90-47d7-9c58-8b95ea089a4a"), new Guid("234e659d-7919-4a3a-8e6c-8a6b58c7dae4") },
                    { new Guid("0e9ed85f-a740-4650-b1c8-fc18d7969768"), new Guid("291470b7-2128-447f-ab64-8f82770c74a2") },
                    { new Guid("3aa1c312-1e6c-4179-9d52-ce6e1299cb86"), new Guid("291470b7-2128-447f-ab64-8f82770c74a2") },
                    { new Guid("dd6562b3-93d7-45bf-894f-7d00c7897237"), new Guid("291470b7-2128-447f-ab64-8f82770c74a2") },
                    { new Guid("e295f6b0-ed22-4e19-9524-b1844ebf891e"), new Guid("291470b7-2128-447f-ab64-8f82770c74a2") },
                    { new Guid("e3959340-6a6e-45f5-a75d-3741be5f9951"), new Guid("291470b7-2128-447f-ab64-8f82770c74a2") },
                    { new Guid("037e8836-8448-4a65-a439-99804aef6b13"), new Guid("2c26cd80-e2e9-480a-8ce2-089e4545e01b") },
                    { new Guid("33bbb4b8-b362-4e69-aaba-a2d588ae02b3"), new Guid("2c26cd80-e2e9-480a-8ce2-089e4545e01b") },
                    { new Guid("5ba511c5-bcf6-4adb-ba15-83dc32354b8c"), new Guid("2c26cd80-e2e9-480a-8ce2-089e4545e01b") },
                    { new Guid("6506e3bf-7adf-487a-85cd-9ddf2571b86d"), new Guid("2c26cd80-e2e9-480a-8ce2-089e4545e01b") },
                    { new Guid("da307696-1a69-446d-a218-8fce5197ce47"), new Guid("2c26cd80-e2e9-480a-8ce2-089e4545e01b") },
                    { new Guid("e729b54e-4f90-47d7-9c58-8b95ea089a4a"), new Guid("2c26cd80-e2e9-480a-8ce2-089e4545e01b") },
                    { new Guid("037fec9e-827f-45b7-89bf-e9bbff837d38"), new Guid("35140fdb-06f1-4edb-be27-b02a1a44d91f") },
                    { new Guid("476bf9e1-2ef7-4f4e-aedb-096d75007cc5"), new Guid("35140fdb-06f1-4edb-be27-b02a1a44d91f") },
                    { new Guid("6dbd3ee6-d9ce-42df-986a-8b0007f28f96"), new Guid("35140fdb-06f1-4edb-be27-b02a1a44d91f") },
                    { new Guid("78dd080d-ac62-433f-a7e0-e502f4488568"), new Guid("35140fdb-06f1-4edb-be27-b02a1a44d91f") },
                    { new Guid("ae94d435-31b7-44c7-ba5e-53b18f1e6afe"), new Guid("35140fdb-06f1-4edb-be27-b02a1a44d91f") },
                    { new Guid("d898a657-04bd-4d2e-a9c9-330ce533e413"), new Guid("35140fdb-06f1-4edb-be27-b02a1a44d91f") },
                    { new Guid("12f83231-03b4-4ebb-bb24-340c84263253"), new Guid("3a42bd69-50f4-49cc-9184-55d97bc930d4") },
                    { new Guid("2cf3063b-e92e-4d4c-a8a9-281423e349fd"), new Guid("3a42bd69-50f4-49cc-9184-55d97bc930d4") },
                    { new Guid("33bbb4b8-b362-4e69-aaba-a2d588ae02b3"), new Guid("3a42bd69-50f4-49cc-9184-55d97bc930d4") },
                    { new Guid("7f788719-b041-446a-a264-7f861248655a"), new Guid("3a42bd69-50f4-49cc-9184-55d97bc930d4") },
                    { new Guid("8725a3db-2f1a-409e-ad30-6cba94531ae2"), new Guid("3a42bd69-50f4-49cc-9184-55d97bc930d4") },
                    { new Guid("a23bd7d5-50a6-4e54-be1b-ae8e598f309a"), new Guid("3a42bd69-50f4-49cc-9184-55d97bc930d4") },
                    { new Guid("d6facd73-57cd-4382-a31e-3995353ff91e"), new Guid("3a42bd69-50f4-49cc-9184-55d97bc930d4") },
                    { new Guid("fe633b05-cebe-4370-bd19-09100c0b7344"), new Guid("3a42bd69-50f4-49cc-9184-55d97bc930d4") },
                    { new Guid("036bdc1d-fe5a-468e-9b62-f86c40863bd1"), new Guid("64bc61c1-7a4c-4844-bc02-17ab6b5ae64d") },
                    { new Guid("3c2b33e0-d08c-4306-aa43-75459237deb3"), new Guid("64bc61c1-7a4c-4844-bc02-17ab6b5ae64d") },
                    { new Guid("4951bfc0-816a-4541-adaa-d13a75c365f0"), new Guid("64bc61c1-7a4c-4844-bc02-17ab6b5ae64d") },
                    { new Guid("9e2d481b-874f-4587-a842-072098955bcb"), new Guid("64bc61c1-7a4c-4844-bc02-17ab6b5ae64d") },
                    { new Guid("dd848273-7c2f-423e-9c5f-0982db7eaa9c"), new Guid("64bc61c1-7a4c-4844-bc02-17ab6b5ae64d") },
                    { new Guid("4b3a7c87-897e-4e8b-9b55-b268d0d65602"), new Guid("76b8ab13-b3cd-49a6-84b5-3706e811bdb0") },
                    { new Guid("530ab3f8-6c5b-4659-828a-803f5f482274"), new Guid("76b8ab13-b3cd-49a6-84b5-3706e811bdb0") },
                    { new Guid("8a9384a4-2c40-47f7-a2c1-5b69fd054c1d"), new Guid("76b8ab13-b3cd-49a6-84b5-3706e811bdb0") },
                    { new Guid("a3f16034-f110-4a27-b419-a3aa8afee6a4"), new Guid("76b8ab13-b3cd-49a6-84b5-3706e811bdb0") },
                    { new Guid("ae94d435-31b7-44c7-ba5e-53b18f1e6afe"), new Guid("76b8ab13-b3cd-49a6-84b5-3706e811bdb0") },
                    { new Guid("cfb4956c-43fb-4b1b-a430-28a65746b1cd"), new Guid("76b8ab13-b3cd-49a6-84b5-3706e811bdb0") },
                    { new Guid("d203b227-620e-4a71-bde5-8ef6219c6e2d"), new Guid("76b8ab13-b3cd-49a6-84b5-3706e811bdb0") },
                    { new Guid("d6facd73-57cd-4382-a31e-3995353ff91e"), new Guid("76b8ab13-b3cd-49a6-84b5-3706e811bdb0") },
                    { new Guid("da307696-1a69-446d-a218-8fce5197ce47"), new Guid("76b8ab13-b3cd-49a6-84b5-3706e811bdb0") },
                    { new Guid("e729b54e-4f90-47d7-9c58-8b95ea089a4a"), new Guid("76b8ab13-b3cd-49a6-84b5-3706e811bdb0") },
                    { new Guid("6b71c2a5-c8fa-4446-b76f-f244880bd117"), new Guid("89fa23ba-749b-460b-9882-f3cbbd76a1cd") },
                    { new Guid("8a9384a4-2c40-47f7-a2c1-5b69fd054c1d"), new Guid("89fa23ba-749b-460b-9882-f3cbbd76a1cd") },
                    { new Guid("ae94d435-31b7-44c7-ba5e-53b18f1e6afe"), new Guid("89fa23ba-749b-460b-9882-f3cbbd76a1cd") },
                    { new Guid("cfb4956c-43fb-4b1b-a430-28a65746b1cd"), new Guid("89fa23ba-749b-460b-9882-f3cbbd76a1cd") },
                    { new Guid("d7e77f30-934e-4d7b-93e5-0ea110092719"), new Guid("89fa23ba-749b-460b-9882-f3cbbd76a1cd") },
                    { new Guid("e4543b2c-6472-46b6-836c-68839f50a9d9"), new Guid("89fa23ba-749b-460b-9882-f3cbbd76a1cd") },
                    { new Guid("037fec9e-827f-45b7-89bf-e9bbff837d38"), new Guid("8cb9facc-e26e-4ce2-8765-f7a3a291f955") },
                    { new Guid("24a8866e-827a-4324-9b9c-62cdf0219945"), new Guid("8cb9facc-e26e-4ce2-8765-f7a3a291f955") },
                    { new Guid("476bf9e1-2ef7-4f4e-aedb-096d75007cc5"), new Guid("8cb9facc-e26e-4ce2-8765-f7a3a291f955") },
                    { new Guid("6a57c572-dc3e-497d-b414-7944663ab7df"), new Guid("8cb9facc-e26e-4ce2-8765-f7a3a291f955") },
                    { new Guid("6dbd3ee6-d9ce-42df-986a-8b0007f28f96"), new Guid("8cb9facc-e26e-4ce2-8765-f7a3a291f955") },
                    { new Guid("9a147065-60a7-453b-b3ae-80bc4b4156d9"), new Guid("8cb9facc-e26e-4ce2-8765-f7a3a291f955") },
                    { new Guid("cfb4956c-43fb-4b1b-a430-28a65746b1cd"), new Guid("8cb9facc-e26e-4ce2-8765-f7a3a291f955") },
                    { new Guid("d898a657-04bd-4d2e-a9c9-330ce533e413"), new Guid("8cb9facc-e26e-4ce2-8765-f7a3a291f955") },
                    { new Guid("fa5bcbc6-a1f2-45ba-abcd-6958aac8fbb2"), new Guid("8cb9facc-e26e-4ce2-8765-f7a3a291f955") },
                    { new Guid("02e8f4c3-f031-451e-9d57-bc9cd8f4dcf9"), new Guid("a8bbdf7f-685e-4915-b2e9-19b95b8b5ccb") },
                    { new Guid("2cf3063b-e92e-4d4c-a8a9-281423e349fd"), new Guid("a8bbdf7f-685e-4915-b2e9-19b95b8b5ccb") },
                    { new Guid("4951bfc0-816a-4541-adaa-d13a75c365f0"), new Guid("a8bbdf7f-685e-4915-b2e9-19b95b8b5ccb") },
                    { new Guid("530ab3f8-6c5b-4659-828a-803f5f482274"), new Guid("a8bbdf7f-685e-4915-b2e9-19b95b8b5ccb") },
                    { new Guid("8cb4d66a-7f6a-4423-a26d-c1dca8bc92bb"), new Guid("a8bbdf7f-685e-4915-b2e9-19b95b8b5ccb") },
                    { new Guid("97d2692c-db28-478f-a5f9-1e55798b9bbf"), new Guid("a8bbdf7f-685e-4915-b2e9-19b95b8b5ccb") },
                    { new Guid("9e2d481b-874f-4587-a842-072098955bcb"), new Guid("a8bbdf7f-685e-4915-b2e9-19b95b8b5ccb") },
                    { new Guid("d203b227-620e-4a71-bde5-8ef6219c6e2d"), new Guid("a8bbdf7f-685e-4915-b2e9-19b95b8b5ccb") },
                    { new Guid("d7e77f30-934e-4d7b-93e5-0ea110092719"), new Guid("a8bbdf7f-685e-4915-b2e9-19b95b8b5ccb") },
                    { new Guid("da307696-1a69-446d-a218-8fce5197ce47"), new Guid("a8bbdf7f-685e-4915-b2e9-19b95b8b5ccb") },
                    { new Guid("df63308a-4335-4f69-a74c-051993261fcb"), new Guid("a8bbdf7f-685e-4915-b2e9-19b95b8b5ccb") },
                    { new Guid("037e8836-8448-4a65-a439-99804aef6b13"), new Guid("b39859ba-ff41-4f82-be87-bacdeb8e2c0a") },
                    { new Guid("037fec9e-827f-45b7-89bf-e9bbff837d38"), new Guid("b39859ba-ff41-4f82-be87-bacdeb8e2c0a") },
                    { new Guid("1848d0e1-f073-47d1-afbc-36543210d616"), new Guid("b39859ba-ff41-4f82-be87-bacdeb8e2c0a") },
                    { new Guid("4955bb49-bf12-463a-8cb4-e0d0b396d332"), new Guid("b39859ba-ff41-4f82-be87-bacdeb8e2c0a") },
                    { new Guid("4b3a7c87-897e-4e8b-9b55-b268d0d65602"), new Guid("b39859ba-ff41-4f82-be87-bacdeb8e2c0a") },
                    { new Guid("530ab3f8-6c5b-4659-828a-803f5f482274"), new Guid("b39859ba-ff41-4f82-be87-bacdeb8e2c0a") },
                    { new Guid("5c82cfc3-79a8-4079-ba51-4049bad1dd10"), new Guid("b39859ba-ff41-4f82-be87-bacdeb8e2c0a") },
                    { new Guid("6a57c572-dc3e-497d-b414-7944663ab7df"), new Guid("b39859ba-ff41-4f82-be87-bacdeb8e2c0a") },
                    { new Guid("8cb4d66a-7f6a-4423-a26d-c1dca8bc92bb"), new Guid("b39859ba-ff41-4f82-be87-bacdeb8e2c0a") },
                    { new Guid("9e2d481b-874f-4587-a842-072098955bcb"), new Guid("b39859ba-ff41-4f82-be87-bacdeb8e2c0a") },
                    { new Guid("df63308a-4335-4f69-a74c-051993261fcb"), new Guid("b39859ba-ff41-4f82-be87-bacdeb8e2c0a") },
                    { new Guid("037e8836-8448-4a65-a439-99804aef6b13"), new Guid("d47c0cf6-5484-4b59-8426-9d8f2e34812d") },
                    { new Guid("0c745d6c-9d08-4176-a06b-2ccefe95b587"), new Guid("d47c0cf6-5484-4b59-8426-9d8f2e34812d") },
                    { new Guid("0ec261fb-35e3-402b-b4d0-c30ecb4a34eb"), new Guid("d47c0cf6-5484-4b59-8426-9d8f2e34812d") },
                    { new Guid("10606543-0d01-4ac0-b6b5-691bcafe3c30"), new Guid("d47c0cf6-5484-4b59-8426-9d8f2e34812d") },
                    { new Guid("33bbb4b8-b362-4e69-aaba-a2d588ae02b3"), new Guid("d47c0cf6-5484-4b59-8426-9d8f2e34812d") },
                    { new Guid("bbf49d78-4fc9-4b0d-8e8e-7ca5e72a03c8"), new Guid("d47c0cf6-5484-4b59-8426-9d8f2e34812d") },
                    { new Guid("e295f6b0-ed22-4e19-9524-b1844ebf891e"), new Guid("d47c0cf6-5484-4b59-8426-9d8f2e34812d") },
                    { new Guid("a3f16034-f110-4a27-b419-a3aa8afee6a4"), new Guid("d6fbd6be-632f-4f0d-b2f2-1776e1f068e1") },
                    { new Guid("d898a657-04bd-4d2e-a9c9-330ce533e413"), new Guid("d6fbd6be-632f-4f0d-b2f2-1776e1f068e1") },
                    { new Guid("fa5bcbc6-a1f2-45ba-abcd-6958aac8fbb2"), new Guid("d6fbd6be-632f-4f0d-b2f2-1776e1f068e1") },
                    { new Guid("02e8f4c3-f031-451e-9d57-bc9cd8f4dcf9"), new Guid("f8e30203-770d-458f-856b-427734a58afc") },
                    { new Guid("0c745d6c-9d08-4176-a06b-2ccefe95b587"), new Guid("f8e30203-770d-458f-856b-427734a58afc") },
                    { new Guid("1848d0e1-f073-47d1-afbc-36543210d616"), new Guid("f8e30203-770d-458f-856b-427734a58afc") },
                    { new Guid("369d6a60-c748-4526-aa5b-961b3d7a80fe"), new Guid("f8e30203-770d-458f-856b-427734a58afc") },
                    { new Guid("4955bb49-bf12-463a-8cb4-e0d0b396d332"), new Guid("f8e30203-770d-458f-856b-427734a58afc") },
                    { new Guid("8cb4d66a-7f6a-4423-a26d-c1dca8bc92bb"), new Guid("f8e30203-770d-458f-856b-427734a58afc") }
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
