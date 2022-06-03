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

namespace _26042022_KutuphaneOtomasyonu
{
    public partial class uyelistele : Form
    {
        public uyelistele()
        {
            InitializeComponent();
        }
        SqlConnection sql = new SqlConnection("Data Source=DESKTOP-BJ4EMC1\\SQLEXPRESS;Initial Catalog=kutuphan;Integrated Security=True");

        private void EmanetListele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from uyeler", sql);
            DataSet ds = new DataSet();
            sql.Open();
            da.Fill(ds);
            sql.Close();
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from uyeler",sql);
            DataSet ds = new DataSet();
            sql.Open();
            da.Fill(ds);
            sql.Close();
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand sqll = new SqlCommand("delete from uyeler where Tc=@s1",sql);
            sqll.Parameters.AddWithValue("@s1", textBox1.Text);
            sql.Open();
            sqll.ExecuteNonQuery();
            sql.Close();
            MessageBox.Show("Kütüphanemizden Ayrıldığınız İçin Üzgünüz:(");
            EmanetListele();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 uyelistele = new Form1();
            uyelistele.Show();
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void uyelistele_Load(object sender, EventArgs e)
        {
            EmanetListele();
        }
    }
}
