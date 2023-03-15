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
    public partial class frmkategorilistesi : Form
    {
        public frmkategorilistesi()
        {
            InitializeComponent();
        }
        DbTeknikServısEntities db = new DbTeknikServısEntities();
        void listeleme()
        {
            var deger = from u in db.TBLKATEGORI
                        where u.durum==true
                        select new
                        {
                            u.ID,
                            u.AD,
                        };
            gridControl1.DataSource = deger.ToList();
        }
        private void frmkategorilistesi_Load(object sender, EventArgs e)
        {
            listeleme();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listeleme();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Kategori Kaydetme İşlemini Onaylıyormusnuz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    TBLKATEGORI t = new TBLKATEGORI();
                    t.AD = txtkategorıad.Text;
                    t.durum = true;
                    db.TBLKATEGORI.Add(t);
                    db.SaveChanges();
                    MessageBox.Show("Kategori Kaydedilmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                DialogResult dr = MessageBox.Show("Geçerli Kategoriyi Silme İşlemini Onaylıyormusunuz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr==DialogResult.Yes)
                {
                    int id = int.Parse(txtkategorııd.Text);
                    var deger = db.TBLKATEGORI.Find(id);
                    deger.durum = false;
                    db.SaveChanges();
                    MessageBox.Show("Geçerli Kategori Silinmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                DialogResult dr = MessageBox.Show("Geçerli Kategori Bilgilerini Güncelleme İşlemini Onaylıyormusnuz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr==DialogResult.Yes)
                {
                    int id = int.Parse(txtkategorııd.Text);
                    var deger = db.TBLKATEGORI.Find(id);
                    deger.AD = txtkategorıad.Text;
                    deger.durum = true;
                    db.SaveChanges();
                    MessageBox.Show("Geçerli Kategorinin Bilgileri Güncellenmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtkategorııd.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtkategorıad.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.apple.com/tr/");
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.bosch.com.tr/");
        }

        private void pictureEdit3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.samsung.com/tr/");
        }

        private void pictureEdit7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.lenovo.com/tr/tr/");
        }

        private void pictureEdit4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.beko.com.tr/");
        }

        private void pictureEdit5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://new.siemens.com/tr/tr.html");
        }

        private void pictureEdit6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.monsternotebook.com.tr/");
        }

        private void pictureEdit8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.arcelik.com.tr/");
        }

        private void pictureEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
