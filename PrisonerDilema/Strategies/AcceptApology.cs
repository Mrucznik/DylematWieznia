using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PrisonerDilema.Action;

namespace PrisonerDilema.Strategies
{
    class AcceptApology : CumulativeStrategy
    {
        public override bool TakeAction()
        {
            /*if (EnemyMoves.Count < 4)
            {
                return LastMove;
            }

            List<bool> last2Moves = new List<bool>(4);

            for (int i = 0; i < 3; i++)
                last3Moves.Add(EnemyMoves.Pop());

            if(last3Moves[0] == BETRAYAL && last3Moves[1] == COOPERATION

            MyMoves.Push();*/
            return false;
        }
    }
}
