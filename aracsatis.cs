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
    public partial class aracsatis : Form
    {
        aracveritabani aracveritabani = new aracveritabani();
        public aracsatis()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void satisbtn_Click(object sender, EventArgs e)
        {
            if (plakatxt.Text != "")
            {
                if (satisfiyat.Text!="") {
                    DataGridViewRow satir = dataGridView1.CurrentRow;
                    string cumle = "delete from arac where plaka='" + satir.Cells["plaka"].Value.ToString() + "'";
                    SqlCommand komut2 = new SqlCommand();

                    pictureBox1.Image = null;
                    aracveritabani.sil_ekle_guncelle(komut2, cumle);
                    yenilelistele();
                    string cumle2 = "insert into kar (alinanucret,tarih) values (@alinanucret,@tarih)";
                    SqlCommand komut3 = new SqlCommand();
                    komut3.Parameters.AddWithValue("@alinanucret", satisfiyat.Text);
                    komut3.Parameters.AddWithValue("@tarih", DateTime.Now.Date.ToString().TrimEnd('0', ':'));
                    aracveritabani.sil_ekle_guncelle(komut3, cumle2);
                    foreach (Control item in Controls) if (item is TextBox) item.Text = "";
                    foreach (Control items in Controls) if (items is ComboBox) items.Text = "";
                }
                else
                {
                    MessageBox.Show("Satış Fiyatı Girilmedi!");
                }
            }
            else
            {
                MessageBox.Show("Araç Seçili Değil");
            }
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
        private void yenilelistele()
        {
            string cumle = "select * from arac";
            SqlDataAdapter adpt2 = new SqlDataAdapter();
            dataGridView1.DataSource = aracveritabani.listele(adpt2, cumle);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string cumle = "select *from arac where plaka like '%" + satisfiyat.Text + "%'";
            SqlDataAdapter adpt2 = new SqlDataAdapter();
            dataGridView1.DataSource = aracveritabani.listele(adpt2, cumle);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(satisfiyat.Text!="" && fiyattxt.Text!="")
                kartxt.Text = (int.Parse(satisfiyat.Text) - int.Parse(fiyattxt.Text)).ToString();
            
        }

        private void aracsatis_Load(object sender, EventArgs e)
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
    }
}
