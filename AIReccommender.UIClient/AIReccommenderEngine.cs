using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIReccommender.Entities;
using AIReccommender.CoreEngine;
using AIReccommender.DataAggregator;
using AIReccommender.DataLoader;
using AIReccommender.DataCacher;
using System.ComponentModel;


namespace AIReccommender.UIClient
{
    public class AIReccommenderEngine
    {
        public IList<Book> Recommend(Preference preference, int limit)
        {
            DataLoaderFactory factory = DataLoaderFactory.Instance;
            IDataCacher dataCacher = new MemDataCacher();
            BookDataService service = new BookDataService(factory, dataCacher);
            IReccommender reccommender = new PearsonReccommender();
            IRatingsAggregator aggregator = new RatingsAggregator();
            BookDetails BookData = service.GetBookDetails();
            Dictionary<string, List<int>> BookRatings = aggregator.Aggregate(BookData, preference);
            List <double> CorelationCoefficients = new List<double>();
            int[] baseData = BookRatings[preference.ISBN].ToArray();
            Dictionary<double, Book> BookCoeffs = new Dictionary<double, Book>();
            double tempCoeff = 0;
            foreach (Book book in BookData.Book)
            {
                if(preference.ISBN == book.ISBN)
                {
                    continue;
                }
                int[] otherData = BookRatings[book.ISBN].ToArray();
                tempCoeff = reccommender.GetCorelation(baseData, otherData);
                CorelationCoefficients.Add(tempCoeff);
                BookCoeffs.Add(tempCoeff, book);
            }             
            CorelationCoefficients.Sort();
            CorelationCoefficients.Reverse();
            IList <Book> ListOfBooks = new List<Book>();
            for(int i=0; i<limit; i++)
            {
                ListOfBooks.Add(BookCoeffs[CorelationCoefficients[i]]);
            }

            return ListOfBooks;
        }
    }
}
