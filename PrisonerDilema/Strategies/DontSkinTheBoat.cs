using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PrisonerDilema.Action;

namespace PrisonerDilema.Strategies
{
    /// <summary>
    /// Wet za wet, ale przedłużaj współpracę po trzech kolejnych współpracach.
    /// </summary>
    class DontSkinTheBoat : IStrategy
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
            if (LastMove == BETRAYAL)
            {
                int movesToProcess = 4;
                Stack<bool> lastOponentMoves = new Stack<bool>(movesToProcess);
                Stack<bool> lastMyMoves = new Stack<bool>(movesToProcess);

                for (int i = 0; i < movesToProcess; i++)
                {
                    lastOponentMoves.Push(EnemyMoves.Pop());
                    lastMyMoves.Push(MyMoves.Pop());
                }

                //our move set
                if (lastOponentMoves.Count(move => move == COOPERATION) >= movesToProcess-1 && lastMyMoves.Count(move => move == COOPERATION) >= movesToProcess-1)
                    ourMove = COOPERATION;
                else
                    ourMove = BETRAYAL;

                for (int i = 0; i < movesToProcess; i++)
                {
                    EnemyMoves.Push(lastOponentMoves.Pop());
                    MyMoves.Push(lastMyMoves.Pop());
                }
                    
            }
            else
            {
                ourMove = COOPERATION;
            }

            MyMoves.Push(ourMove);
            return ourMove;
        }

        public virtual void ProcessOpponentAction(bool opponentAction)
        {
            LastMove = opponentAction;
            EnemyMoves.Push(opponentAction);
        }
    }
}
