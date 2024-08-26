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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        DB_GaleriEntities db = new DB_GaleriEntities();
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-8LKDD961\\SQLEXPRESS;Initial Catalog=DB_Galeri;Integrated Security=True;Encrypt=False");
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            if(TxtKullaniciAd.Text=="" || TxtSifre.Text=="")
            {
                errorProvider1.SetError(TxtKullaniciAd, "Kullancı adı ve şifre bölümü boş olamaz");
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Select * from Users Where UserName=@p1 and Password=@p2", baglanti);
                komut.Parameters.Add("@p1", TxtKullaniciAd.Text);
                komut.Parameters.Add("@p2",TxtSifre.Text);

               
                Form1 frm = new Form1();
              

                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    //form1.derece = int.Parse(dr["Degree"].ToString());


                    frm.derece = int.Parse(dr[1].ToString());
                    if(frm.derece!=2)
                    {
                        Form3 frm3 = new Form3();
                        frm3.Show();
                        this.Hide();
                    }
                    else
                    {
                        frm.Show();
                        this.Hide();
                    }
                    
                    


                }
                else
                {
                    MessageBox.Show("Kullanici adi veya şifre hatalı,Lütfen Tekrar deneyiniz","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                baglanti.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.CheckState==CheckState.Checked)
            {
                TxtSifre.UseSystemPasswordChar = true;
                checkBox1.Text = "Göster";
            }
            else if(checkBox1.CheckState==CheckState.Unchecked)
            {
                TxtSifre.UseSystemPasswordChar = false;
                checkBox1.Text = "Gizle";
            }
        }
    }
}
