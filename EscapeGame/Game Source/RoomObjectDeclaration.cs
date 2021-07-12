using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeGame.Models;
using EscapeGame.Enums;

namespace EscapeGame.GameSource
{
    public class RoomObjectDeclaration
    {
        private readonly Dictionary<RoomID, List<RoomObject>> _objectDeclaration =
            new Dictionary<RoomID, List<RoomObject>>()
            {
                { RoomID.Kitchen, new List<RoomObject>() {
                    new RoomObject(ObjectID.Oven, "Ofen"),
                    new RoomObject(ObjectID.Dishwasher, "Spülmaschine"),
                    new RoomObject(ObjectID.CutleryDrawer, "Besteckschublade"),
                    new RoomObject(ObjectID.Drawer, "Schublade"),
                    new RoomObject(ObjectID.Fruitbowl, "Obstschale"),
                    new RoomObject(ObjectID.Fridge, "Kühlschrank")
                }}
            };

        public RoomObjectDeclaration() { }

        public List<RoomObject> Get(RoomID id)
        {
            if (_objectDeclaration.ContainsKey(id)) return _objectDeclaration[id];
            else return new List<RoomObject>();
        }
    }
}
