using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using EscapeGame.Enums;
using CommandHelper;
using EscapeGame.Models;
using EscapeGame.Models.Rooms;

namespace EscapeGame.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Variables

        private bool _isMenuOpen, _isWindowMaximized, _isHelpShown;
        private WindowState _windowState;
        private RoomID _roomID = RoomID.Start;
        private Dictionary<RoomID, Room> _roomList;
        private readonly Game _game = new Game();

        #endregion

        #region Main

        public MainViewModel()
        {
            _roomList = new Dictionary<RoomID, Room>() {
                { RoomID.Start, new StartRoom(new StartViewModel(_game)) },
                { RoomID.Story, new StoryRoom(new StoryViewModel(_game)) },
                { RoomID.Kitchen, new KitchenRoom(new KitchenViewModel(_game)) }
            };
            Register4Events();
        }

        private void Register4Events()
        {
            _game.GameStarted += SetComponent;
            _game.ComponentFinished += SetComponent;
        }
        
        private void SetComponent(GameComponent gc)
        {
            //PRoomID = gc.PRoomID;
            //_roomList[gc.PRoomID].PVm.SetComponent(gc);
            PRoomID = RoomID.Kitchen;
        }

        private void CloseApp()
        {
            Application.Current.Shutdown();
        }

        private void MinimizeWindow()
        {
            PWindowState = WindowState.Minimized;
        }

        private void ChangeRoom(int roomID)
        {
            PRoomID = (RoomID)roomID;
        }

        #endregion

        #region Properties

        public RoomID PRoomID
        {
            get { return _roomID; }
            set
            {
                _roomID = value;
                NotifyOnPropertyChanged("PRoomID");
            }
        }

        public Room PRoom
        {
            get
            {
                if (_roomList.Count > 0) return _roomList[PRoomID];
                else return null;
            }
        }

        public bool PIsMenuOpen
        {
            get { return _isMenuOpen; }
            set
            {
                _isMenuOpen = value;
                NotifyOnPropertyChanged("PIsMenuOpen");
            }
        }

        public WindowState PWindowState
        {
            get
            { return _windowState; }
            set
            {
                if (_windowState != value)
                {
                    _windowState = value;
                    NotifyOnPropertyChanged("PWindowState");
                }
            }
        }

        public bool PIsMaximized
        {
            get
            { return _isWindowMaximized; }
            set
            {
                if (_isWindowMaximized != value)
                {
                    _isWindowMaximized = value;
                    if (value) PWindowState = WindowState.Maximized;
                    else PWindowState = WindowState.Normal;
                    NotifyOnPropertyChanged("PIsMaximized");
                }
            }
        }

        public bool PShowHelp
        {
            get { return _isHelpShown; }
            set
            {
                _isHelpShown = value;
                NotifyOnPropertyChanged("PShowHelp");
            }
        }

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

        public ICommand CmdClose
        {
            get
            {
                return new RelayCommand(o => CloseApp());
            }
        }

        public ICommand CmdMinimize
        {
            get
            {
                return new RelayCommand(o => MinimizeWindow());
            }
        }

        public ICommand CmdChangeRoom
        {
            get
            {
                return new RelayCommand<int>(param => ChangeRoom(param));
            }
        }

        #endregion
    }
}
