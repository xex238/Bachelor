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
using System.Windows.Shapes;

namespace Wpf_2
{
    /// <summary>
    /// Логика взаимодействия для Added_window.xaml
    /// </summary>
    public partial class Added_window : Window
    {
        public Added_window()
        {
            InitializeComponent();
        }

        private void Start_button1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow("quadratic Bezier curve");
            mw.ShowDialog();
        }

        private void Square_Bezier_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow("straight_line");
            mw.ShowDialog();
        }

        private void arc_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow("arc");
            mw.ShowDialog();
        }

        private void Bezier_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow("Bezier curve");
            mw.ShowDialog();
        }
    }
}