namespace Đồ_án_ltwin
{
    partial class EnterCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnterCode));
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.TextBoxEnter = new Guna.UI.WinForms.GunaTextBox();
            this.ButtonEnter = new Guna.UI.WinForms.GunaButton();
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.gunaButton9 = new Guna.UI.WinForms.GunaButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.gunaLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gunaLabel1.Location = new System.Drawing.Point(39, 183);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(507, 41);
            this.gunaLabel1.TabIndex = 0;
            this.gunaLabel1.Text = "Enter Your Code to Access Member";
            // 
            // TextBoxEnter
            // 
            this.TextBoxEnter.BackColor = System.Drawing.Color.Transparent;
            this.TextBoxEnter.BaseColor = System.Drawing.Color.White;
            this.TextBoxEnter.BorderColor = System.Drawing.Color.Silver;
            this.TextBoxEnter.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxEnter.FocusedBaseColor = System.Drawing.Color.White;
            this.TextBoxEnter.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.TextBoxEnter.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.TextBoxEnter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TextBoxEnter.Location = new System.Drawing.Point(97, 309);
            this.TextBoxEnter.Name = "TextBoxEnter";
            this.TextBoxEnter.PasswordChar = '●';
            this.TextBoxEnter.Radius = 15;
            this.TextBoxEnter.SelectedText = "";
            this.TextBoxEnter.Size = new System.Drawing.Size(391, 41);
            this.TextBoxEnter.TabIndex = 1;
            this.TextBoxEnter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxEnter.UseSystemPasswordChar = true;
            this.TextBoxEnter.TextChanged += new System.EventHandler(this.TextBoxEnter_TextChanged);
            this.TextBoxEnter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxEnter_KeyPress);
            // 
            // ButtonEnter
            // 
            this.ButtonEnter.AnimationHoverSpeed = 0.07F;
            this.ButtonEnter.AnimationSpeed = 0.03F;
            this.ButtonEnter.BackColor = System.Drawing.Color.Transparent;
            this.ButtonEnter.BaseColor = System.Drawing.Color.SteelBlue;
            this.ButtonEnter.BorderColor = System.Drawing.Color.Black;
            this.ButtonEnter.DialogResult = System.Windows.Forms.DialogResult.None;
            this.ButtonEnter.FocusedColor = System.Drawing.Color.Empty;
            this.ButtonEnter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ButtonEnter.ForeColor = System.Drawing.Color.White;
            this.ButtonEnter.Image = null;
            this.ButtonEnter.ImageSize = new System.Drawing.Size(20, 20);
            this.ButtonEnter.Location = new System.Drawing.Point(207, 356);
            this.ButtonEnter.Name = "ButtonEnter";
            this.ButtonEnter.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ButtonEnter.OnHoverBorderColor = System.Drawing.Color.Black;
            this.ButtonEnter.OnHoverForeColor = System.Drawing.Color.White;
            this.ButtonEnter.OnHoverImage = null;
            this.ButtonEnter.OnPressedColor = System.Drawing.Color.Black;
            this.ButtonEnter.Radius = 15;
            this.ButtonEnter.Size = new System.Drawing.Size(159, 42);
            this.ButtonEnter.TabIndex = 2;
            this.ButtonEnter.Text = "Enter";
            this.ButtonEnter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ButtonEnter.Click += new System.EventHandler(this.ButtonEnter_Click);
            this.ButtonEnter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ButtonEnter_KeyPress);
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = this.panel1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.gunaButton9);
            this.panel1.Location = new System.Drawing.Point(1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 42);
            this.panel1.TabIndex = 3;
            // 
            // gunaButton9
            // 
            this.gunaButton9.AnimationHoverSpeed = 0.07F;
            this.gunaButton9.AnimationSpeed = 0.03F;
            this.gunaButton9.BackColor = System.Drawing.Color.Transparent;
            this.gunaButton9.BaseColor = System.Drawing.Color.Transparent;
            this.gunaButton9.BorderColor = System.Drawing.Color.Black;
            this.gunaButton9.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaButton9.FocusedColor = System.Drawing.Color.Empty;
            this.gunaButton9.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.gunaButton9.ForeColor = System.Drawing.Color.White;
            this.gunaButton9.Image = null;
            this.gunaButton9.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaButton9.ImageSize = new System.Drawing.Size(40, 30);
            this.gunaButton9.Location = new System.Drawing.Point(545, 0);
            this.gunaButton9.Name = "gunaButton9";
            this.gunaButton9.OnHoverBaseColor = System.Drawing.Color.LightCoral;
            this.gunaButton9.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaButton9.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaButton9.OnHoverImage = null;
            this.gunaButton9.OnPressedColor = System.Drawing.Color.Black;
            this.gunaButton9.Size = new System.Drawing.Size(59, 42);
            this.gunaButton9.TabIndex = 15;
            this.gunaButton9.Text = "X";
            this.gunaButton9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaButton9.Click += new System.EventHandler(this.gunaButton9_Click_1);
            // 
            // EnterCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(609, 865);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ButtonEnter);
            this.Controls.Add(this.TextBoxEnter);
            this.Controls.Add(this.gunaLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EnterCode";
            this.Text = "EnterCode";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaTextBox TextBoxEnter;
        private Guna.UI.WinForms.GunaButton ButtonEnter;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaButton gunaButton9;
    }
}