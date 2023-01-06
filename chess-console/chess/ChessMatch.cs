using board;

namespace chess
{
    internal class ChessMatch
    {
        public Board board { get; private set; }
        private int turn;
        private Color currentPlayer;
        public bool isMatchFinished { get; private set; }

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            isMatchFinished = false;
            setPieces();
        }

        public void move(Position origin, Position target)
        {
            Piece p = board.removePiece(origin);
            p.incrementQuantityOfMoves();
            Piece capturedPiece = board.removePiece(target);
            board.putPiece(p, target);
        }

        public void setPieces()
        {
            // WHITE PIECES --------------------- 
            // King
            board.putPiece(new King(board, Color.White), new ChessPosition('e', 1).toPosition());

            // Rooks
            board.putPiece(new Rook(board, Color.White), new ChessPosition('a', 1).toPosition());
            board.putPiece(new Rook(board, Color.White), new ChessPosition('h', 1).toPosition());

            // BLACK PIECES ---------------------
            // King
            board.putPiece(new King(board, Color.Black), new ChessPosition('e', 8).toPosition());

            // Rooks
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('a', 8).toPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('h', 8).toPosition());
        }
    }
}
