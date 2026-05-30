using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;


namespace _08_CopyFileManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Source { get; set; }
        public string Destination { get; set; }
     

        public MainWindow()
        {
            InitializeComponent();
          
           
            Source = srcTb.Text = @"C:\Users\helen\Downloads\Java_Script-main.zip";
            Destination = destTb.Text = @"C:\Users\helen\Desktop\Test";
        }

        private void SourceButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                srcTb.Text = Source = dialog.FileName;
            }

        }

        private void DestButton_Click_1(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog();
            fileDialog.IsFolderPicker = true;   
            if(fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                destTb.Text = Destination = fileDialog.FileName;    
            }
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            //source---> dest
            //copy file
            string filename = Path.GetFileName(Source);
           
            string destPath = Path.Combine(Destination, filename);
            //Files.Add(new FileCopy() { FileName = filename, Length = Source.Length });
            //MessageBox.Show
            string message = $"{filename} . Length : {Source.Length}";
            listFiles.Items.Add(message);
            //listFiles.ItemsSource = Files;
            //MessageBox.Show(Source);
            //MessageBox.Show(filename);
            // MessageBox.Show(destPath);
           CopyFileAsync(Source, destPath);
            

        }
        private Task CopyFileAsync(string src, string dest)
        {
            return Task.Run(() =>
            File.Copy(src, dest, true)
            );
        }
    }

    class FileCopy
    {
        public string FileName { get; set; }
        public int Length { get; set; }
        public override string ToString()
        {
            return $"{FileName} - {Length}";
        }
    }
}