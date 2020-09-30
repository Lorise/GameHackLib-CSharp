using System.Drawing;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Brushes = System.Windows.Media.Brushes;
using Color = System.Windows.Media.Color;
using Rectangle = System.Windows.Shapes.Rectangle;
using SolidColorBrush = System.Windows.Media.SolidColorBrush;

namespace GameHackLib.Code
{
    public class CanvasDraw
    {
        private readonly Canvas _canvas;
        private SolidColorBrush _solidColorBrush = new SolidColorBrush(Colors.Black);
        public double StrokeThickness { get; set; } = 1.0;
        public int FontSize { get; set; }
        public string FontFamily { get; set; }

        public CanvasDraw(Canvas canvas)
        {
            _canvas = canvas;
        }

        public void SetSolidColor(Color color)
        {
            _solidColorBrush = new SolidColorBrush(color);
        }

        public void Clear()
        {
            _canvas.Children.Clear();
        }

        public void DrawPixel(Vector2 p0)
        {
        }

        public void DrawLine(Vector2 p0, Vector2 p1)
        {
            var line = new Line
            {
                X1 = p0.X,
                Y1 = p0.Y,
                X2 = p1.X,
                Y2 = p1.Y,
                StrokeThickness = StrokeThickness,
                Stroke = _solidColorBrush
            };

            _canvas.Children.Add(line);
        }

        public void DrawTriangle(Vector2 p0, Vector2 p1, Vector2 p2)
        {
            DrawLine(p0, p1);
            DrawLine(p1, p2);
            DrawLine(p2, p0);
        }

        public void DrawRectangle(Vector2 p0, Vector2 p1)
        {

        }

        public void DrawFillRectangle(Vector2 p0, Vector2 p1)
        {

        }

        public void DrawCircle(Vector2 center, float radius)
        {
            Ellipse myEllipse = new Ellipse();
            //myEllipse.Fill = _solidColorBrush;
            myEllipse.StrokeThickness = StrokeThickness;
            myEllipse.Stroke = _solidColorBrush;

            // Set the width and height of the Ellipse.
            myEllipse.Margin = new Thickness(center.X - radius, center.Y - radius, 0, 0);
            myEllipse.Width = radius * 2;
            myEllipse.Height = radius * 2;

            // How to set center of ellipse???

            _canvas.Children.Add(myEllipse);
        }

        public void DrawFillCircle(Vector2 center, float radius)
        {
            Ellipse myEllipse = new Ellipse();
            myEllipse.Fill = _solidColorBrush;
            myEllipse.StrokeThickness = StrokeThickness;
            //myEllipse.Stroke = _solidColorBrush;

            // Set the width and height of the Ellipse.
            myEllipse.Margin = new Thickness(center.X - radius, center.Y - radius, 0, 0);
            myEllipse.Width = radius * 2;
            myEllipse.Height = radius * 2;

            // How to set center of ellipse???

            _canvas.Children.Add(myEllipse);
        }

        public void DrawBitmap(Bitmap bitmap, Vector2 p0, Vector2 p1)
        {

        }

        public void DrawText(Vector2 p0, string str, bool outline = false)
        {
            if (outline)
            {
                
            }
        }
    }
}
