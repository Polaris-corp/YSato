
namespace Shisensho
{
    partial class ShisenshoForm
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
            this.rbtNormalMode = new System.Windows.Forms.RadioButton();
            this.rbtBeginnerMode = new System.Windows.Forms.RadioButton();
            this.lblMessageOrder = new System.Windows.Forms.Label();
            this.lblPlayerCount = new System.Windows.Forms.Label();
            this.txtPlayerCount = new System.Windows.Forms.TextBox();
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
            // rbtNormalMode
            // 
            this.rbtNormalMode.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.rbtNormalMode.Checked = true;
            this.rbtNormalMode.Location = new System.Drawing.Point(902, 10);
            this.rbtNormalMode.Name = "rbtNormalMode";
            this.rbtNormalMode.Size = new System.Drawing.Size(95, 16);
            this.rbtNormalMode.TabIndex = 3;
            this.rbtNormalMode.TabStop = true;
            this.rbtNormalMode.Text = "NormalMode";
            this.rbtNormalMode.UseVisualStyleBackColor = false;
            // 
            // rbtBeginnerMode
            // 
            this.rbtBeginnerMode.AutoSize = true;
            this.rbtBeginnerMode.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.rbtBeginnerMode.Location = new System.Drawing.Point(902, 32);
            this.rbtBeginnerMode.Name = "rbtBeginnerMode";
            this.rbtBeginnerMode.Size = new System.Drawing.Size(95, 16);
            this.rbtBeginnerMode.TabIndex = 4;
            this.rbtBeginnerMode.TabStop = true;
            this.rbtBeginnerMode.Text = "BeginnerMode";
            this.rbtBeginnerMode.UseVisualStyleBackColor = false;
            // 
            // lblMessageOrder
            // 
            this.lblMessageOrder.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.lblMessageOrder.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMessageOrder.Location = new System.Drawing.Point(477, 32);
            this.lblMessageOrder.Name = "lblMessageOrder";
            this.lblMessageOrder.Size = new System.Drawing.Size(172, 23);
            this.lblMessageOrder.TabIndex = 5;
            this.lblMessageOrder.Text = "Player1の番です";
            this.lblMessageOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayerCount
            // 
            this.lblPlayerCount.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.lblPlayerCount.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPlayerCount.Location = new System.Drawing.Point(12, 9);
            this.lblPlayerCount.Name = "lblPlayerCount";
            this.lblPlayerCount.Size = new System.Drawing.Size(71, 17);
            this.lblPlayerCount.TabIndex = 6;
            this.lblPlayerCount.Text = "プレイ人数";
            // 
            // txtPlayerCount
            // 
            this.txtPlayerCount.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtPlayerCount.Location = new System.Drawing.Point(12, 32);
            this.txtPlayerCount.Name = "txtPlayerCount";
            this.txtPlayerCount.Size = new System.Drawing.Size(71, 22);
            this.txtPlayerCount.TabIndex = 7;
            this.txtPlayerCount.Text = "1";
            this.txtPlayerCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ShisenshoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(1140, 761);
            this.Controls.Add(this.txtPlayerCount);
            this.Controls.Add(this.lblPlayerCount);
            this.Controls.Add(this.lblMessageOrder);
            this.Controls.Add(this.rbtBeginnerMode);
            this.Controls.Add(this.rbtNormalMode);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnHint);
            this.Controls.Add(this.reStartButton);
            this.Name = "ShisenshoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "四川省";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button reStartButton;
        private System.Windows.Forms.Button btnHint;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.RadioButton rbtNormalMode;
        private System.Windows.Forms.RadioButton rbtBeginnerMode;
        private System.Windows.Forms.Label lblMessageOrder;
        private System.Windows.Forms.Label lblPlayerCount;
        private System.Windows.Forms.TextBox txtPlayerCount;
    }
}

