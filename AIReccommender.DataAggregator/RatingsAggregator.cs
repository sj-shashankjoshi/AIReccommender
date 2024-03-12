using AIReccommender.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            AgeGroupChecker ageGroupfinder = new AgeGroupChecker();
            string preferenceAgeGroup = ageGroupfinder.FindAgeGroup(preference.Age);
            
            
           

            Parallel.ForEach(bookDetails.UserData, tempUser =>
            {
                if((tempUser.State==preference.State) && (preferenceAgeGroup == ageGroupfinder.FindAgeGroup(tempUser.Age)))
                {
                    preferenceUsers.Add(tempUser);
                }
            });
            Parallel.ForEach(preferenceUsers, User =>
            {
                if(User == null)
                {
                    return;
                }
                foreach (var rating in bookDetails.Rating)
                {
                    if(User.UserId == rating.UserID)
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