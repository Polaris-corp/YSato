﻿
namespace WindowsFormsApp2.View
{
    partial class LoginForm
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
            this.lblPwd = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.lblUserId = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblWarningStatement = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPwd.Location = new System.Drawing.Point(177, 126);
            this.lblPwd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(84, 15);
            this.lblPwd.TabIndex = 9;
            this.lblPwd.Text = "PASSWORD";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(265, 122);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPwd.MaxLength = 8;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(105, 19);
            this.txtPwd.TabIndex = 8;
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblUserId.Location = new System.Drawing.Point(188, 91);
            this.lblUserId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(57, 15);
            this.lblUserId.TabIndex = 7;
            this.lblUserId.Text = "USERID";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(265, 91);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUserId.MaxLength = 8;
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(105, 19);
            this.txtUserId.TabIndex = 6;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(265, 208);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(104, 70);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "ログイン";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // lblWarningStatement
            // 
            this.lblWarningStatement.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblWarningStatement.Location = new System.Drawing.Point(215, 183);
            this.lblWarningStatement.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWarningStatement.Name = "lblWarningStatement";
            this.lblWarningStatement.Size = new System.Drawing.Size(219, 23);
            this.lblWarningStatement.TabIndex = 10;
            this.lblWarningStatement.Text = "5分間で3回間違えるとロックされます";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.lblWarningStatement);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.btnLogin);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "LoginForm";
            this.Text = "ログイン";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblWarningStatement;
    }
}