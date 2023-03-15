using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace TeknikServis1.Formlar
{
    public partial class frmyenicari : Form
    {
        public frmyenicari()
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

        }

        private void frmyenicari_Load_1(object sender, EventArgs e)
        {
            // illeri lookupedite ekleme
            lookUpEdit1.Properties.DataSource = db.iller.ToList();
            
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            byte il = byte.Parse(lookUpEdit1.EditValue.ToString());
            // ilçeleri lookupedite ekleme
            //lookUpEdit2.Properties.DataSource = db.ilceler.Where(x => x.sehir == il).ToList();


            var deger = from x in db.ilceler
                        where x.sehir == il
                        select new
                        {
                            x.id,
                            x.ilce
                        };
            lookUpEdit2.Properties.DataSource = deger.ToList();
        }

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            int s1 = int.Parse(lookUpEdit1.EditValue.ToString());
            int s2 = int.Parse(lookUpEdit2.EditValue.ToString());
            try
            {
                if (s1!=0&&s2!=0)
                {
                    DialogResult dialogResult = MessageBox.Show("Cari Ekleme İşlemini Onaylıyormusnuz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult==DialogResult.Yes)
                    {
                        TBLCARI t = new TBLCARI();
                        t.AD = txtad.Text;
                        t.SOYAD = txtsoyad.Text;
                        t.TELEFON = txttelefon.Text;
                        t.MAIL = txtmail.Text;
                        t.IL = lookUpEdit1.Text;
                        t.ILCE = lookUpEdit2.Text;
                        t.BANKA = txtbanka.Text;
                        t.VERGIDAIRESI = txtvergidairesi.Text;
                        t.VERGINO = txtvergino.Text;
                        t.STATU = txtstatü.Text;
                        t.ADRES = txtadres.Text;
                        t.DURUM = true;
                        db.TBLCARI.Add(t);
                        db.SaveChanges(); MessageBox.Show("Cari Kaydedilmiştir","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ürün Kaydedilmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

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
    }
}
