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
                    Console.Clear();
                    Screen.printBoard(match.board);

                    Console.Write("Origin: ");
                    Position origin = Screen.readChessPosition().toPosition();

                    bool[,] possibleMoves = match.board.piece(origin).possibleMoves();

                    Console.Clear();
                    Screen.printBoard(match.board, possibleMoves);

                    Console.Write("Target: ");
                    Position target = Screen.readChessPosition().toPosition();

                    match.move(origin, target);
                }
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
