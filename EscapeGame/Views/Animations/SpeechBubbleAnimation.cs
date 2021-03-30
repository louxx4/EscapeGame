using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using EscapeGame.Views.Converters;
using Microsoft.Xaml.Behaviors;

namespace EscapeGame.Views.Animations
{
    public class SpeechBubbleAnimation : TriggerAction<UIElement>
    {
        #region Main

        protected override void Invoke(object parameter)
        {
            if (Speech != null)
            {
                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(CreateAnimation(this.AssociatedObject, this.Speech));
                storyboard.Begin();
            }
        }

        private static StringAnimationUsingKeyFrames CreateAnimation(UIElement element, string speech)
        {
            StringAnimationUsingKeyFrames animation = new StringAnimationUsingKeyFrames
            {
                Duration = MessageToDuration.Convert(speech),
                FillBehavior = FillBehavior.HoldEnd
            };

            for (int i = 0; i < speech.Length; i++)
            { animation.KeyFrames.Add(new DiscreteStringKeyFrame(speech.
                Substring(0, i + 1), KeyTime.Uniform)); }

            Storyboard.SetTargetProperty(animation, new PropertyPath("(TextBlock.Text)"));
            Storyboard.SetTarget(animation, element);
            return animation;
        }

        #endregion

        #region DependencyProperties

        private static readonly DependencyProperty SpeechProperty =
            DependencyProperty.Register("Speech", typeof(string), typeof(SpeechBubbleAnimation));


        #endregion

        #region Properties

        public string Speech
        {
            get { return (string)GetValue(SpeechProperty); }
            set { SetValue(SpeechProperty, value); }
        }

        #endregion
    }
}
