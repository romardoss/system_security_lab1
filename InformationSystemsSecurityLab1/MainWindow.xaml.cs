﻿using InformationSystemsSecurityLab1.EncryptionCode;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Spire.Doc;

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
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments),
                Filter = "Text files (*.txt; *.doc; *.docx)|*.txt;*.doc;*.docx|All files (*.*)|*.*",
            };
            if (openFile.ShowDialog() == true ) {
                WorkingText.Document.Blocks.Clear();
                if(Path.GetExtension(openFile.FileName) == ".doc" ||
                    Path.GetExtension(openFile.FileName) == ".docx")
                {
                    Document doc = new Document();
                    doc.LoadFromFile(openFile.FileName);
                    WorkingText.AppendText(doc.GetText());
                }
                else if (Path.GetExtension(openFile.FileName) == ".txt")
                {
                    WorkingText.AppendText(File.ReadAllText(openFile.FileName));
                }
                else
                {
                    MessageBox.Show("Unknown file extension. It is only .txt, " +
                        ".doc, .docx provided");
                }
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

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int key = GetKey(KeyText.Text);
                string input = StringFromRichTextBox(WorkingText);
                string answer = CeasarAlgorithm.Encrypt(input, key);
                PrintAnswer(answer);
            }
            catch (Exception) { }
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int key = GetKey(KeyText.Text);
                string input = StringFromRichTextBox(WorkingText);
                string answer = CeasarAlgorithm.Decrypt(input, key);
                PrintAnswer(answer);
            }
            catch (Exception) { }
        }

        private void PrintAnswer(string answer)
        {
            WorkingText.Document.Blocks.Clear();
            WorkingText.AppendText(answer);
        }

        private int GetKey(string key)
        {
            if (int.TryParse(key, out int answer))
            {
                return answer;
            }
            else
            {
                MessageBox.Show("Key must be a number");
                throw new Exception();
            }
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            About aboutWindow = new About();
            aboutWindow.ShowDialog();
        }

        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
