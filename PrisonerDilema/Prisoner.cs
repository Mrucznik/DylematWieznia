using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonerDilema
{
    class Prisoner : IStrategy
    {
        private readonly IStrategy _strategy;

        public Prisoner(IStrategy strategy)
        {
            _strategy = strategy;
        }
        
        public bool TakeAction() => _strategy.TakeAction();

        public void ProcessOpponentAction(bool opponentAction) => _strategy.ProcessOpponentAction(opponentAction);
    }
}
