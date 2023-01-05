using System;

using board;

namespace chess_console
{
    internal class Screen
    {
        public static void printTable(Board table)
        {
            for (int i = 0; i < table.rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < table.columns; j++)
                {
                    if (table.piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        printPiece(table.piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.Write("  ");
            for(char i = 'a'; i < 'i'; i++)
            {
                Console.Write(i + " ");
            }
        }

        public static void printPiece(Piece piece)
        {
            if(piece.color == Color.White)
            {
                Console.Write(piece);
            }
            if(piece.color == Color.Black)
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
