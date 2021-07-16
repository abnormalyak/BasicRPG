using Engine.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestEngine.ViewModels
{
    [TestClass]
    public class TestGameSession
    {
        [TestMethod]
        public void TestCreateGameSession()
        {
            GameSession g = new GameSession();

            Assert.IsNotNull(g.CurrentPlayer);
            Assert.AreEqual("Home", g.CurrentLocation.Name);
        }

        [TestMethod]
        public void TestPlayerRespawnsHomeAndFullyHealedOnDeath()
        {
            GameSession g = new GameSession();

            g.CurrentPlayer.TakeDamage(999);

            Assert.AreEqual("Home", g.CurrentLocation.Name);
            Assert.AreEqual(g.CurrentPlayer.Level * 100, g.CurrentPlayer.Health);
        }
    }
}
