using System.Threading;
using System.Windows.Controls;
using System.Data.OleDb;

using LibraryPro.Converter;
using LibraryPro.ViewModels;

namespace LibraryPro.Views
{
    public partial class LibraryUC : UserControl
    {
        /*IVConverter converter;*/
        public LibraryUC()
        {
            InitializeComponent();
           /* converter = new IVConverter();
            this.DataContext = converter;*/
            LibraryVM lvm = new LibraryVM();
           /* myPolyline.Points = lvm.book.points;*/
        }

        #region ThreadImp
        private void threadButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            threadButton.IsEnabled = false;
            listViewButton.IsEnabled = false;

            Thread listThread = new Thread(DelayMethod);
            listThread.Start();
            /*DelayMethod();*/

            threadButton.IsEnabled = true;
            listViewButton.IsEnabled = true;
        }

        private void DelayMethod()
        {
            Thread.Sleep(9000);
        }

        private void listViewButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                listBoxNumber.Items.Add(i);
            }
        } 
        #endregion

    }
}
