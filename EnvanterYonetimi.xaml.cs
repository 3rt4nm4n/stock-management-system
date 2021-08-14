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
using System.Data;
using Npgsql;

namespace DYSis
{
    /// <summary>
    /// Interaction logic for EnvanterYonetimi.xaml
    /// </summary>
    public partial class EnvanterYonetimi : Window
    {
        public NpgsqlConnection conn;
        string connstring = String.Format(@"Server=localhost;Port=5432;User Id=postgres;Password=password;Database=DepoYonSis");
        private NpgsqlCommand cmd;
        private string sql = null;
        public string tur = "";
        public string malzemeadi = "";
        public long barkod;
        public string birim = "";
        public int adet;
        public string tedarikci = "";
        
        public EnvanterYonetimi()
        {
            InitializeComponent();
            barTxt.Focus();
            conn = new NpgsqlConnection(connstring);
            
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

        private void bulButon_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                    conn.Open();
                    string aranacak_barkod = barTxt.Text;
                    cmd = new NpgsqlCommand(sql, conn);
                    string bulunan_urun_sql = "SELECT * FROM urun WHERE barkod=" + aranacak_barkod;
                    cmd = new NpgsqlCommand(bulunan_urun_sql, conn);
                    NpgsqlDataReader rdr = cmd.ExecuteReader(); 
                if (rdr.Read())
                {
                    turTxt.Text = rdr.GetString(1);
                    birimTxt.Text = rdr.GetString(4); //must get word part of the string
                    adTxt.Text = rdr.GetString(2);
                    tedTxt.Text = rdr.GetString(6);
                    
                }
                
                conn.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Failed!", MessageBoxButton.OK, MessageBoxImage.Error);
                conn.Close();
            }
        }

        private void guncelleBut_Click(object sender, RoutedEventArgs e)
        {
            //UPDATE urun
            //SET column adı = yeni değer
            //WHERE barkod_numarası
            try
            {
                conn.Open();
                sql = "UPDATE urun SET barkod=" + barTxt.Text + ", tur=\'" + turTxt.Text + "\', malzemeadi=\'" + adTxt.Text + "\', birim=\'" + birimTxt.Text + "\', tedarikci=\'" + tedTxt.Text+"\' WHERE barkod="+barTxt.Text;
                cmd = new NpgsqlCommand(sql, conn);
                cmd.ExecuteScalar();
                conn.Close();
            }
            catch (Exception except)
            {
                MessageBox.Show("Error:" + except.Message, "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                conn.Close();
            }

        }

        private void silBut_Click(object sender, RoutedEventArgs e)
        {
            //DELETE FROM urun
            //WHERE barkod_numarası
            try
            {
                conn.Open();
                sql = "DELETE FROM urun WHERE barkod=" + barTxt.Text;
                cmd = new NpgsqlCommand(sql, conn);
                cmd.ExecuteScalar();
                MessageBox.Show(adTxt.Text + " veritabanından silindi.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                conn.Close();
            }
            catch(Exception excep)
            {
                MessageBox.Show("Error" + excep.Message, "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                conn.Close();
            }
        }

        
    }
}
