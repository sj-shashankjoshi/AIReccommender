using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIReccommender.Entities;
using AIReccommender.CoreEngine;
using AIReccommender.DataAggregator;
using AIReccommender.DataLoader;
using System.ComponentModel;


namespace AIReccommender.UIClient
{
    public class AIReccommenderEngine
    {
        public static IList<Book> Recommend(Preference preference, int limit)
        {
            IDataLoader dataLoader = new CSVDataLoader();
            IReccommender reccommender = new PearsonReccommender();
            IRatingsAggregator aggregator = new RatingsAggregator();
            BookDetails BookData = dataLoader.Load();
            Dictionary<string, List<int>> BookRatings = aggregator.Aggregate(BookData, preference);
            int[] bleh = new int[3];
            List <double> CorelationCoefficients = new List<double>();
            int[] baseData = BookRatings[preference.ISBN].ToArray();
            Dictionary<double, Book> BookCoeffs = new Dictionary<double, Book>();
            double tempCoeff = 0;
            foreach (Book book in BookData.book)
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
