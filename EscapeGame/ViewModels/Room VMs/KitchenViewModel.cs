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

        public KitchenViewModel() : base() { }

        public override void SetComponent(GameComponent c)
        {
            Enter();
            //Invoke action on enter, if intended for the game component
            if (c?.PInvokeOnEnter == true)
            {
                GetObject(c.PInvokeObjectID).PVM.InvokeOnEnter(c.PInvokeActionID);
            }
        }

        #endregion

    }
}
