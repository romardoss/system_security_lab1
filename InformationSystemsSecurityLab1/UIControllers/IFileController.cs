using System.Windows.Controls;

namespace InformationSystemsSecurityLab1.UIControllers
{
    internal interface IFileController
    {
        void OpenFile(RichTextBox file);
        void SaveFile(RichTextBox file, string text);
        void NewFile(RichTextBox file);
        void PrintFile(RichTextBox file, string text);
    }
}
