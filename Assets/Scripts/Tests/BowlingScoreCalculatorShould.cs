using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class BowlingScoreCalculatorShould
    {
        private BowlingScoreCalculator _calculator;
        private readonly List<int> _gameWithNoBonus = new List<int>() {3, 5, 8, 9, 4, 8, 7, 8, 9, 0};
        private readonly int _gameWithNoBonusTotal;
        private readonly List<int> _gameWithSpares = new List<int>() {3, 5, 8, 9, 4, 8, 7, 8, 9, 10, 11};
        private const int GameWithSparesTotal = 81;
        private readonly List<int> _gameWithStrikes = new List<int>() {3, 5, 8, 9, 4, 8, 7, 8, 9, 11, 5, 11};
        private const int GameWithStrikesTotal = 86;
        private readonly List<int> _gameWithSparesAndStrikes = new List<int>() {3, 5, 10, 9, 4, 11, 7, 8, 9, 11, 11, 10};
        private const int GameWithSparesAndStrikesTotal = 119;

        public BowlingScoreCalculatorShould()
        {
            _gameWithNoBonusTotal = _gameWithNoBonus.Sum();
        }

        [SetUp]
        public void Setup()
        {
            _calculator = new BowlingScoreCalculator(10);
        }
        
        [Test]
        public void CalculateScoreCorrectlyForASequenceWithNoBonus()
        {
            Assert.AreEqual(_gameWithNoBonusTotal, _calculator.CalculateScore(_gameWithNoBonus));
        }

        [Test]
        public void CalculateScoreCorrectlyForASequenceWithSpares()
        {
            Assert.AreEqual(GameWithSparesTotal, _calculator.CalculateScore(_gameWithSpares));
        }

        [Test]
        public void CalculateScoreCorrectlyForASequenceWithStrikes()
        {
            Assert.AreEqual(GameWithStrikesTotal, _calculator.CalculateScore(_gameWithStrikes));
        }

        [Test]
        public void CalculateScoreCorrectlyForASequenceWithSparesAndStrikes()
        {
            Assert.AreEqual(GameWithSparesAndStrikesTotal, _calculator.CalculateScore(_gameWithSparesAndStrikes));
        }
        
    }
}
