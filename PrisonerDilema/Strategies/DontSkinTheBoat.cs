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
    class DontSkinTheBoat : CumulativeStrategy
    {
        public override bool TakeAction()
        {
            if (EnemyMoves.Count < 4)
            {
                return LastMove;
            }

            bool ourMove;
            if (LastMove == BETRAYAL)
            {
                Stack<bool> last4Moves = new Stack<bool>(4);

                for (int i = 0; i < 4; i++)
                    last4Moves.Push(EnemyMoves.Pop());

                ourMove = last4Moves.Count(move => move == COOPERATION) > 3 ? COOPERATION : BETRAYAL;

                for (int i = 0; i < 4; i++)
                    EnemyMoves.Push(last4Moves.Pop());
                    
            }
            else
            {
                ourMove = COOPERATION;
            }

            return ourMove;
        }
    }
}
