using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Cliente_finale
{
    public partial class Form : System.Windows.Forms.Form
    {
        //coordinate
        public static int x = 0;
        public static int y = 0;
        //stato della socket
        public static string connesso = "Disconnesso";

        //ip e porta
        public static IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");
        public static IPEndPoint remoteEP = new IPEndPoint(ipAddress, 5000);
        //socket
        public static Socket client = new Socket(ipAddress.AddressFamily,
            SocketType.Stream, ProtocolType.Tcp);

        public Form()
        {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
        }
        private void invia(string da_inviare)
        {
            //gestione invia
            da_inviare += '$';
            byte[] msg = Encoding.ASCII.GetBytes(da_inviare);

            int a = client.Send(msg);
            Console.WriteLine(DateTime.Now.ToString() + " " + DateTime.Now.Millisecond.ToString() + " inviato " + a + " byte: " + "[" + da_inviare + "]");
            //MessageBox.Show("Client invia: ");

        }
        private string ricevi()
        {
            string data = "";
            //gestione ricevi
            byte[] bytes = new Byte[8];
                while (data.IndexOf("$") == -1)
            {
                int bytesRec = client.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
            }
            data = data.Remove(data.Length - 1, 1);
            Console.WriteLine(DateTime.Now.ToString() + " " + DateTime.Now.Millisecond.ToString() + " ricevuto " + bytes.Length + " convertito in: " + "[" + data.ToString() + "]");
            
            return data;
        }
        private void connetti()
        {
            //funzione che gestisce tutta la socket al momento del caricamento della form
            try
            {
                
                client.Connect(remoteEP);
                Console.WriteLine("Connesso con " + remoteEP.ToString());
                connesso = "Connesso";
                Text = "Server - " + connesso + " - Posizione immagine (" + x + "|" + y + ")";
                
                SpostaCE.Enabled = true;
                SpostaNE.Enabled = true;
                SpostaNO.Enabled = true;
                SpostaSO.Enabled = true;
                SpostaSE.Enabled = true;
                Imm.Enabled = true;
                string xy_string;
                string[] xy;
                while (client.Connected)
                {
                    //x = Convert.ToInt32(ricevi());
                    //Thread.Sleep(100);
                    //y = Convert.ToInt32(ricevi());
                    xy_string = ricevi();
                    xy = xy_string.Split('#');
                    x = Convert.ToInt32(xy[0]);
                    y = Convert.ToInt32(xy[1]);
                    Text = "Server - " + connesso + " - Posizione immagine (" + x + "|" + y + ")";
                }
            }
            catch(Exception e)
            {

                try
                {
                    Console.WriteLine("Eccezzione " + e.Message);
                    Text = "Client – Connessione non stabilita.";
                }
                catch { }
            }
        }
        private void SpostaCE_Click(object sender, EventArgs e)
        {
            invia("21#" + SpostaCE.Text);
        }

        private void SpostaSO_Click(object sender, EventArgs e)
        {
            invia("21#" + SpostaSO.Text);
        }

        private void SpostaNO_Click(object sender, EventArgs e)
        {
            invia("21#" + SpostaNO.Text);
        }

        private void SpostaNE_Click(object sender, EventArgs e)
        {
            invia("21#" + SpostaNE.Text);
        }

        private void SpostaSE_Click(object sender, EventArgs e)
        {
            invia("21#" + SpostaSE.Text);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(connetti));
            t.IsBackground = true;
            t.Start();
        }

        private void Imm_Click(object sender, EventArgs e)
        {
            invia("23#NEXT");
        }
    }
}
