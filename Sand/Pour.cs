using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sand
{
    class Pour
    {
        public static class Location
        {
            public static Random Random { get; set; } = new Random();
            public static int Drop { get; set; } = 0;
            public static int Check { get; set; } = 0;
        }

        public static void Grain()
        {

            for (int i = 1; i < Location.Drop; i++)
            {

                Location.Check = Location.Random.Next(300);//Program.Display.FrameChar.Count);

                if (Program.Display.FrameChar[Location.Check] == " ")
                {
                    Program.Display.FrameChar[Location.Check] = "*";
                }

            }
        }
    }
}
