using EscapeGame.Enums;
using EscapeGame.Views.Converters;
using Microsoft.Xaml.Behaviors;
using System;
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
            if (Character != Character.None &&
                CharacterAction == CharacterAction.Talking &&
                Duration != null)
            {
                BitmapImage img1 = CharacterToImage.Convert(Character, CharacterAction, 1);
                BitmapImage img2 = CharacterToImage.Convert(Character, CharacterAction, 2);
                BitmapImage img3 = CharacterToImage.Convert(Character, CharacterAction, 3);
                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(CreateAnimation(this.AssociatedObject, img1, img2, img3, this.Duration));
                storyboard.Begin();
            }
        }

        private static ObjectAnimationUsingKeyFrames CreateAnimation(UIElement element,
            BitmapImage img1, BitmapImage img2, BitmapImage img3, Duration duration)
        {
            ObjectAnimationUsingKeyFrames animation = new ObjectAnimationUsingKeyFrames { Duration = duration };

            if (duration.HasTimeSpan)
            {
                BitmapImage _image = img1;
                double iterations = Math.Floor(duration.TimeSpan.TotalSeconds * 4);
                for (int i = 0; i < iterations; i++)
                {
                    animation.KeyFrames.Add(new DiscreteObjectKeyFrame(_image, KeyTime.Uniform));
                    if (i == iterations - 2) _image = img3;
                    else _image = _image.Equals(img1) ? img2 :
                         _image.Equals(img2) ? img3 : _image.Equals(img3) ? img1 : img2;
                }
            }

            Storyboard.SetTarget(animation, element);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(Image.Source)"));
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
