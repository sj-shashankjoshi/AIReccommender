using AIReccommender.Entities;
using AIReccommender.DataCacher;
using AIReccommender.DataLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIReccommender.UIClient
{
    public class BookDataService
    {
        private DataLoaderFactory dataLoaderFactory;
        private IDataCacher dataCacher;

        public BookDataService()
        {
            dataLoaderFactory = DataLoaderFactory.Instance;
            dataCacher = new MemDataCacher();
        }

        public BookDetails GetBookDetails()
        {
            
            var cachedData = dataCacher.GetData();
            if (cachedData != null)
            {
                return cachedData;
            }

            var dataLoader = dataLoaderFactory.GetDataLoader();
            var bookDetails = dataLoader.Load();

            dataCacher.SetData(bookDetails);

            return bookDetails;
        }
    }
}