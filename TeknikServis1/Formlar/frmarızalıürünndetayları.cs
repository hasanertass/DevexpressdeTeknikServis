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
    public partial class frmarızalıürünndetayları : Form
    {
        public frmarızalıürünndetayları()
        {
            InitializeComponent();
        }

        private void frmarızalıürünndetayları_Load(object sender, EventArgs e)
        {
            DbTeknikServısEntities db = new DbTeknikServısEntities();
            gridControl1.DataSource = (from x in db.TBLURUNTAKIP
                                      select new
                                      {
                                          x.TAKIPID,
                                          x.SERINO,
                                          x.TARİH,
                                          x.ACIKLAMA
                                      }).ToList();
        }
    }
}
