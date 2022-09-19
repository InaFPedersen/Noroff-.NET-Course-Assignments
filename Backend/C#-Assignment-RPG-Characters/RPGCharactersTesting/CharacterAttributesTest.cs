using RPG_Characters.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RPGCharactersTesting
{
   public class CharacterAttributesTest
    {
        #region Character Attributes on Creation
        //Attributes Character has when created

        /// <summary>
        /// Which Attributes the Mage character has when created.
        /// </summary>
        [Fact]
        public void Attributes_MageCharacterCreation_AttributesNumbers()
        {
            //Arrange
            int[] expected = { 1, 1, 8 };

            //Act
            Mage mage = new("");
            int[] actualDo = { mage.BaseAttributes.Strength, mage.BaseAttributes.Dexterity, mage.BaseAttributes.Intelligence };

            //Assert
            Assert.Equal(expected, actualDo);

        }

        /// <summary>
        /// Which Attributes the Ranger character has when created.
        /// </summary>
        [Fact]
        public void Attributes_RangerCharacterCreation_AttributesNumbers()
        {
            //Arrange
            int[] expected = { 1, 7, 1 };

            //Act
            Ranger ranger = new("");
            int[] actualDo = { ranger.BaseAttributes.Strength, ranger.BaseAttributes.Dexterity, ranger.BaseAttributes.Intelligence };

            //Assert
            Assert.Equal(expected, actualDo);

        }

        /// <summary>
        /// Which Attributes the Rogue character has when created.
        /// </summary>
        [Fact]
        public void Attributes_RogueCharacterCreation_AttributesNumbers()
        {
            //Arrange
            int[] expected = { 2, 6, 1 };

            //Act
            Rogue rogue = new("");
            int[] actualDo = { rogue.BaseAttributes.Strength, rogue.BaseAttributes.Dexterity, rogue.BaseAttributes.Intelligence };

            //Assert
            Assert.Equal(expected, actualDo);

        }

        /// <summary>
        /// Which Attributes the Warrior character has when created.
        /// </summary>
        [Fact]
        public void Attributes_WarriorCharacterCreation_AttributesNumbers()
        {
            //Arrange
            int[] expected = { 5, 2, 1 };

            //Act
            Warrior warrior = new("");
            int[] actualDo = { warrior.BaseAttributes.Strength, warrior.BaseAttributes.Dexterity, warrior.BaseAttributes.Intelligence };

            //Assert
            Assert.Equal(expected, actualDo);

        }

        #endregion

        #region Character Attributes after level up to level 2
        //Attributes after level up to level 2

        /// <summary>
        /// Attributes after leveling up a Mage character
        /// </summary>
        [Fact]
        public void Attributes_MageCharacterLevelUp_NewAttributeNumbers()
        {
            //Arrange
            int[] expected = { 2, 2, 13 };

            //Act
            Mage mage = new("");
            mage.LevelUp();
            int[] actualDo = { mage.BaseAttributes.Strength, mage.BaseAttributes.Dexterity, mage.BaseAttributes.Intelligence };

            //Assert
            Assert.Equal(expected, actualDo);
        }

        /// <summary>
        /// Attributes after leveling up a Ranger character
        /// </summary>
        [Fact]
        public void Attributes_RangerCharacterLevelUp_NewAttributeNumbers()
        {
            //Arrange
            int[] expected = { 2, 12, 2 };

            //Act
            Ranger ranger = new("");
            ranger.LevelUp();
            int[] actualDo = { ranger.BaseAttributes.Strength, ranger.BaseAttributes.Dexterity, ranger.BaseAttributes.Intelligence };

            //Assert
            Assert.Equal(expected, actualDo);
        }

        /// <summary>
        /// Attributes after leveling up a Rogue character
        /// </summary>
        [Fact]
        public void Attributes_RogueCharacterLevelUp_NewAttributeNumbers()
        {
            //Arrange
            int[] expected = { 3, 10, 2 };

            //Act
            Rogue rogue = new("");
            rogue.LevelUp();
            int[] actualDo = { rogue.BaseAttributes.Strength, rogue.BaseAttributes.Dexterity, rogue.BaseAttributes.Intelligence };

            //Assert
            Assert.Equal(expected, actualDo);
        }

        /// <summary>
        /// Attributes after leveling up a Warrior character
        /// </summary>
        [Fact]
        public void Attributes_WarriorCharacterLevelUp_NewAttributeNumbers()
        {
            //Arrange
            int[] expected = { 8, 4, 2 };

            //Act
            Warrior warrior = new("");
            warrior.LevelUp();
            int[] actualDo = { warrior.BaseAttributes.Strength, warrior.BaseAttributes.Dexterity, warrior.BaseAttributes.Intelligence };

            //Assert
            Assert.Equal(expected, actualDo);
        }
        #endregion


    }
}
