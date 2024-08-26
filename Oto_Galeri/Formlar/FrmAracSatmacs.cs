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
using System.Data.SqlClient;
namespace Oto_Galeri.Formlar
{
    public partial class FrmAracSatmacs : Form
    {
        public FrmAracSatmacs()
        {
            InitializeComponent();
        }
        DB_GaleriEntities db = new DB_GaleriEntities();
         SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-8LKDD961\\SQLEXPRESS;Initial Catalog=DB_Galeri;Integrated Security=True;Encrypt=False");
        private void BtnListele_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = db.Arac_SAT().ToList();
        }

        private void BtnAracSat_Click(object sender, EventArgs e)
        {
          baglanti.Open();
            SqlCommand cmd = new SqlCommand("Insert into TblMusteri(Ad,Soyad,Telefon,Arac) Values(@p1,@p2,@p3,@p4)", baglanti);

            cmd.Parameters.Add("@p1", TxtAd.Text);
            cmd.Parameters.Add("@p2",TxtSoyad.Text);
            cmd.Parameters.Add("@p3",TxtTelefon.Text);
            cmd.Parameters.Add("@p4",Txt_Arac_ID.Text);
            cmd.ExecuteNonQuery();
            baglanti.Close();
          


            if(Txt_Arac_ID.Text=="")
            {
                errorProvider1.SetError(Txt_Arac_ID, "Satılacak Aracın ID lütfen giriniz");
            }
            else
            {
                int maxId = db.TblMusteri
                          .OrderByDescending(x => x.MusteriID) // ID'ye göre azalan sırada sıralar
                          .Select(x => x.MusteriID) // Sadece MusteriID'yi seçer
                          .FirstOrDefault(); // İlk değeri alır

                var y = db.TblMusteri.Find(maxId);
                y.Ad=TxtAd.Text;
                y.Soyad=TxtSoyad.Text;
                y.Telefon=int.Parse(TxtTelefon.Text);


                int id = int.Parse(Txt_Arac_ID.Text);
                var z=db.TblAracBilgileri.Find(id);
                z.Satis_Tarihi=DateTime.Parse(mskSatisTarihi.Text);
                z.Satis_Fiyati=int.Parse(TxtSatisFiyati.Text);
                z.Durum = "Satıldı";


                db.SaveChanges();
                

                MessageBox.Show("Araç satım işlemi başarılı bir şekilde tamamlanmıştır", "Araç Satım İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void BtnAracListele_Click(object sender, EventArgs e)
        {
            var degerler = from x in db.TblAracBilgileri
                           select new
                           {
                               x.ID,
                               x.Marka,
                               x.Plaka,
                               x.Kilometre,
                               x.Alim_Tarihi,
                               x.Durum,
                               x.TblKategori.Kategori_ID,
                               x.TblKategori.Kategoriler
                           };
            dataGridView1.DataSource = degerler.Where(x => x.Durum == "Boş").ToList(); 
        }

        private void BtnMüşterilerilListele_Click(object sender, EventArgs e)
        {
            var degerler = from x in db.TblMusteri
                           select new
                           {
                               x.MusteriID,
                               x.Ad,
                               x.Soyad,
                               x.Telefon,
                               x.Arac,
                               x.TblAracBilgileri1.Marka,
                               x.TblAracBilgileri1.Alim_Tarihi,
                               x.TblAracBilgileri1.Alis_Fiyati
                           };
            dataGridView1.DataSource=degerler.ToList();

        }

        private void FrmAracSatmacs_Load(object sender, EventArgs e)
        {

        }
    }
}
