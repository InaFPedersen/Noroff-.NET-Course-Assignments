using RPG_Characters.CharacterItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Characters.Items
{
    public class Armor: Item
    {
        //Armor adds attributes of a character

        //Global variables:
        public ArmorType ArmorType;

        /// <summary>
        /// overide ItemEquipmentSlot finds the slots
        /// </summary>
        public override ItemEquipmentSlot ItemEquipmentSlot { get; }

        /// <summary>
        /// Armor method, finds the itemname, itemrequirementlevel, attributebonus and which itemslot
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="itemLevelRequirement"></param>
        /// <param name="armorType"></param>
        /// <param name="AttributeBonus"></param>
        /// <param name="itemEquipmentSlot"></param>
        public Armor(string itemName, int itemLevelRequirement, ArmorType armorType, CharacterAttributes AttributeBonus, ItemEquipmentSlot itemEquipmentSlot) 
            : base(itemName, itemLevelRequirement, AttributeBonus)
        {
            ArmorType = armorType;
            this.ItemEquipmentSlot = itemEquipmentSlot;
        }
    }
}
