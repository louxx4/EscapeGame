using EscapeGame.Enums;
using EscapeGame.Models.GameComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeGame.Models;

namespace EscapeGame.GameSource
{
    public class GameComponentSequence
    {
        #region Variables

        private int _currentIndex = -1;
        private readonly List<GameComponent> _sequenceDefinition = new List<GameComponent> {
            //new StoryMessage(RoomID.Story, Character.Robs, CharacterAction.Talking,
            //    new string[] {"Hallo und herzlich willkommen zu Escape la familia.",
            //    "Mein Name ist Robs und ich werde Sie durch den groben Spielablauf führen."}),
            new OpenRiddle(RoomID.Kitchen)
        };

        #endregion

        #region Main

        public GameComponent GetNextComponent()
        {
            _currentIndex++;
            return _sequenceDefinition[_currentIndex];
        }

        #endregion

    }
}
