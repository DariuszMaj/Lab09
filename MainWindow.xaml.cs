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
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lab09a
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
      

        public MainWindow()
        {
            InitializeComponent();
        }
       

        private void TextButton_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "text";
            PageReposne reponse = FetchSnippets(pageNumber, pageSize, snippetsType) ;
            MyDataGrid.ItemsSource = reponse.Batches;
        }

        private void BashButton_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "bash";

            PageReposne reponse = FetchSnippets(pageNumber, pageSize, snippetsType);
            MyDataGrid.ItemsSource = reponse.Batches;

        }

        private void CplusButton_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "cpp";

            PageReposne reponse = FetchSnippets(pageNumber, pageSize, snippetsType);
            MyDataGrid.ItemsSource = reponse.Batches;
        }

        private void CsharpButton_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "cs";

            PageReposne reponse = FetchSnippets(pageNumber, pageSize, snippetsType);
            MyDataGrid.ItemsSource = reponse.Batches;
        }

        private void JavaButton_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "java";

            PageReposne reponse = FetchSnippets(pageNumber, pageSize, snippetsType);
            MyDataGrid.ItemsSource = reponse.Batches;
        }

        private void CSSButton_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "css";

            PageReposne reponse = FetchSnippets(pageNumber, pageSize, snippetsType);
            MyDataGrid.ItemsSource = reponse.Batches;
        }

        private void HTMLButton_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "html";

            PageReposne reponse = FetchSnippets(pageNumber, pageSize, snippetsType);
            MyDataGrid.ItemsSource = reponse.Batches;
        }

        private void JavaScriptButton_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "javascript";

            PageReposne reponse = FetchSnippets(pageNumber, pageSize, snippetsType);
            MyDataGrid.ItemsSource = reponse.Batches;
        }

        private void PHPButton_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "php";

            PageReposne reponse = FetchSnippets(pageNumber, pageSize, snippetsType);
            MyDataGrid.ItemsSource = reponse.Batches;
        }

        private void PythonButton_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "python";

            PageReposne reponse = FetchSnippets(pageNumber, pageSize, snippetsType);
            MyDataGrid.ItemsSource = reponse.Batches;
        }

        private void SQLButton_Click(object sender, RoutedEventArgs e)
        {
            snippetsType = "sql";

            PageReposne reponse = FetchSnippets(pageNumber, pageSize, snippetsType);
            MyDataGrid.ItemsSource = reponse.Batches;
        }

        private void one_Click(object sender, RoutedEventArgs e)
        {
            pageNumber = 1;
            PageReposne reponse = FetchSnippets(pageNumber, pageSize, snippetsType);
            MyDataGrid.ItemsSource = reponse.Batches;
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            pageNumber = 2; PageReposne reponse = FetchSnippets(pageNumber, pageSize, snippetsType);
            MyDataGrid.ItemsSource = reponse.Batches;
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            pageNumber = 3; PageReposne reponse = FetchSnippets(pageNumber,pageSize, snippetsType);
            MyDataGrid.ItemsSource = reponse.Batches;
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            pageNumber = 4; PageReposne reponse = FetchSnippets(pageNumber, pageSize, snippetsType);
            MyDataGrid.ItemsSource = reponse.Batches;
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            pageNumber = 5; PageReposne reponse = FetchSnippets(pageNumber,pageSize, snippetsType);
            MyDataGrid.ItemsSource = reponse.Batches;
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            pageNumber= 6; PageReposne reponse = FetchSnippets(pageNumber,pageSize, snippetsType);
            MyDataGrid.ItemsSource = reponse.Batches;
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            pageNumber = 7; PageReposne reponse = FetchSnippets(pageNumber, pageSize, snippetsType);
            MyDataGrid.ItemsSource = reponse.Batches;
        }




            int pageNumber=1;
            int pageSize = 5;
            string snippetsType = "cs";
            

            

           
        

        public static string FetchData(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                ContentType type = new ContentType(response.ContentType ?? "text/plain;charset=" + Encoding.UTF8.WebName);
                Encoding encoding = Encoding.GetEncoding(type.CharSet ?? Encoding.UTF8.WebName);

                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static PageReposne FetchSnippets(int pageNumber, int pageSize, string snippetsType)
        {
            string url = $"https://dirask.com/api/snippets?pageNumber={pageNumber}&pageSize={pageSize}&dataOrder=newest&dataGroup=batches&snippetsType={Uri.EscapeUriString(snippetsType)}";
            string data = FetchData(url);

            return JsonSerializer.Deserialize<PageReposne>(data);
        }

        private void ItemPerSite_GotFocus(object sender, RoutedEventArgs e)
        {
            pageSize = int.Parse(ItemPerSite.Text);
            PageReposne reponse = FetchSnippets(pageNumber, Convert.ToInt32(ItemPerSite.Text), snippetsType);
            MyDataGrid.ItemsSource = reponse.Batches;

        }
    }

    public class PageReposne
    {
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }

        [JsonPropertyName("pagesCount")]
        public int PagesCount { get; set; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("batches")]
        public List<SnippetReponse> Batches { get; set; }
    }

    public class SnippetReponse
    {
        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("creationTime")]
        public DateTime? CreationTime { get; set; }

        [JsonPropertyName("updateTime")]
        public DateTime? UpdateTime { get; set; }
    }




}

