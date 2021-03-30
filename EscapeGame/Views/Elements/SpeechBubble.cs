using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using EscapeGame.Views;

namespace EscapeGame.Views.Elements
{
    public class SpeechBubble : TextBlock
    {

        public static readonly DependencyProperty SpeechProperty =
            DependencyProperty.Register("Speech", typeof(string), typeof(SpeechBubble));

        public string Speech
        {
            get { return (string)GetValue(SpeechProperty); }
            set { SetValue(SpeechProperty, value);
                
            }
        }
    }
}
