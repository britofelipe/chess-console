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

        public Piece piece(Position position)
        {
            return pieces[position.row, position.column];
        }

        public bool isTherePieceInPosition(Position position)
        {
            validatePosition(position);
            return piece(position) != null;
        }

        public void putPiece(Piece p, Position position)
        {
            if (isTherePieceInPosition(position))
            {
                throw new BoardException("There is already a piece on this position!");
            }
            pieces[position.row, position.column] = p;
            p.position = position;
        }

        public Piece removePiece(Position position)
        {
            if(piece(position) == null)
            {
                return null;
            }
            Piece aux = piece(position);
            aux.position = null;
            pieces[position.row, position.column] = null;
            return aux;
        }

        public bool isPositionValid(Position position)
        {
            if (position.row < 0 || position.column < 0 || position.row >= rows || position.column >= columns) return false;
            return true;
        }

        public void validatePosition(Position position)
        {
            if (!isPositionValid(position))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}
