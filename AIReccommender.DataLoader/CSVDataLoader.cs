using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIReccommender.Entities;
using System.IO;
using System.Threading;

namespace AIReccommender.DataLoader
{
    public class CSVDataLoader : IDataLoader
    {
        public BookDetails Load()
        {
            BookDetails AllDetails = new BookDetails();

            //logic to read data from CSV
            var FilePathBook = @"C:\demo\AIReccommender.UIClient\BX-CSV-Dump\BX-Books.csv";
            var FilePathUser = @"C:\demo\AIReccommender.UIClient\BX-CSV-Dump\BX-Users.csv";
            var FilePathBookRating = @"C:\demo\AIReccommender.UIClient\BX-CSV-Dump\BX-Book-Ratings.csv";

            if(File.Exists(FilePathBook))
            {
                //Reading from BX-Books.csv
                using (var reader = new StreamReader(FilePathBook))
                {
                    int count = 0;
                    while (!reader.EndOfStream)
                    {

                        var ContentLine = reader.ReadLine();
                        var columns = ContentLine.Split(';').ToList();
                        if (count == 0) { count++; continue; }
                        AllDetails.book.ISBN.Add(columns[0]);
                        AllDetails.book.BookTitle.Add(columns[1]);
                        AllDetails.book.BookAuthor.Add(columns[2]);
                        AllDetails.book.YearOfPublication.Add(int.Parse(columns[3]));
                        AllDetails.book.Publisher.Add(columns[4]);
                        AllDetails.book.ImageUrlSmall.Add(columns[5]);
                        AllDetails.book.ImageUrlMedium.Add(columns[6]);
                        AllDetails.book.ImageUrlLarge.Add(columns[7]);

                    }
                }

            }
            if (File.Exists(FilePathUser))
            {
                using (var reader = new StreamReader(FilePathUser))
                {
                    int count = 0;
                    while (!reader.EndOfStream)
                    {
                        var ContentLine = reader.ReadLine();
                        var columns = ContentLine.Split(';').ToList();
                        if (count == 0) { count++; continue; }
                        var loc = columns[1].Split(',').ToList();
                        AllDetails.UserData.UserId.Add(int.Parse(columns[0]));
                        AllDetails.UserData.City.Add(loc[0]);
                        AllDetails.UserData.State.Add(loc[1]);
                        AllDetails.UserData.Country.Add(loc[2]);
                        AllDetails.UserData.Age.Add(int.Parse(columns[2]));

                    }
                }
            }
            if(File.Exists(FilePathBookRating))
            {
                using (var reader = new StreamReader(FilePathBookRating))
                {
                    int count = 0;
                    while (!reader.EndOfStream)
                    {
                        var ContentLine = reader.ReadLine();
                        var columns = ContentLine.Split(';').ToList();
                        if (count == 0) { count++; continue; }
                        AllDetails.rating.UserID.Add(int.Parse(columns[0]));
                        AllDetails.rating.ISBN.Add(columns[1]);
                        AllDetails.rating.Rating.Add(int.Parse(columns[2]));
                    }
                }
            }


            return AllDetails;
        }
    }
}
