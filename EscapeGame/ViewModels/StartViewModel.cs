using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeGame.ViewModels
{
    public class StartViewModel : ViewModel,INotifyPropertyChanged
    {
        #region Variables

        #endregion

        #region Main

        public StartViewModel()
        {

        }


        #endregion

        #region Properties

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region EventHandler

        private void NotifyOnPropertyChanged(string propName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #endregion

        #region Commands

        #endregion
    }
}
