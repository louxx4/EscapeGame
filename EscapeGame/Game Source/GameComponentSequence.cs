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
            new OpenRiddle(RoomID.Kitchen),
            new StoryMessage(RoomID.Story, Character.Robs, CharacterAction.Talking,null),
            new OpenRiddle(RoomID.Kitchen)
        };

        #endregion

        #region Main

        public GameComponent GetNextComponent(string[] message)
        {
            GameComponent next = _sequenceDefinition[++_currentIndex];
            if (message != null && next.GetType() == typeof(StoryMessage))
            {
                StoryMessage storyMessage = (StoryMessage)next;
                storyMessage.Message = message;
            }
            return next;
        }

        #endregion

    }
}
