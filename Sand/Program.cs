using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Sand
{
    class Program
    {
        public static class Display
        {
            public static List<string> FrameChar { get; set; } = new List<string>();
            public static StringBuilder FrameString { get; set; } = new StringBuilder();
            public static StringBuilder DisplayFrame { get; set; } = new StringBuilder();
            public static Random Random { get; set; } = new Random();
        }

        static void Main(string[] args)
        {
            //Pull in the Board
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.SetWindowSize(60, 40);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.CursorVisible = false;
            Console.Clear();
            Frame.SetFrame();
            Display.FrameChar.AddRange(Display.FrameString.ToString().Select(Chars => Chars.ToString()));

            //Set the Values for Movement Calculations
            string[] Lines = Display.FrameString.ToString().Split((Char)10);
            int Width = Lines[0].Length + 1;

            int Offset = 0;

            do
            {
                Pour.Grain();

                for (int i = Program.Display.FrameChar.Count -1; i >= 0; i--)
                {

                    if (Program.Display.FrameChar[i] == "*" && ((i + Width + Offset) < Program.Display.FrameChar.Count))
                    {
                        if(Program.Display.FrameChar[i + (Width + Offset)] == " ")
                        {
                            Program.Display.FrameChar[i] = " ";
                            Program.Display.FrameChar[i + (Width + Offset)] = "*";
                        }
                        else if (Program.Display.FrameChar[i + (Width + Offset) + 1] == " ")
                        {
                            Program.Display.FrameChar[i] = " ";
                            Program.Display.FrameChar[i + (Width + Offset) + 1] = "*";
                        }
                        else if (Program.Display.FrameChar[i + (Width + Offset) - 1] == " ")
                        {
                            Program.Display.FrameChar[i] = " ";
                            Program.Display.FrameChar[i + (Width + Offset) - 1] = "*";
                        }
                    }

                }

                //Update Display
                Display.DisplayFrame.Clear();
                Display.FrameChar.ForEach(Item => Display.DisplayFrame.Append(Item));
                //Display.DisplayFrame.Append(System.Environment.NewLine);

                //Write Display to Console
                Console.SetCursorPosition(0, 0);
                Console.Write(Display.DisplayFrame);
                System.Threading.Thread.Sleep(100);

            } while (true);
        }
    }
}
