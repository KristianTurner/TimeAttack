using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
                    System.Threading.Thread.Sleep(10);
                    Player1String = i.ToString();
                }
            });
        }

        private string _player1String;
        public string Player1String
        {
            get { return _player1String; }
            set
            {
                _player1String = value;
                RaisePropertyChanged("Player1string");
            }
        }

        private string player2string;

        public string Player2String
        {
            get {
                return this.player2string;
                }
            set
            {
                player2string = value;
                RaisePropertyChanged("Player2string");
            }
        }

        private bool _player1Tag;
        private bool _player2Tag;
        private bool _running;

        private void RaisePropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private Stopwatch _timeAttack = new Stopwatch();

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Space:
                    if (!_running)
                    {
                        _player1Tag = _player2Tag = true;
                        _running = true;
                        
                        _timeAttack.Start();
                        Task.Factory.StartNew(() =>
                        {
                            while (_player1Tag || _player2Tag)
                            {
                                System.Threading.Thread.Sleep(25);
                                if (_player1Tag)
                                {
                                    Player1String = _timeAttack.Elapsed.TotalSeconds > 60 ? _timeAttack.Elapsed.ToString("m\\:ss") : $"{_timeAttack.Elapsed.Seconds}";
                                }
                                if (_player2Tag)
                                {
                                    Player2String = _timeAttack.Elapsed.TotalSeconds > 60 ? _timeAttack.Elapsed.ToString("m\\:ss") : $"{_timeAttack.Elapsed.Seconds}";
                                }
                            }
                            _timeAttack.Stop();
                            _timeAttack.Reset();
                        });
                    }
                    else
                    {
                        if (!_player1Tag && !_player2Tag)
                        {
                            Player1String = "0";
                            Player2String = "0";
                            _running = false;
                        }
                    }


                    break;
                case Key.P:
                    if (_running && _player1Tag)
                    {
                        _player1Tag = false;
                        Player1String = _timeAttack.Elapsed.TotalSeconds > 60 ? _timeAttack.Elapsed.ToString("m\\:ss") : $"{_timeAttack.Elapsed.Seconds}";
                    }


                    break;
                    
                case Key.O:
                    if (_running && _player2Tag)
                    {
                        _player2Tag = false;
                        Player2String = _timeAttack.Elapsed.TotalSeconds > 60 ? _timeAttack.Elapsed.ToString("m\\:ss") : $"{_timeAttack.Elapsed.Seconds}";
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
