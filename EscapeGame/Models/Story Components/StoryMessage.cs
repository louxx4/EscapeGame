using EscapeGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeGame.Models.StoryComponents
{
    public class StoryMessage : StoryComponent
    {
        #region Variables

        private readonly Character _character1, _character2;
        private readonly string _message;

        #endregion

        #region Main

        public StoryMessage(RoomID room, Character c1, string msg) : base(room)
        {
            _character1 = c1;
            _message = msg;
        }

        public StoryMessage(RoomID room, Character c1, Character c2, string msg) : this(room, c1, msg)
        {
            _character2 = c2;
        }

        #endregion

    }
}
