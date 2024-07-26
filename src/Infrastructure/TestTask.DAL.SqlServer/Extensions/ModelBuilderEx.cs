using Microsoft.EntityFrameworkCore;
using TestTask.Domain.Entities;
using TestTask.Domain.Enums;

namespace TestTask.DAL.SqlServer.Extensions;

public static class ModelBuilderEx
{
    private static readonly List<Genre> Genres = new()
    {
        new Genre { Title = "Science Fiction" },
        new Genre { Title = "Fantasy" },
        new Genre { Title = "Mystery" },
        new Genre { Title = "Thriller" },
        new Genre { Title = "Romance" },
        new Genre { Title = "Historical Fiction" },
        new Genre { Title = "Horror" },
        new Genre { Title = "Adventure" },
        new Genre { Title = "Non-Fiction" },
        new Genre { Title = "Biography" },
        new Genre { Title = "Drama" },
        new Genre { Title = "Comedy" },
        new Genre { Title = "Poetry" },
        new Genre { Title = "Self-Help" },
        new Genre { Title = "Cookbook" },
        new Genre { Title = "Science" },
        new Genre { Title = "Business" },
        new Genre { Title = "Travel" },
    };

    private static readonly List<Author> Authors = new()
    {
        new Author { FullName = "Jane Austen" },
        new Author { FullName = "Charles Dickens" },
        new Author { FullName = "F. Scott Fitzgerald" },
        new Author { FullName = "J.K. Rowling" },
        new Author { FullName = "Agatha Christie" },
        new Author { FullName = "George Orwell" },
        new Author { FullName = "Leo Tolstoy" },
        new Author { FullName = "William Shakespeare" },
        new Author { FullName = "Mark Twain" },
        new Author { FullName = "Gabriel García Márquez" },
        new Author { FullName = "Harper Lee" },
        new Author { FullName = "J.R.R. Tolkien" },
        new Author { FullName = "Homer" },
        new Author { FullName = "Stephen King" },
        new Author { FullName = "Ernest Hemingway" },
        new Author { FullName = "Emily Brontë" },
        new Author { FullName = "Virginia Woolf" },
        new Author { FullName = "Charlotte Brontë" },
        new Author { FullName = "Arthur Conan Doyle" },
        new Author { FullName = "Ayn Rand" },
        new Author { FullName = "Jane Goodall" },
        new Author { FullName = "Michael Crichton" },
        new Author { FullName = "Isaac Asimov" },
        new Author { FullName = "Margaret Atwood" },
        new Author { FullName = "Kurt Vonnegut" },
        new Author { FullName = "H.G. Wells" },
        new Author { FullName = "Roald Dahl" },
        new Author { FullName = "Hermann Hesse" },
        new Author { FullName = "Aldous Huxley" },
        new Author { FullName = "Toni Morrison" },
    };

