using System;
using board;
using chess;

namespace chess_console
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                ChessMatch match = new ChessMatch();

                while(!match.gameOver)
                {
                    try
                    {
                        // Match
                        Console.Clear();
                        Screen.printMatch(match);

                        // Origin
                        Console.Write("Origin: ");
                        Position origin = Screen.readChessPosition().toPosition();

                        match.validateOriginPosition(origin);

                        // Printing valid moves
                        bool[,] validMoves = match.board.piece(origin).validMoves();

                        Console.Clear();
                        Screen.printMatch(match, validMoves);

                        // Target
                        Console.Write("Target: ");
                        Position target = Screen.readChessPosition().toPosition();

                        match.validateTargetPosition(origin, target);

                        // Make move
                        match.move(origin, target);
                    }
                    catch(BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                // GameOver
                Console.Clear();
                Screen.printMatch(match);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
