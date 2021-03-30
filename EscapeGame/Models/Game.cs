using EscapeGame.Enums;
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
            GameStarted?.Invoke(_currentRoom);
        }

    }
}
