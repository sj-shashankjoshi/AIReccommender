using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIReccommender.Entities
{
    public class Book
    {
        public List<string> BookTitle { set; get; }
        public List<string> BookAuthor {  set; get; }
        public List<string> ISBN {  set; get; }
        public List<string> Publisher { set; get; }
        public List<int> YearOfPublication { set; get; }
        public List<string> ImageUrlSmall { set; get; }
        public List<string> ImageUrlMedium { set; get; }
        public List<string> ImageUrlLarge { set; get; }
    }
}
