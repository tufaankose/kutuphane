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
    public partial class EmanetKitapVerme : Form
    {
        public EmanetKitapVerme()
        {
            InitializeComponent();
        }
        SqlConnection sql = new SqlConnection("Data Source=DESKTOP-BJ4EMC1\\SQLEXPRESS;Initial Catalog=kutuphan;Integrated Security=True");

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 don = new Form1();
            don.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand sqll = new SqlCommand("insert into sepet values(@s1,@s2,@s3,@s4,@s5,@s6,@s7,@s8)", sql);
            sqll.Parameters.AddWithValue("@s1", textBox5.Text);
            sqll.Parameters.AddWithValue("@s2", textBox6.Text);
            sqll.Parameters.AddWithValue("@s3", textBox7.Text);
            sqll.Parameters.AddWithValue("@s4", textBox8.Text);
            sqll.Parameters.AddWithValue("@s5", textBox9.Text);
            sqll.Parameters.AddWithValue("@s6", textBox10.Text);
            sqll.Parameters.AddWithValue("@s7", dateTimePicker1.Text);
            sqll.Parameters.AddWithValue("@s8", dateTimePicker2.Text);
            sql.Open();
            sqll.ExecuteNonQuery();
            sql.Close();
            MessageBox.Show("Başarılı Bir Şekilde Sepete Eklendi ");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlCommand sqll = new SqlCommand("select * from uyeler where tc='" + textBox1.Text + "'", sql);
            sql.Open();
            SqlDataReader read = sqll.ExecuteReader();
            while (read.Read())
            {
                textBox2.Text = read["Ad Soyad"].ToString();
                textBox3.Text = read["Yaş"].ToString();
                textBox4.Text = read["Telefon"].ToString();

            }
            sql.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from kitaplar where Barkod like'" + textBox5.Text + "' ", sql);
            sql.Open();
            SqlDataReader read = komut.ExecuteReader();

            while (read.Read())
            {
                textBox6.Text = read["KitapAd"].ToString();
                textBox7.Text = read["Yazar"].ToString();
                textBox8.Text = read["YayınEvi"].ToString();
                textBox9.Text = read["Sayfa"].ToString();
            }
            sql.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand sqll = new SqlCommand("delete from sepet where BarkodNo='" + dataGridView1.CurrentRow.Cells["BarkodNo"] + "'", sql);

            sql.Open();
            sqll.ExecuteNonQuery();
            sql.Close();
            MessageBox.Show("Başarıyla Silindi ");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                SqlCommand sqll = new SqlCommand("insert into EmanetKitaplar(tc,AdSoyad,Yaş,Telefon,BarkodNo,KitapAdi,Yazar,YayinEvi,SayfaSayisi,KitapSayisi,TeslimatTarihi,iadetarihi) values(@tc,@AdSoyad,@Yaş,@Telefon,@BarkodNo,@KitapAdi,@Yazar,@YayinEvi,@SayfaSayisi,@KitapSayisi,@TeslimatTarihi,@iadetarihi)", sql);
                sqll.Parameters.AddWithValue("@tc", textBox1.Text);
                sqll.Parameters.AddWithValue("@AdSoyad", textBox2.Text);
                sqll.Parameters.AddWithValue("@Yaş", textBox3.Text);
                sqll.Parameters.AddWithValue("@Telefon", textBox4.Text);
                sqll.Parameters.AddWithValue("@BarkodNo", dataGridView1.Rows[i].Cells["BarkodNo"].Value.ToString());
                sqll.Parameters.AddWithValue("@KitapAdi", textBox6.Text);
                sqll.Parameters.AddWithValue("Yazar", dataGridView1.Rows[i].Cells["Yazar"].Value.ToString());
                sqll.Parameters.AddWithValue("YayinEvi", dataGridView1.Rows[i].Cells["YayinEvi"].Value.ToString());
                sqll.Parameters.AddWithValue("SayfaSayisi", dataGridView1.Rows[i].Cells["SayfaSayisi"].Value.ToString());
                sqll.Parameters.AddWithValue("KitapSayisi", dataGridView1.Rows[i].Cells["KitapSayisi"].Value.ToString());
                sqll.Parameters.AddWithValue("TeslimatTarihi", dateTimePicker1.Text.ToString()); ;
                sqll.Parameters.AddWithValue("iadeTarihi", dateTimePicker2.Text.ToString()); ;
                sql.Open();
                sqll.ExecuteNonQuery();
                sql.Close();
                SqlCommand sqll2 = new SqlCommand("delete from sepet", sql);
                sql.Open();
                sqll2.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("Kitap(lar)emanet edildi");
                break;

            }
        }
        DataSet ds;
        private void button5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from sepet", sql);
            ds = new DataSet();
            sql.Open();
            da.Fill(ds);
            sql.Close();
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
