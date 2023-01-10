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

                while(!match.isMatchFinished)
                {
                    try
                    {
                        // Match
                        Console.Clear();
                        Screen.printBoard(match.board);

                        // Origin
                        Console.WriteLine("Turn: " + match.turn);
                        Console.WriteLine(match.currentPlayer + "'s turn");
                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.readChessPosition().toPosition();

                        match.validateOriginPosition(origin);

                        // Printing valid moves
                        bool[,] validMoves = match.board.piece(origin).validMoves();

                        Console.Clear();
                        Screen.printBoard(match.board, validMoves);

                        // Target
                        Console.WriteLine("Turn: " + match.turn);
                        Console.WriteLine(match.currentPlayer + "'s turn");
                        Console.WriteLine();
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
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
