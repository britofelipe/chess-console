using board;
using System.Collections.Generic;

namespace chess
{
    internal class ChessMatch
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool gameOver { get; private set; }
        private HashSet<Piece> gamePieces;
        private HashSet<Piece> capturedPieces;
        public bool check { get; private set; }
        

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            gameOver = false;
            gamePieces = new HashSet<Piece>();
            capturedPieces = new HashSet<Piece>();
            setGame();
        }

        public void move(Position origin, Position target)
        {
            Piece capturedPiece = moveUtil(origin, target);

            // Testing check for the current player
            if (isKingInCheck(currentPlayer))
            {
                undoMove(origin, target, capturedPiece);
                throw new BoardException("Not a valid move: your king will be in check!");
            }

            // Testing check for the opponent
            if (isKingInCheck(opponentPlayer(currentPlayer)))
            {
                check = true;
                if (isCheckMate(opponentPlayer(currentPlayer)))
                {
                    gameOver = true;
                    return;
                }
            }
            else
            {
                check = false;
            }
            turn++;
            nextPlayer();
        }

        public Piece moveUtil(Position origin, Position target)
        {
            Piece p = board.removePiece(origin);
            p.incrementQuantityOfMoves();
            Piece capturedPiece = board.removePiece(target);
            board.putPiece(p, target);
            if (capturedPiece != null)
            {
                capturedPieces.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void undoMove(Position origin, Position target, Piece capturedPiece)
        {
            Piece p = board.removePiece(target);
            p.decrementQuantityOfMoves();
            board.putPiece(p, origin);
            if (capturedPiece != null)
            {
                board.putPiece(capturedPiece, target);
                capturedPieces.Remove(capturedPiece);
            }
        }

        public void validateOriginPosition(Position origin)
        {
            if (board.piece(origin) == null)
            {
                throw new BoardException("There is not a piece on the chosen origin!");
            }
            if (currentPlayer != board.piece(origin).color)
            {
                throw new BoardException("The chosen piece is not yours!");
            }
            if (!board.piece(origin).areThereValidMovesFromHere())
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

        private void nextPlayer()
        {
            if (currentPlayer == Color.White)
            {
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
            foreach (Piece piece in capturedPieces)
            {
                if (piece.color == color)
                {
                    playerCapturedPieces.Add(piece);
                }
            }
            return playerCapturedPieces;
        }

        private Color opponentPlayer(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece king(Color color)
        {
            foreach (Piece piece in playerGamePieces(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public bool isKingInCheck(Color color)
        {
            Piece k = king(color);
            if (k == null)
            {
                throw new BoardException("There is no " + color + " king on the board!");
            }

            foreach (Piece piece in playerGamePieces(opponentPlayer(color)))
            {
                bool[,] possibleMoves = piece.validMoves();
                if (possibleMoves[k.position.row, k.position.column] == true)
                {
                    return true;
                }
            }
            return false;
        }

        public bool isCheckMate(Color color)
        {
            foreach (Piece piece in playerGamePieces(color))
            {
                bool[,] possibleMoves = piece.validMoves();
                for (int i = 0; i < board.rows; i++)
                {
                    for (int j = 0; j < board.columns; j++)
                    {
                        if (possibleMoves[i, j])
                        {
                            Position origin = piece.position;
                            Position possibleTarget = new Position(i, j);
                            Piece capturedPiece = moveUtil(piece.position, possibleTarget);
                            bool isStillCheck = isKingInCheck(color);
                            undoMove(origin, possibleTarget, capturedPiece);
                            if(!isStillCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void setNewPiece(Piece piece, char column, int row)
        {
            board.putPiece(piece, new ChessPosition(column, row).toPosition());
            gamePieces.Add(piece);
        }

        public void setGame()
        {
            // WHITE PIECES ----------------------------------------------------
            // King
            setNewPiece(new King(board, Color.White), 'e', 1);

            // Queen
            setNewPiece(new Queen(board, Color.White), 'd', 1);

            // Rooks
            setNewPiece(new Rook(board, Color.White), 'a', 1);
            setNewPiece(new Rook(board, Color.White), 'h', 1);

            // Bishops
            setNewPiece(new Bishop(board, Color.White), 'c', 1);
            setNewPiece(new Bishop(board, Color.White), 'f', 1);

            // Knights
            setNewPiece(new Knight(board, Color.White), 'b', 1);
            setNewPiece(new Knight(board, Color.White), 'g', 1);

            // Pawns
            for (char i = 'a'; i < 'i'; i++)
            {
                setNewPiece(new Pawn(board, Color.White), i, 2);
            }

            // BLACK PIECES --------------------------------------------------
            // King
            setNewPiece(new King(board, Color.Black), 'e', 8);

            // Queen
            setNewPiece(new Queen(board, Color.Black), 'd', 8);

            // Rooks
            setNewPiece(new Rook(board, Color.Black), 'a', 8);
            setNewPiece(new Rook(board, Color.Black), 'h', 8);

            // Bishops
            setNewPiece(new Bishop(board, Color.Black), 'c', 8);
            setNewPiece(new Bishop(board, Color.Black), 'f', 8);

            // Knights
            setNewPiece(new Knight(board, Color.Black), 'b', 8);
            setNewPiece(new Knight(board, Color.Black), 'g', 8);

            // Pawns
            for (char i = 'a'; i < 'i'; i++)
            {
                setNewPiece(new Pawn(board, Color.Black), i, 7);
            }
        }
    }
}
