public class TicBrdGame
{
    private static bool isValidPlay;
    private static string rowLine;
    private static int row;
    private static string columnLine;
    private static int column;

    public static void Main()
    {
        TicBrd t = TicBrd.MakeNew;
        t.Initialize();

        Console.WriteLine(t);

        while (true)
        {
            do
            {
                isValidPlay = false;
                try
                {
                    GetRowColForX();

                    t.X(row, column);
                    isValidPlay = true;
                }
                catch
                {
                    Console.WriteLine("This spot has already been played on. Try another spot!");
                }
            } while (!isValidPlay);

            Console.WriteLine(t);

            // if the win number == 2
            if (t.WinNumber == 2)
            {
                // Write to the console that x wins
                Console.WriteLine("X wins!");
                return;
            }
            // if the win number == 3
            else if (t.WinNumber == 3)
            {
                // Write to the console that x wins
                Console.WriteLine("O wins!");
                return;
            }
            // if the win number == 1
            else if (t.WinNumber == 1)
            {
                // Write to the console that it is a draw
                Console.WriteLine("Draw!");
                return;
            }

            isValidPlay = false;
            do
            {
                try
                {
                    GetRowColForO(t);
                }
                catch
                {
                    // no op
                }

            } while (!isValidPlay);


            Console.WriteLine(t);

            if (t.WinNumber == 2)
            {
                Console.WriteLine("X wins!");
                return;
            }
            else if (t.WinNumber == 3)
            {
                Console.WriteLine("O wins!");
                return;
            }
            else if (t.WinNumber == 1)
            {
                Console.WriteLine("Draw!");
                return;
            }
        }
    }

    private static void GetRowColForO(TicBrd t)
    {
        Console.WriteLine("Play O");

        Console.WriteLine("Row:");
        rowLine = Console.ReadLine();
        row = int.Parse(rowLine);

        Console.WriteLine("Column:");
        columnLine = Console.ReadLine();
        column = int.Parse(columnLine);

        t.O(row, column);
        isValidPlay = true;
    }

    private static void GetRowColForX()
    {
        Console.WriteLine("Play X");

        Console.WriteLine("Row:");
        rowLine = Console.ReadLine();
        row = int.Parse(rowLine);

        Console.WriteLine("Column:");
        columnLine = Console.ReadLine();
        column = int.Parse(columnLine);
    }
}

