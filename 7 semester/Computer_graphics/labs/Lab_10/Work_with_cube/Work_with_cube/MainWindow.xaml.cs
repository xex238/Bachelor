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

namespace WpfApp7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Get_cube_8(Int32Collection myTriangleIndicesCollection)
        {
            myTriangleIndicesCollection.Add(4);
            myTriangleIndicesCollection.Add(5);
            myTriangleIndicesCollection.Add(6);
            myTriangleIndicesCollection.Add(6);
            myTriangleIndicesCollection.Add(7);
            myTriangleIndicesCollection.Add(4);

            myTriangleIndicesCollection.Add(7);
            myTriangleIndicesCollection.Add(6);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(3);
            myTriangleIndicesCollection.Add(7);

            myTriangleIndicesCollection.Add(5);
            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(6);
            myTriangleIndicesCollection.Add(5);

            // Нижняя невидимая
            myTriangleIndicesCollection.Add(4);
            myTriangleIndicesCollection.Add(0);
            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(5);
            myTriangleIndicesCollection.Add(4);

            // Левая боковая невидимая
            myTriangleIndicesCollection.Add(4);
            myTriangleIndicesCollection.Add(7);
            myTriangleIndicesCollection.Add(3);
            myTriangleIndicesCollection.Add(3);
            myTriangleIndicesCollection.Add(0);
            myTriangleIndicesCollection.Add(4);

            myTriangleIndicesCollection.Add(0);
            myTriangleIndicesCollection.Add(3);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(0);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Declare scene objects.
            Viewport3D myViewport3D = new Viewport3D();
            Model3DGroup myModel3DGroup = new Model3DGroup();
            GeometryModel3D myGeometryModel = new GeometryModel3D();
            ModelVisual3D myModelVisual3D = new ModelVisual3D();

            OrthographicCamera myOCamera = new OrthographicCamera(new Point3D(0, 0, 8), new Vector3D(0, 0, -3), new Vector3D(0, 1, 0), 8);
            myViewport3D.Camera = myOCamera;

            // Источник света
            DirectionalLight myDirectionalLight = new DirectionalLight();
            myDirectionalLight.Color = Colors.White;
            myDirectionalLight.Direction = new Vector3D(1, 1, -25);

            myModel3DGroup.Children.Add(myDirectionalLight);

            // The geometry specifes the shape of the 3D plane. In this sample, a flat sheet 
            // is created.
            MeshGeometry3D myMeshGeometry3D = new MeshGeometry3D();

            // Create a collection of normal vectors for the MeshGeometry3D.
            Vector3DCollection myNormalCollection = new Vector3DCollection();
            myNormalCollection.Add(new Vector3D(0, 1, 0));
            myNormalCollection.Add(new Vector3D(0, 1, 0));
            myNormalCollection.Add(new Vector3D(0, 1, 0));
            myNormalCollection.Add(new Vector3D(0, 1, 0));
            myMeshGeometry3D.Normals = myNormalCollection;

            // Сюда написать точки с фото
            myMeshGeometry3D.TextureCoordinates.Add(new Point(1, 0));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(0, 0));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(0, 1));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(0, 1));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(1, 1));
            myMeshGeometry3D.TextureCoordinates.Add(new Point(1, 0));

            // Create a collection of vertex positions for the MeshGeometry3D. 
            Point3DCollection myPositionCollection = new Point3DCollection();
            myPositionCollection.Add(new Point3D(0, 0, 0));
            myPositionCollection.Add(new Point3D(1, 0, 0));
            myPositionCollection.Add(new Point3D(1, 1, 0));
            myPositionCollection.Add(new Point3D(0, 1, 0));
            myPositionCollection.Add(new Point3D(0, 0, 1));
            myPositionCollection.Add(new Point3D(1, 0, 1));
            myPositionCollection.Add(new Point3D(1, 1, 1));
            myPositionCollection.Add(new Point3D(0, 1, 1));

            myPositionCollection.Add(new Point3D(0, 0, 0));
            myPositionCollection.Add(new Point3D(1, 0, 0));
            myPositionCollection.Add(new Point3D(1, 1, 0));
            myPositionCollection.Add(new Point3D(0, 1, 0));
            myPositionCollection.Add(new Point3D(0, 0, 1));
            myPositionCollection.Add(new Point3D(1, 0, 1));
            myPositionCollection.Add(new Point3D(1, 1, 1));
            myPositionCollection.Add(new Point3D(0, 1, 1));

            myPositionCollection.Add(new Point3D(0, 0, 0));
            myPositionCollection.Add(new Point3D(1, 0, 0));
            myPositionCollection.Add(new Point3D(1, 1, 0));
            myPositionCollection.Add(new Point3D(0, 1, 0));
            myPositionCollection.Add(new Point3D(0, 0, 1));
            myPositionCollection.Add(new Point3D(1, 0, 1));
            myPositionCollection.Add(new Point3D(1, 1, 1));
            myPositionCollection.Add(new Point3D(0, 1, 1));

            myMeshGeometry3D.Positions = myPositionCollection;
            // Create a collection of triangle indices for the MeshGeometry3D.
            Int32Collection myTriangleIndicesCollection = new Int32Collection();

            // Треугольник на 24 точках
            // Оставляем
            myTriangleIndicesCollection.Add(4);
            myTriangleIndicesCollection.Add(5);
            myTriangleIndicesCollection.Add(6);
            myTriangleIndicesCollection.Add(6);
            myTriangleIndicesCollection.Add(7);
            myTriangleIndicesCollection.Add(4);

            // Оставляем
            myTriangleIndicesCollection.Add(15);
            myTriangleIndicesCollection.Add(14);
            myTriangleIndicesCollection.Add(10);
            myTriangleIndicesCollection.Add(10);
            myTriangleIndicesCollection.Add(11);
            myTriangleIndicesCollection.Add(15);

            // Оставляем
            myTriangleIndicesCollection.Add(21);
            myTriangleIndicesCollection.Add(17);
            myTriangleIndicesCollection.Add(18);
            myTriangleIndicesCollection.Add(18);
            myTriangleIndicesCollection.Add(22);
            myTriangleIndicesCollection.Add(21);

            // Оставляем
            myTriangleIndicesCollection.Add(12);
            myTriangleIndicesCollection.Add(8);
            myTriangleIndicesCollection.Add(9);
            myTriangleIndicesCollection.Add(9);
            myTriangleIndicesCollection.Add(13);
            myTriangleIndicesCollection.Add(12);

            // Оставляем
            myTriangleIndicesCollection.Add(20);
            myTriangleIndicesCollection.Add(23);
            myTriangleIndicesCollection.Add(19);
            myTriangleIndicesCollection.Add(19);
            myTriangleIndicesCollection.Add(16);
            myTriangleIndicesCollection.Add(20);

            // Оставляем
            myTriangleIndicesCollection.Add(0);
            myTriangleIndicesCollection.Add(3);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(0);

            myMeshGeometry3D.TriangleIndices = myTriangleIndicesCollection;

            PointCollection myTextureCollection = new PointCollection();
            myTextureCollection.Add(new Point(0, 0));
            myTextureCollection.Add(new Point(0, 1));
            myTextureCollection.Add(new Point(1, 0));
            myTextureCollection.Add(new Point(1, 1));

            myTextureCollection.Add(new Point(1, 1));
            myTextureCollection.Add(new Point(0, 1));
            myTextureCollection.Add(new Point(1, 0));
            myTextureCollection.Add(new Point(0, 0));

            myTextureCollection.Add(new Point(0, 0));
            myTextureCollection.Add(new Point(1, 0));
            myTextureCollection.Add(new Point(0, 1));
            myTextureCollection.Add(new Point(1, 1));

            myTextureCollection.Add(new Point(0, 1));
            myTextureCollection.Add(new Point(1, 0));
            myTextureCollection.Add(new Point(0, 0));
            myTextureCollection.Add(new Point(1, 1));

            myTextureCollection.Add(new Point(1, 1));
            myTextureCollection.Add(new Point(0, 1));
            myTextureCollection.Add(new Point(1, 0));
            myTextureCollection.Add(new Point(0, 0));

            myTextureCollection.Add(new Point(0, 0));
            myTextureCollection.Add(new Point(0, 1));
            myTextureCollection.Add(new Point(1, 0));
            myTextureCollection.Add(new Point(1, 1));

            myMeshGeometry3D.TextureCoordinates = myTextureCollection;

            // Применяем сетку к геометрической модели
            // Apply the mesh to the geometry model.
            myGeometryModel.Geometry = myMeshGeometry3D;

            //// Код с листочка
            //BitmapImage bm1 = new BitmapImage();
            //bm1.BeginInit();
            //bm1.UriSource = new Uri("lotos.bmp", UriKind.Relative);
            //bm1.EndInit();

            //ImageBrush imgBrush = new ImageBrush(bm1);
            // Конец кода с листочка

            // Код как у Дианы. Вставка bmp изображения
            //BitmapImage mybit = new BitmapImage();
            //mybit.BeginInit();
            //mybit.UriSource = new Uri("lotos.bmp");
            //mybit.EndInit();

            //ImageBrush img = new ImageBrush();
            //img.ImageSource = mybit;
            //DiffuseMaterial myMatherial = new DiffuseMaterial();
            //myMatherial.Brush = img;
            //myGeometryModel.Material = myMatherial;
            // Конец вставки bmp изображения

            //// Что это за код и как он тут возник?
            //DiffuseMaterial myMatherial = new DiffuseMaterial(imgBrush);
            //myGeometryModel.Material = myMatherial;

            TranslateTransform3D myTranslateTransform3D = new TranslateTransform3D();
            myModel3DGroup.Transform = myTranslateTransform3D;
            DoubleAnimation xAnim = new DoubleAnimation();
            xAnim.From = -1;
            xAnim.To = -1;
            xAnim.RepeatBehavior = new RepeatBehavior(200);
            xAnim.Duration = TimeSpan.FromSeconds(4);
            xAnim.AutoReverse = true;
            myTranslateTransform3D.BeginAnimation(TranslateTransform3D.OffsetXProperty, xAnim);

            myGeometryModel.Transform = myTranslateTransform3D;
            myModel3DGroup.Children.Add(myGeometryModel);

            myModelVisual3D.Content = myModel3DGroup;

            myViewport3D.Children.Add(myModelVisual3D);
            this.Content = myViewport3D;
            // End draw code

            // Commented code
            DiffuseMaterial myMaterial = new DiffuseMaterial(Brushes.Red);
            myGeometryModel.Material = myMaterial;

            RotateTransform3D myRotateTransform3D = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 1, 0), 0), new Point3D(0, 0, 0));

            //Transform3DGroup trGrp = new Transform3DGroup();
            //RotateTransform3D nrt1 = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 1, 0), 45));
            //RotateTransform3D nrt2 = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 1, 0), 45));
            //TranslateTransform3D trs = new TranslateTransform3D(new Vector3D(0, 0, 0));
            //trGrp.Children.Clear();
            //trGrp.Children.Add(nrt1);
            //trGrp.Children.Add(nrt2);
            //trGrp.Children.Add(myRotateTransform3D);
            //trGrp.Children.Add(trs);
            //myGeometryModel.Transform = trGrp;

            DoubleAnimation rotAnimaion = new DoubleAnimation(360, 0, new Duration(TimeSpan.FromSeconds(2)));
            rotAnimaion.RepeatBehavior = RepeatBehavior.Forever;
            myRotateTransform3D.Rotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, rotAnimaion);

            // Add the geometry model to the model group.

            myModel3DGroup.Children.Add(myGeometryModel);

            // Add the group of models to the ModelVisual3d.
            myModelVisual3D.Content = myModel3DGroup;
            // 
            myViewport3D.Children.Add(myModelVisual3D);

            // Apply the viewport to the page so it will be rendered.
            this.Content = myViewport3D;
        }
    }
}