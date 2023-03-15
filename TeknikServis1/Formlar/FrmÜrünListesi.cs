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
    public partial class FrmÜrünListesi : Form
    {
        public FrmÜrünListesi()
        {
            InitializeComponent();
        }

        DbTeknikServısEntities db = new DbTeknikServısEntities();
        void listeleme()
        {
            // Sadece istenilen kısımların listelemesini yapan kod 
            var deger = from u in db.TBLURUN
                        where u.durum2 == true
                        select new
                        {
                            u.ID,
                            u.AD,
                            u.MARKA,
                            KATEGORI = u.TBLKATEGORI.AD,
                            u.ALISFIYAT,
                            u.SATISFIYAT,
                            u.STOKSAYISI,
                        };
            gridControl1.DataSource = deger.ToList();
        }
        private void FrmÜrünListesi_Load(object sender, EventArgs e)
        {
            // ürün listeleme
            listeleme();


            // kategorileri lookup edite gönderme
            ////lookUpEdit1.Properties.DataSource = db.TBLKATEGORI.ToList();

            var deger = from x in db.TBLKATEGORI
                        where x.durum == true
                        select new
                        {
                            x.ID,
                            x.AD
                        };
            lookUpEdit1.Properties.DataSource = deger.ToList();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listeleme();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            int s = int.Parse(lookUpEdit1.EditValue.ToString());
            try
            {
                if (s!=0)
                {
                    DialogResult dr = MessageBox.Show("Kategori Kaydetme İşlemini Onaylıyormusnuz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        TBLURUN t = new TBLURUN();
                        t.AD = txtUrunAd.Text;
                        t.MARKA = txtMarka.Text;
                        t.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());
                        t.ALISFIYAT = decimal.Parse(txtAlisFiyat.Text);
                        t.SATISFIYAT = decimal.Parse(txtSatısFiyat.Text);
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
                else
                {
                    MessageBox.Show("İşlem Gerçekleşmedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("İşlem Gerçekleşmedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Geçerli Ürünü Silme İşlemine Onay Veriyormusunuz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult ==DialogResult.Yes)
                {
                    int id = int.Parse(txtUrunId.Text);
                    var deger = db.TBLURUN.Find(id);
                    deger.durum2 = false;
                    db.SaveChanges();
                    MessageBox.Show("Geçerli ürün Silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("İşlem Gerçekleşmedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("İşlem Gerçekleşmedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtUrunId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtUrunAd.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            txtMarka.Text = gridView1.GetFocusedRowCellValue("MARKA").ToString();
            txtAlisFiyat.Text = gridView1.GetFocusedRowCellValue("ALISFIYAT").ToString();
            txtSatısFiyat.Text = gridView1.GetFocusedRowCellValue("SATISFIYAT").ToString();
            txtStok.Text = gridView1.GetFocusedRowCellValue("STOKSAYISI").ToString();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Geçerli Ürününün Bilgilerinin güncellenmesine Onay Veriyormusunuz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult==DialogResult.Yes)
                {
                    int id = int.Parse(txtUrunId.Text);
                    var deger = db.TBLURUN.Find(id);
                    deger.AD = txtUrunAd.Text;
                    deger.MARKA = txtMarka.Text;
                    deger.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());
                    deger.ALISFIYAT = decimal.Parse(txtAlisFiyat.Text);
                    deger.SATISFIYAT = decimal.Parse(txtSatısFiyat.Text);
                    deger.STOKSAYISI = short.Parse(txtStok.Text);
                    deger.durum2 = true;
                    db.SaveChanges();
                    MessageBox.Show("Geçerli Ürünün Bilgileri Güncellenmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("İşlem Gerçekleşmedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("İşlem Gerçekleşmedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
