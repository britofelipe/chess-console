using board;

namespace chess
{
    internal class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "K";
        }

        private bool canMoveHere(Position position)
        {
            Piece p = board.piece(position);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] validMoves = new bool[board.rows, board.columns];

            Position position = new Position(0, 0);

            // North
            position.defineValues(position.row - 1, position.column);
            if (board.isPositionValid(position) && canMoveHere(position))
            {
                validMoves[position.row, position.column] = true;
            }
            // Northeast
            position.defineValues(position.row - 1, position.column + 1);
            if (board.isPositionValid(position) && canMoveHere(position))
            {
                validMoves[position.row, position.column] = true;
            }
            // East
            position.defineValues(position.row, position.column + 1);
            if (board.isPositionValid(position) && canMoveHere(position))
            {
                validMoves[position.row, position.column] = true;
            }
            // Southeast
            position.defineValues(position.row + 1, position.column + 1);
            if (board.isPositionValid(position) && canMoveHere(position))
            {
                validMoves[position.row, position.column] = true;
            }
            // South
            position.defineValues(position.row + 1, position.column);
            if (board.isPositionValid(position) && canMoveHere(position))
            {
                validMoves[position.row, position.column] = true;
            }
            // Southwest
            position.defineValues(position.row + 1, position.column - 1);
            if (board.isPositionValid(position) && canMoveHere(position))
            {
                validMoves[position.row, position.column] = true;
            }
            // West
            position.defineValues(position.row, position.column - 1);
            if (board.isPositionValid(position) && canMoveHere(position))
            {
                validMoves[position.row, position.column] = true;
            }
            // Northwest
            position.defineValues(position.row - 1, position.column - 1);
            if (board.isPositionValid(position) && canMoveHere(position))
            {
                validMoves[position.row, position.column] = true;
            }

            return validMoves;
        }
    }
}
