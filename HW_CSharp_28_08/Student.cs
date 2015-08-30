using System;

namespace HW_CSharp_28_08
{
    class Student
    {
        private string name;

        public Student(string n)
        {
            name = n;
        }

        public void ComputerLiteratureHandler(Book b, bool flag)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (b.BookGenre.Equals("Computer literature") & flag)
                Console.WriteLine(name + ": " + "I'm going to the library!");
        }

        public void ScienceFictionHandler(Book b, bool flag)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (b.BookGenre.Equals("Science fiction") & flag)
                Console.WriteLine(name + ": " + "I want to order the book delivery!");
            if (!b.BookGenre.Equals("Science fiction") & !flag)
                Console.WriteLine(name + ": " + "I'm not going to read it!");
        }
    }
}
