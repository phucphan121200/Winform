namespace Đồ_án_ltwin
{
    partial class NotificationSignup
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationSignup));
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.LabelYourein = new Guna.UI.WinForms.GunaLabel();
            this.BacktoForm1 = new Guna.UI.WinForms.GunaButton();
            this.LabelName = new Guna.UI.WinForms.GunaLabel();
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.SuspendLayout();
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Bold);
            this.gunaLabel1.ForeColor = System.Drawing.Color.White;
            this.gunaLabel1.Location = new System.Drawing.Point(55, 191);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(387, 89);
            this.gunaLabel1.TabIndex = 1;
            this.gunaLabel1.Text = "WELCOME!";
            // 
            // LabelYourein
            // 
            this.LabelYourein.AutoSize = true;
            this.LabelYourein.BackColor = System.Drawing.Color.Transparent;
            this.LabelYourein.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelYourein.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LabelYourein.Location = new System.Drawing.Point(12, 22);
            this.LabelYourein.Name = "LabelYourein";
            this.LabelYourein.Size = new System.Drawing.Size(432, 67);
            this.LabelYourein.TabIndex = 2;
            this.LabelYourein.Text = "You\'re in ORWELL,";
            // 
            // BacktoForm1
            // 
            this.BacktoForm1.AnimationHoverSpeed = 0.07F;
            this.BacktoForm1.AnimationSpeed = 0.03F;
            this.BacktoForm1.BackColor = System.Drawing.Color.Transparent;
            this.BacktoForm1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.BacktoForm1.BorderColor = System.Drawing.Color.Black;
            this.BacktoForm1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BacktoForm1.FocusedColor = System.Drawing.Color.Empty;
            this.BacktoForm1.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            this.BacktoForm1.ForeColor = System.Drawing.Color.White;
            this.BacktoForm1.Image = null;
            this.BacktoForm1.ImageSize = new System.Drawing.Size(20, 20);
            this.BacktoForm1.Location = new System.Drawing.Point(917, 676);
            this.BacktoForm1.Name = "BacktoForm1";
            this.BacktoForm1.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.BacktoForm1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.BacktoForm1.OnHoverForeColor = System.Drawing.Color.White;
            this.BacktoForm1.OnHoverImage = null;
            this.BacktoForm1.OnPressedColor = System.Drawing.Color.Black;
            this.BacktoForm1.Radius = 15;
            this.BacktoForm1.Size = new System.Drawing.Size(257, 61);
            this.BacktoForm1.TabIndex = 4;
            this.BacktoForm1.Text = "Sign in!";
            this.BacktoForm1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BacktoForm1.Click += new System.EventHandler(this.BacktoForm1_Click);
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.BackColor = System.Drawing.Color.Transparent;
            this.LabelName.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LabelName.Location = new System.Drawing.Point(449, 22);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(160, 67);
            this.LabelName.TabIndex = 5;
            this.LabelName.Text = "Name";
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gunaPanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(1208, 29);
            this.gunaPanel1.TabIndex = 6;
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = this.gunaPanel1;
            // 
            // NotificationSignup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1208, 781);
            this.Controls.Add(this.gunaPanel1);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.BacktoForm1);
            this.Controls.Add(this.LabelYourein);
            this.Controls.Add(this.gunaLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NotificationSignup";
            this.Text = "NotificationSignup";
            this.Load += new System.EventHandler(this.NotificationSignup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaLabel LabelYourein;
        private Guna.UI.WinForms.GunaButton BacktoForm1;
        private Guna.UI.WinForms.GunaLabel LabelName;
        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
    }
}