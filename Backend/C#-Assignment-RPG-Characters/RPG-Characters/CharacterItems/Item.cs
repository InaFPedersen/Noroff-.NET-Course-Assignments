using RPG_Characters.CharacterItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Characters
{
    public abstract class Item
    {
        
        //Global variables:
        public string ItemName;
        public int ItemLevelRequirement;
        public CharacterAttributes PrimaryCharacterAttribute;

        /// <summary>
        /// abstract ItemEqupmentslot, makes sure all items have a itemslot.
        /// </summary>
        public abstract ItemEquipmentSlot ItemEquipmentSlot { get; }
        

        /// <summary>
        /// This protected item method takes in the requirements for all items
        /// that they have a name, levelrequirement and which attributes it gives.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="itemLevelRequirement"></param>
        /// <param name="primaryCharacterAttribute"></param>
        protected Item(string itemName, int itemLevelRequirement, CharacterAttributes primaryCharacterAttribute)
        {
            ItemName = itemName;
            ItemLevelRequirement = itemLevelRequirement;
            PrimaryCharacterAttribute = primaryCharacterAttribute;
        }

        

        

    }
}
