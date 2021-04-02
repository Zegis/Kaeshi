using Keshi.Entity;
using NUnit.Framework;

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
    }
}
