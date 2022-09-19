using RPG_Characters.CharacterItems;
using RPG_Characters.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Characters.Characters
{
    public class Rogue: Character
    {
        /// <summary>
        /// Rogue takes in the name property, and assign BaseAttributes and LevelUpAttributes
        /// </summary>
        /// <param name="name"></param>
        public Rogue(string name) : base(name)
        {
            BaseAttributes = new CharacterAttributes(2, 6, 1);
            LevelUpAttributes = new CharacterAttributes(1, 4, 1);
        }

        /// <summary>
        /// MaincharacterAttributes returns the Rogue's main attribute(dexterity)
        /// </summary>
        /// <param name="mainCharacterAttribute"></param>
        /// <returns></returns>
        public override int MainCharacterAttributes(CharacterAttributes mainCharacterAttribute)
        {
            return mainCharacterAttribute.Dexterity;
        }

        /// <summary>
        /// ArmorFitsCharacter checks if the armor that is being equipped is leather or mail. 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override bool ArmorFitsCharacter(Armor item)
        {
            return (item.ArmorType == ArmorType.Leather || item.ArmorType == ArmorType.Mail);
        }

        /// <summary>
        /// WeaponFitsCharacter checks if the weapon that is being equipped is Dagger or sword.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override bool WeaponFitsCharacter(Weapons item)
        {
            return (item.WeaponType == WeaponType.Dagger || item.WeaponType == WeaponType.Sword);
        }
    }
}
