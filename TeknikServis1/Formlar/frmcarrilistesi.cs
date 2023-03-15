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
    public partial class frmcarrilistesi : Form
    {
        public frmcarrilistesi()
        {
            InitializeComponent();
        }
        DbTeknikServısEntities db = new DbTeknikServısEntities();
        void listeleme()
        {
            var deger = from x in db.TBLCARI
                        where x.DURUM==true
                        select new
                        {
                            x.ID,
                            x.AD,
                            x.SOYAD,
                            x.MAIL,
                            x.TELEFON,
                            x.IL,
                            x.ILCE,
                            x.BANKA,
                            x.VERGIDAIRESI,
                            x.VERGINO,
                            x.STATU,
                            x.ADRES
                        };
            gridControl1.DataSource = deger.ToList();
        }
        private void frmcarrilistesi_Load(object sender, EventArgs e)
        {
            listeleme();

            // illeri lookupedite listeleme
            lkpdtİL.Properties.DataSource = db.iller.ToList();

            // toplam cari sayısı çekme
            labelControl12.Text = db.TBLCARI.Count().ToString();

            // Aktif Cari Sayısını Çekme
            labelControl14.Text = db.TBLCARI.Where(x => x.DURUM == true).Count().ToString();

            // toplam il sayısını çekme
            labelControl16.Text = db.TBLCARI.Where(x=>x.DURUM==true).GroupBy(x => x.IL).Count().ToString();

            // en fazla carili ili çekme
            var deger = db.TBLCARI.OrderBy(x => x.IL).GroupBy(x => x.IL).Select(x => new
            {
                İL = x.Key,
                Toplam = x.Count()
            }).OrderByDescending(x => x.Toplam);
            labelControl18.Text = deger.Select(x => x.İL).FirstOrDefault().ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void lkpdtİL_EditValueChanged(object sender, EventArgs e)
        {
            byte il = byte.Parse(lkpdtİL.EditValue.ToString());
            // ilceleri lookupedite çekme
            var deger = from x in db.ilceler
                        where x.sehir == il
                        select new
                        {
                            x.id,
                            x.ilce
                        };
            lkpdtİLÇE.Properties.DataSource = deger.ToList();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            int s1 = Convert.ToInt32(lkpdtİL.EditValue);
            int s2 = Convert.ToInt32(lkpdtİLÇE.EditValue);
            try
            {
                if (s1!=0&&s2!=0)
                {
                    DialogResult dialogResult = MessageBox.Show("Cari Ekleme İşlemini Onaylıyormusnuz ?", "ONAY", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult==DialogResult.Yes)
                    {
                        TBLCARI t = new TBLCARI();
                        t.AD = txtad.Text;
                        t.SOYAD = txtsoyad.Text;
                        t.TELEFON = txttelefon.Text;
                        t.MAIL = txtmaıl.Text;
                        t.IL = lkpdtİL.Text;
                        t.ILCE = lkpdtİLÇE.Text;
                        t.BANKA = txtbanka.Text;
                        t.VERGIDAIRESI = txtvergidairesi.Text;
                        t.VERGINO = txtvergino.Text;
                        t.STATU = txtstatu.Text;
                        t.ADRES = txtadres.Text;
                        t.DURUM = true;
                        db.TBLCARI.Add(t);
                        db.SaveChanges();
                        MessageBox.Show("Cari Kaydedilmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("İşlem Gerçekleşmedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                DialogResult dialogResult = MessageBox.Show("Cariyi Silmek İstediğinize Eminmisiniz ?", "ONAY", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult==DialogResult.Yes)
                {
                    int id = Convert.ToInt32(txtıd.Text);
                    var deger = db.TBLCARI.Find(id);
                    deger.DURUM = false;
                    db.SaveChanges();
                    MessageBox.Show("Cari Silinmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtıd.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtad.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            txtsoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
            txttelefon.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();
            txtmaıl.Text = gridView1.GetFocusedRowCellValue("MAIL").ToString();
            txtbanka.Text = gridView1.GetFocusedRowCellValue("BANKA").ToString();
            txtvergidairesi.Text = gridView1.GetFocusedRowCellValue("VERGIDAIRESI").ToString();
            txtvergino.Text = gridView1.GetFocusedRowCellValue("VERGINO").ToString();
            txtstatu.Text = gridView1.GetFocusedRowCellValue("STATU").ToString();
            txtadres.Text = gridView1.GetFocusedRowCellValue("ADRES").ToString();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Cari Bilgilerini Güncellemek İstediğinize Eminmisiniz ?", "ONAY", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult==DialogResult.Yes)
                {
                    int id = Convert.ToInt32(txtıd.Text);
                    var deger = db.TBLCARI.Find(id);
                    deger.AD = txtad.Text;
                    deger.SOYAD = txtsoyad.Text;
                    deger.TELEFON = txttelefon.Text;
                    deger.MAIL = txtmaıl.Text;
                    deger.IL = lkpdtİL.Text;
                    deger.ILCE = lkpdtİLÇE.Text;
                    deger.BANKA = txtbanka.Text;
                    deger.VERGIDAIRESI = txtvergidairesi.Text;
                    deger.VERGINO = txtvergino.Text;
                    deger.STATU = txtstatu.Text;
                    deger.ADRES = txtadres.Text;
                    deger.DURUM = true;
                    db.SaveChanges();
                    MessageBox.Show("Cari Kaydedilmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnListele_Click(object sender, EventArgs e)
        {
            listeleme();
        }
    }
}
