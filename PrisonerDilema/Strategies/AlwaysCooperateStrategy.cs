using static PrisonerDilema.Action;

namespace PrisonerDilema.Strategies
{
    /// <summary>
    /// Zawsze współpracuj
    /// </summary>
    class AlwaysCooperateStrategy : IStrategy
    {
        public bool TakeAction()
        {
            return COOPERATION;
        }

        public void ProcessOpponentAction(bool opponentAction)
        {
            //do nothing
        }
    }
}
