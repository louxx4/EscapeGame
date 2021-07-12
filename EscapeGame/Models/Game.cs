using EscapeGame.Enums;
using EscapeGame.GameSource;
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
        public event ComponentFinishedEventHandler ComponentFinished;

        #region Variables

        private readonly GameComponentSequence _sequence;
        private readonly RoomObjectDeclaration _objectDeclaration;
        
        #endregion

        #region Main

        public Game() {
            _sequence = new GameComponentSequence();
            _objectDeclaration = new RoomObjectDeclaration();
        }

        public void Start()
        {
            GameStarted?.Invoke(GetNextComponent());
        }

        public void IsComponentFinished()
        {
            ComponentFinished?.Invoke(GetNextComponent());
        }

        public List<RoomObject> GetObjects(RoomID id)
        {
            return _objectDeclaration.Get(id);
        } 

        public GameComponent GetNextComponent()
        {
            return _sequence.GetNextComponent();
        }

        #endregion
    }
}
