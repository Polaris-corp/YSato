
namespace WindowsFormsApp2
{
    partial class UserListForm
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
            this.userListGridView = new System.Windows.Forms.DataGridView();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.cmbViewType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.userListGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // userListGridView
            // 
            this.userListGridView.AllowUserToAddRows = false;
            this.userListGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.userListGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userListGridView.Location = new System.Drawing.Point(231, 56);
            this.userListGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userListGridView.MultiSelect = false;
            this.userListGridView.Name = "userListGridView";
            this.userListGridView.RowHeadersVisible = false;
            this.userListGridView.RowHeadersWidth = 51;
            this.userListGridView.RowTemplate.Height = 24;
            this.userListGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.userListGridView.Size = new System.Drawing.Size(505, 358);
            this.userListGridView.TabIndex = 0;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(41, 98);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(149, 109);
            this.btnRegister.TabIndex = 1;
            this.btnRegister.Text = "登録";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(41, 261);
            this.btnChange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(149, 109);
            this.btnChange.TabIndex = 2;
            this.btnChange.Text = "変更";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.BtnChange_Click);
            // 
            // cmbViewType
            // 
            this.cmbViewType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbViewType.FormattingEnabled = true;
            this.cmbViewType.Items.AddRange(new object[] {
            "通常表示",
            "削除済み",
            "全件表示"});
            this.cmbViewType.Location = new System.Drawing.Point(615, 28);
            this.cmbViewType.Name = "cmbViewType";
            this.cmbViewType.Size = new System.Drawing.Size(121, 23);
            this.cmbViewType.TabIndex = 4;
            this.cmbViewType.SelectedIndexChanged += new System.EventHandler(this.CmbViewType_SelectedIndexChanged);
            // 
            // UserListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 451);
            this.Controls.Add(this.cmbViewType);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.userListGridView);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UserListForm";
            this.Text = "ユーザー情報一覧";
            this.Load += new System.EventHandler(this.UserListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userListGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView userListGridView;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.ComboBox cmbViewType;
    }
}

