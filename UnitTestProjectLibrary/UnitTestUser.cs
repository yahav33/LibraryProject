using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLib;
using FluentAssertions;

namespace UnitTestProjectLibrary
{
    
    [TestClass]
    public class UnitTestUser
    {
        User user;
        [TestMethod]
        public void CheckByUserNameIndexer()
        {
           user = new User("yahav", "12345", true);
           User a = user["yahav"];
           user.username.Should().Be(a.username);  
        }
        [TestMethod]
        public void CheckIfItemAddToTheList()
        {
            user = new User("kesem", "fgfzg4", false);
            Journal journal = new Journal("thePost", 4.5, 43, Theme.Heroism, Categories.History, 5.6);
            user.RentItem(journal);
            user.GetItem("thePost").Should().Be(journal);
        }
    }
}
