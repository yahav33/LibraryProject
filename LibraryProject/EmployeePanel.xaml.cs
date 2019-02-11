using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for EmployeePanel.xaml
    /// </summary>
    public partial class EmployeePanel : Window
    {
        private LibraryManager libraryManager;
        public EmployeePanel()
        {
            libraryManager = new LibraryManager();
            InitializeComponent();
            RemoveBtn.IsEnabled = false;
        }
        // add new item
        private void AddNewItemBtr(object sender, RoutedEventArgs e)
        {
            AddItem addItemWindow = new AddItem();
            addItemWindow.Show();
        }

        private void SearchByNameBtn_Click(object sender, RoutedEventArgs e)// By name
        {
           
            if (!Checks.IsNotEmptyNullOrWhite(SearchBoxTxt.Text))
            {
                System.Windows.Forms.MessageBox.Show("You need to insert a value");
                return;
            }
            if (!libraryManager.GetObject(0, SearchBoxTxt, InfoTxt, BookTxt,RemoveBtn))
            {
                InfoTxt.Text = "";
                BookTxt.Text = "";
                System.Windows.Forms.MessageBox.Show("Cannot Find Name!", "Error");

            }
            SearchBoxTxt.Text = "";
        }
        private void SearchByISBNBtr(object sender, RoutedEventArgs e)// By ISBN 
        {
            if (!Checks.IsNotEmptyNullOrWhite(SearchBoxTxt.Text))
            {
                System.Windows.Forms.MessageBox.Show("You need to insert a value");
                return;
            }
            if (!libraryManager.GetObject(1, SearchBoxTxt, InfoTxt, BookTxt, RemoveBtn))
            {
                InfoTxt.Text = "";
                BookTxt.Text = "";
                System.Windows.Forms.MessageBox.Show("Cannot Find ISBN!", "Error");
            }
            SearchBoxTxt.Text = "";
        }
        // show all the rentel Item's in our list
        private void ShowRental_Click(object sender, RoutedEventArgs e)
        {
            string rez = BookLib.ItemCollection.GetAllRental();
            if (rez != "")
            {
                System.Windows.Forms.MessageBox.Show(rez);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No Rental Items! ");
            }
        }
        // Remove Item from the stock (all the item's - cupies).
        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BookLib.ItemCollection.abstractItems.Remove(libraryManager.getItem())) {
                InfoTxt.Text = "";
                BookTxt.Text = "";
                System.Windows.Forms.MessageBox.Show("Item was removed!");

            }
        }

        
        //show all the stock that we have
        private void ShowTotalstockBtr(object sender, RoutedEventArgs e)
        {
            BooksListStock booksListStock = new BooksListStock();
            booksListStock.Show();
        }
        // show all the subscibers to the libary
        private void AllUsersBtr(object sender, RoutedEventArgs e)
        {
            UsersList usersList = new UsersList();
            usersList.Show();
        }
        // give us option to add or remove cupies from specific Item
        private void ManageCupiesOfItemBtr(object sender, RoutedEventArgs e)
        {
            AddCopiesPanel addCopiesPanel = new AddCopiesPanel(libraryManager);
            addCopiesPanel.Show();
        }
        //give us option to ask qurey the system
        private void QueryBtr(object sender, RoutedEventArgs e)
        {
            QureyPanel qureyPanel = new QureyPanel();
            qureyPanel.Show();
        }
    }
}
