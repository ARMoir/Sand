using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
            public static ConsoleColor Color { get; set; } = ConsoleColor.Yellow;
            public static int Offset { get; set; } = 0;
        }

        static void Main(string[] args)
        {
            //Pull in the Board
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.SetWindowSize(60, 40);
            }

            

            //Start Thred to Read Keypress
            Task.Factory.StartNew(() => Key.Press());

            Console.CursorVisible = false;
            Console.Clear();
            Frame.SetFrame();
            Display.FrameChar.AddRange(Display.FrameString.ToString().Select(Chars => Chars.ToString()));

            //Set the Values for Movement Calculations
            string[] Lines = Display.FrameString.ToString().Split((Char)10);
            int Width = Lines[0].Length + 1;

            //int Offset = 0;
            int Sleep = 200;

            do
            {
                Pour.Grain();
                Console.ForegroundColor = Display.Color;

                if (Sleep > 5) { Sleep--; }

                for (int i = Program.Display.FrameChar.Count -1; i >= 0; i--)
                {

                    if (Program.Display.FrameChar[i] == "*" && ((i + Width + Display.Offset) < Program.Display.FrameChar.Count))
                    {
                        if(Program.Display.FrameChar[i + (Width + Display.Offset)] == " ")
                        {
                            Program.Display.FrameChar[i] = " ";
                            Program.Display.FrameChar[i + (Width + Display.Offset)] = "*";
                        }
                        else if (Program.Display.FrameChar[i + (Width + Display.Offset) + 1] == " ")
                        {
                            Program.Display.FrameChar[i] = " ";
                            Program.Display.FrameChar[i + (Width + Display.Offset) + 1] = "*";
                        }
                        else if (Program.Display.FrameChar[i + (Width + Display.Offset) - 1] == " ")
                        {
                            Program.Display.FrameChar[i] = " ";
                            Program.Display.FrameChar[i + (Width + Display.Offset) - 1] = "*";
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
                System.Threading.Thread.Sleep(50);

            } while (true);
        }
    }
}
