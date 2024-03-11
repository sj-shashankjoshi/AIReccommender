using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIReccommender.Entities
{
    public class BookDetails
    {
        public BookDetails()
        {
            List<Book> book = new List<Book>();
            List<BookUserRating> rating = new List<BookUserRating>();
            List<User> user = new List<User>();
        }
        public List<Book> Book = new List<Book>();
        public List<BookUserRating> Rating  = new List<BookUserRating>();
        public List<User> UserData = new List<User>();
    }
}
