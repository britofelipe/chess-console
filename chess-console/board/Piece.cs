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

        public abstract bool[,] validMoves();
    }
}
