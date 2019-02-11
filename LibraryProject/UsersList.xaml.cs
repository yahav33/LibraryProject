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
    /// Interaction logic for UsersList.xaml
    /// </summary>
    public partial class UsersList : Window
    {
        public UsersList()
        {// Fill the combox with all the subscribers
            InitializeComponent();
            for (int i = 0; i < BookLib.User.users.Count; i++)
            {
                BookListCombo.Items.Add(BookLib.User.users[i].username);

            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {// print the user cradit in our libary, the choosen one
            int a = BookListCombo.SelectedIndex;
            InfoTxt.Text = User.users[a].ToString();
        }
    }
}
