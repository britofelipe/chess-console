using board;

namespace chess
{
    internal class King : Piece
    {
        private ChessMatch match;
        public King(Board board, Color color, ChessMatch match) : base(board, color)
        {
            this.match = match;
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

        private bool testRookForCastle(Position position)
        {
            Piece piece = board.piece(position);
            return piece != null && piece is Rook && piece.color == color && piece.quantityOfMovements == 0;
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

            // CASTLE
            if(quantityOfMovements == 0 && !match.check)
            {
                // Kingside castle
                Position rookPositionKingsideCastle = new Position(position.row, position.column + 3);
                if(testRookForCastle(rookPositionKingsideCastle))
                {
                    Position newKingPosition = new Position(position.row, position.column + 1);
                    Position newRookPosition = new Position(position.row, position.column + 2);
                    if(board.piece(newKingPosition) == null && board.piece(newRookPosition) == null)
                    {
                        validMoves[position.row, position.column + 2] = true;
                    }
                }
                // Small castle
                Position rookPositionQueensideCastle = new Position(position.row, position.column - 4);
                if (testRookForCastle(rookPositionQueensideCastle))
                {
                    Position newKingPosition = new Position(position.row, position.column - 1);
                    Position newEmptyPosition = new Position(position.row, position.column - 1);
                    Position newRookPosition = new Position(position.row, position.column - 3);
                    if (board.piece(newKingPosition) == null && board.piece(newRookPosition) == null && board.piece(newEmptyPosition) == null)
                    {
                        validMoves[position.row, position.column - 2] = true;
                    }
                }
            }

            return validMoves;
        }
    }
}
