//// Код Дани
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
//namespace WpfApp6
//{
//    /// <summary>
//    /// Логика взаимодействия для MainWindow.xaml
//    /// </summary>
//    /// 

//    // Типы анимаций:
//    // Линейная
//    // По кватернионам
//    // По ключевым кадрам
//    // По пути
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

//            //Add light sources to the scene.
//            PointLight myDirLight = new PointLight(Color.FromRgb(255, 255, 255), new Point3D(0, 0, 10)); // Commented code
//            //DirectionalLight myDirLight = new DirectionalLight(Color.FromRgb(255, 255, 255), new Vector3D(1, 1, -3));

//            teapotModel.Geometry = (MeshGeometry3D)Application.Current.Resources["myTeapot"];

//            Brush objectBrush;

//            DiffuseMaterial diffuseMaterial;
//            SpecularMaterial specularMaterial;

//            MaterialGroup matGroup = new MaterialGroup();

//            matGroup.Children.Clear();
//            objectBrush = new SolidColorBrush(Color.FromArgb(255, 255, 0, 255));
//            diffuseMaterial = new DiffuseMaterial(objectBrush);
//            specularMaterial = new SpecularMaterial(new SolidColorBrush(Color.FromRgb(255, 255, 255)), 100);

//            matGroup.Children.Add(diffuseMaterial);
//            matGroup.Children.Add(specularMaterial);


//            teapotModel.Material = matGroup;

//            //// Исходный код (линейная анимация)
//            //RotateTransform3D myRotateTransform3D = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 1, 1), 45), new Point3D(0, 0, 0));
//            //Transform3DGroup trGrp = new Transform3DGroup();
//            //TranslateTransform3D trs = new TranslateTransform3D(new Vector3D(0, 0.5, 0));
//            //trGrp.Children.Clear();
//            //trGrp.Children.Add(myRotateTransform3D);
//            //trGrp.Children.Add(trs);
//            // teapotModel.Transform = trGrp;

//            ////Выполняет анимацию значения свойства Double между двумя целевыми значениями с помощью 
//            ////линейной интерполяции в течение указанного времени Duration.

//            // DoubleAnimation rotAnimaion = new DoubleAnimation(360, 0, new Duration(TimeSpan.FromSeconds(2)));
//            //rotAnimaion.RepeatBehavior = RepeatBehavior.Forever;
//            //myRotateTransform3D.Rotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, rotAnimaion);


//            // DoubleAnimation xAnim = new DoubleAnimation();
//            //xAnim.From = -2; xAnim.To = 2;
//            //xAnim.RepeatBehavior = new RepeatBehavior(20);
//            //xAnim.Duration = TimeSpan.FromSeconds(2);
//            //xAnim.AutoReverse = true;
//            //trs.BeginAnimation(TranslateTransform3D.OffsetXProperty, xAnim);
//            //// Конец исходного кода

//            //// Добавленный код (анимация по кватернионам)
//            //RotateTransform3D my_rotate_transform_3d = new RotateTransform3D();

//            //Quaternion q1 = new Quaternion(new Vector3D(1, 1, 0), 0);
//            //QuaternionRotation3D my_quaternion_rotated_3d = new QuaternionRotation3D(q1);
//            //my_rotate_transform_3d.Rotation = my_quaternion_rotated_3d;
//            //teapotModel.Transform = my_rotate_transform_3d;

//            //QuaternionAnimation q_animation = new QuaternionAnimation(new Quaternion(new Vector3D(0, 1, 1), 0), new Quaternion(new Vector3D(1, 1, 1), 359), new Duration(TimeSpan.FromSeconds(4)));
//            //q_animation.UseShortestPath = false;
//            //q_animation.RepeatBehavior = RepeatBehavior.Forever;
//            //my_rotate_transform_3d.Rotation.BeginAnimation(QuaternionRotation3D.QuaternionProperty, q_animation);
//            //// Конец добавленного кода

//            // Добавленный код (анимация по ключевым кадрам)
//            PointAnimation PA = new PointAnimation();



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










