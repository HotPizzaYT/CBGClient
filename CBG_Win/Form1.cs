using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
namespace CBG_Win
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Timer timer1;
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
            timer1.Start();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(webBrowser1.Url === "https://1tsandrew.com/cbg/chat/innerchat.php")
            {
                // Is innerchat?

                // If yes, refresh and focus the chatbox.

                webBrowser1.Refresh();
                textBox1.Focus();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            string input = Prompt.ShowDialog("Please enter the\nURL of the server!", "Server URL required!");
            */
            webBrowser1.Navigate("https://1tsandrew.com/cbg/chat/innerchat.php");
            InitTimer();




        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Send message!
            // MessageBox.Show("Feature not yet added!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            HttpClient client = new HttpClient();

            var values = new Dictionary<string, string>
                {
                    {"m", textBox1.Text},
                    {"u", "CBGClient1.0.0" }
                };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://1tsandrew.com/cbg/chat/sender.php", content);
            var responseString = await response.Content.ReadAsStringAsync();

            webBrowser1.Refresh();
            textBox1.Text = "";
            textBox1.Focus();

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // webBrowser1.innerHTML
        }

        private async void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            HttpClient client = new HttpClient();
            if(e.KeyCode == Keys.Enter)
            {
                // MessageBox.Show("H");
                
                var values = new Dictionary<string, string>
                {
                    {"m", textBox1.Text},
                    {"u", "CBGClient1.0.0" }
                };
                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync("https://1tsandrew.com/cbg/chat/sender.php", content);
                var responseString = await response.Content.ReadAsStringAsync();

                webBrowser1.Refresh();
                textBox1.Text = "";
                textBox1.Focus();
                // MessageBox.Show(responseString);
            }
        }
    }



    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
