using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Checkers.Core;
using System.Linq;
using System.Collections.Generic;

namespace Checkers.Tests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void TestBoardSetup()
        {
            var board = GameRules.startGame;
            Assert.AreEqual(board.Where(x => x.IsBlackMan).Count(), 12);
            Assert.AreEqual(board.Where(x => x.IsWhiteMan).Count(), 12);
            Assert.AreEqual(board.Where(x => x.IsBlackKing).Count(), 0);
            Assert.AreEqual(board.Where(x => x.IsBlackKing).Count(), 0);
        }
    }
}
