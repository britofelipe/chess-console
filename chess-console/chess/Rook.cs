using board;

namespace chess
{
    internal class Rook : Piece
    {
        public Rook(Board tab, Color color) : base(tab, color)
        {

        }

        public override string ToString()
        {
            return "R";
        }
    }
}
