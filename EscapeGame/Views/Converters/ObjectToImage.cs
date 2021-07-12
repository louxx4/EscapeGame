using EscapeGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace EscapeGame.Views.Converters
{
    public static class ObjectToImage
    {
        public static BitmapImage Convert(ObjectID id)
        {
            string key = "img" + id.ToString();
        
            BitmapImage resource = (BitmapImage)Application.Current.TryFindResource(key);

            return resource ?? null;
        }

    }
}
