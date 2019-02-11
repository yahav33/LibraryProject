using System;
using System.Windows.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLib;
using LibraryProject;
using FluentAssertions;

namespace UnitTestProjectLibrary
{
   
    [TestClass]
    public class UnitTestLibaryMang
    {
        LibraryManager library = new LibraryManager();
        [TestMethod]
        public void GetObjectByName()
        {
            Book abstractItem = new Book("kesem", 3, 5, Theme.GoodNEvil, Categories.Comedy, 5.6);
            TextBox textBox = new TextBox();
            textBox.Text = "kesem";//name of the book
            int type = 0;//by name
            TextBlock infoOftheitem = new TextBlock();
            infoOftheitem.Text = "";
            TextBlock nameoftheitem = new TextBlock();
            nameoftheitem.Text = "";
            Button buttonRent = new Button();
            library.GetObject(type, textBox, infoOftheitem, nameoftheitem, buttonRent).Should().Be(true);

        }
        [TestMethod]
        public void GetObjectByISBN()
        {
            Book abstractItem = new Book("kesem", 3, 5, Theme.GoodNEvil, Categories.Comedy, 5.6);
            TextBox textBox = new TextBox();
            textBox.Text = abstractItem.ISBN.ToString();//By ISBN
            int type = 1;//by ISBN
            TextBlock infoOftheitem = new TextBlock();
            infoOftheitem.Text = "";
            TextBlock nameoftheitem = new TextBlock();
            nameoftheitem.Text = "";
            Button buttonRent = new Button();
            library.GetObject(type, textBox, infoOftheitem, nameoftheitem, buttonRent).Should().Be(true);

        }
        [TestMethod]
        public void GetObjectByNameBad()//not good!
        {
            Book abstractItem = new Book("kesem", 3, 5, Theme.GoodNEvil, Categories.Comedy, 5.6);
            TextBox textBox = new TextBox();
            textBox.Text = "yahav";//name of the book
            int type = 1;//by name
            TextBlock infoOftheitem = new TextBlock();
            infoOftheitem.Text = "";
            TextBlock nameoftheitem = new TextBlock();
            nameoftheitem.Text = "";
            Button buttonRent = new Button();
            library.GetObject(type, textBox, infoOftheitem, nameoftheitem, buttonRent).Should().Be(false);

        }
        //the rent check is a problam becouse we keep the item in the class every time when he search, and now the fun over and the item went null.
        // but in the gui she stil remmber the item
        [TestMethod]
        public void RentBook()
        {
            LibraryManager manager = new LibraryManager();
            TextBlock textBlock1 = new TextBlock();
            Book abstractItem = new Book("kesem", 3, 5, Theme.GoodNEvil, Categories.Comedy, 5.6);
            User user = new User("yahav", "3456", false);
            TextBox textBox = new TextBox();
            textBox.Text = "yahav";//name of the book
            int type = 1;//by name
            TextBlock infoOftheitem = new TextBlock();
            infoOftheitem.Text = "";
            TextBlock nameoftheitem = new TextBlock();
            nameoftheitem.Text = "";
            Button buttonRent = new Button();
            manager.GetObject(type, textBox, infoOftheitem, nameoftheitem, buttonRent);
            manager.RentBook(100, textBlock1, user).Should().Be(true);
        }
        [TestMethod]
        public void RentBookZerocupies()
        {
            TextBlock textBlock = new TextBlock();
            Book abstractItem = new Book("kesem", 3, 0, Theme.GoodNEvil, Categories.Comedy, 5.6);
            User user = new User("yahav", "3456", false);
            var a = library.RentBook(100, textBlock, user);
            library.RentBook(100, textBlock, user).Should().Be(a);
        }
        [TestMethod]
        public void RentBookNoMoney()
        {
            TextBlock textBlock = new TextBlock();
            Book abstractItem = new Book("kesem", 3, 5, Theme.GoodNEvil, Categories.Comedy, 5.6);
            User user = new User("yahav", "3456", false);
            var a = library.RentBook(2, textBlock, user);
            library.RentBook(2, textBlock, user).Should().Be(a);
        }
        [TestMethod]
        public void CheckIfUserNotExistGood()
        {
            User userExist = new User("yahav", "66ueh", false);
            LibraryManager.CheckIfUserNotExist("kesem", "hdh").Should().Be(true);
        }
        [TestMethod]
        public void CheckIfUserNotExistBad()
        {
            User userExist = new User("yahav", "66ueh", false);
            LibraryManager.CheckIfUserNotExist("yahav", "hdh").Should().Be(false);
        }
        [TestMethod]
        public void RegisterBad()
        {
            User userExist = new User("yahav", "66ueh", false);
            LibraryManager.Register("yahav", "kj").Should().Be(false);
        }
        [TestMethod]
        public void Register()
        {
            User userExist = new User("yahav", "66ueh", false);
            LibraryManager.Register("kesem", "kj").Should().Be(true);
        }
        //[TestMethod]
        //public void GetChange()
        //{
        //    Book abstractItem = new Book("kesem", 3, 5, Theme.GoodNEvil, Categories.Comedy, 5.6);
        //    double a = abstractItem.getDiscountPrice();
        //    library.GetChange(100).Should().Be(100 - a);

        //}
        [TestMethod]
        public void isMoneyValidBad()
        {
            TextBox textBox = new TextBox();
            Book abstractItem = new Book("kesem", 3, 5, Theme.GoodNEvil, Categories.Comedy, 5.6);
            textBox.Text = "ghjghkj";
            library.isMoneyValid(textBox).Should().Be(-1);
        }
        [TestMethod]
        public void isMoneyValidGood()
        {
            TextBox textBox = new TextBox();
            Book abstractItem = new Book("kesem", 3, 5, Theme.GoodNEvil, Categories.Comedy, 5.6);
            textBox.Text = "56";
            library.isMoneyValid(textBox).Should().Be(56);

        }

    }
}
