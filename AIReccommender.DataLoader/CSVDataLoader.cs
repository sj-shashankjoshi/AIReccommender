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

            if (File.Exists(FilePathBook) && File.Exists(FilePathUser) && File.Exists(FilePathBookRating))
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
                        bookTemp.ISBN = columns[0].Trim('"');
                        bookTemp.BookTitle = columns[1].Trim('"');
                        bookTemp.BookAuthor = columns[2].Trim('"');
                        bookTemp.YearOfPublication = columns[3].Trim('"');
                        bookTemp.Publisher = columns[4].Trim('"');
                        bookTemp.ImageUrlSmall = columns[5].Trim('"');    
                        bookTemp.ImageUrlMedium = columns[6].Trim('"');
                        bookTemp.ImageUrlLarge = columns[7].Trim('"');
                        AllDetails.Book.Add(bookTemp);
                    }
                }
                using (var reader1 = new StreamReader(FilePathUser))
                {
                    User UserDataTemp = null;
                    int count = 0;
                    while (!reader1.EndOfStream)
                    {
                        try
                        {
                            var ContentLine = reader1.ReadLine();
                            var columns = ContentLine.Split(';').ToList();
                            if (count == 0) { count++; continue; }
                            var loc = columns[1].Split(',').ToList();
                            UserDataTemp = new User();
                            string a = columns[0].Trim('"');
                            UserDataTemp.UserId = int.Parse(a);
                            UserDataTemp.City = loc[0].Trim(' ');
                            UserDataTemp.State = loc[1].Trim(' ');
                            UserDataTemp.Country = loc[2].Trim(' ');
                            string temp = columns[2].Trim('"');
                            if (temp == "NULL")
                            {
                                UserDataTemp.Age = 1;
                            }
                            else
                            {
                                UserDataTemp.Age = int.Parse(temp);
                            }
                            AllDetails.UserData.Add(UserDataTemp);
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }

                    }
                }
                using (var reader3 = new StreamReader(FilePathBookRating))
                {
                    BookUserRating tempRating = null;
                    int count = 0;
                    while (!reader3.EndOfStream)
                    {
                        try
                        {
                            var ContentLine = reader3.ReadLine();
                            var columns = ContentLine.Split(';').ToList();
                            if (count == 0) { count++; continue; }
                            tempRating = new BookUserRating();
                            string b = columns[0].Trim('"');
                            tempRating.UserID = int.Parse(b);
                            tempRating.ISBN = columns[1].Trim('"');
                            string a = columns[2].Trim('"');
                            tempRating.Rating = int.Parse(a);
                            AllDetails.Rating.Add(tempRating);
                        }
                        catch (Exception eq)
                        {
                            continue;
                        }

                    }
                }

            }
                      

            return AllDetails;
        }
    }
}
