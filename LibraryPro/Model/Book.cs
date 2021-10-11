using System;
using System.ComponentModel;
using System.Windows.Media;

namespace LibraryPro.Model
{
    public class Book : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged_implemetation
        public event PropertyChangedEventHandler PropertyChanged; //---- default eH invoked whenever property changes
        private void OnPropertyChanged(string propertyName) //----helper method will call defaul event handler
        {
            //----if method added for this event handler, we'll invoke them
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                //----invoking methods listening to this EH
            }
        } 
        #endregion

        private int _BookId;
        private string _BookName;
        private string _PublishedYear;

        public int BookId
        {
            get { return _BookId; }
            set { _BookId = value; OnPropertyChanged("BookId"); } //----prop changes, notification EH invoked so that UI Prop could also invoke
        }

        public string BookName
        {
            get { return _BookName; }
            set { _BookName = value; OnPropertyChanged("BookName"); }
        }

        public string PublishedYear
        {
            get { return _PublishedYear; }
            set { _PublishedYear = value; OnPropertyChanged("PublishedYear"); }
        }

        public DateTime Date{ get; set; }

        public PointCollection points { get; set; } = new PointCollection();

        public string ColorName { get; set; }
    }

}
