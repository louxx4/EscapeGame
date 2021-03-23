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
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(CreateAnimation(this.AssociatedObject, this.PSpeech));
            storyboard.Begin();
        }

        private StringAnimationUsingKeyFrames CreateAnimation(UIElement element, string speech)
        {
            StringAnimationUsingKeyFrames animation = new StringAnimationUsingKeyFrames
            {
                Duration = new Duration(new TimeSpan(0, 0, speech.Length / 10)),
                FillBehavior = FillBehavior.HoldEnd
            };

            foreach (char c in speech)
            { animation.KeyFrames.Add(new DiscreteStringKeyFrame(c.ToString(), KeyTime.Uniform)); }

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

        public static readonly DependencyProperty SpeechProperty =
            DependencyProperty.Register("PSpeech", typeof(string), typeof(SpeechBubbleAnimation), null);

        #endregion
    }
}
