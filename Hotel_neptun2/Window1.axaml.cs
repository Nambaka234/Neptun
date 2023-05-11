using Avalonia.Controls;
using Avalonia.Media.Imaging;
using System;
//using Hotel_neptun2.Image;

namespace Hotel_neptun2
{
    public partial class Window1 : Window
    {
        public static Bitmap? bitmap;
        public Window1()
        {
            InitializeComponent();
            bitmap = Image.pathimage;
            BigImage.Source = bitmap;
        }        
    }
}
