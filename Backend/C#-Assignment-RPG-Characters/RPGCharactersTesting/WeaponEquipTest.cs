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
    public class WeaponEquipTest
    {
        //Testing Item : Weapons
        
        /// <summary>
        /// Testing if the  character can equip correct weapon
        /// </summary>
        [Fact]
        public void TryToEquip_Weapon_SuccessMessage()
        {
            //Arrange
            string expectedResult = "A new weapon was successfully equipped!";
            Rogue rogueCharacterObj = new("The Stealthy Rogue");
            rogueCharacterObj.CharacterLevel = 1;
            Weapons weapon = new("Beginner Dagger", 1, 1, 1, WeaponType.Dagger, new CharacterAttributes(1, 2, 1));

            //Act
            string actualDo = rogueCharacterObj.TryToEquipItem(weapon);

            //Assert
            Assert.Equal(expectedResult, actualDo);
        }

        /// <summary>
        /// Testing if the Rogue character can equip weapon piece that is the wrong Weapon Type!
        /// </summary>
        [Fact]
        public void TryToEquip_WrongWeaponType_InvalidArmorMessage()
        {
            //Arrange
            Rogue rogueCharacterObj = new("The Stealthy Rogue");
            rogueCharacterObj.CharacterLevel = 1;
            Weapons weaponWrongType = new("Beginner Axe", 1, 1, 1, WeaponType.Axe, new CharacterAttributes(4, 2, 1));
            

            //Assert
            Assert.Throws<InvalidWeaponException>(() => rogueCharacterObj.TryToEquipItem(weaponWrongType));
        }

        /// <summary>
        /// Testing if the Rogue character can equip weapon that is higher level than the character
        /// </summary>
        [Fact]
        public void TryToEquip_WaponInWrongLevel_InvalidArmorMessage()
        {
            //Arrange
            Rogue rogueCharacterObj = new("The Stealthy Rogue");
            rogueCharacterObj.CharacterLevel = 1;
            Weapons weaponHigherLevel = new("Amazing Dagger", 41, 21, 10, WeaponType.Dagger, new CharacterAttributes(41, 21, 10));

            //Assert
            Assert.Throws<InvalidWeaponException>(() => rogueCharacterObj.TryToEquipItem(weaponHigherLevel));
        }
    }
}
