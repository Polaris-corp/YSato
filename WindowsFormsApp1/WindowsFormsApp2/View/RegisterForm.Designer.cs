
namespace WindowsFormsApp2
{
    partial class RegisterForm
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
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.lblUserId = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.rbtAvailable = new System.Windows.Forms.RadioButton();
            this.rbtNotAvailable = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txtUserId
            // 
            this.txtUserId.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtUserId.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtUserId.Location = new System.Drawing.Point(163, 62);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUserId.MaxLength = 8;
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.ReadOnly = true;
            this.txtUserId.Size = new System.Drawing.Size(140, 23);
            this.txtUserId.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtName.Location = new System.Drawing.Point(163, 127);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtName.MaxLength = 8;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(140, 23);
            this.txtName.TabIndex = 1;
            // 
            // txtPwd
            // 
            this.txtPwd.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtPwd.Location = new System.Drawing.Point(163, 191);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPwd.MaxLength = 8;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(140, 23);
            this.txtPwd.TabIndex = 2;
            // 
            // lblUserId
            // 
            this.lblUserId.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblUserId.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUserId.Location = new System.Drawing.Point(46, 62);
            this.lblUserId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(85, 25);
            this.lblUserId.TabIndex = 3;
            this.lblUserId.Text = "USERID";
            this.lblUserId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblName.Location = new System.Drawing.Point(66, 127);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(56, 25);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "NAME";
            // 
            // lblPwd
            // 
            this.lblPwd.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPwd.Location = new System.Drawing.Point(46, 194);
            this.lblPwd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(95, 25);
            this.lblPwd.TabIndex = 5;
            this.lblPwd.Text = "PASSWORD";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(376, 206);
            this.btnExecute.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(152, 98);
            this.btnExecute.TabIndex = 6;
            this.btnExecute.Text = "登録";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.BtnExecute_Click);
            // 
            // rbtAvailable
            // 
            this.rbtAvailable.AutoSize = true;
            this.rbtAvailable.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rbtAvailable.Location = new System.Drawing.Point(90, 266);
            this.rbtAvailable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbtAvailable.Name = "rbtAvailable";
            this.rbtAvailable.Size = new System.Drawing.Size(70, 19);
            this.rbtAvailable.TabIndex = 8;
            this.rbtAvailable.TabStop = true;
            this.rbtAvailable.Text = "利用可";
            this.rbtAvailable.UseVisualStyleBackColor = true;
            // 
            // rbtNotAvailable
            // 
            this.rbtNotAvailable.AutoSize = true;
            this.rbtNotAvailable.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rbtNotAvailable.Location = new System.Drawing.Point(201, 266);
            this.rbtNotAvailable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbtNotAvailable.Name = "rbtNotAvailable";
            this.rbtNotAvailable.Size = new System.Drawing.Size(85, 19);
            this.rbtNotAvailable.TabIndex = 9;
            this.rbtNotAvailable.TabStop = true;
            this.rbtNotAvailable.Text = "利用不可";
            this.rbtNotAvailable.UseVisualStyleBackColor = true;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.rbtNotAvailable);
            this.Controls.Add(this.rbtAvailable);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtUserId);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "RegisterForm";
            this.Text = "ユーザーの登録と変更";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.RadioButton rbtAvailable;
        private System.Windows.Forms.RadioButton rbtNotAvailable;
    }
}