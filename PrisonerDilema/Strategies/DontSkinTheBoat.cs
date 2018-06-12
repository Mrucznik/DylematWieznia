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
        private readonly Stack<bool> _enemyMoves = new Stack<bool>(3);
        private bool _lastMove = COOPERATION;


        public bool TakeAction()
        {
            if (_enemyMoves.Count < 4)
            {
                return _lastMove;
            }

            bool ourMove;
            if (_lastMove == BETRAYAL)
            {
                Stack<bool> last4Moves = new Stack<bool>(4);

                for (int i = 0; i < 4; i++)
                    last4Moves.Push(_enemyMoves.Pop());

                ourMove = last4Moves.Count(move => move == COOPERATION) > 3 ? COOPERATION : BETRAYAL;

                for (int i = 0; i < 4; i++)
                    _enemyMoves.Push(last4Moves.Pop());
                    
            }
            else
            {
                ourMove = COOPERATION;
            }

            return ourMove;
        }

        public void ProcessOpponentAction(bool opponentAction)
        {
            _lastMove = opponentAction;
            _enemyMoves.Push(opponentAction);
        }
    }
}
