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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BookLib;

namespace LibraryProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User user;
        bool found;
        RegisterPanel registerPanel;
        public bool state = false;
        public MainWindow()
        {
            InitializeComponent();
            // users that cam with the system , a custumer and b employee
            User a = new User("Ofri", "123",false);
            User b = new User("yahav", "123", true);
           
        }
        //get the current user that we can use him and send him to the anther panel's
        public User GetUserCurrent()
        {
            return user;
        }
        // login event
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            //Pass all the info all the check's that we need
            if (!Checks.IsNotEmptyNullOrWhite(UserTxt.Text) || !Checks.IsNotEmptyNullOrWhite(PassTxt.Text)) {
                System.Windows.Forms.MessageBox.Show("Please enter account id","Error!");
                return;
            }
            // run all the users list and check if the password matching the user
            for (int i = 0; i < User.users.Count; i++)
            {
                if (User.users[i].username.ToLower() == UserTxt.Text.ToLower())
                {
                    if (User.users[i].password.ToLower() == PassTxt.Text.ToLower())
                    {
                        user = User.users[i];// bring the current user, only one every time
                        found = true;
                        break;
                    }
                   
                    
                }
                else
                {
                    found = false;
                }
            }
            if (!found)
            {
                System.Windows.Forms.MessageBox.Show("Wrong PassWord", "Error!");//change the word inside
            }
            else// we found a matching and open the Panel's according to the authorizationg
            {
                if (!user.isEmployee())
                {
                    CustomerPanel customerPanel = new CustomerPanel(user);
                    customerPanel.Show();
                }
                else
                {
                    EmployeePanel employeePanel = new EmployeePanel();
                    employeePanel.Show();
                }
                //this.Close();
            }   
        }
        //Register button check if the event allrady sing into event
        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {

            if (registerPanel == null)
            {
                registerPanel = new RegisterPanel();
                registerPanel.Closing += RegisterPanel_Closing;
            }
            
            registerPanel.Show();
        }

        private void RegisterPanel_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            registerPanel = null;
        }
    }
}
