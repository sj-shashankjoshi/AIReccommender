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
            List <Book> book = new List <Book>();
            List<BookUserRating> rating = new List<BookUserRating>();
            List<User> user = new List<User>();
        }       
        public List<Book> book { set; get; }
        public List<BookUserRating> rating { set; get; }
        public List <User> UserData { set; get; }
    }
}
