using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonerDilema.Strategies
{
    /// <summary>
    /// Losowo zdradzaj i współpracuj.
    /// </summary>
    class RandomStrategy : IStrategy
    {
        public bool TakeAction()
        {
            Random random = new Random();
            return random.Next(0, 1) == 0;
        }

        public void ProcessOpponentAction(bool opponentAction)
        {
            //do nothing
        }
    }
}
