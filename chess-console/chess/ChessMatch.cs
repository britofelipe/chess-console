using board;
using System.Transactions;

namespace chess
{
    internal class ChessMatch
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
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

            moveUtil(origin, target);
            turn++;
            nextPlayer();
        }

        public void moveUtil(Position origin, Position target)
        {
            Piece p = board.removePiece(origin);
            p.incrementQuantityOfMoves();
            Piece capturedPiece = board.removePiece(target);
            board.putPiece(p, target);
        }

        public void validateOriginPosition(Position origin)
        {
            if (board.piece(origin) == null)
            {
                throw new BoardException("There is not a piece on the chosen origin!");
            }
            if(currentPlayer != board.piece(origin).color)
            {
                throw new BoardException("The chosen piece is not yours!");
            }
            if(!board.piece(origin).areThereValidMovesFromHere())
            {
                throw new BoardException("There are not valid moves for this piece");
            }
        }

        public void validateTargetPosition(Position origin, Position target)
        {
            if (!board.piece(origin).isThisValidTarget(target))
            {
                throw new BoardException("This is not a valid move");
            }
        }

        private void nextPlayer() { 
            if (currentPlayer  == Color.White) {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }
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
