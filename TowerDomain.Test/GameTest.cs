using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TowerDomain.Test
{
    [TestClass]
    public class GameTest
    {
        private Game testee;

        [TestInitialize]
        public void TestInitialize()
        {
            this.testee = new Game();
        }

        [TestMethod]
        public void BuildNewTower()
        {
            // Arrange
            Tower tower = new Tower();

            // Act
            this.testee.CreateNewTower(tower);

            // Assert
            this.testee.TowerContainers.Count().Should().Be(1);
        }

        [TestMethod]
        public void UpgradeTowerRange()
        {
            // Arrange
            Tower towerWithoutRangeUpgrade = new Tower();
            Tower towerWithRangeUpgrade = new Tower();

            this.testee.CreateNewTower(towerWithRangeUpgrade);
            this.testee.CreateNewTower(towerWithoutRangeUpgrade);

            // Act
            testee.UpgradeRangeFromTower(towerWithRangeUpgrade);

            // Assert
            testee.TowerContainers.ElementAt(0).Range.Should().BeGreaterThan(testee.TowerContainers.ElementAt(1).Range);
        }
    }
}