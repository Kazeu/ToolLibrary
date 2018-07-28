using System;
using System.Collections.Generic;

namespace ToolLibrary
{
    public class Misc
    {
        public static void PrtDashLine(int num)
        {
            for (int i = 0; i <= num; ++i)
            {
                Console.Write("-");
            }
        }
    }
}
