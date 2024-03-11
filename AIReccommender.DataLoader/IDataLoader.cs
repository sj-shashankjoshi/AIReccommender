using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIReccommender.Entities;

namespace AIReccommender.DataLoader
{
    public interface IDataLoader
    {
        BookDetails Load();
    }
}
