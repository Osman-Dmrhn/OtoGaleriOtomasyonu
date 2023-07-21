using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtoGaleriOtomasyonu
{
    internal class aracveritabani
    {
        SqlConnection baglanti = new SqlConnection("Data Source=OSMAN\\MSSQLSERVER02;Initial Catalog=arac_kiralama;Integrated Security=True");
        DataTable tablo;
        
        public void sil_ekle_guncelle(SqlCommand komut,string sorgu)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = sorgu;
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        public DataTable listele(SqlDataAdapter adpt,string sorgu)
        {
            tablo = new DataTable();
            adpt = new SqlDataAdapter(sorgu, baglanti);
            adpt.Fill(tablo);
            baglanti.Close();
            return tablo;
        }

        public void plaka_sorgu(string sorgu,TextBox plaka,TextBox Marka,TextBox Model,TextBox Yıl,TextBox Renk,ComboBox yakıt,TextBox km,TextBox fiyat,TextBox kiralama,PictureBox resim)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu,baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                plaka.Text = read["plaka"].ToString();
                Marka.Text = read["marka"].ToString();
                Model.Text = read["model"].ToString();
                Yıl.Text = read["yıl"].ToString();
                Renk.Text = read["renk"].ToString();
                yakıt.Text = read["yakıt"].ToString();
                km.Text = read["km"].ToString();
                fiyat.Text = read["fiyat"].ToString();
                kiralama.Text = read["kiralamafiyat"].ToString();
                resim.ImageLocation = read["resim"].ToString();

            }
            baglanti.Close();
            
        }
        public void tc_sorgu(string sorgu,TextBox tc,TextBox ad,TextBox soyad,TextBox telefon)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                tc.Text = read["tc"].ToString();
                ad.Text = read["isim"].ToString();
                soyad.Text = read["soyisim"].ToString();
                telefon.Text = read["telefon"].ToString();
            }
            baglanti.Close();
        }
    }
}
