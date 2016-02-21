using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GildedRose.Console;

namespace GildedRose.ConsoleTests
{
    [TestClass]
    public class ConjuredTests
    {
        public Program program;

        [TestInitialize]
        public void SetUp()
        {
            program = new Program();
        }

        [TestMethod()]
        public void ConjuredItems_DegradeTwiceAsFastAsNormalItems_SellInDatePositive()
        {
            int originalQuality = 20;
            program.Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = originalQuality } };

            program.UpdateQuality();

            int newQuality = program.Items[0].Quality;

            Assert.AreEqual(originalQuality - (2* Program.NORMAL_ITEM_QUALITY_LOSS), newQuality);
        }

        [TestMethod()]
        public void ConjuredItems_DegradeTwiceAsFastAsNormalItems_SellInDateNegative()
        {
            int originalQuality = 20;
            int originalSellIn = 0;
            program.Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = originalSellIn, Quality = originalQuality } };

            program.UpdateQuality();

            int newQuality = program.Items[0].Quality;

            Assert.AreEqual(originalQuality - (4 * Program.NORMAL_ITEM_QUALITY_LOSS), newQuality);
        }

        [TestMethod()]
        public void ConjuredItems_QualityIsNeverNegative()
        {
            int originalQuality = 0;
            program.Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = originalQuality } };

            program.UpdateQuality();

            int newQuality = program.Items[0].Quality;

            Assert.AreEqual(originalQuality, newQuality);
        }
    }
}
