using BookLib;
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

namespace LibraryProject
{
    /// <summary>
    /// Interaction logic for AddCopiesPanel.xaml
    /// </summary>
    public partial class AddCopiesPanel : Window
    {
        //Panel that give the employee option to add or remove cupies from valid item
        private LibraryManager libraryManager;
        AbstractItem item2;
        AbstractItem item;
        public AddCopiesPanel(LibraryManager _libraryManager)
        {
            InitializeComponent();
            libraryManager = _libraryManager;
            addbt.IsEnabled = false;
            removebt.IsEnabled = false;
        }
        // add cupies
        private void Add_cupiesBtr(object sender, RoutedEventArgs e)
        {
            if (Checks.isTextInt(AmountTxt.Text))//add by yahav
            {
                item.AddCopies(int.Parse(AmountTxt.Text));

                System.Windows.Forms.MessageBox.Show("Stock Added!", "Sucess");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Number Is not Valid!!", "Eroor");
                AmountTxt.Text = "";
            }


            }
        
        private void Search_Item(object sender, RoutedEventArgs e)
        {
            //we check 2 thing's the name and the edition they qunic, and if they valid we can to the add and remove
            BookLib.ItemCollection collection = libraryManager.GetItemCollection();
            item = collection[double.Parse(EditionTxt.Text)];
            item2 = collection[NameTxtt.Text];
            if (item == item2 && item != null)
            {
                ItemNameblock.Text = "Item was Found";
                addbt.IsEnabled = true;
                removebt.IsEnabled = true;
            }

            else
            {
                ItemNameblock.Text = "Item was Not Found";
                item = null;
                item2 = null;
                EditionTxt.Text = "";
                NameTxtt.Text = "";
            }

        }

        private void Remove_cupiesBtr(object sender, RoutedEventArgs e)
        {
            if (Checks.isTextInt(AmountTxt.Text))// check the input
            {
                //here we check if the amount that we want to remove is more then the items in stock.
                // we cant remove cupies that not existent
                try
                {
                    item.ReduceCopies(int.Parse(AmountTxt.Text));
                    AmountTxt.Text = "";
                    System.Windows.Forms.MessageBox.Show("Stock Reduce!", "Sucess");
                }
                catch (Exception z)
                {
                    System.Windows.Forms.MessageBox.Show(z.Message, "Error");
                }
               
            }

            else
            {
                System.Windows.Forms.MessageBox.Show("Number Is not Valid!!", "Eroor");
                AmountTxt.Text = "";
            }


        }
    }
}
