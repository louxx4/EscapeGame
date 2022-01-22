using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeGame.ViewModels
{
    public abstract class ObjectViewModel : INotifyPropertyChanged
    {

        #region Main

        public ObjectViewModel() { }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;
        public event ComponentFinishedEventHandler ComponentFinished;

        #endregion

        #region EventHandler

        protected void NotifyOnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        protected void TriggerOnComponentFinished(string[] message)
        {
            ComponentFinished?.Invoke(message);
        }

        #endregion
    }
}
