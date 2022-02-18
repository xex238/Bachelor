//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
//using System.Windows.Media.Media3D;
//using System.Windows.Media.Animation;
//namespace Wpf_2
//{
//    /// <summary>
//    /// Логика взаимодействия для MainWindow.xaml
//    /// </summary>
//    public partial class MainWindow : Window
//    {
//        public MainWindow()
//        {
//            InitializeComponent();
//        }
//        Model3DGroup modelGroup = new Model3DGroup();
//        PerspectiveCamera myPCamera = new PerspectiveCamera();
//        GeometryModel3D teapotModel = new GeometryModel3D();
//        Transform3DCollection myTransforms = new Transform3DCollection();
//        Viewport3D myViewport = new Viewport3D();

//        private void Window_Loaded(object sender, RoutedEventArgs e)
//        {
//            //Set camera viewpoint and properties.
//            myPCamera.FarPlaneDistance = 20;
//            myPCamera.NearPlaneDistance = 1;
//            myPCamera.FieldOfView = 45;
//            myPCamera.Position = new Point3D(0, 0, 10);
//            myPCamera.LookDirection = new Vector3D(0, 0, -10);
//            myPCamera.UpDirection = new Vector3D(0, 1, 0);

//            DirectionalLight myDirLight = new DirectionalLight(Color.FromRgb(255, 255, 255), new Vector3D(1, 1, -3));

//            teapotModel.Geometry = (MeshGeometry3D)Application.Current.Resources["myTeapot"];

//            Brush objectBrush;

//            DiffuseMaterial diffuseMaterial;
//            SpecularMaterial specularMaterial;

//            MaterialGroup matGroup = new MaterialGroup();

//            matGroup.Children.Clear();
//            objectBrush = new SolidColorBrush(Color.FromArgb(255, 0, 255, 255));
//            diffuseMaterial = new DiffuseMaterial(objectBrush);
//            specularMaterial = new SpecularMaterial(new SolidColorBrush(Color.FromRgb(255, 255, 255)), 100);

//            matGroup.Children.Add(diffuseMaterial);
//            matGroup.Children.Add(specularMaterial);

//            ColorAnimationUsingKeyFrames objColorAnim = new ColorAnimationUsingKeyFrames();

//            objColorAnim.KeyFrames.Add(new LinearColorKeyFrame(Color.FromRgb(0, 100, 255), KeyTime.FromTimeSpan(new TimeSpan(0, 0, 3))));
//            objColorAnim.KeyFrames.Add(new LinearColorKeyFrame(Color.FromRgb(255, 0, 100), KeyTime.FromTimeSpan(new TimeSpan(0, 0, 6))));
//            objColorAnim.KeyFrames.Add(new LinearColorKeyFrame(Color.FromRgb(100, 255, 0), KeyTime.FromTimeSpan(new TimeSpan(0, 0, 9))));
//            objColorAnim.KeyFrames.Add(new LinearColorKeyFrame(Color.FromRgb(100, 0, 255), KeyTime.FromTimeSpan(new TimeSpan(0, 0, 12))));
//            objColorAnim.KeyFrames.Add(new LinearColorKeyFrame(Color.FromRgb(255, 100, 0), KeyTime.FromTimeSpan(new TimeSpan(0, 0, 15))));
//            objColorAnim.KeyFrames.Add(new LinearColorKeyFrame(Color.FromRgb(0, 255, 100), KeyTime.FromTimeSpan(new TimeSpan(0, 0, 18))));
//            objColorAnim.KeyFrames.Add(new LinearColorKeyFrame(Color.FromRgb(0, 100, 255), KeyTime.FromTimeSpan(new TimeSpan(0, 0, 21))));
//            teapotModel.Material = matGroup;
//            objColorAnim.RepeatBehavior = RepeatBehavior.Forever;
//            objectBrush.BeginAnimation(SolidColorBrush.ColorProperty, objColorAnim);


//            RotateTransform3D myRotateTransform3D = new RotateTransform3D();

//            Quaternion q1 = new Quaternion(new Vector3D(1, 1, 0), 0);
//            QuaternionRotation3D myQuaternion = new QuaternionRotation3D(q1);
//            myRotateTransform3D.Rotation = myQuaternion;
//            teapotModel.Transform = myRotateTransform3D;

//            QuaternionAnimation qa = new QuaternionAnimation(new Quaternion(new Vector3D(1, 1, 0), 0), new Quaternion(new Vector3D(1, 1, 0), 359), new Duration(TimeSpan.FromSeconds(3)));
//            qa.UseShortestPath = false;
//            qa.RepeatBehavior = RepeatBehavior.Forever;
//            myRotateTransform3D.Rotation.BeginAnimation(QuaternionRotation3D.QuaternionProperty, qa);

//            modelGroup.Children.Add(teapotModel);
//            modelGroup.Children.Add(myDirLight);

//            ModelVisual3D modelsVisual = new ModelVisual3D();
//            modelsVisual.Content = modelGroup;

//            //Add the visual and camera to the Viewport3D.
//            myViewport.Camera = myPCamera;
//            myViewport.Children.Add(modelsVisual);

