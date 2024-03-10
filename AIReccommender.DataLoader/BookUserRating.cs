using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIReccommender.DataLoader
{
    internal class BookUserRating
    {
        public int Rating { set; get; }
        public long ISBN { set; get; }
        public long UserID { set; get; }
    }
}
