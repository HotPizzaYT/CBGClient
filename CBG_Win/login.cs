using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;


namespace CBG_Win
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient(new HttpClientHandler());

            var values = new Dictionary<string, string>
                {
                    {"username", textBox1.Text},
                    {"password", textBox2.Text }
                };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://1tsandrew.com/cbg/chat/account/lc.php", content);
            var responseString = await response.Content.ReadAsStringAsync();
            var original = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            original.TextBoxValue = textBox1.Text;
            original.Show();
        }
    }
}
