using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonerDilema.Strategies
{
    /// <summary>
    /// Gracz wybiera.
    /// </summary>
    class HumanStrategy : IStrategy
    {
        public bool TakeAction()
        {
            //TODO: show UI to allow human choose action
            return false; //a good guy
        }

        public void ProcessOpponentAction(bool opponentAction)
        {
            //Do nothing - human can process action without code instructions :O
        }
    }
}
