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
    public partial class Odeme : Form
    {
        public Odeme()
        {
            InitializeComponent();
        }
        AracKiralama1Container baglanti = new AracKiralama1Container();
        public void listele()
        {
            dataGridView2.DataSource = baglanti.Odemeler1.ToList();
            dataGridView2.Visible = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            menu git = new menu();
            git.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Rapor git = new Rapor();
            git.Show();
            this.Hide();
        }

        private void Odeme_Load(object sender, EventArgs e)
        {
           var cek = from s in baglanti.Musteriler1
                  orderby s.Id ascending
                  select s.Id;
            comboBox1.DataSource = cek.ToList();
            var c = from s in baglanti.Araclar1 where s.AracKiraDurumu=="MÜSAİT"
                      orderby s.Id ascending
                      select s.Id;
            comboBox2.DataSource = c.ToList();
            dataGridView2.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listele();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Odemeler m = new Odemeler();
            m.MusterilerId = Convert.ToInt32(comboBox1.SelectedItem);
            m.AraclarId = Convert.ToInt32(comboBox2.SelectedItem);
            m.OdemeTutar = Convert.ToDecimal(textBox8.Text);
            m.OdemeTarih = dateTimePicker1.Text;
            m.VadeFarki= Convert.ToDecimal(textBox9.Text);
            baglanti.Odemeler1.Add(m);
            baglanti.SaveChanges();
            listele();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow s = dataGridView2.CurrentRow;
            comboBox1.Tag= s.Cells[0].Value.ToString();
            comboBox1.Text = s.Cells[1].Value.ToString();
            comboBox2.Text = s.Cells[2].Value.ToString();
            textBox8.Text= s.Cells[3].Value.ToString();
            dateTimePicker1.Text= s.Cells[4].Value.ToString();
            textBox9.Text= s.Cells[5].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int gm = Convert.ToInt32(comboBox1.Tag);
            var m = baglanti.Odemeler1.Where(x => x.Id == gm).SingleOrDefault();
            m.MusterilerId = Convert.ToInt32(comboBox1.SelectedItem);
            m.AraclarId = Convert.ToInt32(comboBox2.SelectedItem);
            m.OdemeTutar = Convert.ToDecimal(textBox8.Text);
            m.OdemeTarih = dateTimePicker1.Text;
            m.VadeFarki = Convert.ToDecimal(textBox9.Text);
            baglanti.SaveChanges();
            
            listele();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int gm = Convert.ToInt32(comboBox1.Tag);
            var m = baglanti.Odemeler1.Where(x => x.Id == gm).SingleOrDefault();
            baglanti.Odemeler1.Remove(m);
            baglanti.SaveChanges();
            listele();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(comboBox1.Text);
            dataGridView2.DataSource = baglanti.Odemeler1.Where(x => x.MusterilerId==a).ToList();
            
           
            dataGridView2.Visible = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
