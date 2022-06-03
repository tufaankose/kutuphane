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
    public partial class EmanetKitapL : Form
    {
        public EmanetKitapL()
        {
            InitializeComponent();
        }
        SqlConnection sql = new SqlConnection("Data Source=DESKTOP-BJ4EMC1\\SQLEXPRESS;Initial Catalog=kutuphan;Integrated Security=True");
        DataSet ds = new DataSet();
        private void EmanetKitapL_Load(object sender, EventArgs e)
        {
            EmanetListele();
            comboBox1.SelectedIndex = 0;
        }

        private void EmanetListele()
        {
            sql.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from emanetkitaplar", sql);
            adtr.Fill(ds, "EmanetKitaplar");
            dataGridView1.DataSource = ds.Tables[0];
            sql.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ds.Tables[0].Clear();
            if (comboBox1.SelectedIndex==0)
            {
                EmanetListele();
            }
            else if (comboBox1.SelectedIndex==1)
            {
                sql.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("select * from emanetkitaplar where '"+DateTime.Now.ToShortDateString()+"'>iadetarihi", sql);
                adtr.Fill(ds,"EmanetKitaplar");
                dataGridView1.DataSource = ds.Tables[0];
                sql.Close();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                sql.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("select * from emanetkitaplar where '" + DateTime.Now.ToShortDateString() + "'<=iadetarihi", sql);
                adtr.Fill(ds, "EmanetKitaplar");
                dataGridView1.DataSource = ds.Tables[0];
                sql.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 don = new Form1();
            don.Show();
            this.Hide();
        }
    }
}
