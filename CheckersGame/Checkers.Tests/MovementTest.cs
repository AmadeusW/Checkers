using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Checkers.Core;

namespace Checkers.Tests
{
    [TestClass]
    public class MovementTest
    {
        [TestMethod]
        public void TestManMovement()
        {
            // Only allowed to move one tile away to the south
            var piece = GameRules.Tile.BlackMan;
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.NE, 0));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.NE, 1));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.NE, 2));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.SE, 0));
            Assert.IsTrue(GameRules.canPieceMove(piece, GameRules.Direction.SE, 1));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.SE, 2));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.SW, 0));
            Assert.IsTrue(GameRules.canPieceMove(piece, GameRules.Direction.SW, 1));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.SW, 2));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.NW, 0));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.NW, 1));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.NW, 2));
            // Only allowed to move one tile away to the north
            piece = GameRules.Tile.WhiteMan;
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.NE, 0));
            Assert.IsTrue(GameRules.canPieceMove(piece, GameRules.Direction.NE, 1));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.NE, 2));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.SE, 0));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.SE, 1));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.SE, 2));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.SW, 0));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.SW, 1));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.SW, 2));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.NW, 0));
            Assert.IsTrue(GameRules.canPieceMove(piece, GameRules.Direction.NW, 1));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.NW, 2));
        }

        [TestMethod]
        public void TestKingMovement()
        {
            // Only allowed to move one tile away in any direction
            var piece = GameRules.Tile.BlackKing;
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.NE, 0));
            Assert.IsTrue(GameRules.canPieceMove(piece, GameRules.Direction.NE, 1));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.NE, 2));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.SE, 0));
            Assert.IsTrue(GameRules.canPieceMove(piece, GameRules.Direction.SE, 1));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.SE, 2));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.SW, 0));
            Assert.IsTrue(GameRules.canPieceMove(piece, GameRules.Direction.SW, 1));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.SW, 2));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.NW, 0));
            Assert.IsTrue(GameRules.canPieceMove(piece, GameRules.Direction.NW, 1));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.NW, 2));
            // Only allowed to move one tile away in any direction
            piece = GameRules.Tile.WhiteKing;
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.NE, 0));
            Assert.IsTrue(GameRules.canPieceMove(piece, GameRules.Direction.NE, 1));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.NE, 2));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.SE, 0));
            Assert.IsTrue(GameRules.canPieceMove(piece, GameRules.Direction.SE, 1));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.SE, 2));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.SW, 0));
            Assert.IsTrue(GameRules.canPieceMove(piece, GameRules.Direction.SW, 1));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.SW, 2));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.NW, 0));
            Assert.IsTrue(GameRules.canPieceMove(piece, GameRules.Direction.NW, 1));
            Assert.IsFalse(GameRules.canPieceMove(piece, GameRules.Direction.NW, 2));
        }
    }
}
