using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    static class ItemFactory
    {
        public static IItem GetItem(Item basicItem)
        {
            if (basicItem.Name.Contains("Sulfuras"))
            {
                return new SulfurasItem { Name = basicItem.Name, Quality = basicItem.Quality, SellIn = basicItem.SellIn };
            }
            else if (basicItem.Name.Contains("Aged Brie"))
            {
                return new AgedBrieItem { Name = basicItem.Name, Quality = basicItem.Quality, SellIn = basicItem.SellIn };
            }
            else if (basicItem.Name.Contains("Backstage pass"))
            {
                return new BackstagePassItem { Name = basicItem.Name, Quality = basicItem.Quality, SellIn = basicItem.SellIn };
            }
            else
            {
                return new NormalItem { Name = basicItem.Name, Quality = basicItem.Quality, SellIn = basicItem.SellIn };
            }
        }
    }


}
