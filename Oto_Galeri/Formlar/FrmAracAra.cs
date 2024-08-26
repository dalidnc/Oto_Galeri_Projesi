using Oto_Galeri.Entity;
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
    public partial class FrmAracAra : Form
    {
        public FrmAracAra()
        {
            InitializeComponent();
        }
        DB_GaleriEntities db = new DB_GaleriEntities();
        public int id;
       
        Form1 form1 = new Form1();
       public int degree;
        private void FrmAracAra_Load(object sender, EventArgs e)
        {
           if(degree==2)
            {
                mskAlimTarihi.Visible = false;
                TxtAlisFiyati.Visible = false;

                
            }
            TblAracBilgileri t = new TblAracBilgileri();

            var x = db.TblAracBilgileri.Find(id);
            TxtArac_ID.Text = id.ToString();
            TxtDurum.Text = x.Durum;
            TxtAlisFiyati.Text = x.Alis_Fiyati.ToString();
            TxtSatisFiyati.Text = x.Satis_Fiyati.ToString();
            TxtPlaka.Text = x.Plaka;
            CmbMarka.Text = x.Marka.ToString();
            TxtKilometre.Text = x.Kilometre.ToString();
            mskAlimTarihi.Text = x.Alim_Tarihi.ToString();
            mskSatisTarihi.Text = x.Satis_Tarihi.ToString();
            TxtPlaka.Text = x.Plaka;
            TxtResim.Text = x.Resim.ToString();



            pictureBox1.ImageLocation = TxtResim.Text;
            //
        }

        private void BtnAracEkle_Click(object sender, EventArgs e)
        {
            if(degree==2)
            {
                Form1 form1 = new Form1();
                form1.derece = 2;
            
                form1.Show();
                this.Close();
                
            }
            else
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Close();
            }
           
        }
    }
}
