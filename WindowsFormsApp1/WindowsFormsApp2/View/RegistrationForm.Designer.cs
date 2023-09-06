
namespace WindowsFormsApp2
{
    partial class RegistrationForm
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
            this.UserIdTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.PwdTextBox = new System.Windows.Forms.TextBox();
            this.IdLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.PwdLabel = new System.Windows.Forms.Label();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserIdTextBox
            // 
            this.UserIdTextBox.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.UserIdTextBox.Location = new System.Drawing.Point(118, 99);
            this.UserIdTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UserIdTextBox.Name = "UserIdTextBox";
            this.UserIdTextBox.ReadOnly = true;
            this.UserIdTextBox.Size = new System.Drawing.Size(140, 23);
            this.UserIdTextBox.TabIndex = 0;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NameTextBox.Location = new System.Drawing.Point(118, 159);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(140, 23);
            this.NameTextBox.TabIndex = 1;
            // 
            // PwdTextBox
            // 
            this.PwdTextBox.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PwdTextBox.Location = new System.Drawing.Point(118, 223);
            this.PwdTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PwdTextBox.Name = "PwdTextBox";
            this.PwdTextBox.Size = new System.Drawing.Size(140, 23);
            this.PwdTextBox.TabIndex = 2;
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.IdLabel.Location = new System.Drawing.Point(56, 99);
            this.IdLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(22, 16);
            this.IdLabel.TabIndex = 3;
            this.IdLabel.Text = "ID";
            this.IdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NameLabel.Location = new System.Drawing.Point(44, 159);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(46, 16);
            this.NameLabel.TabIndex = 4;
            this.NameLabel.Text = "Name";
            // 
            // PwdLabel
            // 
            this.PwdLabel.AutoSize = true;
            this.PwdLabel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PwdLabel.Location = new System.Drawing.Point(31, 223);
            this.PwdLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PwdLabel.Name = "PwdLabel";
            this.PwdLabel.Size = new System.Drawing.Size(72, 16);
            this.PwdLabel.TabIndex = 5;
            this.PwdLabel.Text = "Password";
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Location = new System.Drawing.Point(376, 206);
            this.ExecuteButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(152, 98);
            this.ExecuteButton.TabIndex = 6;
            this.ExecuteButton.Text = "登録";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(376, 62);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(152, 98);
            this.DeleteButton.TabIndex = 7;
            this.DeleteButton.Text = "削除";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Visible = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.ExecuteButton);
            this.Controls.Add(this.PwdLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.IdLabel);
            this.Controls.Add(this.PwdTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.UserIdTextBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "RegistrationForm";
            this.Text = "RegistrationForm";
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserIdTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox PwdTextBox;
        private System.Windows.Forms.Label IdLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label PwdLabel;
        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.Button DeleteButton;
    }
}