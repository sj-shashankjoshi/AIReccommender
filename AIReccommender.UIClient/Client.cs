using AIReccommender.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AIReccommender.UIClient
{
    internal class Client
    {
        static void Main(string[] args)
        {
            Preference preference = new Preference();
            Console.WriteLine("Enter your Prefrence: ");
            //Console.WriteLine("Generating Recommended List");
            Console.Write("ISBN: ");
            preference.ISBN = Console.ReadLine();
            //preference.ISBN = "0312970242";
            Console.Write("State: ");
            preference.State = Console.ReadLine();
            //preference.State = "california";
            Console.Write("Age: ");
            preference.Age = int.Parse(Console.ReadLine());
            //preference.Age = 40;

            Console.Write("Give the limit for the recommendation: ");
            int limit = int.Parse(Console.ReadLine());
            //int limit = 10;
            AIReccommenderEngine Engine1 = new AIReccommenderEngine();
            Console.WriteLine("Generating recommendation list");
            IList <Book> RList = Engine1.Recommend(preference, limit);
            Console.WriteLine("ISBN\t\tBookTitle\t\tBookAuthor\t\tPublisher\t\tYear of Publishing\t\tImage URL");
            foreach (Book book in RList)
            {
                Console.WriteLine($"{book.ISBN}\t\t{book.BookTitle}\t\t{book.BookAuthor}\t\t{book.Publisher}\t\t{book.YearOfPublication}\t\t{book.ImageUrlSmall}\t\t");
            }
        }
    }
}
