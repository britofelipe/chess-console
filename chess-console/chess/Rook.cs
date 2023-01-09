using board;

namespace chess
{
    internal class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "R";
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

            // North
            pos.setPosition(position.row - 1, position.column);
            while (board.isPositionValid(pos) && canMoveHere(pos))
            {
                validMoves[pos.row, pos.column] = true;
                if(board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.row = pos.row - 1;
            }

            // East
            pos.setPosition(position.row, position.column + 1);
            while (board.isPositionValid(pos) && canMoveHere(pos))
            {
                validMoves[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.column = pos.column + 1;
            }

            // South
            pos.setPosition(position.row + 1, position.column);
            while (board.isPositionValid(pos) && canMoveHere(pos))
            {
                validMoves[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.row = pos.row + 1;
            }

            // West
            pos.setPosition(position.row, position.column - 1);
            while (board.isPositionValid(pos) && canMoveHere(pos))
            {
                validMoves[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color)
                {
                    break;
                }
                pos.column = pos.column - 1;
            }

            return validMoves;
        }
    }
}
