using EscapeGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeGame.Models.GameComponents
{
    public class StoryMessage : GameComponent
    {
        #region Variables

        private readonly Character _character1, _character2;
        private readonly CharacterAction _action1, _action2;
        private readonly string[] _message;
        private readonly bool _hasCharacter2;

        #endregion

        #region Main

        public StoryMessage(RoomID room, Character c1, CharacterAction a1, string[] msg) : base(room)
        {
            _character1 = c1;
            _action1 = a1;
            _message = msg;
            _hasCharacter2 = false;
        }

        public StoryMessage(RoomID room, Character c1, CharacterAction a1, 
            Character c2, CharacterAction a2, string[] msg) : this(room, c1, a1, msg)
        {
            _character2 = c2;
            _action2 = a2;
            _hasCharacter2 = true;
        }

        #endregion

        #region Properties

        public Character Character1
        {
            get { return _character1; }
        }

        public string[] Message
        {
            get { return _message; }
        }
        
        public Character Character2
        {
            get { return _character2; }
        }

        public CharacterAction CharacterAction1
        {
            get { return _action1; }
        }

        public CharacterAction CharacterAction2
        {
            get { return _action2; }
        }

        public bool HasCharacter2
        {
            get { return _hasCharacter2; }
        }

        #endregion

    }
}
