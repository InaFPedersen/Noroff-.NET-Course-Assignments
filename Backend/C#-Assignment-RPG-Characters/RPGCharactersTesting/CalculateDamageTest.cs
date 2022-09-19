using RPG_Characters;
using RPG_Characters.CharacterItems;
using RPG_Characters.Characters;
using RPG_Characters.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RPGCharactersTesting
{
    public class CalculateDamageTest
    {
        //Names should be MethodYouTest_ScenarioTesting_ExpectedBehaviour

        #region Damage without weapon equipped
        //Damage without weapon equipped

        /// <summary>
        /// calculating Damage without weapon equipped
        /// </summary>
        [Fact]
        public void CalculateDamage_WithNoWeaponEquipped_DamageDone()
        {
            //arrange
            int expected = 1 * (1 + (5 / 100));
            Warrior warrior = new("");

            //act
            double damage = warrior.CalculateTotalDamage(); 
            
            //assert
            Assert.Equal(expected, damage);
        }

        #endregion

        #region Damage with valid weapon equipped
        //Damage with valid weapon equipped

        /// <summary>
        /// calculating Damage with valid weapon equipped
        /// </summary>
        [Fact]
        public void CalculateDamage_WithValidWeaponEquipped_DamageDone()
        {
            //arrange
            Warrior warrior = new("");
            Weapons weapon = new("Beginner Axe", 1, 7, 1.1, WeaponType.Axe, new CharacterAttributes(0, 0, 0));
            warrior.TryToEquipItem(weapon);
            
            double expected = (7 * 1.1) * (1 + (5 / 100));
            //act
            double damage = warrior.CalculateTotalDamage();
            //assert
            Assert.Equal(expected, damage);
        }

        #endregion

        #region Damage with valid weapon and armor equipped
        //Damage with valid weapon and armor equipped

        /// <summary>
        /// calculating Damage with valid weapon and armor equipped
        /// </summary>
        [Fact]
        public void CalculateDamage_WithValidWeaponAndArmorEquipped_DamageDone()
        {
            //arrange
            Warrior warrior = new("");
            Weapons weapon = new("Beginner Axe", 1, 7, 1.1, WeaponType.Axe, new CharacterAttributes(0, 0, 0));
            warrior.TryToEquipItem(weapon);
            Armor armor = new("Beginner Plate Chest", 1, ArmorType.Plate, new CharacterAttributes(1, 2, 1), ItemEquipmentSlot.Body);
            warrior.TryToEquipItem(armor);
            double expected = (7 * 1.1) * (1 + ((5 + 1) / 100));
            //act
            double damage = warrior.CalculateTotalDamage();
            //assert
            Assert.Equal(expected, damage);
        }

        #endregion
    }
}
