using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using chat.server;

namespace client.ui
{
    public partial class frm : MaterialForm
    {
        TcpClient tcpClient = new TcpClient();
        Stream clientStream;

        public frm()
        {
            InitializeComponent();
            //
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            tcpClient.Connect(Server.ip, 8001);
            clientStream = tcpClient.GetStream();
            //
            Thread myThread = new Thread(reveiveMsg);
            myThread.IsBackground = true;
            //
            myThread.Start();

        }

        private void reveiveMsg()
        {
            while (true)
            {
                //
                int startLength = 0;
                int maxLength = 100;
                byte[] incomingMsg = new byte[maxLength];
                int actualRecievedMsgLen = clientStream.Read(incomingMsg, startLength, maxLength);

                //logout
                if (Convert.ToChar(incomingMsg[0]) == 'q')
                {
                    MessageBox.Show("signed out");
                    Thread.Sleep(333);
                    break;
                }

                var stringBuilder = new StringBuilder();
                foreach (var item in incomingMsg)
                {
                    stringBuilder.Append(Convert.ToChar(item));
                }

                //
                //file?
                if (Convert.ToChar(incomingMsg[0]) == '.')
                {
                    string filePath = "received_file_"+DateTime.Now.ToLongDateString()+".txt";

                    saveMyFile(stringBuilder, filePath);

                    string msg = $"~you received a file {filePath}";
                    stringBuilder = new StringBuilder(msg);
                }
                //

                lstMsgs.Items.Add(stringBuilder.ToString());
            }

            clientStream.Close();
            tcpClient.Close();
            Application.Exit();
        }

        private void saveMyFile(StringBuilder myIncomingMsg, string filePath)
        {
            if (!File.Exists(filePath))
            {
                var myFile = File.Create(filePath);

                // close the file so TextWriter can open it later again for write
                myFile.Close();
            }

            //write to file
            TextWriter myNewFile = new StreamWriter(filePath);

            myNewFile.WriteLine(myIncomingMsg.ToString());
            myNewFile.Flush();

            myNewFile.Close();
            myNewFile = null;
        }

        private void send()
        {
            string myMsgStr = txtMsg.Text;
            ASCIIEncoding encode = new ASCIIEncoding();
            byte[] myMsgByte = encode.GetBytes("~" + myMsgStr);
            //
            lstMsgs.Items.Add(myMsgStr);
            //Transmitting
            int startLen = 0, end = myMsgByte.Length;
            clientStream.Write(myMsgByte, startLen, end);
            //
            txtMsg.Clear();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            send();
        }

        private void txtMsg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                send();
            }
        }

        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string path = openFileDialog1.FileName;
            TextReader myFile = new StreamReader(path);
            string myMsgStr = myFile.ReadToEnd();

            myFile.Close();
            myFile = null;

            ASCIIEncoding encode = new ASCIIEncoding();
            string msgType = ".";
            byte[] myMsgByte = encode.GetBytes(msgType + myMsgStr);

            //Transmitting
            int startLen = 0, end = myMsgByte.Length;
            clientStream.Write(myMsgByte, startLen, end);

            lstMsgs.Items.Add("you sent a file");
        }
    }
}
