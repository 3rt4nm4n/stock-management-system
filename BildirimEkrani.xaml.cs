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
using System.IO;

namespace DYSis
{
    /// <summary>
    /// Interaction logic for BildirimEkrani.xaml
    /// </summary>
    public partial class BildirimEkrani : Window
    {
        public NpgsqlConnection conn;
        string connstring = String.Format(@"Server=localhost;Port=5432;User Id=postgres;Password=password;Database=DepoYonSis");
        private NpgsqlCommand cmd;
        public string query_not = "SELECT CASE WHEN EXISTS (SELECT malzemeadi FROM urun WHERE adet=0 OR adet<10) THEN CAST (1 AS BIT) ELSE CAST (0 AS BIT) END";
        
        public BildirimEkrani()
        {


            StreamWriter writer = new StreamWriter("azdir.txt");
            StreamWriter writer2 = new StreamWriter("bitdir.txt");
            

            InitializeComponent();
            conn = new NpgsqlConnection(connstring);
            conn.Open();
            string azalan = "SELECT malzemeadi FROM urun WHERE adet<10 and adet>0";
            string biten = "SELECT malzemeadi FROM urun WHERE adet=0";
            cmd = new NpgsqlCommand(azalan, conn);
            using (NpgsqlDataReader rdr = cmd.ExecuteReader())
            { 
                while (rdr.Read())
                {
                    for (int i = 0; i < rdr.FieldCount; i++)
                        writer.WriteLine("-" + rdr.GetString(i).ToString() + "\n");    
                }
                writer.Close();
                StreamReader reader = new StreamReader("azdir.txt");
                bildirimTxt.Text = reader.ReadToEnd();
            }
            cmd = new NpgsqlCommand(biten, conn);
            using (NpgsqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {  
                    for (int i = 0; i < rdr.FieldCount; i++)
                        writer2.WriteLine("-" + rdr.GetString(i).ToString() + "\n");
                }
                writer2.Close();
                StreamReader reader2 = new StreamReader("bitdir.txt");
                bildirimTxt_Copy.Text= reader2.ReadToEnd(); ;
            }
            
            conn.Close();
        }
    }
}
