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
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        public AddItem()
        {//fill all the combo box with the Option's
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

            ThemeCombo.SelectedItem = Theme.GoodNEvil.ToString();
            CategoryCombo.SelectedItem = Categories.Comedy.ToString();
            BookRadio.IsChecked = true;
        }

        private void Add_ItemEvent(object sender, RoutedEventArgs e)
        {
            // run all the check's
            if (!Checks.IsNotEmptyNullOrWhite(NameTxt.Text) || !Checks.isTextDouble(EditionTxt.Text) || !Checks.isTextInt(CopiesTxt.Text) || !Checks.isTextDouble(PriceTxt.Text))
            {
                System.Windows.Forms.MessageBox.Show("Please enter valid information", "Error!");
                return;
            }
            // after that all the input are valid's we can to all the input casting
            // we check if the book allrady in our system
            if (BookRadio.IsChecked == true && LibraryManager.CheckIfBookNotExisted(NameTxt.Text))
            {
                new Book(NameTxt.Text, double.Parse(EditionTxt.Text), int.Parse(CopiesTxt.Text), (Theme)Enum.Parse(typeof(Theme), ThemeCombo.SelectedValue.ToString()),(Categories)Enum.Parse(typeof(Categories),CategoryCombo.SelectedValue.ToString()) , double.Parse(PriceTxt.Text));
                System.Windows.Forms.MessageBox.Show("Item was added!");
                this.Close();
            }
            else if(JournalRadion.IsChecked == true && LibraryManager.CheckIfBookNotExisted(NameTxt.Text)) {
                new Journal(NameTxt.Text, double.Parse(EditionTxt.Text), int.Parse(CopiesTxt.Text), (Theme)Enum.Parse(typeof(Theme), ThemeCombo.SelectedValue.ToString()), (Categories)Enum.Parse(typeof(Categories), CategoryCombo.SelectedValue.ToString()), double.Parse(PriceTxt.Text));
                System.Windows.Forms.MessageBox.Show("Item was added!");
                this.Close();
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
