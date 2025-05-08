using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazilimDeneme
{
    public partial class Form1 : Form
    {
        private Label welcomeLabel;
        private Button enterButton;
        private Label homeLabel;

        public Form1()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            // Form ayarları
            this.Text = "YazilimDeneme Uygulaması";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Hoş Geldiniz etiketi
            welcomeLabel = new Label();
            welcomeLabel.Text = "Hoş Geldiniz";
            welcomeLabel.Font = new Font("Arial", 16, FontStyle.Bold);
            welcomeLabel.AutoSize = true;
            welcomeLabel.Location = new Point(200, 50);
            this.Controls.Add(welcomeLabel);

            // Giriş Yap butonu
            enterButton = new Button();
            enterButton.Text = "Giriş Yap";
            enterButton.Font = new Font("Arial", 12);
            enterButton.Size = new Size(120, 40);
            enterButton.Location = new Point(220, 120);
            enterButton.Click += EnterButton_Click;
            this.Controls.Add(enterButton);

            // AnaSayfa etiketi (başlangıçta gizli)
            homeLabel = new Label();
            homeLabel.Text = "AnaSayfa";
            homeLabel.Font = new Font("Arial", 36, FontStyle.Bold);
            homeLabel.AutoSize = true;
            homeLabel.Location = new Point(150, 200);
            homeLabel.Visible = false;
            this.Controls.Add(homeLabel);
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            // Giriş Yap butonuna tıklandığında
            welcomeLabel.Visible = false;
            enterButton.Visible = false;
            homeLabel.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form yüklenirken ek işlem gerekirse buraya eklenebilir
        }
    }
}