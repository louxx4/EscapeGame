using EscapeGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeGame.Models
{
    public abstract class GameComponent
    {

        #region Variables
        private readonly RoomID _room;
        private readonly bool _invokeOnEnter;
        private readonly ObjectID _invokeObject;
        private readonly ActionID _invokeAction;
        #endregion

        public GameComponent(RoomID room)
        {
            _room = room;
            _invokeOnEnter = false;
        }

        public GameComponent(RoomID room, ObjectID roomobject, ActionID action) : this(room)
        {
            _invokeObject = roomobject;
            _invokeAction = action;
            _invokeOnEnter = true;
        }

        #region Properties

        public RoomID PRoomID
        {
            get { return _room; }
        }

        public ObjectID PInvokeObjectID
        {
            get { return _invokeObject; }
        }

        public ActionID PInvokeActionID
        {
            get { return _invokeAction; }
        }

        public bool PInvokeOnEnter
        {
            get { return _invokeOnEnter; }
        }

        #endregion

    }
}
