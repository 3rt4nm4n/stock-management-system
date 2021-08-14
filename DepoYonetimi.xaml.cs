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
using System.Windows.Shapes;
using Npgsql;
using System.Data;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

namespace DYSis
{
    /// <summary>
    /// Interaction logic for DepoYonetimi.xaml
    /// </summary>
    public partial class DepoYonetimi : Window
    {

        public NpgsqlConnection conn;
        string connstring = String.Format(@"Server=localhost;Port=5432;User Id=postgres;Password=password;Database=DepoYonSis");
        private NpgsqlCommand cmd;
        private string sql = null;
        private DataTable dt;
        public SeriesCollection SeriesCollection { get; set; }
        public DepoYonetimi()
        {
            InitializeComponent();
            List<int> allvalues = new List<int>();
            List<string> strvalues = new List<string>();
            conn = new NpgsqlConnection(connstring);
            
            try
            {
                conn.Open();
                
                sql = "SELECT * FROM urun ORDER BY stokkodu ASC";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dg.DataContext = dt.DefaultView;
                while (cmd.ExecuteReader().Read())
                {
                   
                    allvalues.Add(Convert.ToInt32(cmd.ExecuteReader()));
                    
                }
                SeriesCollection = new SeriesCollection
                {
                    new ColumnSeries
                    {
                        Values = new ChartValues<int>(allvalues)
                    }
                };
                DataContext = this;
                
                conn.Close();
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("Error: " + ex.Message, " Failed!", MessageBoxButton.OK, MessageBoxImage.Error);
                //conn.Close();
            }
        }

        private void AButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void DYButton_Click(object sender, RoutedEventArgs e)
        {
            DepoYonetimi dy = new DepoYonetimi();
            dy.Show();
            this.Close();
        }
        private void EYButton_Click(object sender, RoutedEventArgs e)
        {
            EnvanterYonetimi ey = new EnvanterYonetimi();
            ey.Show();
            this.Close();
        }

        private void DepoGirdiButton_Click(object sender, RoutedEventArgs e)
        {
            DepoGiris dg = new DepoGiris();
            dg.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DepoCikis dc = new DepoCikis();
            dc.Show();
        }
    }
}
