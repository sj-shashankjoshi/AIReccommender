using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AIReccommender.DataLoader
{
    internal class Book
    {
        public string BookTitle { set; get; }
        public string BookAuthor { set; get; }
        public long ISBN { set; get; }
        public string Publisher { set; get; }
        public int YearOfPublishing { set; get; }
        public string ImageUrlSmall { set; get; }
        public string ImageUrlMedium { set; get; }
        public string ImageUrlLarge { set; get; }
    }
}
