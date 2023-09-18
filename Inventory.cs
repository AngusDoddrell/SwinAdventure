using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items = new List<Item>();

        public Inventory()
        {

        }

        public bool HasItem(string ID)
        {
            foreach(Item item in _items)
            {
                if (item.AreYou(ID))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(Item item)
        {
            _items.Add(item);
        }

        public Item Take(string ID)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(ID))
                {
                    _items.Remove(item);
                    return item;
                }
            }
            return null;
        }

        public Item Fetch(string ID)
        {
            foreach (Item item in _items)
            {
                if (item.AreYou(ID))
                {
                    return item;
                }
            }
            return null;
        }

        public string ItemList
        {
            get
            {
                string ItemList = "";
                foreach (Item item in _items)
                {
                    ItemList += item.ShortDescription;
                }
                return ItemList;
            }
        }
    }
}
