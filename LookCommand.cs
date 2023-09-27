using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(ids: new string[] {"look"} ) { }

        public override string Execute(Player p, string[] text)
        {
            if (!(text.Length == 3 || text.Length == 5))
            {
                return $"I don't know how to look like that";
            } 

            if (text[0] != "look")
            {
                return "Error with look input";
            }

            if (text[1] != "at")
            {
                return "What do you want to look at?";
            }

            if (text.Length == 5 && text[3] != "in")
            {
                return "What do you want to look in?";
            }

            if ((text.Length == 3) && text[2] == "location")
            {
                return p.Location.Description;
            }

            if (text.Length == 3)
            {
                string find = text[2];
                return LookAtIn(find, p as IHaveInventory);
            }

            if(text.Length == 5)
            {
                string find = text[2];
                string loc = text[4];
                IHaveInventory container = FetchContainer(p, loc);

                if (container == null)
                {
                    return $"Cannot find the {loc}";
                }

                return LookAtIn(find, container);
            }

            return "Success";
        }

        public IHaveInventory FetchContainer(Player p, string containerID)
        {
            if (p.AreYou(containerID))
            {
                return p;
            }

            if(containerID == "location")
            {
                return p.Location as IHaveInventory;
            }

            Item foundItem = p.Inventory.Fetch(containerID);

            if (foundItem is IHaveInventory container)
            {
                return container;
            }

            return null; // If the item is not a container, return null.
        }



        private string LookAtIn(string ThingID, IHaveInventory Container)
        {
            if (Container.Locate(ThingID) != null)
            {
                string foundDesc = Container.Locate(ThingID).FullDescription;
                return foundDesc;
            } else
            {
                return $"Cannot find {ThingID}.";
            }

        }
    }
}
