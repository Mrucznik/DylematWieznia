using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PrisonerDilema.Action;

namespace PrisonerDilema.Strategies
{
    /// <summary>
    /// Współpracuj, gdy współpraca została nawiązana po jej naruszeniu
    /// </summary>
    class CooperateStrategy : IStrategy
    {
        protected bool OponentLastMove = COOPERATION;
        protected bool MyLastMove;

        public bool TakeAction()
        {
            if (MyLastMove == BETRAYAL && OponentLastMove == COOPERATION)
            {
                MyLastMove = COOPERATION;
                return COOPERATION;
            }

            MyLastMove = OponentLastMove;
            return OponentLastMove;
        }

        public void ProcessOpponentAction(bool opponentAction)
        {
            OponentLastMove = opponentAction;
        }
    }
}