// Код с изменением цвета (нелинейный, резкий)
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
namespace WpfApp6
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	/// 

	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		Model3DGroup modelGroup = new Model3DGroup();
		PerspectiveCamera myPCamera = new PerspectiveCamera();
		GeometryModel3D teapotModel = new GeometryModel3D();
		Transform3DCollection myTransforms = new Transform3DCollection();
		Viewport3D myViewport = new Viewport3D();

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			//Set camera viewpoint and properties.
			myPCamera.FarPlaneDistance = 20;
			myPCamera.NearPlaneDistance = 1;
			myPCamera.FieldOfView = 45;
			myPCamera.Position = new Point3D(0, 0, 10);
			myPCamera.LookDirection = new Vector3D(0, 0, -10);
			myPCamera.UpDirection = new Vector3D(0, 1, 0);

			//Add light sources to the scene.
			PointLight myDirLight = new PointLight(Color.FromRgb(255, 255, 255), new Point3D(0, 0, 10)); // Commented code
																										 //DirectionalLight myDirLight = new DirectionalLight(Color.FromRgb(255, 255, 255), new Vector3D(1, 1, -3));

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

			//RotateTransform3D myRotateTransform3D = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 1, 1), 45), new Point3D(0, 0, 0));
			//Transform3DGroup trGrp = new Transform3DGroup();
			//TranslateTransform3D trs = new TranslateTransform3D(new Vector3D(0, 0.5, 0));
			//trGrp.Children.Clear();
			//trGrp.Children.Add(myRotateTransform3D);
			//trGrp.Children.Add(trs);
			// teapotModel.Transform = trGrp;

			//Выполняет анимацию значения свойства Double между двумя целевыми значениями с помощью 
			//линейной интерполяции в течение указанного времени Duration.

			// DoubleAnimation rotAnimaion = new DoubleAnimation(360, 0, new Duration(TimeSpan.FromSeconds(2)));
			//rotAnimaion.RepeatBehavior = RepeatBehavior.Forever;
			//myRotateTransform3D.Rotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, rotAnimaion);


			// DoubleAnimation xAnim = new DoubleAnimation();
			//xAnim.From = -2; xAnim.To = 2;
			//xAnim.RepeatBehavior = new RepeatBehavior(20);
			//xAnim.Duration = TimeSpan.FromSeconds(2);
			//xAnim.AutoReverse = true;
			//trs.BeginAnimation(TranslateTransform3D.OffsetXProperty, xAnim);

			// Анимация кватернион
			RotateTransform3D rotate_transform = new RotateTransform3D();

			Quaternion q = new Quaternion(new Vector3D(1, 1, 0), 0);
			QuaternionRotation3D quaternion_rotated = new QuaternionRotation3D(q);
			rotate_transform.Rotation = quaternion_rotated;
			teapotModel.Transform = rotate_transform;

			QuaternionAnimation q_animation = new QuaternionAnimation(new Quaternion(new Vector3D(0, 1, 1), 0), new Quaternion(new Vector3D(1, 1, 1), 359), new Duration(TimeSpan.FromSeconds(4)));
			q_animation.UseShortestPath = false;
			q_animation.RepeatBehavior = RepeatBehavior.Forever;
			rotate_transform.Rotation.BeginAnimation(QuaternionRotation3D.QuaternionProperty, q_animation);

			// Анимация цвета по ключевым кадрам
			ColorAnimationUsingKeyFrames color_animation = new ColorAnimationUsingKeyFrames();

			color_animation.KeyFrames.Add(new DiscreteColorKeyFrame(Color.FromRgb(255, 255, 255), KeyTime.FromTimeSpan(new TimeSpan(0, 0, 1))));
			color_animation.KeyFrames.Add(new DiscreteColorKeyFrame(Color.FromRgb(255, 255, 0), KeyTime.FromTimeSpan(new TimeSpan(0, 0, 2))));
			color_animation.KeyFrames.Add(new DiscreteColorKeyFrame(Color.FromRgb(255, 0, 0), KeyTime.FromTimeSpan(new TimeSpan(0, 0, 3))));

			teapotModel.Material = matGroup;

			color_animation.RepeatBehavior = RepeatBehavior.Forever;

			objectBrush.BeginAnimation(SolidColorBrush.ColorProperty, color_animation);

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