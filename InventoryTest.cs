using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventureTests
{
    internal class InventoryTest
    {
        private Inventory _TestableInventory;
        private Item _TestItem;

        [SetUp]
        public void Setup()
        {
            _TestableInventory = new Inventory();
            _TestItem = new Item(new string[] {"test"}, "testshortdesc", "testfulldesc");
        }

        [Test]
        public void TestFindItem()
        {
            _TestableInventory.Put(_TestItem);
            Assert.IsTrue(_TestableInventory.HasItem("test"));
        }

        [Test]
        public void TestNoFindItem()
        {
            _TestableInventory.Put(_TestItem);
            bool result = (_TestableInventory.HasItem("WrongTest"));
            Assert.IsFalse(result);
        }

        [Test]
        public void TestFetchItem()
        {
            _TestableInventory.Put(_TestItem);
            Item ReturnedItem = _TestableInventory.Fetch("Test");
            Assert.AreEqual(ReturnedItem, _TestItem);
            bool Result = _TestableInventory.HasItem("Test");
            Assert.IsTrue(Result);
        }

        [Test]
        public void TestTakeItem()
        {
            _TestableInventory.Put(_TestItem);
            Item ReturnedItem = _TestableInventory.Take("Test");
            Assert.AreEqual(ReturnedItem, _TestItem);
            bool Result = _TestableInventory.HasItem("Test");
            Assert.IsFalse(Result);
        }

        [Test]
        public void TestItemList()
        {
            String[] identsOne = { "ExampleWeapon", "ExampleSword" };
            Item ExampleWeapon = new Item(identsOne, "ExampleWeaponOne", "This is an example weapon");

            String[] identsTwo = { "ExampleArmor", "ExampleArmor" };
            Item ExampleArmor = new Item(identsTwo, "ExampleArmorOne", "This is an example Armor");

            _TestableInventory.Put(ExampleWeapon);
            _TestableInventory.Put(ExampleArmor);

            string List = "a ExampleWeaponOne (ExampleWeapon)" + ", a ExampleArmorOne (ExampleArmor)";

            string Actual = _TestableInventory.ItemList;

            Assert.AreEqual(List, Actual);
        }
    }
}
