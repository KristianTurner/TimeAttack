using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimeAttack.Annotations;

namespace TimeAttack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 50; i++)
                {
                    System.Threading.Thread.Sleep(100);
                    MyValue = i.ToString();
                }
            });
        }

        private string myValue;
        public string MyValue
        {
            get { return myValue; }
            set
            {
                myValue = value;
                RaisePropertyChanged("MyValue");
            }
        }

        private void RaisePropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            MyValue = "Hello World";
            switch (e.Key)
            {
                case Key.Space:
                    
                    break;
                case Key.P:

                    break;
                    
                case Key.O:
                    break;

                default:
                    break;
            }
        }
    }
}
