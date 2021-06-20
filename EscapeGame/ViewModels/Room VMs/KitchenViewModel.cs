using CommandHelper;
using EscapeGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeGame.ViewModels
{
    public class KitchenViewModel : RoomViewModel, INotifyPropertyChanged
    {
        #region Variables

        #endregion

        #region Main

        public KitchenViewModel(Game game) : base(game) { }

        public override void SetComponent(GameComponent c)
        {
            PRoom.Enter();
        }

        #endregion



    }
}
