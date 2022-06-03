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
    public partial class KitapEkle : Form
    {
        public KitapEkle()
        {
            InitializeComponent();
        }
        SqlConnection sql = new SqlConnection("Data Source=DESKTOP-BJ4EMC1\\SQLEXPRESS;Initial Catalog=kutuphan;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand sqll = new SqlCommand("insert into kitaplar values(@s1,@s2,@s3,@s4,@s5,@s6)", sql);
            sqll.Parameters.AddWithValue("@s1", textBox1.Text);
            sqll.Parameters.AddWithValue("@s2", textBox2.Text);
            sqll.Parameters.AddWithValue("@s3", textBox3.Text);
            sqll.Parameters.AddWithValue("@s4", textBox4.Text);
            sqll.Parameters.AddWithValue("@s5", textBox5.Text);
            sqll.Parameters.AddWithValue("@s6", textBox6.Text);
            sql.Open();
            sqll.ExecuteNonQuery();
            sql.Close();
            MessageBox.Show("Başarılı Kitap Girişi");

            Form1 listele = new Form1();
            listele.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form1 uyelistele = new Form1();
            uyelistele.Show();
            this.Hide();
        }
    }
}
