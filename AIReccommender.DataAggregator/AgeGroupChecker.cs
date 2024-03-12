using AIReccommender.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIReccommender.DataAggregator
{
    public class AgeGroupChecker
    {
        public string FindAgeGroup(int age)
        {
            if (age >= 1 && age <= 16) { return "Teen Age"; }
            else if (age >= 17 && age <= 30) { return "Young Age"; }
            else if (age >= 31 && age <= 50) { return "Mid Age"; }
            else if (age >= 51 && age <= 60) { return "Old Age"; }
            else if (age >= 60) { return "Senior Citizens"; }
            return "not applicable";
        }
    }
}
