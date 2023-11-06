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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdLaggedButton_Click(object sender, EventArgs e)
        {
            txtMessage.Text = "Start lagging";
            Thread.Sleep(5000);
            txtMessage.Text = "Done lagging";
        }

        private void cmdInterThreadError_Click(object sender, EventArgs e)
        {
            Task.Run(() => {
                txtMessage.Text = "Start inter-thread error";
                Thread.Sleep(5000);
                txtMessage.Text = "Done inter-thread error";
            });
        }

        private void cmdUsingInvoke_Click(object sender, EventArgs e)
        {
            SetText("Start using invoke");
            Thread.Sleep(5000);
            SetText("Done using invoke");
        }

        private async void cmdAsync_ClickAsync(object sender, EventArgs e)
        {
            txtMessage.Text = "Start non error";
            await Task.Delay(5000);
            txtMessage.Text = "Done non error";
        }

        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            if (txtMessage.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                Invoke(d, new object[] { text });
            }
            else
            {
                txtMessage.Text = text;
            }
        }
    }
}
