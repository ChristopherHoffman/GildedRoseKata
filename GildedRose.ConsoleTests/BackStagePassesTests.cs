using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GildedRose.Console;


namespace GildedRose.ConsoleTests
{
    [TestClass]
    public class BackStagePassesTests
    {
        public Program program;

        [TestInitialize]
        public void SetUp()
        {
            program = new Program();
        }

        public Item getPass(int sellIn, int quality)
        {
            return new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = sellIn,
                Quality = quality
            };
        }

        [TestMethod]
        public void BackstagePass_QualityIncreaseByOne_SellInDateGreaterThanTen()
        {
            int originalQuality = 20;
            int originalSellIn = 15;
            program.Items = new List<Item> { getPass(originalSellIn, originalQuality) };
            program.UpdateQuality();

            int newQuality = program.Items[0].Quality;

            Assert.AreEqual(originalQuality+1, newQuality);
        }

        [TestMethod]
        public void BackstagePass_QualityIncreaseByTwo_SellInDateBetweenTenAndSix()
        {

            int originalQuality = 20;
            int originalSellIn = 10;
            program.Items = new List<Item> { getPass(originalSellIn, originalQuality) };
            program.UpdateQuality();

            int newQuality = program.Items[0].Quality;

            Assert.AreEqual(originalQuality + 2, newQuality);
        }

        [TestMethod]
        public void BackstagePass_QualityIncreaseByTwo_SellInDateBetweenFiveAndZero()
        {

            int originalQuality = 20;
            int originalSellIn = 5;
            program.Items = new List<Item> { getPass(originalSellIn, originalQuality) };
            program.UpdateQuality();

            int newQuality = program.Items[0].Quality;

            Assert.AreEqual(originalQuality + 3, newQuality);
        }

        [TestMethod]
        public void BackstagePass_QualityShouldBeZero_WhenSellInDateNegative()
        {

            int originalQuality = 20;
            int originalSellIn = 0;
            program.Items = new List<Item> { getPass(originalSellIn, originalQuality) };
            program.UpdateQuality();

            int newQuality = program.Items[0].Quality;

            Assert.AreEqual(0, newQuality);
        }

        [TestMethod]
        public void BackstagePass_QualityCannotBeMoreThanFifty()
        {
            int originalQuality = 49;
            int originalSellIn = 10;
            program.Items = new List<Item> { getPass(originalSellIn, originalQuality) };
            program.UpdateQuality();

            int newQuality = program.Items[0].Quality;

            Assert.AreEqual(50, newQuality);

            program.UpdateQuality();
            newQuality = program.Items[0].Quality;

            Assert.AreEqual(50, newQuality);
        }
    }
}
