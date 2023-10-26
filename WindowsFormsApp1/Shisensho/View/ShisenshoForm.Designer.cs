
namespace Shisensho
{
    partial class Shisensho
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.reStartButton = new System.Windows.Forms.Button();
            this.btnHint = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // reStartButton
            // 
            this.reStartButton.Location = new System.Drawing.Point(1076, -1);
            this.reStartButton.Name = "reStartButton";
            this.reStartButton.Size = new System.Drawing.Size(65, 58);
            this.reStartButton.TabIndex = 0;
            this.reStartButton.Text = "NewGame";
            this.reStartButton.UseVisualStyleBackColor = true;
            this.reStartButton.Click += new System.EventHandler(this.reStartButton_Click);
            // 
            // btnHint
            // 
            this.btnHint.Location = new System.Drawing.Point(1005, -1);
            this.btnHint.Name = "btnHint";
            this.btnHint.Size = new System.Drawing.Size(65, 58);
            this.btnHint.TabIndex = 1;
            this.btnHint.Text = "Hint";
            this.btnHint.UseVisualStyleBackColor = true;
            this.btnHint.Click += new System.EventHandler(this.btnHint_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoEllipsis = true;
            this.lblTimer.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.lblTimer.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTimer.Location = new System.Drawing.Point(512, -1);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(106, 27);
            this.lblTimer.TabIndex = 2;
            // 
            // Shisensho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(1140, 761);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnHint);
            this.Controls.Add(this.reStartButton);
            this.Name = "Shisensho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "四川省";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button reStartButton;
        private System.Windows.Forms.Button btnHint;
        private System.Windows.Forms.Label lblTimer;
    }
}

