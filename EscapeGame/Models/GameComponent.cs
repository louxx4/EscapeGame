using EscapeGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeGame.Models
{
    public abstract class GameComponent
    {

        private readonly RoomID _room;

        public GameComponent(RoomID room)
        {
            _room = room;
        }

        public RoomID PRoomID
        {
            get { return _room;  }
        }

    }
}
