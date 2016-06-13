using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GildedRose.Console;

namespace GildedRose.ConsoleTests
{
    [TestClass()]
    public class ConjuredItemTest
    {
        public Program program;

        [TestInitialize]
        public void SetUp()
        {
            program = new Program();
        }

        [TestMethod()]
        public void ConjuredItem_DegradeQualityByOne_ItemHasPositiveSellIn()
        {
            int originalQuality = 20;
            program.Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = originalQuality } };

            program.UpdateQuality();

            Item alteredItem = program.Items[0];

            Assert.AreEqual(originalQuality - 2, alteredItem.Quality);
        }

        [TestMethod()]
        public void ConjuredItem_DegradeSellInByOne_ItemHasPositiveSellIn()
        {
            int originalSellIn = 10;
            program.Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = originalSellIn, Quality = 20 } };

            program.UpdateQuality();

            Item alteredItem = program.Items[0];

            Assert.AreEqual(originalSellIn - 1, alteredItem.SellIn);
        }

        [TestMethod()]
        public void ConjuredItem_QualityDegradesTwiceAsFast_SellInDateNegative()
        {
            int originalQuality = 20;
            program.Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = originalQuality } };

            program.UpdateQuality();

            Item alteredItem = program.Items[0];

            Assert.AreEqual(originalQuality - 4, alteredItem.Quality);
        }

        [TestMethod()]
        public void ConjuredItem_QualityIsNeverNegative()
        {
            int originalQuality = 0;
            program.Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = originalQuality } };

            program.UpdateQuality();

            Item alteredItem = program.Items[0];

            Assert.AreEqual(originalQuality, alteredItem.Quality);
        }

    }
}