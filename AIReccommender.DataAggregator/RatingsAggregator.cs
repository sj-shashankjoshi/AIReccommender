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
            List<User> preferenceUsers = new List<User>();
            AgeGroup ageGroup = new AgeGroup();
            string preferenceAgeGroup = ageGroup.FindAgeGroup(preference.Age);
            
           

            Parallel.ForEach(bookDetails.UserData, tempUser =>
            {
                if((tempUser.State==preference.State) && (preferenceAgeGroup == ageGroup.FindAgeGroup(tempUser.Age)))
                {
                    preferenceUsers.Add(tempUser);
                }
            });
            Parallel.ForEach(preferenceUsers, pUser =>
            {
                foreach (var rating in bookDetails.Rating)
                {
                    if(pUser.UserId == rating.UserID)
                    {
                        if (!RatingsList.ContainsKey(rating.ISBN))
                        {
                            RatingsList[rating.ISBN] = new List<int>();
                        }
                        RatingsList[rating.ISBN].Add(rating.Rating);
                    }
                }
            });
           

            return RatingsList;
        }
    }
}