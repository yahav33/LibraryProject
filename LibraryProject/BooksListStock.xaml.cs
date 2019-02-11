using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BookLib;

namespace LibraryProject
{
    /// <summary>
    /// Interaction logic for BooksListStock.xaml
    /// </summary>
    public partial class BooksListStock : Window
    {
        //Fill all combobox with the list of the item's
        public BooksListStock()
        {
            InitializeComponent();
            for (int i = 0; i < BookLib.ItemCollection.abstractItems.Count; i++)
            {
                BookListCombo.Items.Add(BookLib.ItemCollection.abstractItems[i].Name);

            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // print the user the detail's of the item that he choose
            InfoTxt.Text = LibraryManager.getInfo(BookListCombo);
        }
    }
}
