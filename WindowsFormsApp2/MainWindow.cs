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


namespace WindowsFormsApp2
{
    public partial class MainWindow : Form
    {

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void addressBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void connectButton_Click(object sender, EventArgs e)
        {
           
            WorkWindow.address = addressBox.Text;
            WorkWindow.login = loginBox.Text;
            WorkWindow.password = passBox.Text;
            WorkWindow.port = int.Parse(portBox.Text);
            
           if(WorkWindow.address == null | WorkWindow.login == null | WorkWindow.password == null)
            {
                MessageBox.Show("Fill all fields");
            }
            else
            {
                WorkWindow wind = new WorkWindow();
                wind.Show();
            }
            
            
        }
    }
}
