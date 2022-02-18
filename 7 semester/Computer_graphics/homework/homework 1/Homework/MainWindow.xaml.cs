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

// Подключенные библиотеки
using System.Windows.Xps.Packaging;
using System.Windows.Markup;
using System.IO;
using Microsoft.Win32;
using System.Windows.Annotations;
using System.Windows.Annotations.Storage;
using System.Diagnostics;
using System.Windows.Xps;

namespace Homework
{
    public partial class MainWindow : Window
    {
        protected Menu mainMenu = new Menu();

        // Создаем меню «Файл».
        protected MenuItem fileMenuItem = new MenuItem();

        protected MenuItem openMenuItem = new MenuItem();
        protected ToolTip openToolTip = new ToolTip();

        protected MenuItem saveMenuItem = new MenuItem();
        protected ToolTip saveToolTip = new ToolTip();

        protected MenuItem exitMenuItem = new MenuItem();
        protected ToolTip exitToolTip = new ToolTip();

        // Блочные элементы
        protected MenuItem block_examples = new MenuItem();
        protected MenuItem block_paragraph_example = new MenuItem();
        protected MenuItem block_list_example = new MenuItem();
        protected MenuItem block_table_example = new MenuItem();
        protected MenuItem block_section_example = new MenuItem();
        protected MenuItem block_UIContainer_example = new MenuItem();

        // Строчные элементы
        protected MenuItem lowercase_examples = new MenuItem();
        protected MenuItem block_span_example = new MenuItem();
        protected MenuItem block_hyperlink_example = new MenuItem();
        protected MenuItem block_floater_example = new MenuItem();
        protected MenuItem block_figure_example = new MenuItem();

        // Аннотирование
        protected MenuItem work_with_annotations = new MenuItem();
        protected MenuItem create_comment = new MenuItem();
        protected MenuItem delete_comment = new MenuItem();
        protected MenuItem create_highlighting = new MenuItem();
        protected MenuItem delete_highlighting = new MenuItem();

        // Службы аннотирования
        // Поток для хранения аннотаций
        protected MemoryStream annotationMemoryStream;

        protected FileStream annotationFileStream;

