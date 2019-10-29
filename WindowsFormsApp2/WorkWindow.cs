using System;
using Renci.SshNet;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace WindowsFormsApp2
{
    public partial class WorkWindow : Form
    {
        public static String address = null, login = null, password = null;
        public static int port;
        public WorkWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String command = commandBox.Text;
            RunCommand(command);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            var client = new SshClient(address, login, password);
            client.Disconnect();
            logOutput.AppendText("Disconnected");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void RunCommand(String commandFromTB)
        {
            stopButton.Enabled = true;
            try
            {
                using (var client = new SshClient(address, login, password))
                {
                    client.Connect();

                    var cmd = client.CreateCommand(commandFromTB);

                    var result = cmd.BeginExecute();

                    using (var reader =
                               new StreamReader(cmd.OutputStream, Encoding.UTF8, true, 1024, true))
                    {
                        while (!result.IsCompleted || !reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            if (line != null)
                            {
                                logOutput.Invoke(
                                    (MethodInvoker)(() =>
                                        logOutput.AppendText(line + Environment.NewLine)));
                            }
                        }
                    }

                    cmd.EndExecute(result);
                }
            }
            catch
            {
                stopButton.Enabled = false;
                MessageBox.Show("Something wrong!");
            }
        }
    }
}

