using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    //Sorry Goblin, but I moved your item into a new file.
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

    public class NormalItem : Item, IItem
    {
        public void Update()
        {
            if (this.Quality > 0)
            {
                this.Quality -= 1;
            }

            this.SellIn -= 1;

            if (this.SellIn < 0)
            {
                if (this.Quality > 0)
                {
                    this.Quality -= 1;
                }
            }
        }
    }

    public class SulfurasItem : Item, IItem
    {
        public void Update()
        {
            //Do nothing, because I'm special!
        }
    }

    public class AgedBrieItem : Item, IItem
    {
        public void Update()
        {
            if (this.Quality < 50)
            {
                this.Quality = this.Quality + 1;
            }

            this.SellIn -= 1;

            if (this.SellIn < 0)
            {
                if (this.Quality < 50)
                {
                    this.Quality = this.Quality + 1;
                }
            }
        }
    }

    public class BackstagePassItem : Item, IItem
    {
        public void Update()
        {
            if (this.SellIn > 0)
            {
                if (this.Quality < 50)
                {
                    this.Quality = this.Quality + 1;
                }
            }

            if (this.SellIn < 11)
            {
                if (this.Quality < 50)
                {
                    this.Quality = this.Quality + 1;
                }
            }

            if (this.SellIn < 6)
            {
                if (this.Quality < 50)
                {
                    this.Quality = this.Quality + 1;
                }
            }

            this.SellIn -= 1;

            if (this.SellIn < 0)
            {
                this.Quality = 0;
            }
        }
    }
}
