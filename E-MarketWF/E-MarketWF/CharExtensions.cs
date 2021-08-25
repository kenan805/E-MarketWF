using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MarketWF
{
    static class CharExtension
    {
        public static bool IsComma(this char chr)
        {
            if (chr == ',')
                return true;
            return false;
        }
    }
}
