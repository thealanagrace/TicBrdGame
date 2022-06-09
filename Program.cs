using System.Collections.Immutable;
using System.Linq;

namespace Interview
{
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

    public class TicBrd
    {
        private string[,] _spaces;

        public static TicBrd MakeNew
        {
            get
            {
                return new TicBrd();
            }
        }

        public void Initialize()
        {
            _spaces = new string[3, 3];
        }

        public void X(int row, int col)
        {
            if (_spaces[row, col] != null)
            {
                throw new System.InvalidOperationException("Player has already played in this spot");
            }
            _spaces[row, col] = "X";
        }

        public void O(int row, int col)
        {
            if (_spaces[row, col] != null)
            {
                throw new System.InvalidOperationException("Player has already played in this spot");
            }
            _spaces[row, col] = "O";
        }

        public int? WinNumber
        {
            get
            {
                #region X

                #region Rows
                if (_spaces[0, 0] == "X")
                {
                    if (_spaces[0, 1] == "X")
                    {
                        if (_spaces[0, 2] == "X")
                        {
                            return 2;
                        }
                    }
                }

                if (_spaces[1, 0] == "X")
                {
                    if (_spaces[1, 1] == "X")
                    {
                        if (_spaces[1, 2] == "X")
                        {
                            return 2;
                        }
                    }
                }

                if (_spaces[2, 0] == "X")
                {
                    if (_spaces[2, 1] == "X")
                    {
                        if (_spaces[2, 2] == "X")
                        {
                            return 2;
                        }
                    }
                }
                #endregion

                #region Cols

                if (_spaces[0, 0] == "X")
                {
                    if (_spaces[1, 0] == "X")
                    {
                        if (_spaces[2, 0] == "X")
                        {
                            return 2;
                        }
                    }
                }

                if (_spaces[0, 1] == "X")
                {
                    if (_spaces[1, 1] == "X")
                    {
                        if (_spaces[2, 1] == "X")
                        {
                            return 2;
                        }
                    }
                }

                if (_spaces[0, 2] == "X")
                {
                    if (_spaces[1, 2] == "X")
                    {
                        if (_spaces[2, 2] == "X")
                        {
                            return 2;
                        }
                    }
                }


                #endregion

                #region Diags

                if (_spaces[0, 0] == "X")
                {
                    if (_spaces[1, 1] == "X")
                    {
                        if (_spaces[2, 2] == "X")
                        {
                            return 2;
                        }
                    }
                }

                if (_spaces[0, 2] == "X")
                {
                    if (_spaces[1, 1] == "X")
                    {
                        if (_spaces[2, 0] == "X")
                        {
                            return 2;
                        }
                    }
                }

                #endregion

                #endregion

                #region O

                #region Rows
                if (_spaces[0, 0] == "O")
                {
                    if (_spaces[0, 1] == "O")
                    {
                        if (_spaces[0, 2] == "O")
                        {
                            return 3;
                        }
                    }
                }

                if (_spaces[1, 0] == "O")
                {
                    if (_spaces[1, 1] == "O")
                    {
                        if (_spaces[1, 2] == "O")
                        {
                            return 3;
                        }
                    }
                }

                if (_spaces[2, 0] == "O")
                {
                    if (_spaces[2, 1] == "O")
                    {
                        if (_spaces[2, 2] == "O")
                        {
                            return 3;
                        }
                    }
                }
                #endregion

                #region Cols

                if (_spaces[0, 0] == "O")
                {
                    if (_spaces[1, 0] == "O")
                    {
                        if (_spaces[2, 0] == "O")
                        {
                            return 3;
                        }
                    }
                }

                if (_spaces[0, 1] == "O")
                {
                    if (_spaces[1, 1] == "O")
                    {
                        if (_spaces[2, 1] == "O")
                        {
                            return 3;
                        }
                    }
                }

                if (_spaces[0, 2] == "O")
                {
                    if (_spaces[1, 2] == "O")
                    {
                        if (_spaces[2, 2] == "O")
                        {
                            return 3;
                        }
                    }
                }


                #endregion

                #region Diags

                if (_spaces[0, 0] == "O")
                {
                    if (_spaces[1, 1] == "O")
                    {
                        if (_spaces[2, 2] == "O")
                        {
                            return 3;
                        }
                    }
                }

                if (_spaces[0, 2] == "O")
                {
                    if (_spaces[1, 1] == "O")
                    {
                        if (_spaces[2, 0] == "O")
                        {
                            return 3;
                        }
                    }
                }

                #endregion

                #endregion

                else if (_spaces.Cast<string>().Any(spaceState => spaceState == null))
                {
                    return null;
                }
                else
                {
                    return 1;
                }

                //Should never get here!
                return null;
            }
        }

        public override string ToString() =>
            $@"{_spaces[0, 0] ?? " "}|{_spaces[0, 1] ?? " "}|{_spaces[0, 2] ?? " "}
{_spaces[1, 0] ?? " "}|{_spaces[1, 1] ?? " "}|{_spaces[1, 2] ?? " "}
{_spaces[2, 0] ?? " "}|{_spaces[2, 1] ?? " "}|{_spaces[2, 2] ?? " "}";
    }

    #region Candidate, please ignore this section!
    public static class Console
    {
        private class SimulatedGameInputQueue
        {
            private readonly ImmutableQueue<int> _inputQueue;

            private SimulatedGameInputQueue(ImmutableQueue<int> inputQueue) => _inputQueue = inputQueue;

            public static SimulatedGameInputQueue Empty => new SimulatedGameInputQueue(ImmutableQueue<int>.Empty);

            public SimulatedGameInputQueue Play(int row, int col) => new SimulatedGameInputQueue(_inputQueue.Enqueue(row).Enqueue(col));

            public SimulatedGameInputQueue GetNextInput(out int input) => new SimulatedGameInputQueue(_inputQueue.Dequeue(out input));
        }

        private static SimulatedGameInputQueue xWinningGame =
            SimulatedGameInputQueue.Empty
                .Play(1, 1)
                .Play(0, 0)
                .Play(0, 1)
                .Play(1, 0)
                .Play(2, 1);

        private static SimulatedGameInputQueue currentGameInputQueue = xWinningGame;

        public static string ReadLine()
        {
            currentGameInputQueue = currentGameInputQueue.GetNextInput(out int input);
            System.Console.WriteLine(input);
            return input.ToString();
        }

        public static void WriteLine(object value) => System.Console.WriteLine(value);
    }
    #endregion
}
