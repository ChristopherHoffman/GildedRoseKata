using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              Items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          }

                          };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        //public bool ItemIsSpecial(Item item)
        //{
        //    if (item.Name.Contains("Backstage") || item.Name.Contains("Aged") || item.Name.Contains("Backstage"))
        //}

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                DecreaseQuality(item);

                // Decrease SellIn Date
                DecreaseSellInDate(item);

                if (item.SellIn < 0)
                {
                    HandleNegativeSellIn(item);
                }
            }
        }

        private void HandleNegativeSellIn(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    // This sets the Backstage Pass to 0 quality after the sellIn date.
                    item.Quality = item.Quality - item.Quality;
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    break;
                default:
                    if (item.Quality > 0)
                    {
                        item.Quality = item.Quality - 1;
                    }
                    break;
            } 
        }

        private void DecreaseQuality(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                return;
            }

            if (item.Quality < 50)
            {
                if (item.Name == "Aged Brie")
                {
                    item.Quality = item.Quality + 1;
                }
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    IncreaseBackstagePassQuality(item);
                }
                else //Normal Items
                {

                    if (item.Quality > 0)
                    {
                        item.Quality = item.Quality - 1;
                    }
                }


            }
        }

        private static void IncreaseBackstagePassQuality(Item item)
        {

            item.Quality = item.Quality + 1;

            if (item.SellIn < 11)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }

            if (item.SellIn < 6)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }
        }

        private void DecreaseSellInDate(Item item)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn -= 1;
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
