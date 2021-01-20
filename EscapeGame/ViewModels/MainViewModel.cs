using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeGame.Models;

namespace EscapeGame.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void notifyOnPropertyChanged(string propName) {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public MainViewModel()
        {

        }
    }
}
