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
            throw new InvalidOperationException("Player has already played in this spot");
        }
        _spaces[row, col] = "X";
    }

    public void O(int row, int col)
    {
        if (_spaces[row, col] != null)
        {
            throw new InvalidOperationException("Player has already played in this spot");
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

