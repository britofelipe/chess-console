namespace table
{
    class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Position(int line, int column)
        {
            Row = line;
            Column = column;
        }

        public override string ToString()
        {
            return Row
                + ", "
                + Column;
        }
    }
}
