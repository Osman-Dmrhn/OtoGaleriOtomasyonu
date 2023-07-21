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
    public partial class aracekleme : Form
    {
        aracveritabani aracekle = new aracveritabani();
        public aracekleme()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (plakatxt.Text == "" || markatxt.Text == "" || modeltxt.Text == "" || yiltxt.Text == "" || renktxt.Text == "" || yakitcombo.Text == "" || kmtxt.Text == "" || fiyattxt.Text == "" || kiratxt.Text == "")
            {
                MessageBox.Show("Tüm Alanlar Doldurulmalıdır!");
            }
            else if (pictureBox1.Image==null)
            {
                MessageBox.Show("Fotoğraf Seçilmedi!");
            }
            else
            {
                string cumle = "insert into arac(plaka,marka,model,yıl,renk,yakıt,km,fiyat,kiralamafiyat,resim) values (@plaka,@marka,@model,@yıl,@renk,@yakıt,@km,@fiyat,@kiralamafiyat,@resim) ";
                SqlCommand komut2 = new SqlCommand();
                komut2.Parameters.AddWithValue("@plaka", plakatxt.Text);
                komut2.Parameters.AddWithValue("@marka", markatxt.Text);
                komut2.Parameters.AddWithValue("@model", modeltxt.Text);
                komut2.Parameters.AddWithValue("@yıl", yiltxt.Text);
                komut2.Parameters.AddWithValue("@renk", renktxt.Text);
                komut2.Parameters.AddWithValue("@yakıt", yakitcombo.Text);
                komut2.Parameters.AddWithValue("@km", kmtxt.Text);
                komut2.Parameters.AddWithValue("@fiyat", fiyattxt.Text);
                komut2.Parameters.AddWithValue("@kiralamafiyat", kiratxt.Text);
                komut2.Parameters.AddWithValue("@resim", pictureBox1.ImageLocation);
                aracekle.sil_ekle_guncelle(komut2, cumle);
                foreach (Control items in Controls) if (items is TextBox) items.Text = "";
                foreach (Control items in Controls) if (items is ComboBox) items.Text = "";
                pictureBox1.Image = null;
                MessageBox.Show("Araç Eklendi.");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void aracekleme_Load(object sender, EventArgs e)
        {

        }
    }
}
