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
            List<BookUserRating> preferentialRatings = new List<BookUserRating>();
            List<User> preferenceUsers = new List<User>();
            int up = 0, low = 0;
            if(preference.Age >= 1 && preference.Age <= 16) { low = 0; up = 16; }
            else if(preference.Age >= 17 && preference.Age <= 30) { low = 17; up = 30; }
            else if(preference.Age >= 31 && preference.Age <= 50) { low = 31; up = 50; }
            else if(preference.Age >= 51 && preference.Age <= 60) { low = 51; up = 60; }
            else if(preference.Age >= 60) {  up = 100; low = 61;}

            Parallel.ForEach(bookDetails.UserData, tempUser =>
            {
                if((String.Equals(tempUser.State,preference.State)) && (tempUser.Age>= low && tempUser.Age <= up))
                {
                    preferenceUsers.Add(tempUser);
                }
            });
            Parallel.ForEach(preferenceUsers, pUser => 
            {
                Parallel.ForEach(bookDetails.Rating, tempRating => 
                { 
                    if(pUser.UserId == tempRating.UserID)
                    {
                        preferentialRatings.Add(tempRating);
                    }
                });
            });
            List<int> tempRatings = null;
            Parallel.ForEach(preferentialRatings, rating =>
            {
                Parallel.ForEach(preferentialRatings, rating2 =>
                {
                    tempRatings = new List<int>();
                    if (String.Equals(rating.ISBN,rating2.ISBN))
                    {
                        tempRatings.Add(rating2.Rating);
                    }
                });
                RatingsList.Add(rating.ISBN, tempRatings);
                tempRatings.Clear();
            });

            return RatingsList;
        }
    }
}