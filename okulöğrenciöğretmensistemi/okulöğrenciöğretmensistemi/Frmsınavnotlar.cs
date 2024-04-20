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
    public partial class Frmsınavnotlar : Form
    {
        public Frmsınavnotlar()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.tbl_notlarTableAdapter ds= new DataSet1TableAdapters.tbl_notlarTableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-OEOQ425\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True;Encrypt=False");
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.notlistesi(int.Parse(txtıd.Text));
        }

        private void Frmsınavnotlar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select*from tbl_dersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "dersad";
            comboBox1.ValueMember = "dersıd";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }
        int notıd;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           notıd=int.Parse( dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtıd.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtsınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtsınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtproje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtort.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtdurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        int sınav1, sınav2, sınav3, proje;
        double ortalama;
        private void btnhesapla_Click(object sender, EventArgs e)
        {
            
            string durum;
            sınav1=Convert.ToInt16(txtsınav1.Text);
            sınav2= Convert.ToInt16(txtsınav2.Text);
            sınav3 = Convert.ToInt16(txtsınav3.Text);
            proje = Convert.ToInt16(txtproje.Text);
            ortalama=(sınav1+sınav2+sınav3+proje)/4;
            txtort.Text=ortalama.ToString();
            if (ortalama >= 50)
            {
                txtdurum.Text = "true";
            }
            else 
                    {
                txtdurum.Text = "false";
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            ds.norguncelle(byte.Parse(comboBox1.SelectedValue.ToString()), int.Parse(txtıd.Text),byte.Parse(txtsınav1.Text), byte.Parse(txtsınav2.Text) , byte.Parse(txtsınav3.Text), byte.Parse(txtproje.Text), decimal.Parse(txtort.Text), bool.Parse(txtdurum.Text),notıd);
        }
    }
}
