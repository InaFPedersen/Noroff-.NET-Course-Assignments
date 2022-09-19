using RPG_Characters;
using RPG_Characters.CharacterItems;
using RPG_Characters.Characters;
using RPG_Characters.Exceptions;
using RPG_Characters.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RPGCharactersTesting
{
    public class ArmorEquipTest
    {
        //Testing Items : Armor

        /// <summary>
        /// Testing if the Rogue character can equip armor piece
        /// </summary>
        [Fact]
        public void TryToEquip_Armor_SuccessMessage()
        {
            //Arrange
            string expectedResult = "A new armor was successfully equipped!";
            Rogue rogueCharacterObj = new("The Stealthy Rogue");
            rogueCharacterObj.CharacterLevel = 1;
            Armor armor = new("Beginner Chest", 1, ArmorType.Leather, new CharacterAttributes(1, 2, 1), ItemEquipmentSlot.Body);

            //Act
            string actualDo = rogueCharacterObj.TryToEquipItem(armor);

            //Assert
            Assert.Equal(expectedResult, actualDo);
        }

        /// <summary>
        /// Testing if the Rogue character can equip armor piece that is the wrong Armor Type!
        /// </summary>
        [Fact]
        public void TryToEquip_WrongArmorType_InvalidArmorMessage()
        {
            //Arrange
            Rogue rogueCharacterObj = new("The Stealthy Rogue");
            rogueCharacterObj.CharacterLevel = 1;
            Armor armorWrongType = new("Beginner Legs", 1, ArmorType.Cloth, new CharacterAttributes(1, 1, 2), ItemEquipmentSlot.Legs);
            
            //Assert
            Assert.Throws<InvalidArmorException>(() => rogueCharacterObj.TryToEquipItem(armorWrongType));
        }

        /// <summary>
        /// Testing if the Rogue character can equip armor piece that is higher level than the character
        /// </summary>
        [Fact]
        public void TryToEquip_ArmorInWrongLevel_InvalidArmorMessage()
        {
            //Arrange
            Rogue rogueCharacterObj = new("The Stealthy Rogue");
            rogueCharacterObj.CharacterLevel = 1;
            Armor armorHigherLevel = new("Fancy Cap", 2, ArmorType.Mail, new CharacterAttributes(1, 1, 2), ItemEquipmentSlot.Head);

            //Assert
            Assert.Throws<InvalidArmorException>(() => rogueCharacterObj.TryToEquipItem(armorHigherLevel));
        }
    }
}
