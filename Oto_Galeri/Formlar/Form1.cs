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
using Oto_Galeri.Entity;



namespace Oto_Galeri.Formlar
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        DB_GaleriEntities db = new DB_GaleriEntities();
        public int derece;
       // SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-8LKDD961\\SQLEXPRESS;Initial Catalog=DB_Galeri;Integrated Security=True;Multiple Active Result Sets=True;Encrypt=False;Application Name=EntityFramework");
        private void Form1_Load(object sender, EventArgs e)
        {
          

            CmbKatogori.DisplayMember = "Kategoriler";
            CmbKatogori.ValueMember = "KategoriID";
            CmbKatogori.DataSource=db.TblKategori.ToList();
            
            if(derece==2)
            {
                Listele();
                this.Size = new Size(907,600);
                this.BtnListele.Location = new Point(12, 545);
                groupBox1.Visible = false;
                BtnAracEkle.Visible = false;
                BtnAracSil.Visible = false;
                BtnGüncelle.Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
               
            }
            else
            {
                this.BtnListele.Location = new Point(958, 504);
                groupBox1.Visible = true;
                BtnAracEkle.Visible = true;
                BtnAracSil.Visible = true;
                BtnGüncelle.Visible = true;
              
            }

        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            if(TxtArac_ID.Text=="")
            {
                errorProvider1.SetError(TxtArac_ID, "Güncellenme işleminde AraçID boş bırakılamaz");
            }
            else
            {
                int arac_id = int.Parse(TxtArac_ID.Text);
                var x = db.TblAracBilgileri.Find(arac_id);
                x.Marka = CmbMarka.SelectedItem.ToString();
                x.Plaka = TxtPlaka.Text; 
                x.Kilometre = int.Parse(TxtKilometre.Text);
                x.Alim_Tarihi = DateTime.Parse(mskAlimTarihi.Text);
                x.Alis_Fiyati = int.Parse(TxtAlisFiyati.Text);
                x.Satis_Fiyati = int.Parse(TxtSatisFiyati.Text);
                x.Resim = TxtResim.Text;
                db.SaveChanges();
                MessageBox.Show("Bilgiler başarılı bir şekilde güncellendi", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          
        }
        public void Listele()
        {
            var degerler = from x in db.TblAracBilgileri
                           select new
                           {
                               x.ID,
                               x.Marka,
                               x.Plaka,
                               x.Kilometre,
                               x.Alis_Fiyati,
                               x.Satis_Fiyati,
                               x.Alim_Tarihi,
                               x.Satis_Tarihi,
                               x.Durum,
                               x.Resim,
                               //AdSoyad = x.TblMusteri.Ad + " " + x.TblMusteri.Soyad

                           };

            if(derece==2)
            {
                dataGridView1.DataSource = degerler.Where(x => x.Durum == "Boş").ToList();

            }
            else
            {
                dataGridView1.DataSource = degerler.ToList();
            }
            
        }
        private void BtnListele_Click(object sender, EventArgs e)
        {
           
            Listele();
        }
        private void BtnAracEkle_Click(object sender, EventArgs e)
        {
            
            TblAracBilgileri t = new TblAracBilgileri();
            t.Marka=CmbMarka.SelectedItem.ToString();
            t.Plaka=TxtPlaka.Text;
            t.Kilometre=int.Parse(TxtKilometre.Text); 
            t.Alim_Tarihi = DateTime.Parse(mskAlimTarihi.Text);
            t.Alis_Fiyati = int.Parse(TxtAlisFiyati.Text);
            t.Satis_Fiyati = int.Parse(TxtSatisFiyati.Text);
            t.Resim = TxtResim.Text;
            t.Durum = "Bos";
           db.TblAracBilgileri.Add(t);
            db.SaveChanges();
            MessageBox.Show("Yeni araç kaydı başarıli bir şekilde yapılmıştır", "Araç Ekleme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // TxtArac_ID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //CmbMarka.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString().FirstOrDefault();
            //TxtPlaka.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //TxtKilometre.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            //mskAlimTarihi.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            //mskSatisTarihi.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            //TxtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            //TxtAlisFiyati.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            //TxtSatisFiyati.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();


            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                // Hücrelerin değerlerini alırken null kontrolü yapın
                TxtArac_ID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value?.ToString() ?? string.Empty;
                var markaValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value?.ToString() ?? string.Empty;
                CmbMarka.SelectedValue = markaValue.Length > 0 ? markaValue.First() : (object)null;
                TxtPlaka.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value?.ToString() ?? string.Empty;
                TxtKilometre.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value?.ToString() ?? string.Empty;
                mskAlimTarihi.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value?.ToString() ?? string.Empty;
                mskSatisTarihi.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value?.ToString() ?? string.Empty;
                TxtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value?.ToString() ?? string.Empty;
                TxtAlisFiyati.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value?.ToString() ?? string.Empty;
                TxtSatisFiyati.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value?.ToString() ?? string.Empty;
                TxtResim.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value?.ToString() ?? string.Empty;
            }

        }

        private void BtnResimSec_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            TxtResim.Text = openFileDialog1.FileName;
        }

        private void BtnAracSil_Click(object sender, EventArgs e)
        {
            if(TxtSatisFiyati.Text=="" && mskSatisTarihi.Text=="")
            {
                errorProvider1.SetError(TxtSatisFiyati, "Satış fiyatini girmediniz");
                errorProvider1.SetError(mskSatisTarihi, "Satış tarihini girmediniz");
            }
            else
            {
                int id = int.Parse(TxtArac_ID.Text);
                var x = db.TblAracBilgileri.Find(id);
                x.Durum = "Satıldı";
                x.Satis_Tarihi = DateTime.Parse(mskSatisTarihi.Text);
                db.SaveChanges(); 
                MessageBox.Show("Araç başarılı bir şekilde satıldı");
            }


        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            var degerler = from x in db.TblAracBilgileri
                           select new
                           {

                               x.ID,
                               x.Marka,
                               x.Plaka,
                               x.Kilometre,
                               x.Alis_Fiyati,
                               x.Satis_Fiyati,
                               x.Alim_Tarihi,
                               x.Satis_Tarihi,
                               x.Durum,
                               x.Resim,
                               x.TblKategori.Kategoriler,
                               x.Kategori_No

                           };
            if(derece==2)
            {
                dataGridView1.DataSource = degerler.Where(x => x.Marka == TxtMarka.Text && x.Durum=="Boş").ToList();
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[6].Visible = false;
            }
            else
            {
                dataGridView1.DataSource = degerler.Where(x => x.Marka == TxtMarka.Text).ToList();
            }
          
            //dataGridView1.Columns[7].Visible = false;
            //dataGridView1.Columns[6].Visible = false;
            //dataGridView1.Columns[8].Visible = false;
        }

        private void BtnAra2_Click(object sender, EventArgs e)
        {
            if (AracID2.Text == "")
            {
                errorProvider1.SetError(AracID2, "Araç ID boş olamaz");
            }
            else
            {
               if(derece==2)
                {
                    FrmAracAra frm = new FrmAracAra();
                    frm.degree = 2;
                    frm.id = int.Parse(AracID2.Text);
                    frm.Show();
                    
                    this.Close();
                }
               else
                {
                    FrmAracAra frm = new FrmAracAra();
                    frm.id = int.Parse(AracID2.Text);
                    frm.Show();
                    this.Close();
                }
                
               
            }
            //dataGridView1.DataSource=db.TblAracBilgileri.Where(x=>x.ID==int.Parse(TxtArac_ID.Text)).ToList();
        }

        private void CmbMarkaAra_SelectedIndexChanged(object sender, EventArgs e)
        {

            var degerler = from x in db.TblAracBilgileri
                           select new
                           {

                               x.ID,
                               x.Marka,
                               x.Plaka,
                               x.Kilometre,
                               x.Alis_Fiyati,
                               x.Satis_Fiyati,
                               x.Alim_Tarihi,
                               x.Satis_Tarihi,
                               x.Durum,
                               x.Resim,
                               x.TblKategori.Kategoriler,
                               x.Kategori_No

                           };
           

            CmbMarka.ValueMember = "Marka";
            CmbMarka.DisplayMember = "Marka";
            CmbMarka.DataSource = db.TblKategori.ToList();
            //dataGridView1.Columns[9].Visible = false;
            if(derece==2)
            {
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                
                dataGridView1.DataSource = degerler.Where(y => y.Marka == (CmbMarka.SelectedText) && y.Durum=="Boş").ToList();
            }
            else
            {
                dataGridView1.DataSource = degerler.Where(y => y.Marka == (CmbMarka.SelectedText)).ToList();
            }
            


        }
        private void CmbKatogori_SelectedIndexChanged(object sender, EventArgs e)
        {
            var degerler = from x in db.TblAracBilgileri
                           select new
                           {

                               x.ID,
                               x.Marka,
                               x.Plaka,
                               x.Kilometre,
                               x.Alis_Fiyati,
                               x.Satis_Fiyati,
                               x.Alim_Tarihi,
                               x.Satis_Tarihi,
                               x.Durum,
                               x.Resim,
                               x.TblKategori.Kategoriler,
                               x.Kategori_No

                           };
           
            if(derece==2)
            {
                dataGridView1.DataSource = degerler.Where(y => y.Kategori_No == CmbKatogori.SelectedIndex + 1 && y.Durum=="Boş").ToList();
                dataGridView1.Columns[9].Visible = false;
            }
            else
            {
                dataGridView1.DataSource = degerler.Where(y => y.Kategori_No == CmbKatogori.SelectedIndex + 1).ToList();
                dataGridView1.Columns[9].Visible = false;
            }
           

        }
        private void BtnAraBul_Click(object sender, EventArgs e)
        {
            if(AracID2.Text=="")
            {
                errorProvider1.SetError(AracID2, "Araç ID boş olamaz");
            }
            else
            {
                int id = int.Parse(AracID2.Text);
                var y = db.TblAracBilgileri.Find(id);


                var degerler = from x in db.TblAracBilgileri
                               select new
                               {

                                   x.ID,
                                   x.Marka,
                                   x.Plaka,
                                   x.Kilometre,
                                   x.Alis_Fiyati,
                                   x.Satis_Fiyati,
                                   x.Alim_Tarihi,
                                   x.Satis_Tarihi,
                                   x.Durum,
                                   x.Resim,
                                   x.TblKategori.Kategoriler,
                                   x.Kategori_No

                               };
                if (derece == 2)
                {
                    dataGridView1.DataSource = degerler.Where(x => x.ID == y.ID && x.Durum == "Boş").ToList();
                }
                else
                {
                    dataGridView1.DataSource = degerler.Where(x => x.ID == y.ID).ToList();

                }
            }
          
            // dataGridView1.DataSource=db.TblAracBilgileri.Where(x=>x.ID==y.ID).ToList();
        }
    }
}
