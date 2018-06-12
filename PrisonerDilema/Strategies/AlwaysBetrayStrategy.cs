using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PrisonerDilema.Action;

namespace PrisonerDilema.Strategies
{
    /// <summary>
    /// Zawsze zdradzaj
    /// </summary>
    class AlwaysBetrayStrategy : IStrategy
    {
        public bool TakeAction()
        {
            return BETRAYAL;
        }

        public void ProcessOpponentAction(bool opponentAction)
        {
            //do nothing
        }
    }
}
