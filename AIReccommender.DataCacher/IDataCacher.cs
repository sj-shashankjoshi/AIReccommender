using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIReccommender.Entities;

namespace AIReccommender.DataCacher
{
    public interface IDataCacher
    {
        BookDetails GetData();
        void SetData(BookDetails data);
    }
}
