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
        private readonly DataLoaderFactory dataLoaderFactory;
        private readonly IDataCacher dataCacher;

        public BookDataService(DataLoaderFactory dataLoaderFactory, IDataCacher dataCacher)
        {
            this.dataLoaderFactory = dataLoaderFactory;
            this.dataCacher = dataCacher;
        }

        public BookDetails GetBookDetails()
        {
            // if data in cache
            var cachedData = dataCacher.GetData();
            if (cachedData != null)
            {
                return cachedData;
            }

            // If not in cache
            var dataLoader = dataLoaderFactory.GetDataLoader();
            var bookDetails = dataLoader.Load();

            // Cache the loaded data
            dataCacher.SetData(bookDetails);

            return bookDetails;
        }
    }
}