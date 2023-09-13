
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
            this.txtUserId.Location = new System.Drawing.Point(217, 78);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.ReadOnly = true;
            this.txtUserId.Size = new System.Drawing.Size(185, 27);
            this.txtUserId.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtName.Location = new System.Drawing.Point(217, 159);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(185, 27);
            this.txtName.TabIndex = 1;
            // 
            // txtPwd
            // 
            this.txtPwd.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtPwd.Location = new System.Drawing.Point(217, 239);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(185, 27);
            this.txtPwd.TabIndex = 2;
            // 
            // lblUserId
            // 
            this.lblUserId.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblUserId.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUserId.Location = new System.Drawing.Point(62, 78);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(113, 31);
            this.lblUserId.TabIndex = 3;
            this.lblUserId.Text = "USERID";
            this.lblUserId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblName.Location = new System.Drawing.Point(88, 159);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(75, 31);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "NAME";
            // 
            // lblPwd
            // 
            this.lblPwd.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPwd.Location = new System.Drawing.Point(62, 242);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(127, 31);
            this.lblPwd.TabIndex = 5;
            this.lblPwd.Text = "PASSWORD";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(501, 258);
            this.btnExecute.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(203, 122);
            this.btnExecute.TabIndex = 6;
            this.btnExecute.Text = "登録";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.BtnExecute_Click);
            // 
            // rbtnAvailable
            // 
            this.rbtAvailable.AutoSize = true;
            this.rbtAvailable.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rbtAvailable.Location = new System.Drawing.Point(120, 333);
            this.rbtAvailable.Name = "rbtnAvailable";
            this.rbtAvailable.Size = new System.Drawing.Size(109, 29);
            this.rbtAvailable.TabIndex = 8;
            this.rbtAvailable.TabStop = true;
            this.rbtAvailable.Text = "利用可";
            this.rbtAvailable.UseVisualStyleBackColor = true;
            // 
            // rbtnNotAvailable
            // 
            this.rbtNotAvailable.AutoSize = true;
            this.rbtNotAvailable.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rbtNotAvailable.Location = new System.Drawing.Point(268, 333);
            this.rbtNotAvailable.Name = "rbtnNotAvailable";
            this.rbtNotAvailable.Size = new System.Drawing.Size(133, 29);
            this.rbtNotAvailable.TabIndex = 9;
            this.rbtNotAvailable.TabStop = true;
            this.rbtNotAvailable.Text = "利用不可";
            this.rbtNotAvailable.UseVisualStyleBackColor = true;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 451);
            this.Controls.Add(this.rbtNotAvailable);
            this.Controls.Add(this.rbtAvailable);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtUserId);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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