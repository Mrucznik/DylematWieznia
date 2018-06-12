using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
        public MainWindow()
        {
            InitializeComponent();
            _prisoner1 = new Prisoner(new TitForTat());
            _prisoner2 = new Prisoner(new TitForTat());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var prisoner1Choice = _prisoner1.TakeAction();
            var prisoner2Choice = _prisoner2.TakeAction();

            ListBoxItem roundText = new ListBoxItem {Content = $"W1: {prisoner1Choice}, W2: {prisoner2Choice}"};
            Display.Items.Add(roundText);

            _prisoner1.ProcessOpponentAction(prisoner2Choice);
            _prisoner2.ProcessOpponentAction(prisoner1Choice);

            if (prisoner1Choice == COOPERATION && prisoner2Choice == COOPERATION)
            {
                
            }


            Prisoner1SumOfYears.Text = (Int32.Parse(Prisoner1SumOfYears.Text) + 1).ToString();
        }
    }
}
