using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PrisonerDilema.Action;

namespace PrisonerDilema.Strategies
{
    /// <summary>
    /// Wet za 2 wety - dopiero gdy przeciwnik zdradzi 2 razy, zaczynamy go zdradzać.
    /// </summary>
    class TitFor2Tat : IStrategy
    {
        private int _tolerantion = 2;

        private bool _previousAction = COOPERATION;

        public bool TakeAction()
        {
            if (_previousAction == BETRAYAL && _tolerantion <= 0)
                return BETRAYAL;
            else
                return COOPERATION;
        }

        public void ProcessOpponentAction(bool opponentAction)
        {
            if (opponentAction == BETRAYAL)
                _tolerantion--;
            else
                _tolerantion = 2;
            _previousAction = opponentAction;
        }
    }
}
