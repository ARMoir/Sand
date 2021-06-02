using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sand.Program;

namespace Sand
{
    class Obstacle
    {

        public static class Location
        {
            public static Random Random { get; set; } = new Random();
            public static int Drop { get; set; } = 20;
            public static int Check { get; set; } = 0;
        }

        public static void Create()
        {

            for (int i = 1; i < Location.Drop; i++)
            {

                Location.Check = Location.Random.Next(Display.FrameChar.Count);

                if (Display.FrameChar[Location.Check] == " "
                    && Display.FrameChar[Location.Check - 1] == " "  
                    && Display.FrameChar[Location.Check + 1] == " "
                    && Display.FrameChar[Location.Check - 2] == " "
                    && Display.FrameChar[Location.Check + 2] == " "
                    && Display.FrameChar[Location.Check - 3] == " "
                    && Display.FrameChar[Location.Check + 3] == " "
                    && Display.FrameChar[Location.Check - 4] == " "
                    && Display.FrameChar[Location.Check + 4] == " "
                    && Display.FrameChar[(Location.Check - 4) - Display.Width] == " "
                    && Display.FrameChar[(Location.Check + 4) - Display.Width] == " ")
                {
                    Display.FrameChar[Location.Check] = "═";
                    Display.FrameChar[Location.Check - 1] = "═";
                    Display.FrameChar[Location.Check + 1] = "═";
                    Display.FrameChar[Location.Check - 2] = "═";
                    Display.FrameChar[Location.Check + 2] = "═";
                    Display.FrameChar[Location.Check - 3] = "═";
                    Display.FrameChar[Location.Check + 3] = "═";
                    Display.FrameChar[Location.Check - 4] = "╚";
                    Display.FrameChar[Location.Check + 4] = "╝";
                    Display.FrameChar[(Location.Check - 4) - Display.Width] = "║";
                    Display.FrameChar[(Location.Check + 4) - Display.Width] = "║";
                }
            }
        }
    }
}
