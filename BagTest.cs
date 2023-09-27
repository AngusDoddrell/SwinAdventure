using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventureTests
{
    internal class BagTest
    {
        private Bag _TestableBag;
        private Bag _SecondBag;
        private Item _Sword;
        private Item _Axe;

        [SetUp]
        public void Setup()
        {
            _TestableBag = new Bag(new[] { "bag" }, "Default Bag", "Just a regular bag");

            _SecondBag = new Bag(new[] { "leather bag" }, "Leather Bag", "A Leather Bag");

            _Sword = new Item(new string[] { "sword", "weapon" }, "example sword", "This is an example weapon");

            _Axe = new Item(new string[] { "axe", "weapon" }, "example axe", "This is an example weapon");
        }

        [Test]
        public void TestBagLocatesItems()
        {
            _TestableBag.Inventory.Put(_Sword);

            GameObject FoundItem = _TestableBag.Locate("sword");

            Assert.AreEqual(_Sword, FoundItem);
        }

        [Test]
        public void TestBagLocatesItself()
        {
            GameObject FoundBag = _TestableBag.Locate("bag");
            Assert.AreSame(_TestableBag, FoundBag);
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            GameObject FoundItem = _TestableBag.Locate("Nothing");
            Assert.IsNull(FoundItem);
        }

        [Test]
        public void TestBagFullDescription()
        {
            _TestableBag.Inventory.Put(_Axe);
            string FullDesc = _TestableBag.FullDescription;
            string Expected = "In the Default Bag, is a example axe (axe)";
            Assert.AreEqual(Expected, FullDesc);
        }

        [Test]
        public void TestBagInBag()
        {

            _SecondBag.Inventory.Put(_Axe);

            _TestableBag.Inventory.Put(_SecondBag);

            Assert.AreEqual(_Axe, _SecondBag.Locate("axe"));

            Assert.AreEqual(_SecondBag, _TestableBag.Locate("leather bag"));

            Assert.IsNull(_TestableBag.Locate("axe"));
        }
    }
}
