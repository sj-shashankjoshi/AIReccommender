using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIReccommender.Entities
{
    public class Book
    {
       
        public string BookTitle { set; get; }
        public string BookAuthor {  set; get; }
        public string ISBN {  set; get; }
        public string Publisher { set; get; }
        public string YearOfPublication { set; get; }
        public string ImageUrlSmall { set; get; }
        public string ImageUrlMedium { set; get; }
        public string ImageUrlLarge { set; get; }
    }
}
