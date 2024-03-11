using AIReccommender.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIReccommender.DataAggregator
{
    public class RatingsAggregator : IRatingsAggregator
    {
        public Dictionary<string, List<int>> Aggregate (BookDetails bookDetails, Preference preference)
        {
            Dictionary<string, List<int>> RatingsList = new Dictionary<string, List<int>>();
            List<int> ratings = new List<int>();
            foreach (Book tempBook in bookDetails.book)
            {
                foreach (BookUserRating tempRating in bookDetails.rating)
                {
                    if(tempBook.ISBN == tempRating.ISBN)
                    {
                        foreach (User tempUser in bookDetails.UserData)
                        {
                            if(tempRating.UserID == tempUser.UserId)
                            {
                                if (preference.Age >= 1 && preference.Age <= 16)
                                {
                                    if(tempUser.Age>= 1 && tempUser.Age <= 16)
                                    {
                                        ratings.Add(tempRating.Rating);
                                    }                                    
                                }
                                if (preference.Age >= 17 && preference.Age <= 30)
                                {
                                    if (tempUser.Age >= 17 && tempUser.Age <= 30)
                                    {
                                        ratings.Add(tempRating.Rating);
                                    }
                                }
                                if (preference.Age >= 31 && preference.Age <= 50)
                                {
                                    if (tempUser.Age >= 31 && tempUser.Age <= 50)
                                    {
                                        ratings.Add(tempRating.Rating);
                                    }
                                }
                                if (preference.Age >= 51 && preference.Age <= 60)
                                {
                                    if (tempUser.Age >= 51 && tempUser.Age <= 60)
                                    {
                                        ratings.Add(tempRating.Rating);
                                    }
                                }
                                if (preference.Age >= 61 && preference.Age <= 100)
                                {
                                    if (tempUser.Age >= 61 && tempUser.Age <= 100)
                                    {
                                        ratings.Add(tempRating.Rating);
                                    }
                                }

                            }
                        }
                        
                        
                    }
                }
                RatingsList.Add(tempBook.ISBN, ratings);
                ratings.Clear();
            }      
            return RatingsList;
        }
    }
}
