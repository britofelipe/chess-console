using System;
using board;
using chess;

namespace chess_console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Board board = new Board(8, 8);
            //try
            //{
            //    board.putPiece(new Tower(board, Color.Black), new Position(0, 0));
            //    board.putPiece(new Tower(board, Color.Black), new Position(1, 3));
            //    board.putPiece(new King(board, Color.Black), new Position(2, 4));
            //    // board.putPiece(new Tower(board, Color.Black), new Position(0, 0));
            //    board.putPiece(new Tower(board, Color.Black), new Position(0, 8));

            //    Screen.printTable(board);
            //}
            //catch(BoardException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            ChessPosition pos = new ChessPosition('a', 1);
            Console.WriteLine(pos.ToString());
            Console.WriteLine(pos.toPosition());

            Console.ReadLine();
        }
    }
}
