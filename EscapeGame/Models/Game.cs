using EscapeGame.Enums;
using EscapeGame.Models.StoryComponents;
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
        private int _componentIndex;

        public Game()
        {
            _currentRoom = RoomID.Story;
        }

        public void Start()
        {
            GameStarted?.Invoke(_currentRoom);
        }

        public StoryComponent getNextComponent()
        {
            return null;
        }

        private StoryComponent getComponent()
        {
            return new StoryMessage()
        }

    }
}
