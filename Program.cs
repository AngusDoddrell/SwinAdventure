﻿using System.Runtime.CompilerServices;

namespace SwinAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //initialise the name and description fields to store the users username and description
            string _name;
            string _description;

            //Get the players name and description from the user
            Console.WriteLine("Please enter your username:");
            _name = Console.ReadLine();
            Console.WriteLine("Please enter your players description:");
            _description = Console.ReadLine();

            //create the player
            Player _player = new Player(_name, _description);

            //Create two items - a starter sword and a starter pickaxe
            Item _starterSword = new Item(new string[] { "weapon", "sword", "melee" }, "Starter Sword", "A Starter Weapon to use against regular enemies");
            Item _starterPickaxe = new Item(new string[] { "tool", "pickaxe", "harvesting", "melee" }, "Starter Pickaxe", "A Starter Pickaxe for extracting resources");

            //Create a bag - a starter bag for the new player
            Bag _starterBag = new Bag(new string[] { "bag" }, "Starter Bag", "A starter bag to hold a few items");

            //Create one more item to add to the players bag - a mysterious key
            Item _starterKey = new Item(new string[] { "key", "collectible" }, "Mysterious Key", "A mysterious key found in your starter bag");

            //add all the items to the necessary inventories
            _player.Inventory.Put(_starterSword);
            _player.Inventory.Put(_starterPickaxe);

            _starterBag.Inventory.Put(_starterKey);
            _player.Inventory.Put(_starterBag);

            //confirm the players inventory
            Console.WriteLine(_player.FullDescription);

            //confirm the contents of the starter bag
            Console.WriteLine(_starterBag.FullDescription);

            //Loop reading commands and execute them
            bool _exit = false;
            LookCommand _lookCommand = new LookCommand();

            while (_exit == false)
            {
                string _input = Console.ReadLine();
                _input = _input.ToLower();
                string[] _command = _input.Split(" ");
                if (_command[0] == "exit")
                {
                    _exit = true;
                }
                if (_command[0] == "look") ;
                {
                   string _result = _lookCommand.Execute(_player, _command);
                   Console.WriteLine( _result );
                }
            }
        }
    }
}