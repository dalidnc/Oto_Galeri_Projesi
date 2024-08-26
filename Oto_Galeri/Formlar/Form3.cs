using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oto_Galeri.Formlar
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void panel1_Click(object sender, EventArgs e)
        {

            FrmAracSatmacs frm = new FrmAracSatmacs();
            frm.Show();
            this.Hide();
        }

        private void AracAl_Click(object sender, EventArgs e)
        {
            FrmAracAlimSatimcs frm = new FrmAracAlimSatimcs();
            frm.Show();
            this.Hide();
        }

        private void AracListele_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void AracGuncelle_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();

        }

        private void SatisMusteri_Click(object sender, EventArgs e)
        {
            FrmMusteriBilgileri frm = new FrmMusteriBilgileri();
            frm.Show();
            this.Hide();
        }

        private void MusteriGuncelle_Click(object sender, EventArgs e)
        {
            FrmMusteriBilgileri frm = new FrmMusteriBilgileri();
            frm.Show();
            this.Hide();
        }

       
    }
}
