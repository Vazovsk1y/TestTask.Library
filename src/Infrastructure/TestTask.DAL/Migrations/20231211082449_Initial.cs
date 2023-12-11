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
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
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
                        name: "FK_BooksHireRecords_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
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
                    { new Guid("079540e9-5013-4fda-a6bb-a217c1d2f243"), "Margaret Atwood" },
                    { new Guid("1223f27d-e2d8-4342-b524-bccd42a5cc92"), "Kurt Vonnegut" },
                    { new Guid("133dd1b0-9251-4ff3-8e60-35a0d005ceb4"), "Isaac Asimov" },
                    { new Guid("16780e43-6e2f-40de-b786-7525ac3f8753"), "H.G. Wells" },
                    { new Guid("175df3ff-da72-4eb7-969c-9b422d779fd3"), "Virginia Woolf" },
                    { new Guid("21170579-8f47-48c8-a41a-266124770b5a"), "Charlotte Brontë" },
                    { new Guid("21fbb7f9-30e0-4911-a616-e13a6d3a80fe"), "Hermann Hesse" },
                    { new Guid("46aed2bf-b21d-4731-921b-acec93be34c3"), "Toni Morrison" },
                    { new Guid("516caece-3437-4dd7-9839-8a5043e65a46"), "Homer" },
                    { new Guid("52c70c29-ff87-40a7-8cc8-46d0290cd5f3"), "Michael Crichton" },
                    { new Guid("64b71e73-58a1-43f2-b461-036fa26f7fcb"), "Emily Brontë" },
                    { new Guid("6513ce88-800e-4129-a47e-7f856328a9b0"), "William Shakespeare" },
                    { new Guid("6dd310ce-a007-48b3-bf40-e4380897e200"), "Gabriel García Márquez" },
                    { new Guid("74de59d0-fb8e-485b-958c-5861bf9d1130"), "F. Scott Fitzgerald" },
                    { new Guid("79260a8c-0957-4f10-b830-91698b2e219c"), "Harper Lee" },
                    { new Guid("86b99160-6f76-4e96-bb17-0ee3a4c21aa6"), "J.K. Rowling" },
                    { new Guid("8780a8de-0576-49d6-a781-48211edaa32d"), "Leo Tolstoy" },
                    { new Guid("8f3b7a7a-99c0-4743-87a0-20be60f48b8b"), "Jane Goodall" },
                    { new Guid("90938517-f842-43ca-9067-7d48bc0f2bee"), "Charles Dickens" },
                    { new Guid("93774efc-253a-4c9a-b10c-1652ef14c3a0"), "Mark Twain" },
                    { new Guid("98ab917f-3163-43af-9f3a-fc50db1c1cc0"), "Jane Austen" },
                    { new Guid("9d43d676-5e95-4861-be75-b2bba76af8b5"), "Aldous Huxley" },
                    { new Guid("b592b8c2-5c2e-4592-9b58-41359ad5bbea"), "Ayn Rand" },
                    { new Guid("b7633d0c-a97d-4564-99db-f30b216eedc6"), "Arthur Conan Doyle" },
                    { new Guid("bc409169-7ea1-4850-90df-53fa0dd181fc"), "Agatha Christie" },
                    { new Guid("c248abca-7177-4da7-a1b9-d78720d5f01f"), "Ernest Hemingway" },
                    { new Guid("ced2a24a-732b-4744-87b2-7d3468f28fce"), "J.R.R. Tolkien" },
                    { new Guid("d5b2752d-4454-44a1-83fc-29372aed73c7"), "Stephen King" },
                    { new Guid("e1e15c69-e5f7-425d-9a91-59e3dd366bea"), "George Orwell" },
                    { new Guid("e63cca5a-111f-47e1-b5d5-8a88f2bf5006"), "Roald Dahl" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("06c56ed3-cc67-4f1f-b1ce-f564000e33af"), "Travel" },
                    { new Guid("39726e1a-7a3c-4822-8afc-9a8cc7dd445e"), "Horror" },
                    { new Guid("5a72e833-d1ce-45f0-aa66-55a5a6ddeed3"), "Fantasy" },
                    { new Guid("63bdc34b-5143-4dea-8d34-38dbafc72c63"), "Science Fiction" },
                    { new Guid("674eaa8f-3760-4b07-ae22-f24b15d4d45f"), "Self-Help" },
                    { new Guid("6b803fcf-f4fa-4f62-9acc-851cc4745512"), "Business" },
                    { new Guid("8f220de1-b593-4bf2-9bf1-33c213491d79"), "Historical Fiction" },
                    { new Guid("a1278d68-f099-4d99-92cf-21504b4af305"), "Drama" },
                    { new Guid("a4945a91-3cb1-418b-ba8e-2f4435349fa3"), "Biography" },
                    { new Guid("c1d58ffa-0f1d-442b-9248-41d31431e8f2"), "Thriller" },
                    { new Guid("c3a86636-203c-4475-8cea-567646ad2a32"), "Adventure" },
                    { new Guid("c5b2c854-275d-477d-8c37-ac3c4b1fa535"), "Comedy" },
                    { new Guid("c65881aa-ec34-4bdd-85b9-58f4c4c3c795"), "Cookbook" },
                    { new Guid("cd0e257b-92f1-46e4-a452-79ce1626c88e"), "Poetry" },
                    { new Guid("d4c07071-05b6-4846-b84f-decc69ddb08c"), "Romance" },
                    { new Guid("dca4afa1-cd3d-46f7-bd6f-9ee3476c4589"), "Non-Fiction" },
                    { new Guid("dfa917b1-fe4b-4c1e-9058-da239f55c7f0"), "Science" },
                    { new Guid("fa635920-0c61-49be-ace0-3a5b4aa13b0a"), "Mystery" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "ISBN", "Title" },
                values: new object[,]
                {
                    { new Guid("01908b56-06dc-43b3-b828-9d2f6d7cc0c2"), new Guid("079540e9-5013-4fda-a6bb-a217c1d2f243"), "Douglas Adams's hilarious space adventure, following the misadventures of Arthur Dent and his extraterrestrial friend Ford Prefect.", "978-0-34-539180-3", "The Hitchhiker's Guide to the Galaxy" },
                    { new Guid("0b0b9f27-802f-4e85-8bbd-c70b48641123"), new Guid("b7633d0c-a97d-4564-99db-f30b216eedc6"), null, "978-0-19-921613-3", "Alice's Adventures in Wonderland" },
                    { new Guid("181f69bd-3756-4bc7-a43a-4b5c41461cd9"), new Guid("52c70c29-ff87-40a7-8cc8-46d0290cd5f3"), "Erin Morgenstern's magical tale of a mysterious competition between two illusionists in a magical circus.", "978-0-38-553970-6", "The Night Circus" },
                    { new Guid("20939ac3-5e65-4c08-b438-0a2dc2fa3a1a"), new Guid("175df3ff-da72-4eb7-969c-9b422d779fd3"), "John Green's heart-wrenching novel about two teenagers with cancer who fall in love.", "978-0-14-242417-9", "The Fault in Our Stars" },
                    { new Guid("27dfba61-d9d0-4c93-bac1-a12a6a8c717f"), new Guid("8780a8de-0576-49d6-a781-48211edaa32d"), "Haruki Murakami's surreal and mesmerizing novel exploring the mysteries of human consciousness.", "978-0-67-977543-0", "The Wind-Up Bird Chronicle" },
                    { new Guid("28569081-d422-4b71-9f9c-4cc22f7bec7d"), new Guid("ced2a24a-732b-4744-87b2-7d3468f28fce"), "Charles Duhigg's exploration of the science behind habits and how they can be transformed.", "978-0-81-298160-5", "The Power of Habit" },
                    { new Guid("300be501-adfe-4eda-9fe6-03ecf9ebbec0"), new Guid("90938517-f842-43ca-9067-7d48bc0f2bee"), "Frank Herbert's science fiction epic set in a distant future where noble houses vie for control of the desert planet Arrakis and its valuable spice melange.", "978-0-44-117271-9", "Dune" },
                    { new Guid("31ba1edf-a578-40b3-81fd-ac291495017c"), new Guid("b7633d0c-a97d-4564-99db-f30b216eedc6"), "C.S. Lewis's beloved fantasy series, taking readers to the enchanting land of Narnia and its magical inhabitants.", "978-0-06-112008-4", "The Chronicles of Narnia" },
                    { new Guid("3435e764-2930-470e-8826-5b5fd3b098f3"), new Guid("98ab917f-3163-43af-9f3a-fc50db1c1cc0"), "Herman Melville's epic journey aboard the whaling ship Pequod, driven by Captain Ahab's obsessive quest for the white whale.", "978-0-14-310635-7", "Moby-Dick" },
                    { new Guid("34ca9f52-d97e-4c5b-826d-17cf14db7a8b"), new Guid("79260a8c-0957-4f10-b830-91698b2e219c"), "Andy Weir's gripping science fiction novel about an astronaut stranded on Mars and his fight for survival.", "978-0-55-341802-6", "The Martian" },
                    { new Guid("3503bdf4-978d-421a-a488-9f2a049f6b4c"), new Guid("079540e9-5013-4fda-a6bb-a217c1d2f243"), "Mary Shelley's gothic tale of scientific hubris and the consequences of creating life.", "978-0-48-628211-4", "Frankenstein" },
                    { new Guid("37dc49d3-76bc-4b9e-8598-360181f66196"), new Guid("133dd1b0-9251-4ff3-8e60-35a0d005ceb4"), "J.D. Salinger's iconic coming-of-age novel, capturing the angst and rebellion of a teenage boy in post-World War II America.", "978-0-31-676948-0", "The Catcher in the Rye" },
                    { new Guid("3ffa4aec-59c1-4ff4-acd5-1e7ddd1478d9"), new Guid("6513ce88-800e-4129-a47e-7f856328a9b0"), "Paulo Coelho's philosophical novel about Santiago, a shepherd boy, on a journey to discover his personal legend.", "978-0-06-112241-5", "The Alchemist" },
                    { new Guid("40923629-d9e0-4db5-8128-f2ec66a5b12a"), new Guid("079540e9-5013-4fda-a6bb-a217c1d2f243"), "Margaret Atwood's dystopian novel set in the Republic of Gilead, where women's rights are severely restricted.", "978-0-38-549081-8", "The Handmaid's Tale" },
                    { new Guid("4459c13c-f848-4aa4-ae42-f299e9d612fe"), new Guid("9d43d676-5e95-4861-be75-b2bba76af8b5"), null, "978-0-37-584220-7", "The Book Thief" },
                    { new Guid("4555dcdf-4f39-4eba-b192-69cb694cd4e1"), new Guid("86b99160-6f76-4e96-bb17-0ee3a4c21aa6"), "Yuval Noah Harari's exploration of the history and impact of Homo sapiens on the world.", "978-0-99-711060-8", "Sapiens: A Brief History of Humankind" },
                    { new Guid("49d6f6d0-10e1-4997-b023-0b2f7d15d43f"), new Guid("b7633d0c-a97d-4564-99db-f30b216eedc6"), null, "978-1-25-030169-7", "The Silent Patient" },
                    { new Guid("4bfff86c-aca1-48a1-8968-65bcc6b5f334"), new Guid("1223f27d-e2d8-4342-b524-bccd42a5cc92"), null, "978-0-14-143955-6", "Wuthering Heights" },
                    { new Guid("4d04d1fd-19fa-42aa-a513-5415e8340f83"), new Guid("b592b8c2-5c2e-4592-9b58-41359ad5bbea"), "Donna Tartt's Pulitzer Prize-winning novel about a young boy's life after a terrorist attack in a New York art museum.", "978-0-31-605543-7", "The Goldfinch" },
                    { new Guid("5304db79-d521-4115-80da-fcb1f68e2b42"), new Guid("8780a8de-0576-49d6-a781-48211edaa32d"), null, "978-0-06-112028-4", "One Hundred Years of Solitude" },
                    { new Guid("5c334b61-e2a6-4eb4-a8c7-8a04416ad80a"), new Guid("93774efc-253a-4c9a-b10c-1652ef14c3a0"), "Joseph Heller's satirical novel depicting the absurdities and paradoxes of war.", "978-0-68-484121-9", "The Catch-22" },
                    { new Guid("618131df-0838-4027-b04a-2581d5b2fda4"), new Guid("9d43d676-5e95-4861-be75-b2bba76af8b5"), "Leo Tolstoy's epic portrayal of Russian society during the Napoleonic Wars, blending history, philosophy, and human drama.", "978-0-14-303500-8", "War and Peace" },
                    { new Guid("633a6c2f-e200-405b-a42b-37c06aebb35b"), new Guid("b592b8c2-5c2e-4592-9b58-41359ad5bbea"), "Alexandre Dumas's classic adventure novel of betrayal, revenge, and redemption.", "978-0-14-044926-6", "The Count of Monte Cristo" },
                    { new Guid("64977bb3-d94c-4a18-a021-0262696a153d"), new Guid("52c70c29-ff87-40a7-8cc8-46d0290cd5f3"), "Rebecca Skloot's biography exploring the life and legacy of Henrietta Lacks, whose cells were used for medical research without her knowledge.", "978-1-40-005217-2", "The Immortal Life of Henrietta Lacks" },
                    { new Guid("67e2ad32-674b-48c8-9f6a-96b239faf9b6"), new Guid("b7633d0c-a97d-4564-99db-f30b216eedc6"), "Harper Lee's powerful exploration of racial injustice and moral growth in the American South.", "978-0-06-112348-4", "To Kill a Mockingbird" },
                    { new Guid("6b3bf8bc-e501-4d71-91ff-b28492210da4"), new Guid("e63cca5a-111f-47e1-b5d5-8a88f2bf5006"), "Suzanne Collins's dystopian saga of Katniss Everdeen's fight for survival in the annual Hunger Games.", "978-0-43-902352-8", "The Hunger Games" },
                    { new Guid("6fcda34e-0083-46e1-bd7d-61d668ca1f87"), new Guid("6dd310ce-a007-48b3-bf40-e4380897e200"), "Jeannette Walls's memoir detailing her unconventional and often troubled childhood.", "978-0-74-324754-5", "The Glass Castle" },
                    { new Guid("7a6ee1a3-49f1-4717-9149-e8e3ebb938b3"), new Guid("74de59d0-fb8e-485b-958c-5861bf9d1130"), null, "978-0-14-200174-5", "The Secret Life of Bees" },
                    { new Guid("7c217837-2cd7-47d1-88c7-676f2332b52f"), new Guid("133dd1b0-9251-4ff3-8e60-35a0d005ceb4"), "Homer's ancient Greek epic, recounting the adventures of Odysseus as he journeys home from the Trojan War.", "978-0-14-303995-2", "The Odyssey" },
                    { new Guid("85b4a2f5-e9f1-4d9f-9487-244107f5734a"), new Guid("86b99160-6f76-4e96-bb17-0ee3a4c21aa6"), "Ken Kesey's classic novel set in a mental hospital, challenging authority and celebrating individuality.", "978-0-45-116396-7", "One Flew Over the Cuckoo's Nest" },
                    { new Guid("861c2273-d46f-40cd-be54-ba71f0d01958"), new Guid("52c70c29-ff87-40a7-8cc8-46d0290cd5f3"), "J.K. Rowling's enchanting introduction to the wizarding world, filled with magic, friendship, and adventure.", "978-0-59-035342-7", "Harry Potter and the Sorcerer's Stone" },
                    { new Guid("8ba41b69-5de2-4759-be90-e86834abe8f9"), new Guid("74de59d0-fb8e-485b-958c-5861bf9d1130"), null, "978-0-45-141943-9", "Les Misérables" },
                    { new Guid("8f85d6c1-a18c-4687-ae7a-1d2e4d39bac5"), new Guid("21fbb7f9-30e0-4911-a616-e13a6d3a80fe"), "Tara Westover's memoir recounting her journey from a rural Idaho childhood to gaining an education against all odds.", "978-0-52-558019-4", "Educated" },
                    { new Guid("a17210e7-9845-479e-8d85-658acab39541"), new Guid("16780e43-6e2f-40de-b786-7525ac3f8753"), null, "978-0-52-551488-0", "The Immortalists" },
                    { new Guid("a2d303e5-b091-4175-b3ad-f18c4150c2ca"), new Guid("e63cca5a-111f-47e1-b5d5-8a88f2bf5006"), "George Orwell's dystopian masterpiece, depicting a nightmarish future under totalitarian rule.", "978-0-45-152493-5", "1984" },
                    { new Guid("a6a480b0-8310-4a49-a0b1-54e6112be513"), new Guid("6513ce88-800e-4129-a47e-7f856328a9b0"), "M. Scott Peck's exploration of personal growth, love, and spiritual development.", "978-0-74-324315-8", "The Road Less Traveled" },
                    { new Guid("a8faca57-ed76-4b08-8a15-4bdae8f670ef"), new Guid("86b99160-6f76-4e96-bb17-0ee3a4c21aa6"), "Stephen King's chilling tale of supernatural horror, isolation, and the descent into madness at the haunted Overlook Hotel.", "978-0-38-511683-7", "The Shining" },
                    { new Guid("ae908b3b-0fc1-4c2d-a4ed-2d7c6b668f8d"), new Guid("93774efc-253a-4c9a-b10c-1652ef14c3a0"), "F. Scott Fitzgerald's classic portrayal of the American Dream, excess, and disillusionment in the Roaring Twenties.", "978-0-74-327356-5", "The Great Gatsby" },
                    { new Guid("c26c1e57-5c39-4ca9-959a-27cc92739f50"), new Guid("133dd1b0-9251-4ff3-8e60-35a0d005ceb4"), "A timeless tale of love, manners, and societal expectations in Regency-era England by Jane Austen.", "978-0-14-143951-8", "Pride and Prejudice" },
                    { new Guid("c6485cdb-8640-4275-9747-e83145207bfe"), new Guid("b7633d0c-a97d-4564-99db-f30b216eedc6"), null, "978-0-15-602835-6", "The Color Purple" },
                    { new Guid("c800f15d-902f-4926-9573-18b6f9bdba71"), new Guid("133dd1b0-9251-4ff3-8e60-35a0d005ceb4"), "Fyodor Dostoevsky's exploration of morality, faith, and family dynamics through the complex relationships of the Karamazov brothers.", "978-0-14-044924-2", "The Brothers Karamazov" },
                    { new Guid("cc291c88-39c4-40c3-a1e4-e01105b4b969"), new Guid("86b99160-6f76-4e96-bb17-0ee3a4c21aa6"), "Kathryn Stockett's novel about African American maids working in white households in Jackson, Mississippi, during the early 1960s.", "978-0-42-523220-0", "The Help" },
                    { new Guid("d24c539b-79b8-4ca2-9420-ad513f3e1d86"), new Guid("6dd310ce-a007-48b3-bf40-e4380897e200"), "Geoffrey Chaucer's collection of stories told by a diverse group of pilgrims on their journey to Canterbury.", "978-0-14-042234-4", "The Canterbury Tales" },
                    { new Guid("d38cff8b-03e3-4881-b59d-7466533e12f7"), new Guid("9d43d676-5e95-4861-be75-b2bba76af8b5"), "Paula Hawkins's psychological thriller about a woman who becomes entangled in a missing person investigation.", "978-1-59-463402-4", "The Girl on the Train" },
                    { new Guid("dabceca5-300f-4591-a738-1122163c83ce"), new Guid("74de59d0-fb8e-485b-958c-5861bf9d1130"), "John Steinbeck's novel depicting the struggles of a displaced Oklahoma family during the Great Depression.", "978-0-14-303943-3", "The Grapes of Wrath" },
                    { new Guid("de1bac85-8b79-4b8a-b135-9ca754fcbc41"), new Guid("6513ce88-800e-4129-a47e-7f856328a9b0"), "J.R.R. Tolkien's epic fantasy trilogy, featuring the quest to destroy the One Ring and save Middle-earth from the dark forces of Sauron.", "978-0-54-400341-5", "The Lord of the Rings" },
                    { new Guid("e2c46869-9860-4e06-8841-b6bc9edd0da4"), new Guid("21170579-8f47-48c8-a41a-266124770b5a"), "Stieg Larsson's gripping mystery featuring investigative journalist Mikael Blomkvist and the enigmatic hacker Lisbeth Salander.", "978-0-30-726975-1", "The Girl with the Dragon Tattoo" },
                    { new Guid("eced989d-bcdf-48f9-ada4-28396d97f8c4"), new Guid("8f3b7a7a-99c0-4743-87a0-20be60f48b8b"), "Dan Brown's gripping mystery involving symbology, art, and secret societies.", "978-0-30-747427-8", "The Da Vinci Code" },
                    { new Guid("edbe7b2d-3fed-455d-ba25-f7f0353be0b7"), new Guid("6dd310ce-a007-48b3-bf40-e4380897e200"), "Fyodor Dostoevsky's psychological thriller, exploring the moral and psychological turmoil of a young man in St. Petersburg.", "978-0-14-310763-7", "Crime and Punishment" },
                    { new Guid("efa09ccf-2570-4c39-b119-0bcde2c48868"), new Guid("52c70c29-ff87-40a7-8cc8-46d0290cd5f3"), "Khaled Hosseini's powerful novel about friendship, betrayal, and redemption in Afghanistan.", "978-1-59-463193-1", "The Kite Runner" },
                    { new Guid("f13afc2d-c7bc-4182-8437-563ceb96ad6a"), new Guid("21170579-8f47-48c8-a41a-266124770b5a"), null, "978-0-14-143957-0", "The Picture of Dorian Gray" },
                    { new Guid("f151e3d5-a85e-42be-a355-9f84dcbdb269"), new Guid("1223f27d-e2d8-4342-b524-bccd42a5cc92"), "Cormac McCarthy's post-apocalyptic tale of a father and son's harrowing journey through a desolate landscape.", "978-0-30-738789-9", "The Road" },
                    { new Guid("f521ba4b-7098-4f59-b741-0ca27c719980"), new Guid("64b71e73-58a1-43f2-b461-036fa26f7fcb"), null, "978-0-14-044022-5", "The Three Musketeers" },
                    { new Guid("f8623d6d-1370-4cad-b556-738a82906ccd"), new Guid("e63cca5a-111f-47e1-b5d5-8a88f2bf5006"), null, "978-0-06-085052-4", "Brave New World" },
                    { new Guid("faa58f73-9d27-49cf-bac2-a60630ea2ce4"), new Guid("079540e9-5013-4fda-a6bb-a217c1d2f243"), null, "978-0-54-792822-7", "The Hobbit" },
                    { new Guid("fe3d3a04-8afc-4728-8b6c-eacc833aaa6a"), new Guid("74de59d0-fb8e-485b-958c-5861bf9d1130"), "Amy Tan's novel exploring the relationships between Chinese-American immigrant mothers and their American-born daughters.", "978-0-80-417839-9", "The Joy Luck Club" }
                });

            migrationBuilder.InsertData(
                table: "BooksGenres",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { new Guid("01908b56-06dc-43b3-b828-9d2f6d7cc0c2"), new Guid("39726e1a-7a3c-4822-8afc-9a8cc7dd445e") },
                    { new Guid("0b0b9f27-802f-4e85-8bbd-c70b48641123"), new Guid("39726e1a-7a3c-4822-8afc-9a8cc7dd445e") },
                    { new Guid("300be501-adfe-4eda-9fe6-03ecf9ebbec0"), new Guid("39726e1a-7a3c-4822-8afc-9a8cc7dd445e") },
                    { new Guid("3503bdf4-978d-421a-a488-9f2a049f6b4c"), new Guid("39726e1a-7a3c-4822-8afc-9a8cc7dd445e") },
                    { new Guid("40923629-d9e0-4db5-8128-f2ec66a5b12a"), new Guid("39726e1a-7a3c-4822-8afc-9a8cc7dd445e") },
                    { new Guid("4d04d1fd-19fa-42aa-a513-5415e8340f83"), new Guid("39726e1a-7a3c-4822-8afc-9a8cc7dd445e") },
                    { new Guid("67e2ad32-674b-48c8-9f6a-96b239faf9b6"), new Guid("39726e1a-7a3c-4822-8afc-9a8cc7dd445e") },
                    { new Guid("8f85d6c1-a18c-4687-ae7a-1d2e4d39bac5"), new Guid("39726e1a-7a3c-4822-8afc-9a8cc7dd445e") },
                    { new Guid("cc291c88-39c4-40c3-a1e4-e01105b4b969"), new Guid("39726e1a-7a3c-4822-8afc-9a8cc7dd445e") },
                    { new Guid("f8623d6d-1370-4cad-b556-738a82906ccd"), new Guid("39726e1a-7a3c-4822-8afc-9a8cc7dd445e") },
                    { new Guid("0b0b9f27-802f-4e85-8bbd-c70b48641123"), new Guid("5a72e833-d1ce-45f0-aa66-55a5a6ddeed3") },
                    { new Guid("40923629-d9e0-4db5-8128-f2ec66a5b12a"), new Guid("5a72e833-d1ce-45f0-aa66-55a5a6ddeed3") },
                    { new Guid("633a6c2f-e200-405b-a42b-37c06aebb35b"), new Guid("5a72e833-d1ce-45f0-aa66-55a5a6ddeed3") },
                    { new Guid("64977bb3-d94c-4a18-a021-0262696a153d"), new Guid("5a72e833-d1ce-45f0-aa66-55a5a6ddeed3") },
                    { new Guid("7c217837-2cd7-47d1-88c7-676f2332b52f"), new Guid("5a72e833-d1ce-45f0-aa66-55a5a6ddeed3") },
                    { new Guid("8f85d6c1-a18c-4687-ae7a-1d2e4d39bac5"), new Guid("5a72e833-d1ce-45f0-aa66-55a5a6ddeed3") },
                    { new Guid("edbe7b2d-3fed-455d-ba25-f7f0353be0b7"), new Guid("5a72e833-d1ce-45f0-aa66-55a5a6ddeed3") },
                    { new Guid("f151e3d5-a85e-42be-a355-9f84dcbdb269"), new Guid("5a72e833-d1ce-45f0-aa66-55a5a6ddeed3") },
                    { new Guid("fe3d3a04-8afc-4728-8b6c-eacc833aaa6a"), new Guid("5a72e833-d1ce-45f0-aa66-55a5a6ddeed3") },
                    { new Guid("27dfba61-d9d0-4c93-bac1-a12a6a8c717f"), new Guid("63bdc34b-5143-4dea-8d34-38dbafc72c63") },
                    { new Guid("28569081-d422-4b71-9f9c-4cc22f7bec7d"), new Guid("63bdc34b-5143-4dea-8d34-38dbafc72c63") },
                    { new Guid("34ca9f52-d97e-4c5b-826d-17cf14db7a8b"), new Guid("63bdc34b-5143-4dea-8d34-38dbafc72c63") },
                    { new Guid("861c2273-d46f-40cd-be54-ba71f0d01958"), new Guid("63bdc34b-5143-4dea-8d34-38dbafc72c63") },
                    { new Guid("c6485cdb-8640-4275-9747-e83145207bfe"), new Guid("63bdc34b-5143-4dea-8d34-38dbafc72c63") },
                    { new Guid("f151e3d5-a85e-42be-a355-9f84dcbdb269"), new Guid("63bdc34b-5143-4dea-8d34-38dbafc72c63") },
                    { new Guid("31ba1edf-a578-40b3-81fd-ac291495017c"), new Guid("674eaa8f-3760-4b07-ae22-f24b15d4d45f") },
                    { new Guid("3435e764-2930-470e-8826-5b5fd3b098f3"), new Guid("674eaa8f-3760-4b07-ae22-f24b15d4d45f") },
                    { new Guid("618131df-0838-4027-b04a-2581d5b2fda4"), new Guid("674eaa8f-3760-4b07-ae22-f24b15d4d45f") },
                    { new Guid("6b3bf8bc-e501-4d71-91ff-b28492210da4"), new Guid("674eaa8f-3760-4b07-ae22-f24b15d4d45f") },
                    { new Guid("7a6ee1a3-49f1-4717-9149-e8e3ebb938b3"), new Guid("674eaa8f-3760-4b07-ae22-f24b15d4d45f") },
                    { new Guid("85b4a2f5-e9f1-4d9f-9487-244107f5734a"), new Guid("674eaa8f-3760-4b07-ae22-f24b15d4d45f") },
                    { new Guid("c800f15d-902f-4926-9573-18b6f9bdba71"), new Guid("674eaa8f-3760-4b07-ae22-f24b15d4d45f") },
                    { new Guid("efa09ccf-2570-4c39-b119-0bcde2c48868"), new Guid("674eaa8f-3760-4b07-ae22-f24b15d4d45f") },
                    { new Guid("27dfba61-d9d0-4c93-bac1-a12a6a8c717f"), new Guid("6b803fcf-f4fa-4f62-9acc-851cc4745512") },
                    { new Guid("861c2273-d46f-40cd-be54-ba71f0d01958"), new Guid("6b803fcf-f4fa-4f62-9acc-851cc4745512") },
                    { new Guid("e2c46869-9860-4e06-8841-b6bc9edd0da4"), new Guid("6b803fcf-f4fa-4f62-9acc-851cc4745512") },
                    { new Guid("edbe7b2d-3fed-455d-ba25-f7f0353be0b7"), new Guid("6b803fcf-f4fa-4f62-9acc-851cc4745512") },
                    { new Guid("3503bdf4-978d-421a-a488-9f2a049f6b4c"), new Guid("8f220de1-b593-4bf2-9bf1-33c213491d79") },
                    { new Guid("4555dcdf-4f39-4eba-b192-69cb694cd4e1"), new Guid("8f220de1-b593-4bf2-9bf1-33c213491d79") },
                    { new Guid("49d6f6d0-10e1-4997-b023-0b2f7d15d43f"), new Guid("8f220de1-b593-4bf2-9bf1-33c213491d79") },
                    { new Guid("633a6c2f-e200-405b-a42b-37c06aebb35b"), new Guid("8f220de1-b593-4bf2-9bf1-33c213491d79") },
                    { new Guid("8f85d6c1-a18c-4687-ae7a-1d2e4d39bac5"), new Guid("8f220de1-b593-4bf2-9bf1-33c213491d79") },
                    { new Guid("c800f15d-902f-4926-9573-18b6f9bdba71"), new Guid("8f220de1-b593-4bf2-9bf1-33c213491d79") },
                    { new Guid("e2c46869-9860-4e06-8841-b6bc9edd0da4"), new Guid("8f220de1-b593-4bf2-9bf1-33c213491d79") },
                    { new Guid("edbe7b2d-3fed-455d-ba25-f7f0353be0b7"), new Guid("8f220de1-b593-4bf2-9bf1-33c213491d79") },
                    { new Guid("f8623d6d-1370-4cad-b556-738a82906ccd"), new Guid("8f220de1-b593-4bf2-9bf1-33c213491d79") },
                    { new Guid("37dc49d3-76bc-4b9e-8598-360181f66196"), new Guid("a1278d68-f099-4d99-92cf-21504b4af305") },
                    { new Guid("49d6f6d0-10e1-4997-b023-0b2f7d15d43f"), new Guid("a1278d68-f099-4d99-92cf-21504b4af305") },
                    { new Guid("7a6ee1a3-49f1-4717-9149-e8e3ebb938b3"), new Guid("a1278d68-f099-4d99-92cf-21504b4af305") },
                    { new Guid("861c2273-d46f-40cd-be54-ba71f0d01958"), new Guid("a1278d68-f099-4d99-92cf-21504b4af305") },
                    { new Guid("ae908b3b-0fc1-4c2d-a4ed-2d7c6b668f8d"), new Guid("a1278d68-f099-4d99-92cf-21504b4af305") },
                    { new Guid("c26c1e57-5c39-4ca9-959a-27cc92739f50"), new Guid("a1278d68-f099-4d99-92cf-21504b4af305") },
                    { new Guid("dabceca5-300f-4591-a738-1122163c83ce"), new Guid("a1278d68-f099-4d99-92cf-21504b4af305") },
                    { new Guid("eced989d-bcdf-48f9-ada4-28396d97f8c4"), new Guid("a1278d68-f099-4d99-92cf-21504b4af305") },
                    { new Guid("4555dcdf-4f39-4eba-b192-69cb694cd4e1"), new Guid("a4945a91-3cb1-418b-ba8e-2f4435349fa3") },
                    { new Guid("5c334b61-e2a6-4eb4-a8c7-8a04416ad80a"), new Guid("a4945a91-3cb1-418b-ba8e-2f4435349fa3") },
                    { new Guid("6fcda34e-0083-46e1-bd7d-61d668ca1f87"), new Guid("a4945a91-3cb1-418b-ba8e-2f4435349fa3") },
                    { new Guid("8ba41b69-5de2-4759-be90-e86834abe8f9"), new Guid("a4945a91-3cb1-418b-ba8e-2f4435349fa3") },
                    { new Guid("dabceca5-300f-4591-a738-1122163c83ce"), new Guid("a4945a91-3cb1-418b-ba8e-2f4435349fa3") },
                    { new Guid("f13afc2d-c7bc-4182-8437-563ceb96ad6a"), new Guid("a4945a91-3cb1-418b-ba8e-2f4435349fa3") },
                    { new Guid("f521ba4b-7098-4f59-b741-0ca27c719980"), new Guid("a4945a91-3cb1-418b-ba8e-2f4435349fa3") },
                    { new Guid("0b0b9f27-802f-4e85-8bbd-c70b48641123"), new Guid("c1d58ffa-0f1d-442b-9248-41d31431e8f2") },
                    { new Guid("181f69bd-3756-4bc7-a43a-4b5c41461cd9"), new Guid("c1d58ffa-0f1d-442b-9248-41d31431e8f2") },
                    { new Guid("34ca9f52-d97e-4c5b-826d-17cf14db7a8b"), new Guid("c1d58ffa-0f1d-442b-9248-41d31431e8f2") },
                    { new Guid("5c334b61-e2a6-4eb4-a8c7-8a04416ad80a"), new Guid("c1d58ffa-0f1d-442b-9248-41d31431e8f2") },
                    { new Guid("633a6c2f-e200-405b-a42b-37c06aebb35b"), new Guid("c1d58ffa-0f1d-442b-9248-41d31431e8f2") },
                    { new Guid("7c217837-2cd7-47d1-88c7-676f2332b52f"), new Guid("c1d58ffa-0f1d-442b-9248-41d31431e8f2") },
                    { new Guid("f151e3d5-a85e-42be-a355-9f84dcbdb269"), new Guid("c1d58ffa-0f1d-442b-9248-41d31431e8f2") },
                    { new Guid("faa58f73-9d27-49cf-bac2-a60630ea2ce4"), new Guid("c1d58ffa-0f1d-442b-9248-41d31431e8f2") },
                    { new Guid("20939ac3-5e65-4c08-b438-0a2dc2fa3a1a"), new Guid("c3a86636-203c-4475-8cea-567646ad2a32") },
                    { new Guid("28569081-d422-4b71-9f9c-4cc22f7bec7d"), new Guid("c3a86636-203c-4475-8cea-567646ad2a32") },
                    { new Guid("5c334b61-e2a6-4eb4-a8c7-8a04416ad80a"), new Guid("c3a86636-203c-4475-8cea-567646ad2a32") },
                    { new Guid("a8faca57-ed76-4b08-8a15-4bdae8f670ef"), new Guid("c3a86636-203c-4475-8cea-567646ad2a32") },
                    { new Guid("4d04d1fd-19fa-42aa-a513-5415e8340f83"), new Guid("c5b2c854-275d-477d-8c37-ac3c4b1fa535") },
                    { new Guid("67e2ad32-674b-48c8-9f6a-96b239faf9b6"), new Guid("c5b2c854-275d-477d-8c37-ac3c4b1fa535") },
                    { new Guid("6b3bf8bc-e501-4d71-91ff-b28492210da4"), new Guid("c5b2c854-275d-477d-8c37-ac3c4b1fa535") },
                    { new Guid("85b4a2f5-e9f1-4d9f-9487-244107f5734a"), new Guid("c5b2c854-275d-477d-8c37-ac3c4b1fa535") },
                    { new Guid("861c2273-d46f-40cd-be54-ba71f0d01958"), new Guid("c5b2c854-275d-477d-8c37-ac3c4b1fa535") },
                    { new Guid("a17210e7-9845-479e-8d85-658acab39541"), new Guid("c5b2c854-275d-477d-8c37-ac3c4b1fa535") },
                    { new Guid("ae908b3b-0fc1-4c2d-a4ed-2d7c6b668f8d"), new Guid("c5b2c854-275d-477d-8c37-ac3c4b1fa535") },
                    { new Guid("de1bac85-8b79-4b8a-b135-9ca754fcbc41"), new Guid("c5b2c854-275d-477d-8c37-ac3c4b1fa535") },
                    { new Guid("01908b56-06dc-43b3-b828-9d2f6d7cc0c2"), new Guid("c65881aa-ec34-4bdd-85b9-58f4c4c3c795") },
                    { new Guid("27dfba61-d9d0-4c93-bac1-a12a6a8c717f"), new Guid("c65881aa-ec34-4bdd-85b9-58f4c4c3c795") },
                    { new Guid("31ba1edf-a578-40b3-81fd-ac291495017c"), new Guid("c65881aa-ec34-4bdd-85b9-58f4c4c3c795") },
                    { new Guid("37dc49d3-76bc-4b9e-8598-360181f66196"), new Guid("c65881aa-ec34-4bdd-85b9-58f4c4c3c795") },
                    { new Guid("5304db79-d521-4115-80da-fcb1f68e2b42"), new Guid("c65881aa-ec34-4bdd-85b9-58f4c4c3c795") },
                    { new Guid("85b4a2f5-e9f1-4d9f-9487-244107f5734a"), new Guid("c65881aa-ec34-4bdd-85b9-58f4c4c3c795") },
                    { new Guid("a2d303e5-b091-4175-b3ad-f18c4150c2ca"), new Guid("c65881aa-ec34-4bdd-85b9-58f4c4c3c795") },
                    { new Guid("cc291c88-39c4-40c3-a1e4-e01105b4b969"), new Guid("c65881aa-ec34-4bdd-85b9-58f4c4c3c795") },
                    { new Guid("e2c46869-9860-4e06-8841-b6bc9edd0da4"), new Guid("c65881aa-ec34-4bdd-85b9-58f4c4c3c795") },
                    { new Guid("eced989d-bcdf-48f9-ada4-28396d97f8c4"), new Guid("c65881aa-ec34-4bdd-85b9-58f4c4c3c795") },
                    { new Guid("34ca9f52-d97e-4c5b-826d-17cf14db7a8b"), new Guid("cd0e257b-92f1-46e4-a452-79ce1626c88e") },
                    { new Guid("6b3bf8bc-e501-4d71-91ff-b28492210da4"), new Guid("cd0e257b-92f1-46e4-a452-79ce1626c88e") },
                    { new Guid("a2d303e5-b091-4175-b3ad-f18c4150c2ca"), new Guid("cd0e257b-92f1-46e4-a452-79ce1626c88e") },
                    { new Guid("f8623d6d-1370-4cad-b556-738a82906ccd"), new Guid("cd0e257b-92f1-46e4-a452-79ce1626c88e") },
                    { new Guid("01908b56-06dc-43b3-b828-9d2f6d7cc0c2"), new Guid("d4c07071-05b6-4846-b84f-decc69ddb08c") },
                    { new Guid("31ba1edf-a578-40b3-81fd-ac291495017c"), new Guid("d4c07071-05b6-4846-b84f-decc69ddb08c") },
                    { new Guid("34ca9f52-d97e-4c5b-826d-17cf14db7a8b"), new Guid("d4c07071-05b6-4846-b84f-decc69ddb08c") },
                    { new Guid("3ffa4aec-59c1-4ff4-acd5-1e7ddd1478d9"), new Guid("d4c07071-05b6-4846-b84f-decc69ddb08c") },
                    { new Guid("64977bb3-d94c-4a18-a021-0262696a153d"), new Guid("d4c07071-05b6-4846-b84f-decc69ddb08c") },
                    { new Guid("c6485cdb-8640-4275-9747-e83145207bfe"), new Guid("d4c07071-05b6-4846-b84f-decc69ddb08c") },
                    { new Guid("cc291c88-39c4-40c3-a1e4-e01105b4b969"), new Guid("d4c07071-05b6-4846-b84f-decc69ddb08c") },
                    { new Guid("faa58f73-9d27-49cf-bac2-a60630ea2ce4"), new Guid("d4c07071-05b6-4846-b84f-decc69ddb08c") },
                    { new Guid("0b0b9f27-802f-4e85-8bbd-c70b48641123"), new Guid("dca4afa1-cd3d-46f7-bd6f-9ee3476c4589") },
                    { new Guid("31ba1edf-a578-40b3-81fd-ac291495017c"), new Guid("dca4afa1-cd3d-46f7-bd6f-9ee3476c4589") },
                    { new Guid("40923629-d9e0-4db5-8128-f2ec66a5b12a"), new Guid("dca4afa1-cd3d-46f7-bd6f-9ee3476c4589") },
                    { new Guid("64977bb3-d94c-4a18-a021-0262696a153d"), new Guid("dca4afa1-cd3d-46f7-bd6f-9ee3476c4589") },
                    { new Guid("d38cff8b-03e3-4881-b59d-7466533e12f7"), new Guid("dca4afa1-cd3d-46f7-bd6f-9ee3476c4589") },
                    { new Guid("f13afc2d-c7bc-4182-8437-563ceb96ad6a"), new Guid("dca4afa1-cd3d-46f7-bd6f-9ee3476c4589") },
                    { new Guid("181f69bd-3756-4bc7-a43a-4b5c41461cd9"), new Guid("dfa917b1-fe4b-4c1e-9058-da239f55c7f0") },
                    { new Guid("4bfff86c-aca1-48a1-8968-65bcc6b5f334"), new Guid("dfa917b1-fe4b-4c1e-9058-da239f55c7f0") },
                    { new Guid("5304db79-d521-4115-80da-fcb1f68e2b42"), new Guid("dfa917b1-fe4b-4c1e-9058-da239f55c7f0") },
                    { new Guid("de1bac85-8b79-4b8a-b135-9ca754fcbc41"), new Guid("dfa917b1-fe4b-4c1e-9058-da239f55c7f0") },
                    { new Guid("f521ba4b-7098-4f59-b741-0ca27c719980"), new Guid("dfa917b1-fe4b-4c1e-9058-da239f55c7f0") },
                    { new Guid("181f69bd-3756-4bc7-a43a-4b5c41461cd9"), new Guid("fa635920-0c61-49be-ace0-3a5b4aa13b0a") },
                    { new Guid("20939ac3-5e65-4c08-b438-0a2dc2fa3a1a"), new Guid("fa635920-0c61-49be-ace0-3a5b4aa13b0a") },
                    { new Guid("40923629-d9e0-4db5-8128-f2ec66a5b12a"), new Guid("fa635920-0c61-49be-ace0-3a5b4aa13b0a") },
                    { new Guid("4459c13c-f848-4aa4-ae42-f299e9d612fe"), new Guid("fa635920-0c61-49be-ace0-3a5b4aa13b0a") },
                    { new Guid("6fcda34e-0083-46e1-bd7d-61d668ca1f87"), new Guid("fa635920-0c61-49be-ace0-3a5b4aa13b0a") },
                    { new Guid("a2d303e5-b091-4175-b3ad-f18c4150c2ca"), new Guid("fa635920-0c61-49be-ace0-3a5b4aa13b0a") },
                    { new Guid("a6a480b0-8310-4a49-a0b1-54e6112be513"), new Guid("fa635920-0c61-49be-ace0-3a5b4aa13b0a") },
                    { new Guid("d24c539b-79b8-4ca2-9420-ad513f3e1d86"), new Guid("fa635920-0c61-49be-ace0-3a5b4aa13b0a") },
                    { new Guid("de1bac85-8b79-4b8a-b135-9ca754fcbc41"), new Guid("fa635920-0c61-49be-ace0-3a5b4aa13b0a") },
                    { new Guid("efa09ccf-2570-4c39-b119-0bcde2c48868"), new Guid("fa635920-0c61-49be-ace0-3a5b4aa13b0a") },
                    { new Guid("f521ba4b-7098-4f59-b741-0ca27c719980"), new Guid("fa635920-0c61-49be-ace0-3a5b4aa13b0a") }
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
                name: "IX_User_Email",
                table: "User",
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
                name: "User");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
