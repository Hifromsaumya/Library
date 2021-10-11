using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data.OleDb;

using System.ComponentModel;
using LibraryPro.Model;
using LibraryPro.Commands;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows;

namespace LibraryPro.ViewModels
{
    public class LibraryVM : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged_implemetation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        LibraryService libraryService;

        /*public int currentSecond = 0;
        Random rd = new Random();
        public PointCollection LtPoint = new PointCollection();
        public Book book { get; set; } = new Book();*/

        public LibraryVM()
        {
            libraryService = new LibraryService();
            LoadData();
            ReadBook = new Book();
            addCommand = new RelayCommand(Insert);
            searchCommand = new RelayCommand(Search);
            updateCommand = new RelayCommand(Update);
            deleteCommand = new RelayCommand(Delete);

            /*DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Timertick;
            timer.Interval = TimeSpan.FromMilliseconds(2000);
            timer.Start();

            book = new Book()
            {
                points = LtPoint,
                ColorName = " Red"
            };*/
        }

        /*private void Timertick(object sender, EventArgs e)
        {
            currentSecond++;
            double x = currentSecond * 10;
            double y = rd.Next(1, 200);
            LtPoint.Add(new Point(x, y));
        }*/



        #region Read_Operation
        private ObservableCollection<Book> bookList;
        public ObservableCollection<Book> BookList
        {
            get { return bookList; }
            set { bookList = value; OnPropertyChanged("BookList"); }
        }
        private void LoadData()
        {
            BookList = new ObservableCollection<Book>(libraryService.GetAll());

        }
        #endregion

        #region Read_Values_from_Controls
        private Book readBook;
        public Book ReadBook
        {
            get { return readBook; }
            set { readBook = value; OnPropertyChanged("ReadBook"); } //Calling Book, Setter will be called and we will get notified
        }
        #endregion

        #region Message_Property
        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }
        #endregion

        #region Insert_Operation
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get { return addCommand; } //----One Way DB
        }
        //----method that will call service to add data
        public void Insert()
        {
            try
            {
                var IsInserted = libraryService.Add(ReadBook); //obj in readbook will be added
                LoadData();
                if (IsInserted)
                {
                    Message = "Data Inserted";
                }
                else
                    Message = "Uh Oh! Couldn't insert";

            }
            catch (Exception insertException)
            {
                Message = insertException.Message;
            }
        }
        #endregion

        #region Search_Operation
        private RelayCommand searchCommand;
        public RelayCommand SearchCommand
        {
            get { return searchCommand; }
        }
        public void Search()
        {
            try
            {
                var objSearchBook = libraryService.Search(readBook.BookName);
                if (objSearchBook != null)
                {
                    //----using property as it will give setter a notification, not the variable
                    ReadBook.BookId = objSearchBook.BookId;
                    ReadBook.PublishedYear = objSearchBook.PublishedYear;

                }
                else
                {
                    Message = "Apologies! This Library is small, we don't have the bookmyou searched";
                }
            }
            catch (Exception searchException)
            {
                Message = searchException.Message;
            }
        }
        #endregion

        #region Update_operation
        private RelayCommand updateCommand;
        public RelayCommand UpdateCommand
        {
            get { return updateCommand; }
        }
        public void Update()
        {
            try
            {
                var IsUpdated = libraryService.Update(ReadBook);
                if (IsUpdated)
                    Message = "Book Updated";
                else
                    Message = "Update failed";
            }
            catch (Exception updateException)
            {
                Message = updateException.Message;
            }
        }
        #endregion

        #region Delete_Operation
        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }
        }
        public void Delete()
        {
            try
            {
                var IsDeleted = libraryService.Delete(ReadBook.BookId);
                if (IsDeleted)
                    Message = "Book Deleted :(";
                else
                    Message = "Unable to Delete, guess we could just keep it a li'l longer";
            }
            catch (Exception deleteException)
            {
                Message = deleteException.Message;
            }
        }
        #endregion

    }

}

