using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net.Sockets;
using System.Media;

namespace testforspproject1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public  static TcpClient x;
        public  static NetworkStream ns;

        public  static StreamReader sr;
        public  static StreamWriter sw;

        public static string user;
        public static string password;
        public void button1_Click(object sender, EventArgs e)
        {
            x = new TcpClient();
            x.Connect("127.0.0.1", 20555);
            ns = x.GetStream();
            sr = new StreamReader(ns);
            sw = new StreamWriter(ns);

             user = textBox1.Text;
            password = textBox2.Text;

            sw.WriteLine(user);
            sw.Flush();
            sw.WriteLine(password);
            sw.Flush();
            string a = sr.ReadLine();

            if (a == "Invalid Username Or Password")
            {
                
                SoundPlayer player = new SoundPlayer(@"C:\Windows\Media\Invaled.wav");
                player.Play();
                MessageBox.Show(a);
            }
            else
            {

                Form1 f = new Form1();
                f.Show();
                SoundPlayer player = new SoundPlayer(@"C:\Windows\Media\connected.wav");
                player.Play();
                this.Hide();
            }
        }

        

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(@"C:\Windows\Media\goodbye.wav");
            player.Play();
            Application.Exit();
            System.Threading.Thread.Sleep(900);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(@"C:\WINDOWS\Media\welcome.wav");
            player.Play();
            

        }
    }
}
