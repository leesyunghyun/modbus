namespace Modbus_Master
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxSelect = new System.Windows.Forms.ComboBox();
            this.textBoxip = new System.Windows.Forms.TextBox();
            this.textBoxport = new System.Windows.Forms.TextBox();
            this.buttonTCP = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDelayPoll = new System.Windows.Forms.TextBox();
            this.textBoxRsnTO = new System.Windows.Forms.TextBox();
            this.textBoxCntTO = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonSerial = new System.Windows.Forms.Button();
            this.comboBoxStopBit = new System.Windows.Forms.ComboBox();
            this.comboBoxParity = new System.Windows.Forms.ComboBox();
            this.comboBoxBit = new System.Windows.Forms.ComboBox();
            this.comboBoxBaud = new System.Windows.Forms.ComboBox();
            this.comboBoxCom = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButtonASCII = new System.Windows.Forms.RadioButton();
            this.radioButtonRtu = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addressChangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label9 = new System.Windows.Forms.Label();
            this.labelState = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.multiRegisterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxSelect
            // 
            this.comboBoxSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelect.FormattingEnabled = true;
            this.comboBoxSelect.Location = new System.Drawing.Point(6, 22);
            this.comboBoxSelect.Name = "comboBoxSelect";
            this.comboBoxSelect.Size = new System.Drawing.Size(121, 20);
            this.comboBoxSelect.TabIndex = 0;
            this.comboBoxSelect.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelect_SelectedIndexChanged);
            // 
            // textBoxip
            // 
            this.textBoxip.Location = new System.Drawing.Point(6, 33);
            this.textBoxip.Name = "textBoxip";
            this.textBoxip.Size = new System.Drawing.Size(77, 21);
            this.textBoxip.TabIndex = 1;
            this.textBoxip.Text = "127.0.0.1";
            // 
            // textBoxport
            // 
            this.textBoxport.Location = new System.Drawing.Point(89, 33);
            this.textBoxport.Name = "textBoxport";
            this.textBoxport.Size = new System.Drawing.Size(38, 21);
            this.textBoxport.TabIndex = 2;
            this.textBoxport.Text = "502";
            // 
            // buttonTCP
            // 
            this.buttonTCP.Location = new System.Drawing.Point(6, 177);
            this.buttonTCP.Name = "buttonTCP";
            this.buttonTCP.Size = new System.Drawing.Size(121, 19);
            this.buttonTCP.TabIndex = 3;
            this.buttonTCP.Text = "Connect";
            this.buttonTCP.UseVisualStyleBackColor = true;
            this.buttonTCP.Click += new System.EventHandler(this.buttonTCP_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxSelect);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 51);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxDelayPoll);
            this.groupBox2.Controls.Add(this.textBoxRsnTO);
            this.groupBox2.Controls.Add(this.textBoxCntTO);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.buttonTCP);
            this.groupBox2.Controls.Add(this.textBoxip);
            this.groupBox2.Controls.Add(this.textBoxport);
            this.groupBox2.Location = new System.Drawing.Point(12, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(133, 201);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tcp/ip";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(89, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "[ms]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(89, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "[ms]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(89, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "[ms]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "Delay Between Polls";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "Response Timeout";
            // 
            // textBoxDelayPoll
            // 
            this.textBoxDelayPoll.Location = new System.Drawing.Point(6, 150);
            this.textBoxDelayPoll.Name = "textBoxDelayPoll";
            this.textBoxDelayPoll.Size = new System.Drawing.Size(77, 21);
            this.textBoxDelayPoll.TabIndex = 7;
            this.textBoxDelayPoll.Text = "20";
            // 
            // textBoxRsnTO
            // 
            this.textBoxRsnTO.Location = new System.Drawing.Point(6, 111);
            this.textBoxRsnTO.Name = "textBoxRsnTO";
            this.textBoxRsnTO.Size = new System.Drawing.Size(77, 21);
            this.textBoxRsnTO.TabIndex = 7;
            this.textBoxRsnTO.Text = "1000";
            // 
            // textBoxCntTO
            // 
            this.textBoxCntTO.Location = new System.Drawing.Point(6, 72);
            this.textBoxCntTO.Name = "textBoxCntTO";
            this.textBoxCntTO.Size = new System.Drawing.Size(77, 21);
            this.textBoxCntTO.TabIndex = 7;
            this.textBoxCntTO.Text = "3000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Connect Timeout";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP Address";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonSerial);
            this.groupBox3.Controls.Add(this.comboBoxStopBit);
            this.groupBox3.Controls.Add(this.comboBoxParity);
            this.groupBox3.Controls.Add(this.comboBoxBit);
            this.groupBox3.Controls.Add(this.comboBoxBaud);
            this.groupBox3.Controls.Add(this.comboBoxCom);
            this.groupBox3.Location = new System.Drawing.Point(151, 92);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(155, 201);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Serial Settings";
            // 
            // buttonSerial
            // 
            this.buttonSerial.Location = new System.Drawing.Point(6, 175);
            this.buttonSerial.Name = "buttonSerial";
            this.buttonSerial.Size = new System.Drawing.Size(143, 23);
            this.buttonSerial.TabIndex = 1;
            this.buttonSerial.Text = "Connect";
            this.buttonSerial.UseVisualStyleBackColor = true;
            // 
            // comboBoxStopBit
            // 
            this.comboBoxStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStopBit.FormattingEnabled = true;
            this.comboBoxStopBit.Location = new System.Drawing.Point(6, 147);
            this.comboBoxStopBit.Name = "comboBoxStopBit";
            this.comboBoxStopBit.Size = new System.Drawing.Size(143, 20);
            this.comboBoxStopBit.TabIndex = 0;
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Location = new System.Drawing.Point(6, 114);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(143, 20);
            this.comboBoxParity.TabIndex = 0;
            // 
            // comboBoxBit
            // 
            this.comboBoxBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBit.FormattingEnabled = true;
            this.comboBoxBit.Location = new System.Drawing.Point(6, 77);
            this.comboBoxBit.Name = "comboBoxBit";
            this.comboBoxBit.Size = new System.Drawing.Size(94, 20);
            this.comboBoxBit.TabIndex = 0;
            // 
            // comboBoxBaud
            // 
            this.comboBoxBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaud.FormattingEnabled = true;
            this.comboBoxBaud.Location = new System.Drawing.Point(6, 46);
            this.comboBoxBaud.Name = "comboBoxBaud";
            this.comboBoxBaud.Size = new System.Drawing.Size(94, 20);
            this.comboBoxBaud.TabIndex = 0;
            // 
            // comboBoxCom
            // 
            this.comboBoxCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCom.FormattingEnabled = true;
            this.comboBoxCom.Location = new System.Drawing.Point(6, 20);
            this.comboBoxCom.Name = "comboBoxCom";
            this.comboBoxCom.Size = new System.Drawing.Size(143, 20);
            this.comboBoxCom.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButtonASCII);
            this.groupBox4.Controls.Add(this.radioButtonRtu);
            this.groupBox4.Location = new System.Drawing.Point(159, 35);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(147, 51);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mode";
            // 
            // radioButtonASCII
            // 
            this.radioButtonASCII.AutoSize = true;
            this.radioButtonASCII.Location = new System.Drawing.Point(77, 25);
            this.radioButtonASCII.Name = "radioButtonASCII";
            this.radioButtonASCII.Size = new System.Drawing.Size(54, 16);
            this.radioButtonASCII.TabIndex = 0;
            this.radioButtonASCII.Text = "ASCII";
            this.radioButtonASCII.UseVisualStyleBackColor = true;
            // 
            // radioButtonRtu
            // 
            this.radioButtonRtu.AutoSize = true;
            this.radioButtonRtu.Checked = true;
            this.radioButtonRtu.Location = new System.Drawing.Point(13, 24);
            this.radioButtonRtu.Name = "radioButtonRtu";
            this.radioButtonRtu.Size = new System.Drawing.Size(47, 16);
            this.radioButtonRtu.TabIndex = 0;
            this.radioButtonRtu.TabStop = true;
            this.radioButtonRtu.Text = "RTU";
            this.radioButtonRtu.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Address,
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(312, 36);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.Size = new System.Drawing.Size(334, 257);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Address
            // 
            this.Address.Frozen = true;
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Alias";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Value";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.Width = 90;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(655, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addressChangeToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.multiRegisterToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // addressChangeToolStripMenuItem
            // 
            this.addressChangeToolStripMenuItem.Name = "addressChangeToolStripMenuItem";
            this.addressChangeToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.addressChangeToolStripMenuItem.Text = "Address Change";
            this.addressChangeToolStripMenuItem.Click += new System.EventHandler(this.addressChangeToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(502, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 10;
            this.label9.Text = "State :";
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.ForeColor = System.Drawing.Color.Red;
            this.labelState.Location = new System.Drawing.Point(550, 8);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(72, 12);
            this.labelState.TabIndex = 11;
            this.labelState.Text = "No Connect";
            // 
            // multiRegisterToolStripMenuItem
            // 
            this.multiRegisterToolStripMenuItem.Name = "multiRegisterToolStripMenuItem";
            this.multiRegisterToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.multiRegisterToolStripMenuItem.Text = "Multi Register";
            this.multiRegisterToolStripMenuItem.Click += new System.EventHandler(this.multiRegisterToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(655, 299);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.Text = "ModbusPoll";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSelect;
        private System.Windows.Forms.TextBox textBoxip;
        private System.Windows.Forms.TextBox textBoxport;
        private System.Windows.Forms.Button buttonTCP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDelayPoll;
        private System.Windows.Forms.TextBox textBoxRsnTO;
        private System.Windows.Forms.TextBox textBoxCntTO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonSerial;
        private System.Windows.Forms.ComboBox comboBoxStopBit;
        private System.Windows.Forms.ComboBox comboBoxParity;
        private System.Windows.Forms.ComboBox comboBoxBit;
        private System.Windows.Forms.ComboBox comboBoxBaud;
        private System.Windows.Forms.ComboBox comboBoxCom;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButtonASCII;
        private System.Windows.Forms.RadioButton radioButtonRtu;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addressChangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem multiRegisterToolStripMenuItem;
    }
}

