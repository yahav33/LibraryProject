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
    /// Interaction logic for ReturnItem.xaml
    /// </summary>
    public partial class ReturnItem : Window
    {
        // i need to get the manger and user that choose to return the item, to ask him few thing's
        private LibraryManager libraryManager;
        private User user;
        public ReturnItem(LibraryManager _libraryManager,User _user)
        {// Fill all the option's
            InitializeComponent();
            ThemeCombo.Items.Add(Theme.GoodNEvil.ToString());
            ThemeCombo.Items.Add(Theme.Heroism.ToString());
            ThemeCombo.Items.Add(Theme.Love.ToString());
            ThemeCombo.Items.Add(Theme.SuperHeroes.ToString());
            ThemeCombo.Items.Add(Theme.Survivel.ToString());
            CategoryCombo.Items.Add(Categories.Comedy.ToString());
            CategoryCombo.Items.Add(Categories.Comics.ToString());
            CategoryCombo.Items.Add(Categories.History.ToString());
            CategoryCombo.Items.Add(Categories.Horror.ToString());
            CategoryCombo.Items.Add(Categories.Kids.ToString());
            CategoryCombo.Items.Add(Categories.Mysteries.ToString());
            //give defult parmeters to the controler's
            ThemeCombo.SelectedItem = Theme.GoodNEvil.ToString();
            CategoryCombo.SelectedItem = Categories.Comedy.ToString();
            BookRadio.IsChecked = true;
            libraryManager = _libraryManager;
            user = _user;
        }
        // return the items
        private void Return_ItemBtr(object sender, RoutedEventArgs e)
        {
            double a = double.Parse(EditionTxt.Text);
            string name = NameTxt.Text;
            BookLib.ItemCollection collection = libraryManager.GetItemCollection();
            // we compre the the name and the edition of the item to check if he valid
            AbstractItem item = collection[a];
            AbstractItem item2 = collection[name];
            // if this 2 itmes founded are the same obj so the input is valid

            if (item == item2 && item != null && item2 != null)
            {
                if (libraryManager.ReturnItemFromRent(user, item))
                {
                    //the return succes
                    System.Windows.Forms.MessageBox.Show("Book returned!", "Sucess");
                }
                else
                {
                    //the return faild
                    System.Windows.Forms.MessageBox.Show("Book was not found!", "Error");
                }

            }
            else
            {
                // input wrong!
                System.Windows.Forms.MessageBox.Show("Incorrect information!", "Error");
            }
            
        }
    }
}
