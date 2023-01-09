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

        public override bool[,] validMoves()
        {
            bool[,] validMoves = new bool[board.rows, board.columns];

            Position pos = new Position(0, 0);

            // North
            pos.setPosition(position.row - 1, position.column);
            if (board.isPositionValid(pos) && canMoveHere(pos))
            {
                validMoves[pos.row, pos.column] = true;
            }
            // Northeast
            pos.setPosition(position.row - 1, position.column + 1);
            if (board.isPositionValid(pos) && canMoveHere(pos))
            {
                validMoves[pos.row, pos.column] = true;
            }
            // East
            pos.setPosition(position.row, position.column + 1);
            if (board.isPositionValid(pos) && canMoveHere(pos))
            {
                validMoves[pos.row, pos.column] = true;
            }
            // Southeast
            pos.setPosition(position.row + 1, position.column + 1);
            if (board.isPositionValid(pos) && canMoveHere(pos))
            {
                validMoves[pos.row, pos.column] = true;
            }
            // South
            pos.setPosition(position.row + 1, position.column);
            if (board.isPositionValid(pos) && canMoveHere(pos))
            {
                validMoves[pos.row, pos.column] = true;
            }
            // Southwest
            pos.setPosition(position.row + 1, position.column - 1);
            if (board.isPositionValid(pos) && canMoveHere(pos))
            {
                validMoves[pos.row, pos.column] = true;
            }
            // West
            pos.setPosition(position.row, position.column - 1);
            if (board.isPositionValid(pos) && canMoveHere(pos))
            {
                validMoves[pos.row, pos.column] = true;
            }
            // Northwest
            pos.setPosition(position.row - 1, position.column - 1);
            if (board.isPositionValid(pos) && canMoveHere(pos))
            {
                validMoves[pos.row, pos.column] = true;
            }

            return validMoves;
        }
    }
}
