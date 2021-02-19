using System;

namespace AlifLesson13HW18._02
{
    class Program
    {
        static Random random = new Random();

        static char MySymbols
        {
            get
            {
                int t = random.Next(10);
                if (t <= 2)

                    return (char)('0' + random.Next(10));
                else if (t <= 4)

                    return (char)('a' + random.Next(27));
                else if (t <= 6)

                    return (char)('A' + random.Next(27));
                else

                    return (char)(random.Next(32, 255));
            }
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WindowLeft = Console.WindowTop = 0;
            Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;

            Console.CursorVisible = false;

            int width, height;

            int[] y;

            Initializer(out width, out height, out y);

            while (true)
                UpdateAllColumns(width, height, y);
        }
        private static void UpdateAllColumns(int width, int height, int[] y)
        {
            int x;

            for (x = 0; x < width; ++x)
            {

                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(x, y[x]);
                Console.Write(MySymbols);


                Console.ForegroundColor = ConsoleColor.DarkGreen;
                int temp = y[x] - 2;
                Console.SetCursorPosition(x, inScreenYPosition(temp, height));
                Console.Write(MySymbols);


                int temp1 = y[x] - 20;
                Console.SetCursorPosition(x, inScreenYPosition(temp1, height));
                Console.Write(' ');


                y[x] = inScreenYPosition(y[x] + 1, height);
            }
            if (Console.KeyAvailable)
            {
                if (Console.ReadKey().Key == ConsoleKey.F5)
                    Initializer(out width, out height, out y);
                if (Console.ReadKey().Key == ConsoleKey.F11)
                    System.Threading.Thread.Sleep(1);
            }

        }
        public static int inScreenYPosition(int yPosition, int height)
        {
            if (yPosition < 0)
                return yPosition + height;
            else if (yPosition < height)
                return yPosition;
            else
                return 0;
        }
        private static void Initializer(out int width, out int height, out int[] y)
        {
            height = Console.WindowHeight;
            width = Console.WindowWidth - 1;


            y = new int[width];

            Console.Clear();

            for (int x = 0; x < width; ++x)
            {

                y[x] = random.Next(height);
            }
        }
    }
}
