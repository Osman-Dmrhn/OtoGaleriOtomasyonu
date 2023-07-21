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
    public partial class arackiralama : Form
    {
        aracveritabani aracveritabani = new aracveritabani();
        public arackiralama()
        {
            InitializeComponent();
        }

        private void plakatxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cumle = "select * from arac where plaka like '%" + plakatxt.Text + "%'";

            aracveritabani.plaka_sorgu(cumle,plakatxt,markatxt, modeltxt, yiltxt, renktxt, yakitcombo, kmtxt, fiyattxt, kiratxt, pictureBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cumle = "select *from musteri where tc like '%" + tctxt.Text + "%'";
            aracveritabani.tc_sorgu(cumle, tctxt,isimtxt, soyisimtxt,telefontxt); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                MessageBox.Show("Hesaplama Yapılmadı!");
            }
            else {
                string cumle = "insert into kiralanmis(plaka,marka,model,renk,tc,isim,soyisim,telefon,gun,cikis,donus) values (@plaka,@marka,@model,@renk,@tc,@isim,@soyisim,@telefon,@gun,@cikis,@donus)";
                SqlCommand komut2 = new SqlCommand();
                komut2.Parameters.AddWithValue("@plaka", plakatxt.Text);
                komut2.Parameters.AddWithValue("@marka", markatxt.Text);
                komut2.Parameters.AddWithValue("@model", modeltxt.Text);
                komut2.Parameters.AddWithValue("@renk", renktxt.Text);
                komut2.Parameters.AddWithValue("@tc", tctxt.Text);
                komut2.Parameters.AddWithValue("@isim", isimtxt.Text);
                komut2.Parameters.AddWithValue("@soyisim", soyisimtxt.Text);
                komut2.Parameters.AddWithValue("@telefon", telefontxt.Text);
                komut2.Parameters.AddWithValue("@gun", textBox2.Text);
                komut2.Parameters.AddWithValue("@cikis", dateTimePicker1.Text);
                komut2.Parameters.AddWithValue("@donus", dateTimePicker2.Text);
                aracveritabani.sil_ekle_guncelle(komut2, cumle);
                pictureBox1.Image = null;
                string cumle2 = "insert into kar (alinanucret,tarih) values (@alinanucret,@tarih)";
                SqlCommand komut3 = new SqlCommand();
                komut3.Parameters.AddWithValue("@alinanucret", textBox1.Text);
                komut3.Parameters.AddWithValue("@tarih", DateTime.Now.Date.ToString().TrimEnd('0', ':'));
                aracveritabani.sil_ekle_guncelle(komut3, cumle2);
                foreach (Control items in Controls) if (items is TextBox) items.Text = "";
                foreach (Control items in Controls) if (items is ComboBox) items.Text = "";

                yenilelistele();
            }
        }

        private void yenilelistele()
        {
            string cumle = "select *from kiralanmis";
            SqlDataAdapter adpt2 = new SqlDataAdapter();
            dataGridView1.DataSource = aracveritabani.listele(adpt2, cumle);
        }

        private void arackiralama_Load(object sender, EventArgs e)
        {
            yenilelistele();
            dataGridView1.Columns[0].HeaderText = "TC";
            dataGridView1.Columns[1].HeaderText = "İSİM";
            dataGridView1.Columns[2].HeaderText = "SOYİSİM";
            dataGridView1.Columns[3].HeaderText = "TELEFON";
            dataGridView1.Columns[4].HeaderText = "PLAKA";
            dataGridView1.Columns[5].HeaderText = "MARKA";
            dataGridView1.Columns[6].HeaderText = "MODEL";
            dataGridView1.Columns[7].HeaderText = "RENK";
            dataGridView1.Columns[8].HeaderText = "ÇIKIŞ";
            dataGridView1.Columns[9].HeaderText = "DÖNÜŞ";
            dataGridView1.Columns[10].HeaderText = "K.GÜN";

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            tctxt.Text = satir.Cells[0].Value.ToString();
            isimtxt.Text = satir.Cells[1].Value.ToString();
            soyisimtxt.Text = satir.Cells[2].Value.ToString();
            telefontxt.Text = satir.Cells[3].Value.ToString();
            plakatxt.Text = satir.Cells[4].Value.ToString();
            markatxt.Text = satir.Cells[5].Value.ToString();
            modeltxt.Text = satir.Cells[6].Value.ToString();
            renktxt.Text = satir.Cells[7].Value.ToString();
            kmtxt.Text = satir.Cells[8].Value.ToString();
            kiratxt.Text = satir.Cells[9].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (plakatxt.Text != "")
            {
                DataGridViewRow satir = dataGridView1.CurrentRow;
                string cumle = "delete from kiralanmis where plaka='" + satir.Cells["plaka"].Value.ToString() + "'";
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text!="") {
                int ücret, gün;
                //Hesaplama
                ücret = int.Parse(kiratxt.Text);
                gün = int.Parse(textBox2.Text);
                textBox1.Text = (gün * ücret).ToString();
            }
        }
    }
}
