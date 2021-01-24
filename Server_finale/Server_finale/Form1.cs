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

namespace Server_finale
{
    public partial class FormServer : System.Windows.Forms.Form
    {
        private static string posizione = "CE";
        private static int x = 0;
        private static int y = 0;
        private static string connesso = "Disconnesso";

        private static IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        private static IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 5000);

        public static Socket listener = new Socket(ipAddress.AddressFamily,
            SocketType.Stream, ProtocolType.Tcp);
        
        
        public FormServer()
        {
            InitializeComponent();
            FormServer.CheckForIllegalCrossThreadCalls = false;
        }
        private void Form_Load(object sender, EventArgs e)
        {
            immagine.Load("immagini/immagine1.jpg");
            aggPosizione();
            Thread ascolta = new Thread(new ThreadStart(gestisciSocket));
            ascolta.IsBackground = true;
            ascolta.Start();
        }
        public void aggPosizione()
        {
            switch (posizione)
            {
                case "CE":
                    {
                        x = (immagine.Parent.ClientSize.Width / 2) - (immagine.Width / 2);
                        y = (immagine.Parent.ClientSize.Height / 2) - (immagine.Height / 2);
                        break;
                    }
                case "NE":
                    {
                        x = (immagine.Parent.ClientSize.Width) - (immagine.Width);
                        y = 0;
                        break;
                    }
                case "NO":
                    {
                        x = 0;
                        y = 0;
                        break;
                    }
                case "SE":
                    {
                        x = (immagine.Parent.ClientSize.Width) - (immagine.Width);
                        y = (immagine.Parent.ClientSize.Height) - (immagine.Height);
                        break;
                    }
                case "SO":
                    {
                        x = 0;
                        y = (immagine.Parent.ClientSize.Height) - (immagine.Height);
                        break;
                    }
            }
            immagine.Location = new Point(x, y);
            Text = "Server - " + connesso + " - Posizione immagine (" + x + "|" + y + ")";
        }
        private void gestisciSocket()
        {
            //Accetta le socket e crea thread che le gestisce
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                while (true)
                {
                    Socket accettata = listener.Accept();
                    Thread t = new Thread(new ParameterizedThreadStart(coordinate));
                    t.IsBackground = true;
                    t.Start(accettata);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void coordinate(Object a)
        {
            Socket handler = (Socket)a;

            connesso = "Connesso";
            
            Thread t1 = new Thread(new ParameterizedThreadStart(posizioni));
            t1.IsBackground = true;
            t1.Start(handler);

            int x1 = -1;
            int y1 = -1;
            while (handler.Connected) 
            {
                Thread.Sleep(1);
                if (x1 != x || y1 != y)
                {
                    invia(handler, Convert.ToString(x));
                    //ricevi(handler);

                    invia(handler, Convert.ToString(y));
                    //ricevi(handler);
                }
                x1 = x;
                y1 = y;
            }

            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
        private static void invia(Socket handler, string da_inviare)
        {
            //gestione dell'invio
            da_inviare += '$';
            byte[] msg = Encoding.ASCII.GetBytes(da_inviare);

            try
            {
                int a = handler.Send(msg);
                Console.WriteLine(DateTime.Now.ToString() + " " + DateTime.Now.Millisecond.ToString() + " inviato " + a + " byte: " + "[" + da_inviare + "]");
            }
            catch { }
        }

        private static string ricevi(Socket handler)
        {
            string data = "";
            //gestione del ricevi
            byte[] bytes = new Byte[4];
            try
            {
                while (data.IndexOf("$") == -1)
                {
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                }
                data = data.Remove(data.Length - 1, 1);
            }
            catch { }
            
            Console.WriteLine(DateTime.Now.ToString() + " " + DateTime.Now.Millisecond.ToString() + " ricevuto " + bytes.Length + " convertito in: " + "[" + data.ToString() + "]");
            return data;
        }
        private void posizioni(Object b)
        {
            Socket handler = (Socket)b;
            while (true)
            {
                string a = ricevi(handler);
                if (posizione != a)
                {
                    posizione = a;
                    aggPosizione();

                }
            }
        }
        private void Form_SizeChanged(object sender, EventArgs e)
        {
            aggPosizione();
        }
    }
}
