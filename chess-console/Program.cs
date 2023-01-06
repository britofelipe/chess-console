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
                    Screen.printTable(match.board);

                    Console.Write("Origin: ");
                    Position origin = Screen.readChessPosition().toPosition();
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
