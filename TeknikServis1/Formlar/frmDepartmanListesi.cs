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
    public partial class frmDepartmanListesi : Form
    {
        public frmDepartmanListesi()
        {
            InitializeComponent();
        }
        DbTeknikServısEntities db = new DbTeknikServısEntities();
        void listeleme()
        {
            var deger = from x in db.TBLDEPARTMAN
                        where x.durum == true
                        select new
                        {
                            x.ID,
                            x.AD,
                            x.ACIKLAMA
                        };
            gridControl1.DataSource = deger.ToList();

        }
        private void frmDepartmanListesi_Load(object sender, EventArgs e)
        {
            
            listeleme();

            // toplam departman sayısı çekme
            labelControl12.Text = db.TBLDEPARTMAN.Count(x=>x.durum==true).ToString();

            // toplam personel sayısı
            labelControl14.Text = db.TBLPERSONEL.Count().ToString();

            // en fazla çalışanı departman
            var deger = db.TBLPERSONEL.OrderBy(x => x.TBLDEPARTMAN.AD).GroupBy(y => y.TBLDEPARTMAN.AD).Select(z => new
            {
                Departman = z.Key,
                Toplam = z.Count()
            }).OrderByDescending(z=>z.Toplam);
            labelControl16.Text = deger.Select(x => x.Departman).FirstOrDefault().ToString();

            // en az çalışanı olan departman
            var degerr = db.TBLPERSONEL.OrderBy(x => x.TBLDEPARTMAN.AD).GroupBy(y => y.TBLDEPARTMAN.AD).Select(z => new
            {
                Departman = z.Key,
                Toplam = z.Count()
            }).OrderBy(a=>a.Toplam);
            labelControl18.Text = degerr.Select(x => x.Departman).FirstOrDefault().ToString();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listeleme();
        }
        TBLDEPARTMAN t = new TBLDEPARTMAN();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Departman Kaydetme İşlemini Onaylıyormusunuz ?", "ONAY", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes&&rchtxtacıkalama.Text!=null)
                {
                    t.AD = txtad.Text;
                    t.ACIKLAMA = rchtxtacıkalama.Text;
                    t.durum = true;
                    db.TBLDEPARTMAN.Add(t);
                    db.SaveChanges();
                    MessageBox.Show("Departman Kaydedilmiştir", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                DialogResult dialogResult = MessageBox.Show("Departman Silme İşlemini Onaylıyormusunuz ?", "ONAY", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    int ıd = Convert.ToInt32(txtıd.Text);
                    var deger = db.TBLDEPARTMAN.Find(ıd);
                    deger.durum = false;
                    db.SaveChanges();
                    MessageBox.Show("Departman Silinmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Departman Bilgilerini Güncelleme  İşlemini Onaylıyormusunuz ?", "ONAY", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes&&rchtxtacıkalama.Text!="")
                {
                    int id = Convert.ToInt32(txtıd.Text);
                    var deger = db.TBLDEPARTMAN.Find(id);
                    deger.AD = txtad.Text;
                    deger.ACIKLAMA = rchtxtacıkalama.Text;
                    deger.durum = true;
                    db.SaveChanges();
                    MessageBox.Show("Departman Bilgileri Güncellenmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("İşlem Gerçekleşmedi","Hata",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("İşlem Gerçekleşmedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtad.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            txtıd.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            rchtxtacıkalama.Text = gridView1.GetFocusedRowCellValue("ACIKLAMA").ToString();
        }
    }
}
