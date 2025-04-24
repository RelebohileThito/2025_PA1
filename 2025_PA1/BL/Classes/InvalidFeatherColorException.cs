using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_PA1.BL.Classes
{
    public class InvalidFeatherColorException:Exception
    {
        public InvalidFeatherColorException() : base("Invalid feather color") { }
        public InvalidFeatherColorException(string message) : base(message) { }
    }
}
