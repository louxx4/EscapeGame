using EscapeGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeGame.Models
{
    public delegate void GameStartedEventHandler(GameComponent startComponent);
    public delegate void ComponentFinishedEventHandler(GameComponent nextComponent);

}
