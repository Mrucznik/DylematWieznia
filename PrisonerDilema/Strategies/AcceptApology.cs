using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PrisonerDilema.Action;

namespace PrisonerDilema.Strategies
{
    /// <summary>
    /// Kontynuuj współpracę, gdy partner ją wznowił.
    /// </summary>
    class AcceptApology : IStrategy
    {
        protected readonly Stack<bool> EnemyMoves = new Stack<bool>(3);
        protected readonly Stack<bool> MyMoves = new Stack<bool>(3);
        protected bool LastMove = COOPERATION;
        public bool TakeAction()
        {
            if (EnemyMoves.Count < 4)
            {
                MyMoves.Push(LastMove);
                return LastMove;
            }

            bool ourMove;
            if (true)
            {
                int movesToProcess = 2;
                List<bool> lastOponentMoves = new List<bool>(movesToProcess);
                List<bool> lastMyMoves = new List<bool>(movesToProcess);

                for (int i = 0; i < movesToProcess; i++)
                {
                    lastOponentMoves.Add(EnemyMoves.Pop());
                    lastMyMoves.Add(MyMoves.Pop());
                }

                //our move
                if (lastMyMoves[0] == COOPERATION && lastOponentMoves[0] == BETRAYAL &&
                    lastMyMoves[1] == BETRAYAL && lastOponentMoves[1] == COOPERATION)
                    ourMove = COOPERATION;
                else
                    ourMove = BETRAYAL;

                for (int i = movesToProcess-1; i >= 0 ; i--)
                {
                    EnemyMoves.Push(lastOponentMoves[i]);
                    MyMoves.Push(lastMyMoves[i]);
                }
            }

            MyMoves.Push(ourMove);
            return ourMove;
        }

        public void ProcessOpponentAction(bool opponentAction)
        {
            LastMove = opponentAction;
            EnemyMoves.Push(opponentAction);
        }
    }
}
