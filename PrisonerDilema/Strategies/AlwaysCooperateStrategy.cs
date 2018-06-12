using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PrisonerDilema.Action;

namespace PrisonerDilema.Strategies
{
    /// <summary>
    /// Zawsze współpracuj
    /// </summary>
    class AlwaysCooperateStrategy : IStrategy
    {
        public bool TakeAction()
        {
            return COOPERATION;
        }

        public void ProcessOpponentAction(bool opponentAction)
        {
            //do nothing
        }
    }
}
