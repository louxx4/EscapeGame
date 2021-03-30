using CommandHelper;
using EscapeGame.Enums;
using EscapeGame.Models;
using EscapeGame.Views.Converters;
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
        private Character _character1, _character2;
        private CharacterAction _action1, _action2;

        #endregion

        #region Main

        public StoryViewModel(Game game) : base(game)
        {
            PCharacter1 = Character.Robs;
            PAction1 = CharacterAction.Talking;
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
                if (PropertyChanged != null)
                {
                    NotifyOnPropertyChanged("PMessage");
                }
            }
        }

        public BitmapImage PSource1
        {
            get { return CharacterToImage.Convert(PCharacter1, PAction1); }
        }

        public BitmapImage PSource2
        {
            get { return CharacterToImage.Convert(PCharacter2, PAction2); }
        }

        public Duration PDuration
        {
            get { return MessageToDuration.Convert(PMessage); }
        }

        public Character PCharacter1
        {
            get { return _character1; }
            set
            {
                _character1 = value;
                if (PropertyChanged != null) NotifyOnPropertyChanged("PCharacter1");
            }
        }

        public Character PCharacter2
        {
            get { return _character2; }
            set
            {
                _character2 = value;
                if (PropertyChanged != null) NotifyOnPropertyChanged("PCharacter2");
            }
        }

        public CharacterAction PAction1
        {
            get { return _action1; }
            set
            {
                _action1 = value;
                if (PropertyChanged != null) NotifyOnPropertyChanged("PAction1");
            }
        }

        public CharacterAction PAction2
        {
            get { return _action2; }
            set
            {
                _action2 = value;
                if (PropertyChanged != null) NotifyOnPropertyChanged("PAction2");
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
