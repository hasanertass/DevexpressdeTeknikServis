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
    public partial class frmMarkalar : Form
    {
        public frmMarkalar()
        {
            InitializeComponent();
        }
        DbTeknikServısEntities db = new DbTeknikServısEntities();
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-025R33B\\SQLEXPRESS;Initial Catalog=DbTeknikServıs;Integrated Security=True");
        private void frmMarkalar_Load(object sender, EventArgs e)
        {
            var deger = db.TBLURUN.OrderBy(x => x.MARKA).GroupBy(y => y.MARKA).Select(z => new
            {
                Marka = z.Key,
                Toplam=z.Count()
            }).OrderByDescending(z=>z.Toplam);
            gridControl1.DataSource = deger.ToList();


            // toplam ürün sayısını çekme
            labelControl2.Text = db.TBLURUN.Count().ToString();
            // toplam marka sayısı çekme
            labelControl3.Text = (from x in db.TBLURUN
                                  select x.MARKA).Distinct().Count().ToString();
            // en yüksek fiyatlı marka çekme
            labelControl7.Text = (from x in db.TBLURUN
                                  orderby x.SATISFIYAT descending
                                  select x.MARKA).FirstOrDefault().ToString();
            // en fazla ürünü olan marka çekme
            labelControl5.Text = deger.Select(x=>x.Marka).FirstOrDefault().ToString();

            // chart grafiğine manuel olarak veri girişi 
            ////chartControl1.Series["Series 1"].Points.AddPoint("Monster", 25);
            ////chartControl1.Series["Series 1"].Points.AddPoint("Beko", 20);
            ////chartControl1.Series["Series 1"].Points.AddPoint("Arçelik", 10);
            ////chartControl1.Series["Series 1"].Points.AddPoint("Lenovo", 40);
            ////chartControl1.Series["Series 1"].Points.AddPoint("Sıemens", 50);



            ////chartControl2.Series["Kategoriler"].Points.AddPoint("Beyaz Eşya", 10);
            ////chartControl2.Series["Kategoriler"].Points.AddPoint("Bilgisayar", 15);
            ////chartControl2.Series["Kategoriler"].Points.AddPoint("TV", 5);
            ////chartControl2.Series["Kategoriler"].Points.AddPoint("Telefon", 3);
            ////chartControl2.Series["Kategoriler"].Points.AddPoint("Küçük Ev Aletleri", 16);
            ////chartControl2.Series["Kategoriler"].Points.AddPoint("Tablet", 7);
            ////chartControl2.Series["Kategoriler"].Points.AddPoint("Mobilya",9);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select MARKA,Count(*) from TBLURUN group by MARKA",baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), Convert.ToInt32(dr[1]));
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut1 = new SqlCommand(" select k.AD,Count(*) from TBLURUN as u " +
                                               " inner join TBLKATEGORI as k " +
                                               " on u.KATEGORI = k.ID" +
                                               " GROUP BY  k.AD", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                chartControl2.Series["Kategoriler"].Points.AddPoint(Convert.ToString(dr1[0]), Convert.ToInt32(dr1[1]));
            }
            baglanti.Close();
        }


    }
}
