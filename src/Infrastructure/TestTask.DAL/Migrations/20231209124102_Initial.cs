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
                    BooksHiredDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
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
                    { new Guid("1120c5e6-08a2-4e82-b017-2c17aa43b668"), "Emily Brontë" },
                    { new Guid("1454cff4-5a42-46df-be28-c289c894ccc9"), "Leo Tolstoy" },
                    { new Guid("1775be65-906c-4eab-b751-19c85540bbc3"), "Gabriel García Márquez" },
                    { new Guid("1ade89d9-0631-48e9-9d70-d133f1b7d79b"), "Agatha Christie" },
                    { new Guid("1e348601-8fd4-4547-a210-ae1e57672964"), "J.K. Rowling" },
                    { new Guid("2d49d98a-e474-4deb-8c86-c71dda9256e6"), "Roald Dahl" },
                    { new Guid("43e666e1-225e-4bb4-a986-108b7ce572a0"), "Jane Goodall" },
                    { new Guid("511de0d0-2bf7-4d7a-886f-3f5938110b10"), "Charles Dickens" },
                    { new Guid("515a2550-944f-4de1-95bd-06d51310f500"), "Kurt Vonnegut" },
                    { new Guid("524b78ff-4e03-4080-9a3b-4a502a692481"), "Mark Twain" },
                    { new Guid("54790d57-64f3-49e7-a178-8d3acbb9b9e9"), "Harper Lee" },
                    { new Guid("61b53cd5-2169-4463-80d4-d649c3b1b211"), "F. Scott Fitzgerald" },
                    { new Guid("62bf7166-0e78-4fbe-9b0e-13e5bfef9c97"), "Aldous Huxley" },
                    { new Guid("68bc5cbb-cf2f-4da7-8914-09606d19bb95"), "Hermann Hesse" },
                    { new Guid("6b4aee09-ed7b-467b-acaa-d89c208ad784"), "Arthur Conan Doyle" },
                    { new Guid("6fceb52a-ca01-48a6-8de2-ba6e29dcc04f"), "H.G. Wells" },
                    { new Guid("781863a5-b073-42c9-8aa7-53adde205ae9"), "William Shakespeare" },
                    { new Guid("7ff99211-8584-4225-9a7a-d9cee9358021"), "Ayn Rand" },
                    { new Guid("9e2d692a-458f-4bc4-9aa5-ff4548eea6d1"), "J.R.R. Tolkien" },
                    { new Guid("a005d333-657f-46da-928a-d2771f0a070c"), "Jane Austen" },
                    { new Guid("a3dd8dc3-0284-40fe-9b54-00ee89e8039c"), "Margaret Atwood" },
                    { new Guid("a520636c-e7d9-48d8-926c-030a2d15bfa1"), "Virginia Woolf" },
                    { new Guid("a8d1fb52-fef5-4ba1-8d38-8cc1935ef05c"), "Stephen King" },
                    { new Guid("b406abda-ff0f-492e-b859-c5b390708413"), "George Orwell" },
                    { new Guid("c607a908-b9f8-41b2-ab53-6cf647e40c8c"), "Homer" },
                    { new Guid("ca7ecadc-486e-4f7e-9962-f51bb2613607"), "Ernest Hemingway" },
                    { new Guid("e6535418-af19-458c-9d9c-c52b2484e7f5"), "Toni Morrison" },
                    { new Guid("ec2ee190-de53-4a27-92ca-cf654e17ac26"), "Michael Crichton" },
                    { new Guid("f3b275a0-fc36-42a7-b0a1-01c261ebefcd"), "Isaac Asimov" },
                    { new Guid("f88f25d8-30c7-4607-9864-487830dc4249"), "Charlotte Brontë" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("02c35fd4-04e7-4f61-b7fb-c13c9e8f6b0c"), "Cookbook" },
                    { new Guid("05acf1d1-5a9d-4b3d-ac3a-c0b5d765a1dd"), "Travel" },
                    { new Guid("0c06b8a6-da97-4cb1-a953-e367caf6fb42"), "Drama" },
                    { new Guid("14cf7b41-086e-4b21-8185-1d7056466194"), "Science" },
                    { new Guid("16ccf109-9756-467b-9ddf-68a65ea738e6"), "Adventure" },
                    { new Guid("1c65c29c-6bb8-4e9b-ae4c-a8fbca520672"), "Science Fiction" },
                    { new Guid("28ccccdc-30eb-455b-b274-05d78b237498"), "Fantasy" },
                    { new Guid("28f0ced0-29e5-4487-85ca-15c072a53f4c"), "Self-Help" },
                    { new Guid("3da4819b-e78c-479e-b95d-627a7e75fd6a"), "Poetry" },
                    { new Guid("7bd0d44e-f643-4416-af0c-87cb9e219370"), "Horror" },
                    { new Guid("8c56639b-2bc7-4857-97cf-b4ea2afc56f4"), "Non-Fiction" },
                    { new Guid("a5987acd-af9d-4102-ab3f-a4f08f68d841"), "Thriller" },
                    { new Guid("abd7f05f-1138-40a1-84c4-846411701fb4"), "Romance" },
                    { new Guid("b4fd8a39-2b59-4cbf-a14d-b2a3227ab253"), "Comedy" },
                    { new Guid("bde649fd-da82-4255-85c9-e47db4529f9e"), "Mystery" },
                    { new Guid("d2feaa6c-447c-4336-9729-2d40e6e369eb"), "Biography" },
                    { new Guid("f5c2b447-dd2f-4126-b27b-cf2c533a9d75"), "Historical Fiction" },
                    { new Guid("f91bb938-5073-4fe6-b69a-6e6821a9c10a"), "Business" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "ISBN", "Title" },
                values: new object[,]
                {
                    { new Guid("0a28fbc1-d01a-448b-8505-3649e626016a"), new Guid("ca7ecadc-486e-4f7e-9962-f51bb2613607"), "Erin Morgenstern's magical tale of a mysterious competition between two illusionists in a magical circus.", "978-0-38-553970-6", "The Night Circus" },
                    { new Guid("0f434edd-b23d-4d0d-b077-0af4e79b9724"), new Guid("f3b275a0-fc36-42a7-b0a1-01c261ebefcd"), "Yuval Noah Harari's exploration of the history and impact of Homo sapiens on the world.", "978-0-99-711060-8", "Sapiens: A Brief History of Humankind" },
                    { new Guid("1192446a-5e73-48e2-9653-5e8c3870ae4b"), new Guid("1120c5e6-08a2-4e82-b017-2c17aa43b668"), null, "978-0-15-602835-6", "The Color Purple" },
                    { new Guid("143ac5b2-a898-438f-867e-606d27340fec"), new Guid("b406abda-ff0f-492e-b859-c5b390708413"), "Paula Hawkins's psychological thriller about a woman who becomes entangled in a missing person investigation.", "978-1-59-463402-4", "The Girl on the Train" },
                    { new Guid("17c6dc20-eb7b-4e55-adf8-fd44fba5b490"), new Guid("a8d1fb52-fef5-4ba1-8d38-8cc1935ef05c"), null, "978-0-19-921613-3", "Alice's Adventures in Wonderland" },
                    { new Guid("188ecd2e-d396-49f6-96fc-c230f1c4c5fd"), new Guid("6b4aee09-ed7b-467b-acaa-d89c208ad784"), "Harper Lee's powerful exploration of racial injustice and moral growth in the American South.", "978-0-06-112348-4", "To Kill a Mockingbird" },
                    { new Guid("1ba392ba-2216-4498-8f0f-104cff8db456"), new Guid("54790d57-64f3-49e7-a178-8d3acbb9b9e9"), "Herman Melville's epic journey aboard the whaling ship Pequod, driven by Captain Ahab's obsessive quest for the white whale.", "978-0-14-310635-7", "Moby-Dick" },
                    { new Guid("1e65fa55-2c19-4c82-a432-516534c99bc0"), new Guid("781863a5-b073-42c9-8aa7-53adde205ae9"), "Margaret Atwood's dystopian novel set in the Republic of Gilead, where women's rights are severely restricted.", "978-0-38-549081-8", "The Handmaid's Tale" },
                    { new Guid("29abc730-e713-4ca9-a767-e42a2acdfb89"), new Guid("a520636c-e7d9-48d8-926c-030a2d15bfa1"), "Andy Weir's gripping science fiction novel about an astronaut stranded on Mars and his fight for survival.", "978-0-55-341802-6", "The Martian" },
                    { new Guid("2b450ea6-63fa-4035-8be0-a33a6ee1d49d"), new Guid("781863a5-b073-42c9-8aa7-53adde205ae9"), "Haruki Murakami's surreal and mesmerizing novel exploring the mysteries of human consciousness.", "978-0-67-977543-0", "The Wind-Up Bird Chronicle" },
                    { new Guid("32458b4b-f7a0-4c9b-be20-6aa8e63fcf45"), new Guid("a3dd8dc3-0284-40fe-9b54-00ee89e8039c"), "M. Scott Peck's exploration of personal growth, love, and spiritual development.", "978-0-74-324315-8", "The Road Less Traveled" },
                    { new Guid("35d857b4-8190-4adf-9708-58e1d6a895ff"), new Guid("f88f25d8-30c7-4607-9864-487830dc4249"), "Ken Kesey's classic novel set in a mental hospital, challenging authority and celebrating individuality.", "978-0-45-116396-7", "One Flew Over the Cuckoo's Nest" },
                    { new Guid("38872df0-e129-4259-a3f4-4ee53ddb250d"), new Guid("1454cff4-5a42-46df-be28-c289c894ccc9"), "Khaled Hosseini's powerful novel about friendship, betrayal, and redemption in Afghanistan.", "978-1-59-463193-1", "The Kite Runner" },
                    { new Guid("450394fc-a9a3-42b5-90e4-d24207819c27"), new Guid("a005d333-657f-46da-928a-d2771f0a070c"), "Alexandre Dumas's classic adventure novel of betrayal, revenge, and redemption.", "978-0-14-044926-6", "The Count of Monte Cristo" },
                    { new Guid("474575eb-d7cf-4069-a41c-e1c306342674"), new Guid("6b4aee09-ed7b-467b-acaa-d89c208ad784"), "J.K. Rowling's enchanting introduction to the wizarding world, filled with magic, friendship, and adventure.", "978-0-59-035342-7", "Harry Potter and the Sorcerer's Stone" },
                    { new Guid("487de90a-b378-471e-9e5d-d2207b4891d2"), new Guid("6fceb52a-ca01-48a6-8de2-ba6e29dcc04f"), "Stieg Larsson's gripping mystery featuring investigative journalist Mikael Blomkvist and the enigmatic hacker Lisbeth Salander.", "978-0-30-726975-1", "The Girl with the Dragon Tattoo" },
                    { new Guid("4a019e46-f0c3-4ce8-ad11-d5f511cfcaad"), new Guid("a8d1fb52-fef5-4ba1-8d38-8cc1935ef05c"), "Paulo Coelho's philosophical novel about Santiago, a shepherd boy, on a journey to discover his personal legend.", "978-0-06-112241-5", "The Alchemist" },
                    { new Guid("4e7bcb3f-0fa7-45df-85e9-89aefa8e254f"), new Guid("c607a908-b9f8-41b2-ab53-6cf647e40c8c"), "C.S. Lewis's beloved fantasy series, taking readers to the enchanting land of Narnia and its magical inhabitants.", "978-0-06-112008-4", "The Chronicles of Narnia" },
                    { new Guid("557c9e56-9dd7-42ed-b544-00d01bdf2482"), new Guid("515a2550-944f-4de1-95bd-06d51310f500"), "Jeannette Walls's memoir detailing her unconventional and often troubled childhood.", "978-0-74-324754-5", "The Glass Castle" },
                    { new Guid("5a7447dd-e69c-4854-b954-d9a7e7a1ea7f"), new Guid("54790d57-64f3-49e7-a178-8d3acbb9b9e9"), "Joseph Heller's satirical novel depicting the absurdities and paradoxes of war.", "978-0-68-484121-9", "The Catch-22" },
                    { new Guid("60549876-68fe-41ee-8cf3-bcaad740c83f"), new Guid("781863a5-b073-42c9-8aa7-53adde205ae9"), null, "978-0-14-200174-5", "The Secret Life of Bees" },
                    { new Guid("63d58133-904d-4b56-bbfa-d9287bb2db42"), new Guid("9e2d692a-458f-4bc4-9aa5-ff4548eea6d1"), null, "978-0-52-551488-0", "The Immortalists" },
                    { new Guid("6912e78e-fe60-4284-bba3-1c6fab5da7b8"), new Guid("2d49d98a-e474-4deb-8c86-c71dda9256e6"), "Donna Tartt's Pulitzer Prize-winning novel about a young boy's life after a terrorist attack in a New York art museum.", "978-0-31-605543-7", "The Goldfinch" },
                    { new Guid("69f1b9de-0730-442c-b100-e0a138019568"), new Guid("511de0d0-2bf7-4d7a-886f-3f5938110b10"), "Fyodor Dostoevsky's psychological thriller, exploring the moral and psychological turmoil of a young man in St. Petersburg.", "978-0-14-310763-7", "Crime and Punishment" },
                    { new Guid("6ebb3f04-c5b7-4081-abb0-283c7255f8ee"), new Guid("7ff99211-8584-4225-9a7a-d9cee9358021"), "J.D. Salinger's iconic coming-of-age novel, capturing the angst and rebellion of a teenage boy in post-World War II America.", "978-0-31-676948-0", "The Catcher in the Rye" },
                    { new Guid("6ee634eb-3d33-44d1-a989-d9773e9a3946"), new Guid("b406abda-ff0f-492e-b859-c5b390708413"), null, "978-0-14-143955-6", "Wuthering Heights" },
                    { new Guid("7259f14d-1878-4de5-a5d9-8e4b2ab4e01a"), new Guid("54790d57-64f3-49e7-a178-8d3acbb9b9e9"), "Dan Brown's gripping mystery involving symbology, art, and secret societies.", "978-0-30-747427-8", "The Da Vinci Code" },
                    { new Guid("763f49f3-3cde-4a1a-b995-55ca3f31b51e"), new Guid("54790d57-64f3-49e7-a178-8d3acbb9b9e9"), "Kathryn Stockett's novel about African American maids working in white households in Jackson, Mississippi, during the early 1960s.", "978-0-42-523220-0", "The Help" },
                    { new Guid("94ccfb6f-eea8-4355-a810-dc2057d0cb46"), new Guid("515a2550-944f-4de1-95bd-06d51310f500"), "Amy Tan's novel exploring the relationships between Chinese-American immigrant mothers and their American-born daughters.", "978-0-80-417839-9", "The Joy Luck Club" },
                    { new Guid("9a3284b5-de86-4ad9-ae4c-d3609f9577e7"), new Guid("1e348601-8fd4-4547-a210-ae1e57672964"), null, "978-0-06-085052-4", "Brave New World" },
                    { new Guid("9c2c8bc9-d8b0-48e6-accf-f8caec7cf7f0"), new Guid("62bf7166-0e78-4fbe-9b0e-13e5bfef9c97"), null, "978-0-37-584220-7", "The Book Thief" },
                    { new Guid("a2148227-e552-419d-95df-e73909854426"), new Guid("1e348601-8fd4-4547-a210-ae1e57672964"), "A timeless tale of love, manners, and societal expectations in Regency-era England by Jane Austen.", "978-0-14-143951-8", "Pride and Prejudice" },
                    { new Guid("ae7f256b-bc62-4e75-bdf4-808da41f1004"), new Guid("c607a908-b9f8-41b2-ab53-6cf647e40c8c"), "John Green's heart-wrenching novel about two teenagers with cancer who fall in love.", "978-0-14-242417-9", "The Fault in Our Stars" },
                    { new Guid("b1004e2e-3074-45f3-b440-db36596895fd"), new Guid("a520636c-e7d9-48d8-926c-030a2d15bfa1"), "Suzanne Collins's dystopian saga of Katniss Everdeen's fight for survival in the annual Hunger Games.", "978-0-43-902352-8", "The Hunger Games" },
                    { new Guid("b1993f42-dafe-46ca-8c4e-4161c2c4b2bb"), new Guid("6fceb52a-ca01-48a6-8de2-ba6e29dcc04f"), "Frank Herbert's science fiction epic set in a distant future where noble houses vie for control of the desert planet Arrakis and its valuable spice melange.", "978-0-44-117271-9", "Dune" },
                    { new Guid("b474882b-c9b9-4d5a-a1da-ad0c06ba1bb3"), new Guid("1775be65-906c-4eab-b751-19c85540bbc3"), "J.R.R. Tolkien's epic fantasy trilogy, featuring the quest to destroy the One Ring and save Middle-earth from the dark forces of Sauron.", "978-0-54-400341-5", "The Lord of the Rings" },
                    { new Guid("b57a4007-ab4f-4256-a54a-14b9ade0b7cc"), new Guid("43e666e1-225e-4bb4-a986-108b7ce572a0"), null, "978-0-45-141943-9", "Les Misérables" },
                    { new Guid("b924f0cb-70b3-4e03-b6c3-91724434dc58"), new Guid("9e2d692a-458f-4bc4-9aa5-ff4548eea6d1"), "Rebecca Skloot's biography exploring the life and legacy of Henrietta Lacks, whose cells were used for medical research without her knowledge.", "978-1-40-005217-2", "The Immortal Life of Henrietta Lacks" },
                    { new Guid("bf6cb36c-f093-4aa9-a7ce-889d9641d019"), new Guid("68bc5cbb-cf2f-4da7-8914-09606d19bb95"), null, "978-0-06-112028-4", "One Hundred Years of Solitude" },
                    { new Guid("c48b0ed7-dd23-4e74-9b59-d130398a8393"), new Guid("b406abda-ff0f-492e-b859-c5b390708413"), "Stephen King's chilling tale of supernatural horror, isolation, and the descent into madness at the haunted Overlook Hotel.", "978-0-38-511683-7", "The Shining" },
                    { new Guid("c8aab19b-f5fe-4701-8a33-ec06325998b9"), new Guid("61b53cd5-2169-4463-80d4-d649c3b1b211"), "Tara Westover's memoir recounting her journey from a rural Idaho childhood to gaining an education against all odds.", "978-0-52-558019-4", "Educated" },
                    { new Guid("c8b83ee1-6e18-497a-ace6-32395155c426"), new Guid("b406abda-ff0f-492e-b859-c5b390708413"), "John Steinbeck's novel depicting the struggles of a displaced Oklahoma family during the Great Depression.", "978-0-14-303943-3", "The Grapes of Wrath" },
                    { new Guid("cae639c4-1169-4d57-8ba9-12779bbe4482"), new Guid("a3dd8dc3-0284-40fe-9b54-00ee89e8039c"), null, "978-0-14-044022-5", "The Three Musketeers" },
                    { new Guid("d0116796-dc37-4ab2-8012-2e39d7a8ce30"), new Guid("a8d1fb52-fef5-4ba1-8d38-8cc1935ef05c"), "Mary Shelley's gothic tale of scientific hubris and the consequences of creating life.", "978-0-48-628211-4", "Frankenstein" },
                    { new Guid("d1b42218-f286-4f38-b99c-4df607fc6bde"), new Guid("f88f25d8-30c7-4607-9864-487830dc4249"), "Charles Duhigg's exploration of the science behind habits and how they can be transformed.", "978-0-81-298160-5", "The Power of Habit" },
                    { new Guid("d615aff5-b881-4c4c-959b-e8468bbebbf4"), new Guid("9e2d692a-458f-4bc4-9aa5-ff4548eea6d1"), "Leo Tolstoy's epic portrayal of Russian society during the Napoleonic Wars, blending history, philosophy, and human drama.", "978-0-14-303500-8", "War and Peace" },
                    { new Guid("e8878eeb-4173-4f71-ab42-e19004729544"), new Guid("ec2ee190-de53-4a27-92ca-cf654e17ac26"), "F. Scott Fitzgerald's classic portrayal of the American Dream, excess, and disillusionment in the Roaring Twenties.", "978-0-74-327356-5", "The Great Gatsby" },
                    { new Guid("e9ad84be-9c3d-4baa-84c2-825c0aaea917"), new Guid("61b53cd5-2169-4463-80d4-d649c3b1b211"), null, "978-0-54-792822-7", "The Hobbit" },
                    { new Guid("ec80c2d4-869d-433d-ac3f-4b57a134bd8c"), new Guid("6b4aee09-ed7b-467b-acaa-d89c208ad784"), "Geoffrey Chaucer's collection of stories told by a diverse group of pilgrims on their journey to Canterbury.", "978-0-14-042234-4", "The Canterbury Tales" },
                    { new Guid("ee9347bc-4e42-4704-be10-68d0de0bce83"), new Guid("a3dd8dc3-0284-40fe-9b54-00ee89e8039c"), null, "978-0-14-143957-0", "The Picture of Dorian Gray" },
                    { new Guid("efb3a2b8-c410-4793-8156-7d32de3cf541"), new Guid("7ff99211-8584-4225-9a7a-d9cee9358021"), "Fyodor Dostoevsky's exploration of morality, faith, and family dynamics through the complex relationships of the Karamazov brothers.", "978-0-14-044924-2", "The Brothers Karamazov" },
                    { new Guid("f235a275-3aef-4e7d-a250-65a10de598e2"), new Guid("a005d333-657f-46da-928a-d2771f0a070c"), null, "978-1-25-030169-7", "The Silent Patient" },
                    { new Guid("f36970ff-f088-44ab-af86-c92c0e264e21"), new Guid("7ff99211-8584-4225-9a7a-d9cee9358021"), "George Orwell's dystopian masterpiece, depicting a nightmarish future under totalitarian rule.", "978-0-45-152493-5", "1984" },
                    { new Guid("f3f638e5-6468-4600-8941-5a79868e6b29"), new Guid("43e666e1-225e-4bb4-a986-108b7ce572a0"), "Homer's ancient Greek epic, recounting the adventures of Odysseus as he journeys home from the Trojan War.", "978-0-14-303995-2", "The Odyssey" },
                    { new Guid("f900be11-7dd4-47e3-9c05-3ef8412e49fb"), new Guid("511de0d0-2bf7-4d7a-886f-3f5938110b10"), "Cormac McCarthy's post-apocalyptic tale of a father and son's harrowing journey through a desolate landscape.", "978-0-30-738789-9", "The Road" },
                    { new Guid("ff7c5a2f-03d7-4d8a-9187-374b8bc12011"), new Guid("2d49d98a-e474-4deb-8c86-c71dda9256e6"), "Douglas Adams's hilarious space adventure, following the misadventures of Arthur Dent and his extraterrestrial friend Ford Prefect.", "978-0-34-539180-3", "The Hitchhiker's Guide to the Galaxy" }
                });

            migrationBuilder.InsertData(
                table: "BooksGenres",
                columns: new[] { "BookId", "GenreId" },
                values: new object[,]
                {
                    { new Guid("ae7f256b-bc62-4e75-bdf4-808da41f1004"), new Guid("02c35fd4-04e7-4f61-b7fb-c13c9e8f6b0c") },
                    { new Guid("ec80c2d4-869d-433d-ac3f-4b57a134bd8c"), new Guid("02c35fd4-04e7-4f61-b7fb-c13c9e8f6b0c") },
                    { new Guid("0f434edd-b23d-4d0d-b077-0af4e79b9724"), new Guid("0c06b8a6-da97-4cb1-a953-e367caf6fb42") },
                    { new Guid("2b450ea6-63fa-4035-8be0-a33a6ee1d49d"), new Guid("0c06b8a6-da97-4cb1-a953-e367caf6fb42") },
                    { new Guid("32458b4b-f7a0-4c9b-be20-6aa8e63fcf45"), new Guid("0c06b8a6-da97-4cb1-a953-e367caf6fb42") },
                    { new Guid("35d857b4-8190-4adf-9708-58e1d6a895ff"), new Guid("0c06b8a6-da97-4cb1-a953-e367caf6fb42") },
                    { new Guid("487de90a-b378-471e-9e5d-d2207b4891d2"), new Guid("0c06b8a6-da97-4cb1-a953-e367caf6fb42") },
                    { new Guid("e8878eeb-4173-4f71-ab42-e19004729544"), new Guid("0c06b8a6-da97-4cb1-a953-e367caf6fb42") },
                    { new Guid("efb3a2b8-c410-4793-8156-7d32de3cf541"), new Guid("0c06b8a6-da97-4cb1-a953-e367caf6fb42") },
                    { new Guid("557c9e56-9dd7-42ed-b544-00d01bdf2482"), new Guid("14cf7b41-086e-4b21-8185-1d7056466194") },
                    { new Guid("5a7447dd-e69c-4854-b954-d9a7e7a1ea7f"), new Guid("14cf7b41-086e-4b21-8185-1d7056466194") },
                    { new Guid("6ebb3f04-c5b7-4081-abb0-283c7255f8ee"), new Guid("14cf7b41-086e-4b21-8185-1d7056466194") },
                    { new Guid("d615aff5-b881-4c4c-959b-e8468bbebbf4"), new Guid("14cf7b41-086e-4b21-8185-1d7056466194") },
                    { new Guid("f235a275-3aef-4e7d-a250-65a10de598e2"), new Guid("14cf7b41-086e-4b21-8185-1d7056466194") },
                    { new Guid("1192446a-5e73-48e2-9653-5e8c3870ae4b"), new Guid("16ccf109-9756-467b-9ddf-68a65ea738e6") },
                    { new Guid("143ac5b2-a898-438f-867e-606d27340fec"), new Guid("16ccf109-9756-467b-9ddf-68a65ea738e6") },
                    { new Guid("1e65fa55-2c19-4c82-a432-516534c99bc0"), new Guid("16ccf109-9756-467b-9ddf-68a65ea738e6") },
                    { new Guid("69f1b9de-0730-442c-b100-e0a138019568"), new Guid("16ccf109-9756-467b-9ddf-68a65ea738e6") },
                    { new Guid("b474882b-c9b9-4d5a-a1da-ad0c06ba1bb3"), new Guid("16ccf109-9756-467b-9ddf-68a65ea738e6") },
                    { new Guid("c8aab19b-f5fe-4701-8a33-ec06325998b9"), new Guid("16ccf109-9756-467b-9ddf-68a65ea738e6") },
                    { new Guid("1ba392ba-2216-4498-8f0f-104cff8db456"), new Guid("1c65c29c-6bb8-4e9b-ae4c-a8fbca520672") },
                    { new Guid("9c2c8bc9-d8b0-48e6-accf-f8caec7cf7f0"), new Guid("1c65c29c-6bb8-4e9b-ae4c-a8fbca520672") },
                    { new Guid("a2148227-e552-419d-95df-e73909854426"), new Guid("1c65c29c-6bb8-4e9b-ae4c-a8fbca520672") },
                    { new Guid("bf6cb36c-f093-4aa9-a7ce-889d9641d019"), new Guid("1c65c29c-6bb8-4e9b-ae4c-a8fbca520672") },
                    { new Guid("ec80c2d4-869d-433d-ac3f-4b57a134bd8c"), new Guid("1c65c29c-6bb8-4e9b-ae4c-a8fbca520672") },
                    { new Guid("0f434edd-b23d-4d0d-b077-0af4e79b9724"), new Guid("28ccccdc-30eb-455b-b274-05d78b237498") },
                    { new Guid("143ac5b2-a898-438f-867e-606d27340fec"), new Guid("28ccccdc-30eb-455b-b274-05d78b237498") },
                    { new Guid("38872df0-e129-4259-a3f4-4ee53ddb250d"), new Guid("28ccccdc-30eb-455b-b274-05d78b237498") },
                    { new Guid("4e7bcb3f-0fa7-45df-85e9-89aefa8e254f"), new Guid("28ccccdc-30eb-455b-b274-05d78b237498") },
                    { new Guid("7259f14d-1878-4de5-a5d9-8e4b2ab4e01a"), new Guid("28ccccdc-30eb-455b-b274-05d78b237498") },
                    { new Guid("9a3284b5-de86-4ad9-ae4c-d3609f9577e7"), new Guid("28ccccdc-30eb-455b-b274-05d78b237498") },
                    { new Guid("c48b0ed7-dd23-4e74-9b59-d130398a8393"), new Guid("28ccccdc-30eb-455b-b274-05d78b237498") },
                    { new Guid("ff7c5a2f-03d7-4d8a-9187-374b8bc12011"), new Guid("28ccccdc-30eb-455b-b274-05d78b237498") },
                    { new Guid("0f434edd-b23d-4d0d-b077-0af4e79b9724"), new Guid("28f0ced0-29e5-4487-85ca-15c072a53f4c") },
                    { new Guid("188ecd2e-d396-49f6-96fc-c230f1c4c5fd"), new Guid("28f0ced0-29e5-4487-85ca-15c072a53f4c") },
                    { new Guid("1ba392ba-2216-4498-8f0f-104cff8db456"), new Guid("28f0ced0-29e5-4487-85ca-15c072a53f4c") },
                    { new Guid("63d58133-904d-4b56-bbfa-d9287bb2db42"), new Guid("28f0ced0-29e5-4487-85ca-15c072a53f4c") },
                    { new Guid("69f1b9de-0730-442c-b100-e0a138019568"), new Guid("28f0ced0-29e5-4487-85ca-15c072a53f4c") },
                    { new Guid("6912e78e-fe60-4284-bba3-1c6fab5da7b8"), new Guid("3da4819b-e78c-479e-b95d-627a7e75fd6a") },
                    { new Guid("bf6cb36c-f093-4aa9-a7ce-889d9641d019"), new Guid("3da4819b-e78c-479e-b95d-627a7e75fd6a") },
                    { new Guid("ee9347bc-4e42-4704-be10-68d0de0bce83"), new Guid("3da4819b-e78c-479e-b95d-627a7e75fd6a") },
                    { new Guid("0f434edd-b23d-4d0d-b077-0af4e79b9724"), new Guid("7bd0d44e-f643-4416-af0c-87cb9e219370") },
                    { new Guid("1ba392ba-2216-4498-8f0f-104cff8db456"), new Guid("7bd0d44e-f643-4416-af0c-87cb9e219370") },
                    { new Guid("1e65fa55-2c19-4c82-a432-516534c99bc0"), new Guid("7bd0d44e-f643-4416-af0c-87cb9e219370") },
                    { new Guid("5a7447dd-e69c-4854-b954-d9a7e7a1ea7f"), new Guid("7bd0d44e-f643-4416-af0c-87cb9e219370") },
                    { new Guid("b474882b-c9b9-4d5a-a1da-ad0c06ba1bb3"), new Guid("7bd0d44e-f643-4416-af0c-87cb9e219370") },
                    { new Guid("efb3a2b8-c410-4793-8156-7d32de3cf541"), new Guid("7bd0d44e-f643-4416-af0c-87cb9e219370") },
                    { new Guid("ff7c5a2f-03d7-4d8a-9187-374b8bc12011"), new Guid("7bd0d44e-f643-4416-af0c-87cb9e219370") },
                    { new Guid("450394fc-a9a3-42b5-90e4-d24207819c27"), new Guid("8c56639b-2bc7-4857-97cf-b4ea2afc56f4") },
                    { new Guid("474575eb-d7cf-4069-a41c-e1c306342674"), new Guid("8c56639b-2bc7-4857-97cf-b4ea2afc56f4") },
                    { new Guid("487de90a-b378-471e-9e5d-d2207b4891d2"), new Guid("8c56639b-2bc7-4857-97cf-b4ea2afc56f4") },
                    { new Guid("ae7f256b-bc62-4e75-bdf4-808da41f1004"), new Guid("8c56639b-2bc7-4857-97cf-b4ea2afc56f4") },
                    { new Guid("d615aff5-b881-4c4c-959b-e8468bbebbf4"), new Guid("8c56639b-2bc7-4857-97cf-b4ea2afc56f4") },
                    { new Guid("efb3a2b8-c410-4793-8156-7d32de3cf541"), new Guid("8c56639b-2bc7-4857-97cf-b4ea2afc56f4") },
                    { new Guid("f3f638e5-6468-4600-8941-5a79868e6b29"), new Guid("8c56639b-2bc7-4857-97cf-b4ea2afc56f4") },
                    { new Guid("b1993f42-dafe-46ca-8c4e-4161c2c4b2bb"), new Guid("a5987acd-af9d-4102-ab3f-a4f08f68d841") },
                    { new Guid("d1b42218-f286-4f38-b99c-4df607fc6bde"), new Guid("a5987acd-af9d-4102-ab3f-a4f08f68d841") },
                    { new Guid("e8878eeb-4173-4f71-ab42-e19004729544"), new Guid("a5987acd-af9d-4102-ab3f-a4f08f68d841") },
                    { new Guid("1192446a-5e73-48e2-9653-5e8c3870ae4b"), new Guid("abd7f05f-1138-40a1-84c4-846411701fb4") },
                    { new Guid("1e65fa55-2c19-4c82-a432-516534c99bc0"), new Guid("abd7f05f-1138-40a1-84c4-846411701fb4") },
                    { new Guid("35d857b4-8190-4adf-9708-58e1d6a895ff"), new Guid("abd7f05f-1138-40a1-84c4-846411701fb4") },
                    { new Guid("38872df0-e129-4259-a3f4-4ee53ddb250d"), new Guid("abd7f05f-1138-40a1-84c4-846411701fb4") },
                    { new Guid("474575eb-d7cf-4069-a41c-e1c306342674"), new Guid("abd7f05f-1138-40a1-84c4-846411701fb4") },
                    { new Guid("63d58133-904d-4b56-bbfa-d9287bb2db42"), new Guid("abd7f05f-1138-40a1-84c4-846411701fb4") },
                    { new Guid("b924f0cb-70b3-4e03-b6c3-91724434dc58"), new Guid("abd7f05f-1138-40a1-84c4-846411701fb4") },
                    { new Guid("38872df0-e129-4259-a3f4-4ee53ddb250d"), new Guid("b4fd8a39-2b59-4cbf-a14d-b2a3227ab253") },
                    { new Guid("d615aff5-b881-4c4c-959b-e8468bbebbf4"), new Guid("b4fd8a39-2b59-4cbf-a14d-b2a3227ab253") },
                    { new Guid("5a7447dd-e69c-4854-b954-d9a7e7a1ea7f"), new Guid("bde649fd-da82-4255-85c9-e47db4529f9e") },
                    { new Guid("60549876-68fe-41ee-8cf3-bcaad740c83f"), new Guid("bde649fd-da82-4255-85c9-e47db4529f9e") },
                    { new Guid("6ee634eb-3d33-44d1-a989-d9773e9a3946"), new Guid("bde649fd-da82-4255-85c9-e47db4529f9e") },
                    { new Guid("b474882b-c9b9-4d5a-a1da-ad0c06ba1bb3"), new Guid("bde649fd-da82-4255-85c9-e47db4529f9e") },
                    { new Guid("b924f0cb-70b3-4e03-b6c3-91724434dc58"), new Guid("bde649fd-da82-4255-85c9-e47db4529f9e") },
                    { new Guid("c48b0ed7-dd23-4e74-9b59-d130398a8393"), new Guid("bde649fd-da82-4255-85c9-e47db4529f9e") },
                    { new Guid("b1993f42-dafe-46ca-8c4e-4161c2c4b2bb"), new Guid("d2feaa6c-447c-4336-9729-2d40e6e369eb") },
                    { new Guid("c8b83ee1-6e18-497a-ace6-32395155c426"), new Guid("d2feaa6c-447c-4336-9729-2d40e6e369eb") },
                    { new Guid("4a019e46-f0c3-4ce8-ad11-d5f511cfcaad"), new Guid("f5c2b447-dd2f-4126-b27b-cf2c533a9d75") },
                    { new Guid("69f1b9de-0730-442c-b100-e0a138019568"), new Guid("f5c2b447-dd2f-4126-b27b-cf2c533a9d75") },
                    { new Guid("b1004e2e-3074-45f3-b440-db36596895fd"), new Guid("f5c2b447-dd2f-4126-b27b-cf2c533a9d75") },
                    { new Guid("bf6cb36c-f093-4aa9-a7ce-889d9641d019"), new Guid("f5c2b447-dd2f-4126-b27b-cf2c533a9d75") },
                    { new Guid("c48b0ed7-dd23-4e74-9b59-d130398a8393"), new Guid("f5c2b447-dd2f-4126-b27b-cf2c533a9d75") },
                    { new Guid("ff7c5a2f-03d7-4d8a-9187-374b8bc12011"), new Guid("f5c2b447-dd2f-4126-b27b-cf2c533a9d75") },
                    { new Guid("1192446a-5e73-48e2-9653-5e8c3870ae4b"), new Guid("f91bb938-5073-4fe6-b69a-6e6821a9c10a") },
                    { new Guid("17c6dc20-eb7b-4e55-adf8-fd44fba5b490"), new Guid("f91bb938-5073-4fe6-b69a-6e6821a9c10a") },
                    { new Guid("7259f14d-1878-4de5-a5d9-8e4b2ab4e01a"), new Guid("f91bb938-5073-4fe6-b69a-6e6821a9c10a") },
                    { new Guid("b57a4007-ab4f-4256-a54a-14b9ade0b7cc"), new Guid("f91bb938-5073-4fe6-b69a-6e6821a9c10a") },
                    { new Guid("b924f0cb-70b3-4e03-b6c3-91724434dc58"), new Guid("f91bb938-5073-4fe6-b69a-6e6821a9c10a") },
                    { new Guid("bf6cb36c-f093-4aa9-a7ce-889d9641d019"), new Guid("f91bb938-5073-4fe6-b69a-6e6821a9c10a") },
                    { new Guid("ff7c5a2f-03d7-4d8a-9187-374b8bc12011"), new Guid("f91bb938-5073-4fe6-b69a-6e6821a9c10a") }
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
