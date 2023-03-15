using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis1.Formlar
{
    public partial class FrmUrunSatıs : Form
    {
        public FrmUrunSatıs()
        {
            InitializeComponent();
        }
        DbTeknikServısEntities db = new DbTeknikServısEntities();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUNHAREKET t = new TBLURUNHAREKET();
            t.URUN = int.Parse(txtUrunıd.Text);
            t.MUSTERI = int.Parse(txtMusteri.Text);
            t.PERSONEL = short.Parse(txtpersonel.Text);
            t.TARIH = DateTime.Parse(txttarih.Text);
            t.ADET = short.Parse(numericUpDown1.Text);
            t.FIYAT = decimal.Parse(txtfiyat.Text);
            t.URUNSERINO = txtserino.Text;
            db.TBLURUNHAREKET.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Satışı Yapılmıştır.");
        }
        public int ıdd;
        private void FrmUrunSatıs_Load(object sender, EventArgs e)
        {

        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            try
            {
                int ıd = int.Parse(txtUrunıd.Text);
                var sorgu = db.TBLURUN.SingleOrDefault(y => y.ID == ıd);
                if (sorgu != null)
                {
                    txtfiyat.Text = sorgu.SATISFIYAT.ToString();
                }
                else
                {
                    MessageBox.Show("Lütfen Geçerli Bir Ürün Id Giriniz !!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("İşlem Gerçekleşmedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Formlar.frmmusterisecim fr = new frmmusterisecim();
            fr.sayı = 1;
            fr.Show();
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Formlar.frmmusterisecim fr = new frmmusterisecim();
            fr.sayı = 2;
            fr.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Formlar.frmmusterisecim fr = new frmmusterisecim();
            fr.sayı = 3;
            fr.Show();
        }
    }
}
