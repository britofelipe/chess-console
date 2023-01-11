using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    internal class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "N";
        }

        private bool canMoveHere(Position position)
        {
            Piece p = board.piece(position);
            return p == null || p.color != color;
        }

        public override bool[,] validMoves()
        {
            bool[,] validMoves = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            // Northeast 1
            pos.setPosition(position.row - 1, position.column + 2);
            if (board.isPositionValid(pos) && canMoveHere(pos))
            {
                validMoves[pos.row, pos.column] = true;
            }
            // Northeast 2
            pos.setPosition(position.row - 2, position.column + 1);
            if (board.isPositionValid(pos) && canMoveHere(pos))
            {
                validMoves[pos.row, pos.column] = true;
            }
            // Southeast 1
            pos.setPosition(position.row + 1, position.column + 2);
            if (board.isPositionValid(pos) && canMoveHere(pos))
            {
                validMoves[pos.row, pos.column] = true;
            }
            // Southeast 2
            pos.setPosition(position.row + 2, position.column + 1);
            if (board.isPositionValid(pos) && canMoveHere(pos))
            {
                validMoves[pos.row, pos.column] = true;
            }
            // Southwest 1
            pos.setPosition(position.row + 1, position.column - 2);
            if (board.isPositionValid(pos) && canMoveHere(pos))
            {
                validMoves[pos.row, pos.column] = true;
            }
            // Southwest 2
            pos.setPosition(position.row + 2, position.column - 1);
            if (board.isPositionValid(pos) && canMoveHere(pos))
            {
                validMoves[pos.row, pos.column] = true;
            }
            // Northwest 1
            pos.setPosition(position.row - 1, position.column - 2);
            if (board.isPositionValid(pos) && canMoveHere(pos))
            {
                validMoves[pos.row, pos.column] = true;
            }
            // Northwest 2
            pos.setPosition(position.row - 2, position.column - 1);
            if (board.isPositionValid(pos) && canMoveHere(pos))
            {
                validMoves[pos.row, pos.column] = true;
            }

            return validMoves;
        }
    }
}
