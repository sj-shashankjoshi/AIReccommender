using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIReccommender.Entities
{
    public class User
    {
        public List<long> UserId { get; set; }
        public List<int> Age { get; set; }
        public List<string> City {  get; set; }
        public List<string> State { set; get; }
        public List<string> Country { get; set; }
    }
}
