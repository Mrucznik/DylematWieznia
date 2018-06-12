using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonerDilema
{
    interface IStrategy
    {
        bool TakeAction();
        void ProcessOpponentAction(bool opponentAction);
    }
}
