using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtoGaleriOtomasyonu
{
    public partial class anamenu : Form
    {
        public anamenu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            müsteriekleme müsteriekleme = new müsteriekleme();
            müsteriekleme.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            aracekleme aracekleme = new aracekleme();
            aracekleme.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            musterilisteleme musterilist = new musterilisteleme();
            musterilist.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            araclisteleme araclisteleme = new araclisteleme();
            araclisteleme.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            arackiralama arackiralama = new arackiralama();
            arackiralama.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            aracsatis aracsatis = new aracsatis();
            aracsatis.Show();
        }

        private void karbtn_Click(object sender, EventArgs e)
        {
            kar karozet = new kar();
            karozet.Show();
        }
    }
}
