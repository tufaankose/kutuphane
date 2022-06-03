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
    public partial class Kitapİade : Form
    {
        public Kitapİade()
        {
            InitializeComponent();
        }
        SqlConnection sql = new SqlConnection("Data Source=DESKTOP-BJ4EMC1\\SQLEXPRESS;Initial Catalog=kutuphan;Integrated Security=True");
        DataSet ds = new DataSet();
        private void Kitapİade_Load(object sender, EventArgs e)
        {
            EmanetListele();
        }
        private void EmanetListele()
        {
            sql.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from emanetkitaplar", sql);
            adtr.Fill(ds, "EmanetKitaplar");
            dataGridView1.DataSource = ds.Tables[0];
            sql.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 don = new Form1();
            don.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ds.Tables[0].Clear();
            sql.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from emanetkitaplar where tc like '%" + textBox1.Text + "%'", sql);
            da.Fill(ds, "EmanetKitaplar");
            sql.Close();
            if (textBox1.Text=="")
            {
                ds.Tables[0].Clear();
                EmanetListele();
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ds.Tables[0].Clear();
            sql.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from emanetkitaplar where barkodNo like '%" + textBox2.Text + "%'", sql);
            da.Fill(ds, "EmanetKitaplar");
            sql.Close();
            if (textBox2.Text == "")
            {
                ds.Tables[0].Clear();
                EmanetListele();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand sqll = new SqlCommand("delete from emanetkitaplar where tc=@tc and barkodno=@barkodno ", sql);
            sqll.Parameters.AddWithValue("@tc", dataGridView1.CurrentRow.Cells["tc"].Value.ToString());
            sqll.Parameters.AddWithValue("@barkodno", dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString());
            sqll.ExecuteNonQuery();
            MessageBox.Show("Kitaplar İade Edildi");


            sql.Close();
            ds.Tables[0].Clear();
            EmanetListele();
        }
    }
}
