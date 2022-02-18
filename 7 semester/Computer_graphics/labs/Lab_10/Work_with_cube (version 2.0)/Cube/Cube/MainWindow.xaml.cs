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

            // Create a collection of vertex positions for the MeshGeometry3D. 
            Point3DCollection myPositionCollection = new Point3DCollection();
            myPositionCollection.Add(new Point3D(0, 0, 0));
            myPositionCollection.Add(new Point3D(1, 0, 0));
            myPositionCollection.Add(new Point3D(0, 1, 0));
            myPositionCollection.Add(new Point3D(1, 1, 0));
            //2
            myPositionCollection.Add(new Point3D(0, 0, 0));
            myPositionCollection.Add(new Point3D(0, 0, 1));
            myPositionCollection.Add(new Point3D(0, 1, 0));
            myPositionCollection.Add(new Point3D(0, 1, 1));
            //3
            myPositionCollection.Add(new Point3D(0, 0, 0));
            myPositionCollection.Add(new Point3D(1, 0, 0));
            myPositionCollection.Add(new Point3D(0, 0, 1));
            myPositionCollection.Add(new Point3D(1, 0, 1));
            //4
            myPositionCollection.Add(new Point3D(1, 0, 0));
            myPositionCollection.Add(new Point3D(1, 1, 1));
            myPositionCollection.Add(new Point3D(1, 0, 1));
            myPositionCollection.Add(new Point3D(1, 1, 0));
            //5
            myPositionCollection.Add(new Point3D(0, 0, 1));
            myPositionCollection.Add(new Point3D(1, 0, 1));
            myPositionCollection.Add(new Point3D(0, 1, 1));
            myPositionCollection.Add(new Point3D(1, 1, 1));
            //6
            myPositionCollection.Add(new Point3D(0, 1, 0));
            myPositionCollection.Add(new Point3D(0, 1, 1));
            myPositionCollection.Add(new Point3D(1, 1, 0));
            myPositionCollection.Add(new Point3D(1, 1, 1));

            myMeshGeometry3D.Positions = myPositionCollection;
            // Create a collection of triangle indices for the MeshGeometry3D.
            Int32Collection myTriangleIndicesCollection = new Int32Collection();
            PointCollection myTextureCollection = new PointCollection();

            myTriangleIndicesCollection.Add(0);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(3);
            //2
            myTriangleIndicesCollection.Add(4);
            myTriangleIndicesCollection.Add(5);
            myTriangleIndicesCollection.Add(6);
            myTriangleIndicesCollection.Add(6);
            myTriangleIndicesCollection.Add(5);
            myTriangleIndicesCollection.Add(7);
            //3
            myTriangleIndicesCollection.Add(8);
            myTriangleIndicesCollection.Add(9);
            myTriangleIndicesCollection.Add(10);
            myTriangleIndicesCollection.Add(9);
            myTriangleIndicesCollection.Add(11);
            myTriangleIndicesCollection.Add(10);
            //4
            myTriangleIndicesCollection.Add(12);
            myTriangleIndicesCollection.Add(13);
            myTriangleIndicesCollection.Add(14);
            myTriangleIndicesCollection.Add(12);
            myTriangleIndicesCollection.Add(15);
            myTriangleIndicesCollection.Add(13);
            //5
            myTriangleIndicesCollection.Add(16);
            myTriangleIndicesCollection.Add(17);
            myTriangleIndicesCollection.Add(18);
            myTriangleIndicesCollection.Add(19);
            myTriangleIndicesCollection.Add(18);
            myTriangleIndicesCollection.Add(17);
            //6
            myTriangleIndicesCollection.Add(20);
            myTriangleIndicesCollection.Add(21);
            myTriangleIndicesCollection.Add(22);
            myTriangleIndicesCollection.Add(22);
            myTriangleIndicesCollection.Add(21);
            myTriangleIndicesCollection.Add(23);

            //1
            myTextureCollection.Add(new Point(0, 0));
            myTextureCollection.Add(new Point(0, 1));
            myTextureCollection.Add(new Point(1, 0));
            myTextureCollection.Add(new Point(1, 1));
            //2
            myTextureCollection.Add(new Point(1, 1));
            myTextureCollection.Add(new Point(0, 1));
            myTextureCollection.Add(new Point(1, 0));
            myTextureCollection.Add(new Point(0, 0));
            //3
            myTextureCollection.Add(new Point(0, 0));
            myTextureCollection.Add(new Point(1, 0));
            myTextureCollection.Add(new Point(0, 1));
            myTextureCollection.Add(new Point(1, 1));
            //4
            myTextureCollection.Add(new Point(0, 1));
            myTextureCollection.Add(new Point(1, 0));
            myTextureCollection.Add(new Point(0, 0));
            myTextureCollection.Add(new Point(1, 1));
            //5
            myTextureCollection.Add(new Point(1, 1));
            myTextureCollection.Add(new Point(0, 1));
            myTextureCollection.Add(new Point(1, 0));
            myTextureCollection.Add(new Point(0, 0));
            //6
            myTextureCollection.Add(new Point(0, 0));
            myTextureCollection.Add(new Point(0, 1));
            myTextureCollection.Add(new Point(1, 0));
            myTextureCollection.Add(new Point(1, 1));

            myMeshGeometry3D.TriangleIndices = myTriangleIndicesCollection;
            myMeshGeometry3D.TextureCoordinates = myTextureCollection;

            // Apply the mesh to the geometry model.
            myGeometryModel.Geometry = myMeshGeometry3D;

            // Код с листочка (работает)
            BitmapImage bm1 = new BitmapImage();
            bm1.BeginInit();
            bm1.UriSource = new Uri("lotos.bmp", UriKind.Relative);
            //bm1.UriSource = new Uri("pivo.bmp", UriKind.Relative);
            bm1.EndInit();

            ImageBrush imgBrush = new ImageBrush(bm1);

            DiffuseMaterial myMatherial = new DiffuseMaterial(imgBrush);
            myGeometryModel.Material = myMatherial;
            // Конец кода с листочка

            RotateTransform3D myRotateTransform3D = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 1, 0), 0), new Point3D(0, 0, 0));

            Transform3DGroup trGrp = new Transform3DGroup();
            RotateTransform3D nrt1 = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 1, 0), 45));
            RotateTransform3D nrt2 = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 1, 0), 45));
            TranslateTransform3D trs = new TranslateTransform3D(new Vector3D(0, 0, 0));
            trGrp.Children.Clear();
            trGrp.Children.Add(nrt1);
            trGrp.Children.Add(nrt2);
            trGrp.Children.Add(myRotateTransform3D);
            trGrp.Children.Add(trs);
            myGeometryModel.Transform = trGrp;

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
        private void Window_Loaded2(object sender, RoutedEventArgs e)
        {
            // Declare scene objects.
            Viewport3D myViewport3D = new Viewport3D();
            Model3DGroup myModel3DGroup = new Model3DGroup();
            GeometryModel3D myGeometryModel = new GeometryModel3D();
            ModelVisual3D myModelVisual3D = new ModelVisual3D();

            OrthographicCamera myOCamera = new OrthographicCamera(new Point3D(0, 0, 8), new Vector3D(0, 0, -3), new Vector3D(0, 1, 0), 8);
            myViewport3D.Camera = myOCamera;

            DirectionalLight myDirectionalLight = new DirectionalLight();
            myDirectionalLight.Color = Colors.White;
            myDirectionalLight.Direction = new Vector3D(1, 1, -25);

            myModel3DGroup.Children.Add(myDirectionalLight);

            // The geometry specifes the shape of the 3D plane. In this sample, a flat sheet 
            // is created.
            MeshGeometry3D myMeshGeometry3D = new MeshGeometry3D();

            // Create a collection of normal vectors for the MeshGeometry3D.
            Vector3DCollection myNormalCollection = new Vector3DCollection();



            // Create a collection of vertex positions for the MeshGeometry3D. 
            Point3DCollection myPositionCollection = new Point3DCollection();
            myPositionCollection.Add(new Point3D(0, 0, 0));//0
            myPositionCollection.Add(new Point3D(1, 0, 0));//1
            myPositionCollection.Add(new Point3D(1, 0, 1));//2
            myPositionCollection.Add(new Point3D(1, 0, 1));//3
            myPositionCollection.Add(new Point3D(0, 0, 1));//4
            myPositionCollection.Add(new Point3D(0, 0, 0));//5


            myPositionCollection.Add(new Point3D(0, 0, 0));//6
            myPositionCollection.Add(new Point3D(0, 0, 1));//7
            myPositionCollection.Add(new Point3D(0, 1, 1));//8
            myPositionCollection.Add(new Point3D(0, 1, 1));//9
            myPositionCollection.Add(new Point3D(0, 1, 0));//10
            myPositionCollection.Add(new Point3D(0, 0, 0));//11


            myPositionCollection.Add(new Point3D(0, 0, 0));//12
            myPositionCollection.Add(new Point3D(0, 1, 0));//13
            myPositionCollection.Add(new Point3D(1, 1, 0));//14
            myPositionCollection.Add(new Point3D(1, 1, 0));//15
            myPositionCollection.Add(new Point3D(1, 0, 0));//16
            myPositionCollection.Add(new Point3D(0, 0, 0));//17


            myPositionCollection.Add(new Point3D(1, 0, 0));//18
            myPositionCollection.Add(new Point3D(1, 1, 0));//19
            myPositionCollection.Add(new Point3D(1, 1, 1));//20
            myPositionCollection.Add(new Point3D(1, 1, 1));//21
            myPositionCollection.Add(new Point3D(1, 0, 1));//22
            myPositionCollection.Add(new Point3D(1, 0, 0));//23

            myPositionCollection.Add(new Point3D(1, 1, 1));//24
            myPositionCollection.Add(new Point3D(1, 1, 0));//25
            myPositionCollection.Add(new Point3D(0, 1, 0));//26
            myPositionCollection.Add(new Point3D(0, 1, 0));//27
            myPositionCollection.Add(new Point3D(0, 1, 1));//28
            myPositionCollection.Add(new Point3D(1, 1, 1));//29


            myPositionCollection.Add(new Point3D(1, 0, 1));//30
            myPositionCollection.Add(new Point3D(1, 1, 1));//31
            myPositionCollection.Add(new Point3D(0, 1, 1));//32
            myPositionCollection.Add(new Point3D(0, 1, 1));//33
            myPositionCollection.Add(new Point3D(0, 0, 1));//34
            myPositionCollection.Add(new Point3D(1, 0, 1));//35

            myMeshGeometry3D.Positions = myPositionCollection;
            // Create a collection of triangle indices for the MeshGeometry3D.
            Int32Collection myTriangleIndicesCollection = new Int32Collection();

            myTriangleIndicesCollection.Add(0);
            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(3);
            myTriangleIndicesCollection.Add(4);
            myTriangleIndicesCollection.Add(5);

            myTriangleIndicesCollection.Add(6);
            myTriangleIndicesCollection.Add(7);
            myTriangleIndicesCollection.Add(8);
            myTriangleIndicesCollection.Add(9);
            myTriangleIndicesCollection.Add(10);
            myTriangleIndicesCollection.Add(11);


            myTriangleIndicesCollection.Add(12);
            myTriangleIndicesCollection.Add(13);
            myTriangleIndicesCollection.Add(14);
            myTriangleIndicesCollection.Add(15);
            myTriangleIndicesCollection.Add(16);
            myTriangleIndicesCollection.Add(17);

            myTriangleIndicesCollection.Add(18);
            myTriangleIndicesCollection.Add(19);
            myTriangleIndicesCollection.Add(20);
            myTriangleIndicesCollection.Add(21);
            myTriangleIndicesCollection.Add(22);
            myTriangleIndicesCollection.Add(23);


            myTriangleIndicesCollection.Add(24);
            myTriangleIndicesCollection.Add(25);
            myTriangleIndicesCollection.Add(26);
            myTriangleIndicesCollection.Add(27);
            myTriangleIndicesCollection.Add(28);
            myTriangleIndicesCollection.Add(29);


            myTriangleIndicesCollection.Add(30);
            myTriangleIndicesCollection.Add(31);
            myTriangleIndicesCollection.Add(32);
            myTriangleIndicesCollection.Add(33);
            myTriangleIndicesCollection.Add(34);
            myTriangleIndicesCollection.Add(35);


            myMeshGeometry3D.TriangleIndices = myTriangleIndicesCollection;

            PointCollection myTextureCollection = new PointCollection();

            //для невидимых
            myTextureCollection.Add(new Point(0, 0));
            myTextureCollection.Add(new Point(0, 1));
            myTextureCollection.Add(new Point(1, 1));
            myTextureCollection.Add(new Point(1, 1));
            myTextureCollection.Add(new Point(1, 0));
            myTextureCollection.Add(new Point(0, 0));

            myTextureCollection.Add(new Point(0, 0));
            myTextureCollection.Add(new Point(0, 1));
            myTextureCollection.Add(new Point(1, 1));
            myTextureCollection.Add(new Point(1, 1));
            myTextureCollection.Add(new Point(1, 0));
            myTextureCollection.Add(new Point(0, 0));

            myTextureCollection.Add(new Point(0, 0));
            myTextureCollection.Add(new Point(0, 1));
            myTextureCollection.Add(new Point(1, 1));
            myTextureCollection.Add(new Point(1, 1));
            myTextureCollection.Add(new Point(1, 0));
            myTextureCollection.Add(new Point(0, 0));

            //для видимых
            myTextureCollection.Add(new Point(0, 0));
            myTextureCollection.Add(new Point(1, 0));
            myTextureCollection.Add(new Point(1, 1));
            myTextureCollection.Add(new Point(1, 1));
            myTextureCollection.Add(new Point(0, 1));
            myTextureCollection.Add(new Point(0, 0));

            myTextureCollection.Add(new Point(0, 0));
            myTextureCollection.Add(new Point(1, 0));
            myTextureCollection.Add(new Point(1, 1));
            myTextureCollection.Add(new Point(1, 1));
            myTextureCollection.Add(new Point(0, 1));
            myTextureCollection.Add(new Point(0, 0));

            myTextureCollection.Add(new Point(0, 0));
            myTextureCollection.Add(new Point(1, 0));
            myTextureCollection.Add(new Point(1, 1));
            myTextureCollection.Add(new Point(1, 1));
            myTextureCollection.Add(new Point(0, 1));
            myTextureCollection.Add(new Point(0, 0));



            myMeshGeometry3D.TextureCoordinates = myTextureCollection;


            // Apply the mesh to the geometry model.
            myGeometryModel.Geometry = myMeshGeometry3D;


            BitmapImage mybit = new BitmapImage();
            mybit.BeginInit();
            mybit.UriSource = new Uri("lotos.bmp");
            mybit.EndInit();

            ImageBrush img = new ImageBrush();
            img.ImageSource = mybit;
            DiffuseMaterial myMaterial = new DiffuseMaterial();
            myMaterial.Brush = img;
            myGeometryModel.Material = myMaterial;

            RotateTransform3D myRotateTransform3D = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 1, 0), 0), new Point3D(0, 0, 0));

            Transform3DGroup trGrp = new Transform3DGroup();
            RotateTransform3D nrt1 = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 1, 0), 45));
            RotateTransform3D nrt2 = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 1, 0), 45));
            TranslateTransform3D trs = new TranslateTransform3D(new Vector3D(0, 0, 0));
            trGrp.Children.Clear();
            trGrp.Children.Add(nrt1);
            trGrp.Children.Add(nrt2);
            trGrp.Children.Add(myRotateTransform3D);
            trGrp.Children.Add(trs);
            myGeometryModel.Transform = trGrp;

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