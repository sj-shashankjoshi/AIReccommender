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
using System.Collections;


namespace AIReccommender.UIClient
{
    public class AIReccommenderEngine
    {
        public IList<Book> Recommend(Preference preference, int limit)
        {
            BookDataService service = new BookDataService();
            IReccommender reccommender = new PearsonReccommender();
            IRatingsAggregator aggregator = new RatingsAggregator();
            BookDetails BookData = service.GetBookDetails();
            Dictionary<string, List<int>> BookRatings = aggregator.Aggregate(BookData, preference);
            List<double> CorelationCoefficients = new List<double>();
            List<double> UpdateCorelationCoefficients = new List<double>();
            List<int> tempBaseList = BookRatings[preference.ISBN];
            int[] baseData = tempBaseList.ToArray();
            Dictionary<double, string> ISBNCoeffs = new Dictionary<double, string>();
            double tempCoeff = 0;
            Dictionary<double, Book> BookCoeffs = new Dictionary<double, Book>();
                        
            foreach (KeyValuePair<string, List<int>> entry in BookRatings)
            {

                if (preference.ISBN == entry.Key)
                {
                    continue;
                }
                List<int> tempOtherList = BookRatings[entry.Key];
                int[] otherData = tempOtherList.ToArray();
                tempCoeff = reccommender.GetCorelation(baseData, otherData);
                CorelationCoefficients.Add(tempCoeff);
                if(ISBNCoeffs.ContainsKey(tempCoeff))
                {
                    continue;
                }
                ISBNCoeffs.Add(tempCoeff, entry.Key);
            }

            CorelationCoefficients.Sort();
            CorelationCoefficients.Reverse();
            for (int i = 0; i < limit; i++)
            {
                UpdateCorelationCoefficients.Add(CorelationCoefficients[i]);
            }
            IList<Book> ListOfBooks = new List<Book>();
            int x = 0;
            foreach (Book book in BookData.Book)
            {
                foreach(double u in UpdateCorelationCoefficients)
                {
                    if (ISBNCoeffs[u] == book.ISBN)
                    {
                        ListOfBooks.Add(BookCoeffs[CorelationCoefficients[x]]);
                        x++;
                    }
                }
            }
            
            

            return ListOfBooks;
        
        }
    }
}
