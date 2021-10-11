using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LibraryPro.Model
{
    public class LibraryService
    {
        private static List<Book> objBooksList;

        public LibraryService()
        {
            objBooksList = new List<Book>()
            {
                new Book{BookId = 1, BookName = "The back of the Napkin", PublishedYear= "1998" },
                new Book{BookId = 2, BookName = "Into the Wild", PublishedYear= "1994" },
                new Book{BookId = 3, BookName = "The boy in stripped Pajamas", PublishedYear= "1950" },
            };
        }

        #region GetAll_Method
        public List<Book> GetAll()
        {
            return objBooksList.ToList();
        }
        #endregion

        #region Add_Method
        public bool Add(Book newBook)
        {
            if (newBook != null)
            {
                objBooksList.Add(newBook);
            }
            return true;
        }
        #endregion

        #region Update_Method
        public bool Update(Book updateBook)
        {
            bool IsUpdated = false;
            for (int i = 0; i < objBooksList.Count; i++)
            {
                if (objBooksList[i].BookName == updateBook.BookName)
                {
                    objBooksList[i].BookId = updateBook.BookId;
                    objBooksList[i].PublishedYear = updateBook.PublishedYear;
                    IsUpdated = true;
                    break;
                }
            }
            return IsUpdated;
        }
        #endregion

        #region Delete_Method
        public bool Delete(int bookId)
        {
            bool isDeleted = false;
            for (int i = 0; i < objBooksList.Count; i++)
            {
                if (objBooksList[i].BookId == bookId)
                {
                    objBooksList.RemoveAt(i);
                    isDeleted = true;
                    break;
                }
            }
            return isDeleted;
        }
        #endregion

        #region Search_Method
        public Book Search(string bookName)
        {
            return objBooksList.FirstOrDefault(e => e.BookName == bookName);
        } 
        #endregion
    }
}
