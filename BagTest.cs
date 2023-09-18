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

            GameObject FoundItem = _TestableBag.Locate("weapon");

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
            string FullDesc = _TestableBag.FullDescription;
            string Expected = "";
            Assert.AreEqual(Expected, FullDesc);
        }

        [Test]
        public void TestBagInBag()
        {
            _TestableBag.Inventory.Put(_SecondBag);

            _SecondBag.Inventory.Put(_Axe);

            Assert.AreEqual(_SecondBag, _TestableBag.Locate("leather bag"));

            Assert.AreEqual(_Axe, _SecondBag.Locate("axe"));

            Assert.IsNull(_TestableBag.Locate("axe"));
        }
    }
}
