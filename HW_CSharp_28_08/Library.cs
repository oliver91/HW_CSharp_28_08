using System;
using System.Collections;
using System.Collections.ObjectModel;

namespace HW_CSharp_28_08
{
    class Library : IEnumerable, IEnumerator
    {
        public event LibraryEventHandler evt;

        private ObservableCollection<Book> booksList = new ObservableCollection<Book>();
        private int position = -1;

        public void AddBook(Book b)
        {
            booksList.Add(b);
            if (evt != null)
                evt(b, true);
        }

        public Book TakeBook(string bookName)
        {
            Book currentBook = null;
            for (int i = 0; i < booksList.Count; i++)
            {
                if (booksList[i].BookName.Equals(bookName)) currentBook = booksList[i];
            }
            booksList.Remove(currentBook);
            
            Console.WriteLine(bookName + " is already taken!");

            if (evt != null)
                evt(currentBook, false);
            return currentBook;
        }

        public void PrintAllBooks()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nAvailable books: ");
            int i = 1;
            foreach (Book b in booksList)
            {
                Console.WriteLine("{0}. {1}, {2}, {3}", i,
                b.BookName, b.AuthorName, b.BookGenre);
                i++;
            }
            Console.WriteLine("\n");
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator) this;
        }

        public bool MoveNext()
        {
            position++;
            return (position < booksList.Count);
        }

        public void Reset()
        {
            position = 0;
        }

        public object Current
        {
            get { return booksList[position]; }
        }
    }
}
