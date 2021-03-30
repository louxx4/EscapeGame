using EscapeGame.Enums;
using EscapeGame.Views.Converters;
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace EscapeGame.Views.Animations
{
    class TalkingAnimation : TriggerAction<UIElement>
    {
        #region Main

        protected override void Invoke(object parameter)
        {
            if (CharacterAction == CharacterAction.Talking && Duration != null)
            {
                BitmapImage img1 = CharacterToImage.Convert(Character, CharacterAction, true);
                BitmapImage img2 = CharacterToImage.Convert(Character, CharacterAction, false);
                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(CreateAnimation(this.AssociatedObject, img1, img2, this.Duration));
                storyboard.Begin();
            }
        }

        private static ObjectAnimationUsingKeyFrames CreateAnimation(UIElement element,
            BitmapImage img1, BitmapImage img2, Duration duration)
        {
            ObjectAnimationUsingKeyFrames animation = new ObjectAnimationUsingKeyFrames { Duration = duration };
            BitmapImage _image = img1;

            for (int i = 0; i < duration.TimeSpan.TotalSeconds * 4; i++)
            {
                animation.KeyFrames.Add(new DiscreteObjectKeyFrame(_image, KeyTime.Uniform));
                _image = (_image.Equals(img1) ? img2 : img1);
            }

            Storyboard.SetTargetProperty(animation, new PropertyPath("(Image.Source)"));
            Storyboard.SetTarget(animation, element);
            return animation;
        }

        #endregion

        #region DependencyProperties

        public static readonly DependencyProperty CharacterProperty =
            DependencyProperty.Register("Character", typeof(Character), typeof(TalkingAnimation));

        public static readonly DependencyProperty CharacterActionProperty =
            DependencyProperty.Register("CharacterAction", typeof(CharacterAction), typeof(TalkingAnimation));

        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration", typeof(Duration), typeof(TalkingAnimation));

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
