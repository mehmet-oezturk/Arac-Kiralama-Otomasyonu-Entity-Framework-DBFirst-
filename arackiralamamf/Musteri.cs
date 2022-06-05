using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arackiralamamf
{
    public partial class Musteri : Form
    {
        public Musteri()
        {
            InitializeComponent();
        }
        AracKiralama1Container baglanti = new AracKiralama1Container();
        public void listele()
        {
            dataGridView1.DataSource = baglanti.Musteriler1.ToList();
            dataGridView1.Visible = true;
        }
        private void Musteri_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Musteriler m = new Musteriler();

            m.MusteriAdSoyad = textBox1.Text;
            m.Telefon = maskedTextBox2.Text;
            m.TcNo = textBox3.Text;
            m.EhliyetDurumu = comboBox1.Text;
            m.Adres = textBox5.Text;
            baglanti.Musteriler1.Add(m);
            baglanti.SaveChanges();
            listele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            menu git = new menu();
            git.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow s = dataGridView1.CurrentRow;
            textBox1.Tag = s.Cells[0].Value.ToString();
            textBox1.Text = s.Cells[1].Value.ToString();
            maskedTextBox2.Text = s.Cells[2].Value.ToString();
            textBox3.Text = s.Cells[3].Value.ToString();
            comboBox1.Text = s.Cells[4].Value.ToString();
            textBox5.Text = s.Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int gm = Convert.ToInt32(textBox1.Tag);
            var m = baglanti.Musteriler1.Where(x => x.Id == gm).SingleOrDefault();
            m.MusteriAdSoyad = textBox1.Text;
            m.Telefon = maskedTextBox2.Text;
            m.TcNo = textBox3.Text;
            m.EhliyetDurumu = comboBox1.Text;
            m.Adres = textBox5.Text;
            baglanti.SaveChanges();
           
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int gm = Convert.ToInt32(textBox1.Tag);
            var m = baglanti.Musteriler1.Where(x => x.Id == gm).FirstOrDefault();
            baglanti.Musteriler1.Remove(m);
            baglanti.SaveChanges();

            listele();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.Musteriler1.Where(x => x.MusteriAdSoyad.ToLower().Contains(textBox1.Text) || x.MusteriAdSoyad.ToUpper().Contains(textBox1.Text)).ToList();
            dataGridView1.Visible = true;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Rapor git = new Rapor();
            git.Show();
            this.Hide();
        }
    }
}
