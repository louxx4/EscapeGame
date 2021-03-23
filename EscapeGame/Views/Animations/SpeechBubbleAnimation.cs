using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using Microsoft.Xaml.Behaviors;

namespace EscapeGame.Views.Animations
{
    public class SpeechBubbleAnimation : TriggerAction<UIElement>
    {
        #region Main

        protected override void Invoke(object parameter)
        {
            if (PSpeech != null)
            {
                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(CreateAnimation(this.AssociatedObject, this.PSpeech));
                storyboard.Begin();
            }
        }

        private static StringAnimationUsingKeyFrames CreateAnimation(UIElement element, string speech)
        {
            StringAnimationUsingKeyFrames animation = new StringAnimationUsingKeyFrames
            {
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, speech.Length * 90)),
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

        #region Properties

        public string PSpeech
        {
            get { return (string)GetValue(SpeechProperty); }
            set { SetValue(SpeechProperty, value); }
        }

        private static readonly DependencyProperty SpeechProperty =
            DependencyProperty.Register("PSpeech", typeof(string), typeof(SpeechBubbleAnimation), null);

        #endregion
    }
}
