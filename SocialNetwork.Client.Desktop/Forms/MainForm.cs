﻿using RestSharp;
using SocialNetwork.Client.Desktop.Configuration;
using SocialNetwork.Models.Output;
using System.Data;
using System.Runtime.InteropServices;

namespace SocialNetwork.Client.Desktop.Forms
{
    public partial class MainForm : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
           (
               int nLeftRect,    
               int nTopRect,     
               int nRightRect,   
               int nBottomRect,  
               int nWidthEllipse, 
               int nHeightEllipse 
           );
        public MainForm()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pnlNavigation.Height = btn_Dashboard.Height;
            pnlNavigation.Top = btn_Dashboard.Top;
            pnlNavigation.Left = btn_Dashboard.Left;
            btn_Dashboard.BackColor = Color.FromArgb(60, 63, 69);

        }
        private void allProfilesLabel_Show()
        {
            var client = new RestClient(AppConfiguration.Host);

            var request = new RestRequest("profile/all");

            List<ProfileOutput>? response = client.Get<List<ProfileOutput>>(request);

            string text = string.Join('\n', response.Select(u => u.OnService).ToList());

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
            pnlNavigation.Height = btn_Dashboard.Height;
            pnlNavigation.Top = btn_Dashboard.Top;
            pnlNavigation.Left = btn_Dashboard.Left;
            btn_Dashboard.BackColor = Color.FromArgb(60, 63, 69);
        }

        private void btn_Analytics_Click(object sender, EventArgs e)
        {
            pnlNavigation.Height = btn_Analytics.Height;
            pnlNavigation.Top = btn_Analytics.Top;
            btn_Analytics.BackColor = Color.FromArgb(60, 63, 69);

        }

        private void btn_Chat_Click(object sender, EventArgs e)
        {
            pnlNavigation.Height = btn_Chat.Height;
            pnlNavigation.Top = btn_Chat.Top;
            btn_Chat.BackColor = Color.FromArgb(60, 63, 69);

        }

        private void btn_Contact_Click(object sender, EventArgs e)
        {
            pnlNavigation.Height = btn_Contact.Height;
            pnlNavigation.Top = btn_Contact.Top;
            btn_Contact.BackColor = Color.FromArgb(60, 63, 69);

        }

        private void btn_FAQ_Click(object sender, EventArgs e)
        {
            pnlNavigation.Height = btn_FAQ.Height;
            pnlNavigation.Top = btn_FAQ.Top;
            btn_FAQ.BackColor = Color.FromArgb(60, 63, 69);

        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            pnlNavigation.Height = btn_Settings.Height;
            pnlNavigation.Top = btn_Settings.Top;
            btn_Settings.BackColor = Color.FromArgb(142, 145, 170);

        }

        private void btn_Dashboard_Leave(object sender, EventArgs e)
        {
            btn_Settings.BackColor = Color.FromArgb(142, 145, 149);
        }

        private void btn_Analytics_Leave(object sender, EventArgs e)
        {
            btn_Settings.BackColor = Color.FromArgb(142, 145, 149);
        }

        private void btn_Chat_Leave(object sender, EventArgs e)
        {
            btn_Settings.BackColor = Color.FromArgb(142, 145, 149);
        }

        private void btn_Contact_Leave(object sender, EventArgs e)
        {
            btn_Settings.BackColor = Color.FromArgb(142, 145, 149);
        }

        private void btn_FAQ_Leave(object sender, EventArgs e)
        {
            btn_Settings.BackColor = Color.FromArgb(142, 145, 149);
        }

        private void btn_Settings_Leave(object sender, EventArgs e)
        {
            btn_Settings.BackColor = Color.FromArgb(142, 145, 149);
        }

        /*private void label_CountUsers_Click(object sender, EventArgs e)
        {

        }*/
    }
}