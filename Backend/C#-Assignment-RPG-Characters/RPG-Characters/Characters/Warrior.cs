using RPG_Characters.CharacterItems;
using RPG_Characters.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Characters.Characters
{
    public class Warrior: Character
    {
        /// <summary>
        /// Warrior takes in the name property, and assign BaseAttributes and LevelUpAttributes
        /// </summary>
        /// <param name="name"></param>
        public Warrior(string name) : base(name)
        {
            BaseAttributes = new CharacterAttributes(5, 2, 1);
            LevelUpAttributes = new CharacterAttributes(3, 2, 1);
        }

        /// <summary>
        /// MaincharacterAttributes returns the Warrior's main attribute(strength)
        /// </summary>
        /// <param name="mainCharacterAttribute"></param>
        /// <returns></returns>
        public override int MainCharacterAttributes(CharacterAttributes mainCharacterAttribute)
        {
            return mainCharacterAttribute.Strength;
        }

        /// <summary>
        /// ArmorFitsCharacter checks if the armor that is being equipped is mail or plate
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override bool ArmorFitsCharacter(Armor item)
        {
            return (item.ArmorType == ArmorType.Mail || item.ArmorType == ArmorType.Plate);
        }

        /// <summary>
        /// WeaponFitsCharacter checks if the weapon that is being equipped is Axe, hammer or sword.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override bool WeaponFitsCharacter(Weapons item)
        {
            return (item.WeaponType == WeaponType.Axe || item.WeaponType == WeaponType.Hammer || item.WeaponType == WeaponType.Sword);
        }
    }
}
