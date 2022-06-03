using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _26042022_KutuphaneOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Kitapİade ki = new Kitapİade();
            ki.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uekle uekle = new uekle();
            uekle.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uyelistele uyelistele = new uyelistele();
            uyelistele.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KitapEkle ekle = new KitapEkle();
            ekle.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            KitapListele listele = new KitapListele();
            listele.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EmanetKitapVerme emanet = new EmanetKitapVerme();
            emanet.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EmanetKitapL emanet = new EmanetKitapL();
            emanet.Show();
            this.Hide();
        }
    }
}
