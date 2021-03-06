using static System.Console;

namespace SchoolSharp.Utils
{
    public static class Printer
    {
        public static void DrawLine(int length = 20)
        {
            // Replace with "=" in the left side of the string each number of param length times
            WriteLine("".PadLeft(length, '='));
        }

        public static void DrawTitle(string title)
        {
            var size = title.Length + 4;
            DrawLine(size);
            WriteLine($"| {title} |");
            DrawLine(size);
        }

        public static void PressEnter()
        {
            WriteLine("Then, press ENTER to continue...");
        }
    }
}