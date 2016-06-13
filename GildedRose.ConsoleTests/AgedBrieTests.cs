using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GildedRose.Console;

namespace GildedRose.ConsoleTests
{
    [TestClass]
    public class AgedBrieTests
    {
        public Program program;

        [TestInitialize]
        public void SetUp()
        {
            program = new Program();
        }

        [TestMethod]
        public void AgedBrie_QualityIncreasesByOne_SellInDateIsPositive()
        {
            int originalQuality = 0;
            program.Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 0 } };

            program.UpdateQuality();

            int newQuality = program.Items[0].Quality;

            Assert.AreEqual(originalQuality + 1, newQuality);
        }

        [TestMethod]
        public void AgedBrie_QualityIncreasesByTwo_SellInDateIsZeroOrNegative()
        {
            int originalQuality = 0;
            program.Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 } };

            program.UpdateQuality();

            int newQuality = program.Items[0].Quality;

            Assert.AreEqual(originalQuality + 2, newQuality);
        }

        [TestMethod]
        public void AgedBrie_QualityCannotBeMoreThanFifty()
        {
            int originalQuality = 49;
            program.Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = originalQuality } };

            program.UpdateQuality();

            int newQuality = program.Items[0].Quality;

            Assert.AreEqual(50, newQuality);

            program.UpdateQuality();
            newQuality = program.Items[0].Quality;

            Assert.AreEqual(50, newQuality);
        }
    }
}
