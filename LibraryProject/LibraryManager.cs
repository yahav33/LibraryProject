using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLib;
using System.Windows.Controls;

namespace LibraryProject
{
    public class LibraryManager
    {
        public static BookLib.ItemCollection item;
        AbstractItem a;

        public LibraryManager()
        {
            item = new BookLib.ItemCollection();
            if (BookLib.ItemCollection.abstractItems.Count < 2)//hardcoded items.
            {
                Book book = new Book("Hey", 1, 1, Theme.GoodNEvil, Categories.Kids, 11);
                //double b = book.getDiscountPrice();
                Journal journal = new Journal("Ofri", 3, 2, Theme.Heroism, Categories.Kids, 11);
            }
        }
        public BookLib.ItemCollection GetItemCollection()
        {
            return item;
        }
        #region Search Methood
        //the search methood that check the name or the ISBN 
        public bool GetObject(int type,TextBox text,TextBlock infotext,TextBlock bookName,Button Rent) {
            if (type == 0)// 0 == search by name
            {
                a = item[text.Text];
                if (a != null)
                {
                    infotext.Text = a.ToString();
                    bookName.Text = a.Name;
                    Rent.IsEnabled = true;
                    return true;
                }
            }
            else if (type == 1) //1 == search by ISBN
            {
                Guid d;
                bool b = Guid.TryParse(text.Text, out d);
                if (b)
                {
                    a = item[d];
                    if (a != null)
                    {
                        infotext.Text = a.ToString();
                        bookName.Text = a.Name;
                        return true;
                    }
                }
                return false;
            }
            return false;
            
        }
        #endregion
        #region Rent a Book
        //rent methood, throw mesaage every step that refort waht goes wrong
        public bool RentBook(double money,TextBlock info,User user)
        {
            if (a.getCopies() <= 0)
            {
                throw new Exception("Not in stock!");
            }
            if (money == -1) {
                throw new Exception("Please enter money only!");
            }
            if (money < a.getDiscountPrice()) {
                throw new Exception("Please enter enought money!");
            }
            // if this pass all the conditions he rentable
            a.ReduceCopyAmount();//remove copy from our list
            info.Text = a.ToString();//print the current detail's
            user.RentItem(a);//add the item to list of the user
            BookLib.ItemCollection.addToRental(user,a);//add to the Dictionary that manage the rentel
            return true;
        }
        #endregion

        #region Return func
        public bool ReturnItemFromRent(User user, AbstractItem abstractItem)
        {
            bool flag = false;
            if (user.items.Count < 1)// if the list item of the user is empty
                return flag;
           //run all the 
            foreach (AbstractItem item in BookLib.ItemCollection.abstractItems)
            {
                if (item == abstractItem)//check if the item valid
                {
                    foreach (AbstractItem newItem in user.items)//check if the item in list of the user
                    {       
                            if (newItem == abstractItem)
                            {
                            user.items.Remove(newItem);//remove the item from the user list
                            BookLib.ItemCollection.removeFromRental(user, newItem);//remove from the Dictionary
                            break;
                            } 
                    }
                    item.AddCopy();//add cupies to the item after return
                    flag = true;
                }
            }
            return flag;
        }
        #endregion
        public double GetChange(double money)// get the change
        {
            double change = 0;
            change = money - a.getDiscountPrice();
            return change;
        }
        public double isMoneyValid(TextBox moneyTxt)
        {
            double money = -1;
            if (double.TryParse(moneyTxt.Text, out money)) 
                return money;
            return -1;
        }

        public static bool CheckIfBookNotExisted(string name)
        {
            var a = BookLib.ItemCollection.abstractItems.Find((b) => b.Name.ToLower() == name.ToLower());
            if (a == null)
                return true;
            return false;
        }

        //Register Account
        public static bool CheckIfUserNotExist(string name,string pass)
        {
            var a = User.users.Find((b) => b.username.ToLower() == name.ToLower());
            if (a == null)
                return true;
            return false;
        }
        // new Register make a new user
        public static bool Register(string name,string pass)
        {
            if (CheckIfUserNotExist(name,pass))
            {
                new User(name, pass);
                return true;     
            }
            return false;
        }
        //print info about the user choose
        public static string getInfo(ComboBox choise)
        {  
            return item[choise.SelectedValue.ToString()].ToString();
        }

        public AbstractItem getItem()
        {
            return a;
        }
    }
}
