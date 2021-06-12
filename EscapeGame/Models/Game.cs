using EscapeGame.Enums;
using EscapeGame.Models.GameComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeGame.Models
{
    public class Game
    {
        public event GameStartedEventHandler GameStarted;
        private RoomID _currentRoom;

        public Game()
        {
            _currentRoom = RoomID.Story;
        }

        public void Start()
        {
            GameStarted?.Invoke(GetNextComponent());
        }

        public GameComponent GetNextComponent()
        {
            return new StoryMessage(RoomID.Story, Character.Robs, CharacterAction.Talking,
                new string[] {"Hallo und herzlich willkommen zu Escape la familia.",
                "Mein Name ist Robs und ich werde Sie durch den groben Spielablauf führen."});
        }

    }
}
