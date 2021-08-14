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
using System.Text.RegularExpressions;
using Npgsql;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DYSis
{
    /// <summary>
    /// Interaction logic for DepoCikis.xaml
    /// </summary>
    public partial class DepoCikis : Window
    {
        public NpgsqlConnection conn;
        public string connstring = String.Format(@"Server=localhost;Port=5432;User Id=postgres;Password=password;Database=DepoYonSis");
        private NpgsqlCommand cmd;
        private string sql = null;
        public string tur = "";
        public string malzemeadi = "";
        public long barkod;
        public string birim = "";
        public int adet;
        public string tedarikci = "";
        const string apos = "\'";
        public DepoCikis()
        {

            InitializeComponent();
            conn = new NpgsqlConnection(connstring);
            bartb.Focus();
            conn.Open();
            sql = "SELECT DISTINCT tur FROM urun";
            cmd = new NpgsqlCommand(sql, conn);
            using (NpgsqlDataReader readerr = cmd.ExecuteReader())
            {
                while (readerr.Read())
                {
                    string name = readerr.GetString(0);
                    turcb.Items.Add(name);
                }
            }
            sql = "SELECT DISTINCT birim FROM urun";
            cmd = new NpgsqlCommand(sql, conn);
            using (NpgsqlDataReader readerrr = cmd.ExecuteReader())
            {
                while (readerrr.Read())
                {
                    string namee = readerrr.GetString(0);
                    bircb.Items.Add(namee);
                }
            }
            conn.Close();
        }

        private void IBut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bartb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");//only numbers can be typed in this textbox
            e.Handled = regex.IsMatch(e.Text);
        }

        private void atb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");//only numbers can be typed in this textbox
            e.Handled = regex.IsMatch(e.Text);
        }

        private void aramabutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                string aranacak_barkod = bartb.Text;
                /*select case when exists(
                select * from urun where barkod= 8690461012340
                )
                then cast(1 as bit)
                else cast(0 as bit) end*/

                sql = "SELECT CASE WHEN EXISTS (SELECT * FROM urun WHERE barkod=" + aranacak_barkod + ") THEN CAST (1 AS BIT) ELSE CAST (0 AS BIT) END";
                cmd = new NpgsqlCommand(sql, conn);

                //cmd.CommandText = sql;
                if (Convert.ToBoolean(cmd.ExecuteScalar()) == true)
                {
                    MessageBox.Show("Ürün bulundu!");
                    string bulunan_urun_sql = "SELECT * FROM urun WHERE barkod=" + aranacak_barkod + ";";
                    cmd = new NpgsqlCommand(bulunan_urun_sql, conn);
                    NpgsqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {

 
                        turcb.Text = rdr.GetString(1);
                        bircb.Text = rdr.GetString(4); //must get string part of the string
                        matb.Text = rdr.GetString(2);
                        ttb.Text = rdr.GetString(6);

                    }

                }
                else if (Convert.ToBoolean(cmd.ExecuteScalar()) == false)
                {
                    MessageBox.Show("Ürün bulunamadı");

                }

                conn.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message, "Failed!", MessageBoxButton.OK, MessageBoxImage.Error);
                conn.Close();
            }
        }

        private void AzBut_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ADBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                long longvalue;
                int intvalue;
                tur = turcb.Text;
                malzemeadi = Convert.ToString(matb.Text);
                if (long.TryParse(bartb.Text, out longvalue))
                    barkod = Convert.ToInt64(long.Parse(bartb.Text));
                birim = bircb.Text;
                if (int.TryParse(atb.Text, out intvalue))
                    adet = Convert.ToInt32(int.Parse(atb.Text));
                tedarikci = Convert.ToString(ttb.Text);
                string aranacak_barkod = bartb.Text;
                string sql_zero = "SELECT CASE WHEN EXISTS(SELECT * FROM urun WHERE "+adet+"<>0) THEN CAST (1 AS BIT) ELSE CAST(0 AS BIT) END";
                sql = "SELECT CASE WHEN EXISTS (SELECT * FROM urun WHERE barkod=" + aranacak_barkod + ") THEN CAST (1 AS BIT) ELSE CAST (0 AS BIT) END";
                conn.Open();
                NpgsqlCommand cmd_checkzero = new NpgsqlCommand(sql_zero, conn);
                cmd = new NpgsqlCommand(sql, conn);
                if (Convert.ToBoolean(cmd.ExecuteScalar()) == false)
                {
                    MessageBox.Show("Ürün depoda yok.", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                }
         
                else if (Convert.ToBoolean(cmd.ExecuteScalar()) == true)
                {
                    if (Convert.ToBoolean(cmd_checkzero.ExecuteScalar()) == true) { 
                    int a = Convert.ToInt32(adet);
                    sql = "UPDATE urun SET adet = adet - " + a + " WHERE barkod=" + aranacak_barkod + " AND adet>0;";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.ExecuteScalar();
                    conn.Close();
                        
                    MessageBox.Show("Ürün adedi " + adet + " azaltıldı.", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
                    turcb.Text = "";
                    matb.Text = "";
                    bartb.Text = "";
                    bircb.Text = "";
                    atb.Text = "";
                    ttb.Text = "";
                    
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, " Failed!", MessageBoxButton.OK, MessageBoxImage.Error);
                conn.Close();
            }
        }

        private void bartb_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                aramabutton_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
