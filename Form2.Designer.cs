namespace overrideApp
{
    partial class frmAuth
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
            this.txtAuthPw = new System.Windows.Forms.TextBox();
            this.lblAuthPw = new System.Windows.Forms.Label();
            this.btnAuth = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAuthPw
            // 
            this.txtAuthPw.Location = new System.Drawing.Point(95, 52);
            this.txtAuthPw.Name = "txtAuthPw";
            this.txtAuthPw.PasswordChar = '●';
            this.txtAuthPw.Size = new System.Drawing.Size(100, 20);
            this.txtAuthPw.TabIndex = 0;
            // 
            // lblAuthPw
            // 
            this.lblAuthPw.AutoSize = true;
            this.lblAuthPw.Location = new System.Drawing.Point(36, 55);
            this.lblAuthPw.Name = "lblAuthPw";
            this.lblAuthPw.Size = new System.Drawing.Size(53, 13);
            this.lblAuthPw.TabIndex = 1;
            this.lblAuthPw.Text = "Password";
            // 
            // btnAuth
            // 
            this.btnAuth.Location = new System.Drawing.Point(95, 90);
            this.btnAuth.Name = "btnAuth";
            this.btnAuth.Size = new System.Drawing.Size(75, 23);
            this.btnAuth.TabIndex = 2;
            this.btnAuth.Text = "Login";
            this.btnAuth.UseVisualStyleBackColor = true;
            this.btnAuth.Click += new System.EventHandler(this.btnAuth_Click);
            // 
            // frmAuth
            // 
            this.AcceptButton = this.btnAuth;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 145);
            this.Controls.Add(this.btnAuth);
            this.Controls.Add(this.lblAuthPw);
            this.Controls.Add(this.txtAuthPw);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAuth";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAuthPw;
        private System.Windows.Forms.Label lblAuthPw;
        private System.Windows.Forms.Button btnAuth;
    }
}