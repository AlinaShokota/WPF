using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Test.Model;
using Test.ViewModel.Action;

namespace Test.ViewModel
{
    class TempViewModel : INotifyPropertyChanged
    {
        public DispatcherTimer _timer;
        private double currentTemp;
        public double CurrentTemp
        {
            get
            {
                return this.currentTemp;
            }
            set
            {
                if (currentTemp == value)
                    return;
                currentTemp = value;
                OnPropertyChanged();
            }
        }

        private double goalTemp;
        public double GoalTemp
        {
            get
            {
                return goalTemp;
            }
            set
            {
             
                goalTemp = value;
                CheckAndEnableButton();
                OnPropertyChanged();
            }
        }

        public ICommand SubmitButtonCommand { get; set; }

        public TempViewModel()
        {
            CheckAndEnableButton();
            Sensor sensor = new Sensor();
            CurrentTemp = sensor.ActualTemp;
            GoalTemp = CurrentTemp;

            _timer = new DispatcherTimer(DispatcherPriority.Render);
            _timer.Interval = TimeSpan.FromSeconds(3);
            _timer.Tick += (sender, args) =>
            {
                sensor.changeTemp(CurrentTemp, GoalTemp);
                double temp = sensor.ActualTemp;
                CurrentTemp = Math.Round(temp, 2);

            };
            _timer.Start();
            
        }

        public void CheckAndEnableButton()
        {

            bool isEnabled = false;
             string result = string.Empty;
             if (GoalTemp>17&&GoalTemp<28)
             {
                 isEnabled = true;
                 result = string.Format("Goal temperature is set: \n{0}", GoalTemp);
            }
             else
             {
                 isEnabled = false;
             }

             SubmitButtonCommand = new RelayCommand((ob) => { return isEnabled; }, (ob) => { MessageBox.Show(result); });
          
            OnPropertyChanged("SubmitButtonCommand");

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    /*class TempViewModel : INotifyPropertyChanged
    {
        public DispatcherTimer _timer;
        private double currentTemp;
        public double CurrentTemp
        {
            get
            {
                return this.currentTemp;
            }
            set
            {
                if (currentTemp == value)
                    return;
                currentTemp = value;
                OnPropertyChanged();
            }
        }

        public TempViewModel()
        {
            Sensor sensor = new Sensor();
            CurrentTemp = sensor.ActualTemp;

            _timer = new DispatcherTimer(DispatcherPriority.Render);
            _timer.Interval = TimeSpan.FromSeconds(3);
            _timer.Tick += (sender, args) =>
            {
                sensor.changeTemp(CurrentTemp, 21);
                double temp = sensor.ActualTemp;
                CurrentTemp = Math.Round(temp, 2);

            };
            _timer.Start();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }*/
}
