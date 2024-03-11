using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIReccommender.Entities
{
    public class BookUserRating
    {
        public int Rating { set; get; }
        public string ISBN { set; get; }
        public int UserID {  set; get; }

    }
}
