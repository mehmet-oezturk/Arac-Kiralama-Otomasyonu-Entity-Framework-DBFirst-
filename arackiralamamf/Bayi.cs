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
    public partial class Bayi : Form
    {
        public Bayi()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            menu git = new menu();
            git.Show();
            this.Hide();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Rapor git = new Rapor();
            git.Show();
            this.Hide();
        }
        AracKiralama1Container baglanti = new AracKiralama1Container();
        public void listele()
        {
            dataGridView4.DataSource = baglanti.Bayiler1.ToList();
            dataGridView4.Visible = true;
        }
        private void Bayi_Load(object sender, EventArgs e)
        {
            dataGridView4.Visible = false;

            comboBox1.DataSource = baglanti.Araclar1.ToList();// combobox ı diğer veriden çekmek
            comboBox1.ValueMember = "Id";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Bayiler b = new Bayiler();
            b.AraclarId = Convert.ToInt32(comboBox1.Text);
            b.BayiAd = textBox16.Text;
            b.BayiYetkilisi = textBox17.Text;
            
            b.BayiAdres = textBox19.Text;
            b.BayiTelefon = maskedTextBox1.Text;
            b.BayiCiro = Convert.ToDecimal(textBox20.Text);
            baglanti.Bayiler1.Add(b);
            baglanti.SaveChanges();
            listele();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow s = dataGridView4.CurrentRow;
            textBox16.Tag = s.Cells[0].Value.ToString();
            comboBox1.Text= s.Cells[1].Value.ToString();
            textBox16.Text = s.Cells[2].Value.ToString();
            textBox17.Text = s.Cells[3].Value.ToString();
            textBox19.Text = s.Cells[4].Value.ToString();
            maskedTextBox1.Text= s.Cells[5].Value.ToString();
            textBox20.Text = s.Cells[6].Value.ToString();
        }
    }
}
