using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    internal class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "B";
        }

        private bool canMoveHere(Position position)
        {
            Piece piece = board.piece(position);
            return piece == null || piece.color != color;
        }

        public override bool[,] validMoves()
        {
            bool[,] validMoves = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            // Northeast
            pos.setPosition(position.row - 1, position.column + 1);
            while (board.isPositionValid(pos) && canMoveHere(pos))
            {
                validMoves[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.row--;
                pos.column++;
            }

            // Southeast
            pos.setPosition(position.row + 1, position.column + 1);
            while (board.isPositionValid(pos) && canMoveHere(pos))
            {
                validMoves[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.row++;
                pos.column++;
            }

            // Southwest
            pos.setPosition(position.row + 1, position.column - 1);
            while (board.isPositionValid(pos) && canMoveHere(pos))
            {
                validMoves[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.row++;
                pos.column--;
            }

            // Northwest
            pos.setPosition(position.row - 1, position.column - 1);
            while (board.isPositionValid(pos) && canMoveHere(pos))
            {
                validMoves[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.row--;
                pos.column--;
            }

            return validMoves;
        }
    }
}
