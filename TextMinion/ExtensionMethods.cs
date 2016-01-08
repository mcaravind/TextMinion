using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMinion
{
    public static class ExtensionMethods
    {
        public static char CharAt(this string input, int i)
        {
            char c = Char.MinValue;
            if (i < input.Length && i>=0)
            {
                c = input[i];
            }
            return c;
        }
    }
}
