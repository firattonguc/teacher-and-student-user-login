using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace okulöğrenciöğretmensistemi
{
    public partial class frmogretmen : Form
    {
        public frmogretmen()
        {
            InitializeComponent();
        }

        private void btnkulüpislem_Click(object sender, EventArgs e)
        {
            kulup fr=new kulup();
            fr.Show();
        }

        private void btndersislem_Click(object sender, EventArgs e)
        {
            Frmdersler fr=new Frmdersler();
            fr.Show();
        }

        private void btnogrenci_Click(object sender, EventArgs e)
        {
            Frmogrenci fr=new Frmogrenci();
            fr.Show();
        }

        private void btnsınavnot_Click(object sender, EventArgs e)
        {
            Frmsınavnotlar fr=new Frmsınavnotlar();
            fr.Show();
        }
    }
}
