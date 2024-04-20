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
    public partial class Frmdersler : Form
    {
        public Frmdersler()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.tbl_derslerTableAdapter ds = new DataSet1TableAdapters.tbl_derslerTableAdapter();
        private void Frmdersler_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(txtdersad.Text);
            MessageBox.Show("ders ekleme işlemi yapıldı");
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=ds.DersListesi();
        }

        private void btnsıl_Click(object sender, EventArgs e)
        {
            ds.Derssil( byte.Parse(txtdersıd.Text) );
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            ds.Dersgüncelle(txtdersad.Text,byte.Parse(txtdersıd.Text) );
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtdersıd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtdersad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
