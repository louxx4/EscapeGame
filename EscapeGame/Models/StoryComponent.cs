using EscapeGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeGame.Models
{
    public abstract class StoryComponent
    {

        private RoomID _room;

        public StoryComponent(RoomID room)
        {
            _room = room;
        }

    }
}
