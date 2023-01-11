using board;
using System.Collections.Generic;

namespace chess
{
    internal class ChessMatch
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool isMatchFinished { get; private set; }
        private HashSet<Piece> gamePieces;
        private HashSet<Piece> capturedPieces;

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            isMatchFinished = false;
            gamePieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            setGame();
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
            if (capturedPiece != null)
            {
                capturedPieces.Add(capturedPiece);
            }
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

        public HashSet<Piece> playerGamePieces(Color color)
        {
            HashSet<Piece> playerGamePieces = new HashSet<Piece>();
            foreach (Piece piece in gamePieces)
            {
                if (piece.color == color)
                {
                    playerGamePieces.Add(piece);
                }
            }
            playerGamePieces.ExceptWith(playerCapturedPieces(color));
            return playerGamePieces;
        }

        public HashSet<Piece> playerCapturedPieces(Color color)
        {
            HashSet<Piece> playerCapturedPieces = new HashSet<Piece>();
            foreach(Piece piece in capturedPieces)
            {
                if (piece.color == color)
                {
                    playerCapturedPieces.Add(piece);
                }
            }
            return playerCapturedPieces;
        }

        public void setNewPiece(Piece piece, char column, int row)
        {
            board.putPiece(piece, new ChessPosition(column, row).toPosition());
            gamePieces.Add(piece);
        }

        public void setGame()
        {
            // WHITE PIECES --------------------- 
            // King
            setNewPiece(new King(board, Color.White), 'e', 1);

            // Rooks
            setNewPiece(new Rook(board, Color.White), 'a', 1);
            setNewPiece(new Rook(board, Color.White), 'h', 1);

            // BLACK PIECES ---------------------
            // King
            setNewPiece(new King(board, Color.Black), 'e', 8);

            // Rooks
            setNewPiece(new Rook(board, Color.Black), 'a', 8);
            setNewPiece(new Rook(board, Color.Black), 'h', 8);
        }
    }
}
