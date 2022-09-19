using RPG_Characters.CharacterItems;
using RPG_Characters.Exceptions;
using RPG_Characters.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Characters.Characters
{
    public abstract class Character
    {
        
        //Global variables:
        public string CharacterName;
        public int CharacterLevel;

        public Dictionary<ItemEquipmentSlot, Item> Items = new();

        public CharacterAttributes BaseAttributes;

        public CharacterAttributes LevelUpAttributes;
        
        /// <summary>
        /// Character, is used to create a new character taking in the name and setting the name and level.
        /// </summary>
        /// <param name="name"></param>
        protected Character(string name)
        {
            CharacterName = name;
            CharacterLevel = 1;
        }

        /// <summary>
        /// LevelUp method, is used when the character level up one level, 
        /// setting new attributes and returning new character level
        /// </summary>
        /// <returns></returns>
        public int LevelUp()
        {
            BaseAttributes += LevelUpAttributes;
            CharacterLevel++;
            return CharacterLevel;
        }

        /// <summary>
        /// This abstract method gather the individual character classes main attribute
        /// Example: Mage = Intelligence, Ranger/Rogue = Dexterity, and Warrior = Strength
        /// </summary>
        /// <param name="mainCharacterAttribute"></param>
        /// <returns></returns>
        public abstract int MainCharacterAttributes(CharacterAttributes mainCharacterAttribute);

        /// <summary>
        /// This method calculates the total damage of the character
        /// </summary>
        /// <returns></returns>
        public double CalculateTotalDamage()
        {
            Weapons weapon = Items.ContainsKey(ItemEquipmentSlot.Weapon) ? Items[ItemEquipmentSlot.Weapon] as Weapons : null;
            double weaponDPS = 1;
            if(weapon != null)
            {
                weaponDPS = weapon.DPS;
            }
            return weaponDPS * (1 + MainCharacterAttributes(TotalCharacterAttributes()) / 100);
        }

        /// <summary>
        /// This method calculates the TotalCharacterAttributes the character has
        /// </summary>
        /// <returns></returns>
        public CharacterAttributes TotalCharacterAttributes()
        {
           CharacterAttributes output = BaseAttributes + LevelUpAttributes * (CharacterLevel - 1);
            foreach (KeyValuePair<ItemEquipmentSlot, Item> item in Items)
            {
                output += item.Value.PrimaryCharacterAttribute;
            }
            return output;
        }

        /// <summary>
        /// Attempt to equip the given piece of equipment
        /// Returns a message with the outcome!
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="InvalidArmorException"></exception>
        /// <exception cref="InvalidWeaponException"></exception>
        /// <exception cref="InvalidItemException"></exception>
        public string TryToEquipItem(Item item)
        {
            if (item == null)
            {
                throw new NullReferenceException();
            }

            ItemEquipmentSlot slot = item.ItemEquipmentSlot;
            if (item is Armor armor && slot != ItemEquipmentSlot.Weapon)
            {
                if (item.ItemLevelRequirement > CharacterLevel)
                {
                    throw new InvalidArmorException("The item level is higher than your character's level!");
                }
                if (ArmorFitsCharacter(armor))
                {
                    Items.Add(item.ItemEquipmentSlot, item);
                }
                else
                {
                    throw new InvalidArmorException("Character class " + this.GetType() + " cannon equip this type of armor" + armor.ArmorType.ToString());
                }
                return "A new armor was successfully equipped!";
            }
            if (item is Weapons weapon && slot == ItemEquipmentSlot.Weapon)
            {
                if (item.ItemLevelRequirement > CharacterLevel)
                {
                    throw new InvalidWeaponException("The item level is higher than your character's level!");
                }
                if (WeaponFitsCharacter(weapon))
                {
                    Items.Add(item.ItemEquipmentSlot, item);
                }
                else
                {
                    throw new InvalidWeaponException("Character class " + this.GetType() + " cannon equip this type of weapon" + weapon.WeaponType.ToString());
                }
                return "A new weapon was successfully equipped!";
            }
            throw new InvalidItemException("This item is not of any of the types, neither Armor nor Weapon!");
        }

        /// <summary>
        /// Checks if the armor can be equipped by this character
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected abstract bool ArmorFitsCharacter(Armor item);

        /// <summary>
        /// Checks if the weapon can be equipped by this character
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected abstract bool WeaponFitsCharacter(Weapons item);

    }
}
