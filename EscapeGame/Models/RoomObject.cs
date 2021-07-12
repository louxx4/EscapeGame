using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using CommandHelper;
using EscapeGame.Enums;
using EscapeGame.Views.Converters;

namespace EscapeGame.Models
{
    public class RoomObject
    {
        private readonly ObjectID _id;
        private readonly string _tooltip;

        #region Main

        public RoomObject(ObjectID id, string tooltip)
        {
            _id = id;
            _tooltip = tooltip;
        }

        #endregion

        #region Properties

        public string PTooltip
        {
            get { return _tooltip; }
        }

        public BitmapImage PImage
        {
            get { return ObjectToImage.Convert(PID) ; }
        }

        public ObjectID PID
        {
            get { return _id; }
        }

        #endregion
    }
}
