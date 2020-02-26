namespace PrisonerDilema
{
    class Prisoner : IStrategy
    {
        private IStrategy _strategy;
        public float Score { get; set; }

        public Prisoner(IStrategy strategy)
        {
            SetStrategy(strategy);
        }


        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }
        
        public bool TakeAction() => _strategy.TakeAction();

        public void ProcessOpponentAction(bool opponentAction) => _strategy.ProcessOpponentAction(opponentAction);
    }
}
