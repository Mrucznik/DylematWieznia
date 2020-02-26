using System;

namespace PrisonerDilema.Strategies
{
    /// <summary>
    /// Losowo zdradzaj i współpracuj.
    /// </summary>
    class RandomStrategy : IStrategy
    {
        private readonly Random _random = new Random();
        public bool TakeAction()
        {
            return _random.Next(0, 2) == 0;
        }

        public void ProcessOpponentAction(bool opponentAction)
        {
            //do nothing
        }
    }
}
