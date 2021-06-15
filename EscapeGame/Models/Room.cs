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

        private readonly ViewModel _vm;
        private bool _discovered, _visible;

        #endregion

        #region Main

        public Room(ViewModel vm)
        {
            _vm = vm;
        }


        #endregion

        #region Properties

        public ViewModel PVm
        {
            get { return _vm; }
        }

        public bool PDiscovered
        {
            get { return _discovered; }
            set { _discovered = value; }
        }

        public bool PVisible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public Visibility PDiscoveredVisibility
        {
            get { return _discovered ? Visibility.Visible : Visibility.Hidden; }
        }

        #endregion

    }
}
