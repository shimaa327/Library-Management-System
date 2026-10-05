using System;
using System.Collections.Generic;
using System.Text;

namespace Library_Management_System
{
    public class Book : IDisplayable
    {
        private static int nextID = 1;
        public int ID { get; private set; }
        public string Title { get;  set; }
        public string Author {  get;  set; }
        private bool IsBorrowed {  get; set; }
        public CategoryEnum Category { get; set; }



        public Book(string title, string author, CategoryEnum category)
        {
            Title = title;
            Author = author;
            Category = category;

           
            ID = nextID++;
        }









        public void DisplayInfo()
        {
            Console.WriteLine($"Book Details:\nID: {ID}, Title: {Title}, Author: {Author}, Category: {Category}, Is Borrowed: {IsBorrowed}");
        }

        public bool BorrowBook()
        {
            if (!IsBorrowed)
            {
                IsBorrowed = true;
                Console.WriteLine($"The book '{Title}' has been borrowed.");
                return true;
            }

            Console.WriteLine($"The book '{Title}' is already borrowed.");
            return false;
        }

        public bool ReturnBook()
        {
            if (IsBorrowed)
            {
                IsBorrowed = false;
                Console.WriteLine($"The book '{Title}' has been returned.");
                return true;
            }

            Console.WriteLine($"The book '{Title}' was not borrowed.");
            return false;
        }
    }
}