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
            Book book = new Book();
            BookUserRating rating = new BookUserRating();
            User user = new User();
        }       
        public Book book { set; get; }
        public BookUserRating rating { set; get; }
        public User UserData { set; get; }
    }
}
