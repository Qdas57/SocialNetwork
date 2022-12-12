namespace SocialNetwork.Client.Desktop.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlNavigation = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_FAQ = new System.Windows.Forms.Button();
            this.btn_Settings = new System.Windows.Forms.Button();
            this.btn_Contact = new System.Windows.Forms.Button();
            this.btn_Chat = new System.Windows.Forms.Button();
            this.btn_Analytics = new System.Windows.Forms.Button();
            this.btn_Dashboard = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1_SocialNetwork = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_Dashboard = new System.Windows.Forms.Label();
            this.label_CountUsers = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.panel1.Controls.Add(this.pnlNavigation);
            this.panel1.Controls.Add(this.btn_FAQ);
            this.panel1.Controls.Add(this.btn_Settings);
            this.panel1.Controls.Add(this.btn_Contact);
            this.panel1.Controls.Add(this.btn_Chat);
            this.panel1.Controls.Add(this.btn_Analytics);
            this.panel1.Controls.Add(this.btn_Dashboard);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 577);
            this.panel1.TabIndex = 0;
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(145)))), ((int)(((byte)(170)))));
            this.pnlNavigation.Location = new System.Drawing.Point(0, 193);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(3, 100);
            this.pnlNavigation.TabIndex = 7;
            // 
            // btn_FAQ
            // 
            this.btn_FAQ.FlatAppearance.BorderSize = 0;
            this.btn_FAQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FAQ.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_FAQ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(145)))), ((int)(((byte)(170)))));
            this.btn_FAQ.Location = new System.Drawing.Point(0, 502);
            this.btn_FAQ.Name = "btn_FAQ";
            this.btn_FAQ.Size = new System.Drawing.Size(186, 33);
            this.btn_FAQ.TabIndex = 6;
            this.btn_FAQ.Text = "FAQ";
            this.btn_FAQ.UseVisualStyleBackColor = true;
            this.btn_FAQ.Click += new System.EventHandler(this.btn_FAQ_Click);
            this.btn_FAQ.Leave += new System.EventHandler(this.btn_FAQ_Leave);
            // 
            // btn_Settings
            // 
            this.btn_Settings.FlatAppearance.BorderSize = 0;
            this.btn_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Settings.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Settings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(145)))), ((int)(((byte)(170)))));
            this.btn_Settings.Location = new System.Drawing.Point(0, 535);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(186, 42);
            this.btn_Settings.TabIndex = 5;
            this.btn_Settings.Text = "Settings";
            this.btn_Settings.UseVisualStyleBackColor = true;
            this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
            this.btn_Settings.Leave += new System.EventHandler(this.btn_Settings_Leave);
            // 
            // btn_Contact
            // 
            this.btn_Contact.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Contact.FlatAppearance.BorderSize = 0;
            this.btn_Contact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Contact.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Contact.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(145)))), ((int)(((byte)(149)))));
            this.btn_Contact.Location = new System.Drawing.Point(0, 270);
            this.btn_Contact.Name = "btn_Contact";
            this.btn_Contact.Size = new System.Drawing.Size(186, 42);
            this.btn_Contact.TabIndex = 4;
            this.btn_Contact.Text = "Contact Us";
            this.btn_Contact.UseVisualStyleBackColor = true;
            this.btn_Contact.Click += new System.EventHandler(this.btn_Contact_Click);
            this.btn_Contact.Leave += new System.EventHandler(this.btn_Contact_Leave);
            // 
            // btn_Chat
            // 
            this.btn_Chat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Chat.FlatAppearance.BorderSize = 0;
            this.btn_Chat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Chat.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Chat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(145)))), ((int)(((byte)(149)))));
            this.btn_Chat.Location = new System.Drawing.Point(0, 228);
            this.btn_Chat.Name = "btn_Chat";
            this.btn_Chat.Size = new System.Drawing.Size(186, 42);
            this.btn_Chat.TabIndex = 3;
            this.btn_Chat.Text = "Chat";
            this.btn_Chat.UseVisualStyleBackColor = true;
            this.btn_Chat.Click += new System.EventHandler(this.btn_Chat_Click);
            this.btn_Chat.Leave += new System.EventHandler(this.btn_Chat_Leave);
            // 
            // btn_Analytics
            // 
            this.btn_Analytics.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Analytics.FlatAppearance.BorderSize = 0;
            this.btn_Analytics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Analytics.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Analytics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(145)))), ((int)(((byte)(149)))));
            this.btn_Analytics.Location = new System.Drawing.Point(0, 186);
            this.btn_Analytics.Name = "btn_Analytics";
            this.btn_Analytics.Size = new System.Drawing.Size(186, 42);
            this.btn_Analytics.TabIndex = 2;
            this.btn_Analytics.Text = "Analytics";
            this.btn_Analytics.UseVisualStyleBackColor = true;
            this.btn_Analytics.Click += new System.EventHandler(this.btn_Analytics_Click);
            this.btn_Analytics.Leave += new System.EventHandler(this.btn_Analytics_Leave);
            // 
            // btn_Dashboard
            // 
            this.btn_Dashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Dashboard.FlatAppearance.BorderSize = 0;
            this.btn_Dashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Dashboard.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Dashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(145)))), ((int)(((byte)(149)))));
            this.btn_Dashboard.Location = new System.Drawing.Point(0, 144);
            this.btn_Dashboard.Name = "btn_Dashboard";
            this.btn_Dashboard.Size = new System.Drawing.Size(186, 42);
            this.btn_Dashboard.TabIndex = 1;
            this.btn_Dashboard.Text = "Dashboard";
            this.btn_Dashboard.UseVisualStyleBackColor = true;
            this.btn_Dashboard.Click += new System.EventHandler(this.btn_Dashboard_Click);
            this.btn_Dashboard.Leave += new System.EventHandler(this.btn_Dashboard_Leave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1_SocialNetwork);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 144);
            this.panel2.TabIndex = 0;
            // 
            // label1_SocialNetwork
            // 
            this.label1_SocialNetwork.AutoSize = true;
            this.label1_SocialNetwork.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1_SocialNetwork.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(145)))), ((int)(((byte)(149)))));
            this.label1_SocialNetwork.Location = new System.Drawing.Point(34, 101);
            this.label1_SocialNetwork.Name = "label1_SocialNetwork";
            this.label1_SocialNetwork.Size = new System.Drawing.Size(123, 18);
            this.label1_SocialNetwork.TabIndex = 1;
            this.label1_SocialNetwork.Text = "Social Network";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(60, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label_Dashboard
            // 
            this.label_Dashboard.AutoSize = true;
            this.label_Dashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Dashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label_Dashboard.Location = new System.Drawing.Point(223, 22);
            this.label_Dashboard.Name = "label_Dashboard";
            this.label_Dashboard.Size = new System.Drawing.Size(162, 32);
            this.label_Dashboard.TabIndex = 8;
            this.label_Dashboard.Text = "Dashboard";
            // 
            // label_CountUsers
            // 
            this.label_CountUsers.AutoSize = true;
            this.label_CountUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_CountUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label_CountUsers.Location = new System.Drawing.Point(233, 104);
            this.label_CountUsers.Name = "label_CountUsers";
            this.label_CountUsers.Size = new System.Drawing.Size(362, 15);
            this.label_CountUsers.TabIndex = 9;
            this.label_CountUsers.Text = "Сейчас на сервисе: allProfilesLabel_Show().ToString()\r\n";
            /*this.label_CountUsers.Click += new System.EventHandler(this.label_CountUsers_Click);*/
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(951, 577);
            this.Controls.Add(this.label_CountUsers);
            this.Controls.Add(this.label_Dashboard);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Social Network | Main ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private Panel panel1;
        private FlowLayoutPanel pnlNavigation;
        private Button btn_FAQ;
        private Button btn_Settings;
        private Button btn_Contact;
        private Button btn_Chat;
        private Button btn_Analytics;
        private Button btn_Dashboard;
        private Panel panel2;
        private Label label1_SocialNetwork;
        private PictureBox pictureBox1;
        private Label label_Dashboard;
        private Label label_CountUsers;
    }
}