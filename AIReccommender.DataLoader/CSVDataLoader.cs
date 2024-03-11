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
                    Book bookTemp = null;
                    int count = 0;
                    while (!reader.EndOfStream)
                    {

                        var ContentLine = reader.ReadLine();
                        var columns = ContentLine.Split(';').ToList();
                        if (count == 0) { count++; continue; }
                        bookTemp = new Book();
                        bookTemp.ISBN = columns[0];
                        bookTemp.BookTitle = columns[1];
                        bookTemp.BookAuthor = columns[2];
                        bookTemp.YearOfPublication = int.Parse(columns[3]);
                        bookTemp.Publisher = columns[4];
                        bookTemp.ImageUrlSmall = columns[5];
                        bookTemp.ImageUrlMedium = columns[6];
                        bookTemp.ImageUrlLarge = columns[7];
                        AllDetails.book.Add(bookTemp);
                    }
                }

            }
            if (File.Exists(FilePathUser))
            {
                using (var reader = new StreamReader(FilePathUser))
                {
                    User UserDataTemp = null;
                    int count = 0;
                    while (!reader.EndOfStream)
                    {
                        var ContentLine = reader.ReadLine();
                        var columns = ContentLine.Split(';').ToList();
                        if (count == 0) { count++; continue; }
                        var loc = columns[1].Split(',').ToList();
                        UserDataTemp  = new User();
                        UserDataTemp.UserId = int.Parse(columns[0]);
                        UserDataTemp.City = loc[0];
                        UserDataTemp.State = loc[1];
                        UserDataTemp.Country = loc[2];
                        UserDataTemp.Age = int.Parse(columns[2]);
                        AllDetails.UserData.Add(UserDataTemp);
                    }
                }
            }
            if(File.Exists(FilePathBookRating))
            {
                using (var reader = new StreamReader(FilePathBookRating))
                {
                    BookUserRating tempRating = null;
                    int count = 0;
                    while (!reader.EndOfStream)
                    {
                        var ContentLine = reader.ReadLine();
                        var columns = ContentLine.Split(';').ToList();
                        if (count == 0) { count++; continue; }
                        tempRating = new BookUserRating();
                        tempRating.UserID=int.Parse(columns[0]);
                        tempRating.ISBN = columns[1];
                        tempRating.Rating = int.Parse(columns[2]);
                        AllDetails.rating.Add(tempRating);
                    }
                }
            }


            return AllDetails;
        }
    }
}
