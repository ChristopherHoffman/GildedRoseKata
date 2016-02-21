using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GildedRose.Console;

namespace GildedRose.ConsoleTests
{
    [TestClass()]
    public class NormalItemTest
    {
        public Program program;

        [TestInitialize]
        public void SetUp()
        {
            program = new Program();
        }

        [TestMethod()]
        public void NormalItem_DegradeQualityByOne_ItemHasPositiveSellIn()
        {
            int originalQuality = 20;
            program.Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = originalQuality } };

            program.UpdateQuality();

            Item alteredItem = program.Items[0];

            Assert.AreEqual(originalQuality - 1, alteredItem.Quality);
        }

        [TestMethod()]
        public void NormalItem_DegradeSellInByOne_ItemHasPositiveSellIn()
        {
            int originalSellIn = 10;
            program.Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = originalSellIn, Quality = 20 } };

            program.UpdateQuality();

            Item alteredItem = program.Items[0];

            Assert.AreEqual(originalSellIn - 1, alteredItem.SellIn);
        }

        [TestMethod()]
        public void NormalItem_QualityDegradesTwiceAsFast_SellInDateNegative()
        {
            int originalQuality = 20;
            program.Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = originalQuality } };

            program.UpdateQuality();

            Item alteredItem = program.Items[0];

            Assert.AreEqual(originalQuality - 2, alteredItem.Quality);
        }

        [TestMethod()]
        public void NormalItem_QualityIsNeverNegative()
        {
            int originalQuality = 0;
            program.Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = originalQuality } };

            program.UpdateQuality();

            Item alteredItem = program.Items[0];

            Assert.AreEqual(originalQuality, alteredItem.Quality);
        }

    }
}
