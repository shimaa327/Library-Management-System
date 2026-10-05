using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System
{
    public class Library
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Member> Members { get; set; } = new List<Member>();
        public void AddBook(Book book)
        {
            Books.Add(book);
            Console.WriteLine($"Book '{book.Title}' added successfully ");
            Console.WriteLine($"Book Details : \n Title :{ book.Title}\n ID:{book.ID}\n Author : {book.Author}\n Category : {book.Category}    ");
        }

       
        public void AddMember(Member member)
        {
            Members.Add(member);
            Console.WriteLine($"Member '{member.personName}' registered successfully ");
            Console.WriteLine($"Member Details: \n Name:{member.personName} \n MemberId:{ member.personID}");
        }

       
        public void DisplayAllBooks()
        {
            if (Books.Count == 0)
            {
                Console.WriteLine("No books available in the library.");
                return;
            }

            Console.WriteLine("\nAll Books");
            foreach (var book in Books)
            {
                book.DisplayInfo();
            }
        }

        
        public void DisplayAllMembers()
        {
            if (Members.Count == 0)
            {
                Console.WriteLine("No members registered yet.");
                return;
            }

            Console.WriteLine("\nAll Members");
            foreach (var member in Members)
            {
                member.DisplayInfo();
            }
        }

        
        public Book SearchBookById(int id)
        {
            return Books.FirstOrDefault(b => b.ID == id);
        }

        
        public List<Book> SearchBooksByTitle(string title)
        {
            return Books.Where(b => b.Title.ToLower().Contains(title.ToLower())).ToList();
        }





        public void BorrowBook(int bookId, int memberId)
        {
            var book = SearchBookById(bookId);
            var member = Members.FirstOrDefault(m => m.personID == memberId);

            if (book == null)
            {
                Console.WriteLine("Error: Book not found.");
                return;
            }

            if (member == null)
            {
                Console.WriteLine("Error: Member not found.");
                return;
            }

            
            bool isSuccess = book.BorrowBook();

            if (isSuccess)
            {
                Console.WriteLine($"Confirmed: Book '{book.Title}' is now borrowed by {member.personName}.");
            }
        }

        public void ReturnBook(int bookId, int memberId)
        {
            var book = SearchBookById(bookId);
            var member = Members.FirstOrDefault(m => m.personID == memberId);

            if (book == null)
            {
                Console.WriteLine("Error: Book not found.");
                return;
            }

            if (member == null)
            {
                Console.WriteLine("Error: Member not found.");
                return;
            }

           
            bool isSuccess = book.ReturnBook();

            if (isSuccess)
            {
                Console.WriteLine($"Confirmed: Book '{book.Title}' has been returned by {member.personName}.");
            }
        }
    }
}  

 
