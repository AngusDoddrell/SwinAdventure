using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;

        public Player(string name, string desc) : base (new string[] {"me", "inventory"}, name, desc)
        {
            _inventory = new Inventory();
            _location = new Location();
        }

        public GameObject Locate(string ID)
        {
            if (AreYou(ID) == true)
            {
                return this;
            }
            return _inventory.Fetch(ID);
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public Location Location
        {
            get
            {
                return _location;
            }

            set
            {
                _location = value;
            }
        }

        public override string FullDescription
        {
            get
            {
                return "You are " + this.Name + ", " + base.FullDescription + ". You are carrying: " + Inventory.ItemList;
            }
        }

    }
}
