using EscapeGame.Enums;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EscapeGame.Views.Elements
{
    public class Person : Image
    {

        #region DependencyProperties

        public static readonly DependencyProperty CharacterProperty =
            DependencyProperty.Register("Character", typeof(Character), typeof(Person));

        public static readonly DependencyProperty CharacterActionProperty =
            DependencyProperty.Register("CharacterAction", typeof(CharacterAction), typeof(Person));

        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration", typeof(Duration), typeof(Person));

        #endregion

        #region Properties

        public Character Character
        {
            get { return (Character)GetValue(CharacterProperty); }
            set { SetValue(CharacterProperty, value); }
        }

        public CharacterAction CharacterAction
        {
            get { return (CharacterAction)GetValue(CharacterActionProperty); }
            set { SetValue(CharacterActionProperty, value); }
        }

        public Duration Duration
        {
            get { return (Duration)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        #endregion
    }
}
