using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinAdventure;

namespace SwinAdventureTests
{
    public class LookCommandTest
    {
        private Item _gem;
        private Bag _TestableBag;
        private Player _TestablePlayer;
        private LookCommand _LookCommand;

        [SetUp]
        public void Setup()
        {
            _gem = new Item(new string[] { "gemstone" }, "Gemstone", "This is a Gemstone");
            _TestableBag = new Bag(new[] { "bag" }, "Default Bag", "Just a regular bag");
            _TestablePlayer = new Player("example player", "player 1");
            _LookCommand = new LookCommand();
        }

        [Test]
        public void TestLookAtMe()
        {
            _TestablePlayer.Inventory.Put(_gem);
            string Desc = _LookCommand.Execute(_TestablePlayer, new string[] { "look", "at", "inventory" });
            Assert.AreEqual("You are example player, player 1. You are carrying: a Gemstone (gemstone)", Desc);
        }

        [Test]
        public void TestLookAtGem()
        {
            _TestablePlayer.Inventory.Put(_gem);
            string Desc = _LookCommand.Execute(_TestablePlayer, new string[] { "look", "at", "gemstone"});
            Assert.AreEqual("This is a Gemstone", Desc);
        }

        [Test]
        public void TestLookAtUnk()
        {
            string Desc = _LookCommand.Execute(_TestablePlayer, new string[] { "look", "at", "gemstone", "in", "inventory" });
            Assert.AreEqual("Cannot find gemstone.", Desc);
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            _TestablePlayer.Inventory.Put(_gem);
            string Desc = _LookCommand.Execute(_TestablePlayer, new string[] { "look", "at", "gemstone", "in", "inventory" });
            Assert.AreEqual("This is a Gemstone", Desc);
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            _TestableBag.Inventory.Put(_gem);
            _TestablePlayer.Inventory.Put(_TestableBag);
            string Desc = _LookCommand.Execute(_TestablePlayer, new string[] { "look", "at", "gemstone", "in", "bag" });
            Assert.AreEqual("This is a Gemstone", Desc);
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            _TestablePlayer.Inventory.Put(_TestableBag);
            string Desc = _LookCommand.Execute(_TestablePlayer, new string[] { "look", "at", "gemstone", "in", "bag" });
            Assert.AreEqual("Cannot find gemstone.", Desc);
        }

        [Test]
        public void TestInvalidLook()
        {
            string InvalidLengthBelow = _LookCommand.Execute(_TestablePlayer, new string[] {"look" });

            string InvalidLengthAbove = _LookCommand.Execute(_TestablePlayer, new string[] { "look", "at", "gemstone", "in", "the", "bag" });

            string InvalidLook = _LookCommand.Execute(_TestablePlayer, new string[] { "search", "for", "gemstone"});

            string WhatToLookAt = _LookCommand.Execute(_TestablePlayer, new string[] {"look", "for", "gemstone"});

            string WhatToLookIn = _LookCommand.Execute(_TestablePlayer, new string[] { "look", "at", "gemstone", "at", "bag" });

            Assert.AreEqual(InvalidLengthBelow, "I don't know how to look like that");

            Assert.AreEqual(InvalidLengthAbove, "I don't know how to look like that");

            Assert.AreEqual(InvalidLook, "Error with look input");

            Assert.AreEqual(WhatToLookAt, "What do you want to look at?");

            Assert.AreEqual(WhatToLookIn, "What do you want to look in?");
        }

    }
}
