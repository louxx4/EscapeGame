using EscapeGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeGame.ViewModels
{
    public abstract class RoomViewModel : INotifyPropertyChanged
    {
        private readonly Game _game;
        private Room _room;
        private bool _discovered;

        #region Main

        public RoomViewModel(Game game)
        {
            _game = game;
        }

        public abstract void SetComponent(GameComponent c);

        #endregion

        #region Properties

        protected Game PGame
        {
            get { return _game; }
        }

        public Room PRoom
        {
            get { return _room; }
            set { if (_room == null) _room = value; }
        }

        public bool PDiscovered
        {
            get { return _discovered; }
            set
            {
                if (!_discovered) _discovered = value;
                NotifyOnPropertyChanged("PDiscovered");
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
