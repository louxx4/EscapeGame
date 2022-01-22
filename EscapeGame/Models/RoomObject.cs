using System.Windows.Controls;
using System.Windows.Media.Imaging;
using EscapeGame.Enums;
using EscapeGame.ViewModels;
using EscapeGame.Views.Converters;

namespace EscapeGame.Models
{
    public class RoomObject
    {

        #region Main

        public RoomObject(ObjectID id, string tooltip)
        {
            PID = id;
            PTooltip = tooltip;
            PUseImage = false;
        }

        public RoomObject(ObjectID id, string tooltip, ObjectViewModel vm) : this(id, tooltip)
        {
            PUseImage = true;
            PVM = vm;
        }

        #endregion

        #region Properties

        public string PTooltip { get; }

        public bool PUseImage { get; }

        public BitmapImage PImage => ObjectToImage.Convert(PID);

        public ContentControl PControl { get; }

        public ObjectViewModel PVM { get; }

        public ObjectID PID { get; }

        #endregion
    }
}
