using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oto_Galeri.Entity;
namespace Oto_Galeri.Formlar
{
    public partial class FrmAracAlimSatimcs : Form
    {
        public FrmAracAlimSatimcs()
        {
            InitializeComponent();
        }
        DB_GaleriEntities db = new DB_GaleriEntities();

        private void FrmAracAlimSatimcs_Load(object sender, EventArgs e)
        {
            CmbKategori.ValueMember = "KategoriID";
            CmbKategori.DisplayMember = "Kategoriler";
            CmbKategori.DataSource = db.TblKategori.ToList();

        }
        private void BtnAracEkle_Click(object sender, EventArgs e)
        {

            TblAracBilgileri t = new TblAracBilgileri();
            t.Marka = CmbMarka.SelectedItem.ToString();
            t.Plaka = TxtPlaka.Text;
            t.Kilometre = int.Parse(TxtKilometre.Text);
            t.Alim_Tarihi = DateTime.Parse(mskAlimTarihi.Text);
            t.Alis_Fiyati = int.Parse(TxtAlisFiyati.Text);
            t.Resim = TxtResim.Text;
            t.Durum = "Boş"; 
            t.Kategori_No=int.Parse(CmbKategori.SelectedIndex+1.ToString());
            db.TblAracBilgileri.Add(t);
            db.SaveChanges();
 
            MessageBox.Show("Araç başarılı bir şekilde sisteme kaydedilmiştir", "Araç Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information); 
           
        }

        

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var degerler = from x in db.TblAracBilgileri
                           select new
                           {
                               x.ID,
                               x.Marka,
                               x.Plaka,
                               x.Kilometre,
                               x.Alis_Fiyati,
                               x.Alim_Tarihi,
                               x.Resim,
                               x.Durum,
                               x.TblKategori.Kategoriler
                               //AdSoyad = x.TblMusteri.Ad + " " + x.TblMusteri.Soyad
                           };
            dataGridView1.DataSource = degerler.ToList();
        }

        private void BtnSec_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            TxtResim.Text=openFileDialog1.FileName;
        }

        private void BtnGoruntule_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = TxtResim.Text;
        }
    }
}
