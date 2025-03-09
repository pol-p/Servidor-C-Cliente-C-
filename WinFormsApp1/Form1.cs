using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // Constantes privadas para la IP y el puerto del servidor
        private const string ServerIp = "192.168.1.137"; // Dirección IP del servidor
        private const int ServerPort = 9000; // Puerto del servidor

        private Socket? clientSocket;
        public Form1()
        {
            InitializeComponent();
            clientSocket = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_enviar_Click(object sender, EventArgs e)
        {
            //Pulsas el boton --> envia el mensaje al servidor
            string msg = textBox1.Text;

            //Ver si hay conexion
            if (clientSocket == null || !clientSocket.Connected)
            {
                MessageBox.Show("No estás conectado al servidor.");
                return;
            }

            // Validar si el mensaje está vacío (salir del bucle)
            if (string.IsNullOrEmpty(msg))
            {
                MessageBox.Show("No message entered. Exiting...");
                return;
            }

            // Enviar el mensaje al servidor
            try
            {
                byte[] messageBytes = Encoding.ASCII.GetBytes(msg);
                clientSocket.Send(messageBytes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(ServerIp), ServerPort);
            try
            {
                clientSocket.Connect(serverEndPoint);
                this.BackColor = Color.Green;
            }
            catch (SocketException err)
            {
                MessageBox.Show("Fail conexion: " + err);
                return;
            }
        }

        private void btn_diconnect_Click(object sender, EventArgs e)
        {
            // Verificar si el socket está conectado
            if (clientSocket != null && clientSocket.Connected)
            {
                try
                {
                    // Cerrar la conexión
                    string msge = "ExIt";
                    byte[] msgeb = System.Text.Encoding.ASCII.GetBytes(msge);
                    clientSocket.Send(msgeb);
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                    this.BackColor = Color.Red;
                    MessageBox.Show("Desconectado del servidor.");
                }
                catch (SocketException ex)
                {
                    MessageBox.Show("Error al desconectar: " + ex.Message);
                }
                finally
                {
                    // Liberar el socket
                    clientSocket = null;
                }
            }
            else
            {
                MessageBox.Show("No estás conectado al servidor.");
            }
        }
    }
}
