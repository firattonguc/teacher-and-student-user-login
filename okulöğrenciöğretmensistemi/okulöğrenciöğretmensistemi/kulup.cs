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
namespace okulöğrenciöğretmensistemi
{
    public partial class kulup : Form
    {
        public kulup()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-OEOQ425\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True;Encrypt=False");
        public void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_kulupler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void kulup_Load(object sender, EventArgs e)
        {
            listele();

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO tbl_kulupler(kulupad) VALUES(@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtkulupad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp listeye eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtkulupıd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtkulupad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void btnsıl_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from tbl_kulupler where kulupıd=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", txtkulupıd.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("kulüp silindi");
            listele();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut=new SqlCommand("update tbl_kulupler set kulupad=@p1 where kulupıd=@p2",baglanti);
            komut.Parameters.AddWithValue("@p1",txtkulupad.Text);
            komut.Parameters.AddWithValue("@p2", txtkulupıd.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("kulüp güncellendi");
            listele();
        }
    }
}
