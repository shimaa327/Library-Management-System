namespace Library_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Library library = new Library();
            bool running = true;

            while (running)
            {
                
                Console.WriteLine("  Library Management System   ");
                Console.WriteLine("Enter your choice : ");
                Console.WriteLine("1-Add Book");
                Console.WriteLine("2- Add Member");
                Console.WriteLine("3- View All Books");
                Console.WriteLine("4- View All Members");
                Console.WriteLine("5- Search Book");
                Console.WriteLine("6- Borrow Book");
                Console.WriteLine("7- Return Book");
                Console.WriteLine("8- Exit");
               

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter book title: ");
                            string title = Console.ReadLine();
                            Console.Write("Enter author: ");
                            string author = Console.ReadLine();

                            Console.WriteLine("Select Category:");
                            Console.WriteLine("\n1: Programming \n2: Science  \n3: History  \n4: Fiction  \n5: Other");
                            
                            CategoryEnum category = (CategoryEnum)int.Parse(Console.ReadLine());

                            library.AddBook(new Book(title, author, category));
                            break;

                        case "2":
                            Console.Write("Enter member name: ");
                            string memberName = Console.ReadLine();
                            library.AddMember(new Member(memberName));
                            break;

                        case "3":
                            library.DisplayAllBooks();
                            break;

                        case "4":
                            library.DisplayAllMembers();
                            break;

                        case "5":
                            Console.WriteLine("1. Search by ID \n 2. Search by Title");
                            
                            string search = Console.ReadLine();

                            if (search == "1")
                            {
                                Console.Write("Enter Book ID: ");
                                int id = int.Parse(Console.ReadLine());
                                var book = library.SearchBookById(id);
                                if (book != null) book.DisplayInfo();
                                else Console.WriteLine("Book not found.");
                            }
                            else if (search == "2")
                            {
                                Console.Write("Enter Book Title: ");
                                string searchTitle = Console.ReadLine();
                                var results = library.SearchBooksByTitle(searchTitle);
                                if (results.Count > 0)
                                {
                                    foreach (var b in results) b.DisplayInfo();
                                }
                                else
                                {
                                    Console.WriteLine("No books found matching this title.");
                                }
                            }
                            break;

                        case "6":
                            Console.Write("Enter Book ID to borrow: ");
                            int borrowBookId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Member ID: ");
                            int borrowMemberId = int.Parse(Console.ReadLine());

                            library.BorrowBook(borrowBookId, borrowMemberId);
                            break;

                        case "7":
                            Console.Write("Enter Book ID to return: ");
                            int returnBookId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Member ID: ");
                            int returnMemberId = int.Parse(Console.ReadLine());

                            library.ReturnBook(returnBookId, returnMemberId);
                            break;

                        case "8":
                            running = false;
                            Console.WriteLine("Thank you for using the Library System. Goodbye!");
                            break;

                        default:
                            Console.WriteLine("Invalid option! Please enter a number between 1 and 8.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a valid number format.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }
            }
        }
    }


}
