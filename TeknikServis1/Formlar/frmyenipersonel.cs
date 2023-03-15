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
    public partial class frmyenipersonel : Form
    {
        public frmyenipersonel()
        {
            InitializeComponent();
        }
        DbTeknikServısEntities db = new DbTeknikServısEntities();
        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        frmpersonellistesi fr = new frmpersonellistesi();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Personel Ekleme İşlemin Onaylıyormusnuz ?", "ONAY", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    TBLPERSONEL personel = new TBLPERSONEL();
                    personel.AD = txtAd.Text;
                    personel.SOYAD = txtsoyad.Text;
                    personel.DEPARTMAN = Convert.ToByte(lkpdtdepartman.EditValue);
                    personel.FOTOGRAF = txtfoto.Text;
                    personel.MAIL = txtmail.Text;
                    personel.TELEFON = txttel.Text;
                    personel.durum = true;
                    db.TBLPERSONEL.Add(personel);
                    db.SaveChanges();
                    MessageBox.Show("Personel Eklenmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Personel Ekleme İşlemi Gerçekleşemiştir !!!", "Onay Eksikliği", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Personel Ekleme İşlemi Gerçekleşemiştir !!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void frmyenipersonel_Load(object sender, EventArgs e)
        {
            var deger = from x in db.TBLDEPARTMAN
                        where x.durum == true 
                        select new
                        {
                            x.ID,
                            x.AD
                        };
            lkpdtdepartman.Properties.DataSource = deger.ToList();
        }
    }
}
