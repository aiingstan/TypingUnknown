using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingUnknown
{
    public static class KeyPallet
    {
        public static char[] ServeKeySet(KeyRegion region)
        {
            var keys = string.Empty;
            switch (region)
            {
                case KeyRegion.TOP: keys = "`1234567890-=~!@#$%^&*()_+"; break;
                case KeyRegion.RIGHT: keys = "[]\\;',./{}|:\"<>?"; break;
                default: break;
            }
            return keys.ToCharArray();
        }
    }

    public enum KeyRegion
    {
        TOP,
        RIGHT
    }
}
