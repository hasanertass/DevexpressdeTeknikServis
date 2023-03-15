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
    public partial class frmNotlar : Form
    {
        public frmNotlar()
        {
            InitializeComponent();
        }
        DbTeknikServısEntities db = new DbTeknikServısEntities();
        
        private void frmNotlar_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == false).ToList();
            gridControl2.DataSource = db.TBLNOTLARIM.Where(y => y.DURUM == true).ToList();
        }
        TBLNOTLARIM not = new TBLNOTLARIM();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                not.BASLIK = txtad.Text;
                not.IÇERIK = textEdit1.Text;
                not.DURUM = false;
                db.TBLNOTLARIM.Add(not);
                db.SaveChanges();
                MessageBox.Show("Not Kaydedilmiştir. ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Not Kaydedilemedi !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == false).ToList();
            gridControl2.DataSource = db.TBLNOTLARIM.Where(y => y.DURUM == true).ToList();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtıd.Text);
            var deger = db.TBLNOTLARIM.Find(id);
            db.TBLNOTLARIM.Remove(deger);
            db.SaveChanges();
            checkEdit1.Checked = false;
            MessageBox.Show("Not Silinmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtıd.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtad.Text = gridView1.GetFocusedRowCellValue("BASLIK").ToString();
            textEdit1.Text = gridView1.GetFocusedRowCellValue("IÇERIK").ToString();
            checkEdit1.Checked = false;
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtıd.Text = gridView2.GetFocusedRowCellValue("ID").ToString();
            txtad.Text = gridView2.GetFocusedRowCellValue("BASLIK").ToString();
            textEdit1.Text = gridView2.GetFocusedRowCellValue("IÇERIK").ToString();
            checkEdit1.Checked = true;
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtıd.Text);
            var deger = db.TBLNOTLARIM.Find(id);
            deger.BASLIK = txtad.Text;
            deger.IÇERIK = textEdit1.Text;
            if (checkEdit1.Checked==true)
            {
                deger.DURUM = true;
            }
            else
            {
                deger.DURUM = false;
            }
            db.SaveChanges();
            MessageBox.Show("Not Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
