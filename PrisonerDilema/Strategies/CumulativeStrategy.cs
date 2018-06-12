using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PrisonerDilema.Action;

namespace PrisonerDilema.Strategies
{
    abstract class CumulativeStrategy : IStrategy
    {
        protected readonly Stack<bool> EnemyMoves = new Stack<bool>(3);
        protected readonly Stack<bool> MyMoves = new Stack<bool>(3);
        protected bool LastMove = COOPERATION;

        public abstract bool TakeAction();

        public virtual void ProcessOpponentAction(bool opponentAction)
        {
            LastMove = opponentAction;
            EnemyMoves.Push(opponentAction);
        }
    }
}
