using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GildedRose.Console;


namespace GildedRose.ConsoleTests
{
    [TestClass]
    public class SulfurasTests
    {
        public Program program;
        int originalQuality = 80;
        int originalSellIn = 0;

        [TestInitialize]
        public void SetUp()
        {
            program = new Program();
            program.Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = originalSellIn, Quality = originalQuality } };
        }

        [TestMethod]
        public void Sulfuras_NotDecreaseInQuality()
        {
            program.UpdateQuality();

            int newQuality = program.Items[0].Quality;

            Assert.AreEqual(originalQuality, newQuality);
        }

        [TestMethod]
        public void Sulfuras_SellInShouldNotDecrease()
        {
            program.UpdateQuality();

            int newSellIn = program.Items[0].SellIn;

            Assert.AreEqual(originalSellIn, newSellIn);
        }
    }
}
