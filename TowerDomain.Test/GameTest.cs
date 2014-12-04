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
            this.testee.Towers.Count().Should().Be(1);
        }

        [TestMethod]
        public void DescriptionIsCorrect()
        {
            // Arrange
            Tower tower = new Tower();

            // Act
            this.testee.CreateNewTower(tower);

            // Assert
            this.testee.Towers.ElementAt(0).Description.Should().Be("This tower deals 10 damage and has a range of 10");
        }

        [TestMethod]
        public void UpgradeTowerRange()
        {
            // Arrange
            Tower normalTower = new Tower();
            Tower towerWithRangeUpgrade = new Tower();

            this.testee.CreateNewTower(towerWithRangeUpgrade);
            this.testee.CreateNewTower(normalTower);

            // Act
            testee.UpgradeRangeFromTower(towerWithRangeUpgrade);

            // Assert
            testee.Towers.ElementAt(0).Range.Should().BeGreaterThan(testee.Towers.ElementAt(1).Range);
        }

        [TestMethod]
        public void UpgradeTowerDamage()
        {
            // Arrange
            Tower normalTower = new Tower();
            Tower towerWithDamageUpgrade = new Tower();

            this.testee.CreateNewTower(towerWithDamageUpgrade);
            this.testee.CreateNewTower(normalTower);

            // Act
            testee.UpgradeDamageFromTower(towerWithDamageUpgrade);

            // Assert
            testee.Towers.ElementAt(0).Damage.Should().BeGreaterThan(testee.Towers.ElementAt(1).Range);
        }

        [TestMethod]
        public void UpgradeTowerFirstDamageThanRange()
        {
            // Arrange
            Tower towerWithDamageAndRangeUpgrade = new Tower();
            Tower normalTower = new Tower();

            this.testee.CreateNewTower(towerWithDamageAndRangeUpgrade);
            this.testee.CreateNewTower(normalTower);

            // Act
            testee.UpgradeDamageFromTower(testee.Towers.ElementAt(0));
            testee.UpgradeRangeFromTower(testee.Towers.ElementAt(0));

            // Assert
            testee.Towers.ElementAt(0).Damage.Should().BeGreaterThan(testee.Towers.ElementAt(1).Range);
            testee.Towers.ElementAt(0).Range.Should().BeGreaterThan(testee.Towers.ElementAt(1).Range);
        }

        [TestMethod]
        public void UpgradeTowerFirstRangeThanDamage()
        {
            // Arrange
            Tower towerWithDamageAndRangeUpgrade = new Tower();
            Tower normalTower = new Tower();

            this.testee.CreateNewTower(towerWithDamageAndRangeUpgrade);
            this.testee.CreateNewTower(normalTower);

            // Act
            testee.UpgradeRangeFromTower(testee.Towers.ElementAt(0));
            testee.UpgradeDamageFromTower(testee.Towers.ElementAt(0));

            // Assert
            testee.Towers.ElementAt(0).Damage.Should().BeGreaterThan(testee.Towers.ElementAt(1).Range);
            testee.Towers.ElementAt(0).Range.Should().BeGreaterThan(testee.Towers.ElementAt(1).Range);
        }
    }
}