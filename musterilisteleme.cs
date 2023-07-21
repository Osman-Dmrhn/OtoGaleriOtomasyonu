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
    public partial class musterilisteleme : Form
    {
        aracveritabani aracveritabani = new aracveritabani();
        public musterilisteleme()
        {
            InitializeComponent();
        }

        private void musterilisteleme_Load(object sender, EventArgs e)
        {
            yenilelistele();

            dataGridView1.Columns[0].HeaderText = "TC";
            dataGridView1.Columns[1].HeaderText = "İSİM";
            dataGridView1.Columns[2].HeaderText = "SOYİSİM";
            dataGridView1.Columns[3].HeaderText = "TELEFON";
        }

        private void yenilelistele()
        {
            string cumle = "select *from musteri";
            SqlDataAdapter adpt2 = new SqlDataAdapter();
            dataGridView1.DataSource = aracveritabani.listele(adpt2, cumle);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string cumle = "select *from musteri where tc like '%" + tcstext.Text + "%'";
            SqlDataAdapter adpt2 = new SqlDataAdapter();
            dataGridView1.DataSource = aracveritabani.listele(adpt2, cumle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isimtxt.Text == "" || soyisimtxt.Text == "" || tctxt.Text == "" || telefontxt.Text == "")
            {
                MessageBox.Show("Tüm Alanlar Doldurulmalıdır!");
            }
            else
            {
                string cumle = "update musteri set isim=@isim,soyisim=@soyisim,telefon=@telefon where tc=@tc";
                SqlCommand komut2 = new SqlCommand();
                komut2.Parameters.AddWithValue("@tc", tctxt.Text);
                komut2.Parameters.AddWithValue("@isim", isimtxt.Text);
                komut2.Parameters.AddWithValue("@soyisim", soyisimtxt.Text);
                komut2.Parameters.AddWithValue("@telefon", telefontxt.Text);
                aracveritabani.sil_ekle_guncelle(komut2, cumle);
                foreach (Control item in Controls) if (item is TextBox) item.Text = "";
                yenilelistele();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            tctxt.Text = satir.Cells[0].Value.ToString();
            isimtxt.Text = satir.Cells[1].Value.ToString();
            soyisimtxt.Text = satir.Cells[2].Value.ToString();
            telefontxt.Text = satir.Cells[3].Value.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (tctxt.Text != "")
            {
                DataGridViewRow satir = dataGridView1.CurrentRow;
                string cumle = "delete from musteri where tc='" + satir.Cells["tc"].Value.ToString() + "'";
                SqlCommand komut2 = new SqlCommand();
                foreach (Control item in Controls) if (item is TextBox) item.Text = "";
                aracveritabani.sil_ekle_guncelle(komut2, cumle);
                yenilelistele();
            }
            else
            {
                MessageBox.Show("Kişi Seçili Değil");
            }
        }
    }
}
