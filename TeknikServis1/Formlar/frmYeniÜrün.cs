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
    public partial class frmYeniÜrün : Form
    {
        public frmYeniÜrün()
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
            int s = int.Parse(lookUpEdit1.EditValue.ToString());
            try
            {
                if (s != 0)
                {
                    TBLURUN t = new TBLURUN();
                    t.AD = txtUrunAd.Text;
                    t.MARKA = txtMarka.Text;
                    t.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());
                    t.ALISFIYAT = decimal.Parse(txtAlısFiyat.Text);
                    t.SATISFIYAT = decimal.Parse(txtSatİsFiyat.Text);
                    t.STOKSAYISI = short.Parse(txtStok.Text);
                    t.durum2 = true;
                    db.TBLURUN.Add(t);
                    db.SaveChanges();
                    MessageBox.Show("Ürün Kaydedilmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ürün Kaydedilmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ürün Kaydedilmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmYeniÜrün_Load(object sender, EventArgs e)
        {
            //lookUpEdit1.Properties.DataSource = db.TBLKATEGORI.ToList();

            var deger = from x in db.TBLKATEGORI
                        where x.durum == true
                        select new
                        {
                            x.ID,
                            x.AD
                        };
            lookUpEdit1.Properties.DataSource = deger.ToList();
        }
    }
}
