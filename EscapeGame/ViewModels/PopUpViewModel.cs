using CommandHelper;
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
        private readonly string _name;
        private readonly ContentControl _objectControl;

        #region Main

        public PopUpViewModel() { }

        public PopUpViewModel(string name, BitmapImage image)
        {
            _name = name;
            _image = image;
        }

        public PopUpViewModel(string name, ContentControl objectControl)
        {
            _name = name;
            _objectControl = objectControl;
        }

        #endregion

        #region Properties

        public string PName
        {
            get { return _name; }
        }

        public BitmapImage PImage
        {
            get { return _image; }
        }
        
        public ContentControl PObjectControl
        {
            get { return _objectControl;  }
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