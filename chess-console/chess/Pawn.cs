using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    internal class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "P";
        }

        private bool isThereOpponentPieceHere(Position position)
        {
            Piece piece = board.piece(position);
            return piece != null && piece.color != color;
        }

        private bool isPositionEmpty(Position position)
        {
            return board.piece(position) == null;
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

            if(color == Color.White)
            {
                // North
                pos.setPosition(position.row - 1, position.column);
                if (board.isPositionValid(pos) && isPositionEmpty(pos))
                {
                    validMoves[pos.row, pos.column] = true;
                }
                // Double north
                pos.setPosition(position.row - 2, position.column);
                if (board.isPositionValid(pos) && isPositionEmpty(pos) && quantityOfMovements == 0)
                {
                    validMoves[pos.row, pos.column] = true;
                }
                // Northeast
                pos.setPosition(position.row - 1, position.column + 1);
                if (board.isPositionValid(pos) && isThereOpponentPieceHere(pos))
                {
                    validMoves[pos.row, pos.column] = true;
                }
                // Northwest
                pos.setPosition(position.row - 1, position.column - 1);
                if (board.isPositionValid(pos) && isThereOpponentPieceHere(pos))
                {
                    validMoves[pos.row, pos.column] = true;
                }
            }
            else
            {
                // South
                pos.setPosition(position.row + 1, position.column);
                if (board.isPositionValid(pos) && isPositionEmpty(pos))
                {
                    validMoves[pos.row, pos.column] = true;
                }
                // Double south
                pos.setPosition(position.row + 2, position.column);
                if (board.isPositionValid(pos) && isPositionEmpty(pos) && quantityOfMovements == 0)
                {
                    validMoves[pos.row, pos.column] = true;
                }
                // Southeast
                pos.setPosition(position.row + 1, position.column + 1);
                if (board.isPositionValid(pos) && isThereOpponentPieceHere(pos))
                {
                    validMoves[pos.row, pos.column] = true;
                }
                // Southwest
                pos.setPosition(position.row + 1, position.column - 1);
                if (board.isPositionValid(pos) && isThereOpponentPieceHere(pos))
                {
                    validMoves[pos.row, pos.column] = true;
                }
            }


            return validMoves;
        }
    }
}
