using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpChess
{
    public class Position
    {
        public ChessPiece[] Pieces { get; private set; } = new ChessPiece[]
        {
            new ChessPiece { Color = PieceColor.Black, Type = PieceType.Rook },
            new ChessPiece { Color = PieceColor.Black, Type = PieceType.Knight },
            new ChessPiece { Color = PieceColor.Black, Type = PieceType.Bishop },
            new ChessPiece { Color = PieceColor.Black, Type = PieceType.Queen },
            new ChessPiece { Color = PieceColor.Black, Type = PieceType.King },
            new ChessPiece { Color = PieceColor.Black, Type = PieceType.Bishop },
            new ChessPiece { Color = PieceColor.Black, Type = PieceType.Knight },
            new ChessPiece { Color = PieceColor.Black, Type = PieceType.Rook },
            new ChessPiece { Color = PieceColor.Black, Type = PieceType.Pawn },
            new ChessPiece { Color = PieceColor.Black, Type = PieceType.Pawn },
            new ChessPiece { Color = PieceColor.Black, Type = PieceType.Pawn },
            new ChessPiece { Color = PieceColor.Black, Type = PieceType.Pawn },
            new ChessPiece { Color = PieceColor.Black, Type = PieceType.Pawn },
            new ChessPiece { Color = PieceColor.Black, Type = PieceType.Pawn },
            new ChessPiece { Color = PieceColor.Black, Type = PieceType.Pawn },
            new ChessPiece { Color = PieceColor.Black, Type = PieceType.Pawn },
            null, null, null, null, null, null, null, null,
            null, null, null, null, null, null, null, null,
            null, null, null, null, null, null, null, null,
            null, null, null, null, null, null, null, null,
            new ChessPiece { Color = PieceColor.White, Type = PieceType.Pawn },
            new ChessPiece { Color = PieceColor.White, Type = PieceType.Pawn },
            new ChessPiece { Color = PieceColor.White, Type = PieceType.Pawn },
            new ChessPiece { Color = PieceColor.White, Type = PieceType.Pawn },
            new ChessPiece { Color = PieceColor.White, Type = PieceType.Pawn },
            new ChessPiece { Color = PieceColor.White, Type = PieceType.Pawn },
            new ChessPiece { Color = PieceColor.White, Type = PieceType.Pawn },
            new ChessPiece { Color = PieceColor.White, Type = PieceType.Pawn },
            new ChessPiece { Color = PieceColor.White, Type = PieceType.Rook },
            new ChessPiece { Color = PieceColor.White, Type = PieceType.Knight },
            new ChessPiece { Color = PieceColor.White, Type = PieceType.Bishop },
            new ChessPiece { Color = PieceColor.White, Type = PieceType.Queen },
            new ChessPiece { Color = PieceColor.White, Type = PieceType.King },
            new ChessPiece { Color = PieceColor.White, Type = PieceType.Bishop },
            new ChessPiece { Color = PieceColor.White, Type = PieceType.Knight },
            new ChessPiece { Color = PieceColor.White, Type = PieceType.Rook },
        };
    }
}
