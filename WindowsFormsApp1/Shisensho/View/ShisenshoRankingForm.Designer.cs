
namespace Shisensho
{
    partial class ShisenshoRankingForm
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
            this.btnRankingRight = new System.Windows.Forms.Button();
            this.btnRankingLeft = new System.Windows.Forms.Button();
            this.lblRegistering = new System.Windows.Forms.Label();
            this.lblResultMessage = new System.Windows.Forms.Label();
            this.lblResultTimeMessage = new System.Windows.Forms.Label();
            this.lblRankingTop5 = new System.Windows.Forms.Label();
            this.lblRanking5th = new System.Windows.Forms.Label();
            this.lblRanking4th = new System.Windows.Forms.Label();
            this.lblRanking3rd = new System.Windows.Forms.Label();
            this.lblRanking2nd = new System.Windows.Forms.Label();
            this.lblRanking1st = new System.Windows.Forms.Label();
            this.txtNameInputField = new System.Windows.Forms.TextBox();
            this.pnlRegistration = new System.Windows.Forms.Panel();
            this.btnRegistration = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlRegistration.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRankingRight
            // 
            this.btnRankingRight.Location = new System.Drawing.Point(210, 226);
            this.btnRankingRight.Name = "btnRankingRight";
            this.btnRankingRight.Size = new System.Drawing.Size(49, 23);
            this.btnRankingRight.TabIndex = 22;
            this.btnRankingRight.Text = "いいえ";
            this.btnRankingRight.UseVisualStyleBackColor = true;
            this.btnRankingRight.Click += new System.EventHandler(this.btnRankingRight_Click);
            // 
            // btnRankingLeft
            // 
            this.btnRankingLeft.Location = new System.Drawing.Point(155, 226);
            this.btnRankingLeft.Name = "btnRankingLeft";
            this.btnRankingLeft.Size = new System.Drawing.Size(49, 23);
            this.btnRankingLeft.TabIndex = 21;
            this.btnRankingLeft.Text = "はい";
            this.btnRankingLeft.UseVisualStyleBackColor = true;
            this.btnRankingLeft.Click += new System.EventHandler(this.btnRankingLeft_Click);
            // 
            // lblRegistering
            // 
            this.lblRegistering.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblRegistering.Location = new System.Drawing.Point(16, 227);
            this.lblRegistering.Name = "lblRegistering";
            this.lblRegistering.Size = new System.Drawing.Size(133, 20);
            this.lblRegistering.TabIndex = 20;
            this.lblRegistering.Text = "登録しますか？";
            // 
            // lblResultMessage
            // 
            this.lblResultMessage.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblResultMessage.Location = new System.Drawing.Point(19, 194);
            this.lblResultMessage.Name = "lblResultMessage";
            this.lblResultMessage.Size = new System.Drawing.Size(253, 20);
            this.lblResultMessage.TabIndex = 19;
            this.lblResultMessage.Text = "New Record !!!";
            this.lblResultMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblResultMessage.Visible = false;
            // 
            // lblResultTimeMessage
            // 
            this.lblResultTimeMessage.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblResultTimeMessage.Location = new System.Drawing.Point(19, 174);
            this.lblResultTimeMessage.Name = "lblResultTimeMessage";
            this.lblResultTimeMessage.Size = new System.Drawing.Size(253, 20);
            this.lblResultTimeMessage.TabIndex = 18;
            this.lblResultTimeMessage.Text = "あなたのタイムはHH:MM:SSでした！";
            this.lblResultTimeMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblRankingTop5
            // 
            this.lblRankingTop5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblRankingTop5.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblRankingTop5.Location = new System.Drawing.Point(14, 4);
            this.lblRankingTop5.Name = "lblRankingTop5";
            this.lblRankingTop5.Size = new System.Drawing.Size(258, 30);
            this.lblRankingTop5.TabIndex = 17;
            this.lblRankingTop5.Text = "ランキング TOP 5";
            this.lblRankingTop5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRanking5th
            // 
            this.lblRanking5th.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblRanking5th.Location = new System.Drawing.Point(15, 136);
            this.lblRanking5th.Name = "lblRanking5th";
            this.lblRanking5th.Size = new System.Drawing.Size(257, 23);
            this.lblRanking5th.TabIndex = 16;
            this.lblRanking5th.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblRanking4th
            // 
            this.lblRanking4th.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblRanking4th.Location = new System.Drawing.Point(15, 113);
            this.lblRanking4th.Name = "lblRanking4th";
            this.lblRanking4th.Size = new System.Drawing.Size(257, 23);
            this.lblRanking4th.TabIndex = 15;
            this.lblRanking4th.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblRanking3rd
            // 
            this.lblRanking3rd.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblRanking3rd.Location = new System.Drawing.Point(15, 90);
            this.lblRanking3rd.Name = "lblRanking3rd";
            this.lblRanking3rd.Size = new System.Drawing.Size(257, 23);
            this.lblRanking3rd.TabIndex = 14;
            this.lblRanking3rd.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblRanking2nd
            // 
            this.lblRanking2nd.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblRanking2nd.Location = new System.Drawing.Point(15, 67);
            this.lblRanking2nd.Name = "lblRanking2nd";
            this.lblRanking2nd.Size = new System.Drawing.Size(257, 23);
            this.lblRanking2nd.TabIndex = 13;
            this.lblRanking2nd.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblRanking1st
            // 
            this.lblRanking1st.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblRanking1st.Location = new System.Drawing.Point(15, 44);
            this.lblRanking1st.Name = "lblRanking1st";
            this.lblRanking1st.Size = new System.Drawing.Size(257, 23);
            this.lblRanking1st.TabIndex = 12;
            this.lblRanking1st.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtNameInputField
            // 
            this.txtNameInputField.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtNameInputField.Location = new System.Drawing.Point(22, 30);
            this.txtNameInputField.MaxLength = 10;
            this.txtNameInputField.Name = "txtNameInputField";
            this.txtNameInputField.Size = new System.Drawing.Size(127, 22);
            this.txtNameInputField.TabIndex = 23;
            // 
            // pnlRegistration
            // 
            this.pnlRegistration.Controls.Add(this.btnRegistration);
            this.pnlRegistration.Controls.Add(this.label1);
            this.pnlRegistration.Controls.Add(this.btnCancel);
            this.pnlRegistration.Controls.Add(this.txtNameInputField);
            this.pnlRegistration.Location = new System.Drawing.Point(0, 197);
            this.pnlRegistration.Name = "pnlRegistration";
            this.pnlRegistration.Size = new System.Drawing.Size(284, 61);
            this.pnlRegistration.TabIndex = 24;
            this.pnlRegistration.Visible = false;
            // 
            // btnRegistration
            // 
            this.btnRegistration.Location = new System.Drawing.Point(155, 30);
            this.btnRegistration.Name = "btnRegistration";
            this.btnRegistration.Size = new System.Drawing.Size(49, 23);
            this.btnRegistration.TabIndex = 26;
            this.btnRegistration.Text = "登録";
            this.btnRegistration.UseVisualStyleBackColor = true;
            this.btnRegistration.Click += new System.EventHandler(this.btnRegistration_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(210, 30);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(49, 23);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ShisenshoRankingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pnlRegistration);
            this.Controls.Add(this.btnRankingRight);
            this.Controls.Add(this.btnRankingLeft);
            this.Controls.Add(this.lblRegistering);
            this.Controls.Add(this.lblResultMessage);
            this.Controls.Add(this.lblResultTimeMessage);
            this.Controls.Add(this.lblRankingTop5);
            this.Controls.Add(this.lblRanking5th);
            this.Controls.Add(this.lblRanking4th);
            this.Controls.Add(this.lblRanking3rd);
            this.Controls.Add(this.lblRanking2nd);
            this.Controls.Add(this.lblRanking1st);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShisenshoRankingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Result";
            this.Load += new System.EventHandler(this.ShisenshoRankingForm_Load);
            this.pnlRegistration.ResumeLayout(false);
            this.pnlRegistration.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRankingRight;
        private System.Windows.Forms.Button btnRankingLeft;
        private System.Windows.Forms.Label lblRegistering;
        private System.Windows.Forms.Label lblResultMessage;
        private System.Windows.Forms.Label lblResultTimeMessage;
        private System.Windows.Forms.Label lblRankingTop5;
        private System.Windows.Forms.Label lblRanking5th;
        private System.Windows.Forms.Label lblRanking4th;
        private System.Windows.Forms.Label lblRanking3rd;
        private System.Windows.Forms.Label lblRanking2nd;
        private System.Windows.Forms.Label lblRanking1st;
        private System.Windows.Forms.TextBox txtNameInputField;
        private System.Windows.Forms.Panel pnlRegistration;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegistration;
    }
}