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

        public void SetComponentFinished(string[] message = null)
        {
            ComponentFinished?.Invoke(GetNextComponent(message));
        }

        public List<RoomObject> GetObjects(RoomID id)
        {
            return _objectDeclaration.Get(id);
        } 

        public GameComponent GetNextComponent(string[] message = null)
        {
            return _sequence.GetNextComponent(message);
        }

        #endregion

        #region Events 

        public event GameStartedEventHandler GameStarted;
        public event ComponentFinishedEventHandler ComponentFinished;

        #endregion
    }
}
