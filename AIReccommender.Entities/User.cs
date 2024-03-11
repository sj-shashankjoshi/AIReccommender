using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIReccommender.Entities
{
    public class User
    {
        public long UserId { get; set; }
        public int Age { get; set; }
        public string City {  get; set; }
        public string State { set; get; }
        public string Country { get; set; }
    }
}
