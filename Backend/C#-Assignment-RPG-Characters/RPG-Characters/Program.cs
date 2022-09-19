using RPG_Characters.CharacterItems;
using RPG_Characters.Characters;
using RPG_Characters.Items;
using System;

namespace RPG_Characters
{
    public class Program
    {
       

        static void Main()
        {
            Character character = new Rogue("The Stealthy Rogue");
            Weapons weapon = new("Beginner Dagger", 1, 2, 1, WeaponType.Dagger, new CharacterAttributes(1, 2, 1));
            character.TryToEquipItem(weapon);
            string displayCharacterSheet = DisplayCharacterSheet.CreateDisplayCharacterSheet(character);
            Console.WriteLine(displayCharacterSheet);


            /*
            Character character = new Warrior("The Brave warrior", 5);
            Weapons weapon = new("Aged Sword", 5, 2, 1, WeaponType.Sword, new CharacterAttributes(5, 2, 1));
            character.TryToEquipItem(weapon);
            string displayCharacterSheet = DisplayCharacterSheet.CreateDisplayCharacterSheet(character);
            Console.WriteLine(displayCharacterSheet);*/
            /*
            Character character = new Mage("The Magical Mage", 1);
            Weapons weapon = new("Beginner Staff", 1, 1, 2, WeaponType.Staff, new CharacterAttributes(1, 1, 2));
            character.TryToEquipItem(weapon);
            string displayCharacterSheet = DisplayCharacterSheet.CreateDisplayCharacterSheet(character);
            Console.WriteLine(displayCharacterSheet);
            */
            /*
            Character character = new Ranger("The Magical Mage", 10);
            Weapons weapon = new("The Flower Bow", 4, 10, 2, WeaponType.Staff, new CharacterAttributes(4, 10, 2));
            character.TryToEquipItem(weapon);
            string displayCharacterSheet = DisplayCharacterSheet.CreateDisplayCharacterSheet(character);
            Console.WriteLine(displayCharacterSheet);*/

        }
    }
}
