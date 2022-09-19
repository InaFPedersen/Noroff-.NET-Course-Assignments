using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Characters.Characters
{
    public static class DisplayCharacterSheet
    {
        /// <summary>
        /// CreateDisplayCharacterSheet creates a character display sheet to show the different properties of the character
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public static string CreateDisplayCharacterSheet(Character character)
        {
            StringBuilder stringBuilder = new StringBuilder();
            CharacterAttributes characterAttributes = character.TotalCharacterAttributes();
            double DPS = character.CalculateTotalDamage();
            var splitTypeByNameSpace = character.GetType().ToString().Split('.');
            string characterClass = splitTypeByNameSpace[splitTypeByNameSpace.Length -1];

            stringBuilder.Append("Name: " + character.CharacterName + '\n');
            stringBuilder.Append("Level: " + character.CharacterLevel + '\n');
            stringBuilder.Append("Class: " + characterClass + '\n');
            stringBuilder.Append("Strength: " + characterAttributes.Strength + '\n');
            stringBuilder.Append("Dexterity: " + characterAttributes.Dexterity + '\n');
            stringBuilder.Append("Intelligence: " + characterAttributes.Intelligence + '\n');
            stringBuilder.Append("characterDps: " + DPS + '\n');

            string CharacterDisplay = stringBuilder.ToString();
            return CharacterDisplay;
        }
    }
}
