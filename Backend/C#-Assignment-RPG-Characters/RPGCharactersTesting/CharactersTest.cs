using RPG_Characters.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RPGCharactersTesting
{
    public class CharactersTest
    {
        #region Creating new character
        //Creating characters
        /// <summary>
        /// Creation of a new Mage character
        /// </summary>
        [Fact]
        public void CreatingMageCharacter_Mage_NewCharacterName()
        {
            //Arrange
            string expectedResult = "Abe";

            //Act
            Mage mage = new ("Abe");
            string actualDo = mage.CharacterName;

            //Assert
            Assert.Equal(expectedResult, actualDo);
        }

        /// <summary>
        /// Creation of a new Ranger character
        /// </summary>
        [Fact]
        public void CreatingRangerCharacter_Ranger_NewCharacterName()
        {
            //Arrange
            string expectedResult = "Belle";

            //Act
            Ranger ranger = new("Belle");
            string actualDo = ranger.CharacterName;

            //Assert
            Assert.Equal(expectedResult, actualDo);
        }

        /// <summary>
        /// Creation of a new Rogue character
        /// </summary>
        [Fact]
        public void CreatingRangerCharacter_Rouge_NewCharacterName()
        {
            //Arrange
            string expectedResult = "Roue";

            //Act
            Rogue rogue = new("Roue");
            string actualDo = rogue.CharacterName;

            //Assert
            Assert.Equal(expectedResult, actualDo);
        }

        /// <summary>
        /// Creation of a new Warrior character
        /// </summary>
        [Fact]
        public void CreatingRangerCharacter_Warrior_NewCharacterName()
        {
            //Arrange
            string expectedResult = "Warren";

            //Act
            Warrior warrior = new("Warren");
            string actualDo = warrior.CharacterName;

            //Assert
            Assert.Equal(expectedResult, actualDo);
        }
        #endregion

        #region Level Up Character
        //Level up a character

        /// <summary>
        /// Level Up a Mage Character from level 1 to level 2
        /// </summary>
        [Fact]
        public void LevelUp_MageCharacter_IsLevelTwo()
        {
            //Arrange
            int expected = 2;

            //Act
            Mage mage = new("");
            int actualDo = mage.LevelUp();

            //Assert
            Assert.Equal(expected, actualDo);
        }

        /// <summary>
        /// Level Up a Mage Character from level 1 to level 2
        /// </summary>
        [Fact]
        public void LevelUp_RangerCharacter_IsLevelTwo()
        {
            //Arrange
            int expected = 2;

            //Act
            Ranger ranger = new("");
            int actualDo = ranger.LevelUp();

            //Assert
            Assert.Equal(expected, actualDo);
        }

        /// <summary>
        /// Level Up a Mage Character from level 1 to level 2
        /// </summary>
        [Fact]
        public void LevelUp_RogueCharacter_IsLevelTwo()
        {
            //Arrange
            int expected = 2;

            //Act
            Rogue rogue = new("");
            int actualDo = rogue.LevelUp();

            //Assert
            Assert.Equal(expected, actualDo);
        }

        /// <summary>
        /// Level Up a Mage Character from level 1 to level 2
        /// </summary>
        [Fact]
        public void LevelUp_WarriorCharacter_IsLevelTwo()
        {
            //Arrange
            int expected = 2;

            //Act
            Warrior warrior = new("");
            int actualDo = warrior.LevelUp();

            //Assert
            Assert.Equal(expected, actualDo);
        }

        #endregion

       
    }
}
