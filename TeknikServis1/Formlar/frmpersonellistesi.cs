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
    public partial class frmpersonellistesi : Form
    {
        public frmpersonellistesi()
        {
            InitializeComponent();
        }
        DbTeknikServısEntities db = new DbTeknikServısEntities();
        TBLPERSONEL personel = new TBLPERSONEL();
        void listeleme()
        {
            var deger = from x in db.TBLPERSONEL
                        where x.durum == true
                        select new
                        {
                            x.ID,
                            x.AD,
                            x.SOYAD,
                            Departman=x.TBLDEPARTMAN.AD,
                            x.FOTOGRAF,
                            x.MAIL,
                            x.TELEFON
                        };
            gridControl1.DataSource = deger.ToList();
        }
        void grid(int per)
        {
            var deger = from x in db.TBLPERSONEL
                        where x.ID == per 
                        where x.durum == true
                        select new
                        {
                            x.AD,
                            x.SOYAD,
                            Departman = x.TBLDEPARTMAN.AD,
                            x.MAIL
                        };
            gridControl2.DataSource = deger.ToList();
        }
        void grid1(int per)
        {
            var deger = from x in db.TBLPERSONEL
                        where x.ID == per 
                        where x.durum == true
                        select new
                        {
                            x.AD,
                            x.SOYAD,
                            Departman = x.TBLDEPARTMAN.AD,
                            x.MAIL
                        };
            gridControl3.DataSource = deger.ToList();
        }
        void grid2(int per)
        {
            var deger = from x in db.TBLPERSONEL
                        where x.ID == per
                        where x.durum == true
                        select new
                        {
                            x.AD,
                            x.SOYAD,
                            Departman = x.TBLDEPARTMAN.AD,
                            x.MAIL
                        };
            gridControl4.DataSource = deger.ToList();
        }
        void grid3(int per)
        {
            var deger = from x in db.TBLPERSONEL
                        where x.ID == per
                        where x .durum == true
                        select new
                        {
                            x.AD,
                            x.SOYAD,
                            Departman = x.TBLDEPARTMAN.AD,
                            x.MAIL
                        };
            gridControl5.DataSource = deger.ToList();
        }
        void lookup()
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
        private void frmpersonellistesi_Load(object sender, EventArgs e)
        {
            listeleme();
            timer1.Start();
            lookup();

        }
        int sayı = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            int personel = db.TBLPERSONEL.Count();
            //sayac++;
            ////labelControl19.Text = sayac.ToString();
            //if (sayac%4==0)
            //{
            //    sayı++;
            //    grid(sayı);
            //    grid1(sayı + 1);
            //    grid2(sayı + 2);    
            //    grid3(sayı + 3);

            //    sayı += 3;
            //    if (sayı+1>personel)
            //    {
            //        sayı = 0;
            //    }
            //}
            timer1.Enabled = false;
            sayı++;
            grid(sayı);
            grid1(sayı + 1);
            grid2(sayı + 2);
            grid3(sayı + 3);
            sayı += 3;
            if (sayı + 1 > personel)
            {
                sayı = 0;
            }
            timer1.Enabled = true;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Personel Ekleme İşlemini Onaylıyormusnuz ?", "ONAY", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    personel.AD = txtad.Text;
                    personel.SOYAD = txtsoyad.Text;
                    personel.DEPARTMAN = Convert.ToByte(lkpdtdepartman.EditValue);
                    personel.FOTOGRAF = txtfoto.Text;
                    personel.MAIL = txtmail.Text;
                    personel.TELEFON = txttel.Text;
                    personel.durum = true;
                    db.TBLPERSONEL.Add(personel);
                    db.SaveChanges();
                    MessageBox.Show("Yeni Personel eklenmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Personel Ekleme İşlemi Yapılamamıştır.", "Onay Eksikliği", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Personel Ekleme İşlemi Yapılamamıştır.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listeleme();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Personel Silme İşlemini Onaylıyormusnuz ?", "ONAY", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(txtıd.Text);
                    var deger = db.TBLPERSONEL.Find(id);
                    deger.durum = false;
                    db.SaveChanges();
                    MessageBox.Show("Personel Silinmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Personel Silme İşlemi Gerçekleşmedi !!!", "Onay Eksikliği", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Personel Silme İşlemi Gerçekleşmedi !!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Geçerli Personelin Bilgilerinin Güncellenmesini \n Onaylıyormusnuz ?", "ONAY", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    personel.AD = txtad.Text;
                    personel.SOYAD = txtsoyad.Text;
                    personel.DEPARTMAN = Convert.ToByte(lkpdtdepartman.EditValue);
                    personel.FOTOGRAF = txtfoto.Text;
                    personel.MAIL = txtmail.Text;
                    personel.TELEFON = txttel.Text;
                    personel.durum = true;
                    db.SaveChanges();
                    MessageBox.Show("Geçerli Personelin Bilgileri Güncellenmiştir.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Geçerli Personelin Bilgileri Güncellenememiştir !!!", "Onay Eksikliği", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Personel Bilgileri GÜNCELLENEMEMİŞTİR !!!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtıd.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtad.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            txtsoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
            txtfoto.Text = gridView1.GetFocusedRowCellValue("FOTOGRAF").ToString();
            txtmail.Text = gridView1.GetFocusedRowCellValue("MAIL").ToString();
            txttel.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();
        }
    }
}
