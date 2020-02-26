using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using PrisonerDilema.Strategies;
using static PrisonerDilema.Action;

namespace PrisonerDilema
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Prisoner _prisoner1, _prisoner2;
        private bool _shouldEnd;
        public MainWindow()
        {
            InitializeComponent();
            _prisoner1 = new Prisoner(new TitForTat());
            _prisoner2 = new Prisoner(new TitForTat());
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            int iterations = Int32.Parse(NumberOfIterations.Text);
            SelectStrategy(Prisoner1Strategy, _prisoner1);
            SelectStrategy(Prisoner2Strategy, _prisoner2);
            Simulate(_prisoner1, _prisoner2, iterations, SlowMode.IsChecked ?? false);
            _shouldEnd = false;
        }
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            _shouldEnd = true;
        }

        private void SelectStrategy(ComboBox comboBox, Prisoner prisoner)
        {
            switch (comboBox.Text)
            {
                case "Wet za wet":
                {
                    prisoner.SetStrategy(new TitForTat());
                    break;
                }
                case "Wet za dwa wet":
                {
                    prisoner.SetStrategy(new TitFor2Tat());
                    break;
                }
                case "Wet za dwa wet z 10% prawdopodobieństwem na zdradę":
                {
                    prisoner.SetStrategy(new TitForTatWithProbability(BETRAYAL, 0.1));
                    break;
                }
                case "Wet za dwa wet z 10% prawdopodobieństwem na współpracę":
                {
                    prisoner.SetStrategy(new TitForTatWithProbability(COOPERATION, 0.1));
                    break;
                }
                case "Nie zatapiaj łodzi":
                {
                    prisoner.SetStrategy(new DontSkinTheBoat());
                    break;
                }
                case "Zapominaj":
                {
                    prisoner.SetStrategy(new CooperateStrategy());
                    break;
                }
                case "Trzymaj się rozwiązania rutynowego":
                {
                    prisoner.SetStrategy(new RutineStrategy());
                    break;
                }
                case "Zawsze zdradzaj":
                {
                    prisoner.SetStrategy(new AlwaysBetrayStrategy());
                    break;
                }
                case "Zawsze współpracuj":
                {
                    prisoner.SetStrategy(new AlwaysCooperateStrategy());
                    break;
                }
                case "Losowo":
                {
                    prisoner.SetStrategy(new RandomStrategy());
                    break;
                }
            }
        }

        private void UpdateGUI(string text)
        {
            ListBoxItem roundText = new ListBoxItem { Content = text };
            Display.Items.Add(roundText);
            Display.SelectedIndex = Display.Items.Count - 1;
            Display.ScrollIntoView(Display.SelectedItem);

            Prisoner1SumOfYears.Text = _prisoner1.Score.ToString();
            Prisoner2SumOfYears.Text = _prisoner2.Score.ToString();
            PrisonersSumOfYears.Text = (_prisoner1.Score + _prisoner2.Score).ToString();
        }

        private void CalculateScore(bool prisoner1Choice, bool prisoner2Choice)
        {
            if (prisoner1Choice == COOPERATION && prisoner2Choice == COOPERATION)
            {
                _prisoner1.Score += .5f;
                _prisoner2.Score += .5f;
            }
            else if (prisoner1Choice == COOPERATION && prisoner2Choice == BETRAYAL)
            {
                _prisoner1.Score += 10f;
            }
            else if (prisoner1Choice == BETRAYAL && prisoner2Choice == COOPERATION)
            {
                _prisoner2.Score += 10f;
            }
            else if (prisoner1Choice == BETRAYAL && prisoner2Choice == BETRAYAL)
            {
                _prisoner1.Score += 5f;
                _prisoner2.Score += 5f;
            }
        }

        private void Betray(object sender, RoutedEventArgs e)
        {
            var prisoner1Choice = _prisoner1.TakeAction();
            var prisoner2Choice = BETRAYAL;
            _prisoner1.ProcessOpponentAction(prisoner2Choice);
            CalculateScore(prisoner1Choice, prisoner2Choice);
            string p1 = prisoner1Choice ? "Współpracuje" : "Zdradził";
            string p2 = prisoner2Choice ? "Współpracuje" : "Zdradził";
            UpdateGUI($"W1: {p1}, W2: {p2}");

        }

        private void Cooperate(object sender, RoutedEventArgs e)
        {
            var prisoner1Choice = _prisoner1.TakeAction();
            var prisoner2Choice = COOPERATION;
            _prisoner1.ProcessOpponentAction(prisoner2Choice);
            CalculateScore(prisoner1Choice, prisoner2Choice);
            string p1 = prisoner1Choice ? "Współpracuje" : "Zdradził";
            string p2 = prisoner2Choice ? "Współpracuje" : "Zdradził";
            UpdateGUI($"W1: {p1}, W2: {p2}");
        }

        private void EraseData(object sender, RoutedEventArgs e)
        {
            Display.Items.Clear();
            _prisoner1.Score = 0;
            _prisoner2.Score = 0;

            Prisoner1SumOfYears.Text = _prisoner1.Score.ToString();
            Prisoner2SumOfYears.Text = _prisoner2.Score.ToString();
            PrisonersSumOfYears.Text = (_prisoner1.Score + _prisoner2.Score).ToString();
        }


        private async void Simulate(Prisoner prisoner1, Prisoner prisoner2, int iterations, bool slowMode)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < iterations; i++)
                {
                    if (_shouldEnd) break;
                    
                    var prisoner1Choice = _prisoner1.TakeAction();
                    var prisoner2Choice = _prisoner2.TakeAction();
                    _prisoner1.ProcessOpponentAction(prisoner2Choice);
                    _prisoner2.ProcessOpponentAction(prisoner1Choice);

                    CalculateScore(prisoner1Choice, prisoner2Choice);

                    Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                        (ThreadStart) delegate()
                        {
                            string p1 = prisoner1Choice ? "Współpracuje" : "Zdradził";
                            string p2 = prisoner2Choice ? "Współpracuje" : "Zdradził";
                            UpdateGUI($"W1: {p1}, W2: {p2}");
                        });
                    if(slowMode) {
                        Thread.Sleep(100);
                    }
                }
            });

        }
    }
}
