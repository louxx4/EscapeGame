using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeGame.ViewModels;

namespace EscapeGame.Models
{
    public class Room
    {
        #region Variables

        private int _id;
        private ViewModel _vm;

        #endregion

        #region Main

        public Room()
        {

        }

        #endregion

        #region Properties

        public ViewModel PVm
        {
            get { return _vm; }
            set
            {
                _vm = value;
            }
        }

        #endregion

    }
}
