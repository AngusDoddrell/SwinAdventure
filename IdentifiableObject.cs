using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        //create a private list field named _identifier 
        private List<string> _identifier = new();

        //call the constructor for IdentifiableObjects, creating an instance in the heap
        public IdentifiableObject(string[] idents)
        {
            _identifier.AddRange(idents);
        }

        public bool AreYou(string id)
        {
            return _identifier.Contains(id.ToLower());
        }

        //Create the property FirstID
        public string FirstID
        {
            get
            {
                //search firstID for the inputted string, if it is null then return an empty string
                if (_identifier == null || _identifier.Count == 0)
                {
                    return string.Empty;
                } else
                {
                    //if the string is not null, then return the first entry in the identifiers array
                    return _identifier[0];
                }

            }
        }

        public void AddIdentifier(string id)
        {

            //used to add the identifier to the list, converts the passed in ID to lowercase then adds it
            id = id.ToLower();
            _identifier.Add(id);
        }
    }
}
