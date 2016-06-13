using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    class UpdateStrategyFactory
    {
        public static UpdateStrategyInterface Create(Item item)
        {
            if (item.Name.Contains("Sulfuras"))
            {
                return new SulfurasUpdateStrategy();
            }
            else if (item.Name.Contains("Aged Brie"))
            {
                return new AgedBrieUpdateStrategy();
            }
            else if (item.Name.Contains("Backstage pass"))
            {
                return new BackstagePassesUpdateStrategy();
            }
            else if (item.Name.Contains("Conjured"))
            {
                return new ConjuredUpdateStrategy();
            }
            else
            {
                return new StandardUpdateStrategy();
            }
        }
    }
}
