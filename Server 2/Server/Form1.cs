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

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static TcpClient c;
        public static NetworkStream ns;
        public static StreamReader sr;
        public static StreamWriter sw;

        public static TcpListener server = new TcpListener(IPAddress.Any, 20555);
        private void Form1_Load(object sender, EventArgs e)
        {
            

            server.Start();
            Thread tth = new Thread(Listener);
            tth.IsBackground = true;
            tth.Start();
            panel1.Visible = false;
            label4.Text = "Port: 20555";
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if(ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    label3.Text = ip.ToString();
                }
            }
            
        }
        private void Balloon(string user)
        {

            notifyIcon1.Icon = new Icon(@"C:\2\star.ico");
                notifyIcon1.BalloonTipText = user+" Connected !!";
                notifyIcon1.ShowBalloonTip(1000);
            
        }
         void Listener()
        {
            int qx = -1;
            while (true)
            {
                
                c = server.AcceptTcpClient();
                ns = c.GetStream();
                sr = new StreamReader(ns);
                sw = new StreamWriter(ns);
                
                
                
                FileStream Fs = new FileStream(@"F:\users.txt", FileMode.Open, FileAccess.Read);
                StreamReader ss = new StreamReader(Fs);

                string user = sr.ReadLine();
                string password = sr.ReadLine();
                while (!ss.EndOfStream)
                {
                    String[] a = ss.ReadLine().Split(',');
                    string us = a[0];
                    string pass = a[1];
                    if (user == us && pass == password)
                    {
                        qx = 1;
                        sw.WriteLine("Wellcome " + user);
                        sw.Flush();
                        Thread th = new Thread(first);
                        th.Start();
                        using (StreamWriter sw2 = new StreamWriter(@"F:\spmm.txt", true))
                        {
                            sw2.WriteLine(user + " Connected !!");
                        }
                        Balloon(user);
                    }
                    
                }
                if (qx == -1)
                {
                    sw.WriteLine("Invalid Username Or Password");
                    sw.Flush();
                }
                

            }

        }

          static void first()
        {
            
            try
            {
                while (true)
                {

                    string xx = sr.ReadLine();
                    switch (xx)
                    {
                        case "shutdown":
                            using (StreamWriter sw2 = new StreamWriter(@"F:\spmm.txt", true))
                            {

                                System.Threading.Thread.Sleep(1000);
                                sw2.WriteLine("You Shutdown Your Computer");
                            }
                            sw.WriteLine("shutdown");
                            sw.Flush();

                            Process.Start("shutdown", "/s");
                            break;
                        case "restart":
                            using (StreamWriter sw2 = new StreamWriter(@"F:\spmm.txt", true))
                            {
                                sw2.WriteLine("You Restat Your Computer ");
                            }
                            sw.WriteLine("restart");
                            sw.Flush();
                            Process.Start("shutdown", "/r");
                            break;
                        case "get process":
                            using (StreamWriter sw2 = new StreamWriter(@"F:\spmm.txt", true))
                            {
                                sw2.WriteLine("You Get Processes");
                            }
                            sw.WriteLine("Process");
                            sw.Flush();
                            Process[] p = Process.GetProcesses();
                            sw.WriteLine(p.Length);
                            sw.Flush();
                            foreach (Process item in p)
                            {
                                sw.WriteLine(item.ProcessName);
                                sw.Flush();
                            }
                            break;
                        case "kill":
                            string c = sr.ReadLine();
                            Process[] x = Process.GetProcessesByName(c);
                            foreach (Process item in x)
                            {
                                item.Kill();
                            }
                            break;
                        case"":
                            
                            sw.WriteLine("");
                            sw.Flush();               
                            break;
                        case"Dirctory":
                            string n = sr.ReadLine();
                            using (StreamWriter sw3 = new StreamWriter(@"F:\spmm.txt", true))
                            {
                                sw3.WriteLine("You Open The Directory: "+n);
                            }
                            break;
                        default:
                            using (StreamWriter sw2 = new StreamWriter(@"F:\spmm.txt", true))
                            {

                                sw2.WriteLine("You Opened " + xx);
                            }
                            sw.WriteLine("order");
                            sw.Flush();
                            try
                            {
                                Process.Start(xx);
                                sw.WriteLine("fine");
                                sw.Flush();
                            }
                            catch {
                                sw.WriteLine("error");
                                sw.Flush();
                            }
                            break;
                    }

                }
            }
            catch (Exception ex)
            {

                Form1 f = new Form1();
                f.Show();
                
            }
             
        }

          private void button1_Click(object sender, EventArgs e)
          {
              panel1.Visible = true;
              using (StreamReader sr2 = new StreamReader(@"F:\spmm.txt", true))
              {
                  listBox1.Items.Clear();
                  
                  while (!sr2.EndOfStream)
                  {
                      listBox1.Items.Add(sr2.ReadLine());
                  }
                  }
          }

          private void Form1_FormClosed(object sender, FormClosedEventArgs e)
          {
              Application.Exit();
          }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
