using table;

namespace chess
{
    internal class Tower : Piece
    {
        public Tower(Color color, Table tab) : base(color, tab)
        {

        }

        public override string ToString()
        {
            return "T";
        }
    }
}
