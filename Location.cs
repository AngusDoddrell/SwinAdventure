using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Location : IHaveInventory
    {
        private string _name;
        private string _description;
        private Inventory _inventory;

        public Location(string[] ids, string name, string description)
        {
            _inventory = new Inventory();
            _name = name;
            _description = description;
        }

        public Location() { }

        public GameObject Locate(string id)
        {
            Item foundItem = null;

            //checks the locations inventory, if it containts the item then return it
            if (_inventory.HasItem(id))
            {
                foundItem = _inventory.Fetch(id);
            }

            //if the locations inventory does not contain the item, then return nothing
            return foundItem;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string Description
        {
            get
            {
                return $"You are in {_name}, {_description}";
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
}
