using Sand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Sand.Program;

namespace Sand
{
    class Reset
    {
        public static void Now()
        {
            Display.FrameChar.Clear();
            Display.FrameString.Clear();
            Display.DisplayFrame.Clear();
            
            Frame.SetFrame();
            Display.FrameChar.AddRange(Display.FrameString.ToString().Select(Chars => Chars.ToString()));
            Obstacle.Create();

            Pour.Location.Drop = 0;
            Display.Offset = 0;
        }
    }
}
