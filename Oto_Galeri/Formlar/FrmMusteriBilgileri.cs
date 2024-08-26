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
    public partial class FrmMusteriBilgileri : Form
    {
        public FrmMusteriBilgileri()
        {
            InitializeComponent();
        }
        DB_GaleriEntities db = new DB_GaleriEntities();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmMusteriBilgileri_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.View_1.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtMusteriID .Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtMusteriAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtMusteriSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtTelNo.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtAracID.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            cmbMarka.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtPlaka.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtKilometre.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtSatisFiyati.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            msk_satisTarihi.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = db.View_1.ToList();
            dataGridView1.DataSource = db.Musteriler().ToList();
          

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtMusteriID.Text== "")
            {
                errorProvider1.SetError(TxtMusteriID, "Müşteri ID kısmı boş bırakılamaz");
            }
            else
            {
                int id = int.Parse(TxtMusteriID.Text);
                var x = db.TblMusteri.Find(id);
                x.Ad = TxtMusteriAd.Text;
                x.Soyad = TxtMusteriSoyad.Text;
                x.Telefon = int.Parse(TxtTelNo.Text);
                x.Arac = int.Parse(TxtAracID.Text);
                int arac_id = int.Parse(TxtAracID.Text);
                var y = db.TblAracBilgileri.Find(arac_id);
                y.Plaka = (TxtPlaka.Text);
                y.Marka = cmbMarka.SelectedItem.ToString();
                y.Kilometre = int.Parse(TxtKilometre.Text);
                y.Satis_Fiyati = int.Parse(TxtSatisFiyati.Text);
                y.Satis_Tarihi = DateTime.Parse(msk_satisTarihi.Text);
                db.SaveChanges();

                MessageBox.Show("Bilgiler başarılı bir şekilde güncellenmiştir","Güncelleme İşlemi",MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            if (TxtMusteriID.Text == "")
            {
                errorProvider1.SetError(TxtMusteriID, "Müşteri ID kısmı boş bırakılamaz");
            }
            else
            {
                int id = int.Parse(TxtMusteriID.Text);
                dataGridView1.DataSource = db.Musteriler().Where(x => x.MusteriID == id).ToList();

            }

            //if(TxtMusteriAd.Text!="")
            //{
            //    dataGridView1.DataSource = db.View_1.Where(y => y.Ad == TxtMusteriAd.Text).ToList();

            //}
            //else if(TxtMusteriSoyad.Text!="")
            //{
            //    dataGridView1.DataSource = db.View_1.Where(y => y.Soyad == TxtMusteriSoyad.Text).ToList();
            //}

        }

      
        
    }

}
