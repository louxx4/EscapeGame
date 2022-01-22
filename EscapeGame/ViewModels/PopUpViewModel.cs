using CommandHelper;
using EscapeGame.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace EscapeGame.ViewModels
{
    public class PopUpViewModel : INotifyPropertyChanged
    {
        private readonly BitmapImage _image;
        private readonly int _id;
        private readonly string _name;
        private readonly ObjectViewModel _objectVM;

        #region Main

        public PopUpViewModel() { }

        public PopUpViewModel(ObjectID id, string name, BitmapImage image) : this(id, name)
        {
            _image = image;
        }

        public PopUpViewModel(ObjectID id, string name, ObjectViewModel objectVM) : this(id, name)
        {
            _objectVM = objectVM;
        }

        public PopUpViewModel(ObjectID id, string name)
        {
            _id = (int)id;
            _name = name;
        }

        #endregion

        #region Properties

        public string PName
        {
            get { return _name; }
        }

        public int PID
        {
            get { return _id; }
        }


        public BitmapImage PImage
        {
            get { return _image; }
        }

        public ObjectViewModel PObjectVM
        {
            get { return _objectVM; }
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region EventHandler

        protected void NotifyOnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #endregion
    }
}