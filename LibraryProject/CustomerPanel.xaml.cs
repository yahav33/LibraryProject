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
    /// Interaction logic for CustomerPanel.xaml
    /// </summary>
    public partial class CustomerPanel : Window
    {
        private LibraryManager libraryManager;
        private User user;
        public CustomerPanel(User _user)// get the current user from the login window
        {
            libraryManager = new LibraryManager();
            InitializeComponent();
            RentBtn.IsEnabled = false;
            user = _user;
        }
        // 2 methood's to search the book, name or ISBN
        private void SearchByNameBtn_Click(object sender, RoutedEventArgs e)//by name
        {
            
            if (!Checks.IsNotEmptyNullOrWhite(SearchBoxTxt.Text))
            {
                System.Windows.Forms.MessageBox.Show("You need to insert a value");
                return;
            }
            // if the input is good, we check if the item valid
            // the type tell me to search the name, 0 = SearchByName;
            if (!libraryManager.GetObject(0,SearchBoxTxt, InfoTxt, BookTxt,RentBtn))
            {
                InfoTxt.Text = "";
                BookTxt.Text = "";
                 System.Windows.Forms.MessageBox.Show("Cannot Find Name!", "Error");
                


            }
            SearchBoxTxt.Text = "";
        }

        private void SearchByISBNBtn_Click(object sender, RoutedEventArgs e)//by ISBN
        {
           
            if (!Checks.IsNotEmptyNullOrWhite(SearchBoxTxt.Text))
            {
                System.Windows.Forms.MessageBox.Show("You need to insert a value");
                return;
            }
            // if the input is good, we check if the item valid
            // the type tell me to search the name, 1 = SearchByISBNB;
            if (!libraryManager.GetObject(1, SearchBoxTxt, InfoTxt, BookTxt, RentBtn))
            {
                InfoTxt.Text = "";
                BookTxt.Text = "";
                System.Windows.Forms.MessageBox.Show("Cannot Find ISBN!", "Error");
     
            }
            SearchBoxTxt.Text = "";
        }
        // Rent option
        private void RentBtn_Click(object sender, RoutedEventArgs e)
        {
            // we dont want the system fall if the rent dont Successful
            // so we catch the exception and print the string that we get from the eroor.
            try
            {
                double money = libraryManager.isMoneyValid(MoneyTxt);
                libraryManager.RentBook(money, InfoTxt,user);
                Change.Text = libraryManager.GetChange(money).ToString("00.00");
                MoneyTxt.Text = "";

                System.Windows.Forms.MessageBox.Show("Rent Successful");
            }
            catch (Exception a)
            {
                //every step we gonna get the right Message from the excption
                InfoTxt.Text = a.Message;
            }
            
        }
        // show the list of item's
        private void Available_itemsBtr(object sender, RoutedEventArgs e)
        {
            BooksListStock booksListStock = new BooksListStock();
            booksListStock.Show();
        }
        //show the item's that in the user list.
        private void My_Itemsbtr(object sender, RoutedEventArgs e)
        {
            InfoTxt.Text = user.ToString();
            BookTxt.Text = "";
        }
        //show window that you can return the item's
        private void ReturnBookbtr_Click(object sender, RoutedEventArgs e)
        {
            ReturnItem returnItem = new ReturnItem(libraryManager,user);
            returnItem.Show();
        }
    }
}
