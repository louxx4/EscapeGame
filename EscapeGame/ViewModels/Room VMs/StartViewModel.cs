using CommandHelper;
using EscapeGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EscapeGame.ViewModels
{
    public class StartViewModel : ViewModel, INotifyPropertyChanged
    {
        #region Variables

        #endregion

        #region Main

        public StartViewModel(Game game) : base(game) { }

        private void StartGame()
        {
            PGame.Start();
        }

        public override void SetComponent(GameComponent c) { }

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

        public ICommand CmdStart
        {
            get
            {
                return new RelayCommand(o => StartGame());
            }
        }
        #endregion
    }
}
