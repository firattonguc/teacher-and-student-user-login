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
    public partial class frmogrencinotlar : Form
    {
        public frmogrencinotlar()
        {
            InitializeComponent();
        }
        
        SqlConnection baglanti=new SqlConnection(@"Data Source=DESKTOP-OEOQ425\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True;Encrypt=False");
        public string numara;
        private void frmogrencinotlar_Load(object sender, EventArgs e)
        {
            
            
            SqlCommand komut = new SqlCommand("select dersad,sınav1,sınav2,sınav3,proje,ortalama,durum from tbl_notlar\r\nINNER JOIN tbl_dersler on tbl_notlar.dersıd=tbl_dersler.dersıd where ogrıd=1", baglanti);

            
            komut.Parameters.AddWithValue("@p1", numara);

           
            SqlDataAdapter da = new SqlDataAdapter(komut);

            
            DataTable dt = new DataTable();

            
            da.Fill(dt);

            
            dataGridView1.DataSource = dt;

        }
    }
}
