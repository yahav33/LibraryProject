using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookLib;
using FluentAssertions;

namespace UnitTestProjectLibrary
{
    [TestClass]
    public class UnitTestAbs
    {
        [TestMethod]
        public void CheckPriceTest()
        {
            Book book = new Book("yahav", 9, 6, Theme.Heroism, Categories.Horror, 8.9);
            Assert.AreEqual(book.getPrice(), 8.9);
            book.getPrice().Should().Be(8.9);//new test take from nugs.
        }

        [TestMethod]
        public void AddCopiesTest()
        {
            Book book = new Book("yahav", 9, 6, Theme.Heroism, Categories.Horror, 8.9);
            book.AddCopies(10);
            book.getCopies().Should().Be(16);
        }
        [TestMethod]
        public void ReduceCopyAmountTest()
        {
            Book book = new Book("yahav", 9, 6, Theme.Heroism, Categories.Horror, 8.9);
            book.ReduceCopyAmount();
            book.getCopies().Should().Be(5);
        }

    }
}
