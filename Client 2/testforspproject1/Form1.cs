using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Diagnostics;
using System.IO;
using System.Media;

namespace testforspproject1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            
            
        }
        StreamReader sr = Form2.sr;
        StreamWriter sw = Form2.sw;
        

        
        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                
                sw.WriteLine(textBox3.Text);
                sw.Flush();
                string r;
                r = sr.ReadLine();
                switch(r)
                {

                    case"":
                         MessageBox.Show("You Don't Do Any Thing ..!");
                    
                    Form1 f = new Form1();
                    f.Show();
                    this.Hide();
                    break;

                    case"Process":
                    panel1.Visible = true;
                    panel2.Visible = false;
                    listBox1.Items.Clear();
                    string n;
                    int xss = Convert.ToInt32(sr.ReadLine());
                    for (int i = 0; i < xss; i++)
                    {
                        n = sr.ReadLine();
                        listBox1.Items.Add(n);
                    }

                    SoundPlayer player = new SoundPlayer(@"C:\Windows\Media\process.wav");
                    player.Play();
                    
                        break;
                    case"shutdown":
                        SoundPlayer player1 = new SoundPlayer(@"C:\Windows\Media\shutting.wav");
                    player1.Play();
                    
                        break;
                    case"restart":
                            SoundPlayer player2 = new SoundPlayer(@"C:\Windows\Media\restarting.wav");
                    player2.Play();
                    
                        break;
                    default:
                        string a= sr.ReadLine();
                        if (a == "fine")
                        {
                            SoundPlayer player3 = new SoundPlayer(@"C:\Windows\Media\new.wav");
                            player3.Play();
                        }
                        else
                        {
                            MessageBox.Show("The Name Of Process Is Invalid");
                        }
                        break;
                }
                
            }
            catch { MessageBox.Show("You Don't Do Any Thing ..!"); }
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                    sw.WriteLine("kill");
                    sw.Flush();
                    sw.WriteLine(listBox1.SelectedItem);
                    sw.Flush();
                    
                    SoundPlayer player = new SoundPlayer(@"C:\Windows\Media\killed.wav");
                    player.Play();
                   
                
            }
            catch { }
        }

        

        public void Form1_Load(object sender, EventArgs e)
        {

            panel2.Visible = true;
            panel1.Visible = false;
            panel3.Visible = false;
            DriveInfo[] d = DriveInfo.GetDrives();

            foreach (DriveInfo i in d)
                treeView1.Nodes.Add(i.Name);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
            panel3.Visible = false;

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string[] dir = Directory.GetDirectories(e.Node.Text);

            foreach (string n in dir)
                e.Node.Nodes.Add(n);
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            sw.WriteLine("Dirctory");
            sw.Flush();

            string n= treeView1.SelectedNode.Text.ToString();
            sw.WriteLine(n);
            sw.Flush();
        }
    }
}
