namespace thing
{

    using System;
    using thing.Models;

    using System.Collections.Generic;
    public class Program
    {
        static List<Book> books = new List<Book>();

        public static void Main(string[] args)
        {
            books.Add(new Book("The Hunger Games", "Suzanne Collins", Convert.ToInt32("2008"), "Drama", false));
            books.Add(new Book("Catching Fire", "Suzanne Collins", Convert.ToInt32("2009"), "Science Fiction", true));
            books.Add(new Book("Mockingjay", "Suzanne Collins", Convert.ToInt32("2010"), "Science Fiction", true));
            books.Add(new Book("The Da Vinci Code", "Dan Brown", Convert.ToInt32("2003"), "Mystery", false));
            books.Add(new Book("Dracula", "Bram Stoker", Convert.ToInt32("1897"), "Horror", true));


            while (true)
            {
                Console.WriteLine("Choose a command: ");
                Console.WriteLine("X - Close program");
                Console.WriteLine("1 - Add a book to the list");
                Console.WriteLine("2 - Remove a book from the list");
                Console.WriteLine("3 - Show all books");
                Console.WriteLine("4 - Show books by genere");
                Console.WriteLine("5 - Show books by author or title");
                Console.WriteLine("6 - Check if the book is available or not");

                string command = Console.ReadLine();

                if (command.Equals("X", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                if (command == "1")
                {
                    AddBook();
                }
                if (command == "2")
                {
                    RemoveBook();
                }
                if (command == "3")
                {
                    PrintEverything();
                }
                if (command == "4")
                {
                    PrintByGenre();
                }
                if (command == "5")
                {
                    PrintByNameOrAuthor();
                }
                if (command == "6")
                {
                    TakenOrNot();
                }

            }
        }
        static void AddBook()
        {

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Author: ");
            string author = Console.ReadLine();

            Console.Write("Publication year: ");
            int publicationDate = Convert.ToInt32(Console.ReadLine());

            Console.Write("Genere: ");
            string genere = Console.ReadLine();

            bool takenornot = false;

            books.Add(new Book(name, author, publicationDate, genere, takenornot));

            Console.WriteLine("Book has been added!");

        }
        static void RemoveBook()
        {
            Console.WriteLine("Please provide the name of the book you want to delete: ");

            string name = Console.ReadLine();

            Book remove = books.Find(b => b.name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (remove != null)
            {
                books.Remove(remove);
                Console.WriteLine("Book has been removed.");
            }
            else
            {
                Console.WriteLine("Book has not been found");
            }
        }

        static void PrintEverything()
        {
            foreach (Book item in books)
            {
                Console.WriteLine(item);
            }
        }

        static void PrintByGenre()
        {
            // Feature: show books by genre implemented
            Console.WriteLine("Which genre would like to search by?");
            string genre = Console.ReadLine();

            List<Book> hits = books.FindAll(b => b.genere.Equals(genre, StringComparison.OrdinalIgnoreCase));

            if (hits.Count == 0)
            {
                Console.WriteLine("No books have been found by that genre.");
            }
            else
            {
                foreach (Book b in hits)
                {
                    Console.WriteLine(b);
                }
            }
        }

        static void PrintByNameOrAuthor()
        {
            Console.WriteLine("Which book title or author would you like to search?");

            string nameorauthor = Console.ReadLine();

            List<Book> hitsnames = books.FindAll(b => b.name.Equals(nameorauthor, StringComparison.OrdinalIgnoreCase));

            List<Book> hitsauthor = books.FindAll(b => b.author.Equals(nameorauthor, StringComparison.OrdinalIgnoreCase));

            if (hitsnames.Count == 0 && hitsauthor.Count == 0)
            {
                Console.WriteLine("Book or author not found");

            }
            else
            {
                foreach (Book b in hitsnames)
                {
                    Console.WriteLine(b);
                }
                foreach (Book b in hitsauthor)
                {
                    Console.WriteLine(b);
                }
            }

        }

        static void TakenOrNot()
        {
            Console.WriteLine("Which book would you like to see if it is available? (Provide title only)");
            string name = Console.ReadLine();

            Book taken = books.Find(b => b.name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (taken != null)
            {
                if (taken.takenornot)
                {
                    Console.WriteLine("The book is not available.");

                }

                else
                {
                    Console.WriteLine("The book is available.");
                }
            }
            else
            {
                Console.WriteLine("Book has not been found");
            }
        }
    }
}