using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EscapeGame.Enums;
using EscapeGame.ViewModels;

namespace EscapeGame.Models
{
    public abstract class Room
    {
        #region Variables

        private bool _discovered;
        private readonly RoomID _id;

        #endregion

        public Room(RoomID id)
        {
            _id = id;
        }

        public void Enter()
        {
            PDiscovered = true;
        }

        public RoomID GetID()
        {
           return _id;
        }

        #region Properties

        public bool PDiscovered
        {
            get { return _discovered; }
            set
            {
                _discovered = value;
            }
        }

        #endregion

    }
}
