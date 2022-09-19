using RPG_Characters.CharacterItems;
using RPG_Characters.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Characters.Characters
{
    public class Mage : Character
    {
        /// <summary>
        /// Mage takes in the name property, and assign BaseAttributes and LevelUpAttributes
        /// </summary>
        /// <param name="name"></param>
        public Mage(string name) : base(name)
        {
            BaseAttributes = new CharacterAttributes(1, 1, 8);
            LevelUpAttributes = new CharacterAttributes(1, 1, 5);
        }

        /// <summary>
        /// MaincharacterAttributes returns the Mage's main attribute(intelligence)
        /// </summary>
        /// <param name="mainCharacterAttribute"></param>
        /// <returns></returns>
        public override int MainCharacterAttributes(CharacterAttributes mainCharacterAttribute)
        {
            return mainCharacterAttribute.Intelligence;
        }

        /// <summary>
        /// ArmorFitsCharacter checks if the armor that is being equipped is cloth. 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override bool ArmorFitsCharacter(Armor item)
        {
            return (item.ArmorType == ArmorType.Cloth);
        }

        /// <summary>
        /// WeaponFitsCharacter checks if the weapon that is being equipped is Wand or Staff.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override bool WeaponFitsCharacter(Weapons item)
        {
            return (item.WeaponType == WeaponType.Wand || item.WeaponType == WeaponType.Staff);
        }
    }
}
