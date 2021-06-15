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

        #region Variables

        private readonly GameComponentSequence _sequence;
        
        #endregion

        #region Main

        public Game() {
            _sequence = new GameComponentSequence();
        }

        public void Start()
        {
            GameStarted?.Invoke(GetNextComponent());
        }

        public GameComponent GetNextComponent()
        {
            return _sequence.GetNextComponent();
        }

        #endregion
    }
}
