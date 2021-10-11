using System.Windows;
using System.Data.OleDb;
using System.Windows.Forms.Integration;

using LibraryPro.ViewModels;
using LibraryPro.Converter;
using LibraryPro.Views;
using System.Data;
using System.Windows.Forms;

namespace LibraryPro
{
    public partial class MainWindow : Window
    {
        LibraryVM viewModel;

        /*IVConverter converter;*/
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new LibraryVM();
            this.DataContext = viewModel; //---- set as data context of window // so that it is av all the elements inside window
            /*converter = new IVConverter();
            this.DataContext = converter;*/
        }

        private void btnLibrary_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new LibraryUC();
        }

        /*private void btnCharts_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Charts();
        }*/

        /*private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowsFormsHost host = new WindowsFormsHost();
            MaskedTextBox mtbDate = new MaskedTextBox("00/00/0000");
            host.Child = mtbDate;
            this.grid.Children.Add(host);
        }*/
    }
    }
