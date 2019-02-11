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
    /// Interaction logic for QureyPanel.xaml
    /// </summary>
    public partial class QureyPanel : Window
    {
        public QureyPanel()
        {//Fill all the combox with all the info
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
            //defult
            ThemeCombo.SelectedItem = Theme.GoodNEvil.ToString();
            CategoryCombo.SelectedItem = Categories.Comedy.ToString();
            underprice.IsChecked = true;
        }

        private void Find_By_AllBtr(object sender, RoutedEventArgs e)
        {
            //use the Linq# we do Filter by all the parmeters
            if (Checks.isTextDouble(pricetext.Text))
            {
                if (underprice.IsChecked == true)
                {
                    List<AbstractItem> FindAlllist = BookLib.ItemCollection.abstractItems.Where
                   (item => item.getPrice() < double.Parse(pricetext.Text) && item.getTheme().ToString() == ThemeCombo.SelectedValue.ToString()
               && item.getcategory().ToString() == CategoryCombo.SelectedValue.ToString()).ToList();
                    if (FindAlllist.Count == 0)
                    {
                        info.Text = "No Book was Find!";
                    }
                    else info.Text = Print(FindAlllist);
                }
            else
                {
                    List<AbstractItem> FindAlllist = BookLib.ItemCollection.abstractItems.Where
                   (item => item.getPrice() > double.Parse(pricetext.Text) && item.getTheme().ToString() == ThemeCombo.SelectedValue.ToString()
               && item.getcategory().ToString() == CategoryCombo.SelectedValue.ToString()).ToList();
                    if (FindAlllist.Count == 0)
                    {
                        info.Text = "No Book was Find!";
                    }
                    else info.Text = Print(FindAlllist);
                }
               
            }

            else info.Text = "No Book Was found!!";
        }

        private void Find_By_catgoryBtr(object sender, RoutedEventArgs e)
        {//all the item that have the same catgory name
            List<AbstractItem> findCategory = BookLib.ItemCollection.abstractItems.Where
                  (item => item.getcategory() == CategoryCombo.SelectedValue.ToString()).ToList();
            if (findCategory.Count == 0)
            {
                info.Text = "No Book was Find!";
            }
            else  info.Text = Print(findCategory);
            findCategory = null;
        }
        private void Find_By_Theme(object sender, RoutedEventArgs e)
        {//all the item that have the same theme name
            List<AbstractItem> findTheme = BookLib.ItemCollection.abstractItems.Where
                 (item => item.getTheme().ToString() == ThemeCombo.SelectedValue.ToString()).ToList();
            if (findTheme.Count == 0)
            {
                info.Text = "No Book was Find!";
            }
            else  info.Text = Print(findTheme);
        }
        private void Find_by_Price(object sender, RoutedEventArgs e)
        {//all the item that under/above the price of the input
            if (Checks.isTextDouble(pricetext.Text))
            {
                if (underprice.IsChecked == true)
                {
                    List<AbstractItem> FindPrice = BookLib.ItemCollection.abstractItems.Where
                   (item => item.getPrice() < double.Parse(pricetext.Text)).ToList();
                    if (FindPrice.Count == 0)
                    {
                        info.Text = "No Book was Find!";
                    }
                    else info.Text = Print(FindPrice);
                    
                }
                else
                {
                    List<AbstractItem> FindPrice = BookLib.ItemCollection.abstractItems.Where
                   (item => item.getPrice() > double.Parse(pricetext.Text)).ToList();
                    if (FindPrice.Count == 0)
                    {
                        info.Text = "No Book was Find!";
                    }
                    else info.Text = Print(FindPrice);
                }
            }
            else info.Text = "Insert a Valid Number!";
        }
        //func that help us to print the name's of the info that we get from the list
        public static string Print(List<AbstractItem> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.AppendLine(item.Name);
            }
            return sb.ToString();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

