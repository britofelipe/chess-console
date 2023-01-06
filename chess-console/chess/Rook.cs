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

        public override bool[,] possibleMoves()
        {
            bool[,] validMoves = new bool[board.rows, board.columns];

            Position position = new Position(0, 0);

            // North
            position.defineValues(position.row - 1, position.column);
            while (board.isPositionValid(position) && canMoveHere(position))
            {
                validMoves[position.row, position.column] = true;
                if(board.piece(position) != null && board.piece(position).color != color)
                {
                    break;
                }
                position.row = position.row - 1;
            }

            // East
            position.defineValues(position.row, position.column + 1);
            while (board.isPositionValid(position) && canMoveHere(position))
            {
                validMoves[position.row, position.column] = true;
                if (board.piece(position) != null && board.piece(position).color != color)
                {
                    break;
                }
                position.column = position.column + 1;
            }

            // South
            position.defineValues(position.row + 1, position.column);
            while (board.isPositionValid(position) && canMoveHere(position))
            {
                validMoves[position.row, position.column] = true;
                if (board.piece(position) != null && board.piece(position).color != color)
                {
                    break;
                }
                position.row = position.row + 1;
            }

            // West
            position.defineValues(position.row, position.column - 1);
            while (board.isPositionValid(position) && canMoveHere(position))
            {
                validMoves[position.row, position.column] = true;
                if (board.piece(position) != null && board.piece(position).color != color)
                {
                    break;
                }
                position.column = position.column - 1;
            }

            return validMoves;
        }
    }
}
