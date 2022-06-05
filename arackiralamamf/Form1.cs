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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        AracKiralama1Container baglanti = new AracKiralama1Container();
        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }
        public bool KullaniciGiris(string ad, string sifre)
        {
            var sorgu = from p in baglanti.Users1
                        where p.userName == ad && p.UserPs == sifre
                        select p;
            if (sorgu.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (KullaniciGiris(textBox1.Text, textBox2.Text))
            {
                menu git = new menu();
                git.Show();
                this.Hide();
            }
            else { MessageBox.Show("kullnıcı adı veya şifre hatalı \n Tekrar deneyiniz veya kayıtol butonuna basınız"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Users k = new Users();
            k.userName = textBox3.Text;
            k.UserPs = textBox4.Text;
            baglanti.Users1.Add(k);
            MessageBox.Show("Kayıt işleminiz gerçekleşti");
            baglanti.SaveChanges();
        }
    }
}
