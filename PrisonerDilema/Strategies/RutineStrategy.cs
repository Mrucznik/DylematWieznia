using System.Collections.Generic;
using System.Linq;
using static PrisonerDilema.Action;

namespace PrisonerDilema.Strategies
{
    /// <summary>
    /// Zdradzaj po 3 kolejnych zdradach.
    /// </summary>
    class RutineStrategy : IStrategy
    {
        protected readonly Queue<bool> EnemyMoves = new Queue<bool>(3);
        private bool _betrayalMode;

        public bool TakeAction()
        {
            if (_betrayalMode)
                return BETRAYAL;

            if (EnemyMoves.Count < 1)
                return COOPERATION;

            if (EnemyMoves.Count(move => move == BETRAYAL) >= 3)
            {
                _betrayalMode = true;
                return BETRAYAL;
            }

            return EnemyMoves.Peek();
        }

        public void ProcessOpponentAction(bool opponentAction)
        {
            EnemyMoves.Enqueue(opponentAction);
            if (EnemyMoves.Count > 3)
                EnemyMoves.Dequeue();
        }
    }
}
