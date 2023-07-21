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
using static System.Net.Mime.MediaTypeNames;

namespace OtoGaleriOtomasyonu
{
    public partial class araclisteleme : Form
    {
        aracveritabani aracveritabani = new aracveritabani();
        public araclisteleme()
        {
            InitializeComponent();
        }

        private void yenilelistele()
        {
            string cumle = "select *from arac";
            SqlDataAdapter adpt2 = new SqlDataAdapter();
            dataGridView1.DataSource = aracveritabani.listele(adpt2, cumle);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string cumle = "select *from arac where plaka like '%" + textBox1.Text + "%'";
            SqlDataAdapter adpt2 = new SqlDataAdapter();
            dataGridView1.DataSource = aracveritabani.listele(adpt2, cumle);
        }

        private void araclisteleme_Load(object sender, EventArgs e)
        {
            yenilelistele();

            dataGridView1.Columns[0].HeaderText = "PLAKA";
            dataGridView1.Columns[1].HeaderText = "MARKA";
            dataGridView1.Columns[2].HeaderText = "MODEL";
            dataGridView1.Columns[3].HeaderText = "YIL";
            dataGridView1.Columns[4].HeaderText = "RENK";
            dataGridView1.Columns[5].HeaderText = "YAKIT";
            dataGridView1.Columns[6].HeaderText = "KM";
            dataGridView1.Columns[7].HeaderText = "FİYAT";
            dataGridView1.Columns[8].HeaderText = "KİRALAMA ÜCR.";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            plakatxt.Text = satir.Cells[0].Value.ToString();
            markatxt.Text = satir.Cells[1].Value.ToString();
            modeltxt.Text = satir.Cells[2].Value.ToString();
            yiltxt.Text = satir.Cells[3].Value.ToString();
            renktxt.Text = satir.Cells[4].Value.ToString();
            yakitcombo.Text = satir.Cells[5].Value.ToString();
            kmtxt.Text = satir.Cells[6].Value.ToString();
            fiyattxt.Text = satir.Cells[7].Value.ToString();
            kiratxt.Text = satir.Cells[8].Value.ToString();

            pictureBox1.ImageLocation = satir.Cells[9].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (plakatxt.Text != "")
            {
                DataGridViewRow satir = dataGridView1.CurrentRow;
                string cumle = "delete from arac where plaka='" + satir.Cells["plaka"].Value.ToString() + "'";
                SqlCommand komut2 = new SqlCommand();
                foreach (Control item in Controls) if (item is TextBox) item.Text = "";
                foreach (Control items in Controls) if (items is ComboBox) items.Text = "";
                pictureBox1.Image = null;
                aracveritabani.sil_ekle_guncelle(komut2, cumle);
                yenilelistele();
            }
            else
            {
                MessageBox.Show("Araç Seçili Değil");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (plakatxt.Text == "" || markatxt.Text == "" || modeltxt.Text == "" || yiltxt.Text == "" || renktxt.Text == "" || yakitcombo.Text == "" || kmtxt.Text == "" || fiyattxt.Text == "" || kiratxt.Text == "")
            {
                MessageBox.Show("Tüm Alanlar Doldurulmalıdır!");
            }
            else if (pictureBox1.Image == null)
            {
                MessageBox.Show("Fotoğraf Seçilmedi!");
            }
            else
            {
                string cumle = "update arac set marka=@marka,model=@model,yıl=@yıl,renk=@renk,yakıt=@yakıt,km=@km,fiyat=@fiyat,kiralamafiyat=@kiralamafiyat,resim=@resim where plaka=@plaka";
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
                aracveritabani.sil_ekle_guncelle(komut2, cumle);
                foreach (Control item in Controls) if (item is TextBox) item.Text = "";
                foreach (Control items in Controls) if (items is ComboBox) items.Text = "";
                pictureBox1.Image = null;
                yenilelistele();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
