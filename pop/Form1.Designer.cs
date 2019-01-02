namespace pop
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.combDevice = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mac_Lab = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radiolocalhost = new System.Windows.Forms.RadioButton();
            this.radio110 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(412, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "开始监听";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // combDevice
            // 
            this.combDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combDevice.FormattingEnabled = true;
            this.combDevice.Location = new System.Drawing.Point(134, 29);
            this.combDevice.Name = "combDevice";
            this.combDevice.Size = new System.Drawing.Size(272, 20);
            this.combDevice.TabIndex = 1;
            this.combDevice.SelectedIndexChanged += new System.EventHandler(this.combDevice_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(12, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(468, 127);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // Mac_Lab
            // 
            this.Mac_Lab.AutoSize = true;
            this.Mac_Lab.Location = new System.Drawing.Point(234, 9);
            this.Mac_Lab.Name = "Mac_Lab";
            this.Mac_Lab.Size = new System.Drawing.Size(65, 12);
            this.Mac_Lab.TabIndex = 4;
            this.Mac_Lab.Text = "请选择网卡";
            this.Mac_Lab.Click += new System.EventHandler(this.Mac_Lab_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radiolocalhost);
            this.groupBox1.Controls.Add(this.radio110);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(125, 63);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择嗅探模式";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // radiolocalhost
            // 
            this.radiolocalhost.AutoSize = true;
            this.radiolocalhost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.radiolocalhost.Location = new System.Drawing.Point(9, 41);
            this.radiolocalhost.Name = "radiolocalhost";
            this.radiolocalhost.Size = new System.Drawing.Size(88, 16);
            this.radiolocalhost.TabIndex = 1;
            this.radiolocalhost.TabStop = true;
            this.radiolocalhost.Text = "伪造服务器";
            this.radiolocalhost.UseVisualStyleBackColor = true;
            this.radiolocalhost.CheckedChanged += new System.EventHandler(this.radiolocalhost_CheckedChanged);
            // 
            // radio110
            // 
            this.radio110.AutoSize = true;
            this.radio110.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.radio110.Location = new System.Drawing.Point(9, 21);
            this.radio110.Name = "radio110";
            this.radio110.Size = new System.Drawing.Size(96, 16);
            this.radio110.TabIndex = 0;
            this.radio110.TabStop = true;
            this.radio110.Text = "110端口嗅探";
            this.radio110.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 211);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Mac_Lab);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.combDevice);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "邮件密码嗅探";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox combDevice;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label Mac_Lab;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radiolocalhost;
        private System.Windows.Forms.RadioButton radio110;
    }
}