        // Служба аннотирования
        protected AnnotationService myAnnotationService;
        public MainWindow()
        {
            InitializeComponent();
        }
        protected void Create_tools()
        {
            // Сделать главное меню.
            mainMenu.HorizontalAlignment = HorizontalAlignment.Stretch;
            mainMenu.VerticalAlignment = VerticalAlignment.Top;

            fileMenuItem.Header = "Файл";
            mainMenu.Items.Add(fileMenuItem);

            fileMenuItem.Items.Add(openMenuItem);
            openMenuItem.Header = "Открыть";

            openMenuItem.ToolTip = openToolTip;
            openToolTip.Content = "Открыть новый файл";

            fileMenuItem.Items.Add(saveMenuItem);
            saveMenuItem.Header = "Сохранить";

            saveMenuItem.ToolTip = saveToolTip;
            saveToolTip.Content = "Сохранить текущий файл";

            fileMenuItem.Items.Add(exitMenuItem);
            exitMenuItem.Header = "Выход";

            //// Используется для изменения размера
            //Thickness my_thickness = new Thickness();
            //my_thickness.Left = 50;
            //my_thickness.Right = 100;
            //my_thickness.Top = 50;
            //my_thickness.Bottom = 100;

            exitToolTip.Content = "Выйти из программы";
            //exitToolTip.Margin = my_thickness;
            exitMenuItem.ToolTip = exitToolTip;

            // Секция меню с примерами блочных элементов
            block_examples.Header = "Примеры с блочными элементами";
            mainMenu.Items.Add(block_examples);

            block_paragraph_example.Header = "Пример с элементом Paragraph";
            block_examples.Items.Add(block_paragraph_example);

            block_list_example.Header = "Пример с элементом List";
            block_examples.Items.Add(block_list_example);

            block_table_example.Header = "Пример с элементом Table";
            block_examples.Items.Add(block_table_example);

            block_section_example.Header = "Пример с элементом Section";
            block_examples.Items.Add(block_section_example);

            block_UIContainer_example.Header = "Пример с элементом BlockUIContainer";
            block_examples.Items.Add(block_UIContainer_example);

            // Секция меню с примерами строчных элементов
            lowercase_examples.Header = "Примеры со сточными элементами";
            mainMenu.Items.Add(lowercase_examples);

            block_span_example.Header = "Пример с элементом Span";
            lowercase_examples.Items.Add(block_span_example);

            block_hyperlink_example.Header = "Пример с элементом Hyperlink";
            lowercase_examples.Items.Add(block_hyperlink_example);

            block_floater_example.Header = "Пример с элементом Floater";
            lowercase_examples.Items.Add(block_floater_example);

            block_figure_example.Header = "Пример с элементом Figure";
            lowercase_examples.Items.Add(block_figure_example);

            // Секция с аннотациями
            work_with_annotations.Header = "Инструменты аннотирования";
            mainMenu.Items.Add(work_with_annotations);

            create_comment.Header = "Создать комментарий";
            create_comment.Command = AnnotationService.CreateTextStickyNoteCommand;
            work_with_annotations.Items.Add(create_comment);

            delete_comment.Header = "Удалить комментарий";
            delete_comment.Command = AnnotationService.DeleteStickyNotesCommand;
            work_with_annotations.Items.Add(delete_comment);

            create_highlighting.Header = "Выделить";
            create_highlighting.Command = AnnotationService.CreateHighlightCommand;
            work_with_annotations.Items.Add(create_highlighting);

            delete_highlighting.Header = "Удалить выделение";
            delete_highlighting.Command = AnnotationService.ClearHighlightsCommand;
            work_with_annotations.Items.Add(delete_highlighting);

            my_grid.Children.Add(mainMenu);
        }
        protected string File_Dialog()
        {
            OpenFileDialog open_file_dialog = new OpenFileDialog();
            open_file_dialog.Filter = "Все файлы (*.*)|*.*|Файл txt (*.txt)|*.txt|Файл XAML (*.xaml)|*.xaml|RTF-файл (*.rtf)|*.rtf";
            if (open_file_dialog.ShowDialog() == true)
            {
                return open_file_dialog.FileName;
            }
            return "";
        }
        protected void exitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Прощайте");
            this.Close();
        }
        protected string Save_File_Dialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                return saveFileDialog.FileName;
            }
            return "";
        }
        // Блочные элементы
        protected FlowDocument Example_Block_Paragraph(object sender, RoutedEventArgs e)
        {
            // Код 1. Работа с элементом Paragraph (работает)
            FlowDocument flow_document = new FlowDocument();
            Paragraph p = new Paragraph();
            Run run_1 = new Run();
            Run run_2 = new Run();
            Run run_3 = new Run();
            run_1.Text = "Hello world!\n";
            run_2.Text = "А это уже вторая строка\n";
            run_3.Text = "Теперь третья";
            p.Inlines.Add(run_1);
            p.Inlines.Add(run_2);
            p.Inlines.Add(run_3);
            flow_document.Blocks.Add(p);

            return flow_document;
        }
        protected FlowDocument Example_Block_List(object sender, RoutedEventArgs e)
        {
            FlowDocument flow_document = new FlowDocument();

            List languages = new List();
            languages.MarkerStyle = TextMarkerStyle.Box;

            ListItem list_item_1 = new ListItem();
            Paragraph paragraph_1 = new Paragraph();
            paragraph_1.Inlines.Add("C#");
            list_item_1.Blocks.Add(paragraph_1);
            languages.ListItems.Add(list_item_1);

            ListItem list_item_2 = new ListItem();
            Paragraph paragraph_2 = new Paragraph();
            paragraph_2.Inlines.Add("C++");
            list_item_2.Blocks.Add(paragraph_2);
            languages.ListItems.Add(list_item_2);

            ListItem list_item_3 = new ListItem();
            Paragraph paragraph_3 = new Paragraph();
            paragraph_3.Inlines.Add("Python");
            list_item_3.Blocks.Add(paragraph_3);
            languages.ListItems.Add(list_item_3);

            flow_document.Blocks.Add(languages);

            return flow_document;
        }
        protected FlowDocument Example_Block_Table(object sender, RoutedEventArgs e)
        {
            FlowDocument flow_document = new FlowDocument();

            Paragraph heading = new Paragraph();
            heading.Inlines.Add("Таблица:");
            flow_document.Blocks.Add(heading);

            Table table = new Table();
            TableColumn table_column_1 = new TableColumn();
            table_column_1.Width = GridLength.Auto;
            TableColumn table_column_2 = new TableColumn();
            table_column_2.Width = GridLength.Auto;
            table.Columns.Add(table_column_1);
            table.Columns.Add(table_column_2);

            TableRowGroup table_row_group_1 = new TableRowGroup();
            table_row_group_1.FontSize = 14;

            TableRow table_row_1 = new TableRow();

            TableCell table_cell_1 = new TableCell();
            Paragraph paragraph_1 = new Paragraph();
            paragraph_1.Inlines.Add("Элемент 11");
            table_cell_1.Blocks.Add(paragraph_1);

            TableCell table_cell_2 = new TableCell();
            Paragraph paragraph_2 = new Paragraph();
            paragraph_2.Inlines.Add("Элемент 12");
            table_cell_2.Blocks.Add(paragraph_2);

            table_row_1.Cells.Add(table_cell_1);
            table_row_1.Cells.Add(table_cell_2);

            TableRow table_row_2 = new TableRow();

            TableCell table_cell_3 = new TableCell();
            Paragraph paragraph_3 = new Paragraph();
            paragraph_3.Inlines.Add("Элемент 21");
            table_cell_3.Blocks.Add(paragraph_3);

            TableCell table_cell_4 = new TableCell();
            Paragraph paragraph_4 = new Paragraph();
            paragraph_4.Inlines.Add("Элемент 22");
            table_cell_4.Blocks.Add(paragraph_4);

            table_row_2.Cells.Add(table_cell_3);
            table_row_2.Cells.Add(table_cell_4);

            table_row_group_1.Rows.Add(table_row_1);
            table_row_group_1.Rows.Add(table_row_2);
            table.RowGroups.Add(table_row_group_1);

            flow_document.Blocks.Add(table);

            return flow_document;
        }
        protected FlowDocument Example_Block_Section(object sender, RoutedEventArgs e)
        {
            FlowDocument flow_document = new FlowDocument();

            Section section = new Section();

            Paragraph paragraph_1 = new Paragraph();
            Paragraph paragraph_2 = new Paragraph();
            Paragraph paragraph_3 = new Paragraph();
            Paragraph paragraph_4 = new Paragraph();

            paragraph_1.Inlines.Add("Флагманы 2016");
            paragraph_2.Inlines.Add("Xiaomi Mi5");
            paragraph_3.Inlines.Add("Samsung Galaxy S7");
            paragraph_4.Inlines.Add("HP Elite X3");

            section.Blocks.Add(paragraph_1);
            section.Blocks.Add(paragraph_2);
            section.Blocks.Add(paragraph_3);
            section.Blocks.Add(paragraph_4);

            flow_document.Blocks.Add(section);

            return flow_document;
        }
        protected FlowDocument Example_Block_UIContainer(object sender, RoutedEventArgs e)
        {
            FlowDocument flow_document = new FlowDocument();

            Paragraph paragraph = new Paragraph();
            paragraph.Inlines.Add("Заголовок");
            flow_document.Blocks.Add(paragraph);

            BlockUIContainer blockUIContainer = new BlockUIContainer();
            blockUIContainer.FontSize = 13;

            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Vertical;

            TextBlock textBlock = new TextBlock();
            textBlock.Height = 40;
            textBlock.Text = "Нажмите на кнопку для продолжения...";

            Button button = new Button();
            button.Width = 120;
            button.Content = "Нажми меня";

            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(button);

            blockUIContainer.Child = stackPanel;

            flow_document.Blocks.Add(blockUIContainer);

            return flow_document;
        }
        // Строчные элементы
        protected FlowDocument Example_Block_Span(object sender, RoutedEventArgs e)
        {
            FlowDocument flow_document = new FlowDocument();

            // Paragraph 1
            Paragraph paragraph = new Paragraph();
            Span span = new Span();
            span.Background = Brushes.Red;

            Run run_1 = new Run();
            run_1.Text = "Это отличный WPF проект!\n";

            Run run_2 = new Run();
            run_2.Text = "Демонстрация работы блока Span\n";

            paragraph.Inlines.Add(run_1);
            paragraph.Inlines.Add(run_2);

            // Paragraph 2
            Paragraph paragraph_2 = new Paragraph();
            Span span_2 = new Span();
            span_2.Background = Brushes.Wheat;

            Italic italic = new Italic();
            italic.Inlines.Add("Текст, написанный курсивом\n");

            Bold bold = new Bold();
            bold.Inlines.Add("Это очень жирный текст\n");

            Underline underline = new Underline();
            underline.Inlines.Add("А это подчёркнутый текст\n");

            span_2.Inlines.Add(italic);
            span_2.Inlines.Add(bold);
            span_2.Inlines.Add(underline);

            paragraph_2.Inlines.Add(span_2);

            flow_document.Blocks.Add(paragraph);
            flow_document.Blocks.Add(paragraph_2);

            return flow_document;
        }
        protected FlowDocument Example_Block_Hyperlink(object sender, RoutedEventArgs e)
        {
            FlowDocument flow_document = new FlowDocument();

            try
            {
                Paragraph paragraph = new Paragraph();

                //Run run = new Run("Сайт Microsoft");
                Hyperlink hyperlink = new Hyperlink();
                hyperlink.Inlines.Add("Сайт Microsoft");
                hyperlink.NavigateUri = new Uri(@"http:\\microsoft.com");
                hyperlink.RequestNavigate += Hyperlink_Click;
                //hyperlink.Click += Hyperlink_Click;

                paragraph.Inlines.Add(hyperlink);

                flow_document.Blocks.Add(paragraph);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return flow_document;
        }
        protected FlowDocument Example_Block_Floater(object sender, RoutedEventArgs e)
        {
            FlowDocument flow_document = new FlowDocument();

            Paragraph paragraph_1 = new Paragraph();
            paragraph_1.Inlines.Add("Уже смерклось, когда князь Андрей и Пьер подъехали к главному подъезду лысогорского дома. В то время как они подъезжали, князь Андрей с улыбкой обратил внимание Пьера на суматоху, происшедшую у заднего крыльца. Согнутая старушка с котомкой на спине и невысокий мужчина в черном одеянии и с длинными волосами, увидав въезжавшую коляску, бросились бежать назад в ворота. Две женщины выбежали за ними, и все четверо, оглядываясь на коляску, испуганно вбежали на заднее крыльцо.\n");

            Floater floater = new Floater();
            floater.Width = 170;
            floater.Padding = new Thickness(5);
            floater.HorizontalAlignment = HorizontalAlignment.Left;
            floater.FontSize = 18;
            floater.FontStyle = FontStyles.Italic;

            Paragraph paragraph_2 = new Paragraph();
            paragraph_2.Inlines.Add("Война и Мир. Глава 13");

            BlockUIContainer blockUIContainer = new BlockUIContainer();
            Image image = new Image(); // Можно добавить вставку картинки

            floater.Blocks.Add(paragraph_2);

            paragraph_1.Inlines.Add(floater);

            paragraph_1.Inlines.Add("– Это Машины божьи люди, – сказал князь Андрей. – Они приняли нас за отца. А это единственно, в чем она не повинуется ему: он велит гонять этих странников, а она принимает их.\n – Да что такое божьи люди? – спросил Пьер.\n Князь Андрей не успел ответить ему. Слуги вышли навстречу, и он расспрашивал о том, где был старый князь и скоро ли ждут его.\n Старый князь был еще в городе, и его ждали каждую минуту.\n Князь Андрей провел Пьера на свою половину, всегда в полной исправности ожидавшую его в доме его отца, и сам пошел в детскую.");

            flow_document.Blocks.Add(paragraph_1);

            return flow_document;
        }
        protected FlowDocument Example_Block_Figure(object sender, RoutedEventArgs e)
        {
            FlowDocument flow_document = new FlowDocument();

            Paragraph paragraph_1 = new Paragraph();
            paragraph_1.Inlines.Add("Уже смерклось, когда князь Андрей и Пьер подъехали к главному подъезду лысогорского дома. В то время как они подъезжали, князь Андрей с улыбкой обратил внимание Пьера на суматоху, происшедшую у заднего крыльца. Согнутая старушка с котомкой на спине и невысокий мужчина в черном одеянии и с длинными волосами, увидав въезжавшую коляску, бросились бежать назад в ворота. Две женщины выбежали за ними, и все четверо, оглядываясь на коляску, испуганно вбежали на заднее крыльцо.\n");

            Figure figure = new Figure();
            figure.Width = new FigureLength(170);
            figure.Padding = new Thickness(5);
            figure.HorizontalAnchor = FigureHorizontalAnchor.ContentLeft;
            figure.FontSize = 18;
            figure.FontStyle = FontStyles.Italic;

            Paragraph paragraph_2 = new Paragraph();
            paragraph_2.Inlines.Add("Война и Мир. Глава 13");
            figure.Blocks.Add(paragraph_2);

            paragraph_1.Inlines.Add(figure);

            paragraph_1.Inlines.Add("– Это Машины божьи люди, – сказал князь Андрей. – Они приняли нас за отца. А это единственно, в чем она не повинуется ему: он велит гонять этих странников, а она принимает их.\n – Да что такое божьи люди? – спросил Пьер.\n Князь Андрей не успел ответить ему. Слуги вышли навстречу, и он расспрашивал о том, где был старый князь и скоро ли ждут его.\n Старый князь был еще в городе, и его ждали каждую минуту.\n Князь Андрей провел Пьера на свою половину, всегда в полной исправности ожидавшую его в доме его отца, и сам пошел в детскую.");

            flow_document.Blocks.Add(paragraph_1);

            return flow_document;
        }


        protected void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Example_Block_Span(sender, e);
                //Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
                //e.Handled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
    // Поточные документы
    public partial class MainWindow_FlowDocumentScrollViewer : MainWindow
    {
        FlowDocumentScrollViewer myFlowDocumentScrollViewer = new FlowDocumentScrollViewer(); // Работает

        FlowDocument myFlowDocument = new FlowDocument();
        public MainWindow_FlowDocumentScrollViewer()
        {
            this.Loaded += Window_Loaded;
            this.Unloaded += Window_Unloaded;

            myFlowDocumentScrollViewer.Name = "my_flow_document_reader";
            my_grid.Children.Add(myFlowDocumentScrollViewer);

            Create_tools();

            // Элементы меню "Файл"
            openMenuItem.Click += openMenuItem_Click;
            saveMenuItem.Click += saveMenuItem_Click;
            exitMenuItem.Click += exitMenuItem_Click;

            // Блочные элементы
            block_paragraph_example.Click += Block_Paragraph_Example_Click;
            block_list_example.Click += Block_List_Example_Click;
            block_table_example.Click += Block_Table_Example_Click;
            block_section_example.Click += Block_Section_Example_Click;
            block_UIContainer_example.Click += Block_UIContainer_Example_Click;

            // Строчные элементы
            block_span_example.Click += Block_Span_Example_Click;
            block_hyperlink_example.Click += Block_Hyperlink_Example_Click;
            block_floater_example.Click += Block_Floater_Example_Click;
            block_figure_example.Click += Block_Figure_Example_Click;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Инициализация службы аннотаций
            myAnnotationService = new AnnotationService(myFlowDocumentScrollViewer);

            // Создание связанного потока
            annotationFileStream = new FileStream("storage.xml", FileMode.OpenOrCreate);

            // Привязка потока к хранилищу аннотаций
            AnnotationStore annotationStore = new XmlStreamStore(annotationFileStream);
            annotationStore.AutoFlush = true;

            // Включение службы
            myAnnotationService.Enable(annotationStore);
        }
        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            if(myAnnotationService != null && myAnnotationService.IsEnabled)
            {
                myAnnotationService.Store.Flush();
                myAnnotationService.Disable();
                annotationFileStream.Close();
            }
        }
        // Элементы меню "Файл"
        private async void openMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = File_Dialog();

                StreamReader sr = new StreamReader(path);
                var strline = await sr.ReadToEndAsync();
                Paragraph my_paragraph = new Paragraph();
                my_paragraph.Inlines.Add(strline);

                //FlowDocument flow_document = new FlowDocument();
                //flow_document.Blocks.Add(my_paragraph);

                //my_flow_document_reader.Document = flow_document; // Раскомментировать при добавлении xaml
                myFlowDocument.Blocks.Clear();
                myFlowDocument.Blocks.Add(my_paragraph);
                //my_flow_document_2.Blocks.Clear();
                //my_flow_document_2.Blocks.Add(my_paragraph);
                //my_flow_document_3.Blocks.Clear();
                //my_flow_document_3.Blocks.Add(my_paragraph);
                myFlowDocumentScrollViewer.Document = myFlowDocument;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void saveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextRange myTextRange = new TextRange(myFlowDocumentScrollViewer.Document.ContentStart, myFlowDocumentScrollViewer.Document.ContentEnd);
                string path = "";
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Все файлы (*.*)|*.*|Файл txt (*.txt)|*.txt|Файл XAML (*.xaml)|*.xaml|RTF-файл (*.rtf)|*.rtf";
                if (saveFileDialog.ShowDialog() == true)
                {
                    path = saveFileDialog.FileName;
                }

                //File.WriteAllText(path, myFlowDocumentReader.Document.ToString()); // Сохранение в одну строку
                FileStream myFileStream = File.Create(saveFileDialog.FileName);
                if (System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower() == ".rtf")
                {
                    myTextRange.Save(myFileStream, DataFormats.Rtf);
                }
                if (System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower() == ".txt")
                {
                    myTextRange.Save(myFileStream, DataFormats.Text);
                }
                if (System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower() == ".xaml")
                {
                    myTextRange.Save(myFileStream, DataFormats.Xaml);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // Блочные элементы меню
        private void Block_Paragraph_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentScrollViewer.Document = Example_Block_Paragraph(sender, e);
        }
        private void Block_List_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentScrollViewer.Document = Example_Block_List(sender, e);
        }
        private void Block_Table_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentScrollViewer.Document = Example_Block_Table(sender, e);
        }
        private void Block_Section_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentScrollViewer.Document = Example_Block_Section(sender, e);
        }
        private void Block_UIContainer_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentScrollViewer.Document = Example_Block_UIContainer(sender, e);
        }
        // Строчные элементы меню
        private void Block_Span_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentScrollViewer.Document = Example_Block_Span(sender, e);
        }
        private void Block_Hyperlink_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentScrollViewer.Document = Example_Block_Hyperlink(sender, e);
        }
        private void Block_Floater_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentScrollViewer.Document = Example_Block_Floater(sender, e);
        }
        private void Block_Figure_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentScrollViewer.Document = Example_Block_Figure(sender, e);
        }
    }
    public partial class MainWindow_FlowDocumentPageViewer : MainWindow
    {
        FlowDocumentPageViewer myFlowDocumentPageViewer = new FlowDocumentPageViewer(); // Работает

        FlowDocument myFlowDocument = new FlowDocument();
        public MainWindow_FlowDocumentPageViewer()
        {
            myFlowDocumentPageViewer.Name = "my_flow_document_reader";
            my_grid.Children.Add(myFlowDocumentPageViewer);

            Create_tools();

            // Элементы меню "Файл"
            openMenuItem.Click += openMenuItem_Click;
            saveMenuItem.Click += saveMenuItem_Click;
            exitMenuItem.Click += exitMenuItem_Click;

            // Блочные элементы
            block_paragraph_example.Click += Block_Paragraph_Example_Click;
            block_list_example.Click += Block_List_Example_Click;
            block_table_example.Click += Block_Table_Example_Click;
            block_section_example.Click += Block_Section_Example_Click;
            block_UIContainer_example.Click += Block_UIContainer_Example_Click;

            // Строчные элементы
            block_span_example.Click += Block_Span_Example_Click;
            block_hyperlink_example.Click += Block_Hyperlink_Example_Click;
            block_floater_example.Click += Block_Floater_Example_Click;
            block_figure_example.Click += Block_Figure_Example_Click;
        }
        // Элементы меню "Файл"
        private async void openMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = File_Dialog();

                StreamReader sr = new StreamReader(path);
                var strline = await sr.ReadToEndAsync();
                Paragraph my_paragraph = new Paragraph();
                my_paragraph.Inlines.Add(strline);

                //FlowDocument flow_document = new FlowDocument();
                //flow_document.Blocks.Add(my_paragraph);

                //my_flow_document_reader.Document = flow_document; // Раскомментировать при добавлении xaml
                myFlowDocument.Blocks.Clear();
                myFlowDocument.Blocks.Add(my_paragraph);
                //my_flow_document_2.Blocks.Clear();
                //my_flow_document_2.Blocks.Add(my_paragraph);
                //my_flow_document_3.Blocks.Clear();
                //my_flow_document_3.Blocks.Add(my_paragraph);
                myFlowDocumentPageViewer.Document = myFlowDocument;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void saveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //TextRange myTextRange = new TextRange(myFlowDocumentPageViewer.Document.ContentStart, myFlowDocumentPageViewer.Document.ContentEnd);
                //string path = "";
                //SaveFileDialog saveFileDialog = new SaveFileDialog();
                //saveFileDialog.Filter = "Все файлы (*.*)|*.*|Файл txt (*.txt)|*.txt|Файл XAML (*.xaml)|*.xaml|RTF-файл (*.rtf)|*.rtf";
                //if (saveFileDialog.ShowDialog() == true)
                //{
                //    path = saveFileDialog.FileName;
                //}

                ////File.WriteAllText(path, myFlowDocumentReader.Document.ToString()); // Сохранение в одну строку
                //FileStream myFileStream = File.Create(saveFileDialog.FileName);
                //if (System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower() == ".rtf")
                //{
                //    myTextRange.Save(myFileStream, DataFormats.Rtf);
                //}
                //if (System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower() == ".txt")
                //{
                //    myTextRange.Save(myFileStream, DataFormats.Text);
                //}
                //if (System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower() == ".xaml")
                //{
                //    myTextRange.Save(myFileStream, DataFormats.Xaml);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // Блочные элементы меню
        private void Block_Paragraph_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentPageViewer.Document = Example_Block_Paragraph(sender, e);
        }
        private void Block_List_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentPageViewer.Document = Example_Block_List(sender, e);
        }
        private void Block_Table_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentPageViewer.Document = Example_Block_Table(sender, e);
        }
        private void Block_Section_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentPageViewer.Document = Example_Block_Section(sender, e);
        }
        private void Block_UIContainer_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentPageViewer.Document = Example_Block_UIContainer(sender, e);
        }
        // Строчные элементы меню
        private void Block_Span_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentPageViewer.Document = Example_Block_Span(sender, e);
        }
        private void Block_Hyperlink_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentPageViewer.Document = Example_Block_Hyperlink(sender, e);
        }
        private void Block_Floater_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentPageViewer.Document = Example_Block_Floater(sender, e);
        }
        private void Block_Figure_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentPageViewer.Document = Example_Block_Figure(sender, e);
        }
    }
    public partial class MainWindow_FlowDocumentReader : MainWindow
    {
        FlowDocumentReader myFlowDocumentReader = new FlowDocumentReader(); // Работает

        FlowDocument myFlowDocument = new FlowDocument();
        public MainWindow_FlowDocumentReader()
        {
            myFlowDocumentReader.Name = "my_flow_document_reader";
            my_grid.Children.Add(myFlowDocumentReader);

            Create_tools();

            // Элементы меню "Файл"
            openMenuItem.Click += openMenuItem_Click;
            saveMenuItem.Click += saveMenuItem_Click;
            exitMenuItem.Click += exitMenuItem_Click;

            // Блочные элементы
            block_paragraph_example.Click += Block_Paragraph_Example_Click;
            block_list_example.Click += Block_List_Example_Click;
            block_table_example.Click += Block_Table_Example_Click;
            block_section_example.Click += Block_Section_Example_Click;
            block_UIContainer_example.Click += Block_UIContainer_Example_Click;

            // Строчные элементы
            block_span_example.Click += Block_Span_Example_Click;
            block_hyperlink_example.Click += Block_Hyperlink_Example_Click;
            block_floater_example.Click += Block_Floater_Example_Click;
            block_figure_example.Click += Block_Figure_Example_Click;
        }
        // Элементы меню "Файл"
        private async void openMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = File_Dialog();

                StreamReader sr = new StreamReader(path);
                var strline = await sr.ReadToEndAsync();
                Paragraph my_paragraph = new Paragraph();
                my_paragraph.Inlines.Add(strline);

                //FlowDocument flow_document = new FlowDocument();
                //flow_document.Blocks.Add(my_paragraph);

                //my_flow_document_reader.Document = flow_document; // Раскомментировать при добавлении xaml
                myFlowDocument.Blocks.Clear();
                myFlowDocument.Blocks.Add(my_paragraph);
                //my_flow_document_2.Blocks.Clear();
                //my_flow_document_2.Blocks.Add(my_paragraph);
                //my_flow_document_3.Blocks.Clear();
                //my_flow_document_3.Blocks.Add(my_paragraph);
                myFlowDocumentReader.Document = myFlowDocument;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void saveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextRange myTextRange = new TextRange(myFlowDocumentReader.Document.ContentStart, myFlowDocumentReader.Document.ContentEnd);
                string path = "";
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Все файлы (*.*)|*.*|Файл txt (*.txt)|*.txt|Файл XAML (*.xaml)|*.xaml|RTF-файл (*.rtf)|*.rtf";
                if (saveFileDialog.ShowDialog() == true)
                {
                    path = saveFileDialog.FileName;
                }

                //File.WriteAllText(path, myFlowDocumentReader.Document.ToString()); // Сохранение в одну строку
                FileStream myFileStream = File.Create(saveFileDialog.FileName);
                if (System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower() == ".rtf")
                {
                    myTextRange.Save(myFileStream, DataFormats.Rtf);
                }
                if (System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower() == ".txt")
                {
                    myTextRange.Save(myFileStream, DataFormats.Text);
                }
                if (System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower() == ".xaml")
                {
                    myTextRange.Save(myFileStream, DataFormats.Xaml);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // Блочные элементы меню
        private void Block_Paragraph_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentReader.Document = Example_Block_Paragraph(sender, e);
        }
        private void Block_List_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentReader.Document = Example_Block_List(sender, e);
        }
        private void Block_Table_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentReader.Document = Example_Block_Table(sender, e);
        }
        private void Block_Section_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentReader.Document = Example_Block_Section(sender, e);
        }
        private void Block_UIContainer_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentReader.Document = Example_Block_UIContainer(sender, e);
        }
        // Строчные элементы меню
        private void Block_Span_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentReader.Document = Example_Block_Span(sender, e);
        }
        private void Block_Hyperlink_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentReader.Document = Example_Block_Hyperlink(sender, e);
        }
        private void Block_Floater_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentReader.Document = Example_Block_Floater(sender, e);
        }
        private void Block_Figure_Example_Click(object sender, RoutedEventArgs e)
        {
            myFlowDocumentReader.Document = Example_Block_Figure(sender, e);
        }
    }
    // Документ с возможностью редактирования
    public partial class MainWindow_RichTextBox : MainWindow
    {
        RichTextBox rich_text_box = new RichTextBox();

        FlowDocument myFlowDocument = new FlowDocument();
        public MainWindow_RichTextBox()
        {
            rich_text_box.Name = "my_rich_text_box";
            my_grid.Children.Add(rich_text_box);

            Create_tools();

            // Элементы меню "Файл"
            openMenuItem.Click += openMenuItem_Click;
            saveMenuItem.Click += saveMenuItem_Click;
            exitMenuItem.Click += exitMenuItem_Click;

            // Блочные элементы
            block_paragraph_example.Click += Block_Paragraph_Example_Click;
            block_list_example.Click += Block_List_Example_Click;
            block_table_example.Click += Block_Table_Example_Click;
            block_section_example.Click += Block_Section_Example_Click;
            block_UIContainer_example.Click += Block_UIContainer_Example_Click;

            // Строчные элементы
            block_span_example.Click += Block_Span_Example_Click;
            block_hyperlink_example.Click += Block_Hyperlink_Example_Click;
            block_floater_example.Click += Block_Floater_Example_Click;
            block_figure_example.Click += Block_Figure_Example_Click;
        }
        // Элементы меню "Файл"
        private async void openMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = File_Dialog();

                StreamReader sr = new StreamReader(path);
                var strline = await sr.ReadToEndAsync();
                Paragraph my_paragraph = new Paragraph();
                my_paragraph.Inlines.Add(strline);

                //FlowDocument flow_document = new FlowDocument();
                //flow_document.Blocks.Add(my_paragraph);

                //my_flow_document_reader.Document = flow_document; // Раскомментировать при добавлении xaml
                myFlowDocument.Blocks.Clear();
                myFlowDocument.Blocks.Add(my_paragraph);
                //my_flow_document_2.Blocks.Clear();
                //my_flow_document_2.Blocks.Add(my_paragraph);
                //my_flow_document_3.Blocks.Clear();
                //my_flow_document_3.Blocks.Add(my_paragraph);
                rich_text_box.Document = myFlowDocument;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void saveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextRange myTextRange = new TextRange(rich_text_box.Document.ContentStart, rich_text_box.Document.ContentEnd);
                string path = "";
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Все файлы (*.*)|*.*|Файл txt (*.txt)|*.txt|Файл XAML (*.xaml)|*.xaml|RTF-файл (*.rtf)|*.rtf";
                if (saveFileDialog.ShowDialog() == true)
                {
                    path = saveFileDialog.FileName;
                }

                //File.WriteAllText(path, myFlowDocumentReader.Document.ToString()); // Сохранение в одну строку
                FileStream myFileStream = File.Create(saveFileDialog.FileName);
                if (System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower() == ".rtf")
                {
                    myTextRange.Save(myFileStream, DataFormats.Rtf);
                }
                if (System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower() == ".txt")
                {
                    myTextRange.Save(myFileStream, DataFormats.Text);
                }
                if (System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower() == ".xaml")
                {
                    myTextRange.Save(myFileStream, DataFormats.Xaml);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // Блочные элементы меню
        private void Block_Paragraph_Example_Click(object sender, RoutedEventArgs e)
        {
            rich_text_box.Document = Example_Block_Paragraph(sender, e);
        }
        private void Block_List_Example_Click(object sender, RoutedEventArgs e)
        {
            rich_text_box.Document = Example_Block_List(sender, e);
        }
        private void Block_Table_Example_Click(object sender, RoutedEventArgs e)
        {
            rich_text_box.Document = Example_Block_Table(sender, e);
        }
        private void Block_Section_Example_Click(object sender, RoutedEventArgs e)
        {
            rich_text_box.Document = Example_Block_Section(sender, e);
        }
        private void Block_UIContainer_Example_Click(object sender, RoutedEventArgs e)
        {
            rich_text_box.Document = Example_Block_UIContainer(sender, e);
        }
        // Строчные элементы меню
        private void Block_Span_Example_Click(object sender, RoutedEventArgs e)
        {
            rich_text_box.Document = Example_Block_Span(sender, e);
        }
        private void Block_Hyperlink_Example_Click(object sender, RoutedEventArgs e)
        {
            rich_text_box.Document = Example_Block_Hyperlink(sender, e);
        }
        private void Block_Floater_Example_Click(object sender, RoutedEventArgs e)
        {
            rich_text_box.Document = Example_Block_Floater(sender, e);
        }
        private void Block_Figure_Example_Click(object sender, RoutedEventArgs e)
        {
            rich_text_box.Document = Example_Block_Figure(sender, e);
        }
    }
    // Фиксированные документы
    public partial class MainWindow_DocumentViewer : MainWindow
    {
        DocumentViewer document_viewer = new DocumentViewer();

        FixedDocument fixed_document = new FixedDocument();
        public MainWindow_DocumentViewer()
        {
            document_viewer.Name = "document_viewer";
            my_grid.Children.Add(document_viewer);

            Create_tools();

            // Элементы меню "Файл"
            openMenuItem.Click += openMenuItem_Click;
            saveMenuItem.Click += saveMenuItem_Click;
            exitMenuItem.Click += exitMenuItem_Click;

            // Блочные элементы
            block_paragraph_example.Click += Block_Paragraph_Example_Click;
            block_list_example.Click += Block_List_Example_Click;
            block_table_example.Click += Block_Table_Example_Click;
            block_section_example.Click += Block_Section_Example_Click;
            block_UIContainer_example.Click += Block_UIContainer_Example_Click;

            // Строчные элементы
            block_span_example.Click += Block_Span_Example_Click;
            block_hyperlink_example.Click += Block_Hyperlink_Example_Click;
            block_floater_example.Click += Block_Floater_Example_Click;
            block_figure_example.Click += Block_Figure_Example_Click;

            Load_Example();
        }
        public void Load_Example()
        {
            PageContent pageContent_1 = new PageContent();

            FixedPage fixedPage_1 = new FixedPage();

            Grid grid_1 = new Grid();
            grid_1.Margin = new Thickness(10);
            grid_1.Width = 450;
            grid_1.Height = 600;

            TextBlock textBlock_1 = new TextBlock();
            textBlock_1.Text = "Текст первого блока";

            Ellipse ellipse = new Ellipse();
            ellipse.Stroke = Brushes.Green;
            ellipse.Width = 50;
            ellipse.Height = 50;
            ellipse.Fill = Brushes.Red;

            grid_1.Children.Add(textBlock_1);
            grid_1.Children.Add(ellipse);

            fixedPage_1.Children.Add(grid_1);

            pageContent_1.Child = fixedPage_1;

            PageContent pageContent_2 = new PageContent();
            pageContent_2.Width = 650;
            pageContent_2.Height = 900;

            FixedPage fixedPage_2 = new FixedPage();

            StackPanel stackPanel = new StackPanel();
            stackPanel.Margin = new Thickness(10);
            stackPanel.Width = 650;
            stackPanel.Height = 900;
            stackPanel.Background = Brushes.LightBlue;

            TextBlock textBlock_2 = new TextBlock();
            textBlock_2.Text = "Текст второго блока";

            stackPanel.Children.Add(textBlock_2);

            fixedPage_2.Children.Add(stackPanel);

            pageContent_2.Child = fixedPage_2;

            fixed_document.Pages.Add(pageContent_1);
            fixed_document.Pages.Add(pageContent_2);

            document_viewer.Document = fixed_document;
        }
        // Элементы меню "Файл" (не работают)
        private async void openMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //// 1 способ (любой формат)
                //string path = File_Dialog();

                //StreamReader sr = new StreamReader(path);
                //var strline = await sr.ReadToEndAsync();
                //Paragraph my_paragraph = new Paragraph();
                //my_paragraph.Inlines.Add(strline);

                //PageContent pageContent = new PageContent();

                //FixedPage fixedPage = new FixedPage();

                //StackPanel stackPanel = new StackPanel();

                //TextBlock textBlock = new TextBlock();
                //textBlock.Text = strline;

                //stackPanel.Children.Add(textBlock);

                //fixedPage.Children.Add(stackPanel);

                //pageContent.Child = fixedPage;

                //fixed_document.Pages.Add(pageContent);

                //document_viewer.Document = fixed_document;

                // 2 способ (только xps-файл)
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "XPS-файл (*.xps)|*.xps";

                if(openFileDialog.ShowDialog() == true)
                {
                    XpsDocument document = new XpsDocument(openFileDialog.FileName, FileAccess.Read);
                    document_viewer.Document = document.GetFixedDocumentSequence();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void saveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "XPS-файл (*.xps)|*.xps";
                if(saveFileDialog.ShowDialog() == true)
                {
                    XpsDocument document = new XpsDocument(saveFileDialog.FileName, FileAccess.Write);
                    XpsDocumentWriter xpsDocumentWriter = XpsDocument.CreateXpsDocumentWriter(document);
                    xpsDocumentWriter.Write(document_viewer.Document as FixedDocument);
                    document.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // Блочные элементы меню
        private void Block_Paragraph_Example_Click(object sender, RoutedEventArgs e)
        {
            document_viewer.Document = Example_Block_Paragraph(sender, e);
        }
        private void Block_List_Example_Click(object sender, RoutedEventArgs e)
        {
            document_viewer.Document = Example_Block_List(sender, e);
        }
        private void Block_Table_Example_Click(object sender, RoutedEventArgs e)
        {
            document_viewer.Document = Example_Block_Table(sender, e);
        }
        private void Block_Section_Example_Click(object sender, RoutedEventArgs e)
        {
            document_viewer.Document = Example_Block_Section(sender, e);
        }
        private void Block_UIContainer_Example_Click(object sender, RoutedEventArgs e)
        {
            document_viewer.Document = Example_Block_UIContainer(sender, e);
        }
        // Строчные элементы меню
        private void Block_Span_Example_Click(object sender, RoutedEventArgs e)
        {
            document_viewer.Document = Example_Block_Span(sender, e);
        }
        private void Block_Hyperlink_Example_Click(object sender, RoutedEventArgs e)
        {
            document_viewer.Document = Example_Block_Hyperlink(sender, e);
        }
        private void Block_Floater_Example_Click(object sender, RoutedEventArgs e)
        {
            document_viewer.Document = Example_Block_Floater(sender, e);
        }
        private void Block_Figure_Example_Click(object sender, RoutedEventArgs e)
        {
            document_viewer.Document = Example_Block_Figure(sender, e);
        }
    }
}