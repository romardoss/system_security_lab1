using InformationSystemsSecurityLab1.EncryptionCode;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using InformationSystemsSecurityLab1.UIControllers;

namespace InformationSystemsSecurityLab1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            var file = new FileController();
            file.OpenFile(WorkingText);
        }

        private void NewFileButton_Click(object sender, RoutedEventArgs e)
        {
            var file = new FileController();
            file.NewFile(WorkingText);
        }

        private string StringFromRichTextBox(RichTextBox richTextBox)
        {
            TextRange textRange = new TextRange(
                richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            return textRange.Text;
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            string input = StringFromRichTextBox(WorkingText);
            string answer = CeasarAlgorithm.Encrypt(input, KeyText.Text);
            var fileController = new FileController();
            fileController.PrintFile(WorkingText, answer);
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            string input = StringFromRichTextBox(WorkingText);
            string answer = CeasarAlgorithm.Decrypt(input, KeyText.Text);
            var fileController = new FileController();
            fileController.PrintFile(WorkingText, answer);
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            About aboutWindow = new About();
            aboutWindow.ShowDialog();
        }

        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            var file = new FileController();
            file.SaveFile(WorkingText, StringFromRichTextBox(WorkingText));
        }
    }
}
