using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Characters
{
    /// <summary>
    /// CharacterAttributes defines the three different attributes
    /// </summary>
    public struct CharacterAttributes
    {
        public int Strength;
        public int Dexterity;
        public int Intelligence;

        /// <summary>
        /// Set the characterAttributes to strength, dexterity and intelligence
        /// </summary>
        /// <param name="strength"></param>
        /// <param name="dexterity"></param>
        /// <param name="intelligence"></param>
        public CharacterAttributes(int strength, int dexterity, int intelligence)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }

        /// <summary>
        /// CharacterAttributes operator +, Is a add operator that adds baseAttributes with bonusAttributes.
        /// </summary>
        /// <param name="baseAtt"></param>
        /// <param name="bonusAtt"></param>
        /// <returns></returns>
        public static CharacterAttributes operator +(CharacterAttributes baseAtt, CharacterAttributes bonusAtt)
        {
            return new CharacterAttributes(baseAtt.Strength + bonusAtt.Strength, baseAtt.Dexterity + bonusAtt.Dexterity, baseAtt.Intelligence + bonusAtt.Intelligence);
        }

        /// <summary>
        /// CharacterAttributes operator *, Is a multiply operator that multiply baseAttribute with bonusAttributes
        /// </summary>
        /// <param name="baseAtt"></param>
        /// <param name="bonusAtt"></param>
        /// <returns></returns>
        public static CharacterAttributes operator *(CharacterAttributes baseAtt, int bonusAtt)
        {
            return new CharacterAttributes(baseAtt.Strength * bonusAtt, baseAtt.Dexterity * bonusAtt, baseAtt.Intelligence * bonusAtt);
        }
    }
}
