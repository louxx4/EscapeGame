using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EscapeGame.ViewModels;

namespace EscapeGame.Models
{
    public abstract class Room
    {
        #region Variables

        private readonly RoomViewModel _vm;
        private bool _discovered = false;

        #endregion

        #region Main

        public Room(RoomViewModel vm)
        {
            _vm = vm;
            _vm.PRoom = this;
        }

        public void Enter()
        {
            Discover();
        }
        
        private void Discover()
        {
            if (!_discovered)
            {
                _discovered = true;
                PVm.PDiscovered = true;
            }
        }

        #endregion

        #region Properties

        public RoomViewModel PVm
        {
            get { return _vm; }
        }

        #endregion

    }
}
