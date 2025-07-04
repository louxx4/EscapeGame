﻿using CommandHelper;
using EscapeGame.Enums;
using EscapeGame.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace EscapeGame.ViewModels
{
    public abstract class RoomViewModel : INotifyPropertyChanged
    {
        private readonly Game _game;
        private Room _room;
        private bool _discovered, _isOpen;
        private readonly List<RoomObject> _objects;
        private PopUpViewModel _popUpVM = new PopUpViewModel();

        #region Main

        public RoomViewModel(Game game, Room room)
        {
            _game = game;
            _room = room;
            _objects = game.GetObjects(room.GetID());

            Register4Events();
        }

        public RoomViewModel() { }

        private void Register4Events()
        {
            _objects.ForEach(roomObject =>
            {
                if (roomObject.PVM != null) roomObject.PVM.ComponentFinished += OnComponentFinished;
            });
        }

        private void OnComponentFinished(string[] message)
        {
            _game.SetComponentFinished(message);
        }

        public abstract void SetComponent(GameComponent c);

        public RoomObject GetObject(ObjectID id)
        {
            return _objects.Find(o => o.PID == id);
        }

        public void Enter()
        {
            _room.Enter();
        }

        private void OpenPopUp(int objectIndex)
        {
            if (PObjects.Count > objectIndex)
            {
                RoomObject obj = PObjects[objectIndex];
                if (obj != null)
                {
                    //TODO Unterscheidung Image / Control
                    PPopUpVM = new PopUpViewModel(obj.PID, obj.PTooltip, obj.PVM); //obj.PImage);
                    PIsOpen = true;
                }
            }
        }

        #endregion

        #region Properties

        public List<RoomObject> PObjects
        {
            get { return _objects; }
        }

        public PopUpViewModel PPopUpVM
        {
            get { return _popUpVM; }
            set
            {
                _popUpVM = value;
                NotifyOnPropertyChanged("PPopUpVM");
            }
        }

        protected Game PGame
        {
            get { return _game; }
        }

        public bool PIsOpen
        {
            get { return _isOpen; }
            set
            {
                _isOpen = value;
                NotifyOnPropertyChanged("PIsOpen");
            }
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

        #region Commands

        public ICommand CmdObjectClicked
        {
            get { return new RelayCommand<int>(param => OpenPopUp(param)); }
        }

        #endregion
    }
}
