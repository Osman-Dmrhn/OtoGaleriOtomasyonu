using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtoGaleriOtomasyonu
{
    public partial class kar : Form
    {
        aracveritabani aracveritabani = new aracveritabani(); 
        public kar()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kar_Load(object sender, EventArgs e)
        {
            yenilelistele();
            dataGridView1.Columns[0].HeaderText = "ALINAN ÜCRET";
            dataGridView1.Columns[1].HeaderText = "TARİH";
            hesaplama();

            
        }
        private void yenilelistele()
        {
            string cumle = "select * from kar";
            SqlDataAdapter adpt2 = new SqlDataAdapter();
            dataGridView1.DataSource = aracveritabani.listele(adpt2, cumle);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void hesaplama()
        {
            long toplam = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                toplam += Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
            }
            label2.Text = toplam.ToString();
        }
    }
}
