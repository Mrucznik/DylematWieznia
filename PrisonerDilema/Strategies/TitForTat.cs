using static PrisonerDilema.Action;

namespace PrisonerDilema.Strategies
{
    /// <summary>
    /// Wet za wet.
    /// </summary>
    class TitForTat : IStrategy
    {
        private bool _previousAction = COOPERATION;

        public bool TakeAction()
        {
            return _previousAction;
        }

        public void ProcessOpponentAction(bool opponentAction)
        {
            _previousAction = opponentAction;
        }
    }
}
