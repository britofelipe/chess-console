using System;

using board;
using chess;

namespace chess_console
{
    internal class Screen
    {
        public static void printBoard(Board table)
        {
            for (int i = 0; i < table.rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < table.columns; j++)
                {
                        printPiece(table.piece(i, j));

                }
                Console.WriteLine();
            }
            Console.Write("  ");
            for (char i = 'a'; i < 'i'; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine(); Console.WriteLine();
        }

        public static void printBoard(Board table, bool[,] possibleMoves)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor possibleMovesBackground = ConsoleColor.Magenta;

            for (int i = 0; i < table.rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < table.columns; j++)
                {
                    if (possibleMoves[i, j] == true)
                    {
                        Console.BackgroundColor = possibleMovesBackground;
                        printPiece(table.piece(i, j));
                        Console.BackgroundColor = originalBackground;
                    }
                    else
                    {
                        printPiece(table.piece(i, j));
                    }

                }
                Console.WriteLine();
            }
            Console.Write("  ");
            for (char i = 'a'; i < 'i'; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine(); Console.WriteLine();
        }

        public static ChessPosition readChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(column, row);
        }

        public static void printPiece(Piece piece)
        {
            ConsoleColor whiteColor = Console.ForegroundColor;
            ConsoleColor blackColor = ConsoleColor.DarkCyan;

            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    Console.ForegroundColor = blackColor;
                    Console.Write(piece);
                    Console.ForegroundColor = whiteColor;
                }
                Console.Write(" ");
            }
        }
    }
}
