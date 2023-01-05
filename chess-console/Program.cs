using System;
using table;
using chess;

namespace chess_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Table tab = new Table(8, 8);

            tab.putPiece(new Tower(Color.Black, tab), new Position(0, 0));
            tab.putPiece(new Tower(Color.Black, tab), new Position(1, 3));
            tab.putPiece(new King(Color.Black, tab), new Position(2, 4));

            Screen.printTable(tab);

            Console.ReadLine();

        }
    }
}
