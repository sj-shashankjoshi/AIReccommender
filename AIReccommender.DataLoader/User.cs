using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIReccommender.DataLoader
{
    internal class User
    {
        public long UserID { set; get; }
        public int Age { set; get; }
        public string City { set; get; }
        public string State { get; set; }
        public string Country { get; set; }

    }
}
