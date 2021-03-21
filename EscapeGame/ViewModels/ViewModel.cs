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
        public readonly Game _game;

        public ViewModel(Game game)
        {
            this._game = game;
        }
    }
}
