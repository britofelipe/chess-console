using board;

namespace chess
{
    internal class King : Piece
    {
        public King(Board tab, Color color) : base(tab, color)
        {

        }

        public override string ToString()
        {
            return "K";
        }
    }
}
