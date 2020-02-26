using static PrisonerDilema.Action;

namespace PrisonerDilema.Strategies
{
    /// <summary>
    /// Zawsze zdradzaj
    /// </summary>
    class AlwaysBetrayStrategy : IStrategy
    {
        public bool TakeAction()
        {
            return BETRAYAL;
        }

        public void ProcessOpponentAction(bool opponentAction)
        {
            //do nothing
        }
    }
}
