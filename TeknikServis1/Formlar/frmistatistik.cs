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
    public partial class frmistatistik : Form
    {
        public frmistatistik()
        {
            InitializeComponent();
        }
        DbTeknikServısEntities db = new DbTeknikServısEntities();
        private void frmistatistik_Load(object sender, EventArgs e)
        {
            //kritik seviye 
            labelControl7.Text = "10";
            // toplam ürün sayısı çekme
            labelControl2.Text = db.TBLURUN.Count().ToString();

            // toplam kategori ürün sayısı çekme
            labelControl3.Text = db.TBLKATEGORI.Count().ToString();

            // toplam stok sayısı çekme
            labelControl5.Text = db.TBLURUN.Sum(x => x.STOKSAYISI).ToString();

            //en fazla stoklu ürünü çekme
            labelControl19.Text = (from x in db.TBLURUN
                                   orderby x.STOKSAYISI descending
                                   select x.AD).FirstOrDefault();
            labelControl41.Text = (from x in db.TBLURUN
                                   orderby x.STOKSAYISI descending      // ürünün markası ile birlik te çekme
                                   select x.MARKA).FirstOrDefault();
            //en az stoklu ürün çekme
            labelControl17.Text = (from x in db.TBLURUN
                                   orderby x.STOKSAYISI ascending
                                   select x.AD).FirstOrDefault();

            labelControl42.Text = (from x in db.TBLURUN
                                   orderby x.STOKSAYISI ascending       // ürünün markasını bulma
                                   select x.MARKA).FirstOrDefault();
            //en yüksek fiyatlı ürün çekme
            labelControl13.Text = (from x in db.TBLURUN
                                   orderby x.SATISFIYAT descending
                                   select x.AD).FirstOrDefault();
            labelControl43.Text = (from x in db.TBLURUN
                                   orderby x.SATISFIYAT descending      // ürünün markasını bulma
                                   select x.MARKA).FirstOrDefault();
            // en düşük fiyatlı ürün çekme
            labelControl11.Text = (from x in db.TBLURUN
                                   orderby x.SATISFIYAT ascending
                                   select x.AD).FirstOrDefault();
            labelControl44.Text = (from x in db.TBLURUN
                                   orderby x.SATISFIYAT ascending       // ürünün markasını bulma
                                   select x.MARKA).FirstOrDefault();
            // beyaz eşya stok sayısı çekme
            labelControl25.Text = db.TBLURUN.Where(x => x.KATEGORI == 4).Sum(x => x.STOKSAYISI).ToString();
            // laptop stok sayısı çekme
            labelControl27.Text = db.TBLURUN.Where(x => x.KATEGORI == 1).Sum(x => x.STOKSAYISI).ToString();
            //küçük ev aleti stok sayısı çekme
            labelControl29.Text = db.TBLURUN.Where(x => x.KATEGORI == 3).Sum(x => x.STOKSAYISI).ToString();
            // toplam marka sayısını çekme
            labelControl39.Text = (from x in db.TBLURUN
                                   select x.MARKA).Distinct().Count().ToString();

            // en fazla ürünü olan marka 
            var deger = db.TBLURUN.OrderBy(x => x.MARKA).GroupBy(y => y.MARKA).Select(z => new
            {
                Marka = z.Key,
                Toplam = z.Count()
            }).OrderByDescending(z=>z.Toplam);
            labelControl37.Text = deger.Select(a => a.Marka).FirstOrDefault().ToString();
            
        }
    }
}
