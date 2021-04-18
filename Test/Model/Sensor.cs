using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Test.Model
{
    public class Sensor : INotifyPropertyChanged
    {

        private double actualTemp;
        public double ActualTemp
        {
            get
            {
                return actualTemp;
            }
            set
            {
                actualTemp = value;
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
                OnPropertyChanged();
            }
        }

        public Sensor()
        {
            //ActualTemp = measureTemp();
            
            double temp = measureTemp();
            ActualTemp = Math.Round(temp, 2);

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private double measureTemp()
        {
            Random rnd = new Random();
            double val = rnd.Next(18, 30);
            return val;
        }

        public void changeTemp(double actual, double goal)
        {
            if (actual<goal)
            {
                ActualTemp += 0.1;
            }
            else if (actual>goal)
            {
                ActualTemp -= 0.1;
            }
            else
            {

            }
        }

    }
}
/*
public class Sensor : INotifyPropertyChanged
{

    private bool heat;
    public bool Heat
    {
        get
        {
            return heat;
        }
        set
        {
            heat = value;
            OnPropertyChanged();
        }
    }
    private double actualTemp;
    public double ActualTemp
    {
        get
        {
            return actualTemp;
        }
        set
        {
            if (ActualTemp > GoalTemp)
            {
                heat = false;
            }
            else
            {
                heat = true;
            }
            actualTemp = value;
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
            if (GoalTemp > ActualTemp)
            {
                heat = true;
            }
            else
            {
                heat = false;
            }
            goalTemp = value;
            OnPropertyChanged();
        }
    }

    public Sensor()
    {
        //ActualTemp = measureTemp();

        double temp = measureTemp();
        ActualTemp = Math.Round(temp, 2);

    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName]string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }

    private double measureTemp()
    {
        Random rnd = new Random();
        double val = rnd.Next(18, 30);
        return val;
    }

    public void changeTemp(double actual, double goal)
    {
        if (actual < goal)
        {
            ActualTemp += 0.1;
        }
        else if (actual > goal)
        {
            ActualTemp -= 0.1;
        }
        else
        {

        }
    }

}





/*public class Sensor : INotifyPropertyChanged
    {
        private double currentTemp;

        public DispatcherTimer _timer;

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

        public Sensor()
        {
            _timer = new DispatcherTimer(DispatcherPriority.Render);
            _timer.Interval = TimeSpan.FromSeconds(3);
            _timer.Tick += (sender, args) =>
            {
                double temp = CurrentTemp + 0.1;
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

    } */
