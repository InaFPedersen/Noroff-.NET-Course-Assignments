using RPG_Characters.CharacterItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Characters.Items
{
    public class Weapons: Item
    {
        //Weapons determine the damage done by the character

        //Global variables:
        public double WeaponDamage;
        public double WeaponAttacksPerSecond;
        public WeaponType WeaponType;

        /// <summary>
        /// override ItemEquipmentSlot adds the new weapon to the slot for weapons
        /// </summary>
        public override ItemEquipmentSlot ItemEquipmentSlot => ItemEquipmentSlot.Weapon;
        
        /// <summary>
        /// DPS calculates the damage done with weapon and multiplies it with weaponAttacksPerSecond
        /// </summary>
        public double DPS => WeaponDamage * WeaponAttacksPerSecond;

        /// <summary>
        /// Weapons method find/give the weapon a itemname, itemlevelRequirement, weapondamage, weaponAttacsPerSecont, Weapon type, and attributeBonus.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="itemLevelRequirement"></param>
        /// <param name="weaponDamage"></param>
        /// <param name="weaponAttacksPerSecond"></param>
        /// <param name="weaponType"></param>
        /// <param name="AttributeBonus"></param>
        public Weapons(string itemName, int itemLevelRequirement, double weaponDamage, double weaponAttacksPerSecond, WeaponType weaponType, CharacterAttributes AttributeBonus) 
            : base(itemName, itemLevelRequirement, AttributeBonus)
        {
            this.WeaponDamage = weaponDamage;
            this.WeaponAttacksPerSecond = weaponAttacksPerSecond;
            this.WeaponType = weaponType;
            this.PrimaryCharacterAttribute = AttributeBonus;
            
        }
    }
}
