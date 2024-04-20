using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace okulöğrenciöğretmensistemi
{
    public partial class Frmogrenci : Form
    {
        public Frmogrenci()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-OEOQ425\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True;Encrypt=False");
        private void Frmogrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ogrencilistesi();
            
        baglanti.Open();
            SqlCommand komut = new SqlCommand("select*from tbl_kulupler", baglanti);
            SqlDataAdapter da=new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "kulupad";
            comboBox1.ValueMember = "kulupıd";
            comboBox1.DataSource = dt;
            baglanti.Close();

        }
        string c = "";
        private void btnekle_Click(object sender, EventArgs e)
        {
            
            
            ds.ogrenciekle(txtad.Text,txtsoyad.Text,byte.Parse(comboBox1.SelectedValue.ToString()),c);
        MessageBox.Show("ekleme yapıldı");
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.ogrencilistesi();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtıd.Text=comboBox1.SelectedValue.ToString();
        }

        private void btnsıl_Click(object sender, EventArgs e)
        {
            ds.ogrencisıl(int.Parse(txtıd.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtıd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            ds.ogrencıguncelle(txtad.Text,txtsoyad.Text,byte.Parse(comboBox1.SelectedValue.ToString()),c,int.Parse(txtıd.Text));
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "kız";
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
            if (radioButton2.Checked == true)
            {
                c = "erkek";
            }
        }
    }
}
