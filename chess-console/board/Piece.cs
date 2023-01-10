namespace board
{
    internal abstract class Piece
    {
        public Board board { get; protected set; }
        public Color color { get; set; }
        public Position position { get; set; }
        public int quantityOfMovements { get; protected set; }
        
        public Piece(Board board, Color color)
        {
            this.position = null;
            this.color = color;
            this.board = board;
            this.quantityOfMovements = 0;
        }

        public void incrementQuantityOfMoves()
        {
            quantityOfMovements++;
        }

        public bool areThereValidMovesFromHere()
        {
            bool[,] possibleMoves = validMoves();
            for(int i = 0; i < board.rows; i++)
            {
                for(int j = 0; j < board.columns; j++)
                {
                    if (possibleMoves[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool isThisValidTarget(Position target)
        {
            return validMoves()[target.row, target.column];
        }

        public abstract bool[,] validMoves();
    }
}
