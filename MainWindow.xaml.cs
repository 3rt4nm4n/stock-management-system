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
using System.Data;
using Npgsql;


namespace DYSis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public NpgsqlConnection conn;
        string connstring = String.Format(@"Server=localhost;Port=5432;User Id=postgres;Password=password;Database=DepoYonSis");
        private NpgsqlCommand cmd;
        private string sql = null;
        private DataTable dt;
        public string query_not = "SELECT CASE WHEN EXISTS (SELECT malzemeadi FROM urun WHERE adet=0 OR adet<10) THEN CAST (1 AS BIT) ELSE CAST (0 AS BIT) END";
        
        bool checkNot(NpgsqlCommand a, string q, NpgsqlConnection c)
        {
            conn.Open();
            a = new NpgsqlCommand(q, c);
            if (Convert.ToBoolean(a.ExecuteScalar()) == true)
            {
                return true;
            }
            else
                return false;
            
        }
        public MainWindow()
        {
            
        InitializeComponent();
            conn = new NpgsqlConnection(connstring);
            try
            {
                conn.Open();
                sql = "SELECT * FROM urun ORDER BY stokkodu ASC";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dg.DataContext = dt.DefaultView;
       
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, " Failed!", MessageBoxButton.OK, MessageBoxImage.Error);
                conn.Close();
            }
            cmd = new NpgsqlCommand(sql, conn);
            if (checkNot(cmd, query_not, conn))
            {
                notbut.Content = "Bildiriminiz Var";
            }
        }
        
    
        private void AButton_Click(object sender, RoutedEventArgs e)
        {
            dg.Items.Refresh();
        }

        private void DYButton_Click(object sender, RoutedEventArgs e)
        {
            conn.Close();
            DepoYonetimi dy = new DepoYonetimi();
            dy.Show();
            this.Close();
            conn.Close();
        }
        private void EYButton_Click(object sender, RoutedEventArgs e)
        {
            conn.Close();
            EnvanterYonetimi ey = new EnvanterYonetimi();
            ey.Show();
            this.Close();
        }

        private void notbut_Click(object sender, RoutedEventArgs e)
        {
            BildirimEkrani be = new BildirimEkrani();
            be.Show();
            conn.Close();
        }
    }
}
