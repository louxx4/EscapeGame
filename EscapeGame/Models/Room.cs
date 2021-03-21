using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeGame.ViewModels;

namespace EscapeGame.Models
{
    public abstract class Room
    {
        #region Variables

        private readonly ViewModel _vm;
        private bool _discovered;

        #endregion

        #region Main

        public Room(ViewModel vm)
        {
            this._vm = vm;
        }


        #endregion

        #region Properties

        public ViewModel PVm
        {
            get { return _vm; }
            set { }
        }

        public bool PDiscovered
        {
            get { return _discovered; }
            set
            {
                _discovered = true;
            }
        }

        #endregion

    }
}
