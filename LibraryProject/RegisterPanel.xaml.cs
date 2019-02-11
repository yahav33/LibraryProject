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
    /// Interaction logic for RegisterPanel.xaml
    /// </summary>
    public partial class RegisterPanel : Window
    {
        public RegisterPanel()
        {
            InitializeComponent();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!Checks.IsNotEmptyNullOrWhite(UserTxt.Text) || !Checks.IsNotEmptyNullOrWhite(PassTxt.Text))
            {
                System.Windows.Forms.MessageBox.Show("Please enter account id", "Error!");
                return;
            }
            if (!LibraryManager.Register(UserTxt.Text, PassTxt.Text))
                System.Windows.Forms.MessageBox.Show("User already exist","Erro!");
            else
            {
                System.Windows.Forms.MessageBox.Show("Account was added succesfully!","Account added!");
                this.Close();
            }
        }
    }
}
