using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace brodilka
{
    public class Tile : Canvas
    {
        public static Dictionary<string, Color> TileColors = new Dictionary<string, Color>();

        public static int SIZE = 49;   // размер поля
        public static int START = 10;  // от левого угла до первого поля
        public static int SPACING = 1;
        string value; // тип поля
        public string Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                myColor = TileColors[value];
                background.Fill = new SolidColorBrush(myColor);
            }
        }

        // позиция на экране
        int column, row;
        public int Column { get { return column; } }
        public int Row { get { return row; } }

        Rectangle background;
     
        Color myColor;

        public Tile(int c, int r, string val)
        {
            value = val;
            row = r;
            column = c;

            // создаём поле
            background = new Rectangle();
            background.Width = SIZE;
            background.Height = SIZE;

            Children.Add(background);

            Value = value;

            TransformGroup tg = new TransformGroup();
            ScaleTransform myScale = new ScaleTransform(.1, .1, SIZE / 2, SIZE / 2);
            tg.Children.Add(myScale);
            RenderTransform = tg;

            MoveTo(column, row);

            DoubleAnimation da = new DoubleAnimation(.01, 1, TimeSpan.FromSeconds(0.05));
            da.BeginTime = TimeSpan.FromSeconds(0.05);

            myScale.BeginAnimation(ScaleTransform.ScaleXProperty, da);
            myScale.BeginAnimation(ScaleTransform.ScaleYProperty, da);

        }

        public void MoveTo(int c, int r)
        {
            column = c;
            row = r;

            Thickness myMargin = new Thickness(
                START + c * (SIZE + SPACING),
                START + r * (SIZE + SPACING), 0, 0);
            Margin = myMargin;
        }
    }
}
