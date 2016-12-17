using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace UwpChess
{
    class ChessPieceToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            ChessPiece piece = value as ChessPiece;
            if (piece != null)
            {
                var image = new BitmapImage(new Uri($"http://www.wpclipart.com/recreation/games/chess/chess_set_1/chess_piece_{piece.Color.ToString().ToLower()}_{piece.Type.ToString().ToLower()}_T.png"));
                return image;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    class BooleanToZIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool isSelected = (bool)value;

            if (isSelected) { return 65; }
            else { return 0; }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
