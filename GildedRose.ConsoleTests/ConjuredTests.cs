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

            Item alteredItem = program.Items[0];

            Assert.AreEqual(originalQuality - (2* Program.NORMAL_ITEM_QUALITY_LOSS), alteredItem.Quality);
        }
    }
}
