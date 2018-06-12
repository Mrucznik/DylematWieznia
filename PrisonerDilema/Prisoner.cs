using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonerDilema
{
    class Prisoner : IStrategy
    {
        private IStrategy _strategy;
        public int Score { get; set; }

        public Prisoner(IStrategy strategy)
        {
            SetStrategy(strategy);
        }

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }
        
        public bool TakeAction() => _strategy.TakeAction();

        public void ProcessOpponentAction(bool opponentAction) => _strategy.ProcessOpponentAction(opponentAction);
    }
}
