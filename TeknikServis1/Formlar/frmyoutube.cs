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
    public partial class frmyoutube : Form
    {
        public frmyoutube()
        {
            InitializeComponent();
        }

        private void frmyoutube_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.youtube.com");

        }
    }
}
