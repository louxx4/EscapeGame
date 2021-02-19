using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommandHelper;
using EscapeGame.Models;

namespace EscapeGame.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Variables

        private bool _isMenuOpen;
        private ICommand _cmdOpenMenu;

        #endregion

        #region Main

        public MainViewModel()
        {

        }

        private void OpenMenu()
        {
            PIsMenuOpen = true;
        }

        #endregion

        #region Properties

        public bool PIsMenuOpen
        {
            get { return _isMenuOpen; }
            set
            {
                _isMenuOpen = value;
                notifyOnPropertyChanged("PIsMenuOpen");
            }
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region EventHandler

        private void notifyOnPropertyChanged(string propName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #endregion

        #region Commands

        public ICommand CmdOpenMenu
        {
            get
            {
                return _cmdOpenMenu = new RelayCommand(c => OpenMenu());
            }
        }

        #endregion
    }
}
