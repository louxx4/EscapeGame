using CommandHelper;
using EscapeGame.Models;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EscapeGame.ViewModels
{
    public class StoryViewModel : ViewModel, INotifyPropertyChanged
    {
        #region Variables

        private string _message;
        private BitmapImage _person;

        #endregion

        #region Main

        public StoryViewModel(Game game) : base(game)
        {
            PPerson = (BitmapImage)Application.Current.FindResource("imgRobsTalking1");
            PMessage = "Hallo und herzlich willkommen zu Escape la familia.";
        }

        private void ShowNextMessage()
        {
            PMessage = "Mein Name ist Robs und ich werde Sie durch den groben Spielablauf führen.";
        }

        #endregion

        #region Properties

        public string PMessage
        {
            get { return _message; }
            set
            {
                _message = value;
                if(PropertyChanged != null) NotifyOnPropertyChanged("PMessage");
            }
        }

        public BitmapImage PPerson
        {
            get { return _person; }
            set
            {
                _person = value;
                if (PropertyChanged != null) NotifyOnPropertyChanged("PPerson");
            }
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region EventHandler

        private void NotifyOnPropertyChanged(string propName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #endregion

        #region Commands

        public ICommand CmdNextMessage
        {
            get { 
                return new RelayCommand(o => ShowNextMessage()); 
            }
        }

        #endregion
    }
}
