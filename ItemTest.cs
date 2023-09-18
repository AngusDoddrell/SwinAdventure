using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventureTests
{
    internal class ItemTest
    {
        private Item _TestableItem;

        [SetUp]
        public void Setup()
        {
            _TestableItem = new Item(new string[] {"test item"}, "ItemName", "ItemDesc");
        }

        [Test]
        public void TestItemIdent()
        {
            bool result = _TestableItem.AreYou("test item");
            Assert.IsTrue(result);
        }

        [Test]
        public void TestItemDesc()
        {
            string ShortDesc = _TestableItem.ShortDescription;
            Assert.AreEqual(ShortDesc, "ItemName (test item)");
        }

        [Test]
        public void TestFullDesc()
        {
            string FullDesc = _TestableItem.FullDescription;
            Assert.AreEqual(FullDesc, "ItemDesc");
        }

        
    }
}
