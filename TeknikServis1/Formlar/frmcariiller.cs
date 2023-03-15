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
    public partial class frmcariiller : Form
    {
        public frmcariiller()
        {
            InitializeComponent();
        }
        DbTeknikServısEntities db = new DbTeknikServısEntities();

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-025R33B\\SQLEXPRESS;Initial Catalog=DbTeknikServıs;Integrated Security=True");
        private void frmcariiller_Load(object sender, EventArgs e)
        {
            //chartControl1.Series["Series 1"].Points.AddPoint("İstanbul", 50);
            //chartControl1.Series["Series 1"].Points.AddPoint("Bursa", 35);
            //chartControl1.Series["Series 1"].Points.AddPoint("Ankara", 20);
            //chartControl1.Series["Series 1"].Points.AddPoint("Balıkesir", 10);
            //chartControl1.Series["Series 1"].Points.AddPoint("izmir", 40);
            //chartControl1.Series["Series 1"].Points.AddPoint("çanakkale", 30);


            // GRİDE İLLERE GÖRE VERİ ÇEKME 
            gridControl1.DataSource = db.TBLCARI.OrderBy(x => x.IL).
                GroupBy(y => y.IL).
                Select(z => new { İL = z.Key, TOPLAM = z.Count() }).ToList();



            // GRAFİĞE VERİ TABANINDAN VERİ ÇEKME
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select IL,count(*) from tblcarı group by IL",baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();
        }
    }
}
