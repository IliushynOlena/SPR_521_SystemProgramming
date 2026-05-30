using System.IO;
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

namespace _06_AsyncAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //int value = GenerateValue();
            //Task<int> task = Task.Run(GenerateValue);
            //task.Wait();//freeze
            //list.Items.Add(task.Result);//freeze


            //async - allow method to use await keyword
            //await - wait task without freeze
            //Task<int> task = GenerateValueAsync();
            //int value = await GenerateValueAsync();
   
            list.Items.Add(await GenerateValueAsync());

            //MessageBox.Show("Complited");

            //FileStream fs = new FileStream();
            string root = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            MessageBox.Show(root);
            

        }
        Task<int> GenerateValueAsync()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(random.Next(5000));
                //MessageBox.Show("Generate");
                return random.Next(1000);
            });
        }
        int GenerateValue()
        {
            Thread.Sleep(random.Next(5000));
            //MessageBox.Show("Generate");
            return random.Next(1000);
        }
    }
}