using OpenMahjong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace solo_play.Views.Stateless
{
    /// <summary>
    /// Haiga.xaml の相互作用ロジック
    /// </summary>
    public partial class Haiga : UserControl
    {
        public static readonly DependencyProperty PaiProperty = DependencyProperty.Register("Pai", typeof(PaiT), typeof(Haiga), new PropertyMetadata(null, OnPaiPropertyChanged));

        public PaiT Pai {
            get => (PaiT)GetValue(PaiProperty);
            set => SetValue(PaiProperty, value);
        }

        public Haiga()
        {
            InitializeComponent();
        }

        private static void OnPaiPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (Haiga)d;

            var newValue = (PaiT)e.NewValue;

            var (x, y) = control.GetBoundingBox(newValue);

            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.CacheOption = BitmapCacheOption.OnLoad;
            img.UriSource = new Uri(@"./Views/Stateless/Resources/haiga.png", UriKind.Relative);
            img.EndInit();

            CroppedBitmap croppedBitmap = new CroppedBitmap(img, new Int32Rect(x, y, 24, 34));

            croppedBitmap.Freeze();

            control.PaiImage.Source = croppedBitmap;
        }

        private (int, int) GetBoundingBox(PaiT pai)
        {
            int t = pai.PaiNum / 9;
            int n = pai.PaiNum % 9;
            return (n * 24, t * 34);
        }
    }
}
