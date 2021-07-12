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
        #region Main

        public KitchenViewModel(Game game, Room room) : base(game, room) { }

        public override void SetComponent(GameComponent c)
        {
            Enter();
        }

        #endregion

    }
}
