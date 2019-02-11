using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLib;
using FluentAssertions;

namespace UnitTestProjectLibrary
{
    [TestClass]
    public class UnitTestItemCollection
    {
        ItemCollection itemCollection = new ItemCollection();
        [TestMethod]
        public void AddToLibraryCurrect()
        {
            Journal journal = new Journal("thePost", 9.6, 43, Theme.Survivel, Categories.Kids, 4);
            Book book = new Book("kesem", 9, 5, Theme.Heroism, Categories.Horror, 8.9);
            User user = new User("ofri", "12334", true);
            ItemCollection.AddToLibrary(journal).Should().Be(true);
            ItemCollection.AddToLibrary(book).Should().Be(true);
        }
        [TestMethod]
        public void AddToLibraryNull()
        {
            ItemCollection.AddToLibrary(null).Should().Be(false);
        }
        [TestMethod]
        public void CheckTheNameIndexer()
        {
            Book book = new Book("kesem", 9, 5, Theme.Heroism, Categories.Horror, 8.9);
            AbstractItem a = itemCollection["kesem"];
            book.Name.Should().Be(a.Name);
        }
        [TestMethod]
        public void CheckTheISBNIndexer()
        {
            Book book = new Book("yahav", 9, 5, Theme.Heroism, Categories.Horror, 8.9);
            AbstractItem a = itemCollection["yahav"];
            book.ISBN.Should().Be(a.ISBN);
        }
        [TestMethod]
        public void addToRental()//ned to add this func()
        {

        }
    }
}
