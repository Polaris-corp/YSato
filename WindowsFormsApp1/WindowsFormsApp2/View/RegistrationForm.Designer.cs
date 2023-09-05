
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
            this.IDlabel = new System.Windows.Forms.Label();
            this.Namelabel = new System.Windows.Forms.Label();
            this.Pwdlabel = new System.Windows.Forms.Label();
            this.executebutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.UserIdTextBox.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.UserIdTextBox.Location = new System.Drawing.Point(158, 124);
            this.UserIdTextBox.Name = "textBox1";
            this.UserIdTextBox.Size = new System.Drawing.Size(186, 27);
            this.UserIdTextBox.TabIndex = 0;
            // 
            // textBox2
            // 
            this.NameTextBox.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NameTextBox.Location = new System.Drawing.Point(158, 199);
            this.NameTextBox.Name = "textBox2";
            this.NameTextBox.Size = new System.Drawing.Size(186, 27);
            this.NameTextBox.TabIndex = 1;
            // 
            // textBox3
            // 
            this.PwdTextBox.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PwdTextBox.Location = new System.Drawing.Point(158, 279);
            this.PwdTextBox.Name = "textBox3";
            this.PwdTextBox.Size = new System.Drawing.Size(186, 27);
            this.PwdTextBox.TabIndex = 2;
            // 
            // IDlabel
            // 
            this.IDlabel.AutoSize = true;
            this.IDlabel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.IDlabel.Location = new System.Drawing.Point(74, 124);
            this.IDlabel.Name = "IDlabel";
            this.IDlabel.Size = new System.Drawing.Size(27, 20);
            this.IDlabel.TabIndex = 3;
            this.IDlabel.Text = "ID";
            this.IDlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Namelabel
            // 
            this.Namelabel.AutoSize = true;
            this.Namelabel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Namelabel.Location = new System.Drawing.Point(59, 199);
            this.Namelabel.Name = "Namelabel";
            this.Namelabel.Size = new System.Drawing.Size(57, 20);
            this.Namelabel.TabIndex = 4;
            this.Namelabel.Text = "Name";
            // 
            // Pwdlabel
            // 
            this.Pwdlabel.AutoSize = true;
            this.Pwdlabel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Pwdlabel.Location = new System.Drawing.Point(41, 279);
            this.Pwdlabel.Name = "Pwdlabel";
            this.Pwdlabel.Size = new System.Drawing.Size(89, 20);
            this.Pwdlabel.TabIndex = 5;
            this.Pwdlabel.Text = "Password";
            // 
            // executebutton
            // 
            this.executebutton.Location = new System.Drawing.Point(501, 257);
            this.executebutton.Name = "executebutton";
            this.executebutton.Size = new System.Drawing.Size(202, 122);
            this.executebutton.TabIndex = 6;
            this.executebutton.Text = "登録";
            this.executebutton.UseVisualStyleBackColor = true;
            this.executebutton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.executebutton);
            this.Controls.Add(this.Pwdlabel);
            this.Controls.Add(this.Namelabel);
            this.Controls.Add(this.IDlabel);
            this.Controls.Add(this.PwdTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.UserIdTextBox);
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
        private System.Windows.Forms.Label IDlabel;
        private System.Windows.Forms.Label Namelabel;
        private System.Windows.Forms.Label Pwdlabel;
        private System.Windows.Forms.Button executebutton;
    }
}