namespace table
{
    internal class Piece
    {
        public Position position { get; set; }
        public Color color { get; set; }
        public int quantityOfMovements { get; protected set; }
        public Table table { get; protected set; }

        public Piece(Position position, Color color, Table table)
        {
            this.position = position;
            this.color = color;
            this.table = table;
        }
    }
}
