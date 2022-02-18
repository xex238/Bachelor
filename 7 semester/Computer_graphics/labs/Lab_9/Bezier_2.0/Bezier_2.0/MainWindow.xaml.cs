using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Добавленный код
            Model3DGroup modelGroup = new Model3DGroup();
            GeometryModel3D teapotModel = new GeometryModel3D();
            // Конец добавленного кода

            DoubleAnimationUsingPath daPath = new DoubleAnimationUsingPath();
            daPath.Duration = TimeSpan.FromSeconds(5);
            daPath.RepeatBehavior = RepeatBehavior.Forever;
            daPath.AutoReverse = true;

            QuadraticBezierSegment bezier = new QuadraticBezierSegment();
            bezier.Point1 = new Point(100, 100);
            bezier.Point2 = new Point(300, 100);


            PathSegmentCollection segmentCollection = new PathSegmentCollection();
            segmentCollection.Add(bezier);

            PathFigure pthFigure = new PathFigure();
            pthFigure.Segments = segmentCollection;
            PathFigureCollection pthFigureCollection = new PathFigureCollection();
            pthFigureCollection.Add(pthFigure);
            PathGeometry pthGeometry = new PathGeometry();
            pthGeometry.Figures = pthFigureCollection;

            daPath.PathGeometry = pthGeometry;
            daPath.Source = PathAnimationSource.X;
            circle2.BeginAnimation(Canvas.LeftProperty, daPath);

            daPath = new DoubleAnimationUsingPath();
            daPath.Duration = TimeSpan.FromSeconds(5);
            daPath.RepeatBehavior = RepeatBehavior.Forever;
            daPath.AutoReverse = true;
            daPath.PathGeometry = pthGeometry;
            daPath.Source = PathAnimationSource.Y;
            circle2.BeginAnimation(Canvas.TopProperty, daPath);

            modelGroup.Children.Add(teapotModel);
        }
    }
}