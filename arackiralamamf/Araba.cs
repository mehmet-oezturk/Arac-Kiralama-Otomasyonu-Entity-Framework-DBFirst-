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
    public partial class Araba : Form
    {
        public Araba()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            menu git = new menu();
            git.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Rapor git = new Rapor();
            git.Show();
            this.Hide();
        }
        AracKiralama1Container baglanti = new AracKiralama1Container();
        public void listele()
        {
            dataGridView3.DataSource = baglanti.Araclar1.ToList();
            dataGridView3.Visible = true;
        }
        private void Araba_Load(object sender, EventArgs e)
        {
            dataGridView3.Visible = false;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Araclar a = new Araclar();
            a.AracMarka = textBox10.Text;
            a.AracModel = textBox11.Text;
            a.AracOzellik = comboBox1.Text;
            a.AracBakımGunu = dateTimePicker2.Text;
            a.AracKm = Convert.ToInt32(textBox13.Text);
            a.Hgs = comboBox2.Text;
            a.GunlukTutar = Convert.ToDecimal(textBox14.Text);
            a.AracKiraDurumu = comboBox3.Text;
            baglanti.Araclar1.Add(a);
            baglanti.SaveChanges();
            listele();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow s = dataGridView3.CurrentRow;
            textBox10.Tag = s.Cells[0].Value.ToString();
            textBox10.Text = s.Cells[1].Value.ToString();
            textBox11.Text = s.Cells[2].Value.ToString();
            comboBox1.Text = s.Cells[3].Value.ToString();
            dateTimePicker2.Text = s.Cells[4].Value.ToString();
            textBox13.Text = s.Cells[5].Value.ToString();
            comboBox2.Text = s.Cells[6].Value.ToString();
            textBox14.Text = s.Cells[7].Value.ToString();
            comboBox3.Text = s.Cells[8].Value.ToString();



        }

        private void button14_Click(object sender, EventArgs e)
        {

            int gm = Convert.ToInt32(textBox10.Tag);
            var a = baglanti.Araclar1.Where(x => x.Id == gm).SingleOrDefault();
            a.AracMarka = textBox10.Text;
            a.AracModel = textBox11.Text;
            a.AracOzellik = comboBox1.Text;
            a.AracBakımGunu = dateTimePicker2.Text;
            a.AracKm = Convert.ToInt32(textBox13.Text);
            a.Hgs = comboBox2.Text;
            a.GunlukTutar = Convert.ToDecimal(textBox14.Text);
            a.AracKiraDurumu = comboBox3.Text;
            baglanti.SaveChanges();
            listele();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int gm = Convert.ToInt32(textBox10.Tag);
            var a = baglanti.Araclar1.Where(x => x.Id == gm).SingleOrDefault();
            baglanti.Araclar1.Remove(a);
            baglanti.SaveChanges();
            listele();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = baglanti.Araclar1.Where(x => x.AracMarka.ToLower().Contains(textBox10.Text) || x.AracMarka.ToUpper().Contains(textBox10.Text)).ToList();
            dataGridView3.Visible = true;
        }
    }
}
