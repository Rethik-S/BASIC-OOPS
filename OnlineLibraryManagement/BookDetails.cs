using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    public class BookDetails
    {

        //field
        private static int s_bookID=1000;


        //Auto property
        public string BookID { get; }//Read only property
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int BookCount { get; set; }

        //Constructor
        public BookDetails(string bookName, string authorName, int bookCount)
        {
            //Auto Incrementation
            s_bookID++;
            BookID="BID"+s_bookID;

            BookName = bookName;
            AuthorName = authorName;
            BookCount = bookCount;
        }

    }
}