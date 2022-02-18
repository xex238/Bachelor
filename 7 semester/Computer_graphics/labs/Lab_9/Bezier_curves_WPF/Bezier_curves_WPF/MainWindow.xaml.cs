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

namespace Bezier_curves_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public class Vector2
    {
        public int X, Y; //координаты вектора
    //  Конструктор
    public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }
        int x0, y0;//координаты первой точки
        int x1, y1;//координаты второй точки
        int amplitude;//параметр a
    }
    public partial class MainWindow : Window
    {
        private void Window_Loaded1(object sender, RoutedEventArgs e)
        {
            Point p1 = new Point(100, 100);

            //this.gr.Children.Add(p1);
        }
        // Код из интернета
        private void Window_Loaded2(object sender, RoutedEventArgs e)
        {
            PathGeometry pathGeom = new PathGeometry();
            Path p = new Path();

            LineSegment vertLS = new LineSegment();
            PathFigure vertPF = new PathFigure();
            vertPF.StartPoint = new Point(10, 150);
            vertLS.Point = new Point(10, 10);
            vertPF.Segments.Add(vertLS);
            pathGeom.Figures.Add(vertPF);

            LineSegment horLS = new LineSegment();
            PathFigure horPF = new PathFigure();
            horPF.StartPoint = new Point(10, 150);
            horLS.Point = new Point(150, 150);
            horPF.Segments.Add(horLS);
            pathGeom.Figures.Add(horPF);

            for (byte i = 2; i < 14; i++)
            {
                PathFigure pf = new PathFigure();
                pf.StartPoint = new Point(i * 10, 155);
                LineSegment a = new LineSegment();
                a.Point = new Point(i * 10, 145);
                pf.Segments.Add(a);
                pathGeom.Figures.Add(pf);
            }

            for (byte i = 3; i < 15; i++)
            {
                PathFigure pf = new PathFigure();
                pf.StartPoint = new Point(5, i * 10);
                LineSegment a = new LineSegment();
                a.Point = new Point(15, i * 10);
                pf.Segments.Add(a);
                pathGeom.Figures.Add(pf);
            }

            PolyLineSegment vertArr = new PolyLineSegment();
            vertArr.Points = new PointCollection();
            vertArr.Points.Add(new Point(10, 10));
            vertArr.Points.Add(new Point(15, 15));
            PathFigure vertArrF = new PathFigure();
            vertArrF.StartPoint = new Point(5, 15);
            vertArrF.Segments.Add(vertArr);
            pathGeom.Figures.Add(vertArrF);

            PolyLineSegment horArr = new PolyLineSegment();
            horArr.Points = new PointCollection();
            horArr.Points.Add(new Point(150, 150));
            horArr.Points.Add(new Point(145, 155));
            PathFigure horArrF = new PathFigure();
            horArrF.StartPoint = new Point(145, 145);
            horArrF.Segments.Add(horArr);
            pathGeom.Figures.Add(horArrF);

            p.Data = pathGeom;
            p.Stroke = Brushes.Black;

            gr.Children.Add(p);
        }
        private void buttonPrintPoint_Click(object sender, RoutedEventArgs e)
        {
            //Ellipse elipse = new Ellipse();

            //elipse.Width = 4;
            //elipse.Height = 4;

            //elipse.StrokeThickness = 2;
            //elipse.Stroke = Brushes.Black;
            //elipse.Margin = new Thickness(0, 0, 0, 0);

            //gr.Children.Add(elipse);

            //Ellipse elipse1 = new Ellipse();

            //elipse1.Width = 4;
            //elipse1.Height = 4;

            //elipse1.StrokeThickness = 2;
            //elipse1.Stroke = Brushes.Black;
            //elipse1.Margin = new Thickness(180, 30, 0, 0);

            //gr.Children.Add(elipse1);

            //Ellipse elipse2 = new Ellipse();

            //elipse2.Width = 4;
            //elipse2.Height = 4;

            //elipse2.StrokeThickness = 2;
            //elipse2.Stroke = Brushes.Black;
            //elipse2.Margin = new Thickness(100, 140, 0, 0);

            //gr.Children.Add(elipse2);

            Ellipse elipse3 = new Ellipse();

            elipse3.Width = 5;
            elipse3.Height = 5;

            elipse3.StrokeThickness = 2;
            elipse3.Stroke = Brushes.Black;
            elipse3.Margin = new Thickness(0, 0, 0, 0);

            Path p = new Path();
            p.Stroke = Brushes.Blue;

            PathFigure pf = new PathFigure();
            pf.StartPoint = new Point(0, 200);

            PathSegmentCollection psg = new PathSegmentCollection();
            

            pf.Segments = new PathSegmentCollection();

            gr.Children.Add(elipse3);
        }
        //public static void FormBezier(object sender, RoutedEventArgs e)
        //{
        //    int j = 0;
        //    float step = 0.01f;// Возьмем шаг 0.01 для большей точности

        //    PointF[] result = new PointF[101];//Конечный массив точек кривой
        //    for (float t = 0; t < 1; t += step)
        //    {
        //        float ytmp = 0;
        //        float xtmp = 0;
        //        for (int i = 0; i < Arr.Length; i++)
        //        { // проходим по каждой точке
        //            float b = polinom(i, Arr.Length - 1, t); // вычисляем наш полином Бернштейна
        //            xtmp += Arr[i].X * b; // записываем и прибавляем результат
        //            ytmp += Arr[i].Y * b;
        //        }
        //        result[j] = new PointF(xtmp, ytmp);
        //        j++;

        //    }
        //    G.DrawLines(new Pen(Color.Red), result);// Рисуем полученную кривую Безье
        //}

        public void Window_Loaded3(object sender, RoutedEventArgs e)
        {
            //Pen pen = new Pen(new SolidBrush(Color.Black)); //кисть для рисования простой линии
            //Pen pen2 = new Pen(new SolidBrush(Color.Red));//кисть для рисования кривой.

            
            g.SmoothingMode = SmoothingMode.HighQuality; //включаем Anti-Aliasing
            // координаты стартовой точки
            Point mainStart = new Point(x0, y0);
            // координаты конечной точки
            Point mainEnd = new Point(x1, y1);
            //С - середина отрезка AB
            Point mainCenter0 = new Point((mainStart.X + mainEnd.X) / 2, (mainStart.Y + mainEnd.Y) / 2);
            //D- середина отрезка AС
            Point mainCenter1 = new Point((mainStart.X + mainCenter0.X) / 2, (mainStart.Y + mainCenter0.Y) / 2);
            //E- середина отрезка СB
            Point mainCenter2 = new Point((mainCenter0.X + mainEnd.X) / 2, (mainCenter0.Y + mainEnd.Y) / 2);
            //Вектор AB
            Vector2 lineVector = new Vector2(mainEnd.X - mainStart.X, mainEnd.Y - mainStart.Y);
            //вектор a1
            Vector2 orthoVector1 = new Vector2(amplitude, -lineVector.X * amplitude / lineVector.Y);
            //вектор a2
            Vector2 orthoVector2 = new Vector2(-orthoVector1.X, -orthoVector1.Y);

            //очищаем экран
            g.Clear(Color.White);

            //транслируем точку D в точку D'
            mainCenter1.Offset(orthoVector1.x, orthoVector1.y);

            //транслируем точку E в точку E'
            mainCenter2.Offset(orthoVector2.x, orthoVector2.y);

            //рисуем кривую Безье
            g.DrawBezier(pen2, mainStart, mainCenter1, mainCenter2, mainEnd);
            //рисуем простую линию
            g.DrawLine(pen, mainStart, mainEnd);
        }
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
