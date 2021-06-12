using EscapeGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeGame.ViewModels
{
    public abstract class ViewModel
    {
        private readonly Game _game;

        public ViewModel(Game game)
        {
            this._game = game;
        }

        public Game PGame
        {
            get { return _game; }
        }

        public abstract void SetComponent(GameComponent c);
    }
}