    private static readonly List<BookInfo> BookInfos = new()
    {
        new BookInfo { Title = "Pride and Prejudice", ISBN = "978-0-14-143951-8", Description = "A timeless tale of love, manners, and societal expectations in Regency-era England by Jane Austen." },
        new BookInfo { Title = "To Kill a Mockingbird", ISBN = "978-0-06-112348-4", Description = "Harper Lee's powerful exploration of racial injustice and moral growth in the American South." },
        new BookInfo { Title = "1984", ISBN = "978-0-45-152493-5", Description = "George Orwell's dystopian masterpiece, depicting a nightmarish future under totalitarian rule." },
        new BookInfo { Title = "The Great Gatsby", ISBN = "978-0-74-327356-5", Description = "F. Scott Fitzgerald's classic portrayal of the American Dream, excess, and disillusionment in the Roaring Twenties." },
        new BookInfo { Title = "Harry Potter and the Sorcerer's Stone", ISBN = "978-0-59-035342-7", Description = "J.K. Rowling's enchanting introduction to the wizarding world, filled with magic, friendship, and adventure." },
        new BookInfo { Title = "The Hobbit", ISBN = "978-0-54-792822-7" },
        new BookInfo { Title = "The Catcher in the Rye", ISBN = "978-0-31-676948-0", Description = "J.D. Salinger's iconic coming-of-age novel, capturing the angst and rebellion of a teenage boy in post-World War II America." },
        new BookInfo { Title = "War and Peace", ISBN = "978-0-14-303500-8", Description = "Leo Tolstoy's epic portrayal of Russian society during the Napoleonic Wars, blending history, philosophy, and human drama." },
        new BookInfo { Title = "The Odyssey", ISBN = "978-0-14-303995-2", Description = "Homer's ancient Greek epic, recounting the adventures of Odysseus as he journeys home from the Trojan War." },
        new BookInfo { Title = "Brave New World", ISBN = "978-0-06-085052-4" },
        new BookInfo { Title = "The Lord of the Rings", ISBN = "978-0-54-400341-5", Description = "J.R.R. Tolkien's epic fantasy trilogy, featuring the quest to destroy the One Ring and save Middle-earth from the dark forces of Sauron." },
        new BookInfo { Title = "Frankenstein", ISBN = "978-0-48-628211-4", Description = "Mary Shelley's gothic tale of scientific hubris and the consequences of creating life." },
        new BookInfo { Title = "Crime and Punishment", ISBN = "978-0-14-310763-7", Description = "Fyodor Dostoevsky's psychological thriller, exploring the moral and psychological turmoil of a young man in St. Petersburg." },
        new BookInfo { Title = "One Hundred Years of Solitude", ISBN = "978-0-06-112028-4" },
        new BookInfo { Title = "The Chronicles of Narnia", ISBN = "978-0-06-112008-4", Description = "C.S. Lewis's beloved fantasy series, taking readers to the enchanting land of Narnia and its magical inhabitants." },
        new BookInfo { Title = "The Hitchhiker's Guide to the Galaxy", ISBN = "978-0-34-539180-3", Description = "Douglas Adams's hilarious space adventure, following the misadventures of Arthur Dent and his extraterrestrial friend Ford Prefect." },
        new BookInfo { Title = "The Shining", ISBN = "978-0-38-511683-7", Description = "Stephen King's chilling tale of supernatural horror, isolation, and the descent into madness at the haunted Overlook Hotel." },
        new BookInfo { Title = "Moby-Dick", ISBN = "978-0-14-310635-7", Description = "Herman Melville's epic journey aboard the whaling ship Pequod, driven by Captain Ahab's obsessive quest for the white whale." },
        new BookInfo { Title = "Alice's Adventures in Wonderland", ISBN = "978-0-19-921613-3" },
        new BookInfo { Title = "The Girl with the Dragon Tattoo", ISBN = "978-0-30-726975-1", Description = "Stieg Larsson's gripping mystery featuring investigative journalist Mikael Blomkvist and the enigmatic hacker Lisbeth Salander." },
        new BookInfo { Title = "The Hunger Games", ISBN = "978-0-43-902352-8", Description = "Suzanne Collins's dystopian saga of Katniss Everdeen's fight for survival in the annual Hunger Games." },
        new BookInfo { Title = "Dune", ISBN = "978-0-44-117271-9", Description = "Frank Herbert's science fiction epic set in a distant future where noble houses vie for control of the desert planet Arrakis and its valuable spice melange." },
        new BookInfo { Title = "The Brothers Karamazov", ISBN = "978-0-14-044924-2", Description = "Fyodor Dostoevsky's exploration of morality, faith, and family dynamics through the complex relationships of the Karamazov brothers." },
        new BookInfo { Title = "Wuthering Heights", ISBN = "978-0-14-143955-6" },
        new BookInfo { Title = "The Canterbury Tales", ISBN = "978-0-14-042234-4", Description = "Geoffrey Chaucer's collection of stories told by a diverse group of pilgrims on their journey to Canterbury." },
        new BookInfo { Title = "The Picture of Dorian Gray", ISBN = "978-0-14-143957-0" },
        new BookInfo { Title = "The Alchemist", ISBN = "978-0-06-112241-5", Description = "Paulo Coelho's philosophical novel about Santiago, a shepherd boy, on a journey to discover his personal legend." },
        new BookInfo { Title = "The Handmaid's Tale", ISBN = "978-0-38-549081-8", Description = "Margaret Atwood's dystopian novel set in the Republic of Gilead, where women's rights are severely restricted." },
        new BookInfo { Title = "The Road", ISBN = "978-0-30-738789-9", Description = "Cormac McCarthy's post-apocalyptic tale of a father and son's harrowing journey through a desolate landscape." },
        new BookInfo { Title = "The Count of Monte Cristo", ISBN = "978-0-14-044926-6", Description = "Alexandre Dumas's classic adventure novel of betrayal, revenge, and redemption." },
        new BookInfo { Title = "Les Misérables", ISBN = "978-0-45-141943-9" },
        new BookInfo { Title = "The Catch-22", ISBN = "978-0-68-484121-9", Description = "Joseph Heller's satirical novel depicting the absurdities and paradoxes of war." },
        new BookInfo { Title = "The Color Purple", ISBN = "978-0-15-602835-6" },
        new BookInfo { Title = "One Flew Over the Cuckoo's Nest", ISBN = "978-0-45-116396-7", Description = "Ken Kesey's classic novel set in a mental hospital, challenging authority and celebrating individuality." },
        new BookInfo { Title = "The Martian", ISBN = "978-0-55-341802-6", Description = "Andy Weir's gripping science fiction novel about an astronaut stranded on Mars and his fight for survival." },
        new BookInfo { Title = "The Kite Runner", ISBN = "978-1-59-463193-1", Description = "Khaled Hosseini's powerful novel about friendship, betrayal, and redemption in Afghanistan." },
        new BookInfo { Title = "The Silent Patient", ISBN = "978-1-25-030169-7" },
        new BookInfo { Title = "Educated", ISBN = "978-0-52-558019-4", Description = "Tara Westover's memoir recounting her journey from a rural Idaho childhood to gaining an education against all odds." },
        new BookInfo { Title = "Sapiens: A Brief History of Humankind", ISBN = "978-0-99-711060-8", Description = "Yuval Noah Harari's exploration of the history and impact of Homo sapiens on the world." },
        new BookInfo { Title = "The Goldfinch", ISBN = "978-0-31-605543-7", Description = "Donna Tartt's Pulitzer Prize-winning novel about a young boy's life after a terrorist attack in a New York art museum." },
        new BookInfo { Title = "The Night Circus", ISBN = "978-0-38-553970-6", Description = "Erin Morgenstern's magical tale of a mysterious competition between two illusionists in a magical circus." },
        new BookInfo { Title = "The Immortal Life of Henrietta Lacks", ISBN = "978-1-40-005217-2", Description = "Rebecca Skloot's biography exploring the life and legacy of Henrietta Lacks, whose cells were used for medical research without her knowledge." },
        new BookInfo { Title = "The Fault in Our Stars", ISBN = "978-0-14-242417-9", Description = "John Green's heart-wrenching novel about two teenagers with cancer who fall in love." },
        new BookInfo { Title = "The Road Less Traveled", ISBN = "978-0-74-324315-8", Description = "M. Scott Peck's exploration of personal growth, love, and spiritual development." },
        new BookInfo { Title = "The Girl on the Train", ISBN = "978-1-59-463402-4", Description = "Paula Hawkins's psychological thriller about a woman who becomes entangled in a missing person investigation." },
        new BookInfo { Title = "The Da Vinci Code", ISBN = "978-0-30-747427-8", Description = "Dan Brown's gripping mystery involving symbology, art, and secret societies." },
        new BookInfo { Title = "The Help", ISBN = "978-0-42-523220-0", Description = "Kathryn Stockett's novel about African American maids working in white households in Jackson, Mississippi, during the early 1960s." },
        new BookInfo { Title = "The Three Musketeers", ISBN = "978-0-14-044022-5" },
        new BookInfo { Title = "The Wind-Up Bird Chronicle", ISBN = "978-0-67-977543-0", Description = "Haruki Murakami's surreal and mesmerizing novel exploring the mysteries of human consciousness." },
        new BookInfo { Title = "The Book Thief", ISBN = "978-0-37-584220-7" },
        new BookInfo { Title = "The Joy Luck Club", ISBN = "978-0-80-417839-9", Description = "Amy Tan's novel exploring the relationships between Chinese-American immigrant mothers and their American-born daughters." },
        new BookInfo { Title = "The Grapes of Wrath", ISBN = "978-0-14-303943-3", Description = "John Steinbeck's novel depicting the struggles of a displaced Oklahoma family during the Great Depression." },
        new BookInfo { Title = "The Power of Habit", ISBN = "978-0-81-298160-5", Description = "Charles Duhigg's exploration of the science behind habits and how they can be transformed." },
        new BookInfo { Title = "The Secret Life of Bees", ISBN = "978-0-14-200174-5" },
        new BookInfo { Title = "The Immortalists", ISBN = "978-0-52-551488-0" },
        new BookInfo { Title = "The Glass Castle", ISBN = "978-0-74-324754-5", Description = "Jeannette Walls's memoir detailing her unconventional and often troubled childhood." }
    };
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(Genres);
        modelBuilder.Entity<Author>().HasData(Authors);

        var books = new List<Book>();
        var random = new Random();
        foreach (var item in BookInfos)
        {
            var book = new Book
            {
                ISBN = item.ISBN,
                Title = item.Title,
                Description = item.Description,
                AuthorId = Authors[random.Next(0, Authors.Count - 1)].Id,
                BookStatus = BookStatuses.Free,
            };

            books.Add(book);
        }

        modelBuilder.Entity<Book>().HasData(books);

        var bookGenres = new List<BookGenre>();
        foreach (var book in books)
        {
            for (int i = 0; i < random.Next(1, 5); )
            {
                var bookGenre = new BookGenre 
                { 
                    BookId = book.Id, 
                    GenreId = Genres[random.Next(0, Genres.Count - 1)].Id 
                };

                if (bookGenres.Any(e => e.GenreId == bookGenre.GenreId && e.BookId == bookGenre.BookId))
                {
                    continue;
                }

                bookGenres.Add(bookGenre);
                i++;
            }
        }

        modelBuilder.Entity<BookGenre>().HasData(bookGenres);
    }

    private class BookInfo
    {
        public string Title { get; set; } = null!;

        public string ISBN { get; set; } = null!;

        public string? Description { get; set; } = null!;
    }
}