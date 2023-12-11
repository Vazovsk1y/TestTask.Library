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
                    { new Guid("0521ad2c-765f-42ba-a427-503540164431"), "Charles Dickens" },
                    { new Guid("0df4da33-d590-491c-8941-118c178fe18e"), "Gabriel García Márquez" },
                    { new Guid("11268797-dd1f-48ac-a50a-595be0ba5368"), "Roald Dahl" },
                    { new Guid("23312545-93d4-4fdc-b18e-a43a0134b43a"), "Isaac Asimov" },
                    { new Guid("2356606f-dbb3-4091-abeb-60d2fc72d6fa"), "George Orwell" },
                    { new Guid("2fe334ca-0dc3-403b-8e7b-eb04ffaefeaf"), "Emily Brontë" },
                    { new Guid("5a992b40-a12e-429f-a8a2-3227ac309eb8"), "Charlotte Brontë" },
                    { new Guid("5d9ac423-8c27-4728-a524-bdaae18c3211"), "Margaret Atwood" },
                    { new Guid("5e1b881e-9197-4dfb-88c7-3fc6ebfad1c9"), "Hermann Hesse" },
                    { new Guid("6e59ee16-0a7d-43c4-be5e-9adb2219212a"), "H.G. Wells" },
                    { new Guid("76bceedd-b908-4537-910c-c5765121210d"), "Harper Lee" },
                    { new Guid("80e1451b-f47a-4cce-8c23-318a70b4299b"), "Jane Austen" },
                    { new Guid("814afe3e-d821-45c7-a1b1-e4e4813f45e2"), "Agatha Christie" },
                    { new Guid("8cb78f09-e28e-4c8e-961f-d3c3b3e16e95"), "Stephen King" },
                    { new Guid("a56e7c68-5697-4fc1-9fcd-997b32c6f549"), "J.K. Rowling" },
                    { new Guid("a5929383-328e-4c23-a876-0fcd352d462a"), "William Shakespeare" },
                    { new Guid("ac18f4ab-f786-46e1-b390-4431999487f6"), "Ernest Hemingway" },
                    { new Guid("ada5c9f4-5cfd-4a89-a919-ac04a4cd34d2"), "Toni Morrison" },
                    { new Guid("bdc68685-f540-4683-8f8a-f14a32a51d68"), "Jane Goodall" },
                    { new Guid("c12cc196-28fb-481b-b6ad-81e87a8fa8c6"), "Kurt Vonnegut" },
                    { new Guid("c4b61f12-d22b-4422-859e-f000430b0bc1"), "Virginia Woolf" },
                    { new Guid("d619b7da-14f1-41a5-9213-291b9c96d13d"), "Arthur Conan Doyle" },
                    { new Guid("d973ab12-02f5-4f51-a40d-66cad7cccfae"), "Michael Crichton" },
                    { new Guid("e02efb96-c335-47f1-8e49-779a67c76918"), "Aldous Huxley" },
                    { new Guid("e2323aa0-0413-4ef7-afbf-0ee33c3bbf20"), "Mark Twain" },
                    { new Guid("eb25c724-d36d-4f31-b420-407b4dcaf2d5"), "Ayn Rand" },
                    { new Guid("eb6bb1b5-f557-4e2f-88cf-6be757835043"), "Homer" },
                    { new Guid("ee8fbf04-993c-4338-b250-e2d058e8d138"), "Leo Tolstoy" },
                    { new Guid("f23804d9-eb6a-439d-8928-9a96b3900456"), "J.R.R. Tolkien" },
                    { new Guid("fe798bc6-ff2e-47f1-ad28-12a819230cc6"), "F. Scott Fitzgerald" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("100e1c65-4407-41db-a924-fa8d3f146962"), "Biography" },
                    { new Guid("1e3b2b42-fde4-4e24-80c1-c7e3df95f181"), "Adventure" },
                    { new Guid("42fff34d-5594-42f4-8748-9d93e11e8fd0"), "Self-Help" },
                    { new Guid("4979e400-dcc0-438d-a28b-e6fafaf540b6"), "Horror" },
                    { new Guid("49902634-a374-4466-a710-cb0708ba8676"), "Cookbook" },
                    { new Guid("5b9072bb-bb3f-402f-bcd9-fc924a83cc06"), "Thriller" },
                    { new Guid("73a0f79e-fb3c-4c33-a159-00b31bc53c85"), "Travel" },
                    { new Guid("7542901e-05d1-45a7-825b-ecd0afb9758b"), "Comedy" },
                    { new Guid("77ddc50d-0025-40e4-98d2-c9a03ef16fa6"), "Drama" },
                    { new Guid("7e3f1dac-1cbb-47ad-866d-74cfd14d3c9d"), "Science" },
                    { new Guid("83163730-951b-4548-bfd3-0638896dc6da"), "Science Fiction" },
                    { new Guid("84409865-5d9e-478b-ab81-8aa445b2f4a2"), "Business" },
                    { new Guid("88a4bd49-fe23-4a28-8995-82130e504ead"), "Non-Fiction" },
                    { new Guid("9a7e4a9c-b054-4e43-bbe1-1f7aead8b4db"), "Fantasy" },
                    { new Guid("a366cd89-7e8a-4c30-889e-2215c28cc734"), "Poetry" },
                    { new Guid("ab4bc0d0-c950-4bef-b6f5-8c3b28c80836"), "Mystery" },
                    { new Guid("abe4de7c-b3a5-4c75-b274-42ba15ef2e65"), "Historical Fiction" },
                    { new Guid("dd497a53-1396-40b5-a9a6-aa0563ad84b1"), "Romance" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "ISBN", "Title" },
                values: new object[,]
                {
                    { new Guid("07bace45-b504-4f2f-b6d5-3f7a5b43896a"), new Guid("23312545-93d4-4fdc-b18e-a43a0134b43a"), "Paulo Coelho's philosophical novel about Santiago, a shepherd boy, on a journey to discover his personal legend.", "978-0-06-112241-5", "The Alchemist" },
                    { new Guid("07ec9696-d9e6-4c0d-8be8-c2441c6d02b2"), new Guid("814afe3e-d821-45c7-a1b1-e4e4813f45e2"), "Fyodor Dostoevsky's psychological thriller, exploring the moral and psychological turmoil of a young man in St. Petersburg.", "978-0-14-310763-7", "Crime and Punishment" },
                    { new Guid("0899c3aa-33ac-4ea6-acd5-c719f5680f5d"), new Guid("ac18f4ab-f786-46e1-b390-4431999487f6"), null, "978-0-19-921613-3", "Alice's Adventures in Wonderland" },
                    { new Guid("093a8c6d-d250-44ff-9f83-bfc0610ecb54"), new Guid("ac18f4ab-f786-46e1-b390-4431999487f6"), "Rebecca Skloot's biography exploring the life and legacy of Henrietta Lacks, whose cells were used for medical research without her knowledge.", "978-1-40-005217-2", "The Immortal Life of Henrietta Lacks" },
                    { new Guid("11b32795-f5c6-42db-8ecc-3b97c4125271"), new Guid("d973ab12-02f5-4f51-a40d-66cad7cccfae"), "Donna Tartt's Pulitzer Prize-winning novel about a young boy's life after a terrorist attack in a New York art museum.", "978-0-31-605543-7", "The Goldfinch" },
                    { new Guid("17414652-443e-4b84-8cb4-199911bce604"), new Guid("23312545-93d4-4fdc-b18e-a43a0134b43a"), "Yuval Noah Harari's exploration of the history and impact of Homo sapiens on the world.", "978-0-99-711060-8", "Sapiens: A Brief History of Humankind" },
                    { new Guid("1831af5f-a84b-4bd2-a3c1-8ab7424a2ee0"), new Guid("76bceedd-b908-4537-910c-c5765121210d"), "J.K. Rowling's enchanting introduction to the wizarding world, filled with magic, friendship, and adventure.", "978-0-59-035342-7", "Harry Potter and the Sorcerer's Stone" },
                    { new Guid("1e5b98ca-833d-4515-9353-e0cb106a4441"), new Guid("fe798bc6-ff2e-47f1-ad28-12a819230cc6"), "Geoffrey Chaucer's collection of stories told by a diverse group of pilgrims on their journey to Canterbury.", "978-0-14-042234-4", "The Canterbury Tales" },
                    { new Guid("245a11ec-ed95-4957-ba37-04aa6fa15016"), new Guid("eb25c724-d36d-4f31-b420-407b4dcaf2d5"), "Frank Herbert's science fiction epic set in a distant future where noble houses vie for control of the desert planet Arrakis and its valuable spice melange.", "978-0-44-117271-9", "Dune" },
                    { new Guid("302f95fa-d26f-4032-afcd-b2e2ac75162a"), new Guid("76bceedd-b908-4537-910c-c5765121210d"), null, "978-0-54-792822-7", "The Hobbit" },
                    { new Guid("35ecccd2-374a-4d41-9bfa-7d3ee82d5e7e"), new Guid("fe798bc6-ff2e-47f1-ad28-12a819230cc6"), "John Green's heart-wrenching novel about two teenagers with cancer who fall in love.", "978-0-14-242417-9", "The Fault in Our Stars" },
                    { new Guid("3e9d4bdb-d1ef-44e6-8fdf-df7742cabb4e"), new Guid("76bceedd-b908-4537-910c-c5765121210d"), null, "978-0-14-200174-5", "The Secret Life of Bees" },
                    { new Guid("4278e19f-46d2-4a9a-b37c-482962d2fcd7"), new Guid("5d9ac423-8c27-4728-a524-bdaae18c3211"), "Douglas Adams's hilarious space adventure, following the misadventures of Arthur Dent and his extraterrestrial friend Ford Prefect.", "978-0-34-539180-3", "The Hitchhiker's Guide to the Galaxy" },
                    { new Guid("4571b00c-4105-480c-bb46-7460fc5e1857"), new Guid("fe798bc6-ff2e-47f1-ad28-12a819230cc6"), "M. Scott Peck's exploration of personal growth, love, and spiritual development.", "978-0-74-324315-8", "The Road Less Traveled" },
                    { new Guid("46637532-4091-4793-8e80-b1bc3ec93c7f"), new Guid("2fe334ca-0dc3-403b-8e7b-eb04ffaefeaf"), "Stephen King's chilling tale of supernatural horror, isolation, and the descent into madness at the haunted Overlook Hotel.", "978-0-38-511683-7", "The Shining" },
                    { new Guid("474e27d2-84f1-4329-ba69-2dcdfac76a13"), new Guid("80e1451b-f47a-4cce-8c23-318a70b4299b"), null, "978-0-37-584220-7", "The Book Thief" },
                    { new Guid("526d5165-3dfb-40ec-bc96-f20388af40b9"), new Guid("a56e7c68-5697-4fc1-9fcd-997b32c6f549"), "Charles Duhigg's exploration of the science behind habits and how they can be transformed.", "978-0-81-298160-5", "The Power of Habit" },
                    { new Guid("574a7bfb-4c3d-4079-97f3-c1b520c92924"), new Guid("2356606f-dbb3-4091-abeb-60d2fc72d6fa"), "Andy Weir's gripping science fiction novel about an astronaut stranded on Mars and his fight for survival.", "978-0-55-341802-6", "The Martian" },
                    { new Guid("57bf4a63-04d5-4434-999d-2d960e570dc1"), new Guid("2fe334ca-0dc3-403b-8e7b-eb04ffaefeaf"), "Alexandre Dumas's classic adventure novel of betrayal, revenge, and redemption.", "978-0-14-044926-6", "The Count of Monte Cristo" },
                    { new Guid("580b58e8-92d3-4ff3-a423-e31c9567a64c"), new Guid("a5929383-328e-4c23-a876-0fcd352d462a"), "C.S. Lewis's beloved fantasy series, taking readers to the enchanting land of Narnia and its magical inhabitants.", "978-0-06-112008-4", "The Chronicles of Narnia" },
                    { new Guid("5adfc3eb-ba0e-437d-926e-c421ca6dc0da"), new Guid("0df4da33-d590-491c-8941-118c178fe18e"), null, "978-0-52-551488-0", "The Immortalists" },
                    { new Guid("61fa2b59-5266-4c35-840e-4116c2c05fd0"), new Guid("814afe3e-d821-45c7-a1b1-e4e4813f45e2"), "Dan Brown's gripping mystery involving symbology, art, and secret societies.", "978-0-30-747427-8", "The Da Vinci Code" },
                    { new Guid("667607d0-7799-4bee-99ef-5837e4205a0b"), new Guid("f23804d9-eb6a-439d-8928-9a96b3900456"), "Mary Shelley's gothic tale of scientific hubris and the consequences of creating life.", "978-0-48-628211-4", "Frankenstein" },
                    { new Guid("6ad3551f-e70c-4831-b90b-56c6c7ecee99"), new Guid("c12cc196-28fb-481b-b6ad-81e87a8fa8c6"), "Herman Melville's epic journey aboard the whaling ship Pequod, driven by Captain Ahab's obsessive quest for the white whale.", "978-0-14-310635-7", "Moby-Dick" },
                    { new Guid("6e5be676-ca81-44dd-beb1-560ccb97c2bc"), new Guid("c4b61f12-d22b-4422-859e-f000430b0bc1"), "Leo Tolstoy's epic portrayal of Russian society during the Napoleonic Wars, blending history, philosophy, and human drama.", "978-0-14-303500-8", "War and Peace" },
                    { new Guid("7a4a64be-ae4f-49ea-98eb-7b19b122edd1"), new Guid("c4b61f12-d22b-4422-859e-f000430b0bc1"), null, "978-0-06-112028-4", "One Hundred Years of Solitude" },
                    { new Guid("82093d00-46ec-42b3-84d7-8508be0e6786"), new Guid("0521ad2c-765f-42ba-a427-503540164431"), null, "978-0-14-044022-5", "The Three Musketeers" },
                    { new Guid("83c61a3e-650b-425e-98cc-964a62314033"), new Guid("2fe334ca-0dc3-403b-8e7b-eb04ffaefeaf"), "Erin Morgenstern's magical tale of a mysterious competition between two illusionists in a magical circus.", "978-0-38-553970-6", "The Night Circus" },
                    { new Guid("84673902-3fe0-460d-8387-5c07d4c86a65"), new Guid("80e1451b-f47a-4cce-8c23-318a70b4299b"), "Amy Tan's novel exploring the relationships between Chinese-American immigrant mothers and their American-born daughters.", "978-0-80-417839-9", "The Joy Luck Club" },
                    { new Guid("84d30260-a3a4-42c3-82d6-f0560bf08e00"), new Guid("5a992b40-a12e-429f-a8a2-3227ac309eb8"), "George Orwell's dystopian masterpiece, depicting a nightmarish future under totalitarian rule.", "978-0-45-152493-5", "1984" },
                    { new Guid("87d08e42-a569-4613-98e1-aa8ba0ca2288"), new Guid("5a992b40-a12e-429f-a8a2-3227ac309eb8"), "Jeannette Walls's memoir detailing her unconventional and often troubled childhood.", "978-0-74-324754-5", "The Glass Castle" },
                    { new Guid("8a9963cf-111d-44d4-97ab-c6bf2409c2d1"), new Guid("a5929383-328e-4c23-a876-0fcd352d462a"), null, "978-0-14-143955-6", "Wuthering Heights" },
                    { new Guid("8ce03732-06fe-439e-b36c-ff18348be186"), new Guid("ee8fbf04-993c-4338-b250-e2d058e8d138"), "Haruki Murakami's surreal and mesmerizing novel exploring the mysteries of human consciousness.", "978-0-67-977543-0", "The Wind-Up Bird Chronicle" },
                    { new Guid("945f95cb-8575-486c-930f-5a940ab7274e"), new Guid("80e1451b-f47a-4cce-8c23-318a70b4299b"), "Fyodor Dostoevsky's exploration of morality, faith, and family dynamics through the complex relationships of the Karamazov brothers.", "978-0-14-044924-2", "The Brothers Karamazov" },
                    { new Guid("95a78143-b9bd-4920-b58b-f9ce8560ed76"), new Guid("5d9ac423-8c27-4728-a524-bdaae18c3211"), null, "978-0-14-143957-0", "The Picture of Dorian Gray" },
                    { new Guid("9c9a0582-7ff2-410b-90fa-a5170e302b98"), new Guid("d973ab12-02f5-4f51-a40d-66cad7cccfae"), "Tara Westover's memoir recounting her journey from a rural Idaho childhood to gaining an education against all odds.", "978-0-52-558019-4", "Educated" },
                    { new Guid("9df25a01-ac3b-4aed-8016-5818d5d75277"), new Guid("23312545-93d4-4fdc-b18e-a43a0134b43a"), "Harper Lee's powerful exploration of racial injustice and moral growth in the American South.", "978-0-06-112348-4", "To Kill a Mockingbird" },
                    { new Guid("aa897b73-d8dc-433a-8fda-43a9e3f1e185"), new Guid("5e1b881e-9197-4dfb-88c7-3fc6ebfad1c9"), null, "978-1-25-030169-7", "The Silent Patient" },
                    { new Guid("ad83ae84-17e0-4f74-a614-6829134ca021"), new Guid("d973ab12-02f5-4f51-a40d-66cad7cccfae"), "Suzanne Collins's dystopian saga of Katniss Everdeen's fight for survival in the annual Hunger Games.", "978-0-43-902352-8", "The Hunger Games" },
                    { new Guid("af094fed-c54b-4e1c-96d5-f0515d4412a9"), new Guid("0df4da33-d590-491c-8941-118c178fe18e"), "John Steinbeck's novel depicting the struggles of a displaced Oklahoma family during the Great Depression.", "978-0-14-303943-3", "The Grapes of Wrath" },
                    { new Guid("b0bef37c-5964-452b-9ba5-620c07d7ccab"), new Guid("2356606f-dbb3-4091-abeb-60d2fc72d6fa"), null, "978-0-06-085052-4", "Brave New World" },
                    { new Guid("b1da5403-e8e0-40a6-9bda-dc8804f56ded"), new Guid("d973ab12-02f5-4f51-a40d-66cad7cccfae"), "F. Scott Fitzgerald's classic portrayal of the American Dream, excess, and disillusionment in the Roaring Twenties.", "978-0-74-327356-5", "The Great Gatsby" },
                    { new Guid("b1ee63f5-8470-49bf-8fe7-b81cdc4fa6f6"), new Guid("11268797-dd1f-48ac-a50a-595be0ba5368"), "Joseph Heller's satirical novel depicting the absurdities and paradoxes of war.", "978-0-68-484121-9", "The Catch-22" },
                    { new Guid("ce071188-9786-4668-937f-13f08bf7ee35"), new Guid("eb6bb1b5-f557-4e2f-88cf-6be757835043"), "Paula Hawkins's psychological thriller about a woman who becomes entangled in a missing person investigation.", "978-1-59-463402-4", "The Girl on the Train" },
                    { new Guid("cea1b38f-d5fe-4c16-b8bc-de665affefc0"), new Guid("0df4da33-d590-491c-8941-118c178fe18e"), null, "978-0-15-602835-6", "The Color Purple" },
                    { new Guid("d3153c3b-d2ef-497c-abde-95c303d4bfa7"), new Guid("d973ab12-02f5-4f51-a40d-66cad7cccfae"), "Homer's ancient Greek epic, recounting the adventures of Odysseus as he journeys home from the Trojan War.", "978-0-14-303995-2", "The Odyssey" },
                    { new Guid("d65bc50d-e537-48c4-b2ed-498d84c8f30e"), new Guid("e2323aa0-0413-4ef7-afbf-0ee33c3bbf20"), null, "978-0-45-141943-9", "Les Misérables" },
                    { new Guid("d70b5b1c-e525-427c-92c8-cc7b116b3d31"), new Guid("5a992b40-a12e-429f-a8a2-3227ac309eb8"), "Margaret Atwood's dystopian novel set in the Republic of Gilead, where women's rights are severely restricted.", "978-0-38-549081-8", "The Handmaid's Tale" },
                    { new Guid("e0d631bb-7b97-4abd-97b3-67e559ebae8c"), new Guid("6e59ee16-0a7d-43c4-be5e-9adb2219212a"), "Ken Kesey's classic novel set in a mental hospital, challenging authority and celebrating individuality.", "978-0-45-116396-7", "One Flew Over the Cuckoo's Nest" },
                    { new Guid("e1874f15-e51b-489c-8d47-0e7ddd69af99"), new Guid("f23804d9-eb6a-439d-8928-9a96b3900456"), "A timeless tale of love, manners, and societal expectations in Regency-era England by Jane Austen.", "978-0-14-143951-8", "Pride and Prejudice" },
                    { new Guid("e1ea488f-27a3-41c4-945c-a5b488b0eb87"), new Guid("0df4da33-d590-491c-8941-118c178fe18e"), "J.D. Salinger's iconic coming-of-age novel, capturing the angst and rebellion of a teenage boy in post-World War II America.", "978-0-31-676948-0", "The Catcher in the Rye" },
                    { new Guid("e4150e1d-9b95-45d7-8ad3-fa15de300645"), new Guid("11268797-dd1f-48ac-a50a-595be0ba5368"), "J.R.R. Tolkien's epic fantasy trilogy, featuring the quest to destroy the One Ring and save Middle-earth from the dark forces of Sauron.", "978-0-54-400341-5", "The Lord of the Rings" },
                    { new Guid("e4d4bee8-b0b7-4db5-af78-819f67a489ca"), new Guid("a5929383-328e-4c23-a876-0fcd352d462a"), "Khaled Hosseini's powerful novel about friendship, betrayal, and redemption in Afghanistan.", "978-1-59-463193-1", "The Kite Runner" },
                    { new Guid("ed861929-37a9-4dd6-9b5c-ddda3a7af973"), new Guid("ee8fbf04-993c-4338-b250-e2d058e8d138"), "Kathryn Stockett's novel about African American maids working in white households in Jackson, Mississippi, during the early 1960s.", "978-0-42-523220-0", "The Help" },
                    { new Guid("f27ad368-063f-4612-b663-916eb6d53210"), new Guid("e02efb96-c335-47f1-8e49-779a67c76918"), "Stieg Larsson's gripping mystery featuring investigative journalist Mikael Blomkvist and the enigmatic hacker Lisbeth Salander.", "978-0-30-726975-1", "The Girl with the Dragon Tattoo" },
                    { new Guid("fc578e00-9620-4a6d-8cad-8eb9eadb6567"), new Guid("e02efb96-c335-47f1-8e49-779a67c76918"), "Cormac McCarthy's post-apocalyptic tale of a father and son's harrowing journey through a desolate landscape.", "978-0-30-738789-9", "The Road" }
                });

            migrationBuilder.InsertData(
                table: "BooksGenres",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { new Guid("245a11ec-ed95-4957-ba37-04aa6fa15016"), new Guid("100e1c65-4407-41db-a924-fa8d3f146962") },
                    { new Guid("4278e19f-46d2-4a9a-b37c-482962d2fcd7"), new Guid("100e1c65-4407-41db-a924-fa8d3f146962") },
                    { new Guid("526d5165-3dfb-40ec-bc96-f20388af40b9"), new Guid("100e1c65-4407-41db-a924-fa8d3f146962") },
                    { new Guid("57bf4a63-04d5-4434-999d-2d960e570dc1"), new Guid("100e1c65-4407-41db-a924-fa8d3f146962") },
                    { new Guid("95a78143-b9bd-4920-b58b-f9ce8560ed76"), new Guid("100e1c65-4407-41db-a924-fa8d3f146962") },
                    { new Guid("b1da5403-e8e0-40a6-9bda-dc8804f56ded"), new Guid("100e1c65-4407-41db-a924-fa8d3f146962") },
                    { new Guid("d70b5b1c-e525-427c-92c8-cc7b116b3d31"), new Guid("100e1c65-4407-41db-a924-fa8d3f146962") },
                    { new Guid("ed861929-37a9-4dd6-9b5c-ddda3a7af973"), new Guid("100e1c65-4407-41db-a924-fa8d3f146962") },
                    { new Guid("245a11ec-ed95-4957-ba37-04aa6fa15016"), new Guid("1e3b2b42-fde4-4e24-80c1-c7e3df95f181") },
                    { new Guid("302f95fa-d26f-4032-afcd-b2e2ac75162a"), new Guid("1e3b2b42-fde4-4e24-80c1-c7e3df95f181") },
                    { new Guid("3e9d4bdb-d1ef-44e6-8fdf-df7742cabb4e"), new Guid("1e3b2b42-fde4-4e24-80c1-c7e3df95f181") },
                    { new Guid("46637532-4091-4793-8e80-b1bc3ec93c7f"), new Guid("1e3b2b42-fde4-4e24-80c1-c7e3df95f181") },
                    { new Guid("580b58e8-92d3-4ff3-a423-e31c9567a64c"), new Guid("1e3b2b42-fde4-4e24-80c1-c7e3df95f181") },
                    { new Guid("6ad3551f-e70c-4831-b90b-56c6c7ecee99"), new Guid("1e3b2b42-fde4-4e24-80c1-c7e3df95f181") },
                    { new Guid("84d30260-a3a4-42c3-82d6-f0560bf08e00"), new Guid("1e3b2b42-fde4-4e24-80c1-c7e3df95f181") },
                    { new Guid("8ce03732-06fe-439e-b36c-ff18348be186"), new Guid("1e3b2b42-fde4-4e24-80c1-c7e3df95f181") },
                    { new Guid("9c9a0582-7ff2-410b-90fa-a5170e302b98"), new Guid("1e3b2b42-fde4-4e24-80c1-c7e3df95f181") },
                    { new Guid("b1da5403-e8e0-40a6-9bda-dc8804f56ded"), new Guid("1e3b2b42-fde4-4e24-80c1-c7e3df95f181") },
                    { new Guid("e0d631bb-7b97-4abd-97b3-67e559ebae8c"), new Guid("1e3b2b42-fde4-4e24-80c1-c7e3df95f181") },
                    { new Guid("f27ad368-063f-4612-b663-916eb6d53210"), new Guid("1e3b2b42-fde4-4e24-80c1-c7e3df95f181") },
                    { new Guid("093a8c6d-d250-44ff-9f83-bfc0610ecb54"), new Guid("42fff34d-5594-42f4-8748-9d93e11e8fd0") },
                    { new Guid("1e5b98ca-833d-4515-9353-e0cb106a4441"), new Guid("42fff34d-5594-42f4-8748-9d93e11e8fd0") },
                    { new Guid("667607d0-7799-4bee-99ef-5837e4205a0b"), new Guid("42fff34d-5594-42f4-8748-9d93e11e8fd0") },
                    { new Guid("82093d00-46ec-42b3-84d7-8508be0e6786"), new Guid("42fff34d-5594-42f4-8748-9d93e11e8fd0") },
                    { new Guid("4571b00c-4105-480c-bb46-7460fc5e1857"), new Guid("4979e400-dcc0-438d-a28b-e6fafaf540b6") },
                    { new Guid("46637532-4091-4793-8e80-b1bc3ec93c7f"), new Guid("4979e400-dcc0-438d-a28b-e6fafaf540b6") },
                    { new Guid("5adfc3eb-ba0e-437d-926e-c421ca6dc0da"), new Guid("4979e400-dcc0-438d-a28b-e6fafaf540b6") },
                    { new Guid("87d08e42-a569-4613-98e1-aa8ba0ca2288"), new Guid("4979e400-dcc0-438d-a28b-e6fafaf540b6") },
                    { new Guid("11b32795-f5c6-42db-8ecc-3b97c4125271"), new Guid("49902634-a374-4466-a710-cb0708ba8676") },
                    { new Guid("1831af5f-a84b-4bd2-a3c1-8ab7424a2ee0"), new Guid("49902634-a374-4466-a710-cb0708ba8676") },
                    { new Guid("35ecccd2-374a-4d41-9bfa-7d3ee82d5e7e"), new Guid("49902634-a374-4466-a710-cb0708ba8676") },
                    { new Guid("574a7bfb-4c3d-4079-97f3-c1b520c92924"), new Guid("49902634-a374-4466-a710-cb0708ba8676") },
                    { new Guid("57bf4a63-04d5-4434-999d-2d960e570dc1"), new Guid("49902634-a374-4466-a710-cb0708ba8676") },
                    { new Guid("9df25a01-ac3b-4aed-8016-5818d5d75277"), new Guid("49902634-a374-4466-a710-cb0708ba8676") },
                    { new Guid("ad83ae84-17e0-4f74-a614-6829134ca021"), new Guid("49902634-a374-4466-a710-cb0708ba8676") },
                    { new Guid("e4150e1d-9b95-45d7-8ad3-fa15de300645"), new Guid("49902634-a374-4466-a710-cb0708ba8676") },
                    { new Guid("61fa2b59-5266-4c35-840e-4116c2c05fd0"), new Guid("5b9072bb-bb3f-402f-bcd9-fc924a83cc06") },
                    { new Guid("9df25a01-ac3b-4aed-8016-5818d5d75277"), new Guid("5b9072bb-bb3f-402f-bcd9-fc924a83cc06") },
                    { new Guid("e1ea488f-27a3-41c4-945c-a5b488b0eb87"), new Guid("5b9072bb-bb3f-402f-bcd9-fc924a83cc06") },
                    { new Guid("fc578e00-9620-4a6d-8cad-8eb9eadb6567"), new Guid("5b9072bb-bb3f-402f-bcd9-fc924a83cc06") },
                    { new Guid("11b32795-f5c6-42db-8ecc-3b97c4125271"), new Guid("7542901e-05d1-45a7-825b-ecd0afb9758b") },
                    { new Guid("474e27d2-84f1-4329-ba69-2dcdfac76a13"), new Guid("7542901e-05d1-45a7-825b-ecd0afb9758b") },
                    { new Guid("61fa2b59-5266-4c35-840e-4116c2c05fd0"), new Guid("7542901e-05d1-45a7-825b-ecd0afb9758b") },
                    { new Guid("667607d0-7799-4bee-99ef-5837e4205a0b"), new Guid("7542901e-05d1-45a7-825b-ecd0afb9758b") },
                    { new Guid("6e5be676-ca81-44dd-beb1-560ccb97c2bc"), new Guid("7542901e-05d1-45a7-825b-ecd0afb9758b") },
                    { new Guid("87d08e42-a569-4613-98e1-aa8ba0ca2288"), new Guid("7542901e-05d1-45a7-825b-ecd0afb9758b") },
                    { new Guid("b1ee63f5-8470-49bf-8fe7-b81cdc4fa6f6"), new Guid("7542901e-05d1-45a7-825b-ecd0afb9758b") },
                    { new Guid("e1874f15-e51b-489c-8d47-0e7ddd69af99"), new Guid("7542901e-05d1-45a7-825b-ecd0afb9758b") },
                    { new Guid("fc578e00-9620-4a6d-8cad-8eb9eadb6567"), new Guid("7542901e-05d1-45a7-825b-ecd0afb9758b") },
                    { new Guid("093a8c6d-d250-44ff-9f83-bfc0610ecb54"), new Guid("77ddc50d-0025-40e4-98d2-c9a03ef16fa6") },
                    { new Guid("1831af5f-a84b-4bd2-a3c1-8ab7424a2ee0"), new Guid("77ddc50d-0025-40e4-98d2-c9a03ef16fa6") },
                    { new Guid("474e27d2-84f1-4329-ba69-2dcdfac76a13"), new Guid("77ddc50d-0025-40e4-98d2-c9a03ef16fa6") },
                    { new Guid("57bf4a63-04d5-4434-999d-2d960e570dc1"), new Guid("77ddc50d-0025-40e4-98d2-c9a03ef16fa6") },
                    { new Guid("6ad3551f-e70c-4831-b90b-56c6c7ecee99"), new Guid("77ddc50d-0025-40e4-98d2-c9a03ef16fa6") },
                    { new Guid("8a9963cf-111d-44d4-97ab-c6bf2409c2d1"), new Guid("77ddc50d-0025-40e4-98d2-c9a03ef16fa6") },
                    { new Guid("b0bef37c-5964-452b-9ba5-620c07d7ccab"), new Guid("77ddc50d-0025-40e4-98d2-c9a03ef16fa6") },
                    { new Guid("ce071188-9786-4668-937f-13f08bf7ee35"), new Guid("77ddc50d-0025-40e4-98d2-c9a03ef16fa6") },
                    { new Guid("11b32795-f5c6-42db-8ecc-3b97c4125271"), new Guid("7e3f1dac-1cbb-47ad-866d-74cfd14d3c9d") },
                    { new Guid("17414652-443e-4b84-8cb4-199911bce604"), new Guid("7e3f1dac-1cbb-47ad-866d-74cfd14d3c9d") },
                    { new Guid("84d30260-a3a4-42c3-82d6-f0560bf08e00"), new Guid("7e3f1dac-1cbb-47ad-866d-74cfd14d3c9d") },
                    { new Guid("8ce03732-06fe-439e-b36c-ff18348be186"), new Guid("7e3f1dac-1cbb-47ad-866d-74cfd14d3c9d") },
                    { new Guid("b1da5403-e8e0-40a6-9bda-dc8804f56ded"), new Guid("7e3f1dac-1cbb-47ad-866d-74cfd14d3c9d") },
                    { new Guid("cea1b38f-d5fe-4c16-b8bc-de665affefc0"), new Guid("7e3f1dac-1cbb-47ad-866d-74cfd14d3c9d") },
                    { new Guid("3e9d4bdb-d1ef-44e6-8fdf-df7742cabb4e"), new Guid("83163730-951b-4548-bfd3-0638896dc6da") },
                    { new Guid("7a4a64be-ae4f-49ea-98eb-7b19b122edd1"), new Guid("83163730-951b-4548-bfd3-0638896dc6da") },
                    { new Guid("83c61a3e-650b-425e-98cc-964a62314033"), new Guid("83163730-951b-4548-bfd3-0638896dc6da") },
                    { new Guid("84673902-3fe0-460d-8387-5c07d4c86a65"), new Guid("83163730-951b-4548-bfd3-0638896dc6da") },
                    { new Guid("9df25a01-ac3b-4aed-8016-5818d5d75277"), new Guid("83163730-951b-4548-bfd3-0638896dc6da") },
                    { new Guid("ad83ae84-17e0-4f74-a614-6829134ca021"), new Guid("83163730-951b-4548-bfd3-0638896dc6da") },
                    { new Guid("d3153c3b-d2ef-497c-abde-95c303d4bfa7"), new Guid("83163730-951b-4548-bfd3-0638896dc6da") },
                    { new Guid("07ec9696-d9e6-4c0d-8be8-c2441c6d02b2"), new Guid("84409865-5d9e-478b-ab81-8aa445b2f4a2") },
                    { new Guid("57bf4a63-04d5-4434-999d-2d960e570dc1"), new Guid("84409865-5d9e-478b-ab81-8aa445b2f4a2") },
                    { new Guid("5adfc3eb-ba0e-437d-926e-c421ca6dc0da"), new Guid("84409865-5d9e-478b-ab81-8aa445b2f4a2") },
                    { new Guid("ce071188-9786-4668-937f-13f08bf7ee35"), new Guid("84409865-5d9e-478b-ab81-8aa445b2f4a2") },
                    { new Guid("474e27d2-84f1-4329-ba69-2dcdfac76a13"), new Guid("88a4bd49-fe23-4a28-8995-82130e504ead") },
                    { new Guid("580b58e8-92d3-4ff3-a423-e31c9567a64c"), new Guid("88a4bd49-fe23-4a28-8995-82130e504ead") },
                    { new Guid("945f95cb-8575-486c-930f-5a940ab7274e"), new Guid("88a4bd49-fe23-4a28-8995-82130e504ead") },
                    { new Guid("d70b5b1c-e525-427c-92c8-cc7b116b3d31"), new Guid("88a4bd49-fe23-4a28-8995-82130e504ead") },
                    { new Guid("07bace45-b504-4f2f-b6d5-3f7a5b43896a"), new Guid("9a7e4a9c-b054-4e43-bbe1-1f7aead8b4db") },
                    { new Guid("245a11ec-ed95-4957-ba37-04aa6fa15016"), new Guid("9a7e4a9c-b054-4e43-bbe1-1f7aead8b4db") },
                    { new Guid("302f95fa-d26f-4032-afcd-b2e2ac75162a"), new Guid("9a7e4a9c-b054-4e43-bbe1-1f7aead8b4db") },
                    { new Guid("667607d0-7799-4bee-99ef-5837e4205a0b"), new Guid("9a7e4a9c-b054-4e43-bbe1-1f7aead8b4db") },
                    { new Guid("ad83ae84-17e0-4f74-a614-6829134ca021"), new Guid("9a7e4a9c-b054-4e43-bbe1-1f7aead8b4db") },
                    { new Guid("b1ee63f5-8470-49bf-8fe7-b81cdc4fa6f6"), new Guid("9a7e4a9c-b054-4e43-bbe1-1f7aead8b4db") },
                    { new Guid("e1ea488f-27a3-41c4-945c-a5b488b0eb87"), new Guid("9a7e4a9c-b054-4e43-bbe1-1f7aead8b4db") },
                    { new Guid("0899c3aa-33ac-4ea6-acd5-c719f5680f5d"), new Guid("a366cd89-7e8a-4c30-889e-2215c28cc734") },
                    { new Guid("3e9d4bdb-d1ef-44e6-8fdf-df7742cabb4e"), new Guid("a366cd89-7e8a-4c30-889e-2215c28cc734") },
                    { new Guid("46637532-4091-4793-8e80-b1bc3ec93c7f"), new Guid("a366cd89-7e8a-4c30-889e-2215c28cc734") },
                    { new Guid("574a7bfb-4c3d-4079-97f3-c1b520c92924"), new Guid("a366cd89-7e8a-4c30-889e-2215c28cc734") },
                    { new Guid("6ad3551f-e70c-4831-b90b-56c6c7ecee99"), new Guid("a366cd89-7e8a-4c30-889e-2215c28cc734") },
                    { new Guid("aa897b73-d8dc-433a-8fda-43a9e3f1e185"), new Guid("a366cd89-7e8a-4c30-889e-2215c28cc734") },
                    { new Guid("af094fed-c54b-4e1c-96d5-f0515d4412a9"), new Guid("a366cd89-7e8a-4c30-889e-2215c28cc734") },
                    { new Guid("d65bc50d-e537-48c4-b2ed-498d84c8f30e"), new Guid("a366cd89-7e8a-4c30-889e-2215c28cc734") },
                    { new Guid("e0d631bb-7b97-4abd-97b3-67e559ebae8c"), new Guid("a366cd89-7e8a-4c30-889e-2215c28cc734") },
                    { new Guid("e1874f15-e51b-489c-8d47-0e7ddd69af99"), new Guid("a366cd89-7e8a-4c30-889e-2215c28cc734") },
                    { new Guid("1831af5f-a84b-4bd2-a3c1-8ab7424a2ee0"), new Guid("ab4bc0d0-c950-4bef-b6f5-8c3b28c80836") },
                    { new Guid("4278e19f-46d2-4a9a-b37c-482962d2fcd7"), new Guid("ab4bc0d0-c950-4bef-b6f5-8c3b28c80836") },
                    { new Guid("af094fed-c54b-4e1c-96d5-f0515d4412a9"), new Guid("ab4bc0d0-c950-4bef-b6f5-8c3b28c80836") },
                    { new Guid("d65bc50d-e537-48c4-b2ed-498d84c8f30e"), new Guid("ab4bc0d0-c950-4bef-b6f5-8c3b28c80836") },
                    { new Guid("d70b5b1c-e525-427c-92c8-cc7b116b3d31"), new Guid("ab4bc0d0-c950-4bef-b6f5-8c3b28c80836") },
                    { new Guid("e4150e1d-9b95-45d7-8ad3-fa15de300645"), new Guid("ab4bc0d0-c950-4bef-b6f5-8c3b28c80836") },
                    { new Guid("17414652-443e-4b84-8cb4-199911bce604"), new Guid("abe4de7c-b3a5-4c75-b274-42ba15ef2e65") },
                    { new Guid("b1ee63f5-8470-49bf-8fe7-b81cdc4fa6f6"), new Guid("abe4de7c-b3a5-4c75-b274-42ba15ef2e65") },
                    { new Guid("e1ea488f-27a3-41c4-945c-a5b488b0eb87"), new Guid("abe4de7c-b3a5-4c75-b274-42ba15ef2e65") },
                    { new Guid("e4d4bee8-b0b7-4db5-af78-819f67a489ca"), new Guid("abe4de7c-b3a5-4c75-b274-42ba15ef2e65") },
                    { new Guid("ed861929-37a9-4dd6-9b5c-ddda3a7af973"), new Guid("abe4de7c-b3a5-4c75-b274-42ba15ef2e65") },
                    { new Guid("07bace45-b504-4f2f-b6d5-3f7a5b43896a"), new Guid("dd497a53-1396-40b5-a9a6-aa0563ad84b1") },
                    { new Guid("4571b00c-4105-480c-bb46-7460fc5e1857"), new Guid("dd497a53-1396-40b5-a9a6-aa0563ad84b1") },
                    { new Guid("84673902-3fe0-460d-8387-5c07d4c86a65"), new Guid("dd497a53-1396-40b5-a9a6-aa0563ad84b1") },
                    { new Guid("87d08e42-a569-4613-98e1-aa8ba0ca2288"), new Guid("dd497a53-1396-40b5-a9a6-aa0563ad84b1") },
                    { new Guid("9c9a0582-7ff2-410b-90fa-a5170e302b98"), new Guid("dd497a53-1396-40b5-a9a6-aa0563ad84b1") },
                    { new Guid("b1da5403-e8e0-40a6-9bda-dc8804f56ded"), new Guid("dd497a53-1396-40b5-a9a6-aa0563ad84b1") },
                    { new Guid("ed861929-37a9-4dd6-9b5c-ddda3a7af973"), new Guid("dd497a53-1396-40b5-a9a6-aa0563ad84b1") }
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
