using CommandHelper;
using EscapeGame.Enums;
using EscapeGame.Models;
using EscapeGame.Models.GameComponents;
using EscapeGame.Views.Animations;
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
        private bool _arrowEnabled;
        private Character _character1, _character2;
        private CharacterAction _action1, _action2;
        private Visibility _visibility1, _visibility2;

        private int _iterator = 0;
        private string[] _sequences;
        
        #endregion
        
        #region Main

        public StoryViewModel(Game game) : base(game) { }

        public override void SetComponent(GameComponent c)
        {
            if (c is StoryMessage)
            {
                StoryMessage story = c as StoryMessage;
                PCharacter1 = story.Character1;
                PAction1 = story.CharacterAction1;
                _sequences = story.Message;
                if (story.HasCharacter2)
                {
                    PCharacter2 = story.Character2;
                    PAction2 = story.CharacterAction2;
                }
                ShowNextMessage();
            }
        }

        private void ShowNextMessage()
        {
            if (_sequences.Length > _iterator)
            {
                PMessage = _sequences[_iterator];
                _iterator++;
            }
        }

        #endregion

        #region Properties

        public string PMessage
        {
            get { return _message; }
            set
            {
                _message = value;
                PArrowEnabled = false;
                if (PropertyChanged != null)
                {
                    NotifyOnPropertyChanged("PDuration");
                    NotifyOnPropertyChanged("PMessage");
                }
            }
        }

        public Visibility PVisibility1
        {
            get { return _visibility1; }
            set
            {
                _visibility1 = value;
                if (PropertyChanged != null) { NotifyOnPropertyChanged("PVisibility1"); }
            }
        }

        public Visibility PVisibility2
        {
            get { return _visibility2; }
            set
            {
                _visibility2 = value;
                if (PropertyChanged != null) { NotifyOnPropertyChanged("PVisibility2"); }
            }
        }

        public bool PArrowEnabled
        {
            get { return _arrowEnabled; }
            set
            {
                _arrowEnabled = value;
                if (PropertyChanged != null) { NotifyOnPropertyChanged("PArrowEnabled"); }
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
            get
            {
                return new RelayCommand(o => ShowNextMessage());
            }
        }

        #endregion
    }
}
