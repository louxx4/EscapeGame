using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EscapeGame.Views.Converters
{
    public static class MessageToDuration
    {
        public static Duration Convert(string message)
        {
            return new Duration(new TimeSpan(0, 0, 0, 0, message.Length * 90));
        }

    }
}
