using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Media;

namespace Network
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.EnableRaisingEvents = false;
            p.StartInfo.FileName = @"C:\2\Server 2\Server\bin\Debug\Server.exe";
            p.Start();
            pictureBox2.Enabled = false;
            pictureBox2.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.EnableRaisingEvents = false;
            p.StartInfo.FileName = @"C:\2\Client 2\testforspproject1\bin\Debug\testforspproject1.exe";
            p.Start();
            pictureBox1.Enabled = false;
            pictureBox1.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
