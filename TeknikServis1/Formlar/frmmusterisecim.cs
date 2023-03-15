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
    public partial class frmmusterisecim : Form
    {
        public frmmusterisecim()
        {
            InitializeComponent();
        }
        DbTeknikServısEntities db = new DbTeknikServısEntities();
        public int sayı;
        void musteri()
        {
            var deger = from x in db.TBLCARI
                        where x.DURUM == true
                        select new
                        {
                            x.ID,
                            x.AD,
                            x.SOYAD,
                            x.TELEFON,
                            x.MAIL,
                            x.IL,
                            x.ILCE,
                            x.BANKA,
                            x.VERGIDAIRESI,
                            x.VERGINO,
                            x.STATU,
                            x.ADRES
                        };
            dataGridView1.DataSource = deger.ToList();
        }
        void personel()
        {
            var deger = from x in db.TBLPERSONEL
                        where x.durum == true
                        select new
                        {
                            x.ID,
                            x.AD,
                            x.SOYAD,
                            DEPARTMAN = x.TBLDEPARTMAN.AD,
                            x.FOTOGRAF,
                            x.MAIL,
                            x.TELEFON
                        };
            dataGridView1.DataSource = deger.ToList();

        }
        void ürün()
        {
            var deger = from x in db.TBLURUN
                        where x.durum2 == true
                        select new
                        {
                            x.ID,
                            x.AD,
                            x.MARKA,
                            x.SATISFIYAT,
                            x.STOKSAYISI,
                            KATEGORİ = x.TBLKATEGORI.AD,
                            x.DURUM
                        };
            dataGridView1.DataSource = deger.ToList();

        }
        private void frmmusterisecim_Load(object sender, EventArgs e)
        {
            if (sayı == 1)
            {
                musteri();
            }
            else if (sayı==2)
            {
                ürün();
            }
            else
            {
                personel();
            }
        }
        public int ıd;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            ıd = int.Parse(dataGridView1.Rows[secilen].Cells[0].Value.ToString());
        }
    }
}
