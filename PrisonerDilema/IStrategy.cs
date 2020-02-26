namespace PrisonerDilema
{
    interface IStrategy
    {
        bool TakeAction();
        void ProcessOpponentAction(bool opponentAction);
    }
}
