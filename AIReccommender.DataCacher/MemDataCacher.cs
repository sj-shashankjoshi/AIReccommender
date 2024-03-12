using AIReccommender.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIReccommender.DataCacher
{
    public class MemDataCacher : IDataCacher
    {
        public BookDetails cacheData = null;
        public BookDetails GetData()
        {
            return cacheData;
        }
        public void SetData(BookDetails data)
        {
            cacheData = data;
        }
        

    }
}
