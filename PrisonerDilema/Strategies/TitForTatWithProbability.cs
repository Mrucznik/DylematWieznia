using System;
using static PrisonerDilema.Action;

namespace PrisonerDilema.Strategies
{
    class TitForTatWithProbability : IStrategy
    {
        private readonly Random _random = new Random();
        private bool _previousAction = COOPERATION;

        public bool TakeAction()
        {
            if (_random.NextDouble() > 0.9)
                return COOPERATION;
            return _previousAction;
        }

        public void ProcessOpponentAction(bool opponentAction)
        {
            _previousAction = opponentAction;
        }
    }
}
