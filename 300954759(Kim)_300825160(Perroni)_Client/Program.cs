using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _300954759_Kim__300825160_Perroni__Client
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            // TODO:
            // Routine to get input from user to execute a HTTP request.
            // Create a menu and control it by using a loop structure
            RunAsync(11).GetAwaiter().GetResult();
            Console.ReadKey();
        }

        static async Task RunAsync(int opt)
        {
            client.BaseAddress = new Uri("http://localhost:63885");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            // This line should add the apikey to the request
            // client.DefaultRequestHeaders.Add("x-apikey", "//apikey value");

            int opt = 0;
            while(opt != -1)
            {
                Console.WriteLine("***Enter selection to run API operations***");
                Console.WriteLine("---***Books operations:***---\n " +
                    "1 - Get all \n 2 - Get a Book \n 3 - Create a Book \n 4 - Delete a Book \n 5 - Update a Book\n " +
                    "---***Authors operations:***---\n " +
                    "6 - Get all \n 7 - Get an Author \n 8 - Create an Author\n " +
                    "---***Genres operations***---\n " +
                    "9 - Get all \n 10 - Get a Genre \n 11 - Create a Genre\n\n" +
                    "*****Enter -1 to exit******\n" +
                    "===========================");
                opt = int.Parse(Console.ReadLine());
                Console.WriteLine("Loading....");
                RunAsync(opt).GetAwaiter().GetResult();
            }
        }

        static async Task RunAsync(int opt)
        {
            // Based on the option provided by input, execute a particular HTTP request
            switch (opt)
            {
                // From 1-5 Books Operations
                case 1:
                    {
                        await getAllBooks();
                        break;
                    }
                case 2:
                    {
                        await getABook();
                        break;
                    }
                case 3:
                    {
                        await createABook();
                        break;
                    }
                case 4:
                    {
                        await deleteABook();
                        break;
                    }
                case 5:
                    {
                        await updateABook();
                        break;
                    }
                // 6 - 8 Authors' Operations
                case 6:
                    {
                        await getAllAuthors();
                        break;
                    }
                case 7:
                    {
                        await getAnAuthor();
                        break;
                    }
                case 8:
                    {
                        await createAnAuthor();
                        break;
                    }
                // 9 - 11 Genres' Operations
                case 9:
                    {
                        await getAllGenres();
                        break;
                    }
                case 10:
                    {
                        await getAGenre();
                        break;
                    }
                case 11:
                    {
                        await createAGenre();
                        break;
                    }
                // 12 - 14 Users' Operations
                case 12:
                    {
                        await getAllUsers();
                        break;
                    }
                case 13:
                    {
                        await getAnUser();
                        break;
                    }
                case 14:
                    {
                        await createAnUser();
                        break;
                    }
                // 15 - 19 Shelves' Operations
                case 15:
                    {
                        await getAllShelves();
                        break;
                    }
                case 16:
                    {
                        await getAShelf();
                        break;
                    }
                case 17:
                    {
                        await createAShelf();
                        break;
                    }
                case 18:
                    {
                        await deleteAShelf();
                        break;
                    }
                case 19:
                    {
                        await updateAShelf();
                        break;
                    }
                // 20 - 22 BookShelves' Operations
                case 20:
                    {
                        await getAllBookShelves();
                        break;
                    }
                case 21:
                    {
                        await getABookShelf();
                        break;
                    }
                case 22:
                    {
                        await createABookShelf();
                        break;
                    }
                case 23:
                    {
                        await deleteABookShelf();
                        break;
                    }
            }
        }

        //***************Book methods*******************//
        static async Task getAllBooks()
        {
            try
            {
                string json;
                HttpResponseMessage response;
                response = await client.GetAsync("/api/Books");

                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();
                    IEnumerable<Book> books =
                        JsonConvert.DeserializeObject<IEnumerable<Book>>(json);

                    foreach (Book c in books)
                    {
                        // Printing book title only
                        Console.WriteLine(c.Title);
                    }
                }
                else
                {
                    Console.WriteLine("Internal Server Error");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static async Task getABook()
        {
            try
            {
                // Hardcoded value id = 52 == Bag of Bones
                int id = 52;
                HttpResponseMessage response = await client.GetAsync("/api/Books/" + id);

                if (response.IsSuccessStatusCode)
                {
                    Book book = await response.Content.ReadAsAsync<Book>();
                    Console.WriteLine("The book retrieved is: " + book.Title);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Intersal server error");
            }
        }

        static async Task createABook()
        {
            DateTime date = new DateTime(2002, 02, 17);
            Console.WriteLine(date);
            try
            {
                // Hardcoded book object
                Book book = new Book
                {
                    Title = "Return of the King",
                    PublicationDate = "2002-02-17",
                    Publisher = "Kool Books",
                    NumOfPages = 359,
                    GenreId = 20,
                    AuthorId = 13
                };

                Console.WriteLine(book.Title);
                string postBody = JsonConvert.SerializeObject(book);
                HttpResponseMessage response = await client.PostAsJsonAsync("/api/Books", book);
            }
            catch (Exception e)
            {
                Console.WriteLine("Internal server error");
            }
        }

        static async Task deleteABook()
        {
            try
            {
                // Hardcoded value id = 54 (May change since it is deleted from db)
                HttpResponseMessage response = await client.DeleteAsync("/api/Books/" + 54);
                Console.WriteLine($"status from DELETE {response.StatusCode}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine("Internal server error");
            }

        }

        static async Task updateABook()
        {
            try
            {
                Book book = new Book
                {
                    Id = 60,
                    Title = "Return of the King",
                    PublicationDate = "2002-03-17",
                    Publisher = "Kool Books",
                    NumOfPages = 380,
                    GenreId = 20,
                    AuthorId = 13
                };

                // Hardcoded value id = 60 == Return of the King
                HttpResponseMessage response = await client.PutAsJsonAsync("/api/Books/60", book);
                Console.WriteLine($"status from PUT {response.StatusCode}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine("Internal server error");
            }
        }
        //***************End of Book methods*******************//

        //***************Authors methods*******************//
        static async Task getAllAuthors()
        {
            try
            {
                string json;
                HttpResponseMessage response;
                response = await client.GetAsync("/api/Authors");

                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();
                    IEnumerable<Author> authors =
                        JsonConvert.DeserializeObject<IEnumerable<Author>>(json);

                    foreach (Author c in authors)
                    {
                        // Printing author's first name only
                        Console.WriteLine(c.FirstName);
                    }
                }
                else
                {
                    Console.WriteLine("Internal Server Error");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static async Task getAnAuthor()
        {
            try
            {
                // Hardcoded value id = 13 == J.R.R Tolkien
                int id = 13;
                HttpResponseMessage response = await client.GetAsync("/api/Authors/" + id);

                if (response.IsSuccessStatusCode)
                {
                    Author author = await response.Content.ReadAsAsync<Author>();
                    Console.WriteLine("The author retrieved is: " + author.FirstName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Intersal server error");
            }
        }

        static async Task createAnAuthor()
        {
            try
            {
                Author author = new Author
                {
                    FirstName = "Sun",
                    LastName = "Tzu",
                    AreaOfInterest = "War"
                };

                HttpResponseMessage response = await client.PostAsJsonAsync("/api/Authors", author);
            }
            catch (Exception e)
            {
                Console.WriteLine("Internal server error");
            }
        }
        //***************End ofAuthors methods*******************//

        //***************Genres methods*******************//
        static async Task getAllGenres()
        {
            try
            {
                string json;
                HttpResponseMessage response;
                response = await client.GetAsync("/api/Genres");

                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();
                    IEnumerable<Genre> genres =
                        JsonConvert.DeserializeObject<IEnumerable<Genre>>(json);

                    foreach (Genre c in genres)
                    {
                        // Printing genre's name only
                        Console.WriteLine(c.Name);
                    }
                }
                else
                {
                    Console.WriteLine("Internal Server Error");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static async Task getAGenre()
        {
            try
            {
                // Hardcoded value id = 16 == Thriller
                int id = 16;
                HttpResponseMessage response = await client.GetAsync("/api/Genres/" + id);

                if (response.IsSuccessStatusCode)
                {
                    Genre genre = await response.Content.ReadAsAsync<Genre>();
                    Console.WriteLine("The genre retrieved is: " + genre.Name);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Intersal server error");
            }
        }

        static async Task createAGenre()
        {
            try
            {
                Genre genre = new Genre
                {
                    Name = "True Crime",
                    Description = "Based on real stories, this genre holds stories about crimes that happened"
                    + "in the past about the most famous masterminds and biggest crime jobs executed"
                };

                HttpResponseMessage response = await client.PostAsJsonAsync("/api/Genres", genre);
            }
            catch (Exception e)
            {
                Console.WriteLine("Internal server error");
            }
        }
        //***************End of Genres methods*******************//

        //***************Users methods*******************//
        static async Task getAllUsers()
        {
            try
            {
                string json;
                HttpResponseMessage response;
                response = await client.GetAsync("/api/Users");

                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();
                    IEnumerable<User> users =
                        JsonConvert.DeserializeObject<IEnumerable<User>>(json);

                    foreach (User u in users)
                    {
                        // Print user's full name
                        Console.WriteLine("Users' Name: ");
                        Console.WriteLine(u.FirstName + " " + u.LastName);
                    }
                }
                else
                {
                    Console.WriteLine("Internal Server Error");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static async Task getAnUser()
        {
            try
            {
                // Hardcoded value id = 1 == Heeyeong Kim
                int id = 1;
                HttpResponseMessage response = await client.GetAsync("/api/Users/" + id);

                if (response.IsSuccessStatusCode)
                {
                    User user = await response.Content.ReadAsAsync<User>();
                    Console.WriteLine("Retrieved user's name: " + user.FirstName + " " + user.LastName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Intersal server error");
            }
        }

        static async Task createAnUser()
        {
            try
            {
                User user = new User
                {
                    FirstName = "Chris",
                    LastName = "Jang",
                    Address = "1234 Bloor Street"
                };

                HttpResponseMessage response = await client.PostAsJsonAsync("/api/Users", user);
            }
            catch (Exception e)
            {
                Console.WriteLine("Internal server error");
            }
        }
        //***************End of Users methods*******************//

        //***************Shelf methods*******************//
        static async Task getAllShelves()
        {
            try
            {
                string json;
                HttpResponseMessage response;
                response = await client.GetAsync("/api/Shelves");

                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();
                    IEnumerable<Shelf> shelves =
                        JsonConvert.DeserializeObject<IEnumerable<Shelf>>(json);

                    foreach (Shelf s in shelves)
                    {
                        // Print shelf's name only
                        Console.WriteLine("Shelves' Name: ");
                        Console.WriteLine(s.Name);
                    }
                }
                else
                {
                    Console.WriteLine("Internal Server Error");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static async Task getAShelf()
        {
            try
            {
                // Hardcoded value id = 3 == Coding Books
                int id = 3;
                HttpResponseMessage response = await client.GetAsync("/api/Shelves/" + id);

                if (response.IsSuccessStatusCode)
                {
                    Shelf shelf = await response.Content.ReadAsAsync<Shelf>();
                    Console.WriteLine("The shelf retrieved is: " + shelf.Name);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Intersal server error");
            }
        }

        static async Task createAShelf()
        {
            try
            {
                // Hardcoded shelf object
                Shelf shelf = new Shelf
                {
                    Name = "Romance",
                    UserId = 2
                };

                Console.WriteLine(shelf.Name);
                string postBody = JsonConvert.SerializeObject(shelf);
                HttpResponseMessage response = await client.PostAsJsonAsync("/api/Shelves", shelf);
            }
            catch (Exception e)
            {
                Console.WriteLine("Internal server error");
            }
        }

        static async Task deleteAShelf()
        {
            try
            {
                // Hardcoded value id = 6 (May change since it is deleted from db)
                HttpResponseMessage response = await client.DeleteAsync("/api/Shelves/" + 6);
                Console.WriteLine($"status from DELETE {response.StatusCode}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine("Internal server error");
            }

        }

        static async Task updateAShelf()
        {
            try
            {
                Shelf shelf = new Shelf
                {
                    Id = 6,
                    Name = "Novel"
                };

                // Hardcoded value id = 6 == Comic
                HttpResponseMessage response = await client.PutAsJsonAsync("/api/Shelves/6", shelf);
                Console.WriteLine($"status from PUT {response.StatusCode}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine("Internal server error");
            }
        }
        //***************End of Shelf methods*******************//

        //***************BookShelf methods*******************//
        static async Task getAllBookShelves()
        {
            try
            {
                string json;
                HttpResponseMessage response;
                response = await client.GetAsync("/api/BookShelves");

                if (response.IsSuccessStatusCode)
                {
                    json = await response.Content.ReadAsStringAsync();
                    IEnumerable<Bookshelf> bookshelves =
                        JsonConvert.DeserializeObject<IEnumerable<Bookshelf>>(json);

                    foreach (Bookshelf bs in bookshelves)
                    {
                        // Print book id and shelf id
                        Console.WriteLine("ShelfId: " + bs.ShelfId + " BookId: " + bs.BookId);
                    }
                }
                else
                {
                    Console.WriteLine("Internal Server Error");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static async Task getABookShelf()
        {
            try
            {
                // Hardcoded value id = 12 == ShelfId:3/BookId:50
                int id = 12;
                HttpResponseMessage response = await client.GetAsync("/api/BookShelves/" + id);

                if (response.IsSuccessStatusCode)
                {
                    Bookshelf bookshelf = await response.Content.ReadAsAsync<Bookshelf>();
                    Console.WriteLine("Retrieved bookshelf's ShelfId: " + bookshelf.ShelfId + " BookId: " + bookshelf.BookId);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Intersal server error");
            }
        }

        static async Task createABookShelf()
        {
            try
            {
                // Hardcoded shelf object
                Bookshelf bookshelf = new Bookshelf
                {
                    ShelfId=4,
                    BookId=53
                };

                string postBody = JsonConvert.SerializeObject(bookshelf);
                HttpResponseMessage response = await client.PostAsJsonAsync("/api/BookShelves", bookshelf);
            }
            catch (Exception e)
            {
                Console.WriteLine("Internal server error");
            }
        }

        static async Task deleteABookShelf()
        {
            try
            {
                // Hardcoded value id = 12 (May change since it is deleted from db)
                HttpResponseMessage response = await client.DeleteAsync("/api/BookShelves/" + 13);
                Console.WriteLine($"status from DELETE {response.StatusCode}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine("Internal server error");
            }

        }
        //***************End of BookShelf methods*******************//

    }
}
