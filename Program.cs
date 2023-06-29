using System;

public class TicTacToe
{
    private char[,] board;
    private char currentPlayer;
    private bool gameOver;

    public TicTacToe()
    {
        board = new char[3, 3];
        currentPlayer = 'X';
        gameOver = false;
        InitializeBoard();
    }

    public void Play()
    {
        Console.WriteLine("Welcome to Tic-Tac-Toe!");
        Console.WriteLine("Player 1: X");
        Console.WriteLine("Player 2: O");
        Console.WriteLine();

        while (!gameOver)
        {
            DrawBoard();
            int row = 0, col = 0;
            bool validMove = false;

            do
            {
                Console.Write($"Player {currentPlayer}, enter your move (row[1-3] column[1-3]): ");
                string[] input = Console.ReadLine().Split(' ');

                if (input.Length == 2 && int.TryParse(input[0], out row) && int.TryParse(input[1], out col))
                {
                    row--;
                    col--;
                    if (row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == '\0')
                    {
                        validMove = true;
                    }
                }

                if (!validMove)
                {
                    Console.WriteLine("Invalid move. Please try again.");
                }
            } while (!validMove);


            MakeMove(row, col);
            CheckForWin();
            CheckForTie();
            SwitchPlayer();
        }
    }

    private void InitializeBoard()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                board[row, col] = '\0';
            }
        }
    }

    private void DrawBoard()
    {
        Console.WriteLine();
        Console.WriteLine("    1   2   3");
        Console.WriteLine("  +---+---+---+");
        for (int row = 0; row < 3; row++)
        {
            Console.Write($"{row + 1} | ");
            for (int col = 0; col < 3; col++)
            {
                Console.Write($"{board[row, col]} | ");
            }
            Console.WriteLine();
            Console.WriteLine("  +---+---+---+");
        }
        Console.WriteLine();
    }

    private void MakeMove(int roww, int coll)
    {
        board[roww, coll] = currentPlayer;
    }

    private void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
    }

    private void CheckForWin()
    {
        // Check rows
        for (int row = 0; row < 3; row++)
        {
            if (board[row, 0] != '\0' && board[row, 0] == board[row, 1] && board[row, 1] == board[row, 2])
            {
                Console.WriteLine($"Player {currentPlayer} wins!");
                gameOver = true;
                return;
            }
        }

        // Check columns
        for (int col = 0; col < 3; col++)
        {
            if (board[0, col] != '\0' && board[0, col] == board[1, col] && board[1, col] == board[2, col])
            {
                Console.WriteLine($"Player {currentPlayer} wins!");
                gameOver = true;
                return;
            }
        }

        // Check diagonals
        if (board[0, 0] != '\0' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
        {
            Console.WriteLine($"Player {currentPlayer} wins!");
            gameOver = true;
            return;
        }

        if (board[0, 2] != '\0' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
        {
            Console.WriteLine($"Player {currentPlayer} wins!");
            gameOver = true;
            return;
        }
    }

    private void CheckForTie()
    {
        bool isTie = true;
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (board[row, col] == '\0')
                {
                    isTie = false;
                    break;
                }
            }
            if (!isTie)
            {
                break;
            }
        }

        if (isTie)
        {
            Console.WriteLine("It's a tie!");
            gameOver = true;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        TicTacToe game = new TicTacToe();
        game.Play();
    }
}
