using LandmarkAI.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace LandmarkAI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string url = "https://eastus.api.cognitive.microsoft.com/customvision/v3.0/Prediction/351ddfa9-b058-481d-a17e-35743ab5fcf5/classify/iterations/Iteration1/image";
        private const string predictionKey = "3d8a22399208417d85c4e8eee6faef00";
        private const string contentType = "application/octet-stream";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "image files (*.png; *.jpg *.jfif)|*.png;*.jpg;*.jpeg;*.jfif|All files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };

            if ((bool)dialog.ShowDialog())
            {
                string file = dialog.FileName;
                selectedImg.Source = new BitmapImage(new Uri(file));

                MakePredictionAsync(file);
            }
        }

        private async void MakePredictionAsync(string fileName)
        {
            Task<Byte[]> file;
            if (!File.Exists(fileName))
            {
                MessageBox.Show("The file does not exist.", "Null or wrong value", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            file = File.ReadAllBytesAsync(fileName);

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Prediction-Key", predictionKey);

                using var content = new ByteArrayContent(await file);
                content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                var response = await client.PostAsync(url, content);
                var responseString = await response.Content.ReadAsStringAsync();

                PredicionsListView.ItemsSource = (List<Prediction>)JsonConvert.DeserializeObject<CustomVision>(responseString).Predictions;
            };

        }
    }
}
