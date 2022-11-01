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

namespace Poor_Paint
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point currentPoint = new Point();

        SolidColorBrush Bcolor = new SolidColorBrush(Colors.White);
        public MainWindow()
        {
            InitializeComponent();
        }
        private void DrawHandler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(Surface);
        }

        private void MouseMoveHandler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Line line = new Line();
                line.Stroke = Bcolor;
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition(Surface).X;
                line.Y2 = e.GetPosition(Surface).Y;
                currentPoint = e.GetPosition(Surface);
                Surface.Children.Add(line);
                
            }
        }
        void SetColorHandler(object sender, EventArgs e)
        {
            var ColorName = (Color)ColorConverter.ConvertFromString((string)((Button)sender).Tag);
            Bcolor = new SolidColorBrush(ColorName);
        }

        private void EraseHandler(object sender, RoutedEventArgs e)
        {
            Surface.Children.Clear();
        }
    }
}
