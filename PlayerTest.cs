using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventureTests
{
    internal class PlayerTest
    {
        private Player _examplePlayer;
        private Item _exampleWeapon;
        private Item _exampleArmor;

        [SetUp]
        public void Setup()
        {
            _examplePlayer = new Player("example player", "player 1");

            _exampleWeapon = new Item(new string[] {"example weapon"}, "example sword", "This is an example weapon");

            _exampleArmor = new Item(new string[] {"example armor"}, "example chain armor", "This is an example Armor");

            _examplePlayer.Inventory.Put(_exampleArmor);
            _examplePlayer.Inventory.Put(_exampleWeapon);
        }

        [Test]
        public void TestPlayerIdent()
        {
            bool PlayerResult = _examplePlayer.AreYou("me");
            bool InventoryResult = _examplePlayer.AreYou("inventory");

            Assert.IsTrue(PlayerResult);
            Assert.IsTrue(InventoryResult);
        }

        [Test]
        public void TestPlayerLocate()
        {
            Assert.AreEqual(_examplePlayer, _examplePlayer.Locate("me"));
        }

        [Test]
        public void TestPlayerLocateItem()
        {
            Assert.AreEqual(_exampleWeapon, _examplePlayer.Locate("example weapon"));
            Assert.AreEqual(_exampleArmor, _examplePlayer.Locate("example armor"));
        }

        [Test]
        public void TestPlayerLocateNothing()
        {
            Assert.IsNull(_examplePlayer.Locate("ExampleNull"));
        }

        [Test]
        public void TestPlayerFullDesc()
        {
            string FullDesc = "You are " + _examplePlayer.Name + ". You are carrying: " + _examplePlayer.Inventory.ItemList;
            string expected = "You are example player. You are carrying: example chain armor (example armor)example sword (example weapon)";
            Assert.AreEqual(expected, FullDesc);
        }
        

    }
}
