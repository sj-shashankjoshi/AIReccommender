using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIReccommender.Entities
{
    public class BookUserRating
    {
        public List<int> Rating { set; get; }
        public List<string> ISBN { set; get; }
        public List<long> UserID {  set; get; }

    }
}
