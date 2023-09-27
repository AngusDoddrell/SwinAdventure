using SwinAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventureTests
{
    internal class LocationTest
    {
        private Item _gem;
        private Location _location;
        private Bag _TestableBag;
        private Player _TestablePlayer;
        private LookCommand _LookCommand;

        [SetUp]
        public void Setup()
        {
            _gem = new Item(new string[] { "gemstone" }, "Gemstone", "This is a Gemstone");
            _TestableBag = new Bag(new[] { "bag" }, "Default Bag", "Just a regular bag");
            _TestablePlayer = new Player("example player", "player 1");
            _location = new Location(new string[] { "example location" }, "example location", "example location");
            _LookCommand = new LookCommand();
            _TestablePlayer.Location = _location;
        }

        [Test]
        public void TestLocationIdentifyItself()
        {

        }

        //checks that the locate method works as intended, in which the gem is located directly through the item
        [Test]
        public void TestLocationLocateItem()
        {
            _location.Inventory.Put(_gem);
            GameObject locate = _location.Locate("gemstone");
            Assert.AreEqual(_gem, locate);
        }

        //checks that the player can use a locate command to locate an item
        [Test]
        public void PlayerLocateitemsInLocation()
        {
            _location.Inventory.Put(_gem);
            string[] command = { "look", "at", "gemstone", "in", "location" };
            string result = _LookCommand.Execute(_TestablePlayer, command);
            Assert.AreEqual("This is a Gemstone", result);
        }

        [Test]
        public void LocationLocatesNothing()
        {
            string[] command = { "look", "at", "pickaxe", "in", "location" };
            string result = _LookCommand.Execute(_TestablePlayer, command);
            Assert.AreEqual("Cannot find pickaxe.", result);
        }

        [Test]
        public void LocationLocatesWrongItem()
        {
            _location.Inventory.Put(_gem);
            string[] command = { "look", "at", "pickaxe", "in", "location" };
            string result = _LookCommand.Execute(_TestablePlayer, command);
            Assert.AreEqual("Cannot find pickaxe.", result);
        }

        //test that the player has a current location
        [Test]
        public void PlayerHasLocation()
        {
            string result = _TestablePlayer.Location.Name;
            Assert.AreEqual(result, "You are in example location, example location");
        }

        //test that the player can locate where they are using the look command
        [Test]
        public void PlayerLocatesLocation()
        {
            string[] command = { "look", "at", "location" };
            string result = _LookCommand.Execute(_TestablePlayer, command);
            Assert.AreEqual("You are in example location, example location", result);
        }
    }
}
