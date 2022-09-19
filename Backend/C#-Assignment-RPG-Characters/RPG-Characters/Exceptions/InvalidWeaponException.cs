using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Characters.Exceptions
{
    public class InvalidWeaponException : Exception
    {
        public InvalidWeaponException(string message) : base(message) { }
    }
}
