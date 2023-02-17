using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

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
            OpenFileDialog openFile = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments)
            };
            if (openFile.ShowDialog() == true ) {
                WorkingText.Document.Blocks.Clear();
                WorkingText.AppendText(File.ReadAllText(openFile.FileName));
            }
        }

        private void NewFileButton_Click(object sender, RoutedEventArgs e)
        {
            WorkingText.Document.Blocks.Clear();
        }

        private string StringFromRichTextBox(RichTextBox richTextBox)
        {
            TextRange textRange = new TextRange(
                richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            return textRange.Text;
        }
    }
}
