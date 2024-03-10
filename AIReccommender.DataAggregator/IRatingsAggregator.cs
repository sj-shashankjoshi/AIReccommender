using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIReccommender.Entities;

namespace AIReccommender.DataAggregator
{
    public interface IRatingsAggregator
    {
        Dictionary<string,int> Aggregate(BookDetails bookDetails, Preference preference);
    }
}
