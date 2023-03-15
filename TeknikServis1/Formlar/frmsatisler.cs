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
    public partial class frmsatisler : Form
    {
        public frmsatisler()
        {
            InitializeComponent();
        }
        DbTeknikServısEntities db = new DbTeknikServısEntities();
        private void frmsatisler_Load(object sender, EventArgs e)
        {
            var deger = from x in db.TBLURUNHAREKET
                        select new
                        {
                            x.HAREKETID,
                            x.TBLURUN.AD,
                            MUSTERI = x.TBLCARI.AD +" "+ x.TBLCARI.SOYAD,
                            PERSPNEL = x.TBLPERSONEL.AD +" "+ x.TBLPERSONEL.SOYAD,
                            x.TARIH,
                            x.ADET,
                            x.FIYAT,
                            x.URUNSERINO
                        };
            gridControl1.DataSource = deger.ToList();
        }
    }
}
