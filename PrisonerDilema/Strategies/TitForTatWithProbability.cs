using System;
using static PrisonerDilema.Action;

namespace PrisonerDilema.Strategies
{
    class TitForTatWithProbability : IStrategy
    {
        private readonly Random _random = new Random();
        private bool _previousAction = COOPERATION;
        private readonly double _probability;
        private bool _action;


        public TitForTatWithProbability(bool action, double probability)
        {
            _action = action;
            _probability = probability;
        }

        public bool TakeAction()
        {
            if (_random.NextDouble() <= _probability)
                return _action;
            return _previousAction;
        }

        public void ProcessOpponentAction(bool opponentAction)
        {
            _previousAction = opponentAction;
        }
    }
}
