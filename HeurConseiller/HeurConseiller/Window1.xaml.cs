using System.Windows;
using HeurConseiller.TimeAdvisor;
using HeurConseiller.TimeAdvisor.AlarmClock;
using HeurConseiller.TimeAdvisor.Timers;
using HeurConseiller.TimeAdvisor.Translation;

namespace HeurConseiller
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private TimeAdvisor.TimeAdvisor _TimeAdvisor;

        public Window1()
        {
            InitializeComponent();

            _TimeAdvisor = new TimeAdvisor.TimeAdvisor(new Microphone(this),
                                                       new TimeTranslation(),
                                                       new AlarmClock(new StandardTimer()),
                                                       new RandomIntervalStrategy());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _TimeAdvisor.Start();
        }
    }
}
