using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    class StandardUpdateStrategy : UpdateStrategyInterface
    {
        public void Update(Item item)
        {

            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }

            // Decrease SellIn Date
            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                    item.Quality = item.Quality - 1;
                }
            }
        }
    }

    class AgedBrieUpdateStrategy : UpdateStrategyInterface
    {
        public void Update(Item item)
        {

            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }
        }
    }

    class BackstagePassesUpdateStrategy : UpdateStrategyInterface
    {
        public void Update(Item item)
        {
            if (item.SellIn > 0)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }

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

            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }
    }

    public class SulfurasUpdateStrategy: UpdateStrategyInterface
    {
        public void Update(Item item)
        {
            //Do nothing, because I'm special!
        }
    }

    class ConjuredUpdateStrategy : UpdateStrategyInterface
    {
        public void Update(Item item)
        {

            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 2;
            }

            // Decrease SellIn Date
            item.SellIn -= 1;

            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                    item.Quality = item.Quality - 2;
                }
            }
        }
    }
}
