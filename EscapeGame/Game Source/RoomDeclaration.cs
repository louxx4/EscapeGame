using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeGame.Enums;
using EscapeGame.Models;
using EscapeGame.Models.Rooms;
using EscapeGame.ViewModels;

namespace EscapeGame.GameSource
{
    public class RoomDeclaration
    {
        private Dictionary<RoomID, RoomViewModel> _roomList;

        public RoomDeclaration(Game game)
        {
            _roomList = new Dictionary<RoomID, RoomViewModel>() {
                { RoomID.Start, new StartViewModel(game, new StartRoom(RoomID.Start)) },
                { RoomID.Story, new StoryViewModel(game, new StoryRoom(RoomID.Story)) },
                { RoomID.Kitchen, new KitchenViewModel(game, new KitchenRoom(RoomID.Kitchen)) }
            };
        }

        public RoomViewModel GetVM(RoomID id)
        {
            return _roomList[id];
        }

        public Room GetRoom(RoomID id)
        {
            return GetVM(id).PRoom;
        }

    }
}
