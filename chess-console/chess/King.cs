using table;

namespace chess
{
    internal class King : Piece
    {
        public King(Color color, Table tab) : base(color, tab)
        {

        }

        public override string ToString()
        {
            return "R";
        }
    }
}