//            this.Content = myViewport;
//        }
//    }
//}









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
using System.Windows.Media.Media3D;
using System.Windows.Media.Animation;
//namespace WpfApp3
namespace Wpf_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string type_of_line = "quadratic Bezier curve";
        public MainWindow(string s)
        {
            type_of_line = s;
            InitializeComponent();
        }
        Model3DGroup modelGroup = new Model3DGroup();
        PerspectiveCamera myPCamera = new PerspectiveCamera();
        GeometryModel3D teapotModel = new GeometryModel3D();
        Transform3DCollection myTransforms = new Transform3DCollection();
        Viewport3D myViewport = new Viewport3D();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Загрузка окна mainWindow


            myPCamera.FarPlaneDistance = 20;
            myPCamera.NearPlaneDistance = 1;
            myPCamera.FieldOfView = 45;
            myPCamera.Position = new Point3D(0, 0, 10);
            myPCamera.LookDirection = new Vector3D(0, 0, -10);
            myPCamera.UpDirection = new Vector3D(0, 1, 0);

            DirectionalLight myDirLight = new DirectionalLight(Color.FromRgb(255, 255, 255), new Vector3D(1, 1, -3));

            teapotModel.Geometry = (MeshGeometry3D)Application.Current.Resources["myTeapot"];

            Brush objectBrush;

            DiffuseMaterial diffuseMaterial;
            SpecularMaterial specularMaterial;

            MaterialGroup matGroup = new MaterialGroup();

            matGroup.Children.Clear();
            objectBrush = new SolidColorBrush(Color.FromArgb(255, 255, 0, 255));
            diffuseMaterial = new DiffuseMaterial(objectBrush);
            specularMaterial = new SpecularMaterial(new SolidColorBrush(Color.FromRgb(255, 255, 255)), 100);

            matGroup.Children.Add(diffuseMaterial);
            matGroup.Children.Add(specularMaterial);

            teapotModel.Material = matGroup;
            Transform3DGroup trGrp = new Transform3DGroup();

            PathGeometry animationPath = new PathGeometry();
            PathFigure pFigure = new PathFigure();

            if(type_of_line == "quadratic Bezier curve")
            {
                //Путь по квадратичной кривой Безье
                QuadraticBezierSegment bezier = new QuadraticBezierSegment();
                bezier.Point1 = new Point(1, 3);
                bezier.Point2 = new Point(3, 1);
                pFigure.Segments.Add(bezier);
                animationPath.Figures.Add(pFigure);
            }
            if (type_of_line == "straight_line")
            {
                //Путь по прямой линии
                LineSegment lineSegment = new LineSegment();
                lineSegment.Point = new Point(1, 3);
                pFigure.StartPoint = new Point(1, 1);
                pFigure.Segments.Add(lineSegment);
                animationPath.Figures.Add(pFigure);
            }
            if (type_of_line == "arc")
            {
                //Путь по дуге-- ?
                ArcSegment arcSegment = new ArcSegment();
                pFigure.StartPoint = new Point(3, 3);
                arcSegment.Point = new Point(-1, -1);
                arcSegment.Size = new Size(200, 300);
                arcSegment.SweepDirection = SweepDirection.Clockwise;
                arcSegment.RotationAngle = 270;
                pFigure.Segments.Add(arcSegment);
                animationPath.Figures.Add(pFigure);


                Path path = new Path();
                path.StrokeThickness = 4;
                path.Stroke = new SolidColorBrush(Colors.Black);
                path.Fill = new SolidColorBrush(Colors.Yellow);
                path.Data = animationPath;
                //animationPath.AddGeometry(path.Data);
            }

            if(type_of_line == "Bezier curve")
            {
                //Кривая Безье
                pFigure.StartPoint = new Point(-2.6, 2);
                PolyBezierSegment pBezierSegment = new PolyBezierSegment();
                pBezierSegment.Points.Add(new Point(-2.8, 2));
                pBezierSegment.Points.Add(new Point(-2.1, 2));
                pBezierSegment.Points.Add(new Point(-1.6, 1));
                pBezierSegment.Points.Add(new Point(-1.1, 0));
                pBezierSegment.Points.Add(new Point(-0.6, 0));
                pBezierSegment.Points.Add(new Point(0.1, 0));
                pFigure.Segments.Add(pBezierSegment);
                animationPath.Figures.Add(pFigure);
            }

            DoubleAnimationUsingPath Xdaup = new DoubleAnimationUsingPath();
            Xdaup.PathGeometry = animationPath;
            Xdaup.AutoReverse = true;
            Xdaup.RepeatBehavior = RepeatBehavior.Forever;
            Xdaup.Duration = TimeSpan.FromSeconds(3);
            Xdaup.Source = PathAnimationSource.X;

            DoubleAnimationUsingPath Ydaup = new DoubleAnimationUsingPath();
            Ydaup.PathGeometry = animationPath;
            Ydaup.AutoReverse = true;
            Ydaup.RepeatBehavior = RepeatBehavior.Forever;
            Ydaup.Duration = TimeSpan.FromSeconds(3);
            Ydaup.Source = PathAnimationSource.Y;

            TranslateTransform3D translateTransfrom = new TranslateTransform3D(0, 0, 0);

            trGrp.Children.Add(translateTransfrom);

            teapotModel.Transform = trGrp;

            translateTransfrom.BeginAnimation(TranslateTransform3D.OffsetXProperty, Xdaup);
            translateTransfrom.BeginAnimation(TranslateTransform3D.OffsetYProperty, Ydaup);


            modelGroup.Children.Add(teapotModel);
            modelGroup.Children.Add(myDirLight);

            ModelVisual3D modelsVisual = new ModelVisual3D();
            modelsVisual.Content = modelGroup;

            //Add the visual and camera to the Viewport3D.
            myViewport.Camera = myPCamera;
            myViewport.Children.Add(modelsVisual);

            this.Content = myViewport;

        }
    }
}