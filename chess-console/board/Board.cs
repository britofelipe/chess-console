namespace board
{
    internal class Board
    {
        public int rows { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            pieces = new Piece[rows, columns];
        }

        public Piece piece(int row, int column)
        {
            return pieces[row, column];
        }

        public Piece piece(Position pos)
        {
            return pieces[pos.row, pos.column];
        }

        public bool isTherePieceInPosition(Position pos)
        {
            validatePosition(pos);
            return piece(pos) != null;
        }

        public void putPiece(Piece p, Position pos)
        {
            if (isTherePieceInPosition(pos))
            {
                throw new BoardException("There is already a piece on this position!");
            }
            pieces[pos.row, pos.column] = p;
            p.position = pos;
        }

        public bool isPositionValid(Position pos)
        {
            if (pos.row < 0 || pos.column < 0 || pos.row >= rows || pos.column >= columns) return false;
            return true;
        }

        public void validatePosition(Position pos)
        {
            if (!isPositionValid(pos))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}
