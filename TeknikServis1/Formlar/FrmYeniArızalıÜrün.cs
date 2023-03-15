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
    public partial class FrmYeniArızalıÜrün : Form
    {
        public FrmYeniArızalıÜrün()
        {
            InitializeComponent();
        }
        DbTeknikServısEntities db = new DbTeknikServısEntities();
        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUNKABUL t = new TBLURUNKABUL();
            t.CARI = int.Parse(txtıd.Text);
            t.GELISTARIH = DateTime.Parse(txttarih.Text);
            t.PERSONEL = short.Parse(txtpersonel.Text);
            t.URUNSERINO = txtserino.Text;
            db.TBLURUNKABUL.Add(t);
            db.SaveChanges();
            MessageBox.Show("Arızalı Ürün Girişi Yapıldı !!!");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtserino.Text!=null)
                {
                    string serino = txtserino.Text;
                    var sorgu = db.TBLURUNHAREKET.SingleOrDefault(x => x.URUNSERINO == serino);
                    txtıd.Text = sorgu.MUSTERI.ToString();
                    txtpersonel.Text = sorgu.PERSONEL.ToString();
                    txttarih.Text = sorgu.TARIH.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı SeriNo Girişi !!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            frmmusterisecim fr = new frmmusterisecim();
            fr.sayı = 1;
            fr.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            frmmusterisecim fr = new frmmusterisecim();
            fr.sayı = 3;
            fr.Show();
        }
    }
}
