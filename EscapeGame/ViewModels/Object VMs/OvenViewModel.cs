using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeGame.ViewModels
{
    public class OvenViewModel : INotifyPropertyChanged
    {
        private bool _ovenOn;

        #region Main

        public OvenViewModel() { }

        #endregion

        #region Properties

        public bool POvenOn
        {
            get { return _ovenOn; }
            set { 
                _ovenOn = value;
                NotifyOnPropertyChanged("POvenOn");
            }
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region EventHandler

        protected void NotifyOnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #endregion
    }
}
