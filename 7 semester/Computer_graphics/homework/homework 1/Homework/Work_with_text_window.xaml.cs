using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Homework
{
    /// <summary>
    /// Логика взаимодействия для Work_with_text_window.xaml
    /// </summary>
    public partial class Work_with_text_window : Window
    {
        string function = "";
        public Work_with_text_window()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //function = "window_1";
            MainWindow mw = new MainWindow();
            //this.Hide();
            mw.ShowDialog();
        }
        private void my_window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
        private void FlowDocumentReader_Click(object sender, RoutedEventArgs e)
        {
            function = "FlowDocumentReader";
            MainWindow_FlowDocumentReader MW_FlowDocumentReader = new MainWindow_FlowDocumentReader();
            MW_FlowDocumentReader.ShowDialog();
            //MainWindow mw = new MainWindow();
            //mw.ShowDialog();
        }
        private void FlowDocumentScrollViewerButton_Click(object sender, RoutedEventArgs e)
        {
            function = "FlowDocumentScrollViewer";
            MainWindow_FlowDocumentScrollViewer MW_FlowDocumentScrollViewer = new MainWindow_FlowDocumentScrollViewer();
            MW_FlowDocumentScrollViewer.ShowDialog();
            //MainWindow mw = new MainWindow();
            //mw.ShowDialog();
        }
        private void FlowDocumentPageViewerButton_Click(object sender, RoutedEventArgs e)
        {
            function = "FlowDocumentPageViewer";
            MainWindow_FlowDocumentPageViewer MW_FlowDocumentPageViewer = new MainWindow_FlowDocumentPageViewer();
            MW_FlowDocumentPageViewer.ShowDialog();
            //MainWindow mw = new MainWindow();
            //mw.ShowDialog();
        }
        private void RichTextBoxButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow_RichTextBox MW_RichTextBox = new MainWindow_RichTextBox();
            MW_RichTextBox.ShowDialog();
        }
        private void DocumentViewerButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow_DocumentViewer MW_DocumentViewer = new MainWindow_DocumentViewer();
            MW_DocumentViewer.ShowDialog();
        }
    }
}
