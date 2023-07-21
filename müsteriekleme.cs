using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtoGaleriOtomasyonu
{
    public partial class müsteriekleme : Form
    {
        aracveritabani aracveritabani = new aracveritabani();
        public müsteriekleme()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isimtxt.Text==""||soyisimtxt.Text==""||tctxt.Text==""||telefontxt.Text=="")
            {
                MessageBox.Show("Tüm Alanlar Doldurulmalıdır!");
            }
            else {
                string cümle = "insert into musteri (tc,isim,soyisim,telefon) values (@tc,@isim,@soyisim,@telefon)";
                SqlCommand komut2 = new SqlCommand();
                komut2.Parameters.AddWithValue("@tc", tctxt.Text);
                komut2.Parameters.AddWithValue("@isim", isimtxt.Text);
                komut2.Parameters.AddWithValue("@soyisim", soyisimtxt.Text);
                komut2.Parameters.AddWithValue("@telefon", telefontxt.Text);
                aracveritabani.sil_ekle_guncelle(komut2, cümle);
                foreach (Control item in Controls) if (item is TextBox) item.Text = "";
                MessageBox.Show("Müşteri Eklendi");
            }
        }

        private void telefontxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void soyisimtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void isimtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tctxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
