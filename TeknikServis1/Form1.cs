using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnürünlistesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmÜrünListesi fr = new Formlar.FrmÜrünListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnyeniürün_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmYeniÜrün fr = new Formlar.frmYeniÜrün();
            fr.Show();
        }

        private void btnkategorilistesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmkategorilistesi fr = new Formlar.frmkategorilistesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnyenikategori_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmyenikategori fr = new Formlar.frmyenikategori();
            fr.Show();
        }

        private void btnistatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmistatistik fr = new Formlar.frmistatistik();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnmarkalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmMarkalar fr = new Formlar.frmMarkalar();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btncarilistesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmcarrilistesi fr = new Formlar.frmcarrilistesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btncariiller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmcariiller fr = new Formlar.frmcariiller();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnyenicari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmyenicari fr = new Formlar.frmyenicari();
            fr.Show();
        }

        private void btndepartmanListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmDepartmanListesi fr = new Formlar.frmDepartmanListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnyenideprtman_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmYeni_Departman fr = new Formlar.frmYeni_Departman();
            fr.Show();
        }

        private void btnpersonel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmpersonellistesi fr = new Formlar.frmpersonellistesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnyenipersonel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmyenipersonel fr = new Formlar.frmyenipersonel();
            fr.Show();
        }

        private void btnhesapmakinesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void btndövizkurları_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmkurlar fr = new Formlar.frmkurlar();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnword_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        private void btnexcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("excel");

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.frmyoutube fr = new Formlar.frmyoutube();
            fr.MdiParent = this;
            fr.Show();
        }
        private void btnhaberler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem28_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.frmNotlar fr = new Formlar.frmNotlar();
            fr.MdiParent = this;
            fr.Show();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.frmArızaListesi fr = new Formlar.frmArızaListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnyenısatıs_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.FrmUrunSatıs fr = new Formlar.FrmUrunSatıs();
            fr.Show();
        }

        private void frmsatislistesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.frmsatisler fr = new Formlar.frmsatisler();
            fr.MdiParent=this;
            fr.Show();
        }

        private void btnyeniarizalıürün_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.FrmYeniArızalıÜrün fr = new Formlar.FrmYeniArızalıÜrün();
            fr.Show();
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.FrmArizaDetay fr = new Formlar.FrmArizaDetay();
            fr.Show();
        }

        private void btnarızalıüründetayları_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.frmarızalıürünndetayları fr = new Formlar.frmarızalıürünndetayları();
            fr.MdiParent = this;
            fr.Show();
        }

        private void btnqrolustur_ItemClick(object sender, ItemClickEventArgs e)
        {
            Formlar.FrmQRCode fr = new Formlar.FrmQRCode();
            fr.Show();
        }

        private void barButtonItem34_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem31_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
