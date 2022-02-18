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

namespace WPF_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void Window_Loaded1(object sender, RoutedEventArgs e)
        {
            Ellipse el = new Ellipse();
            el.Fill = Brushes.Azure;
            el.Stroke = Brushes.Black;
            el.Width = 200;
            el.Height = 50;
            this.gr.Children.Add(el);
        }
        private void Window_Loaded2(object sender, RoutedEventArgs e)
        {
            Point[] p = new Point[2] { new Point(0, 0), new Point(100, 100) };
            Line my_line = new Line();
            my_line.Stroke = System.Windows.Media.Brushes.Red;
            my_line.X1 = p[0].X + 200;
            my_line.X2 = p[1].X + 200;
            my_line.Y1 = p[0].Y;
            my_line.Y2 = p[1].Y;
            this.gr.Children.Add(my_line);

            Matrix ma = new Matrix(0, 1, -1, 0, 0, 0);
            ma.Transform(p);

            Line my_line1 = new Line();
            my_line1.Stroke = System.Windows.Media.Brushes.Red;
            my_line1.X1 = p[0].X + 200;
            my_line1.X2 = p[1].X + 200;
            my_line1.Y1 = p[0].Y;
            my_line1.Y2 = p[1].Y;
            this.gr.Children.Add(my_line1);
        }
        private void Window_Loaded3(object sender, RoutedEventArgs e)
        {
            Point[] points1 = new Point[4];
            points1[0] = new Point(0, 0);
            points1[1] = new Point(20, 10);
            points1[2] = new Point(20, 30);
            points1[3] = new Point(0, 30);

            for (int i = 0; i < 4; i++)
            {
                points1[i].X = 400 - points1[i].X;
                points1[i].Y = 200 - points1[i].Y;
            }

            Vector[] my_vector1 = new Vector[4];
            double[] helper_mas1 = new double[4];

            for (int i = 0; i < 3; i++)
            {
                my_vector1[i] = new Vector();
                my_vector1[i].X = points1[i + 1].X - points1[i].X;
                my_vector1[i].Y = points1[i + 1].Y - points1[i].Y;
                //helper_mas1[i] = points1[i].X * points1[i + 1].Y - points1[i].Y - points1[i + 1].X;
                //helper_mas1[i] = my_vector1[i].X * my_vector1[i + 1].Y - my_vector1[i].Y * my_vector1[i + 1].X;
            }
            for (int i = 0; i < 3; i++)
            {
                helper_mas1[i] = my_vector1[i].X * my_vector1[i + 1].Y - my_vector1[i].Y * my_vector1[i + 1].X;
            }

            my_vector1[3] = new Vector();
            my_vector1[3].X = points1[0].X - points1[3].X;
            my_vector1[3].Y = points1[0].Y - points1[3].Y;
            //helper_mas1[3] = points1[3].X * points1[0].Y - points1[3].Y - points1[0].X;
            helper_mas1[3] = my_vector1[3].X * my_vector1[0].Y - my_vector1[3].Y * my_vector1[0].X;

            bool detector1 = true;
            for (int i = 0; i < 4; i++)
            {
                if (helper_mas1[i] < 0)
                {
                    detector1 = false;
                }
            }
            if (detector1)
            {
                t.Text = "Фигура №1 (слева) выпуклая";
            }
            else
            {
                t.Text = "Фигура №1 (слева) не выпуклая";
            }
            //t.Text = "";
            //for(int i=0; i<4; i++)
            //{
            //    t.Text = t.Text + helper_mas1[i] + " ";
            //}

            Line[] my_line1 = new Line[4];

            for (int i = 0; i < 3; i++)
            {
                my_line1[i] = new Line();
                my_line1[i].Stroke = System.Windows.Media.Brushes.Red;
                my_line1[i].X1 = points1[i].X;
                my_line1[i].X2 = points1[i + 1].X;
                my_line1[i].Y1 = points1[i].Y;
                my_line1[i].Y2 = points1[i + 1].Y;
                this.gr.Children.Add(my_line1[i]);
            }

            my_line1[3] = new Line();
            my_line1[3].Stroke = System.Windows.Media.Brushes.Red;
            my_line1[3].X1 = points1[3].X;
            my_line1[3].X2 = points1[0].X;
            my_line1[3].Y1 = points1[3].Y;
            my_line1[3].Y2 = points1[0].Y;
            this.gr.Children.Add(my_line1[3]);

            Point[] points2 = new Point[5];
            points2[0] = new Point(0, 0);
            points2[1] = new Point(20, 10);
            points2[2] = new Point(10, 20);
            points2[3] = new Point(30, 30);
            points2[4] = new Point(0, 30);

            for (int i = 0; i < 5; i++)
            {
                points2[i].X = 500 - points2[i].X;
                points2[i].Y = 200 - points2[i].Y;
            }
            //for (int i = 0; i < 5; i++)
            //{
            //    points2[i].X = points2[i].X;
            //    points2[i].Y = points2[i].Y;
            //}

            Vector[] my_vector2 = new Vector[5];
            double[] helper_mas2 = new double[5];

            for (int i = 0; i < 4; i++)
            {
                my_vector2[i] = new Vector();
                my_vector2[i].X = points2[i + 1].X - points2[i].X;
                my_vector2[i].Y = points2[i + 1].Y - points2[i].Y;
                //helper_mas2[i] = points2[i].X * points2[i + 1].Y - points2[i].Y - points2[i + 1].X;
                //helper_mas2[i] = my_vector2[i].X * my_vector2[i + 1].Y - my_vector2[i].Y * my_vector2[i + 1].X;
            }
            for (int i = 0; i < 4; i++)
            {
                helper_mas2[i] = my_vector2[i].X * my_vector2[i + 1].Y - my_vector2[i].Y * my_vector2[i + 1].X;
            }

            my_vector2[4] = new Vector();
            my_vector2[4].X = points2[0].X - points2[4].X;
            my_vector2[4].Y = points2[0].Y - points2[4].Y;
            //helper_mas2[4] = points2[4].X * points2[0].Y - points2[4].Y - points2[0].X;
            helper_mas2[4] = my_vector2[4].X * my_vector2[0].Y - my_vector2[4].Y * my_vector2[0].X;

            bool detector2 = true;
            for (int i = 0; i < 5; i++)
            {
                if (helper_mas2[i] < 0)
                {
                    detector2 = false;
                }
            }
            if (detector2)
            {
                t2.Text = "Фигура №2 (справа) выпуклая";
            }
            else
            {
                t2.Text = "Фигура №2 (справа) не выпуклая";
            }
            //t2.Text = "";
            //for (int i = 0; i < 5; i++)
            //{
            //    t2.Text = t2.Text + helper_mas2[i] + " ";
            //}

            Line[] my_line2 = new Line[5];

            for (int i = 0; i < 4; i++)
            {
                my_line2[i] = new Line();
                my_line2[i].Stroke = System.Windows.Media.Brushes.Red;
                my_line2[i].X1 = points2[i].X;
                my_line2[i].X2 = points2[i + 1].X;
                my_line2[i].Y1 = points2[i].Y;
                my_line2[i].Y2 = points2[i + 1].Y;
                this.gr.Children.Add(my_line2[i]);
            }

            my_line2[4] = new Line();
            my_line2[4].Stroke = System.Windows.Media.Brushes.Red;
            my_line2[4].X1 = points2[4].X;
            my_line2[4].X2 = points2[0].X;
            my_line2[4].Y1 = points2[4].Y;
            my_line2[4].Y2 = points2[0].Y;
            this.gr.Children.Add(my_line2[4]);

            // Затем кол-во векторов на 1 меньше, чем точек -- это последовательная разность векторов
            // Необходимо посмотреть их произведение
            // Если хотя бы один x1 * y2 - y1 * x2 < 0, то не выпуклый, иначе выпуклый
        }
        // Вторая лабораторная (кривые Безье)
        private void Window_Loaded4(object sender, RoutedEventArgs e)
        {
            EllipseGeometry el = new EllipseGeometry(new Point(100, 100), 100, 50);
            Path path = new Path();
            path.Stroke = Brushes.Green;
            path.Data = el.GetFlattenedPathGeometry();
            this.gr.Children.Add(path);
        }
        private void Window_Loaded5(object sender, RoutedEventArgs e)
        {
            EllipseGeometry el = new EllipseGeometry(new Point(100, 100), 100, 50);
            EllipseGeometry el1 = new EllipseGeometry(new Point(150, 100), 100, 50);
            Geometry g1 = el;
            Geometry g11 = el1;
            CombinedGeometry CombineG = new CombinedGeometry(GeometryCombineMode.Xor, g1, g11);
            Path p = new Path();
            p.Fill = Brushes.Red;
            p.Stroke = Brushes.Green;
            p.Data = CombineG.GetFlattenedPathGeometry();

            this.gr.Children.Add(p);
        }
        public MainWindow()
        {
            //Window_Loaded3();
            InitializeComponent();
        }
    }
}
