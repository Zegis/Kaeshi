using Kaeshi.Entity;
using NUnit.Framework;
using System.Text;

namespace Kaeshi.Tests
{

    class CharacterBackpackTests
    {
        public Character chara;

        [Test]
        public void InitialCharacterHasEmptyBackpack()
        {
            chara = new Character(4, 5, 20);

            double backpackCount = chara.Backpack.Count;

            Assert.AreEqual(0, backpackCount);
        }

        [Test]
        public void CharacterCanPlaceItemsInBackpack()
        {
            chara = new Character(4, 5, 20);

            double initialBackpackCount = chara.Backpack.Count;
            Item item = new Item();

            chara.PutInBackpack(item);

            double backpackCount = chara.Backpack.Count;
            
            Assert.Greater(backpackCount, initialBackpackCount);
        }

        [Test]
        public void CharacterCanRemoveItemFromBackpack()
        {
            chara = new Character(4, 5, 20);
            Item item = new Item();
            chara.PutInBackpack(item);

            double initialBackpackCount = chara.Backpack.Count;
            chara.RemoveFromBackpack(item);
            double backpackCount = chara.Backpack.Count;

            Assert.Less(backpackCount, initialBackpackCount);
        }

        [Test]
        public void CharacterBackpackIsDisplayingProperly()
        {
            chara = new Character(4, 5, 20);
            Item item = new Item("foo", "bar");
            chara.PutInBackpack(item);

            var display = chara.DisplayBackpack();

            var expectedDisplay = new StringBuilder().AppendLine(item.Observe()).ToString();

            Assert.IsFalse(string.IsNullOrWhiteSpace(display));
            Assert.AreEqual(expectedDisplay, display);
        }

        [Test]
        public void EmptyCharacterBackpackIsDisplayingProperly()
        {
            chara = new Character(4, 5, 20);

            var display = chara.DisplayBackpack();

            Assert.AreEqual("You have no items in backpack...", display);
        }

        [Test]
        public void CharacterBackpackIsProperlyRetrievingUsableItem()
        {
            chara = new Character(4, 5, 20);
            UsableItem item = new UsableItem("foo", "bar", 4, (a) => a.Injure(2));
            chara.PutInBackpack(item);

            var itemRetrieved = chara.GetUsableItem("foo");

            Assert.IsNotNull(itemRetrieved);
            Assert.IsInstanceOf(typeof(UsableItem), itemRetrieved);            
        }

        [Test]
        public void CharacterBackpackCantRetrieveInvalidItem()
        {
            chara = new Character(4, 5, 20);

            var itemRetrieved = chara.GetUsableItem("foo");

            Assert.IsNull(itemRetrieved);
        }
    }
}
