using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoWayAccepter.Entities
{
    public class State: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _stateName;

        public string StateName
        {
            get { return _stateName; }
            set { _stateName = value; NotifyPropertyChanged("StateName"); }
        }

        private void NotifyPropertyChanged(string str)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(str));
            }
        }

        private string _direction;

        public string Module
        {
            get { return _direction; }
            set { _direction = value; NotifyPropertyChanged("Module"); }
        }

    }
}
