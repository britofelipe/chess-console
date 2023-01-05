namespace table
{
    internal class Piece
    {
        public Position position { get; set; }
        public Color color { get; set; }
        public int quantityOfMovements { get; protected set; }
        public Table table { get; protected set; }

        public Piece(Color color, Table table)
        {
            this.position = null;
            this.color = color;
            this.table = table;
            this.quantityOfMovements = 0;
        }
    }
}
