using RestSharp;
using SocialNetwork.Client.Desktop.Configuration;
using SocialNetwork.Models.Output;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialNetwork.Client.Desktop.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void allProfilesButton_Click(object sender, EventArgs e)
        {
            var client = new RestClient(AppConfiguration.Host);

            var request = new RestRequest("profile/all");

            List<ProfileOutput>? response = client.Get<List<ProfileOutput>>(request);

            string text = string.Join('\n', response.Select(u => u.OnService).ToList());

            MessageBox.Show(text);
        }
    }
}
